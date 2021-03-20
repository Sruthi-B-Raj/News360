using Authentication_API.Models;
using System.Linq;

namespace Authentication_API.Repository
{
    public class AuthRepository : IAuthRepository
    {
        #region Readonly Field
        private readonly AuthDbContext authDbContext;
        #endregion

        #region Constructor
        public AuthRepository(AuthDbContext _authDbContext)
        {
            authDbContext = _authDbContext;
        }
        #endregion

        #region Implicit Implementation of interface methods
        public bool CreateUser(User user)
        {
            authDbContext.Users.Add(user);
            authDbContext.SaveChanges();
            return true;
        }

        public bool IsUserExists(string userId)
        {
            var userExists = authDbContext.Users.FirstOrDefault(user => user.UserId == userId);
            if (userExists != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool LoginUser(User user)
        {
            var _user = authDbContext.Users.FirstOrDefault(users => users.UserId == user.UserId && users.Password == user.Password);
            if (_user != null)
            {
                return true;
            }
            return false;

        }
        #endregion
    }
}
