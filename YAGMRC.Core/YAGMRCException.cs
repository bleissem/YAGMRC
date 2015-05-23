using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YAGMRC.Core
{
    public class YAGMRCException: Exception
    {
        #region Constructor 

        public YAGMRCException(string message):base(message)
        {

        }

        #endregion
    }
}
