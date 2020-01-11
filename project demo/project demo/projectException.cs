using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace project_demo
{
    class projectException
    {
    }

    class PassLengthNotValidException : ApplicationException
    {
        public PassLengthNotValidException(string s):base(s)
        {

        }
    }
}
