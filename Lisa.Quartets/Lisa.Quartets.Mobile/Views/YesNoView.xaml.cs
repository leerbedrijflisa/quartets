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
            LoadSelectedImage(card);
			NavigationPage.SetHasNavigationBar(this, false);
		}

		public void YesClicked(object sender, EventArgs args)
		{
            _database.RecieveCard(_selectedCard.Id);
            Navigation.PushAsync(new AskCardView());
		}

		public void NoClicked(object sender, EventArgs args)
		{
            Navigation.PushAsync(new LockView());
        }

        public void LoadSelectedImage(Card card)
        {
            selectedImage.Source = card.FileName;
            selectedImage.CardId = card.Id;
            _selectedCard = card;
        }

        private CardDatabase _database = new CardDatabase();
        private Card _selectedCard;
	}
}