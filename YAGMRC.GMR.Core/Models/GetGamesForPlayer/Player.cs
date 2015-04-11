using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YAGMRC.GMR.Core.Models.GetGamesForPlayer
{
    public class Player
    {
        public long UserId { get; set; }

        public int TurnOrder { get; set; }
    }
}