using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite.Net.Attributes;
using SQLiteNetExtensions.Attributes;

namespace Lisa.Quartets.Mobile
{
	public class Card
	{
		[PrimaryKey, AutoIncrement]
		public int Id { get; set; }
		public string Name { get; set; }
		public string Category { get; set; }
		public string FileName { get; set; }
		public int InHand { get; set;}
	}
}

