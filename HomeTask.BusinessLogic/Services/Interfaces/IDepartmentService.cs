using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using HomeTask.BusinessLogic.Models;

namespace HomeTask.BusinessLogic.Services.Interfaces
{
    public interface IDepartmentService
    {
        Task<IEnumerable<DepartmentModel>> GetAllDepartmentsAsync(CancellationToken cancellationToken);
    }
}