using Authentication_API.Models;

namespace Authentication_API.Services
{
    public interface IAuthService
    {
        #region Interface Methods
        bool LoginUser(User user);
        bool RegisterUser(User user);
        #endregion

    }
}
