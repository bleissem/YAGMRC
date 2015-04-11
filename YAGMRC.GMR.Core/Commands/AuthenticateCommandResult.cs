using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YAGMRC.GMR.Core.Commands
{
    public class AuthenticateCommandResult
    {
        #region Constructor

        public AuthenticateCommandResult()
            : this(false, null, null)
        {
        }

        public AuthenticateCommandResult(bool authenticated, string authid, string playerID)
        {
            if (string.IsNullOrWhiteSpace(playerID))
            {
                this.PlayerID = 0;
            }
            else
            {
                this.PlayerID = Convert.ToInt64(playerID);
            }

            this.Authenticated = authenticated;
            this.AuthID = authid;
        }

        public AuthenticateCommandResult(bool authenticated, string authid, Int64 playerID)
        {
            this.Authenticated = authenticated;
            this.AuthID = authid;
            this.PlayerID = playerID;
        }

        #endregion Constructor

        public bool Authenticated
        {
            get;
            private set;
        }

        internal string AuthID
        {
            get;
            private set;
        }

        public Int64 PlayerID
        {
            get;
            private set;
        }
    }
}