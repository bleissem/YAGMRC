using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YAGMRC.Create.Game.Model.SQL.GameDB
{
    [Table("Players")]
    public class PlayersTable
    {
        [PrimaryKey, AutoIncrement]
        public Guid ID { get; set; }

        public string Name { get; set; }

        public string EMail { get; set; }

    }
}
