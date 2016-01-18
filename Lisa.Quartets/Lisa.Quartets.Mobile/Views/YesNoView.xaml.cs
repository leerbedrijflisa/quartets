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
            _selectedCard = card;
		}

		public async void YesClicked(object sender, EventArgs args)
		{
           SaveCard();
           await Navigation.PushAsync(new AskCardView());
           Navigation.RemovePage(this);
		}

		public void NoClicked(object sender, EventArgs args)
		{
			Navigation.PushAsync(new LockView());
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