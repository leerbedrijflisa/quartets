using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace Lisa.Quartets.Mobile
{
    public class App : Application
    {
        public App()
        {
            EnsureCardsExist();
			MainPage = new NavigationPage(new StartView());
        }

        private void EnsureCardsExist()
        {
            List<Card> cards = _database.RetrieveCards();
            if (cards.Count == 0)
            {
                _database.CreateDefaultCards();
            }
        }

        CardDatabase _database = new CardDatabase();
    }
}