using RecommendAPI.Models;
using System.Collections.Generic;

namespace RecommendAPI.Services
{
    public interface IRecommendService
    {
        #region Interface Model
        public Recommend AddRecommends(Recommend recommend);
        List<Recommend> GetRecommends();
        List<Recommend> GetRecommendsTitle(string title);
        bool DeleteRecommend(string id, string title);
        #endregion
    }
}
