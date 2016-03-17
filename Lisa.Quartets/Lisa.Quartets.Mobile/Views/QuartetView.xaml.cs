using System;
using System.Collections.Generic;
using Xamarin.Forms;
using System.Threading;
using System.Threading.Tasks;

namespace Lisa.Quartets.Mobile
{
	public partial class QuartetView : ContentPage
	{
		public QuartetView (int category)
		{
			InitializeComponent();

			SetImages(category);
			Animation();
			PlaySound();           
		}

		private double width;
		private double height;

		protected override void OnSizeAllocated (double width, double height){
			base.OnSizeAllocated (width, height);
			if (width != this.width || height != this.height) {
				this.width = width;
				this.height = height;
				if (width > height) {
					quartetCards.Orientation = StackOrientation.Horizontal;
				} else {
					quartetCards.Orientation = StackOrientation.Vertical;
				}
			}
		}

		private void SetImages(int category)
		{
			List<Card> quartet =  _database.RetrieveQuartet(category);

				card1.Source = quartet [0].FileName;
				card2.Source = quartet [1].FileName;
				card3.Source = quartet [2].FileName;
				card4.Source = quartet [3].FileName;

		}

		private void PlaySound() 
		{
			DependencyService.Get<IAudio>().PlayFile("clapping");
		}

		public void Animation()
		{
			CardsAnimation ();
			SlingersAnimation();
		}

		public void AdvanceToNextPage()
		{
			List<Card> cards = _database.RetrieveAskableCards();
			if (cards.Count == 0)
			{
				Navigation.InsertPageBefore(new EmptyHandView(), this);
			}
			else
			{
				Navigation.InsertPageBefore(new RequestView(), this);
			}

			Navigation.PopAsync();
		}

		public async void SlingersAnimation()
		{
			for (int i = 0; i <= 3; i++)
			{
				decoration.Rotation = 10;
				decoration2.Rotation = -10;
				await Task.Delay(500);
				decoration.Rotation = 0;
				decoration2.Rotation = 0;
				await Task.Delay(500);
				decoration.Rotation = -10;
				decoration2.Rotation = 10;
				await Task.Delay(500);
				decoration.Rotation = 0;
				decoration2.Rotation = 0;
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

		public async void CardsAnimation()
		{
			int x = 0;
			for (int i = 0; i < 90; i++)
			{
				card1.Rotation = card1.Rotation + 16;
				card1.Scale = card1.Scale + 0.01;
				x++;
				await Task.Delay (1);
				if (x == 30) {
					Card2Animation ();
				}
			}
		}

		public async void Card2Animation()
		{
			int x = 0;
			for (int i = 0; i < 90; i++)
			{
				card2.Rotation = card2.Rotation + 16;
				card2.Scale = card2.Scale + 0.01;
				x++;
				await Task.Delay (1);
				if (x == 30) {
					Card3Animation ();
				}
			}
		}
		public async void Card3Animation()
		{
			int x = 0;
			for (int i = 0; i < 90; i++)
			{
				card3.Rotation = card3.Rotation + 16;
				card3.Scale = card3.Scale + 0.01;
				x++;
				await Task.Delay (1);
				if (x == 30) {
					Card4Animation ();
				}
			}
		}
		public async void Card4Animation()
		{
			int x = 0;
			for (int i = 0; i < 90; i++)
			{
				card4.Rotation = card4.Rotation + 16;
				card4.Scale = card4.Scale + 0.01;
				x++;
				await Task.Delay (1);
			}
		}

		private CardDatabase _database = new CardDatabase();
	}
}