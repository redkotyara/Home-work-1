using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using HomeTask.DataAccess.Entities;

namespace HomeTask.DataAccess.Repositories.Interfaces
{
    public interface IProgramingLanguageRepository
    {
        Task<IEnumerable<ProgramingLanguageEntity>> GetProgramingLanguagesAsync(CancellationToken cancellationToken);
    }
}