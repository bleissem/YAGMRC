using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace YAGMRC.Core.Commands
{
    public class SubmitTurnCommandParam
    {
        #region Constructor

        private SubmitTurnCommandParam()
        {
        }

        public SubmitTurnCommandParam(int gameID, bool doArchiveFile)
        {
            this.GameID = gameID;
            this.DoArchiveFile = doArchiveFile;
            this.UseThisFileToUpload = null;
        }

        public SubmitTurnCommandParam(int gameID, bool doArchiveFile, FileInfo useThisFileToUpload)
            : this(gameID, doArchiveFile)
        {
            this.UseThisFileToUpload = useThisFileToUpload;
        }

        #endregion Constructor

        public int GameID { get; private set; }

        public bool DoArchiveFile { get; private set; }

        public FileInfo UseThisFileToUpload { get; private set; }

    }
}