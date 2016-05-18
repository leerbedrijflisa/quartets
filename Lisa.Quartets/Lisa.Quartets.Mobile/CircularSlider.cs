using System;
using Xamarin.Forms;

namespace Lisa.Quartets
{
    public class CircularSlider : BoxView
    {
        public CircularSlider ()
        {
            ProgressBackgroundColor = Color.FromHex("B4BCBC");
            ProgressColor = Color.FromHex("bfdfff");
            ThumbColor = Color.FromHex("3f9eff");
            StrokeWidth = 15;
        }

        public event EventHandler Unlock;

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
        public Color ThumbColor{ get; set;}
        public String Label{ get; set;}
        public int StrokeWidth{ get; set;}
    }
}
