using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using YAGMRC.Core;
using YAGMRC.Core.Commands;
using YAGMRC.GMR.Core.Commands;
using YAGMRC.GMR.Core.Models.GetGamesForPlayer;

namespace YAGMRC.GMR.Core
{
    internal class GetGamesAndPlayersCommand : ICommand, IResult<GetGamesPlayersCommandResult>
    {
        #region Constructor

        private GetGamesAndPlayersCommand()
        {
        }

        internal GetGamesAndPlayersCommand(GetGamesForPlayerCommandResult getGamesForPlayerCommandResult, string authKey, DownloadWithJson communication)
        {
            m_GetGamesForPlayerCommandResult = getGamesForPlayerCommandResult;
            m_AuthKey = authKey;
            m_Communication = communication;
        }

        #endregion Constructor

        private string m_AuthKey;
        private GetGamesForPlayerCommandResult m_GetGamesForPlayerCommandResult;
        DownloadWithJson m_Communication;

        private List<long> GetPlayerIDs()
        {
            List<long> playerIDList = new List<long>();

            foreach (var result in m_GetGamesForPlayerCommandResult.Result)
            {
                foreach (var player in result.Players)
                {
                    if (!playerIDList.Contains(player.UserId))
                    {
                        playerIDList.Add(player.UserId);
                    }
                }
            }

            return playerIDList;
        }

        public void Execute()
        {
            if (!this.CanExecute())
            {
                this.Result = new GetGamesPlayersCommandResult(new YAGMRC.GMR.Core.Models.GetGamesAndPlayers.RootObject());
                return;
            }

            
            List<long> players = this.GetPlayerIDs();

            string playerIDText = string.Join("_", players.ConvertAll<string>((long playerID) => playerID.ToString()));


            YAGMRC.GMR.Core.Models.GetGamesAndPlayers.RootObject ro = this.m_Communication.Execute < YAGMRC.GMR.Core.Models.GetGamesAndPlayers.RootObject>("GetGamesAndPlayers?playerIDText=" + playerIDText + "&authKey=" + m_AuthKey);
            this.Result = new GetGamesPlayersCommandResult(ro);
        }

        public GetGamesPlayersCommandResult Result
        {
            get;
            private set;
        }

        public bool CanExecute()
        {
            return true;
        }
    }
}