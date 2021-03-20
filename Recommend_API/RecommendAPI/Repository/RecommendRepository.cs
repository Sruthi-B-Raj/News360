using MongoDB.Driver;
using RecommendAPI.Models;
using System.Collections.Generic;
using System.Linq;

namespace RecommendAPI.Repository
{
    public class RecommendRepository : IRecommendRepository
    {
        private readonly RecommendDbContext dataContext;
        

        public RecommendRepository(RecommendDbContext dataContext)
        {
            this.dataContext = dataContext;
           

        }
        #region Model Implementation
        public Recommend AddRecommendations(Recommend recommend)
        {
            var recommends = this.dataContext.Recommendation.AsQueryable();
            
            if (recommends.Count() == 0)
            {
                recommend.RecommendId = 1;
                //recommend.LikeCounter = 1;
            }
            else
            {
                int max = recommends.Max(c => c.RecommendId) + 1;
                recommend.RecommendId = max;
                //int maxLikeCount = recommends.Max(c => c.LikeCounter + 1);
                //recommend.LikeCounter = maxLikeCount;
            }
            dataContext.Recommendation.InsertOne(recommend);
            return recommend;
        }

        public bool DeleteRecommend(string id, string title)
        {
            var deletedStatus = dataContext.Recommendation.DeleteOne(name => name.UserName == id);
            return deletedStatus.IsAcknowledged && deletedStatus.DeletedCount > 0;
        }

        public List<Recommend> GetRecommends()
        {
           

           
            return dataContext.Recommendation.Find(r => r.LikeCounter>3).ToList();
            
        }

        public List<Recommend> GetRecommendsByTitle(Recommend recommend)
        {
            return dataContext.Recommendation.Find(c => c.title == recommend.title && c.UserName == recommend.UserName).ToList();
        }

        public List<Recommend> GetRecommendsTitle(string title)
        {
            List<Recommend> recommend = new List<Recommend>();
            recommend = dataContext.Recommendation.Find(name => name.title == title).ToList();
            return recommend;
        }

        public bool GetTitleNameIfExists(Recommend recommend)
        {
           var recommendObj=dataContext.Recommendation.Find(r => r.title == recommend.title).ToList();
            if (recommendObj.Count>0)
            {
                return true;
            }
            else { return false; }
            
        }

        public bool IsRecommendExist(Recommend recommend)
        {

            var exist = dataContext.Recommendation.Find(recommends => recommends.title == recommend.title);
            if (exist != null)
            {
                //    recommend.LikeCounter = recommend.LikeCounter + 1;

                //    return recommend.LikeCounter;
                return true;
            }
            else
            {
                //recommendRepository.AddRecommendations(recommend);
                //return recommend.LikeCounter;
                return false;



            }
        }
        public bool IsRecommendExistWithId(string id)
        {
            //var courseExist = dataContext.Recommendation.Find(x => x.UserName == id).FirstOrDefault();
            var courseExist = dataContext.Recommendation.Find(x => x.title == id).FirstOrDefault();
            if (courseExist != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool UpdateRecommendation(Recommend recommend)
        {
            var updateRecommendation = dataContext.Recommendation.ReplaceOne(filter: c => c.title== recommend.title, replacement: recommend);

            if (updateRecommendation.IsAcknowledged == true && updateRecommendation.ModifiedCount > 0)
                return true;
            else
                return false;

        }
        #endregion
    }
}
