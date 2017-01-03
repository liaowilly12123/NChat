using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using SQLite;
using InstallDemo.Droid;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

[assembly: Xamarin.Forms.Dependency(typeof(DatabaseConnection_Android))]
namespace InstallDemo.Droid
{
    public class DatabaseConnection_Android : IDatabaseConnection
    {
        public DatabaseConnection_Android() { }
        public SQLiteConnection DbConnection()
        {
            var dbName = "GroupDataDb.db3";
            var path = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), dbName);
            return new SQLiteConnection(path);
        }
    }
}