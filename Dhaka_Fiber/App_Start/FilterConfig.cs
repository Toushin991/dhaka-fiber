using System.Web;
using System.Web.Mvc;

namespace Dhaka_Fiber
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
