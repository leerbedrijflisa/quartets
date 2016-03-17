using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Lisa.Quartets.Mobile
{
	public partial class SettingsView : ContentPage
	{
		public SettingsView ()
		{
			InitializeComponent ();
		}

		private void SaveSettings(object sender, EventArgs e)
		{            
			string settingsDelay = delayInput.Text;
			_database.SetDelay(settingsDelay);
			Navigation.PushAsync (new StartView ());
		}

		private CardDatabase _database = new CardDatabase();
	}
}