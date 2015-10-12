using System;
using SQLite;

namespace Lisa.Quartets.Mobile
{
	public class Card
	{
		public Card ()
		{
		}

		[PrimaryKey, AutoIncrement]
		public int ID { get; set; }

		public string FileName { get; set; }
	}
}

