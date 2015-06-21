using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAGMRC.Core.DB;
using YAGMRC.Core.Model;
using YAGMRC.Core.OS;

namespace YAGMRC.Core.ViewModels
{
    public class CreateGameViewModel : GalaSoft.MvvmLight.ViewModelBase
    {
        #region constructor

        public CreateGameViewModel(IOSSetting settings)
        {
            m_Settings = settings;
        }

        #endregion

        #region nested Classes

        public class CreateGameParam
        {
            public IStorageFactory CreateStorage { get; set; }
            public Game Game { get; set; }
            public FileInfo SavedGame { get; set; }
        }

        public class CreateGameResult
        {
            public CreateGameResult()
            {

            }
        }

        #endregion

        private IOSSetting m_Settings;


        private FileInfo MasterTableFile
        {
            get
            {
                return new FileInfo(Path.Combine(m_Settings.BasePath.FullName, "master.db3"));
            }
        }

        private FileInfo CreateGameDBFile(Game game, DirectoryInfo dir)
        {
            throw new NotImplementedException();
        }

        private void CreateOrEditMasterTable(Game game, StorageType storageType, DirectoryInfo dir)
        {

            var db = CreateSQLLiteConnection.Create(MasterTableFile);

            db.CreateTable<MasterTable>();

            MasterTable master = new MasterTable();
            master.Guid = game.ID;
            master.LocationType = storageType;
        }

        private FileInfo CreateDBFile(Game game, StorageType storageType)
        {
           if (!this.m_Settings.BasePath.Exists)
           {
               Directory.CreateDirectory(this.m_Settings.BasePath.FullName);
           }

           this.CreateOrEditMasterTable(game, storageType, this.m_Settings.BasePath);
           
           DirectoryInfo gameDir =  Directory.CreateDirectory(Path.Combine(this.m_Settings.BasePath.FullName, game.ID.ToString()));

           return this.CreateGameDBFile(game, gameDir);

        }

        public CreateGameResult CreateGame(CreateGameParam param)
        {
            if (!param.SavedGame.Exists)
            {
                throw new YAGMRCException(param.SavedGame + Environment.NewLine + "does not exists");
            }
            IStorage storage = param.CreateStorage.Create();
            FileInfo dbfileToUpload = CreateDBFile(param.Game, storage.Type);
            return storage.Upload(param.Game, dbfileToUpload, param.SavedGame);
        }

    }
}
