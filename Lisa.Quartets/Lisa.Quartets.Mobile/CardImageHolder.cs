using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Lisa.Quartets.Mobile
{
    public class CardImageHolder
    {
        public List<Card> Cards { get; set;}
        public List<CardImage> CardImages { get; set; }

        public CardImageHolder()
        {
            CardImages = new List<CardImage>();
            EnsureCardsExist();
            foreach (Card card in Cards)
            {
                CardImage image = new CardImage();
                image.Source = card.FileName;
                image.CardId = card.Id;

                CardImages.Add(image);
            }
        }

        private void EnsureCardsExist()
        {
            Cards = _database.RetrieveCards();
            if (Cards.Count == 0)
            {
                _database.CreateDefaultCards();
                Cards = _database.RetrieveCards();
            }
        }

        private CardDatabase _database = new CardDatabase();

    }
}