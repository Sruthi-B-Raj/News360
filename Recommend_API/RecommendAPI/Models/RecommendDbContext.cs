using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace RecommendAPI.Models
{
    public class RecommendDbContext : DbContext
    {
        #region MongoDB Connection
        MongoClient client;
        IMongoDatabase database;
        public RecommendDbContext(IConfiguration config)
        {
            client = new MongoClient(config.GetSection("MongoDB:server").Value);
            database = client.GetDatabase(config.GetSection("MongoDB:db").Value);
        }
        public IMongoCollection<Recommend> Recommendation => database.GetCollection<Recommend>("Recommendation");
        #endregion
    }
}
