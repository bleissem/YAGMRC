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
        [PrimaryKey]
        public Guid GameID { get; set; }

        public string DBFileID { get; set; }

        public string GameFileID { get; set; }
    }
}
