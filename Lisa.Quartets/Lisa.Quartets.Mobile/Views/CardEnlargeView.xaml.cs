using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace Lisa.Quartets.Mobile
{
	public partial class CardEnlargeView : ContentPage
	{
		public CardEnlargeView()
        {
            InitializeComponent();
            EnsureCardsExist();
            SetImages();
        }

		private void EnsureCardsExist()
		{
			var cards = _database.RetrieveCards();
			if (cards.Count() == 0)
			{
				_database.CreateDefaultCards();
			}
		}

        private void SaveSelectedCards(object sender, EventArgs e)
        {
            _database.UpdateSelectedCards(_selectedImages);
        }

		private void OnImageClick(object sender, EventArgs args)
		{	
            var image = (CardImage) sender;

			if (IsSelected(image))
			{
				Deselect(image);
				image.Opacity = 0.5;
				image.Scale = 0.8;
			}
			else
			{
				Select(image);
				image.Opacity = 1;
				image.Scale = 1;
			}
		}

        private bool IsSelected(CardImage image)
		{
            return _selectedImages.Contains(image.CardId);
		}

        private void Select(CardImage image)
		{
            _selectedImages.Add(image.CardId);
		}

		private void Deselect(CardImage image)
		{
            _selectedImages.Remove(image.CardId);
		}

		private void SetImages()
        {
            var cards = _database.RetrieveCards();
            int column = 0;
            int row = 0;

            foreach (var card in cards)
            {
                CardImage image = LoadImage(card);
                cardGrid.Children.Add(image, column, row);

                if (column < 3)
                {
                    column++;
                }
                else
                {
                    column = 0;
                    row++;
                }
            }
        }	

        private CardImage LoadImage(Card card)
        {
            var image = new CardImage();

            var tapGestureRecognizer = new TapGestureRecognizer();
            tapGestureRecognizer.Tapped += OnImageClick;
            image.GestureRecognizers.Add(tapGestureRecognizer);

            image.Source = card.FileName;
            image.Opacity = 0.5;
            image.Scale = 0.8;
            image.CardId = card.Id;

            return image;
        }

		private CardDatabase _database = new CardDatabase();
		private List<int> _selectedImages = new List<int>();
	}
}