using System.Web;
using System.Web.Mvc;

namespace MvcRoutingDemo_deguzman
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
