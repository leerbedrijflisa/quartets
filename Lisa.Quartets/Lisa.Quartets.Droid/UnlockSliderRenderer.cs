using System;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Lisa.Quartets;
using Lisa.Quartets.Droid;
using Android.Graphics;
using Android.Widget;

[assembly: ExportRenderer (typeof(UnlockSlider), typeof(UnlockSliderRenderer))]
namespace Lisa.Quartets.Droid
{
    class UnlockSliderRenderer : SliderRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Slider> e)
        {
            base.OnElementChanged(e);
            if (Control != null)
            {
                Control.SetPadding(75, 0, 75, 0);
                Control.ProgressDrawable.SetColorFilter(Android.Graphics.Color.Gray, PorterDuff.Mode.SrcIn);
                Control.SetBackgroundColor(Android.Graphics.Color.Gray);
                Control.SetThumb(this.Resources.GetDrawable(Resource.Drawable.slide));
            }
        }
    }
}