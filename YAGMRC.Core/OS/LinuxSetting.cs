using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace YAGMRC.Core.OS
{
    public class LinuxSetting : IOSSetting
    {

        #region constructor

        public LinuxSetting()
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string local = ".local";
            this.BasePath = new DirectoryInfo(Path.Combine(path, local, "YAGMRC"));
            this.CIVSaveGamePath = new DirectoryInfo(Path.Combine(path, local, "share", "Aspyr", "Sid Meier's Civilization 5", "Saves", "hotseat"));
        }

        #endregion

        public System.IO.DirectoryInfo CIVSaveGamePath
        {
            get;
            private set;
        }

        public DirectoryInfo BasePath
        {
            get;
            private set;
        }
    }
}