using RecommendAPI.Exception;
using RecommendAPI.Models;
using RecommendAPI.Repository;
using System.Collections.Generic;
using System.Linq;

namespace RecommendAPI.Services
{
    public class RecommendService : IRecommendService
    {
        private readonly IRecommendRepository _repository;
        public RecommendService(IRecommendRepository repository)
        {
            _repository = repository;
        }
        #region Interface Implementation
        public Recommend AddRecommends(Recommend recommend)
        {

            var availability = _repository.GetRecommendsByTitle(recommend);
           
            if (availability.Count == 0)
            {
               return _repository.AddRecommendations(recommend);
            }
            else
            {
               
                throw new RecommendAlreadyExist("Recommend already  Exist");
                
            }
            

        }
        public List<Recommend> GetRecommends()
        {
            return _repository.GetRecommends();
        }
        public bool DeleteRecommend(string id, string title)
        {
            var availbility = _repository.DeleteRecommend(id, title);
            if (availbility)
            {
                _repository.DeleteRecommend(id, title);
                return true;

            }
            else
            {
                throw new RecommendNotFound("Recommend Not Found");
            }

               

        }

        public List<Recommend> GetRecommendsTitle(string title)
        {
            var availibilityStatus = _repository.IsRecommendExistWithId(title);
            if (availibilityStatus)
            {
                return _repository.GetRecommendsTitle(title);
            }
            else
            {
                throw new RecommendNotFound("Recommend Not Found");
            }
        }
        #endregion
    }
}
