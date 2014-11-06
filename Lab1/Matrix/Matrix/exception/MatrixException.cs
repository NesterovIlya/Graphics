using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixLib.exception
{
    [Serializable()]
    public class MatrixException : Exception
    {
        public MatrixException() : base() { }
        public MatrixException(string message) : base(message) { }
        public MatrixException(string message,System.Exception inner) : base(message,inner) { }
        protected MatrixException(System.Runtime.Serialization.SerializationInfo info, 
            System.Runtime.Serialization.StreamingContext context) { }
    }
}
