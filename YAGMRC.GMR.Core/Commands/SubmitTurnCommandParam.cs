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

        public SubmitTurnCommandParam(int gameID, int archivedFiles)
        {
            this.GameID = gameID;
            this.ArchivedFiles = archivedFiles;
            this.UseThisFileToUpload = null;
        }

        public SubmitTurnCommandParam(int gameID, int archivedFiles, FileInfo useThisFileToUpload)
            : this(gameID, archivedFiles)
        {
            this.UseThisFileToUpload = useThisFileToUpload;
        }

        #endregion Constructor

        public int GameID { get; private set; }

        public int ArchivedFiles { get; private set; }

        public FileInfo UseThisFileToUpload { get; private set; }

    }
}