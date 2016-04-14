using System;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using com.refractored.monodroidtoolkit;
using Lisa.Quartets.Droid;
using Lisa.Quartets.Mobile;
using Android.Views;
using Android.Graphics;

[assembly:ExportRenderer(typeof(CircularSlider), typeof(CircularSliderRenderer))]
namespace Lisa.Quartets.Droid
{
    public class CircularSliderRenderer : ViewRenderer<CircularSlider, HoloCircularProgressBar>
    {
        protected override void OnElementChanged (ElementChangedEventArgs<CircularSlider> e)
        {
            base.OnElementChanged (e);

            if (e.OldElement != null || this.Element == null)
                return;
            

            var progress = new HoloCircularProgressBar (Forms.Context) {
                Max = Element.Max,
                Progress = Element.Progress,
                ProgressColor = Element.ProgressColor.ToAndroid (),
                ProgressBackgroundColor = Element.ProgressBackgroundColor.ToAndroid ()
            };

            SetNativeControl(progress);

            _translateX = (int)(Element.Width * 0.5f);
            _translateY = (int)(Element.Height * 0.5f);                
        }

        protected override void OnElementPropertyChanged (object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged (sender, e);

            if (Control == null || Element == null)
                return;


            if (e.PropertyName == CircularSlider.MaxProperty.PropertyName) {
                Control.Max = Element.Max;
            } else if (e.PropertyName == CircularSlider.ProgressProperty.PropertyName) {
                Control.Progress = Element.Progress;
            }
        }

        public override bool OnTouchEvent(MotionEvent e)
        {
            switch (e.Action)
            {
                case MotionEventActions.Down:
                    OnStartTrackingTouch();
                    UpdateOnTouch(e, true);
                    break;
                case MotionEventActions.Move:
                    UpdateOnTouch(e);
                    CheckForUnlock();
                    break;
                case MotionEventActions.Up:
                    OnStopTrackingTouch();
                    CheckForUnlock();
                    Element.Progress = 0;
                    Pressed = false;
                    break;
                case MotionEventActions.Cancel:
                    OnStopTrackingTouch();
                    Element.Progress = 0;
                    Pressed = false;
                    break;
            }

            return true;
        }

        protected override void OnMeasure(int widthMeasureSpec, int heightMeasureSpec)
        {
            var height = GetDefaultSize(SuggestedMinimumHeight, heightMeasureSpec);
            var width = GetDefaultSize(SuggestedMinimumWidth, widthMeasureSpec);
            var min = Math.Min(width, height);
            float top = 0;
            float left = 0;
            var arcDiameter = 0;

            _translateX = (int)(width * 0.5f);
            _translateY = (int)(height * 0.5f);

            arcDiameter = min - PaddingLeft;
            _radius = arcDiameter / 2;
            top = height / 2 - (arcDiameter / 2);
            left = width / 2 - (arcDiameter / 2);
            _IgnoreRadius = (float)_radius / 4;

            base.OnMeasure(widthMeasureSpec, heightMeasureSpec);
        }

        private void OnStartTrackingTouch()
        {
            if (StartTouch != null)
            {
                StartTouch(this,new CircularSliderTouchEventArg(this));
            }
        }

        private void UpdateOnTouch(MotionEvent e, bool tap = false)
        {
            if (ShouldIgnoreTouch(e.GetX(), e.GetY()))
            {
                return;
            }

            int progress = GetProgress(e.GetX(), e.GetY());

            if (progress > (Element.Progress + (Element.Max * 0.10)))
            {
                return;
            }

            Element.Progress = progress;
        }

        private bool ShouldIgnoreTouch(float xPos, float yPos)
        {
            var ignore = false;
            float x = xPos - _translateX;
            float y = yPos - _translateY;

            float touchRadius = (float)Math.Sqrt(((x * x) + (y * y)));
            if (touchRadius < _IgnoreRadius)
            {
                ignore = true;
            }
            return ignore;
        }

        private void OnStopTrackingTouch()
        {
            if (StopTouch != null)
            {
                StopTouch(this, new CircularSliderTouchEventArg(this));
            }
        }

        private void CheckForUnlock()
        {
            if (Element.Progress > (Element.Max - Element.Max * 0.05))
            {
                Element.OnUnlock();
                Element.Progress = 0;
            }
        }

        private int GetProgress(float xPosition, float yPosition)
        {
            float x = xPosition - _translateX;
            float y = yPosition - _translateY;

            double angle = ConvertToDegrees(Math.Atan2(y, x) + (Math.PI / 2) - ConvertToRadians(Element.Rotation));

            if (angle < 0)
            {
                angle = 360 + angle;
            }

            angle = Math.Round(ValuePerDegree() * angle);

            return (int)Math.Round((Element.Max / 100) * angle);
        }

        private double ConvertToDegrees(double value)
        {
            return value * (180.0 / Math.PI);
        }

        private double ConvertToRadians(double angle)
        {
            return (Math.PI / 180) * angle;
        }

        private float ValuePerDegree()
        {
            return (float)Element.Max / 360;
        }

        public event EventHandler<CircularSliderTouchEventArg> StartTouch;
        public event EventHandler<CircularSliderTouchEventArg> StopTouch;

        private int _radius;
        private int _translateX;
        private int _translateY;
        private float _IgnoreRadius;
//        private readonly RectF _ractangle = new RectF();
    }
}
