using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YAGMRC.Mobile.Model.GetGamesForPlayer
{
    public class CurrentTurn
    {
        public int TurnId { get; set; }

        public int Number { get; set; }

        public long UserId { get; set; }

        public string Started { get; set; }

        public string Expires { get; set; }

        public bool Skipped { get; set; }

        public int PlayerNumber { get; set; }

        public bool IsFirstTurn { get; set; }
    }
}
