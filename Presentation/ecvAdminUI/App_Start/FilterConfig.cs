using System.Web.Mvc;

namespace ecvAdminUI.App_Start
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            //filters.Add(new AuthorizeAttribute());
            //filters.Add(new RequireHttpsAttribute());
        }
    }
}