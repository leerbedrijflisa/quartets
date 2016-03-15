using SQLite.Net.Attributes;

namespace Lisa.Quartets.Mobile
{
	public class Settings
	{
		[PrimaryKey, AutoIncrement]
		public int Id { get; set; }
		public int Delay { get; set; }
	}
}