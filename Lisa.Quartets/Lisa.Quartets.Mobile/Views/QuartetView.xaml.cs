using System;
using System.Collections.Generic;
using Xamarin.Forms;
using System.Threading;
using System.Threading.Tasks;

namespace Lisa.Quartets.Mobile
{
	public partial class QuartetView : ContentPage
	{
		public QuartetView ()
		{
			InitializeComponent ();
			Animation();
			PlaySound();
		}
			
		private void PlaySound() 
		{
			DependencyService.Get<IAudio>().PlayFile("clapping");
		}

		public void Animation()
		{
			SlingersAnimation();
		}

		public async void AdvanceToNextPage()
		{
			Navigation.RemovePage(this);
			await Navigation.PushAsync(new AskCardView());
		}

		public async void SlingersAnimation()
		{

			for (int i = 0; i <= 3; i++)
			{
				slingers.Rotation = 10;
				slingers2.Rotation = -10;
				await Task.Delay(500);
				slingers.Rotation = 0;
				slingers2.Rotation = 0;
				await Task.Delay(500);
				slingers.Rotation = -10;
				slingers2.Rotation = 10;
				await Task.Delay(500);
				slingers.Rotation = 0;
				slingers2.Rotation = 0;
				if (i <3)
				{
					await Task.Delay(500);
				}

				if (i == 3)
				{
					AdvanceToNextPage();
				}
					
			}

		}
			
	}
}

