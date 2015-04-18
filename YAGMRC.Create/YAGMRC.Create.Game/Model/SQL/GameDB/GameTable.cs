using SQLite.Net.Attributes;
using System;

namespace YAGMRC.Game.Model.SQL.GameDB
{
    [Table("Game")]
    public class GameTable
    {
        [PrimaryKey, AutoIncrement]
        public Guid ID { get; set; }

        public string Name { get; set; }

        public LocationType Location { get; set; }

        public GameType Type { get; set; }
    }
}