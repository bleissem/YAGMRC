using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YAGMRC.Create.Game.Model.SQL.GameDB
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
