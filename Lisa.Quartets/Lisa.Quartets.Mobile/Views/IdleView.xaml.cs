using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Lisa.Quartets.Mobile
{
	public partial class IdleView : ContentPage
	{
		public IdleView()
		{
			InitializeComponent();
			NavigationPage.SetHasNavigationBar(this, false);
		}

        protected override void OnAppearing()
        {
            _sliderUnlocked = false;
            base.OnAppearing();
        }

        public void RequestCardUnlocked(object sender, EventArgs args)
		{
            if (!_sliderUnlocked)
            {
                _sliderUnlocked = true;
                Navigation.InsertPageBefore(new RequestView(), this);
                Navigation.PopAsync();
            }           
		}

        public void HandOverCardUnlocked(object sender, EventArgs args)
        {
            if (!_sliderUnlocked)
            {
                _sliderUnlocked = true;
                Navigation.PushAsync(new HandOverView());
            }
        }

        public void EditHandUnlocked(object sender, EventArgs args)
        {
            if (!_sliderUnlocked)
            {
                _sliderUnlocked = true;
                Navigation.PushAsync(new HandEditorView(typeof(IdleView)));
            }
        }

        public async void RestartUnlocked(object sender, EventArgs args)
        {
            if (!_sliderUnlocked)
            {
                _sliderUnlocked = true;

                var action = await DisplayAlert("Waarschuwing", "Weet u zeker dat u het spel wilt herstarten?", "Ja", "Nee");

                if (action)
                {
                    _database.ResetCards();   
                    Navigation.InsertPageBefore(new MainMenuView(), this);
                    await Navigation.PopAsync();
                }
                else
                {
                    _sliderUnlocked = false;
                }
            }
        }

        private CardDatabase _database = new CardDatabase();
        private bool _sliderUnlocked = false;
	}
}