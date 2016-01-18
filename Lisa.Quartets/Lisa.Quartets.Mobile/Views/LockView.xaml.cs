using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Lisa.Quartets.Mobile
{
	public partial class LockView : ContentPage
	{
		public LockView()
		{
			InitializeComponent();

			// REVIEW: Should we hide the navigation bar in other views as well?
			NavigationPage.SetHasNavigationBar(this, false);
		}

		public void BackClicked(object sender, EventArgs args)
		{
			Navigation.PopAsync();
		}
	}
}