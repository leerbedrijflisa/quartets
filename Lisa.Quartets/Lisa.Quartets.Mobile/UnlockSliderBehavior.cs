using System;

using Xamarin.Forms;

namespace Lisa.Quartets
{
    public class UnlockSliderBehavior : Behavior<Slider>
    {
        protected override void OnAttachedTo(Slider slider)
        {
            slider.ValueChanged += OnSliderValueChanged;
            base.OnAttachedTo(slider);
        }

        protected override void OnDetachingFrom(Slider slider)
        {
            slider.ValueChanged -= OnSliderValueChanged;
            base.OnDetachingFrom(slider);
        }

        void OnSliderValueChanged(object sender, EventArgs args)
        {
            var slider = (UnlockSlider)sender;

            double newValue = slider.Value;
            if (newValue - _oldValue < 10)
            {
                _oldValue = newValue;

                if (slider.Value >= 90)
                {
                    System.Diagnostics.Debug.WriteLine("unlock!");
                }                ​
            }
            else
            {
                slider.Value = 0;
            }
        }

        private double _oldValue;
    }
}