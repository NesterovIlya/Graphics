using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixLib.exception
{
    [Serializable()]
    class DimentionMismatchException : MatrixException
    {
        public DimentionMismatchException() : base() { }
        public DimentionMismatchException(string message) : base(message) { }
        public DimentionMismatchException(string message,System.Exception inner) : base(message,inner) { }
        protected DimentionMismatchException(System.Runtime.Serialization.SerializationInfo info, 
            System.Runtime.Serialization.StreamingContext context) { }
    }
}
