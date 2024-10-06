using System;
using System.Net.Http.Headers;
using System.Security.Principal;
using System.Text;
using System.Web.Mvc;
using HomeTask.BusinessLogic.Services.Interfaces;

namespace HomeTask.Filters
{
    public class BasicAuthenticationAttribute : ActionFilterAttribute
    {
        public IUserService UserService { get; set; }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var request = filterContext.HttpContext.Request;
            var authHeader = request.Headers["Authorization"];

            if (authHeader is null)
            {
                return;
            }
            
            var headerValue = AuthenticationHeaderValue.Parse(authHeader);

            if (!headerValue.Scheme.Equals("Basic", StringComparison.OrdinalIgnoreCase) ||
                string.IsNullOrWhiteSpace(headerValue.Parameter))
            {
                return;
            }
            
            var credentials = Encoding.UTF8.GetString(Convert.FromBase64String(headerValue.Parameter)).Split(':');
                
            var username = credentials[0];
            var password = credentials[1];

            if (!UserService.IsUserAuthenticated(username, password))
            {
                return;
            }
                
            filterContext.HttpContext.User = new GenericPrincipal(new GenericIdentity(username), null);
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var userName = filterContext?.HttpContext?.User?.Identity?.Name;
            if (string.IsNullOrWhiteSpace(userName))
            {
                return;
            }
            
            UserService.UpdateUserLastActionDate(userName);
        }
    }
}