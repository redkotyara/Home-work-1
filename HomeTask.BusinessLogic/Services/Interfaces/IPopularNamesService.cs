using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace HomeTask.BusinessLogic.Services.Interfaces
{
    public interface IPopularNamesService
    {
        Task<IEnumerable<string>> GetPopularNamesAsync(CancellationToken cancellationToken);
    }
}