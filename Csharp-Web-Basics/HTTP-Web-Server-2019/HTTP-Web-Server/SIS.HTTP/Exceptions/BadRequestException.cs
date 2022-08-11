using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SIS.HTTP.Exceptions
{
    public class BadRequestException : Exception
    {
        private const string message = "The Request was malformed or contains unsupported elements.";
        public BadRequestException() : this(message)
        {
          
        }

        public BadRequestException(string message) : base(message)
        {
           
        }

        public BadRequestException(string message, Exception? innerException) : base(message, innerException)
        {
        }

        protected BadRequestException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        
    }
}
