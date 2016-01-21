using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Lisa.Quartets.Mobile
{
	public partial class LockView : ContentPage
	{
		public LockView()
		{
			InitializeComponent();

			// REVIEW: Should we hide the navigation bar in other views as well?
			NavigationPage.SetHasNavigationBar(this, false);
            _cards = _database.RetrieveCardsWhereInHandIs(1);

            SetImages();

		}

		public void BackClicked(object sender, EventArgs args)
		{
			Navigation.PopAsync();
		}

        private void SetImages()
        {
            CardLayout cardGrid = new CardLayout();
            int lastCategory = 0;
            int translateY = 0;
            AbsoluteLayout stack = new AbsoluteLayout();

            foreach (Card card in _cards)
            {
                CardImage image = new CardImage();
                image.Source = card.FileName;
                image.CardId = card.Id;
                image.Scale = 0.5;

                if (card.IsInHand == 0)
                {
                    image.IsVisible = false;
                }

                if (card.Category > lastCategory)
                {
                    translateY = 0;
                    image.TranslationY = translateY;

                    if (stack.Children.Count > 0)
                    {
                        cardGrid.Children.Add(stack);
                    }

                    stack = MakeNewStack(image);
                }
                else
                {
                    if (image.IsVisible)
                    {
                        translateY += 30;
                    }
                    image.TranslationY = translateY;
                    stack.Children.Add(image);
                }

                lastCategory = card.Category;
            }

            scrollView.Content = cardGrid;
        }

        private AbsoluteLayout MakeNewStack(CardImage firstChild)
        {
            AbsoluteLayout stack = new AbsoluteLayout();
            stack.Children.Add(firstChild);
            return stack;
        }

        private CardDatabase _database = new CardDatabase();
        private List<Card> _cards = new List<Card>();
	}
}