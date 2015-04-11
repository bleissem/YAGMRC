using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace YAGMRC.GMR.Core
{
    public class WebUploadParam
    {
        #region Constructor

        private WebUploadParam()
        {
        }

        public WebUploadParam(string path, FileInfo file, byte[] data, string authKey, int turnID)
        {
            this.Path = path;
            this.Data = data;
            this.File = file;
            this.AuthKey = authKey;
            this.TurnID = turnID;
        }

        #endregion Constructor

        public string Path
        {
            get;
            private set;
        }

        public byte[] Data
        {
            get;
            private set;
        }

        public FileInfo File
        {
            get;
            private set;
        }

        public string AuthKey
        {
            get;
            private set;
        }

        public int TurnID
        {
            get;
            private set;
        }
    }
}