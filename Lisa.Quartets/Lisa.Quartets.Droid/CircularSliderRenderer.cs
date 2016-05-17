using System;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using com.refractored.monodroidtoolkit;
using Lisa.Quartets.Droid;
using Lisa.Quartets.Mobile;
using Lisa.Quartets;
using Android.Views;
using Android.Graphics;
using System.Threading.Tasks;

[assembly:ExportRenderer(typeof(CircularSlider), typeof(CircularSliderRenderer))]
namespace Lisa.Quartets.Droid
{
    public class CircularSliderRenderer : VisualElementRenderer<CircularSlider>
    {
        public CircularSliderRenderer()
        {
            SetWillNotDraw(false);
        }

        protected override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            Invalidate();
        }

        protected override void OnDraw(Canvas canvas)
        {   
            RectF rectF = new RectF(_left, _top, _diameter + _left, _diameter + _top);
            var paint = new Paint
            {
                Color = Element.ProgressBackgroundColor.ToAndroid(),
                AntiAlias = true,
                StrokeWidth = Element.StrokeWidth
            };
            
            paint.SetStyle(Paint.Style.Stroke);

            canvas.DrawArc(rectF, 110, 320, false, paint);

            paint.Color = Element.ProgressColor.ToAndroid();
            canvas.DrawArc(rectF, 110, Element.Progress, false, paint);

            DrawThumb(canvas);

            if (Element.Label != null)
            {                
                DrawLabel(canvas, rectF);  
            }
        }

        private void DrawLabel(Canvas canvas, RectF rectF)
        {
            var paint = new Paint
            {
                    Color = Android.Graphics.Color.Black,
                    AntiAlias = true,
                    TextSize = 50
            };
           
            paint.SetStyle(Paint.Style.Fill);
            var textWidth = paint.MeasureText(Element.Label);

            while (textWidth > rectF.Width())
            {
                paint.TextSize--;
            }

            canvas.DrawText(Element.Label, rectF.CenterX() - textWidth / 2, rectF.CenterY(), paint);
            paint.TextAlign = Paint.Align.Center;
        }

        private void DrawThumb(Canvas canvas)
        {
            var paint = new Paint
            {
                Color  = Element.ThumbColor.ToAndroid(),
                AntiAlias = true,
                StrokeWidth = 10
            };

            float x = (float)(_radius * Math.Cos((Element.Progress + 110) * (float)(Math.PI / 180)));
            float y = (float)(_radius * Math.Sin((Element.Progress + 110) * (float)(Math.PI / 180)));

            x += _middleX;
            y += _middleY;

            canvas.DrawCircle(x, y, _thumbSize, paint);
        }

        private void AnimateToZero()
        {
            for (float i = Element.Progress; i > 0; i--)
            {
                if (_touching || !this.IsShown)
                {
                    return;
                }

                Element.Progress = i;
            }
        }

        protected override void OnMeasure(int widthMeasureSpec, int heightMeasureSpec)
        {
            base.OnMeasure(widthMeasureSpec, heightMeasureSpec);

            var height = GetDefaultSize(SuggestedMinimumHeight, heightMeasureSpec);
            var width = GetDefaultSize(SuggestedMinimumWidth, widthMeasureSpec);
            var min = Math.Min(width, height);

            _thumbSize = Element.StrokeWidth * (float)1.05;
            _diameter = min - Element.StrokeWidth * 2 - _thumbSize;
            _radius = _diameter / 2;
            _left = (width - _diameter) / 2;
            _top = (height - _diameter) / 2;
            _middleX = (int)(width / 2);
            _middleY = (int)(height / 2);
        }

        public override bool OnTouchEvent(MotionEvent e)
        {
            switch (e.Action)
            {
                case MotionEventActions.Down:
                    UpdateOnTouch(e, true);
                    _touching = true;
                    break;
                case MotionEventActions.Move:
                    UpdateOnTouch(e);
                    CheckForUnlock();
                    break;
                case MotionEventActions.Up:
                    CheckForUnlock();
                    _touching = false;
                    AnimateToZero();
                    break;
                case MotionEventActions.Cancel:
                    _touching = false;
                    AnimateToZero();
                    break;
            }

            return true;
        }

        private void UpdateOnTouch(MotionEvent e, bool tap = false)
        {
            int progress = GetProgress(e.GetX(), e.GetY());

            if (progress > (Element.Progress + (320 * 0.10)))
            {
                return;
            }

            Element.Progress = progress;
        }

        private void CheckForUnlock()
        {
            if (Element.Progress > (320 - 320 * 0.025))
            {
                _touching = true;
                Element.OnUnlock();
                Element.Progress = 0;
            }
        }

        private int GetProgress(float xPosition, float yPosition)
        {
            float x = xPosition - _middleX;
            float y = yPosition - _middleY;

            double angle = ConvertToDegrees(Math.Atan2(y, x) + (Math.PI / 2)) - 200;

            if (angle < 0)
            {
                angle = 360 + angle;
            }

            return (int)Math.Round(angle);
        }

        private double ConvertToDegrees(double value)
        {
            return value * (180.0 / Math.PI);
        }

        private double ConvertToRadians(double angle)
        {
            return (Math.PI / 180) * angle;
        }


        private float _top;
        private float _left;
        private int _middleX;
        private int _middleY;
        private float _radius;
        private bool _touching;
        private float _diameter;
        private float _thumbSize;
    }
}
