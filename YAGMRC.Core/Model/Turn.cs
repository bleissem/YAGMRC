using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YAGMRC.Core.Model
{
    public class Turn
    {
#region constructor

        public Turn(Player player)
        {
            this.ID = Guid.NewGuid();
            this.Player = player;
        }

#endregion

        public Guid ID { get; set; }

        public Player Player { get; private set; }
        
    }
}
