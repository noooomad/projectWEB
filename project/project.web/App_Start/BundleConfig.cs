using System.Web;
using System.Web.Optimization;

namespace project.web
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/bundles/bootstrap/css").Include(
                      "~/Content/bootstrap.min.css", new CssRewriteUrlTransform()));

            bundles.Add(new StyleBundle("~/bundles/jquery/css").Include(
                      "~/Content/jquery-ui.css", new CssRewriteUrlTransform()));

            bundles.Add(new StyleBundle("~/bundles/style/css").Include(
                    "~/Vendor/style.css", new CssRewriteUrlTransform()));

            bundles.Add(new StyleBundle("~/bundles/style_1/css").Include(
                    "~/Vendor/style_1.css", new CssRewriteUrlTransform()));

            bundles.Add(new Bundle("~/bundles/bootstrap/js").
                Include("~/Scripts/bootstrap.min.js"));

            bundles.Add(new Bundle("~/bundles/jquery/js").
                Include("~/Scripts/jquery-3.6.3.min.js"));

            bundles.Add(new Bundle("~/bundles/jquery-ui/js").
          Include("~/Scripts/jquery-ui.js"));

        }
    }
}
