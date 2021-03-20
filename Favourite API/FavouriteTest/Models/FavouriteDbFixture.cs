using Favourite_API.Models;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace FavouriteTest.Models
{
    public class FavouriteDbFixture : IDisposable
    {
        public FavouriteDBContext context;
        private IConfigurationRoot configuration;
        public FavouriteDbFixture()
        {
            var builder = new ConfigurationBuilder().AddJsonFile("appsettings.json");
            configuration = builder.Build();
            context = new FavouriteDBContext(configuration);
            context.Favourites.DeleteMany(Builders<Favourite>.Filter.Empty);
            context.Favourites.InsertMany(new List<Favourite>
            {
                new Favourite{FavouriteId=1,UserName="cyk", SourceName="News1",Author="Xyz",title="Covid",PublishedAt=DateTime.Now}

            });
        }
        public void Dispose()
        {
            context = null;
        }
    }

}
