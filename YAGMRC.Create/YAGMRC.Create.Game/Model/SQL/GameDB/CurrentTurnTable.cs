using SQLite.Net.Attributes;
using System;

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