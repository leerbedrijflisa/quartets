using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using System.Text;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Lisa.Quartets.Droid;
using Lisa.Quartets.Mobile;
using Xamarin.Forms;

[assembly: Dependency(typeof(SQLite_Android))]
namespace Lisa.Quartets.Droid
{
	public class SQLite_Android : ISQLite
	{
		public SQLite_Android() { }
		public SQLite.Net.SQLiteConnection GetConnection()
		{
			var sqliteFilename = "CardDatabase.db3";
			string documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal); // Documents folder
			var path = Path.Combine(documentsPath, sqliteFilename);
			// Create the connection
			var plat = new SQLite.Net.Platform.XamarinAndroid.SQLitePlatformAndroid();
			var conn = new SQLite.Net.SQLiteConnection(plat, path);
			// Return the database connection 
			return conn;
		}
	}
}