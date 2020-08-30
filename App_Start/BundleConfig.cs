using System.Web;
using System.Web.Optimization;

namespace WebApplication
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                "~/bootstrap-4.4.1-dist/script/jquery-3.4.1.min.js",
                 "~/bootstrap-4.4.1-dist/script/popper.min.js"
                        /*"~/Scripts/jquery-{version}.js"*/));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                 "~/bootstrap-4.4.1-dist/js/bootstrap.min.js"
                      /*"~/Scripts/bootstrap.js"*/));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      //"~/Content/bootstrap.css",
                      //"~/Content/site.css"
                      "~/bootstrap-4.4.1-dist/css/bootstrap.min.css",
                      //"~/Content/site.css",
                      "~/Style/style.css"));
        }
    }
}
