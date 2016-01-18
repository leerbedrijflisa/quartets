using System;
using System.Collections.Generic;
using Xamarin.Forms;
using System.Threading.Tasks;
using System.Threading;

namespace Lisa.Quartets.Mobile
{
	// TODO: Check all the code for adherence to Lisa's code conventions.
	public partial class AskCardView : ContentPage
	{
		
		public AskCardView()
		{
			InitializeComponent();
			_cards = _database.RetrieveCardsInHand(0);
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

		// TODO: Add URL to the source of this code.
		// TODO: Turn Shuffle into an extension method.
		public IList<T> Shuffle<T>(IList<T> list) {
			int n = list.Count;
			Random rnd = new Random();

			// REVIEW: Why is this a while-loop instead of a for-loop?
			while (n > 1) {
				// REVIEW: What's the purpose of % n? Isn't it superfluous?
				int k = (rnd.Next(0, n) % n);
				n--;
				T value = list[k];
				list[k] = list[n];
				list[n] = value;
			}
			return list;
		}

		private void OnCardClick(object sender, EventArgs args)
		{
			// REVIEW: Is it better to do the final scaling and stop the timer here instead of in the timer function? You don't need the _stop field that way.
			_stop = true;
		}

		// TODO: Change the name of this method to something with a verb, like SetTimer or StartTimer.
		public void Timer(){
			Device.StartTimer (new TimeSpan (0, 0, 0,3,0), () => {
				if(_stop == true)
				{
					// TODO: Disable timer.
					cardimage.ScaleTo(1.6);
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

		// REVIEW: Shouldn't FadeCard return a Task, given that the method is async?
		public async void FadeCard(int id){			
			await cardimage.FadeTo(0,500);
			cardimage.Source = _cards[id].FileName;
			await cardimage.FadeTo(1,500);
		}

		private CardDatabase _database = new CardDatabase();
		private bool _stop;
		private List<Card> _cards = new List<Card>();
		private int _id = 1;
	}

}