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

namespace NoteTree.Droid
{
    public class SQLite_Android : ISQLite
    {
        public SQLite_Android ()
        {
        }
 
        #region ISQLite implementation
 
        public SQLite.SQLiteConnection GetConnection ()
        {
            var fileName = "RandomThought.db3";
            var documentsPath = Environment.GetFolderPath (Environment.SpecialFolder.Personal);
            var path = Path.Combine (documentsPath, fileName);
 
            var platform = new SQLite.Net.Platform.XamarinAndroid.SQLitePlatformAndroid ();
            var connection = new SQLite.SQLiteConnection (platform, path);
 
            return connection;
        }
 
        #endregion
    }
}