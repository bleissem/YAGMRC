using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YAGMRC.Core.DatabaseModel
{
    [Table("MasterTableGoogle")]
    public class MasterTableGoogle
    {
        public Guid GameID { get; set; }

        public string DBFile { get; set; }

        public string GameFile { get; set; }
    }
}
