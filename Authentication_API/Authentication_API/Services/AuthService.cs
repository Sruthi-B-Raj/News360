using Authentication_API.Exceptions;
using Authentication_API.Models;
using Authentication_API.Repository;

namespace Authentication_API.Services
{
    public class AuthService:IAuthService
    {
        #region ReadOnly Field
        private readonly IAuthRepository authRepository;
        #endregion

        #region Constructor
        public AuthService(IAuthRepository _authRepository)
        {
            authRepository = _authRepository;
        }
        #endregion

        #region Implicit Implementation of interface methods 
        public bool LoginUser(User user)
        {
            if (user.UserId != null && user.Password != null)
            {
                bool result = authRepository.LoginUser(user);
                return result;
            }
            else
            {
                throw new UserAlreadyExistsException("Unauthorized");
            }


        }

        public bool RegisterUser(User user)
        {
            var _user = authRepository.IsUserExists(user.UserId);
            if (!_user)
            {
                var result = authRepository.CreateUser(user);
                return result;

            }
            else
            {
                throw new UserAlreadyExistsException($"This userId {user.UserId} already in use");
            }


        }
        #endregion
    }
}
