using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YAGMRC.Core.DatabaseModel
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
