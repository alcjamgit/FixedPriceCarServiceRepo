using System.Web;
using System.Web.Mvc;

namespace FixedPriceCarService.Membership.Web
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
