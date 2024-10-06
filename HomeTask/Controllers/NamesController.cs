using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Mvc;
using HomeTask.BusinessLogic.Services.Interfaces;

namespace HomeTask.Controllers
{
    public class NamesController : Controller 
    {
        private readonly IPopularNamesService _popularNamesService;

        public NamesController(IPopularNamesService popularNamesService)
        {
            _popularNamesService = popularNamesService;
        }
        
        [HttpGet]
        public async Task<ActionResult> PopularNames(CancellationToken cancellationToken)
        {
            var names = await _popularNamesService.GetPopularNamesAsync(cancellationToken);
            return Json(names.Select(x => new { Name = x }), JsonRequestBehavior.AllowGet);
        }
    }
}