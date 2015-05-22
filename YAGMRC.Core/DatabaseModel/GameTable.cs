using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YAGMRC.Core.Model;

namespace YAGMRC.Core.DatabaseModel
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
