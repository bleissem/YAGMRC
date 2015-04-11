using GalaSoft.MvvmLight.Ioc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using YAGMRC.Core;
using YAGMRC.Core.Commands;
using YAGMRC.GMR.Core.Web;

namespace YAGMRC.GMR.Core.Commands
{
    public class GetGamesPlayersCommand : ICommand, IResult<GetGamesPlayersCommandResult>
    {
        #region Constructor

        private GetGamesPlayersCommand()
        {
        }

        public GetGamesPlayersCommand(SimpleIoc resolver)
        {
            m_Resolver = resolver;
        }

        #endregion Constructor

        private SimpleIoc m_Resolver;

        public void Execute()
        {
            this.Result = new GetGamesPlayersCommandResult(new YAGMRC.GMR.Core.Models.GetGamesAndPlayers.RootObject());

            if (!this.CanExecute())
            {
                return;
            }

            IWebCommunitcation executeWeb = m_Resolver.GetInstance<IWebCommunitcation>();
            AuthenticateCommandResult auth = m_Resolver.GetInstance<AuthenticateCommandResult>();

            this.Result = executeWeb.GetGamesAndPlayers(auth.AuthID);

            this.m_Resolver.Unregister<GetGamesPlayersCommandResult>();
            this.m_Resolver.Register<GetGamesPlayersCommandResult>(()=>this.Result);
        }

        public bool CanExecute()
        {
            AuthenticateCommandResult auth = m_Resolver.GetInstance<AuthenticateCommandResult>();
            if ((null != auth) && (auth.Authenticated))
            {
                return true;
            }

            return false;
        }

        public GetGamesPlayersCommandResult Result
        {
            get;
            private set;
        }
    }
}