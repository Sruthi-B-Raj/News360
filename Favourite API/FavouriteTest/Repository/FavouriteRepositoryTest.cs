using Favourite_API.Models;
using Favourite_API.Repositories;
using FavouriteTest.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Test;
using Xunit;

namespace FavouriteTest.Repository
{
    public class FavouriteRepositoryTest : IClassFixture<FavouriteDbFixture>
    {
        FavouriteDbFixture fixture;
        private readonly IFavouriteRepository repository;

        public FavouriteRepositoryTest(FavouriteDbFixture _fixture)
        {
            this.fixture = _fixture;
            repository = new FavouriteRepository(fixture.context);
        }

        [Fact, TestPriority(1)]
        public void CreateFavouriteShouldReturnRecommend()
        {
            Favourite favourite = new Favourite { UserName = "cyk", SourceName = "Karanss", title = "News" };
            var actual = repository.AddFavourite(favourite);
            Assert.IsAssignableFrom<Favourite>(actual);
            Assert.Equal(2, actual.FavouriteId);
        }
        [Fact, TestPriority(2)]
        public void DeleteFavouriteShouldReturnTrue()
        {
            string Id = "cyk";
            string Title = "Covid";

            var actual = repository.DeleteFavourite(Id, Title);
            Assert.True(actual);
        }
        [Fact, TestPriority(3)]
        public void GetAllFavouritesShouldReturnAList()
        {
            var actual = repository.GetFavourites();

            Assert.IsAssignableFrom<List<Favourite>>(actual);
            Assert.NotEmpty(actual);
        }

    }
}
