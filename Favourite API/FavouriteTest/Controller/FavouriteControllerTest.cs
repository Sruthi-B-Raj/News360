using Favourite_API.Models;
using Favourite_API.Repositories;
using FavouriteTest.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace FavouriteTest.Controller
{
    public class FavControllerTest : IClassFixture<ControllerDbFixture>
    {
        ControllerDbFixture fixture;
        private readonly IFavouriteRepository repository;

        public FavControllerTest(ControllerDbFixture _fixture)
        {
            fixture = _fixture;
            repository = new FavouriteRepository(fixture.context);
        }

        [Fact, TestPriority(2)]
        public void DeleteFavoriteShouldReturnTrue()
        {
            string userId = "cyz";
            string Title = "Corona";

            var actual = repository.DeleteFavourite(userId, Title);
            Assert.True(actual);
        }
        [Fact, TestPriority(3)]
        public void GetFavoriteShouldReturnAList()
        {
            string userId = "cyk";
            var actual = repository.GetFavouriteById(userId);

            Assert.IsAssignableFrom<List<Favourite>>(actual);
            Assert.NotEmpty(actual);
        }

        [Fact, TestPriority(4)]
        public void GetFavroitesShouldReturnAll()
        {
            var actual = repository.GetFavourites();

            Assert.NotNull(actual);
            Assert.IsAssignableFrom<List<Favourite>>(actual);
            Assert.NotEmpty(actual);
        }
    }
    internal class TestPriorityAttribute : Attribute
    {
        private readonly int value;
        public TestPriorityAttribute(int value)
        {
            this.value = value;
        }
    }
}
