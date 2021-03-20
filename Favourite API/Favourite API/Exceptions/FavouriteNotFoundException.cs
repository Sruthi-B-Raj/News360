using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Favourite_API.Exceptions
{
    public class FavouriteNotFoundException:ApplicationException
    {
        public FavouriteNotFoundException() { }
        public FavouriteNotFoundException(string message) : base(message)
        {

        }
    }
}
