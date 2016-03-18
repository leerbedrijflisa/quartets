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
			_database.InsertOrReplaceDelay();
            MainPage = new NavigationPage(new HandEditorView(typeof(StartView)));
        }

        private void EnsureCardsExist()
        {
            List<Card> cards = _database.RetrieveCards();
            if (cards.Count == 0)
            {
                _database.CreateDefaultCards();
            }

            _database.ResetCards();
        }

        CardDatabase _database = new CardDatabase();
    }
}