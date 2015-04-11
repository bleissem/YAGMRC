using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YAGMRC.GMR.Core.Commands
{
    public class AuthenticateCommandParam
    {
        #region Constructor

        private AuthenticateCommandParam()
        {

        }

        public AuthenticateCommandParam(string authKey)
        {
            this.AuthKey = authKey;
        }

        #endregion

        public string AuthKey
        {
            get;
            set;
        }
    }
}
