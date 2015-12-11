using Xamarin.Forms.Platform.iOS;
using UIKit;
using Xamarin.Forms;
using Lisa.Quartets;
using Lisa.Quartets.iOS;

[assembly: ExportRenderer (typeof(UnlockSlider), typeof(UnlockSliderRendererIos))]
namespace Lisa.Quartets.iOS
{
	public class UnlockSliderRendererIos : SliderRenderer
	{
		protected override void OnElementChanged (ElementChangedEventArgs<Slider> e)
		{
			base.OnElementChanged (e);

			if (Control != null) {
				SetBackground(Control);
				SetProgressBar(Control);
				SetThumb(Control);

				Control.MaxValue = 1000;

				Control.TouchUpInside += StoppedDragging;
				Control.TouchUpOutside += StoppedDragging;
				Control.ValueChanged += CheckProgress;
			}
		}

		private void SetThumb(UISlider element)
		{
			element.SetThumbImage(UIImage.FromFile("slide.png"), UIControlState.Normal);

		}

		private void SetBackground(UISlider element)
		{
			element.BackgroundColor = UIColor.Gray;
		}

		private void SetProgressBar(UISlider element)
		{
			element.MaximumTrackTintColor = UIColor.Gray;
			element.MinimumTrackTintColor = UIColor.Gray;
		}

		private void StoppedDragging(object sender, System.EventArgs e)
		{
			var slider = (UnlockSlider)Element;
			if (Control.Value >= 900)
			{
				slider.OnStopDragging();
				Control.Value = 0;
			}
			else
			{
				Control.Value = 0;
			}
		}

		private void CheckProgress(object sender, System.EventArgs e)
		{
			System.Diagnostics.Debug.WriteLine(Control.Value);

			if (Control.Value - _lastProgress < 900)
			{
				_lastProgress = Control.Value;

				if (Control.Value >= 900)
				{
					var slider = (UnlockSlider)Element;
					slider.OnStopDragging();
					Control.Value = 0;
					_lastProgress = 0;
				}
			}
			else
			{
				Control.Value = 0;
				_lastProgress = 0;
			}
		}

		private float _lastProgress;
	}
}