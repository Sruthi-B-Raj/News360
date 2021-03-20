using Favourite_API.Exceptions;
using Favourite_API.Models;
using Favourite_API.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Favourite_API.Services
{
    public class FavouriteService : IFavouriteService
    {
        private readonly IFavouriteRepository favouriteRepository;
        public FavouriteService(IFavouriteRepository _favouriteRepository)
        {
            favouriteRepository = _favouriteRepository;
        }

        #region interface implementation
        public Favourite AddFavourite(Favourite favourite)
        {
            var favouriteAvailibilityStatus = favouriteRepository.GetFavouriteByTitle(favourite);
            if (favouriteAvailibilityStatus.Count==0)
            {
                return favouriteRepository.AddFavourite(favourite);
            }
            else
            {
                throw new FavouriteAlreadyExistsException("Favorite already exists");
            }
        }

        public bool DeleteFavourite(string id, string title)
        {
            var favouriteAvailibilityStatus = favouriteRepository.IsFavouriteExistWithId(id);
            if (favouriteAvailibilityStatus)
            {
                return favouriteRepository.DeleteFavourite(id,title);
            }
            else
            {
                throw new FavouriteNotFoundException("Favorite not found");
            }
        }

        public List<Favourite> GetFavouriteById(string userName)
        {
            var favouriteAvailibilityStatus = favouriteRepository.IsFavouriteExistWithId(userName);
            if (favouriteAvailibilityStatus)
            {
                return favouriteRepository.GetFavouriteById(userName);
            }
            else
            {
                throw new FavouriteNotFoundException("Favourite not found");
            }
        }

        public List<Favourite> GetFavourites()
        {
            return favouriteRepository.GetFavourites();
        }
        #endregion
    }
}
