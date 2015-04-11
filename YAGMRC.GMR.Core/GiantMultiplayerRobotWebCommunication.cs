using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using YAGMRC.Core.Commands;
using YAGMRC.Core.Models.SubmitTurn;
using YAGMRC.GMR.Core.Commands;

namespace YAGMRC.GMR.Core.Web
{
    public class GiantMultiplayerRobotWebCommunication: IWebCommunitcation
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



        public AuthenticateCommandResult Authenticate(AuthenticateCommandParam parameter)
        {
            string webResult = m_DownloadWithJson.Execute<string>("AuthenticateUser?authKey=" + parameter.AuthKey);
            return new AuthenticateCommandResult((null != webResult) && (!"null".Equals(webResult)), parameter.AuthKey, webResult);
        }

        public byte[] DownloadSaveGame(string authKey, int gameId)
        {
            YAGMRC.GMR.Core.DownloadSavedGame cmd = new DownloadSavedGame(m_BaseUri);
            cmd.Execute("GetLatestSaveFileBytes?authKey=" + authKey.Trim() + "&gameId=" + gameId.ToString());
            return cmd.Result;                    
        }

        public WebUploadResult UploadGame(FileInfo fileToUpload, string authKey, int turnId)
        {
            WebUpload cmd = new WebUpload();
            cmd.Execute(new WebUploadParam("Game/UploadSaveClient", fileToUpload, File.ReadAllBytes(fileToUpload.FullName), authKey, turnId));
            return cmd.Result;
        }
     



        public GetGamesPlayersCommandResult GetGamesAndPlayers(string authKey)
        {
            GetGamesForPlayerCommand cmd1 = new GetGamesForPlayerCommand(m_DownloadWithJson, authKey);
            cmd1.Execute();
            if (!cmd1.Result.HasResult)
            {
                Trace.Fail("GetGamesForPlayerCommand no result");
            }

            GetGamesAndPlayersCommand cmd2 = new GetGamesAndPlayersCommand(cmd1.Result, authKey, m_DownloadWithJson);
            cmd2.Execute();

            if (!cmd2.Result.HasResult)
            {
                Trace.Fail("GetGamesForPlayerCommand no result");
            }

            return cmd2.Result;
        }
    }
}