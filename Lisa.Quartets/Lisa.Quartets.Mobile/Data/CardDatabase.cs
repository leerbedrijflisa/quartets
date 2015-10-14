using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite.Net;
using SQLiteNetExtensions.Extensions;
using Xamarin.Forms;

namespace Lisa.Quartets.Mobile
{
	public class CardDatabase
	{
		SQLiteConnection database;

		public CardDatabase()
		{
			database = DependencyService.Get<ISQLite>().GetConnection();
			database.CreateTable<Card>();
		}

		public void RemoveCards()
		{
			database.DeleteAll<Card>();
		}

		public List<Card> GetCards()
		{
			return database.GetAllWithChildren<Card>();
			//return (from i in database.Table<Die>() select i).ToList();
		}

		public int SaveCard(Card card)
		{
			if(card.Id != 0)
			{
				database.InsertOrReplaceWithChildren(card);
				return card.Id;
			}
			else
			{
				return database.Insert(card);
			}
		}

		public int DeleteCard(int id)
		{
			return database.Delete<Card>(id);
		}

		public void InsertCard(Card card)
		{
			database.InsertWithChildren(card);
		}

		public Card GetCard(int cardId)
		{
			return database.GetWithChildren<Card>(cardId);
		}

		public void createDefaultCards()			
		{
			for (int i = 0; i < 16; i++) {
				var card = new Card ();
				card.Name = "card" + i.ToString();
				card.Category = "test";
				card.FileName = "card" + i.ToString() + ".jpg";
				card.InHand = 0;

				InsertCard (card);
			}
		}
	}
}