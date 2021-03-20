using Authentication_API.Models;

namespace Authentication_API.Repository
{
    public interface IAuthRepository
    {
        #region Interface Methods
        bool CreateUser(User user);
        bool LoginUser(User user);
        bool IsUserExists(string userId);
        #endregion
    }
}
