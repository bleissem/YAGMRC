using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YAGMRC.Mobile.ViewModels
{
    public class GameViewModel
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

    }
}
