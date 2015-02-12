using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YAGMRC.Mobile.Common
{
    public class GetGamesPlayersCommandResult
    {
        #region Constructor

        public GetGamesPlayersCommandResult():this(null)
        {
        }

        public GetGamesPlayersCommandResult(YAGMRC.Mobile.Model.GetGamesAndPlayers.RootObject model)
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

        public YAGMRC.Mobile.Model.GetGamesAndPlayers.RootObject Result
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
