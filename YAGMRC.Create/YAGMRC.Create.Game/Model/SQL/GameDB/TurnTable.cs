using SQLite.Net.Attributes;
using System;

namespace YAGMRC.Create.Game.Model.SQL.GameDB
{
    [Table("Turn")]
    public class TurnTable
    {
        [PrimaryKey, AutoIncrement]
        public Guid ID { get; set; }

        public int TurnOrder { get; set; }

        public Guid GameID { get; set; }

        public Guid PlayerID { get; set; }
    }
}