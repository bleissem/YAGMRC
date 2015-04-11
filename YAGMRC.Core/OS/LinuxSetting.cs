using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace YAGMRC.Core.OS
{
    public class LinuxSetting : IOSSetting
    {
        public System.IO.DirectoryInfo CIVSaveGamePath
        {
            get
            {
                string path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
                path = Path.Combine(path, ".local", "share", "Aspyr", "Sid Meier's Civilization 5", "Saves", "hotseat");
                return new DirectoryInfo(path);
            }
        }
    }
}