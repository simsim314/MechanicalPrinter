﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace STLManager
{
    public class AddEpsilonException : Exception
    {
        public AddEpsilonException(string ex) : base(ex) {}
    }
}
