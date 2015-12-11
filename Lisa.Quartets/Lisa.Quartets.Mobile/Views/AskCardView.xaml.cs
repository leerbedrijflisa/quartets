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
			InitializeFirstImage();
			Timer();
		}
		public void InitializeFirstImage()
		{
			cardimage.Source = ImageSource.FromFile("card1.jpg");
			var tapGestureRecognizer = new TapGestureRecognizer();
			cardimage.GestureRecognizers.Add(tapGestureRecognizer);
			tapGestureRecognizer.Tapped += OnCardClick;
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
				if (_id > 43)
				{
					_id = 0;
				}
				return true;
			});
		}
		public async void FadeCard(int id){
			await cardimage.FadeTo(0,500);
			cardimage.Source = ImageSource.FromFile("card" + _id + ".jpg"); 
			await cardimage.FadeTo(1,500);
		}
		private bool _stop;
		private int _id;
	}

}