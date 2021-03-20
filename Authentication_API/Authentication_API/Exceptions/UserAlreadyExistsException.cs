using System;

namespace Authentication_API.Exceptions
{
    public class UserAlreadyExistsException:ApplicationException
    {
        public UserAlreadyExistsException() : base() { }
        
        public UserAlreadyExistsException(string message) : base(message) { }

    }
}
