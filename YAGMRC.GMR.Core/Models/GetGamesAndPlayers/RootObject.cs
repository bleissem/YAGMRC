using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YAGMRC.GMR.Core.Models.GetGamesAndPlayers
{
    public class RootObject
    {
        public List<Game> Games { get; set; }

        public List<Player2> Players { get; set; }

        public int CurrentTotalPoints { get; set; }
    }
}