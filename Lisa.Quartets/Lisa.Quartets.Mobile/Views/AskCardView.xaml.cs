using System;
using System.Collections.Generic;
using Xamarin.Forms;
using System.Threading.Tasks;
using System.Threading;

namespace Lisa.Quartets.Mobile
{
	public partial class AskCardView : ContentPage
	{
		
		public AskCardView()
		{
			InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            _cards = _database.RetrieveCardsInHand(0);
            InitializeFirstImage();
			Timer();
		}

        private void InitializeFirstImage()
		{
			var tapGestureRecognizer = new TapGestureRecognizer();
			cardImage.GestureRecognizers.Add(tapGestureRecognizer);
			tapGestureRecognizer.Tapped += OnCardClick;

            SetImage(0);
		}

		private void OnCardClick(object sender, EventArgs args)
		{
			_stop = true;
		}

        private void Timer(){
			Device.StartTimer (new TimeSpan (0, 0, 0,2,0), () => {
				if(_stop == true)
				{
                    AskSelectedCard(_cards[_id -1]);
					return false;	
				}

				FadeCard(_id);
				_id++;

				if (_id >= _cards.Count)
				{
					_id = 0;
				}

				return true;
			});
		}

        private void AskSelectedCard(Card card)
        {
            Navigation.PushAsync(new YesNoView(card));
        }

        private async void FadeCard(int id){			
			await cardImage.FadeTo(0,500);
            SetImage(id);
			await cardImage.FadeTo(1,500);
		}

        private void SetImage(int id)
        {
            cardImage.Source = _cards[id].FileName;
            cardImage.CardId = _cards[id].Id;
        }

		private CardDatabase _database = new CardDatabase();
        private List<Card> _cards = new List<Card>();
        private int _id = 1;
        private bool _stop;
	}

}