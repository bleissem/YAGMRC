using GalaSoft.MvvmLight.Ioc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using YAGMRC.Core;
using YAGMRC.Core.Commands;
using YAGMRC.Core.OS;
using YAGMRC.GMR.Core.Models.GetGamesAndPlayers;
using YAGMRC.GMR.Core.Web;

namespace YAGMRC.GMR.Core.Commands
{
    public class GetLatestSaveFileBytesCommand : ICommand<GetLatestSaveFileBytesCommandParam>
    {
        #region Constructor

        private GetLatestSaveFileBytesCommand()
        {
        }

        public GetLatestSaveFileBytesCommand(SimpleIoc resolver)
        {
            m_Resolver = resolver;
        }

        #endregion Constructor

        private SimpleIoc m_Resolver;

        public void Execute(GetLatestSaveFileBytesCommandParam parameter)
        {
            if (!this.CanExecute())
            {
                return;
            }

            IWebCommunitcation executeWeb = m_Resolver.GetInstance<IWebCommunitcation>();

            int gameid = parameter.GameID;
            {
                GetGamesPlayersCommandResult games = m_Resolver.GetInstance<GetGamesPlayersCommandResult>();
                Game foundGame = (from id in games.Result.Games where id.GameId == gameid select id).FirstOrDefault();
                if (null == foundGame)
                {
                    return;
                }
                AuthenticateCommandResult auth = m_Resolver.GetInstance<AuthenticateCommandResult>();

                byte[] webResult = executeWeb.DownloadSaveGame(auth.AuthID, foundGame.GameId); ;

                string path = m_Resolver.GetInstance<IOSSetting>().CIVSaveGamePath.FullName;

                Directory.CreateDirectory(path);

                FileInfo fi = Helper.File(gameid, m_Resolver.GetInstance<IOSSetting>());
                if (fi.Exists)
                {
                    fi.Delete();
                }
                     
                games.SetHashCode(gameid,Helper.GetHashCode(webResult));
                

                File.WriteAllBytes(fi.FullName, webResult);
            }
        }

        public bool CanExecute()
        {
            AuthenticateCommandResult auth = m_Resolver.GetInstance<AuthenticateCommandResult>();
            GetGamesPlayersCommandResult games = m_Resolver.GetInstance<GetGamesPlayersCommandResult>();
            return (games.HasResult) && ((null != auth) && (auth.Authenticated));
        }
    }
}