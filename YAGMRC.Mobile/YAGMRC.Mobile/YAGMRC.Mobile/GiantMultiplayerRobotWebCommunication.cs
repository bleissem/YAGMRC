using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YAGMRC.Mobile
{
    public class GiantMultiplayerRobotWebCommunication : IWebCommunitcation
    {
        #region Constructor

        public GiantMultiplayerRobotWebCommunication()
        {
            m_BaseUri = new Uri("http://multiplayerrobot.com/api/Diplomacy/");
            m_DownloadWithJson = new DownloadWithJson(m_BaseUri);
        }

        #endregion Constructor


        private Uri m_BaseUri;
        private DownloadWithJson m_DownloadWithJson;


        public bool CanExecute()
        {
            return true;
        }



        public async Task<AuthenticateCommandResult> Authenticate(AuthenticateCommandParam parameter)
        {
            string webResult = await m_DownloadWithJson.Execute<string>("AuthenticateUser?authKey=" + parameter.AuthKey);
            return new AuthenticateCommandResult((null != webResult) && (!"null".Equals(webResult)), parameter.AuthKey, webResult);
        }





        public GetGamesPlayersCommandResult GetGamesAndPlayers(string authKey)
        {
            GetGamesForPlayerCommand cmd1 = new GetGamesForPlayerCommand(m_DownloadWithJson, authKey);
            cmd1.Execute();
            if (!cmd1.Result.HasResult)
            {
               throw new Exception("GetGamesForPlayerCommand no result");
            }

            GetGamesAndPlayersCommand cmd2 = new GetGamesAndPlayersCommand(cmd1.Result, authKey, m_DownloadWithJson);
            cmd2.Execute();

            if (!cmd2.Result.HasResult)
            {
               throw new Exception("GetGamesForPlayerCommand no result");
            }

            return cmd2.Result;
        }

       
    }
}
