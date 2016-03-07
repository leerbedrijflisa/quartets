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

        private void SetImages(int category)
        {
            CardLayout cardGrid = new CardLayout();
            cardGrid.HorizontalOptions = LayoutOptions.CenterAndExpand;
            cardGrid.VerticalOptions = LayoutOptions.CenterAndExpand;
            List<Card> quartet =  _database.RetrieveQuartet(category);

            foreach (var card in quartet)
            {
                CardImage image = new CardImage();
                image.Source = card.FileName;
                image.CardId = card.Id;

                image.Scale = 0.8;

                cardGrid.Children.Add(image);
            }

            layout.Children.Add(cardGrid);
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
            List<Card> cards = _database.RetrieveAskableCards();
            Navigation.RemovePage(this);
            if (cards.Count == 0)
            {
                await Navigation.PushAsync(new EmptyHandView());

            }
            else
            {
                await Navigation.PushAsync(new RequestView());
            }

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

        private CardDatabase _database = new CardDatabase();
	}
}