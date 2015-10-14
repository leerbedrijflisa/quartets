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

		public async void YesClicked(object sender, EventArgs args)
		{
			await Navigation.PushAsync(new StartView());
		}

		public async void NoClicked(object sender, EventArgs args)
		{
			await Navigation.PushAsync(new LockView());
		}
	}
}