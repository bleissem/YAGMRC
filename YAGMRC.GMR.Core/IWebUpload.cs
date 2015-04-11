using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YAGMRC.Core;
using YAGMRC.Core.Commands;
using YAGMRC.Core.Models.SubmitTurn;

namespace YAGMRC.GMR.Core
{
    public interface IWebUpload : ICommand<WebUploadParam>, IResult<WebUploadResult>
    {
    }
}
