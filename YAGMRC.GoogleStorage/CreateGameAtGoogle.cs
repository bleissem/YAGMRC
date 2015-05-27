using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAGMRC.Core.Model;

namespace YAGMRC.GoogleStorage
{
    public class CreateGameAtGoogle
    {
        #region constructor

        public CreateGameAtGoogle()
        {
        }

        #endregion constructor

        public YAGMRC.GoogleStorage.GoogleDrive.GoogleStorageResult Execute(string user, Game game, FileInfo dbFile, FileInfo savedGame)
        {
            try
            {
                Trace.TraceInformation("Uploading to google");

                GoogleDrive storage = new GoogleDrive(user);

                var rootFolder = storage.GetRootFolder();

                Google.Apis.Drive.v2.Data.File gameFolder = storage.AddFolder(game.ID.ToString(), rootFolder.Id);

                Google.Apis.Drive.v2.Data.File dbFileAtGoogle = storage.InsertFile(dbFile, gameFolder);

                string dbFileAtGoogleID = storage.ShareFileOrFolder(dbFileAtGoogle);

                Google.Apis.Drive.v2.Data.File savedGameFileAtGoogle = storage.InsertFile(savedGame, gameFolder);

                string savedGameFileAtGoogleID = storage.ShareFileOrFolder(savedGameFileAtGoogle);

                return new YAGMRC.GoogleStorage.GoogleDrive.GoogleStorageResult() { DatabaseFileID = dbFileAtGoogleID, GameFileID = savedGameFileAtGoogleID };
            }
            catch (Exception e)
            {
                throw new GoogleDriveException("An error occurred: " + Environment.NewLine + e.Message);
            }
        }
    }
}
