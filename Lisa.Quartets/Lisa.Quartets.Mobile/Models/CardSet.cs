using SQLite.Net.Attributes;

namespace Lisa.Quartets.Mobile
{
	public class CardSet
	{		
		[PrimaryKey, AutoIncrement]
		public int Id { get; set; }
		public string Name { get; set; }
		public string FileName { get; set; }
	}
}

