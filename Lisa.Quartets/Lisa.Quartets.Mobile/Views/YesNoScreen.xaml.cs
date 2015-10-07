using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Lisa.Quartets.Mobile
{
	public partial class YesNoScreen : ContentPage
	{
		public YesNoScreen ()
		{
			InitializeComponent ();
			NavigationPage.SetHasNavigationBar(this, false);
		}
		async public void JaButtonClicked(object sender, EventArgs args)
		{
			// Asynchronously adds a Page to the top of the navigation stack.
			await Navigation.PushAsync(new StartPage());
		}
		async public void NeeButtonClicked(object sender, EventArgs args)
		{
			await Navigation.PushAsync(new LockScreen());
		}
	}
}

