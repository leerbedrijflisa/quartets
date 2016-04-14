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

        public static readonly BindableProperty MaxProperty = 
            BindableProperty.Create<CircularSlider,float> (
                p => p.Max, 100);

        public float Max {
            get { return (float)GetValue (MaxProperty); }
            set { SetValue (MaxProperty, value); }
        }

        public Color ProgressColor { get; set;}
        public Color ProgressBackgroundColor{ get; set;}



        ///Ios test
        public static readonly BindableProperty StrokeColorProperty = BindableProperty.Create<CircularSlider, Color>(s => s.StrokeColor, Color.Default);

        public static readonly BindableProperty StrokeWidthProperty = BindableProperty.Create<CircularSlider, float>(s => s.StrokeWidth, 1f);

        public static readonly BindableProperty IndicatorPercentageProperty = BindableProperty.Create<CircularSlider, float>(s => s.IndicatorPercentage, 0f);

        public static readonly BindableProperty PaddingProperty = BindableProperty.Create<CircularSlider, Thickness>(s => s.Padding, default(Thickness));


        public Color StrokeColor
        {
            get { return (Color)GetValue(StrokeColorProperty); }
            set { SetValue(StrokeColorProperty, value); }
        }

        public float StrokeWidth
        {
            get { return (float)GetValue(StrokeWidthProperty); }
            set { SetValue(StrokeWidthProperty, value); }
        }

        public float IndicatorPercentage
        {
            get { return (float)GetValue(IndicatorPercentageProperty); }
            set
            {
                SetValue(IndicatorPercentageProperty, value);
            }
        }

        public Thickness Padding
        {
            get { return (Thickness)GetValue(PaddingProperty); }
            set { SetValue(PaddingProperty, value); }
        }

    }
}
