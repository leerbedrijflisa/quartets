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
			_cards = _database.RetrieveCardsWhereInHandIs(0);
			Shuffle(_cards);
			InitializeFirstImage();
			Timer();
		}

		public void InitializeFirstImage()
		{
			var tapGestureRecognizer = new TapGestureRecognizer();
			cardimage.GestureRecognizers.Add(tapGestureRecognizer);
			tapGestureRecognizer.Tapped += OnCardClick;

			cardimage.Source = _cards[0].FileName;
		}

		private void OnCardClick(object sender, EventArgs args)
		{
			_stop = true;
            ContinueToNextView(_cards[_id]);
		}

		public void Timer(){
			Device.StartTimer (new TimeSpan (0, 0, 0,3,0), () => {
				if(_stop == true)
				{
					return false;	
				}
				_id++;
				if (_id >= _cards.Count)
				{
					_id = 0;
				}

				FadeCard(_id);

				return true;
			});
		}

		public async void FadeCard(int id){			
			await cardimage.FadeTo(0,500);
			cardimage.Source = _cards[id].FileName;
			await cardimage.FadeTo(1,500);
		}

        private async void ContinueToNextView(Card card)
        {
            await cardimage.ScaleTo(1.6);
            await Navigation.PushAsync(new YesNoView(card), false);
            Navigation.RemovePage(this);
        }

        public IList<T> Shuffle<T>(IList<T> list) {
            int n = list.Count;
            Random random = new Random();
            while (n > 1) {
                int k = (random.Next(0, n) % n);
                n--;
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
            return list;
        }

		private CardDatabase _database = new CardDatabase();
		private bool _stop;
		private List<Card> _cards = new List<Card>();
		private int _id = 0;
	}
}