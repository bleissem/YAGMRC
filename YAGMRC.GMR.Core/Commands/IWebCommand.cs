using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YAGMRC.Core.Commands
{
    internal interface IWebCommand
    {
        TResult Execute<TResult>();
    }
}