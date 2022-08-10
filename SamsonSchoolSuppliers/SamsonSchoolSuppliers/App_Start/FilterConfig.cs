using System.Web;
using System.Web.Mvc;

namespace SamsonSchoolSuppliers
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
