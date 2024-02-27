using System.Web;
using System.Web.Optimization;

namespace symptomSage
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new Bundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));
            bundles.Add(new StyleBundle("~/Content/templateCSS").Include(
                "~/Content/templateCss/bootstrap.min.css",
                "~/Content/templateCss/style.css",
                "~/Content/templateCss/style.css.map"));
            bundles.Add(new ScriptBundle("~/bundles/templateScripts").Include(
                "~/Scripts/templateScripts/app.js",
                "~/Scripts/templateScripts/bootstrap.bundle.min.js",
                "~/Scripts/templateScripts/counter.init.js",
                "~/Scripts/templateScripts/jquery.easing.min.js",
                "~/Scripts/templateScripts/jquery.min.js",
                "~/Scripts/templateScripts/scrollspy.min.js"));
        }
    }
}
