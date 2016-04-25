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
                ProgressBackgroundColor = Color.FromHex("00a55e"),
                ProgressColor = Color.FromHex("037041"),
                Label = "test"
            };

            var slider2 = new CircularSlider {
                WidthRequest = 300,
                HeightRequest = 300,
                ProgressBackgroundColor = Color.FromHex("d11111"),
                ProgressColor = Color.FromHex("8e0c0c")           
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

