using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAGMRC.Mobile.Model.GetGamesForPlayer;

namespace YAGMRC.Mobile
{
    internal class GetGamesForPlayerCommand : ICommand, IResult<GetGamesForPlayerCommandResult>
    {
        #region Constructor

        private GetGamesForPlayerCommand()
        {
        }

        internal GetGamesForPlayerCommand(DownloadWithJson communication, string authKey)
        {
            m_Communication = communication;
            m_AuthKey = authKey;
        }

        #endregion Constructor

        private DownloadWithJson m_Communication;
        private string m_AuthKey;

        public async void Execute()
        {
            if (!this.CanExecute())
            {
                this.Result = new GetGamesForPlayerCommandResult(new List<RootObject>());
                return;
            }


            List<RootObject> game = await m_Communication.Execute<List<RootObject>>("GetGamesForPlayer?authKey=" + m_AuthKey);

            if (null != game)
            {
                this.Result = new GetGamesForPlayerCommandResult(game);
            }
            else
            {
                this.Result = new GetGamesForPlayerCommandResult(new List<RootObject>());
            }
        }

        public bool CanExecute()
        {
            return true;
        }

        public GetGamesForPlayerCommandResult Result
        {
            get;
            private set;
        }
    }
}
