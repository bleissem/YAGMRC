using GalaSoft.MvvmLight.Ioc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YAGMRC.Core;
using YAGMRC.Core.Commands;
using YAGMRC.GMR.Core.Web;

namespace YAGMRC.GMR.Core.Commands
{
    public class AuthenticateCommand : ICommand<AuthenticateCommandParam>, IResult<AuthenticateCommandResult>
    {
        #region Constructor

        private AuthenticateCommand()
        {
        }

        public AuthenticateCommand(SimpleIoc resolver, Action<AuthenticateCommandResult> authenticated)
        {
            m_Resolver = resolver;
            m_Authenticated = authenticated;
            this.Result = new AuthenticateCommandResult();
        }

        #endregion Constructor

        private SimpleIoc m_Resolver;
        private Action<AuthenticateCommandResult> m_Authenticated;

        public void Execute(AuthenticateCommandParam parameter)
        {
            IWebCommunitcation executeWeb = m_Resolver.GetInstance<IWebCommunitcation>();
            AuthenticateCommandResult result = executeWeb.Authenticate(parameter);
           
            m_Authenticated(result);

            this.Result = result;
        }

        public bool CanExecute()
        {
            return true;
        }

        public AuthenticateCommandResult Result
        {
            get;
            private set;
        }
    }
}