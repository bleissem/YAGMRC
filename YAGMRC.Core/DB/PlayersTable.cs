using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YAGMRC.Core.DB
{
    [Table("Players")]
    public class PlayersTable
    {
        [SQLite.Net.Attributes.NotNull]
        public Guid Guid { get; set; }
    }
}
