using System;
using System.Collections.Generic;
using Xamarin.Forms;
using System.Threading.Tasks;

namespace Lisa.Quartets.Mobile
{
	public partial class StartPage : ContentPage
	{


		public StartPage()
		{
			InitializeComponent ();
			loadimages ();
		}
		 async void loadimages()
		{
			
			var tapGestureRecognizer = new TapGestureRecognizer();
			var stop = false;

			// Als er op de kaart gedrukt word // 
			tapGestureRecognizer.Tapped += (s, e) => {
				stop = true;			
				System.Diagnostics.Debug.WriteLine("Clicked");
				var imageSender = (Image)s;
				imageSender.ScaleTo(2);
			};
	

			cardimage.GestureRecognizers.Add (tapGestureRecognizer);

				for (int i = 1; i <= 44; i++) 
				{
				
						if (stop == false) 
						{				
							await Task.Delay (500);
							var card = new Image { Aspect = Aspect.AspectFit };
							card.Source = ImageSource.FromFile ("card" + i + ".jpg");
							card.IsVisible = true;	
							cardimage.Source = card.Source;
						}
			
			    }
				


		}
	}

} 