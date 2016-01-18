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

                Control.SetPadding(35, 0, 35, 0);
                Control.StopTrackingTouch += StoppedDragging;
                Control.ProgressChanged += CheckProgress;
            }
        }

        private void SetBackground(SeekBar element)
        {
            GradientDrawable background = new GradientDrawable();
            background.SetColor(Android.Graphics.Color.LightGray);
            background.SetCornerRadius(10);
			// TODO: Replace with something that isn't deprecated.
            element.SetBackgroundDrawable(background);
        }

        private void SetPogressbar(SeekBar element)
        {
            element.ProgressDrawable.SetColorFilter(Android.Graphics.Color.LightGray, PorterDuff.Mode.SrcIn);   
        }

        private void SetThumbImage(SeekBar element)
        {
			// TODO: Replace with something that isn't deprecated.
            element.SetThumb(this.Resources.GetDrawable(Resource.Drawable.slide));
        }

        private void StoppedDragging(object sender, SeekBar.StopTrackingTouchEventArgs e)
        {
            var slider = (UnlockSlider) Element;
            if (Control.Progress >= 900)
            {
                slider.OnStopDragging();
            }

            Control.Progress = 0;
        }

        private void CheckProgress(object sender, SeekBar.ProgressChangedEventArgs e)
        {
            if (DidUserDragSlider())
            {
                if (Control.Progress >= 900)
                {
                    Unlock();
                }
            }
            else
            {
                ResetSlider();
            }

            _lastProgress = Control.Progress;
        }

        private void Unlock()
        {
            var slider = (UnlockSlider) Element;
            slider.OnStopDragging();
            ResetSlider();
        }

        private void ResetSlider()
        {
            Control.Progress = 0;
            _lastProgress = 0;
        }

        private bool DidUserDragSlider()
        {
            return (int) Control.Progress - _lastProgress < 900;
        }

        private int _lastProgress;
    }
}