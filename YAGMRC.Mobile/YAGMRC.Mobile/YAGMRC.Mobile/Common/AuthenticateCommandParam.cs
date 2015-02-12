using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YAGMRC.Mobile.Common
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
