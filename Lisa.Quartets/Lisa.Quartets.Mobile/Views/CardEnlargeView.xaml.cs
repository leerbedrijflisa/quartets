﻿using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace Lisa.Quartets.Mobile
{
	public partial class CardEnlargeView : ContentPage
	{
        public CardEnlargeView(CardImageHolder cardImageHolder)
        {
            InitializeComponent();
            _cardImageHolder = cardImageHolder;
            SetPreviousSelectedCards();
            SetImages();
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
                image.ScaleTo(0.8, 100);

                #if __IOS__
                    image.FadeTo(0.5, 100);   
                #else
                    _opacity[image.CardId].FadeTo(1, 100);
                #endif

			}
			else
			{
                Select(image);
                image.ScaleTo(1, 100);

                #if __IOS__
                    image.FadeTo(1, 100);   
                #else
                    _opacity[image.CardId].FadeTo(0, 100);
                #endif

			}

            saveButton.IsEnabled = true;
		}

        private void SetImages()
        {
            CardLayout cardGrid = new CardLayout();
            int column = 0;
            int row = 0;

            var tapGestureRecognizer = new TapGestureRecognizer();
            tapGestureRecognizer.Tapped += OnImageClick;
            FileImageSource opacitySource = new FileImageSource { File = "opacity.png" };

            foreach (var image in _cardImageHolder.CardImages)
            {
                image.Scale = 0.8;
                image.GestureRecognizers.Add(tapGestureRecognizer);

                #if __IOS__
                    if (IsSelected(image))
                    {
                        image.Opacity = 1;
                        image.Scale = 1;
                    }
                    else
                    {
                        image.Opacity = 0.5;
                        image.Scale = 0.8;
                    }

                    cardGrid.Children.Add(image);
                #else
                    Image opacity = new Image { Source = opacitySource, Scale = 0.8 };

                    if (IsSelected(image))
                    {
                        opacity.Opacity = 0;
                        image.Scale = 1;
                    }

                    _opacity.Add(image.CardId, opacity);

                    var parent = new AbsoluteLayout{ Children = { image, _opacity[image.CardId] } };

                    cardGrid.Children.Add(parent);
                #endif

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

            scrollView.Content = cardGrid;
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

        private void SetPreviousSelectedCards()
        {
            foreach (Card card in _database.RetrieveCardsInHand(1))
            {
                _selectedImages.Add(card.Id);
            }
        }

		private CardDatabase _database = new CardDatabase();
        private List<int> _selectedImages = new List<int>();
		private Dictionary<int, Image> _opacity = new Dictionary<int, Image>();
        private CardImageHolder _cardImageHolder;
	}
}