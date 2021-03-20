using Favourite_API.Models;
using System.Collections.Generic;

namespace Favourite_API.Services
{
    public interface IFavouriteService
    {
        #region interface methods
        List<Favourite> GetFavourites();
        List<Favourite> GetFavouriteById(string userName);
        Favourite AddFavourite(Favourite favourite);
        bool DeleteFavourite(string id, string title);
    
        #endregion
    }
}
