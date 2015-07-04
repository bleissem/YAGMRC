using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAGMRC.Core;
using YAGMRC.Core.DatabaseModel;
using YAGMRC.Core.ViewModels;

namespace YAGMRC.GoogleStorage
{
    public class GoogleDriveStorage : IStorage
    {
        #region constructors

        public GoogleDriveStorage(string user)
        {
            m_User = user;
        }

        #endregion

        private string m_User;
        private SQLite.Net.SQLiteConnection m_DB;

        CreateGameViewModel.CreateGameResult IStorage.Upload(Core.Model.Game game, FileInfo dbFile, FileInfo savedGame)
        {
            CreateGameAtGoogle cgg = new CreateGameAtGoogle();
            GoogleDrive.GoogleStorageResult googleResult = cgg.Execute(m_User, game, dbFile, savedGame);
            //TODO:
            m_DB.CreateTable<MasterTableGoogle>();

            MasterTableGoogle googleMasterTable = new MasterTableGoogle();
            googleMasterTable.GameID = game.ID;
            googleMasterTable.DBFileID = googleResult.DatabaseFileID;
            googleMasterTable.GameFileID = googleResult.GameFileID;
            m_DB.Insert(googleMasterTable);

            return new CreateGameViewModel.CreateGameResult();
        }


        public Core.Model.StorageType Type { get { return Core.Model.StorageType.GoogleDrive; } }


        public void Accept(SQLite.Net.SQLiteConnection db)
        {
            m_DB = db;
        }
    }
}
