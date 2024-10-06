using System.Collections.Generic;
using System.Data.Entity;
using System.Threading;
using System.Threading.Tasks;
using HomeTask.DataAccess.DatabaseContexts;
using HomeTask.DataAccess.Entities;
using HomeTask.DataAccess.Repositories.Interfaces;

namespace HomeTask.DataAccess.Repositories
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly DatabaseContext _databaseContexts;

        public DepartmentRepository(DatabaseContext databaseContexts)
        {
            _databaseContexts = databaseContexts;
        }

        public async Task<IEnumerable<DepartmentEntity>> GetAllDepartmentsAsync(CancellationToken cancellationToken)
        {
            return await _databaseContexts.Departments
                .AsNoTracking()
                .ToArrayAsync(cancellationToken);
        }
    }
}