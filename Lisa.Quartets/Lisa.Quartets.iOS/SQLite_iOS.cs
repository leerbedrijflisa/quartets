using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using System.IO;
using Xamarin.Forms;
using Lisa.Quartets.Mobile;

[assembly: Dependency(typeof(Lisa.Quartets.iOS.SQLite_iOS))]
namespace Lisa.Quartets.iOS
{
    public class SQLite_iOS : ISQLite
    {
        public SQLite_iOS() { }
        public SQLite.Net.SQLiteConnection GetConnection()
        {
			var sqliteFilename = "CardDatabase.db3";
            string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal); // Documents folder
            string libraryPath = Path.Combine(documentsPath, "..", "Library"); // Library folder
            var path = Path.Combine(libraryPath, sqliteFilename);
            // Create the connection
            var plat = new SQLite.Net.Platform.XamarinIOS.SQLitePlatformIOS();
            var conn = new SQLite.Net.SQLiteConnection(plat, path);
            // Return the database connection
            return conn;
        }
    }
}