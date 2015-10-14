using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Lisa.Quartets.Mobile
{
	public partial class LockScreen : ContentPage
	{
		public LockScreen ()
		{
			InitializeComponent();
			NavigationPage.SetHasNavigationBar(this, false);
		}

		public void BackClicked(object sender, EventArgs args)
		{
			Navigation.PopAsync();
		}
	}
}