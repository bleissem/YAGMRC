using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YAGMRC.Core.Models.SubmitTurn
{
    public class WebUploadResult
    {
        #region Construcor

        private WebUploadResult()
        {
        }

        public WebUploadResult(SubmitTurnResult result)
        {
            this.Result = result;
        }

        #endregion Construcor

        public SubmitTurnResult Result
        {
            get;
            private set;
        }
    }
}