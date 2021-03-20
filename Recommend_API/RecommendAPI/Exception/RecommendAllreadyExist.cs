using System;

namespace RecommendAPI.Exception
{
    public class RecommendAlreadyExist : ApplicationException
    {
        public RecommendAlreadyExist()
        {

        }
        public RecommendAlreadyExist(string message) : base(message)
        {

        }
    }
}
