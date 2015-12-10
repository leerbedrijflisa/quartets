using SQLite.Net.Attributes;

namespace Lisa.Quartets.Mobile
{
	public class Card
	{
		[PrimaryKey, AutoIncrement]
		public int Id { get; set; }
		public string Name { get; set; }
		public string Category { get; set; }
		public string FileName { get; set; }
		public int IsInHand { get; set;}
	}
}