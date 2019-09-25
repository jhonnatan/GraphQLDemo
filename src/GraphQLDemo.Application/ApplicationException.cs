using System;

namespace GraphQLDemo.Application
{
    public class ApplicationException : Exception
    {
        public ApplicationException(string businessMessage)
            : base(businessMessage)
        {
        }
    }
}
