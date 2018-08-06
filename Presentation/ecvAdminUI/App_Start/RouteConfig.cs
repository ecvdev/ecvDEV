using System.Web.Mvc;
using System.Web.Routing;

namespace ecvAdminUI
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //-----Below code replace URL from --/Category/List?pageIndex=2-- To--/Category/List/Page2-----
            routes.MapRoute(
                    name: null,
                    url: "{controller}/{action}/Page{pageIndex}",
                    defaults: new { Controller = "Category", action = "List" }
                );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            //routes.MapRoute(
            //        name: null,
            //        url: "{controller}/{action}/{id}",
            //        defaults: new { Controller = "Category", action = "Edit", id = UrlParameter.Optional }
            //    );

        }// End of -- public static void RegisterRoutes(RouteCollection routes)

    }// End of -- public class RouteConfig
}
