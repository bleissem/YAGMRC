using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YAGMRC.Mobile.ViewModels
{
    public class GameViewModel : ViewModelBase
    {
        #region constructor

        private GameViewModel()
        {
        }

        public GameViewModel(Model.GetGamesAndPlayers.Game game)
        {
            this.m_Game = game;
        }

        #endregion constructor

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

        public string Name
        {
            get
            {
                return m_Game.Name;
            }
        }

        public DateTime? Expires
        {
            get
            {
                if (null != m_Game.CurrentTurn)
                {
                    return m_Game.CurrentTurn.Expires;
                }

                return null;
            }
        }
    }
}