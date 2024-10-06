using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using HomeTask.DataAccess.Entities;

namespace HomeTask.DataAccess.Repositories.Interfaces
{
    public interface IDepartmentRepository
    {
        Task<IEnumerable<DepartmentEntity>> GetAllDepartmentsAsync(CancellationToken cancellationToken);
    }
}