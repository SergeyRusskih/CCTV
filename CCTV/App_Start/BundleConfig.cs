using System.Web;
using System.Web.Optimization;

namespace CCTV
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/common").Include(
                        "~/Scripts/jquery-*",
                        "~/Scripts/bootstrap*",
                        "~/Scripts/knockout-*"));


            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new StyleBundle("~/bundles/base").Include(
                        "~/Content/Css/bootstrap.css",
                        "~/Content/Css/bootstrap-theme.css",
                        "~/Content/Css/Common/Site.css"));

        }
    }
}