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
			NavigationPage.SetHasNavigationBar(this, false);
		}

		public void BackClicked(object sender, EventArgs args)
		{
            Navigation.PopToRootAsync();
		}
	}
}