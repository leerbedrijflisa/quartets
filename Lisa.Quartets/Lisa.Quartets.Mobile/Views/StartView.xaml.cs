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
            Navigation.PushAsync(new IdleView());
        }

		private void AskCard(object sender, EventArgs e)
        {            
			Navigation.PushAsync(new RequestView());
		}

        private void SelectCardsClicked(object sender, EventArgs e)
		{
            Navigation.PushAsync(new HandEditorView());
		}

        private void GiveCardClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new HandOverView());
        }

//		private void QuartetViewClicked(object sender, EventArgs e)
//		{            
//			Navigation.PushAsync(new QuartetView());
//		}

        private CardImageHolder _cardImageHolder = new CardImageHolder();
	}
}