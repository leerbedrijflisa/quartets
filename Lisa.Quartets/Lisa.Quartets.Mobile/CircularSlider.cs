using System;
using Xamarin.Forms;

namespace Lisa.Quartets.Mobile
{
    public class CircularSlider : View
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

        public static readonly BindableProperty MaxProperty = 
            BindableProperty.Create<CircularSlider,float> (
                p => p.Max, 100);

        public float Max {
            get { return (float)GetValue (MaxProperty); }
            set { SetValue (MaxProperty, value); }
        }

        public Color ProgressColor { get; set;}
        public Color ProgressBackgroundColor{ get; set;}
    }
}
