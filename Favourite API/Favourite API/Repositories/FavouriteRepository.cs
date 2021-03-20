using Favourite_API.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace Favourite_API.Repositories
{
    public class FavouriteRepository : IFavouriteRepository
    {
        #region readonly field
        private readonly FavouriteDBContext dbContext;
        #endregion

        #region constructor
        public FavouriteRepository(FavouriteDBContext _dbContext)
        {
            dbContext = _dbContext;
        }

       
        #endregion
        #region interface implementation
        public Favourite AddFavourite(Favourite favourite)
        {
            var favourites = this.dbContext.Favourites.AsQueryable();
            if (favourites.Count() == 0)
            {
                favourite.FavouriteId = 1;
            }
            else
            {
                int max = favourites.Max(c => c.FavouriteId) + 1;
                favourite.FavouriteId = max;
            }
            dbContext.Favourites.InsertOne(favourite);
            return favourite;
        }

        public bool DeleteFavourite(string id, string title)
        {
            var articles = dbContext.Favourites.DeleteOne(user => user.UserName == id && user.title==title);
            return articles.IsAcknowledged && articles.DeletedCount > 0;
        }

        public List<Favourite> GetFavouriteById(string userName)
        {
            List<Favourite> favourite = new List<Favourite>();
            favourite = dbContext.Favourites.Find(name => name.UserName == userName).ToList();
            return favourite;
        }

        public List<Favourite> GetFavourites()
        {
            return dbContext.Favourites.Find(x => true).ToList();
       
        }

        public List<Favourite> GetFavouriteByTitle(Favourite favourite)
        {
            return dbContext.Favourites.Find(c => c.title == favourite.title && c.UserName == favourite.UserName).ToList();
        }

        public bool IsFavouriteExistWithId(string id)
        {
            var favouriteExists = dbContext.Favourites.Find(favourite => favourite.UserName == id).FirstOrDefault();
            if (favouriteExists != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion
    }
}
