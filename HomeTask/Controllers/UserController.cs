using System;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Mvc;
using HomeTask.BusinessLogic.Exceptions;
using HomeTask.BusinessLogic.Models;
using HomeTask.BusinessLogic.Services.Interfaces;
using HomeTask.Filters;

namespace HomeTask.Controllers
{
    [BasicAuthentication]
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View("Register");
        }

        [HttpPost]
        public async Task<ActionResult> Add(CreateUserModel model, CancellationToken cancellationToken)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View("Register", model);
                }
                
                await _userService.AddUserAsync(model.Username, model.Password, cancellationToken);
                
                HttpContext.User = new GenericPrincipal(new GenericIdentity(model.Username), null);
            
                return RedirectToAction("GetEmployees", "Employee");
            }
            catch (UsernameIsUsedException)
            {
                ModelState.AddModelError("Username", "Username is already taken");
                return View("Register", model);
            }
        }
    }
}