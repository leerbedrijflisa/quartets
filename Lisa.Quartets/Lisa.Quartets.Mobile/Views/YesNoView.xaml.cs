using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Lisa.Quartets.Mobile
{
	public partial class YesNoView : ContentPage
	{
		public YesNoView()
		{
			InitializeComponent();
			NavigationPage.SetHasNavigationBar(this, false);
		}

		public void YesClicked(object sender, EventArgs args)
		{
           DisplayAlert("Test", "Ja", "OK");
		}

		public void NoClicked(object sender, EventArgs args)
		{
			Navigation.PushAsync(new LockView());
        }
	}
}