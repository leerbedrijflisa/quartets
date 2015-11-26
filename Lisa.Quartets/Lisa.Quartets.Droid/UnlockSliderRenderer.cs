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
                SetBackground(Control);
                SetPogressbar(Control);
                SetThumbImage(Control);

                Control.SetPadding(75, 0, 75, 0);
                Control.StopTrackingTouch += StoppedDragging;
                Control.ProgressChanged += CheckProgress;
            }
        }

        private void SetBackground(SeekBar element)
        {
            GradientDrawable background = new GradientDrawable();
            background.SetColor(Android.Graphics.Color.LightGray);
            background.SetCornerRadius(10);
            element.SetBackgroundDrawable(background);
        }

        private void SetPogressbar(SeekBar element)
        {
            element.ProgressDrawable.SetColorFilter(Android.Graphics.Color.LightGray, PorterDuff.Mode.SrcIn);   
        }

        private void SetThumbImage(SeekBar element)
        {
            element.SetThumb(this.Resources.GetDrawable(Resource.Drawable.slide));
        }

        private void StoppedDragging(object sender, SeekBar.StopTrackingTouchEventArgs e)
        {
            var slider = (UnlockSlider)Element;
            if(Control.Progress >= 900)
            {
                slider.OnStopDragging();
                Control.Progress = 0;
            }
            else
            {
                Control.Progress = 0;
            }

        }

        private void CheckProgress(object sender, SeekBar.ProgressChangedEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine(_lastProgress);
            if((int)Control.Progress - _lastProgress < 900)
            {
                _lastProgress = Control.Progress;

                if (Control.Progress >= 900)
                {
                    var slider = (UnlockSlider)Element;
                    slider.OnStopDragging();
                    Control.Progress = 0;
                    _lastProgress = 0;
                }
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("kom ik hier?");
                Control.Progress = 0;
                _lastProgress = 0;
            }

        }

        private int _lastProgress;
    }
}