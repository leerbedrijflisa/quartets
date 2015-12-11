using System;
using System.Collections.Generic;

using Xamarin.Forms;
using System.Linq;

namespace Lisa.Quartets.Mobile
{
    public partial class GiveCardView : ContentPage
    {
        public GiveCardView()
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
            _database.GiveCardAway(_selectedImage);
            Navigation.PopToRootAsync();
        }

        private void OnImageClick(object sender, EventArgs args)
        {   
            var image = (CardImage) sender;

            if (_selectedImage > -1)
            {
                DeselectAllImages();
            }

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

            ToggleSaveButton();
        }

        private bool IsSelected(CardImage image)
        {
            return _selectedImage == image.CardId;
        }

        private void Select(CardImage image)
        {
            _selectedImage = image.CardId;
        }

        private void Deselect(CardImage image)
        {
            _selectedImage = -1;
        }

        private void SetImages()
        {
            var cards = _database.RetrieveCardsInHand();
            if (cards.Count < 1)
            {
                
                DisplayErrorMessage("Je hebt geen kaarten in je hand om weg te geven");
            }
                
            int column = 0;
            int row = 0;

            foreach (var card in cards)
            {
                CardImage image = LoadImage(card);  

                AppendImage(cards, image, row, column);

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
            image.Opacity = 0.5;
            image.Scale = 0.8;

            return image;
        }

        private async void DisplayErrorMessage(string message)
        {
            await DisplayAlert("Fout", message, "Oké");
            Navigation.PopToRootAsync();
        }

        private void AppendImage(List<Card> cards, CardImage image, int row, int column)
        {
            if (cards.Count == 1)
            {
                parentLayout.Children.Add(image);
            }
            else
            {
                cardGrid.Children.Add(image, column, row);
            }
        }

        private void DeselectAllImages()
        {
            foreach (CardImage card in cardGrid.Children)
            {
                card.Opacity = 0.5;
                card.Scale = 0.8;
            }
        }

        private void ToggleSaveButton()
        {
            if (_selectedImage > -1)
            {
                saveButton.IsEnabled = true;
            }
            else
            {
                saveButton.IsEnabled = false;
            }
        }

        private CardDatabase _database = new CardDatabase();
        private int _selectedImage = -1;
    }
}