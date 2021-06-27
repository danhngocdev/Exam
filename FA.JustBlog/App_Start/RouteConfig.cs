using System.Web.Mvc;
using System.Web.Routing;

namespace IdentitySample
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapMvcAttributeRoutes();

            routes.MapRoute(
                "Post",
                "Post/{year}/{month}/{title}",
                new { controller = "Post", action = "Details" },
                new { year = @"\d{4}", month = @"\d{2}" },
                namespaces: new[] { "FA.JustBlog.Controllers" }
                );

            //routes.MapRoute(
            //    "TagDetail",
            //    "Tag/{tag}",
            //    new { controller = "Tag", action = "PopularTags" },
            //    namespaces: new[] { "FA.JustBlog.Controllers" }
            //    );

            //routes.MapRoute(
            //    "CategoryDetail",
            //    "Category/{name}",
            //    new { controller = "Category", action = "Category" },
            //    namespaces: new[] { "FA.JustBlog.Controllers" }
            //    );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "IdentitySample.Controllers" }

            );
        }
    }
}