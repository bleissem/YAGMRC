using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YAGMRC.Core.DB
{
    [Table("Game")]
    public class GameTable
    {
        [PrimaryKey]
        public Guid ID { get; set; }

        public string Name { get; set; }

        public Guid PlayersTable_ID { get; set; }

    }
}
