using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YAGMRC.Create.Game.Model.SQL.MasterDB
{
    [Table("Master")]
    public class MasterTable
    {
        public Guid GameID { get; set; }

        public GameType GameType { get; set; }

    }
}
