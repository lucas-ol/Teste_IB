using System;
using System.Collections.Generic;
using System.Text;

namespace Teste_IB.Manage.Exceptions
{

    [Serializable]
    public class DataException : Exception
    {
        public int Code { get; }

        public DataException() { }
        public DataException(string message) : base(message) { }
        public DataException(int code, string message) : base(message) { Code = code; }
        public DataException(string message, Exception inner) : base(message, inner) { }
        protected DataException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
