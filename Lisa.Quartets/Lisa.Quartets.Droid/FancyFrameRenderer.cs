using System;
using Lisa.Quartets;
using Lisa.Quartets.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly:ExportRenderer(typeof(FancyFrame), typeof(FancyFrameRenderer))]
namespace Lisa.Quartets.Droid
{
    public class FancyFrameRenderer : FrameRenderer
    {
        public override bool OnTouchEvent(Android.Views.MotionEvent e)
        {
            FancyFrame frame = (FancyFrame)this.Element;
            frame.SendSwipe();

            return base.OnTouchEvent(e);
        }    
    }
}

