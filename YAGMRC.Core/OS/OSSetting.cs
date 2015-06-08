using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YAGMRC.Core.OS
{
    public class OSSetting : IOSSetting
    {
        #region Constructor

        public OSSetting()
        {
            string environment = Environment.OSVersion.ToString().ToUpper();

            if (environment.Contains("UNIX"))
            {
                m_Setting = new LinuxSetting();
            }
            else if (environment.Contains("WINDOWS"))
            {
                m_Setting = new WindowsSetting();
            }
            else
            {
                throw new NotSupportedException("OS: " + environment + " not supported");
            }
        }

        #endregion Constructor

        private IOSSetting m_Setting;

        public System.IO.DirectoryInfo CIVSaveGamePath
        {
            get
            {
                return m_Setting.CIVSaveGamePath;
            }
        }

        public System.IO.DirectoryInfo BasePath
        {
            get
            {
                return m_Setting.BasePath;
            }
        }
    }
}