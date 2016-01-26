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

        private void LockViewClicked(object sender, EventArgs e)
        {            
            Navigation.PushAsync(new LockView());
        }

		private void AskCard(object sender, EventArgs e)
        {            
			Navigation.PushAsync(new AskCardView());
		}

        private void SelectCardsClicked(object sender, EventArgs e)
		{
            Navigation.PushAsync(new CardEnlargeView());
		}

        private void GiveCardClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new GiveCardView());
        }


        private CardImageHolder _cardImageHolder = new CardImageHolder();
	}
}