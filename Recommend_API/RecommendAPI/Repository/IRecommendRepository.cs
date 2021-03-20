using RecommendAPI.Models;
using System.Collections.Generic;

namespace RecommendAPI.Repository
{
    public interface IRecommendRepository
    {
        #region Interface Model
        Recommend AddRecommendations(Recommend recommend);
        bool DeleteRecommend(string id, string title);
        public List<Recommend> GetRecommendsByTitle(Recommend rem);
        List<Recommend> GetRecommendsTitle(string title);

        List<Recommend> GetRecommends();
        public bool GetTitleNameIfExists(Recommend recommend);
        public bool UpdateRecommendation(Recommend recommend);



        public bool IsRecommendExistWithId(string id);
        public bool IsRecommendExist(Recommend recommend);
        
        #endregion
    }
}
