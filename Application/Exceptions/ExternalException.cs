using System;
using System.Runtime.Serialization;

namespace Rgm.Externals.Exceptions
{
    [Serializable]
    public class ExternalException : Exception
    {
        public string erroExterno { get; set; }

        public ExternalException()
        {
        }
        public ExternalException(string message) : base(message)
        {
        }
        public ExternalException(string message, string erroExterno) : base(message)
        {
            this.erroExterno = erroExterno;
        }
        public ExternalException(string message, Exception innerException) : base(message, innerException)
        {
        }
        protected ExternalException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
