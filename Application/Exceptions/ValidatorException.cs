using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Rgm.Application.Exceptions
{
    public class ValidatorException : Exception
    {
        public List<string> ListErrors;

        public ValidatorException()
        {
            ListErrors = new List<string>();
        }
        public ValidatorException(List<string> listerrors) : base("Erro de Validação")
        {
            ListErrors = listerrors;
        }
        public ValidatorException(string message) : base(message)
        {
        }
        public ValidatorException(string message, Exception innerException) : base(message, innerException)
        {
        }
        protected ValidatorException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
