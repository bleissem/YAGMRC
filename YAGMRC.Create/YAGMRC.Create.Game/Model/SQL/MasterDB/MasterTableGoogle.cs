using SQLite.Net.Attributes;
using System;

namespace YAGMRC.Create.Game.Model.SQL.MasterDB
{
    [Table("MasterTableGoogle")]
    public class MasterTableGoogle
    {
        public Guid GameID { get; set; }

        public string DBFile { get; set; }

        public string GameFile { get; set; }
    }
}