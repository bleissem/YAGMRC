using SQLite.Net.Platform.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YAGMRC.Core.DB
{
    internal class CreateSQLLiteConnection
    {

        internal static SQLite.Net.SQLiteConnection Create(FileInfo file)
        {
            return new SQLite.Net.SQLiteConnection(new SQLitePlatformWin32() , file.FullName);
        }

    }
}
