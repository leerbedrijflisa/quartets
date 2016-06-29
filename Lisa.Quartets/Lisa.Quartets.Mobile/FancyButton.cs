using System;
using Xamarin.Forms;

namespace Lisa.Quartets
{
    public class FancyButton : Button
    {
        public FancyButton()
        {
            BackgroundColor = Color.FromHex("c0edd6");
            TextColor = Color.White;
            BorderColor = Color.Black;
            BorderWidth = 1;
            BorderRadius = 20;                
        }
    }
}

