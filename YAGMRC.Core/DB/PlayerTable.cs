using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YAGMRC.Core.DB
{
    [Table("Player")]
    public class PlayerTable
    {
        [SQLite.Net.Attributes.NotNull]
        public Guid ID { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }
    }
}
