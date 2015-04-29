using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAGMRC.Core.Common;

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

        Core.ViewModel.CreateGameViewModel.CreateGameResult IStorage.Upload(Core.Model.Game game, FileInfo dbFile, FileInfo savedGame)
        {
            CreateGameAtGoogle cgg = new CreateGameAtGoogle();
            GoogleDrive.GoogleStorageResult googleResult = cgg.Execute(m_User, game, dbFile, savedGame);
            //TODO:
            return new Core.ViewModel.CreateGameViewModel.CreateGameResult();
        }

    }
}
