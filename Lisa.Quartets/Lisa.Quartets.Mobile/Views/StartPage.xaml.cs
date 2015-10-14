using System;
using System.Collections.Generic;

using Xamarin.Forms;
using System.Linq;

namespace Lisa.Quartets.Mobile
{
	public partial class StartPage : ContentPage
	{
		public StartPage()
		{			
			InitializeComponent();
			NavigationPage.SetHasNavigationBar (this, false);
		}

		void StartButtonClicked(object sender, EventArgs args)
		{
			Navigation.PushAsync (new CardPage ());
		}
	}
}