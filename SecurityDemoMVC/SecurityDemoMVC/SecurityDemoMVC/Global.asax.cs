using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;

namespace SecurityDemoMVC
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected void Application_AuthenticateRequest(Object sender, EventArgs e)
        {
            // Check if the user is authenticated via Forms Authentication
            if (HttpContext.Current.User != null && HttpContext.Current.User.Identity.IsAuthenticated)
            {
                // Check if the identity is a FormsIdentity (meaning it came from our cookie)
                if (HttpContext.Current.User.Identity is FormsIdentity)
                {
                    FormsIdentity id = (FormsIdentity)HttpContext.Current.User.Identity;
                    FormsAuthenticationTicket ticket = id.Ticket;

                    // Get the roles string from the UserData (which is where we put the roles)
                    string userData = ticket.UserData;
                    string[] roles = userData.Split(',');

                    // Create a new GenericPrincipal (User object) with the roles
                    HttpContext.Current.User = new GenericPrincipal(id, roles);
                }
            }
        }
    }
}
