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

		private void AskCard(object sender, EventArgs e)
		{
			Navigation.PushAsync(new AskCardView());
		}

		private void EndOfTurnClicked(object sender, EventArgs e)
		{
			Navigation.PushAsync(new YesNoView());
		}

        private void SelectCardsClicked(object sender, EventArgs e)
		{
            Navigation.PushAsync(new CardEnlargeView(_cardImageHolder));
		}

        private void GiveCardClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new GiveCardView());
        }

        private CardImageHolder _cardImageHolder = new CardImageHolder();
	}
}