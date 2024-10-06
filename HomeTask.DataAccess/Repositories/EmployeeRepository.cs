using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using HomeTask.DataAccess.DatabaseContexts;
using HomeTask.DataAccess.Entities;
using HomeTask.DataAccess.Models;
using HomeTask.DataAccess.Repositories.Interfaces;

namespace HomeTask.DataAccess.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly DatabaseContext _databaseContext;

        public EmployeeRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public async Task<IEnumerable<EmployeeEntity>> GetEmployeesAsync(
            EmployeeFilter filter,
            int pageNumber,
            int pageSize,
            CancellationToken cancellationToken)
        {
            var query = GetEmployeesQuery(filter)
                .OrderBy(e => e.EmployeeId)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize);
            
            return await query.ToArrayAsync(cancellationToken);
        }
        
        public async Task<int> GetEmployeesCountAsync(EmployeeFilter filter, CancellationToken cancellationToken)
        {
            var query = GetEmployeesQuery(filter);
            
            return await query.CountAsync(cancellationToken);
        }

        private IQueryable<EmployeeEntity> GetEmployeesQuery(EmployeeFilter filter)
        {
            var query = _databaseContext.Employees
                .AsNoTracking()
                .Where(x => !x.IsDeleted)
                .Include(e => e.Department)
                .Include(e => e.Experiences)
                .Include(e => e.Experiences.Select(ex => ex.ProgramingLanguage))
                .Include(e => e.Gender);

            if (filter.DepartmentId.HasValue)
            {
                query = query.Where(e => e.DepartmentId == filter.DepartmentId.Value);
            }

            if (!string.IsNullOrWhiteSpace(filter.FirstName))
            {
                query = query.Where(e => e.FirstName.StartsWith(filter.FirstName!));
            }
            
            if (!string.IsNullOrWhiteSpace(filter.LastMame))
            {
                query = query.Where(e => e.LastName.StartsWith(filter.LastMame!));
            }

            if (filter.GenderId.HasValue)
            {
                query = query.Where(e => e.GenderId == filter.GenderId.Value);
            }

            if (filter.Age.HasValue)
            {
                query = query.Where(e => e.Age == filter.Age.Value);
            }

            if (filter.ProgramLanguageId.HasValue)
            {
                query = query.Where(e => e.Experiences.Select(x => x.ProgramingLanguageId).Contains(filter.ProgramLanguageId.Value));
            }

            return query;
        }

        public async Task<EmployeeEntity?> GetEmployeeAsync(int id, CancellationToken cancellationToken)
        {
            return await _databaseContext.Employees
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.EmployeeId == id, cancellationToken);
        }

        public async Task AddEmployeeAsync(EmployeeEntity employeeEntity, CancellationToken cancellationToken)
        {
            _databaseContext.Employees.Add(employeeEntity);
            await _databaseContext.SaveChangesAsync(cancellationToken);
        }

        public async Task EditEmployeeAsync(EmployeeEntity employeeEntity, CancellationToken cancellationToken)
        {
            using var transaction = _databaseContext.Database.BeginTransaction();
            
            try
            {
                var employeeId = employeeEntity.EmployeeId;
                
                var oldExperiences = await _databaseContext.EmployeeExperiences
                    .Where(x => x.EmployeeId == employeeId)
                    .ToArrayAsync(cancellationToken);

                _databaseContext.EmployeeExperiences.RemoveRange(oldExperiences);
                await _databaseContext.SaveChangesAsync(cancellationToken);
                
                var newExperiences = employeeEntity.Experiences;
                _databaseContext.EmployeeExperiences.AddRange(newExperiences);
                await _databaseContext.SaveChangesAsync(cancellationToken);
                
                _databaseContext.Entry(employeeEntity).State = EntityState.Modified;
                await _databaseContext.SaveChangesAsync(cancellationToken);
                transaction.Commit();
            }
            catch (Exception e)
            {
                transaction.Rollback();
                throw;
            }
        }

        public async Task DeleteEmployeeAsync(int employeeId, CancellationToken cancellationToken)
        {
            var entity = await _databaseContext.Employees.FirstOrDefaultAsync(e => e.EmployeeId == employeeId, cancellationToken);

            if (entity is null)
            {
                return;
            }
            
            entity.IsDeleted = true;
            _databaseContext.Entry(entity).State = EntityState.Modified;
            await _databaseContext.SaveChangesAsync(cancellationToken);
        }

        public async Task<EmployeeEntity?> GetEmployeeByIdAsync(int employeeId, CancellationToken cancellationToken)
        {
            return await _databaseContext.Employees
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.EmployeeId == employeeId, cancellationToken);
        }
    }
}