using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YAGMRC.Mobile.Model.GetGamesForPlayer
{
    public class RootObject
    {
        public string Name { get; set; }

        public int GameId { get; set; }

        public List<Player> Players { get; set; }

        public CurrentTurn CurrentTurn { get; set; }

        public int Type { get; set; }
    }
}
