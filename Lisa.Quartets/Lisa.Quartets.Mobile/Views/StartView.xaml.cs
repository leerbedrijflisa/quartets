using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Lisa.Quartets.Mobile
{
	public partial class StartView : ContentPage
	{
		public StartView()
		{
			InitializeComponent();
		}

        private void StartClicked(object sender, EventArgs e)
        {            
            Navigation.InsertPageBefore(new IdleView(), this);
            Navigation.PopAsync();
        }
		private void SettingsClicked(object sender, EventArgs e)
		{
			Navigation.PushAsync (new SettingsView ());
		}
			public void ToggledSwitch()
		{
			var result = _database.GetInstructions ();
			toggledLabel.Text = String.Format ("Switch is now {0}",result.Instruction);
		}
		private CardDatabase _database = new CardDatabase();
	}
}