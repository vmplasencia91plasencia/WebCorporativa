using System.Web;
using System.Web.Optimization;

namespace WebCujae
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Content/Home/js/jquery-1.11.1.min.js",
                         "~/Content/Home/js/jquery.singlePageNav.min.js",
                         "~/Content/Home/js/jquery.fancybox.pack.js",
                          "~/Content/Home/js/jquery.easing.min.js",
                           "~/Content/Home/js/jquery.slitslider.js",
                           "~/Content/Home/js/jquery.ba-cond.min.js"
                        ));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                        "~/Content/Home/js/bootstrap.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/owl").Include(
                         "~/Content/Home/js/owl.carousel.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/wow").Include(
                         "~/Content/Home/js/wow.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/main").Include(
                        "~/Content/Home/js/main.js"));

            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                      "~/Content/Home/js/modernizr-2.6.2.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                      "~/Content/Home/js/modernizr-2.6.2.min.js"));

            bundles.Add(new StyleBundle("~/Content/Home/css").Include(
                      "~/Content/Home/css/font-awesome.min.css",
                       "~/Content/Home/css/jquery.fancybox.css",
                       "~/Content/Home/css/bootstrap.css",
                       "~/Content/Home/css/owl.carousel.css",
                       "~/Content/Home/css/slit-slider.css",
                        "~/Content/Home/css/animate.css",
                        "~/Content/Home/css/main.css",
                        "~/Content/Home/css/noticias.css",
                      "~/Content/Home/css/picture.css"));
        }
    }
}
