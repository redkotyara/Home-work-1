using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using HomeTask.BusinessLogic.Models;
using HomeTask.BusinessLogic.Services.Interfaces;
using HomeTask.DataAccess.Repositories.Interfaces;

namespace HomeTask.BusinessLogic.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IMapper _mapper;

        public DepartmentService(
            IDepartmentRepository departmentRepository, 
            IMapper mapper)
        {
            _departmentRepository = departmentRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<DepartmentModel>> GetAllDepartmentsAsync(CancellationToken cancellationToken)
        {
            var departments = await _departmentRepository.GetAllDepartmentsAsync(cancellationToken);
            
            var result = _mapper.Map<IEnumerable<DepartmentModel>>(departments);

            return result;
        }
    }
}