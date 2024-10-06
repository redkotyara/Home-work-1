using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using HomeTask.BusinessLogic.Models;
using HomeTask.BusinessLogic.Services.Interfaces;
using HomeTask.DataAccess.Repositories.Interfaces;

namespace HomeTask.BusinessLogic.Services
{
    public class ProgramingLanguageService : IProgramingLanguageService
    {
        private readonly IProgramingLanguageRepository _programingLanguageRepository;
        private readonly IMapper _mapper;

        public ProgramingLanguageService(IProgramingLanguageRepository programingLanguageRepository, IMapper mapper)
        {
            _programingLanguageRepository = programingLanguageRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProgramingLanguageModel>> GetProgramingLanguagesAsync(CancellationToken cancellationToken)
        {
            var programingLanguages = await _programingLanguageRepository.GetProgramingLanguagesAsync(cancellationToken);
            
            var result = _mapper.Map<IEnumerable<ProgramingLanguageModel>>(programingLanguages);

            return result;
        }
    }
}