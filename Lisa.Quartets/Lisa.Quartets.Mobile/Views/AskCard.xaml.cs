using System;
using System.Collections.Generic;
using Xamarin.Forms;
using System.Threading.Tasks;
using System.Threading;

namespace Lisa.Quartets.Mobile
{
	public partial class AskCard : ContentPage
	{
		private bool stop;
	
		public AskCard()
		{
			int id = 0;

			var tapGestureRecognizer = new TapGestureRecognizer();
			cardimage.GestureRecognizers.Add(tapGestureRecognizer);


			tapGestureRecognizer.Tapped += (s, e) =>
			{
				System.Diagnostics.Debug.WriteLine("Clicked");
				stop = true;
			};

			Device.StartTimer (new TimeSpan (0, 0, 0,0,300), () => {

				if(stop == true)
				{
					System.Diagnostics.Debug.WriteLine("false");
					cardimage.Scale = 1.6;
					return false;	
				}

				var card = new Image { Aspect = Aspect.AspectFit };
				card.Source = ImageSource.FromFile("card" + id + ".jpg");
				card.IsVisible = true;  
				cardimage.Source = card.Source;
				id++;
				return true;
			});


		}
	}
}
