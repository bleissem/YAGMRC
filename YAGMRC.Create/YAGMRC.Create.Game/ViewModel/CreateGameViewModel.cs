using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAGMRC.Core.Common;
using YAGMRC.Core.Model;

namespace YAGMRC.Core.ViewModel
{
    public class CreateGameViewModel: GalaSoft.MvvmLight.ViewModelBase
    {
        #region constructor

        public CreateGameViewModel(IStorage storage)
        {
             m_Execute = new RelayCommand<CreateGameParam>((createGame)=>storage.Upload(createGame.Game, createGame.DBFile, createGame.SavedGame));            
        }

        #endregion

        #region nested Classes

        public class CreateGameParam
        {
            public Game Game { get; set; }
            public FileInfo DBFile { get; set; }
            public FileInfo SavedGame { get; set; }
        }

        public class CreateGameResult
        {
            public CreateGameResult()
            {

            }
        }

        #endregion

        private RelayCommand<CreateGameParam> m_Execute;
        public RelayCommand<CreateGameParam> Execute
        {
            get
            {
                return m_Execute;
            }
        }

    }
}
