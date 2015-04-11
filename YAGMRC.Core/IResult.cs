using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YAGMRC.Core
{
    public interface IResult<T>
    {
        T Result
        {
            get;
        }
    }
}