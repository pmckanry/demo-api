using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoApi.Exceptions
{
    public class DemoException : Exception
    {
        public DemoException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
