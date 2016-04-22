using System;
using Xamarin.Forms;

namespace Lisa.Quartets.Mobile
{
    public class CircularSlider : BoxView
    {
        public CircularSlider ()
        {
            ProgressColor = Color.FromHex("3498DB");
            ProgressBackgroundColor = Color.FromHex("B4BCBC");
        }

        public EventHandler Unlock;

        public void OnUnlock()
        {
            if (Unlock != null)
            {
                Unlock(this, EventArgs.Empty);
            }
        }

        public static readonly BindableProperty ProgressProperty = 
            BindableProperty.Create<CircularSlider,float> (
                p => p.Progress, 0);

        public float Progress {
            get { return (float)GetValue (ProgressProperty); }
            set { SetValue (ProgressProperty, value); }
        }

        public Color ProgressColor { get; set;}
        public Color ProgressBackgroundColor{ get; set;}
        public String Label { get; set;}
    }
}
