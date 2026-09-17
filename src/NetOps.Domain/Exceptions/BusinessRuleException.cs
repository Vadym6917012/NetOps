using System;
using System.Collections.Generic;
using System.Text;

namespace NetOps.Domain.Exceptions
{
    public sealed class BusinessRuleException : Exception
    {
        public BusinessRuleException(string message)
            : base(message)
        {
        }
    }
}
