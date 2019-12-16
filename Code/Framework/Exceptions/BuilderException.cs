using System;
using System.Collections.Generic;
using System.Text;

namespace Framework.Exceptions
{
    public class BuilderException : Exception
    {
        public BuilderException() : base() {

        }

        public BuilderException(string message) : base(message)
        {

        }
    }
}
