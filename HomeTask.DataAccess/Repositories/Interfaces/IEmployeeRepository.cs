using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using HomeTask.DataAccess.Entities;
using HomeTask.DataAccess.Models;

namespace HomeTask.DataAccess.Repositories.Interfaces
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<EmployeeEntity>> GetEmployeesAsync(
            EmployeeFilter filter,
            int pageNumber,
            int pageSize,
            CancellationToken cancellationToken);

        Task<int> GetEmployeesCountAsync(EmployeeFilter filter, CancellationToken cancellationToken);
        
        Task<EmployeeEntity?> GetEmployeeAsync(int id, CancellationToken cancellationToken);
        
        Task AddEmployeeAsync(EmployeeEntity employeeEntity, CancellationToken cancellationToken);
        
        Task EditEmployeeAsync(EmployeeEntity employeeEntity, CancellationToken cancellationToken);
        
        Task DeleteEmployeeAsync(int employeeId, CancellationToken cancellationToken);
    }
}