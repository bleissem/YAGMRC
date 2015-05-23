using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAGMRC.Core.Model;

namespace YAGMRC.Core.ViewModels
{
    public class CreateGameViewModel : GalaSoft.MvvmLight.ViewModelBase
    {
        #region constructor

        public CreateGameViewModel()
        {
            
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

        private FileInfo CreateDBFile(Game game)
        {
            //TODO: implement DB 
            throw new NotImplementedException();
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
