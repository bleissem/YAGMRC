using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YAGMRC.Mobile.ViewModels
{
    public class GameViewModel: ViewModelBase
    {

        #region constructor

        private GameViewModel()
        {

        }

        public GameViewModel(Model.GetGamesAndPlayers.Game game)
        {
            m_Game = game;
        }

        #endregion

        private Model.GetGamesAndPlayers.Game m_Game;

        public override string ToString()
        {
            return m_Game.Name;
        }

        public int GameID
        {
            get
            {
                return m_Game.GameId;
            }
        }

    }
}
