using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace Lisa.Quartets.Mobile
{
	public partial class StartView : ContentPage
	{
		public StartView()
		{			
			InitializeComponent();
			NavigationPage.SetHasNavigationBar (this, false);
		}

		void StartButtonClicked(object sender, EventArgs args)
		{
			Navigation.PushAsync (new CardView());
		}
	}
}