using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace YAGMRC.Core.OS
{
    public class WindowsSetting : IOSSetting
    {
        public DirectoryInfo CIVSaveGamePath
        {
            get
            {
                string path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
                path = Path.Combine(path, "My Games", "Sid Meier's Civilization 5", "Saves", "hotseat");
                return new DirectoryInfo(path);
            }
        }
    }
}