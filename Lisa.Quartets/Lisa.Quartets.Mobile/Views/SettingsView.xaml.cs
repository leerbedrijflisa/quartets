using System;
using Xamarin.Forms;
using System.Collections.Generic;

namespace Lisa.Quartets.Mobile
{
	public partial class SettingsView : ContentPage
	{

		public string delay;
		public string Instruction;

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

		async void switcher_Toggled(object sender, ToggledEventArgs e)
		{
			//The switch settings are saved here and entered into the database for further use.
			bool toggleState = e.Value;
			int Instruction;
			var modalPage = new InstructionsPage ();
			if (toggleState == false) {
				Instruction = 0;
				InstructionLabel.Text = "Instructions are now disabled";
				await Navigation.PushModalAsync (modalPage);
			} else{
				Instruction = 1;
				InstructionLabel.Text = "Instructions are now enabled";
				//await DisplayAlert ("Instructions enabled", "Instructions are enabled", "OK");
				await Navigation.PushAsync (modalPage);
			}
			_database.SetInstructions (Instruction);
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