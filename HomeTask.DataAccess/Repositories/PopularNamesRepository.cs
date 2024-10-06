using System.Collections.Generic;
using System.Data.Entity;
using System.Threading;
using System.Threading.Tasks;
using HomeTask.DataAccess.DatabaseContexts;
using HomeTask.DataAccess.Entities;
using HomeTask.DataAccess.Repositories.Interfaces;

namespace HomeTask.DataAccess.Repositories
{
    public class PopularNamesRepository : IPopularNamesRepository
    {
        private readonly DatabaseContext _databaseContext;

        public PopularNamesRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public async Task<IEnumerable<PopularFirstNameEntity>> GetPopularFirstNamesAsync(CancellationToken cancellationToken)
        {
            return await _databaseContext.PopularNames
                .AsNoTracking()
                .ToArrayAsync(cancellationToken);
        }
    }
}