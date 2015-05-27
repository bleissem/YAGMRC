using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAGMRC.Core;
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

        CreateGameViewModel.CreateGameResult IStorage.Upload(Core.Model.Game game, FileInfo dbFile, FileInfo savedGame)
        {
            CreateGameAtGoogle cgg = new CreateGameAtGoogle();
            GoogleDrive.GoogleStorageResult googleResult = cgg.Execute(m_User, game, dbFile, savedGame);
            //TODO:
            return new CreateGameViewModel.CreateGameResult();
        }

    }
}
