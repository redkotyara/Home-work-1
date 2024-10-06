using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using HomeTask.BusinessLogic.Models;

namespace HomeTask.BusinessLogic.Services.Interfaces
{
    public interface IEmployeeService
    {
        Task<PaginationResult<EmployeeModel>> GetEmployeesAsync(
            GetEmployeesFilter filter,
            int pageNumber,
            int pageSize,
            CancellationToken cancellationToken);
        
        Task AddEmployeeAsync(CreateOrUpdateEmployeeModel newEmployee, CancellationToken cancellationToken);

        Task EditEmployeeAsync(CreateOrUpdateEmployeeModel employee, CancellationToken cancellationToken);
        
        Task DeleteEmployeeAsync(int employeeId, CancellationToken cancellationToken);
        
        Task<EmployeeModel> GetEmployeeAsync(int employeeId, CancellationToken cancellationToken);
    }
}