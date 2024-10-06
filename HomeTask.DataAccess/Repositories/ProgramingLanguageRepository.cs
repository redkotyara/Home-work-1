using System.Collections.Generic;
using System.Data.Entity;
using System.Threading;
using System.Threading.Tasks;
using HomeTask.DataAccess.DatabaseContexts;
using HomeTask.DataAccess.Entities;
using HomeTask.DataAccess.Repositories.Interfaces;

namespace HomeTask.DataAccess.Repositories
{
    public class ProgramingLanguageRepository : IProgramingLanguageRepository
    {
        private readonly DatabaseContext _databaseContext;

        public ProgramingLanguageRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public async Task<IEnumerable<ProgramingLanguageEntity>> GetProgramingLanguagesAsync(CancellationToken cancellationToken)
        {
            return await _databaseContext.ProgramingLanguages
                .AsNoTracking()
                .ToArrayAsync(cancellationToken);
        }
    }
}