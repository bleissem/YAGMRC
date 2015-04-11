using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace YAGMRC.Core.OS
{
    public interface IOSSetting
    {
        DirectoryInfo CIVSaveGamePath
        {
            get;
        }
    }
}