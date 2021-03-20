using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Favourite_API.Models
{
    public class Favourite
    {
        #region properties
       [BsonId]
        public int FavouriteId { get; set; }
        public string SourceName { get; set; }
        public string Author { get; set; }
        public string title { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public string UrlToImage { get; set; }
        public DateTime PublishedAt { get; set; }
        public string UserName { get; set; }

        public bool IsFavourite { get; set; }

        public Favourite()
        {
            IsFavourite = true;
        }


        #endregion




    }
}
