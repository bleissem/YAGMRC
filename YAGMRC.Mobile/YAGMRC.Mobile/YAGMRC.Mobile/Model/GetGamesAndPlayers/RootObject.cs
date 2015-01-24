using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YAGMRC.Mobile.Model.GetGamesAndPlayers
{
    public class RootObject
    {
        public List<Game> Games { get; set; }

        public List<Player2> Players { get; set; }

        public int CurrentTotalPoints { get; set; }
    }
}
