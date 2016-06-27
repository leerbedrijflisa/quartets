using System;
using System.Collections.Generic;
using Xamarin.Forms;
using System.Threading.Tasks;

namespace Lisa.Quartets.Mobile
{
    public partial class SelectHandView : ContentPage
    {
        public SelectHandView()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }

        private void OnNumberClick(object sender, EventArgs args)
        {
            Button button = (Button)sender;

            _input += button.Text;

            if (_input.Length == 2)
            {
                _selectedCard = _database.RetrieveFromNumber(_input);

                if (_selectedCard != null && _selectedCard.IsInHand == 0)
                {
                    _cardCount++;
                    ShowCard();
                    SaveSelectedCard();
                    AddToOverview();
                    ToggleButtons(true);
                }

                _input = null;
            }
        }

        private void ShowCard()
        {
            cardImage.Source = _selectedCard.FileName;
        }

        private void SaveSelectedCard()
        {
            _selectedCard.IsInHand = 1;
            _database.CreateOrUpdateCard(_selectedCard);
        }

        private void OnMistakeClick(object sender, EventArgs args)
        {
            _selectedCard.IsInHand = 0;
            _database.CreateOrUpdateCard(_selectedCard);

            cardImage.Source = null;
            selectionOverview.Children.RemoveAt(selectionOverview.Children.Count - 1);


            _images.RemoveAt(_images.Count - 1);

            _cardCount--;
            if (_cardCount <= 0)
            {
                ToggleButtons(false);
            }
        }

        private void OnDoneClick(object sender, EventArgs args)
        {
            Navigation.InsertPageBefore(new IdleView(), this);
            Navigation.PopAsync();
        }

        private void OnShowCardsClicked(object sender, EventArgs args)
        {
            Navigation.PushAsync(new HandOverView());
        }

        private void ToggleButtons(bool isEnabled)
        {
            mistakeButton.IsEnabled = isEnabled;
            doneButton.IsEnabled = isEnabled;
        }

        private async void AddToOverview()
        {
            CardImage cardImage = new CardImage
            {
                Source = _selectedCard.FileName,
                TranslationX = Width
            };

            selectionOverview.Children.Add(cardImage);

            // Create animations for all the images that are already on the screen.
            List<Task> tasks = new List<Task>();
            ​
            for (int i = 0; i < _images.Count; i++)
            {
                var image = _images[i];
                double offset = CalculatePosition(i, _images.Count + 1, 100, Width);
                tasks.Add(image.TranslateTo(offset, 0, 500, Easing.CubicInOut));
            }
            ​
            // Create animation for the new image.
            tasks.Add(cardImage.TranslateTo(CalculatePosition(_images.Count, _images.Count + 1, 100, Width), 0, 500, Easing.CubicOut));
            ​
            // Store the new image in the list of images already on the screen.
            _images.Add(cardImage);
            ​
            // Run the animations.
            await Task.WhenAll(tasks.ToArray());
        }

        private double CalculatePosition(int index, int imageCount, double imageWidth, double containerWidth)
        {
            if (imageCount * imageWidth > containerWidth)
            {
                double itemWidth = (containerWidth - imageWidth) / imageCount;
                return index * itemWidth;
            }
            else
            {
                double center = containerWidth / 2;
                double indexOffset = index - (imageCount - 1) / 2.0;
                return center + indexOffset * imageWidth - imageWidth / 2;
            }

        } 

        private string _input;
        private int _cardCount;
        private Card _selectedCard;
        private CardDatabase _database = new CardDatabase();
        private List<CardImage> _images = new List<CardImage>();
    }
}