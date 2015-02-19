using SQLite.Net.Interop;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YAGMRC.Mobile
{
    public class Settings
    {

        public Settings(string dbPath, ISQLitePlatform platform)
        {
            m_DBPath = dbPath;
            m_SQLitePlatform = platform;
        }

        private void Load()
        {

            var db = new SQLite.Net.SQLiteConnection(m_SQLitePlatform, m_DBPath);

            db.CreateTable<YAGMRC.Mobile.Model.SettingsTable>();
            if (0 == db.Table<YAGMRC.Mobile.Model.SettingsTable>().Count())
            {
                var newSettings = new YAGMRC.Mobile.Model.SettingsTable();
                newSettings.AuthKey = string.Empty;
                db.Insert(newSettings);
            }


            m_Auth = db.Table<YAGMRC.Mobile.Model.SettingsTable>().First().AuthKey;

        }

        private void Save()
        {
            var db = new SQLite.Net.SQLiteConnection(m_SQLitePlatform, m_DBPath);

            db.CreateTable<YAGMRC.Mobile.Model.SettingsTable>();
            if (0 == db.Table<YAGMRC.Mobile.Model.SettingsTable>().Count())
            {
                Load();
            }
            else
            {
                var settingsTable = db.Table<YAGMRC.Mobile.Model.SettingsTable>().First();
                settingsTable.AuthKey = m_Auth;
                db.Update(settingsTable);
            }


        }


        private string m_DBPath;
        private ISQLitePlatform m_SQLitePlatform;

        private string m_Auth;
        public string Auth
        {
            get
            {
                Load();
                return m_Auth;
            }
            set
            {
                if (value == m_Auth)
                {
                    return;
                }

                m_Auth = value;
                Save();
            }
        }
    }
}
