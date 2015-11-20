using System;
using Android.Graphics;
using Android.Widget;
using Lisa.Quartets;
using Lisa.Quartets.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Android.Graphics.Drawables;

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
                GradientDrawable background = new GradientDrawable();
                background.SetColor(Android.Graphics.Color.LightGray);
                background.SetCornerRadius(10);
                Control.SetBackgroundDrawable(background);

                Control.SetPadding(75, 0, 75, 0);
                Control.ProgressDrawable.SetColorFilter(Android.Graphics.Color.LightGray, PorterDuff.Mode.SrcIn);
                Control.SetThumb(this.Resources.GetDrawable(Resource.Drawable.slide));              
            }
        }
    }
}