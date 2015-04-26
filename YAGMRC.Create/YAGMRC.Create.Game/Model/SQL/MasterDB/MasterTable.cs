using SQLite.Net.Attributes;
using System;

namespace YAGMRC.Core.Model.SQL.MasterDB
{
    [Table("Master")]
    public class MasterTable
    {
        public Guid GameID { get; set; }

        public GameType GameType { get; set; }
    }
}