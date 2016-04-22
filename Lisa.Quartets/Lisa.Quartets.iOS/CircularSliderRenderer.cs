using System;
using Xamarin.Forms.Platform.iOS;
using Xamarin.Forms;
using UIKit;
using CoreGraphics;
using System.Drawing;
using Lisa.Quartets.Mobile;
using Lisa.Quartets.iOS;

[assembly: ExportRenderer(typeof(CircularSlider), typeof(CircularSliderRenderer))]
namespace Lisa.Quartets.iOS
{
    class CircularSliderRenderer : ViewRenderer<CircularSlider, UIView>
    {
		public CircularSliderRenderer()
		{
            
		}

        protected override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            SetNeedsDisplay();
        }

        public override void Draw(CGRect rect)
        {
			base.Draw(rect);

            var path = new CGPath();
            _strokeWidth = 10;
            _radius = (float)(Math.Min(rect.Width, rect.Height) / 2) - (_strokeWidth * 2);
            _middleX = (float)rect.GetMidX();
            _middleY = (float)rect.GetMidY();
            _context = UIGraphics.GetCurrentContext();

            _context.SetStrokeColor(Element.ProgressBackgroundColor.ToCGColor());
            _context.SetLineWidth(_strokeWidth);
        
            path.AddArc(_middleX, _middleY, _radius, 0, 2.0f * (float)Math.PI, false);

            _context.AddPath (path);
            _context.DrawPath(CGPathDrawingMode.Stroke);

            if (Element.Progress > 0)
            {
                DrawProgress();
            }

            DrawThumb();
        }

        private void DrawThumb()
        {
            var thumbSize = 45;
            var x = _radius * Math.Cos((Element.Progress - 90) * (float)(Math.PI / 180));
            var y = _radius * Math.Sin((Element.Progress - 90) * (float)(Math.PI / 180));

            x += _middleX - (thumbSize / 2);
            y += _middleY - (thumbSize / 2);

            var rect = new CGRect(x, y, 45, 45);
            var image = new UIImage("knop-test.png");
           

            _context.DrawImage(rect, image.CGImage);
        }

        private void DrawProgress()
        {
            float angle;
            var path = new CGPath();

            _context.SetStrokeColor(Element.ProgressColor.ToCGColor());

            if (Element.Progress == 360)
            {
                Element.Progress = 0;
            }
                
            angle = (float)(Element.Progress - 90) * (float)(Math.PI / 180);


            path.AddArc(_middleX, _middleY, _radius, 1.5f * (float)Math.PI, angle, false);

            _context.AddPath (path);
            _context.DrawPath (CGPathDrawingMode.Stroke);
        }

        public override void TouchesMoved(Foundation.NSSet touches, UIEvent evt)
        {
            base.TouchesMoved(touches, evt);

            UITouch touch = touches.AnyObject as UITouch;

            if (touch != null)
            {
                UpdateOnTouch(touch);
                CheckForUnlock();
            }
        }

        public override void TouchesBegan(Foundation.NSSet touches, UIEvent evt)
        {
            base.TouchesBegan(touches, evt);

            UITouch touch = touches.AnyObject as UITouch;

            if (touch != null)
            {
                UpdateOnTouch(touch);
            }
        }

        public override void TouchesEnded(Foundation.NSSet touches, UIEvent evt)
        {
            base.TouchesEnded(touches, evt);
            Element.Progress = 0;
        }

        public override void TouchesCancelled(Foundation.NSSet touches, UIEvent evt)
        {
            base.TouchesCancelled(touches, evt);
            Element.Progress = 0;
        }

        private void UpdateOnTouch(UITouch touch)
        {
            int progress = GetProgress((float)touch.LocationInView(this).X, (float)touch.LocationInView(this).Y);

            if (progress > (Element.Progress + (360 * 0.10)))
            {
                return;
            }

            Element.Progress = progress;
        }

        private int GetProgress(float xPosition, float yPosition)
        {
            float x = xPosition - _middleX;
            float y = yPosition - _middleY;

            var angle = ConvertToDegrees(Math.Atan2(y, x) + (Math.PI / 2));

            if (angle < 0)
            {
                angle = 360 + angle;
            }

            return (int)Math.Round(angle);
        }

        private void CheckForUnlock()
        {
            if (Element.Progress > (360 - 360 * 0.05))
            {
                Element.OnUnlock();
                Element.Progress = 0;
            }
        }

        private double ConvertToDegrees(double value)
        {
            return value * (180.0 / Math.PI);
        }

        private double ConvertToRadians(double value)
        {
            return (Math.PI / 180) * value;
        }

        private int _strokeWidth;
        private float _radius;
        private float _middleX;
        private float _middleY;
        private CGContext _context;
    }
}