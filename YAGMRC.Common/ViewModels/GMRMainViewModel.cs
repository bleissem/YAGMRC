using GalaSoft.MvvmLight.Ioc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YAGMRC.Core;
using YAGMRC.Core.Commands;
using YAGMRC.Core.OS;
using YAGMRC.GMR.Core.Commands;
using YAGMRC.GMR.Core.Web;


namespace YAGMRC.Common.ViewModels
{
    public class GMRMainViewModel 
    {
        #region Constructor

        internal GMRMainViewModel()
        {
            m_Resolver = new SimpleIoc();
            m_Resolver.Register<IWebCommunitcation>(()=>new GiantMultiplayerRobotWebCommunication());
            m_Resolver.Register<AuthenticateCommandResult>(() => new AuthenticateCommandResult());
            m_Resolver.Register<GetGamesPlayersCommandResult>(() => new GetGamesPlayersCommandResult(null));
            m_Resolver.Register<IOSSetting>(() => new OSSetting());
        }

        #endregion Constructor

        private SimpleIoc m_Resolver;

        public SimpleIoc Resolver
        {
            get
            {
                return m_Resolver;
            }
        }

        private AuthenticateCommand m_AuthenticateCommand;

        public AuthenticateCommand Authenticate
        {
            get
            {
                if (null == m_AuthenticateCommand)
                {
                    m_AuthenticateCommand = new AuthenticateCommand(m_Resolver,
                        (auth) =>
                        {
                            m_Resolver.Unregister<AuthenticateCommandResult>();
                            m_Resolver.Register<AuthenticateCommandResult>(()=>auth);
                        });
                }

                return m_AuthenticateCommand;
            }
        }

        private GetGamesPlayersCommand m_GetGamesPlayersCommand;

        public GetGamesPlayersCommand GetGamesAndPlayers
        {
            get
            {
                if (null == m_GetGamesPlayersCommand)
                {
                    m_GetGamesPlayersCommand = new GetGamesPlayersCommand(m_Resolver);
                }
                return m_GetGamesPlayersCommand;
            }
        }

        private GetLatestSaveFileBytesCommand m_GetLatestSaveFileBytes;

        public GetLatestSaveFileBytesCommand GetLatestSaveFileBytes
        {
            get
            {
                if (null == m_GetLatestSaveFileBytes)
                {
                    this.m_GetLatestSaveFileBytes = new GetLatestSaveFileBytesCommand(m_Resolver);
                }

                return m_GetLatestSaveFileBytes;
            }
        }

        private SubmitTurnCommand m_SubmitTurn;

        public SubmitTurnCommand SubmitTurn
        {
            get
            {
                if (null == m_SubmitTurn)
                {
                    m_SubmitTurn = new SubmitTurnCommand(m_Resolver);
                }
                return m_SubmitTurn;
            }
        }


    }
}