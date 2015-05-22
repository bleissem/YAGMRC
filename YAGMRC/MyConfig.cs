using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using YAGMRC.Properties;

namespace YAGMRC
{
    internal class MyConfig
    {
        public MyConfig()
        {
            this._Config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.PerUserRoaming);

            ExeConfigurationFileMap configFileMap = new ExeConfigurationFileMap();
            configFileMap.ExeConfigFilename = this._Config.FilePath;
            _MappedExeConfig = ConfigurationManager.OpenMappedExeConfiguration(configFileMap, ConfigurationUserLevel.None);
            // MessageBox.Show(this._Config.FilePath);
        }

        private Configuration _Config;
        private Configuration _MappedExeConfig;

        private const string AuthKeyConst = "AuthKey";

        [Obsolete]
        private const string DoArchiveGameFilesConst = "DoArchiveGameFiles";
        private const string KeepFilesInArchiveFolderConst = "KeepFilesInArchiveFolder";

        private const string AppSettingsConst = "appSettings";

        private string GetValue(string key)
        {
            if (!_MappedExeConfig.AppSettings.Settings.AllKeys.Contains(key))
            {
                _MappedExeConfig.AppSettings.Settings.Add(key, "");
                _MappedExeConfig.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection(AppSettingsConst);
            }

            return _MappedExeConfig.AppSettings.Settings[key].Value;
        }

        private void SetValue(string key, string value)
        {
            _MappedExeConfig.AppSettings.Settings[key].Value = value;
            _MappedExeConfig.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection(AppSettingsConst);
        }

        public string AuthKey
        {
            get
            {
                return this.GetValue(AuthKeyConst);
            }
            set
            {
                this.SetValue(AuthKeyConst, value);
            }
        }

        [Obsolete]
        private bool DoArchiveGameFiles
        {
            get
            {
                string str = this.GetValue(DoArchiveGameFilesConst);
                if (string.IsNullOrWhiteSpace(str))
                {
                    this.SetValue(DoArchiveGameFilesConst, true.ToString());
                    return true;
                }
                return Convert.ToBoolean(str);
            }
            set
            {
                this.SetValue(DoArchiveGameFilesConst, value.ToString());
            }
        }

        public int keepFilesInArchiveFolder
        {
            get
            {

                string str = this.GetValue(KeepFilesInArchiveFolderConst);
                if (string.IsNullOrWhiteSpace(str))
                {
                    int firstSelectedItemEver = MoveFilesToGameFolderItems.All;
                    this.SetValue(KeepFilesInArchiveFolderConst, firstSelectedItemEver.ToString());
                    return firstSelectedItemEver;
                }
                return Convert.ToInt32(str);
            }
            set
            {
                this.SetValue(KeepFilesInArchiveFolderConst, value.ToString());
            }
        }
    }
}