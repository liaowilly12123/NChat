using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using System.IO;
using InstallDemo.iOS;

[assembly: Xamarin.Forms.Dependency(typeof(DatabaseConnection_iOS))]
namespace InstallDemo.iOS
{
    public class DatabaseConnection_iOS : IDatabaseConnection
    {
        public SQLiteConnection DbConnection()
        {
            var dbName = "GroupDataDb.db3";
            string personalfolder = System.Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string libraryfolder = Path.Combine(personalfolder, "..", "Library");
            var path = Path.Combine(libraryfolder, dbName);
            return new SQLiteConnection(path);
        }
    }
}
