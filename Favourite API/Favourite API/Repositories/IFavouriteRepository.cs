using Favourite_API.Models;

using System.Collections.Generic;

namespace Favourite_API.Repositories
{
    public interface IFavouriteRepository
    {
        #region Interface methods
        List<Favourite> GetFavourites();
        List<Favourite> GetFavouriteById(string userName);
        Favourite AddFavourite(Favourite favourite);
        bool DeleteFavourite(string id, string title);
        public List<Favourite> GetFavouriteByTitle(Favourite favourite);


        bool IsFavouriteExistWithId(string id);
        #endregion
    }
}
