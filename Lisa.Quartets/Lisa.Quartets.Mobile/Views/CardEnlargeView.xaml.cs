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

        private void SaveSelectedCards(object sender, EventArgs args)
        {
            _database.UpdateSelectedCards(_selectedImages);
            Navigation.PopToRootAsync();
        }

		private void OnImageClick(object sender, EventArgs args)
		{	
            var image = (CardImage) sender;

			if (IsSelected(image))
			{
				Deselect(image);
				image.FadeTo(0.5, 100);
				image.ScaleTo(0.8, 100);
				_shadows[image.CardId].ScaleTo(0.8, 100);
				_shadows[image.CardId].FadeTo(0, 100);
			}
			else
			{
				Select(image);
				image.FadeTo(1, 100);
				image.ScaleTo(1, 100);
				_shadows[image.CardId].ScaleTo(1.05, 100);
				_shadows[image.CardId].FadeTo(1, 100);

			}

            saveButton.IsEnabled = true;
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
				_shadows.Add(card.Id, new Image { Source = ImageSource.FromFile("shadow.png"), Opacity=0, Scale=0.8 });
				CardImage image = LoadImage(card);
				var parent = new AbsoluteLayout{ Children = { _shadows[card.Id], image } };
				cardGrid.Children.Add(parent, column, row);


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
            image.CardId = card.Id;

            //If card is selected
            if (card.IsInHand == 1)
            {
                _selectedImages.Add(card.Id);
                _shadows[card.Id].Scale = 1.05;
                _shadows[card.Id].Opacity = 1;
            }
            else
            {
                image.Opacity = 0.5;
                image.Scale = 0.8;
            }

            return image;
        }

		private CardDatabase _database = new CardDatabase();
		private List<int> _selectedImages = new List<int>();
		private Dictionary<int, Image> _shadows = new Dictionary<int, Image>();
	}
}