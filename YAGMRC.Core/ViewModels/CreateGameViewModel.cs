using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        private FileInfo CreateGameDBFile(Game game, DirectoryInfo dir)
        {
            throw new NotImplementedException();
        }

        private void CreateOrEditMasterTable(Game game, DirectoryInfo dir)
        {

        }

        private FileInfo CreateDBFile(Game game)
        {
           if (!this.m_Settings.BasePath.Exists)
           {
               Directory.CreateDirectory(this.m_Settings.BasePath.FullName);
           }

           this.CreateOrEditMasterTable(game, this.m_Settings.BasePath);
           
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
            FileInfo dbfileToUpload = CreateDBFile(param.Game);
            return storage.Upload(param.Game, dbfileToUpload, param.SavedGame);
        }

    }
}
