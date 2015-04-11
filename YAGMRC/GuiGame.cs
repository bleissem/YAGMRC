using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YAGMRC.GMR.Core.Models.GetGamesAndPlayers;

namespace YAGMRC
{
    internal class GuiGame
    {
        #region Constructor

        private GuiGame()
        {
        }

        public GuiGame(Game game)
        {
            this.Game = game;
        }

        #endregion Constructor

        public Game Game
        {
            get;
            private set;
        }

        public string DisplayValue
        {
            get
            {
                return Game.GameId.ToString() + " - " + Game.Name;
            }
        }
    }
}