using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using RecommendAPI.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestCase
{
    public class DatabaseFixture : IDisposable
    {
        public RecommendDbContext context;
        private IConfigurationRoot configuration;

        public DatabaseFixture()
        {
            var builder = new ConfigurationBuilder().AddJsonFile("appsettings.json");
            configuration = builder.Build();
            context = new RecommendDbContext(configuration);
            context.Recommendation.DeleteMany(Builders<Recommend>.Filter.Empty);
            context.Recommendation.InsertMany(new List<Recommend>
            {
                new Recommend{RecommendId=1,UserName="Karan",title="News1"},
                new Recommend{RecommendId=2,UserName="Kiran",title="News2"}

            });
            //var options = new DbContextOptionsBuilder<RecommendDbContext>().UseInMemoryDatabase("MyRecommendDb").Options;
            //context = new RecommendDbContext((Microsoft.Extensions.Configuration.IConfiguration)options);
        }
        public void Dispose()
        {
            context = null;
        }
    }
}
