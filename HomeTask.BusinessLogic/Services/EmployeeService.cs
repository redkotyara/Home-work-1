using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using HomeTask.BusinessLogic.Models;
using HomeTask.BusinessLogic.Services.Interfaces;
using HomeTask.DataAccess.Entities;
using HomeTask.DataAccess.Models;
using HomeTask.DataAccess.Repositories.Interfaces;

namespace HomeTask.BusinessLogic.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IMapper _mapper;
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(
            IMapper mapper, 
            IEmployeeRepository employeeRepository)
        {
            _mapper = mapper;
            _employeeRepository = employeeRepository;
        }

        public async Task<PaginationResult<EmployeeModel>> GetEmployeesAsync(
            GetEmployeesFilter filter,
            int pageNumber,
            int pageSize,
            CancellationToken cancellationToken)
        {
            var mappedFilter = _mapper.Map<EmployeeFilter>(filter);
            var employees = await _employeeRepository.GetEmployeesAsync(
                mappedFilter,
                pageNumber,
                pageSize,
                cancellationToken);
            
            var totalCount = await _employeeRepository.GetEmployeesCountAsync(mappedFilter, cancellationToken);
            
            var mappedItems = _mapper.Map<IEnumerable<EmployeeModel>>(employees);

            var result = new PaginationResult<EmployeeModel>
            {
                PageNumber = pageNumber,
                Items = mappedItems,
                PageSize = pageSize,
                TotalItems = totalCount
            };
            
            return result;
        }

        public Task AddEmployeeAsync(CreateOrUpdateEmployeeModel newEmployee, CancellationToken cancellationToken)
        {
            var newEntity = _mapper.Map<EmployeeEntity>(newEmployee);
            return _employeeRepository.AddEmployeeAsync(newEntity, cancellationToken);
        }

        public Task EditEmployeeAsync(CreateOrUpdateEmployeeModel employee, CancellationToken cancellationToken)
        {
            var entityToUpdate = _mapper.Map<EmployeeEntity>(employee);
            return _employeeRepository.EditEmployeeAsync(entityToUpdate, cancellationToken);
        }

        public Task DeleteEmployeeAsync(int employeeId, CancellationToken cancellationToken)
        {
            return _employeeRepository.DeleteEmployeeAsync(employeeId, cancellationToken);
        }

        public async Task<EmployeeModel> GetEmployeeAsync(int employeeId, CancellationToken cancellationToken)
        {
            var employee = await _employeeRepository.GetEmployeeAsync(employeeId, cancellationToken);
            if (employee is null)
            {
                throw new Exception();
            }
            
            var result = _mapper.Map<EmployeeModel>(employee);
            return result;
        }
    }
}