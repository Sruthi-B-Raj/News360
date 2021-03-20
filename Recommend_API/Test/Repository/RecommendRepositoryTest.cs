using RecommendAPI.Models;
using RecommendAPI.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using Test;
using Xunit;

namespace TestCase.Repository
{
    [TestCaseOrderer("Test.PriorityOrderer", "Test")]
    public class RecommendRepositoryTest : IClassFixture<DatabaseFixture>
    {
        DatabaseFixture fixture;
        private readonly IRecommendRepository repository;

        public RecommendRepositoryTest(DatabaseFixture _fixture)
        {
            this.fixture = _fixture;
            repository = new RecommendRepository(fixture.context);
        }

        [Fact, TestPriority(1)]
        public void CreateRecommendShouldReturnRecommend()
        {
            Recommend recommends = new Recommend { UserName = "Karanss", title = "News" };
            var actual = repository.AddRecommendations(recommends);
            Assert.IsAssignableFrom<Recommend>(actual);
            Assert.Equal(3, actual.RecommendId);
        }
        [Fact, TestPriority(2)]
        public void DeleteRecommendShouldReturnTrue()
        {
            string Id = "Karanss";
            string Title = "News";

            var actual = repository.DeleteRecommend(Id, Title);
            Assert.True(actual);
        }
    }
}
