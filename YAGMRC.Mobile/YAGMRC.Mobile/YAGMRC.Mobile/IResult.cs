using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YAGMRC.Mobile
{
    public interface IResult<T>
    {
        T Result
        {
            get;
        }
    }
}
