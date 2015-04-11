using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YAGMRC.Create.Game.Model.SQL.GameDB
{
    [Table("CurrentTurn")]
    public class CurrentTurnTable
    {
        public Guid GameID { get; set; }

        public Guid TurnID { get; set; }

        /*
        public DateTime Expires { get; set; }
         * */
    }
}
