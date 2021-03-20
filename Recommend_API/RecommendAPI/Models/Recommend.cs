using MongoDB.Bson.Serialization.Attributes;
using System;

namespace RecommendAPI.Models
{
    public class Recommend
    {
        #region Properties
        [BsonId]
        public int RecommendId { get; set; }
        public string SourceName { get; set; }
        public string Author { get; set; }
        public string title { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public string UrlToImage { get; set; }
        public DateTime PublishedAt { get; set; }
        public string UserName { get; set; }
        public int LikeCounter { get; set; } = 1;

        public bool IsRecommend { get; set; }

        public Recommend()
        {
            IsRecommend = true;
        }

        #endregion
    }
}
