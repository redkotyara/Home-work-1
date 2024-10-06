using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using HomeTask.BusinessLogic.Models;

namespace HomeTask.BusinessLogic.Services.Interfaces
{
    public interface IGenderService
    {
        Task<IEnumerable<GenderModel>> GetGendersAsync(CancellationToken cancellationToken);
    }
}