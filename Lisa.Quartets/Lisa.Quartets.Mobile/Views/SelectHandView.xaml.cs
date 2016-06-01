using System;
using System.Collections.Generic;
using Xamarin.Forms;

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

                if (_selectedCard != null)
                {
                    ShowCard();
                    SaveSelectedCard();
                    _cardCount++;
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

        private string _input;
        private int _cardCount;
        private Card _selectedCard;
        private CardDatabase _database = new CardDatabase();
    }
}