using System;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Helpers;
using HomeTask.BusinessLogic.Exceptions;
using HomeTask.BusinessLogic.Services.Interfaces;
using HomeTask.DataAccess.Entities;
using HomeTask.DataAccess.Repositories.Interfaces;

namespace HomeTask.BusinessLogic.Services
{
    public class UserService : IUserService
    {
        readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public bool IsUserAuthenticated(string username, string password)
        {
            var user = _userRepository.GetUser(username);
            if (user == null)
            {
                return false;
            }
            
            return Crypto.VerifyHashedPassword(user.HashedPassword, password);
        }

        public async Task AddUserAsync(string username, string password, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUserAsync(username, cancellationToken);
            if (user != null)
            {
                throw new UsernameIsUsedException("User already exists.");
            }
            
            var passwordHash = Crypto.HashPassword(password);
            var newUser = new UserEntity
            {
                Username = username,
                HashedPassword = passwordHash,
                LastActionTime = null
            };
            
            await _userRepository.AddUserAsync(newUser, cancellationToken);
        }

        public void UpdateUserLastActionDate(string username)
        {
            var user = _userRepository.GetUser(username);
            if (user is null)
            {
                return;
            }
            
            user.LastActionTime = DateTime.UtcNow;
            _userRepository.UpdateUser(user);
        }
    }
}