﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitWiseSDK.DotNet.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string message) : base(message)
        {

        }
    }
    public class UnauthorizedException : Exception
    {
        public UnauthorizedException(string message) : base(message)
        {

        }
    }
}
