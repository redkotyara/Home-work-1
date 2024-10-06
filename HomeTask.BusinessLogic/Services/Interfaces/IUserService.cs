using System.Threading;
using System.Threading.Tasks;

namespace HomeTask.BusinessLogic.Services.Interfaces
{
    public interface IUserService
    {
        bool IsUserAuthenticated(string username, string password);

        void UpdateUserLastActionDate(string username);
        
        Task AddUserAsync(string username, string password, CancellationToken cancellationToken);
    }
}