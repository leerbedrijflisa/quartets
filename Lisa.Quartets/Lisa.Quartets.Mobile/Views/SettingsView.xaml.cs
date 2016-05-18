using System;
using Xamarin.Forms;
using System.Collections.Generic;

namespace Lisa.Quartets.Mobile
{
	public partial class SettingsView : ContentPage
	{

		public string delay;

		public SettingsView ()
		{
			InitializeComponent ();

			var Delays = new List<string> () { "4", "6", "8", "10", "12", "14", "16"};
			Picker DelayPicker = new Picker
			{
				Title = "delayPicker",
				VerticalOptions = LayoutOptions.Start,
			};
			DelayPickerPlace.Children.Add (DelayPicker);

			foreach (string delay in Delays)
			{
				DelayPicker.Items.Add (delay);
			}

			DelayPicker.SelectedIndex = 0;

			DelayPicker.SelectedIndexChanged += (sender, args) => 
			{
				delay = DelayPicker.Items [DelayPicker.SelectedIndex];	
			};
		}

		private void SaveSettings(object sender, EventArgs e)
		{  
			if (delay == null)
			{
				delay = "4";
			}
			string settingsDelay = delay;
			_database.SetDelay(settingsDelay);
			Navigation.PushAsync (new StartView ());
		}

		private CardDatabase _database = new CardDatabase();
	}
}