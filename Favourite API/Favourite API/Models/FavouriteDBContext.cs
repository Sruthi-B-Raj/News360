using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace Favourite_API.Models
{
    public class FavouriteDBContext:DbContext
    {

        #region Mongo Client Declaration
        MongoClient client;
        IMongoDatabase database;
        #endregion
        #region constructor
        public FavouriteDBContext(IConfiguration configuration)
        {

            client = new MongoClient(configuration.GetSection("MongoDb:server").Value);

            database = client.GetDatabase(configuration.GetSection("MongoDb:db").Value);
        }
        public IMongoCollection<Favourite> Favourites => database.GetCollection<Favourite>("Favourites");
        #endregion

       
    }
}
