using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Lisa.Quartets.Mobile
{
	public partial class YesNoView : ContentPage
	{
        public YesNoView(Card card)
		{
			InitializeComponent();
			NavigationPage.SetHasNavigationBar(this, false);
            _selectedCard = card;
		}

		public async void YesClicked(object sender, EventArgs args)
		{
           SaveCard();
           Navigation.RemovePage(this);
		   await Navigation.PushAsync(new AskCardView());
		}

		public async void NoClicked(object sender, EventArgs args)
		{
			Navigation.RemovePage(this);
			await Navigation.PushAsync(new LockView());
        }

        private void SaveCard()
        {
            _selectedCard.IsInHand = 1;
            _database.CreateOrUpdateCard(_selectedCard);
            System.Diagnostics.Debug.WriteLine("saved");
        }

        private Card _selectedCard;
        private CardDatabase _database = new CardDatabase();

	}
}