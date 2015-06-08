using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;


namespace YAGMRC.Core.OS
{
    public class WindowsSetting : IOSSetting
    {
        #region constructor

        public WindowsSetting()
        {
            string personalPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            this.CIVSaveGamePath = new DirectoryInfo(Path.Combine(personalPath, "My Games", "Sid Meier's Civilization 5", "Saves", "hotseat"));
            this.BasePath = new DirectoryInfo(Path.Combine(personalPath, "YAGMRC"));
        }

        #endregion constructor

        public DirectoryInfo BasePath
        {
            get;
            private set;
        }

        public DirectoryInfo CIVSaveGamePath
        {
            get;
            private set;
        }
    }
}