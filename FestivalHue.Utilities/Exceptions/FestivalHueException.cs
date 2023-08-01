using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FestivalHue.Utilities.Exceptions
{
    public class FestivalHueException : Exception
    {
        public FestivalHueException()
        {
        }

        public FestivalHueException(string message)
            : base(message)
        {
        }

        public FestivalHueException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
