using System.Web.Optimization;

public static class BundleConfig
{
    public static void RegisterBundles(BundleCollection bundles)
    {
        bundles.Add(new StyleBundle("~/bundles/animate/css")
            .Include("~/Content/css/animate.css", new CssRewriteUrlTransform()));

        bundles.Add(new StyleBundle("~/bundles/bootstrap-Date/css")
          .Include("~/Content/css/bootstrap-datetimepicker.css", new CssRewriteUrlTransform()));

        bundles.Add(new StyleBundle("~/bundles/bootstrap/css")
          .Include("~/Content/css/bootstrap.min.css", new CssRewriteUrlTransform()));

        bundles.Add(new StyleBundle("~/bundles/font-awesome/css")
          .Include("~/Content/css/font-awesome.css", new CssRewriteUrlTransform()));

        bundles.Add(new StyleBundle("~/bundles/jquery.bxslider/css")
          .Include("~/Content/css/jquery.bxslider.css", new CssRewriteUrlTransform()));

        bundles.Add(new StyleBundle("~/bundles/magnific-popup/css")
          .Include("~/Content/css/magnific-popup.css", new CssRewriteUrlTransform()));

        bundles.Add(new StyleBundle("~/bundles/media/css")
          .Include("~/Content/css/media.css", new CssRewriteUrlTransform()));

        bundles.Add(new StyleBundle("~/bundles/owl.carousel.min/css")
          .Include("~/Content/css/owl.carousel.min.css", new CssRewriteUrlTransform()));

        bundles.Add(new StyleBundle("~/bundles/style/css")
          .Include("~/Content/css/style.css", new CssRewriteUrlTransform()));


        bundles.Add(new Bundle("~/bundles/bootstrap.min/js")
            .Include("~/Content/js/bootstrap.min.js"));

        bundles.Add(new Bundle("~/bundles/bootstrap-datetimepicker/js")
            .Include("~/Content/js/bootstrap-datetimepicker.js"));

        bundles.Add(new Bundle("~/bundles/element/js")
            .Include("~/Content/js/element.js"));

        bundles.Add(new Bundle("~/bundles/imagesloaded.pkgd.min/js")
            .Include("~/Content/js/imagesloaded.pkgd.min.js"));

        bundles.Add(new Bundle("~/bundles/jquery.bxslider.min/js")
            .Include("~/Content/js/jquery.bxslider.min.js"));

        bundles.Add(new Bundle("~/bundles/jquery.isotope.min/js")
            .Include("~/Content/js/jquery.isotope.min.js"));

        bundles.Add(new Bundle("~/bundles/jquery.localscroll-1.2.7-min/js")
            .Include("~/Content/js/bootstrap-datetimepicker"));

        bundles.Add(new Bundle("~/bundles/jquery.magnific-popup/js")
            .Include("~/Content/js/jquery.magnific-popup.js"));

        bundles.Add(new Bundle("~/bundles/jquery.min/js")
            .Include("~/Content/js/jquery.min.js"));

        bundles.Add(new Bundle("~/bundles/jquery.parallax-1.1.3/js")
            .Include("~/Content/js/jquery.parallax-1.1.3.js"));

        bundles.Add(new Bundle("~/bundles/masonry.pkgd.min/js")
            .Include("~/Content/js/masonry.pkgd.min.js"));
        
        bundles.Add(new Bundle("~/bundles/modernizr/js")
            .Include("~/Content/js/modernizr.js"));

        bundles.Add(new Bundle("~/bundles/moment-with-locales/js")
            .Include("~/Content/js/moment-with-locales.js"));

        bundles.Add(new Bundle("~/bundles/owl.carousel/js")
            .Include("~/Content/js/owl.carousel.js"));

        bundles.Add(new Bundle("~/bundles/waypoints.min/js")
           .Include("~/Content/js/waypoints.min.js"));

        bundles.Add(new Bundle("~/bundles/wow.min/js")
           .Include("~/Content/js/wow.min.js"));
    }
}
