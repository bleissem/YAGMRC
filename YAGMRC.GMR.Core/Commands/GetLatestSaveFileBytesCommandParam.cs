using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YAGMRC.GMR.Core.Commands
{
    public class GetLatestSaveFileBytesCommandParam
    {
        #region Constructor

        private GetLatestSaveFileBytesCommandParam()
        {
        }

        public GetLatestSaveFileBytesCommandParam(int gameid)
        {
            this.GameID = gameid;
        }

        #endregion Constructor

        public int GameID
        {
            get;
            private set;
        }
    }
}