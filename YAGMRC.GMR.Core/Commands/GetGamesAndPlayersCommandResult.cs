using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YAGMRC.GMR.Core.Models.GetGamesAndPlayers;

namespace YAGMRC.GMR.Core.Commands
{
    public class GetGamesPlayersCommandResult
    {
        #region Constructor

        private GetGamesPlayersCommandResult()
        {
        }

        public GetGamesPlayersCommandResult(RootObject model)
        {
            this.Result = model;
            m_HasList = new SortedDictionary<int, string>();
        }

        #endregion Constructor

        public bool HasResult
        {
            get
            {
                return (null != this.Result);
            }
        }

        public RootObject Result
        {
            get;
            private set;
        }

        private SortedDictionary<int, string> m_HasList;

        internal void SetHashCode(int gameid, string hash)
        {
            m_HasList[gameid] = hash;
        }

        public bool TryGetHash(int gameid, out string hash)
        {
            return m_HasList.TryGetValue(gameid, out hash);
        }

    }
}