using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using HomeTask.BusinessLogic.Models;
using HomeTask.BusinessLogic.Services.Interfaces;
using HomeTask.DataAccess.Repositories.Interfaces;

namespace HomeTask.BusinessLogic.Services
{
    public class GenderService : IGenderService
    {
        private readonly IGenderRepository _genderRepository;
        private readonly IMapper _mapper;

        public GenderService(IGenderRepository genderRepository, IMapper mapper)
        {
            _genderRepository = genderRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GenderModel>> GetGendersAsync(CancellationToken cancellationToken)
        {
            var genders = await _genderRepository.GetGendersAsync(cancellationToken);
            
            var result = _mapper.Map<IEnumerable<GenderModel>>(genders);

            return result;
        }
    }
}