using System;
using System.Diagnostics;
using System.IO;

namespace YAGMRC.Create.GoogleStorage
{
    public class CreateGameAtGoogle
    {
        #region constructor

        public CreateGameAtGoogle()
        {
        }

        #endregion constructor

        public YAGMRC.Create.GoogleStorage.GoogleStorage.GoogleStorageResult Execute(string user, YAGMRC.Create.Game.Model.Game game, FileInfo dbFile, FileInfo savedGame)
        {
            try
            {
                Trace.TraceInformation("Uploading to google");

                GoogleStorage storage = new GoogleStorage(user);

                var rootFolder = storage.GetRootFolder();

                Google.Apis.Drive.v2.Data.File gameFolder = storage.AddFolder(game.ID.ToString(), rootFolder.Id);

                Google.Apis.Drive.v2.Data.File dbFileAtGoogle = storage.InsertFile(dbFile, gameFolder);

                string dbFileAtGoogleID = storage.ShareFileOrFolder(dbFileAtGoogle);

                Google.Apis.Drive.v2.Data.File savedGameFileAtGoogle = storage.InsertFile(savedGame, gameFolder);

                string savedGameFileAtGoogleID = storage.ShareFileOrFolder(savedGameFileAtGoogle);

                return new YAGMRC.Create.GoogleStorage.GoogleStorage.GoogleStorageResult() { DatabaseFileID = dbFileAtGoogleID, GameFileID = savedGameFileAtGoogleID };
            }
            catch (Exception e)
            {
                throw new GoogleDriveException("An error occurred: " + Environment.NewLine + e.Message);
            }
        }
    }
}