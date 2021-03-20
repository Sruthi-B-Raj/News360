using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Favourite_API.Exceptions
{
    public class FavouriteAlreadyExistsException:ApplicationException
    {
        public FavouriteAlreadyExistsException() { }
        public FavouriteAlreadyExistsException(string message):base(message)
        {

        }
    }
}
