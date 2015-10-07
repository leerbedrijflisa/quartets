using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Lisa.Quartets.Mobile
{
	public partial class LockScreen : ContentPage
	{
		public LockScreen ()
		{
			InitializeComponent ();
			NavigationPage.SetHasNavigationBar(this, false);
		}
		public void BackButtonClicked(object sender, EventArgs args)
		{
			// Asynchronously removes the top Page from the navigation stack.
			Navigation.PopAsync();
		}
	}
}

