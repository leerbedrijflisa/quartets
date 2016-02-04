using System;
using System.Collections.Generic;
using Xamarin.Forms;
using System.Threading.Tasks;

namespace Lisa.Quartets.Mobile
{
	public partial class YesNoView : ContentPage
	{
        public YesNoView(Card card)
		{
			InitializeComponent();
			NavigationPage.SetHasNavigationBar(this, false);
            _selectedCard = card;
            SetSelectedCard();
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

        public void SetSelectedCard()
        {
            CardImage card = new CardImage();
            TapGestureRecognizer gestureRecognizer = new TapGestureRecognizer();
            gestureRecognizer.Tapped += (object sender, EventArgs e) =>
            {
                if (!_soundPlaying)
                {
                    PlaySound();
                }
            };

            card.GestureRecognizers.Add(gestureRecognizer);
            card.Source = _selectedCard.FileName;
            layout.Children.Add(card);
        }

        private void SaveCard()
        {
            _selectedCard.IsInHand = 1;
            _database.CreateOrUpdateCard(_selectedCard);
        }

        public async void PlaySound() 
        {
            _soundPlaying = true;
            DependencyService.Get<IAudio>().PlayFile("vraag");
            await Task.Delay(2000);
            DependencyService.Get<IAudio>().PlayFile(_selectedCard.SoundFile);
            await Task.Delay(2000);
            _soundPlaying = false;
        }

        private bool _soundPlaying = false;

        private Card _selectedCard;
        private CardDatabase _database = new CardDatabase();
	}
}