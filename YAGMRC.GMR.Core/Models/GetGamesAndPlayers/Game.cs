﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YAGMRC.GMR.Core.Models.GetGamesAndPlayers
{
    public class Game
    {
        public string Name { get; set; }

        public int GameId { get; set; }

        public List<Player> Players { get; set; }

        public CurrentTurn CurrentTurn { get; set; }

        public int Type { get; set; }
    }
}