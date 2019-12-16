using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Framework.Exceptions
{
    public class IdentifierException : Exception
    {
        public IdentifierException() : base()
        {

        }

        public IdentifierException(string message) : base(message)
        {

        }
    }
}
