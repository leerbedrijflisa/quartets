using System;
using Xamarin.Forms.Platform.iOS;
using Lisa.Quartets.iOS;
using UIKit;
using Xamarin.Forms;
using Lisa.Quartets;

[assembly: ExportRenderer(typeof(FancyFrame), typeof(FancyIosFrameRenderer))]
namespace Lisa.Quartets.iOS
{
    public class FancyIosFrameRenderer : FrameRenderer
    {
        public override void TouchesBegan(Foundation.NSSet touches, UIEvent evt)
        {
            base.TouchesBegan(touches, evt);

            // Any kind of touch should roll the die, so whenever a gesture ends -
            // no matter which one - we simulate a swipe.
            FancyFrame frame = (FancyFrame) this.Element;
            frame.SendSwipe();
        }
    }
}