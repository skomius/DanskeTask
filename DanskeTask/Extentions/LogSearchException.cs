using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DanskeTask
{
    using System;

    public class LogSearchException : Exception
    {
        public LogSearchException()
        {
        }

        public LogSearchException(string message)
            : base(message)
        {
        }

        public LogSearchException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
