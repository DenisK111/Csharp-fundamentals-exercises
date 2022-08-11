using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SIS.HTTP.Exceptions
{
    public class InternalServerErrorException : Exception
    {
        private const string message = "The Server has encountered an error.";
        public InternalServerErrorException() : this(message)
        {

        }

        public InternalServerErrorException(string? message) : base(message)
        {
        }

        public InternalServerErrorException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected InternalServerErrorException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
