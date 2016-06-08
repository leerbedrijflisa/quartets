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
			InstructionsEnabled ();
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
		private void InstructionsEnabled()
		{
			var result = _database.GetInstructions();

			if (result.Instruction == 1) {
				InstructionBtn.IsVisible = true;
			} 
			else 
			{
				InstructionBtn.IsVisible = false;
			}
		}
		private void InstructionsClicked(object sender, EventArgs e)
		{
			Navigation.PushAsync (new InstructionsPage ());
		}
		private CardDatabase _database = new CardDatabase();
	}
}