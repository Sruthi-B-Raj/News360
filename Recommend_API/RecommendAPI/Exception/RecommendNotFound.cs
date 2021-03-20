using System;

namespace RecommendAPI.Exception
{
    public class RecommendNotFound : ApplicationException
    {
        public RecommendNotFound()
        {
        }
        public RecommendNotFound(string message) : base(message)
        {
        }
    }
}
