using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace YAGMRC
{
    public class MyTraceListener: TraceListener
    {

        #region Constructor

        public MyTraceListener(Action<string> write, Action<string> writeLine)
        {
            m_Write = write;
            m_WriteLine = writeLine;
        }

        #endregion

        private Action<string> m_Write;
        private Action<string> m_WriteLine;

        public override void Write(string message)
        {
            m_Write(message);
        }

        public override void WriteLine(string message)
        {
            m_WriteLine(message);
        }
    }
}
