using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YAGMRC.Core;
using YAGMRC.Core.Commands;

namespace YAGMRC.GMR.Core
{
    internal interface IDownloadSavedGame : ICommand<string>, IResult<byte[]>
    {
    }

    internal class DownloadSavedGame : IDownloadSavedGame
    {
        #region Constructor

        private DownloadSavedGame()
        {
        }

        public DownloadSavedGame(Uri baseUri)
        {
            m_BaseUri = baseUri;
        }

        #endregion Constructor

        private Uri m_BaseUri;

        public void Execute(string parameter)
        {
            this.Result = new System.Net.WebClient().DownloadData(new Uri(m_BaseUri, parameter));
        }

        public bool CanExecute()
        {
            return true;
        }

        public byte[] Result
        {
            get;
            private set;
        }
    }
}
