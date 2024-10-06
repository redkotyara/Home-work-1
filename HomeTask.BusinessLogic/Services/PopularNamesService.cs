using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using HomeTask.BusinessLogic.Services.Interfaces;
using HomeTask.DataAccess.Repositories.Interfaces;

namespace HomeTask.BusinessLogic.Services
{
    public class PopularNamesService : IPopularNamesService
    {
        readonly IPopularNamesRepository _popularNamesRepository;

        public PopularNamesService(IPopularNamesRepository popularNamesRepository)
        {
            _popularNamesRepository = popularNamesRepository;
        }

        public async Task<IEnumerable<string>> GetPopularNamesAsync(CancellationToken cancellationToken)
        {
            var names = await _popularNamesRepository.GetPopularFirstNamesAsync(cancellationToken);
            var result = names.Select(x => x.Name).ToArray();
            return result;
        }
    }
}