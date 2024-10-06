using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using HomeTask.BusinessLogic.Models;

namespace HomeTask.BusinessLogic.Services.Interfaces
{
    public interface IProgramingLanguageService
    {
        Task<IEnumerable<ProgramingLanguageModel>> GetProgramingLanguagesAsync(CancellationToken cancellationToken);
    }
}