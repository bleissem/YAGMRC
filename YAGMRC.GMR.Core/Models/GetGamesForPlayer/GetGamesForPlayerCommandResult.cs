using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YAGMRC.GMR.Core.Models.GetGamesForPlayer
{
    internal class GetGamesForPlayerCommandResult
    {
        #region Constructor

        private GetGamesForPlayerCommandResult()
        {
        }

        public GetGamesForPlayerCommandResult(List<RootObject> obj)
        {
            this.Result = obj;
        }

        #endregion Constructor

        public bool HasResult
        {
            get
            {
                return (null != this.Result);
            }
        }

        public List<RootObject> Result
        {
            get;
            private set;
        }
    }
}