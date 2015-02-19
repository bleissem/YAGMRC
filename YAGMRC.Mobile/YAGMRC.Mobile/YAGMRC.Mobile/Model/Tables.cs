using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YAGMRC.Mobile.Model
{
    [Table("Settings")]
    public class SettingsTable
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string AuthKey { get; set; }
    }
}
