using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YAGMRC.GMR.Core.Models.GetGamesAndPlayers
{
    public class Player2
    {
        public object SteamID { get; set; }

        public string PersonaName { get; set; }

        public string AvatarUrl { get; set; }

        public int PersonaState { get; set; }

        public int GameID { get; set; }
    }
}