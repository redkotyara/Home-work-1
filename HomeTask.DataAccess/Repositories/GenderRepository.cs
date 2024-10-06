using System.Collections.Generic;
using System.Data.Entity;
using System.Threading;
using System.Threading.Tasks;
using HomeTask.DataAccess.DatabaseContexts;
using HomeTask.DataAccess.Entities;
using HomeTask.DataAccess.Repositories.Interfaces;

namespace HomeTask.DataAccess.Repositories
{
    public class GenderRepository : IGenderRepository
    {
        readonly DatabaseContext _context;

        public GenderRepository(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<GenderEntity>> GetGendersAsync(CancellationToken cancellationToken)
        {
            return await _context.Genders
                .AsNoTracking()
                .ToArrayAsync(cancellationToken);
        }
    }
}