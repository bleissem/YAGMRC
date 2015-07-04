using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAGMRC.Core.Model;
using YAGMRC.Core.ViewModels;

namespace YAGMRC.Core
{
    public interface IStorage
    {
        StorageType Type { get; }
        CreateGameViewModel.CreateGameResult Upload(Game game, FileInfo dbFile, FileInfo savedGame);
        void Accept(SQLite.Net.SQLiteConnection db);
    }
}
