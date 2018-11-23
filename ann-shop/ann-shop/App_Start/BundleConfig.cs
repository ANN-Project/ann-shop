using System.Web;
using System.Web.Optimization;

namespace ann_shop
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/font-awesome.min.css",
                      "~/Content/ann-shop/bootstrap-customer.css"));

            bundles.Add(new StyleBundle("~/Content/ann-shop/css").Include(
                      "~/Content/ann-shop/jquery.mThumbnailScroller.css",
                      "~/Content/ann-shop/jquery.fancybox.css",
                      "~/Content/ann-shop/style.css"));

            bundles.Add(new ScriptBundle("~/bundles/ann-shop/jquery").Include(
                        "~/Scripts/ann-shop/common/option_selection.js",
                        "~/Scripts/ann-shop/common/api.jquery.js",
                        "~/Scripts/ann-shop/common/minify-js.min.js",
                        "~/Scripts/ann-shop/common/jquery.fancybox.js",
                        "~/Scripts/ann-shop/common/jquery.mThumbnailScroller.js",
                        "~/Scripts/ann-shop/common/jquery.elevatezoom.js",
                        "~/Scripts/ann-shop/common/jgestures.min.js",
                        "~/Scripts/ann-shop/common/script.js"));

            bundles.Add(new ScriptBundle("~/bundles/ann-shop/jquery/utils").Include(
                        "~/Scripts/ann-shop/utils/string_format.js"));

        }
    }
}
