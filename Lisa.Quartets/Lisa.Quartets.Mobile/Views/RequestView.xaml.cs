using System;
using System.Collections.Generic;
using Xamarin.Forms;
using System.Threading.Tasks;
using System.Threading;

namespace Lisa.Quartets.Mobile
{
	public partial class RequestView : ContentPage
	{		
		public RequestView()
		{
			InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);

			_cards = _database.RetrieveRequestableCards();
			Shuffle(_cards);
			InitializeFirstImage();
			Timer();   
            _startTime = DateTime.UtcNow;
		}

		public void InitializeFirstImage()
		{
			cardimage.Source = _cards[0].FileName;
		}

		private void OnCardSlider(object sender, EventArgs args)
		{		
            if (!_stopped)
            {
                SaveRequestStats();
                _stopped = true;

                PlaySound();

                ContinueToNextView(_cards[_id]);
            }           
		}

		private void PlaySound() 
		{
			DependencyService.Get<IAudio>().PlayFile(_cards[_id].SoundFile);
		}

		public void Timer(){
            Device.StartTimer(new TimeSpan (0, 0, 0,3,0), () => {
				if(_stopped == true)
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

        private void SaveRequestStats(){
            RequestCardStats stats = new RequestCardStats();
            stats.Timestamp = DateTime.UtcNow;
            stats.TimeBeforeTap = (DateTime.UtcNow - _startTime).TotalMilliseconds;
            stats.CardIndex = _id;
            stats.DelaySetting = 300;

            _database.SaveCardRequestStats(stats);
        }

        private async void ContinueToNextView(Card card)
        {
            await cardimage.ScaleTo(1.6);
			await Task.Delay(4000);
            Navigation.InsertPageBefore(new ConfirmationView(card) , this);
            await Navigation.PopAsync();
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
        private List<Card> _cards = new List<Card>();
        private DateTime _startTime;
        private bool _stopped;
        private int _id = 0;
	}
}