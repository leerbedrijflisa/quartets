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
			slingersAnimation ();
			slingers2Animation ();
		}

		public async void slingersAnimation()
		{
			for (int i = 1; i <= 3; i++)
			{
				slingers.Rotation = 10;
				await Task.Delay(500);
				slingers.Rotation = 0;
				await Task.Delay(500);
				slingers.Rotation = -10;
				await Task.Delay(500);
				slingers.Rotation = 0;
				await Task.Delay(500);
			}
		}

		public async void slingers2Animation()
		{
			for (int i = 1; i <= 3; i++)
			{
				slingers2.Rotation = -10;
				await Task.Delay(500);
				slingers2.Rotation = 0;
				await Task.Delay(500);
				slingers2.Rotation = 10;
				await Task.Delay(500);
				slingers2.Rotation = 0;
				await Task.Delay(500);
			}
		}
	}
}

