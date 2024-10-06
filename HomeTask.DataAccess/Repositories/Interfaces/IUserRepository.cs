using System.Threading;
using System.Threading.Tasks;
using HomeTask.DataAccess.Entities;

namespace HomeTask.DataAccess.Repositories.Interfaces
{
    public interface IUserRepository
    {
        UserEntity? GetUser(string username);

        Task<UserEntity?> GetUserAsync(string username, CancellationToken cancellationToken);
        
        Task AddUserAsync(UserEntity user, CancellationToken cancellationToken);
        
        void UpdateUser(UserEntity user);
    }
}