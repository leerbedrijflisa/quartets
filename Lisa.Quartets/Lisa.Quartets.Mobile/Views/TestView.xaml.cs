using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Lisa.Quartets.Mobile
{
    public partial class TestView : ContentPage
    {
        public TestView()
        {
            InitializeComponent();

            var slider = new CircularSlider {
                WidthRequest = 300,
                HeightRequest = 300,
                Unlock = UnlockedSlider
            };
            var slider2 = new CircularSlider {
                WidthRequest = 300,
                HeightRequest = 300,
                Unlock = UnlockedSlider
            };

            layout.Children.Add(slider);
            layout.Children.Add(slider2);
            this.Content = layout;
        }

       private void UnlockedSlider(object sender, EventArgs e)
        {
            DisplayAlert("alert", "unlock", "ok"); 
        }
    }
}

