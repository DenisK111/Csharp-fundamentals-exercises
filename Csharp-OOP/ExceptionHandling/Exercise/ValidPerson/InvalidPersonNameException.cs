using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidPerson
{
    class InvalidPersonNameException : Exception
    {
        public InvalidPersonNameException(string message) : base(message)
        {
        }

        public InvalidPersonNameException()
        {

        }
    }
}
