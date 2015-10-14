using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace Lisa.Quartets.Mobile
{
    public class App : Application
    {
        public App()
        {
			MainPage = new NavigationPage(new YesNoView());
        }
    }
}