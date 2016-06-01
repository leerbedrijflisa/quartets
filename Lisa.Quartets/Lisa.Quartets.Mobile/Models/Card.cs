using SQLite.Net.Attributes;

namespace Lisa.Quartets.Mobile
{
	public class Card
	{
		[PrimaryKey, AutoIncrement]
		public int Id { get; set; }
        public int Number { get; set; }
		public string Name { get; set; }
		public int Category { get; set; }
		public string FileName { get; set; }
		public string SoundFile { get; set; }
		public int IsInHand { get; set;}
        public int IsQuartet{ get; set;}
	}
}