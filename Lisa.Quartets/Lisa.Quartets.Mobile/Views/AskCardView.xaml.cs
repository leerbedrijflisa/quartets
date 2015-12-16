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
			_cards = _database.RetrieveCardsInHand(0);
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
		}

		public void Timer(){
			Device.StartTimer (new TimeSpan (0, 0, 0,2,0), () => {
				if(_stop == true)
				{
					System.Diagnostics.Debug.WriteLine("false");
					cardimage.ScaleTo(1.6);
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