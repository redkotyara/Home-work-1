using System.Web.Mvc;
using System.Web.Routing;

namespace HomeTask
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            
            routes.MapRoute(
                name: "PopularNames",
                url: "names/popular",
                defaults: new { controller = "Names", action = "PopularNames" }
            );
            
            routes.MapRoute(
                name: "GetEmployees",
                url: "",
                defaults: new { controller = "Employee", action = "GetEmployees" }
            );
            
            routes.MapRoute(
                name: "AddEmployee",
                url: "add",
                defaults: new { controller = "Employee", action = "Add" }
            );
            
            routes.MapRoute(
                name: "AddUser",
                url: "users/add",
                defaults: new { controller = "User", action = "Add" }
            );
            
            routes.MapRoute(
                name: "DeleteEmployee",
                url: "delete/{id}",
                defaults: new { controller = "Employee", action = "Delete" }
            );
            
            routes.MapRoute(
                name: "EditEmployee",
                url: "edit/{id}",
                defaults: new { controller = "Employee", action = "Edit" }
            );
        }
    }
}