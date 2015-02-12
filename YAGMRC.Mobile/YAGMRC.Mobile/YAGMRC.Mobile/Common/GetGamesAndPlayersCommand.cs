﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace YAGMRC.Mobile.Common
{
    internal class GetGamesAndPlayersCommand : ICommand, IResult<GetGamesPlayersCommandResult>
    {
        #region Constructor

        private GetGamesAndPlayersCommand()
        {
        }

        internal GetGamesAndPlayersCommand(YAGMRC.Mobile.Model.GetGamesForPlayer.GetGamesForPlayerCommandResult getGamesForPlayerCommandResult, string authKey, DownloadWithJson communication)
        {
            m_GetGamesForPlayerCommandResult = getGamesForPlayerCommandResult;
            m_AuthKey = authKey;
            m_Communication = communication;
        }

        #endregion Constructor

        private string m_AuthKey;
        private YAGMRC.Mobile.Model.GetGamesForPlayer.GetGamesForPlayerCommandResult m_GetGamesForPlayerCommandResult;
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

        public async void Execute()
        {
            if (!this.CanExecute())
            {
                this.Result = new GetGamesPlayersCommandResult(new YAGMRC.Mobile.Model.GetGamesAndPlayers.RootObject());
                return;
            }


            List<long> players = this.GetPlayerIDs();

            List<string> playerList = (from x in players select x.ToString()).ToList();

            string playerIDText = string.Join("_", playerList);


            YAGMRC.Mobile.Model.GetGamesAndPlayers.RootObject ro = await this.m_Communication.Execute<YAGMRC.Mobile.Model.GetGamesAndPlayers.RootObject>("GetGamesAndPlayers?playerIDText=" + playerIDText + "&authKey=" + m_AuthKey);
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
