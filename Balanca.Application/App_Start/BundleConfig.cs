using System.Web;
using System.Web.Optimization;

namespace Balanca.Application
{
    public class BundleConfig
    {

        public static void RegisterBundles(BundleCollection bundles)
        {


            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                //"~/Scripts/jquery-3.1.1.min.js",
                "~/Content/plugins/jQuery/jquery-2.2.3.min.js"
                ));


            bundles.Add(new ScriptBundle("~/bundles/flot").Include(
            "~/Content/plugins/flot/jquery.flot.js",
            "~/Content/plugins/flot/jquery.flot.resize.js",
            "~/Content/plugins/flot/jquery.flot.pie.js",
            "~/Content/plugins/flot/jquery.flot.categories.min.js"
            ));

            bundles.Add(new ScriptBundle("~/bundles/templateJS").Include(
                       "~/Content/plugins/wait/wait.js",
                       "~/Content/bootstrap/js/bootstrap.js",
                       "~/Content/plugins/fastclick/fastclick.js",
                       "~/Content/dist/js/app.js",
                       "~/Content/plugins/sparkline/jquery.sparkline.js",
                       "~/Content/plugins/jvectormap/jquery-jvectormap-1.2.2.min.js",
                       "~/Content/plugins/jvectormap/jquery-jvectormap-world-mill-en.js",
                       "~/Content/plugins/slimScroll/jquery.slimscroll.js",
                       "~/Content/plugins/chartjs/Chart.js",
                       "~/Content/dist/js/demo.js"
                       ));

            bundles.Add(new ScriptBundle("~/bundles/sliderjs").Include(
                "~/Content/plugins/ionslider/ion.rangeSlider.min.js",
                "~/Content/plugins/bootstrap-slider/bootstrap-slider.js",
                "~/Scripts/respond.js"));

            bundles.Add(new ScriptBundle("~/bundles/alertajs").Include(
              "~/Content/Projeto/Layout/Alerta/alerta.js"
            ));

            bundles.Add(new StyleBundle("~/Content/slidercss").Include(
                      "~/Content/plugins/ionslider/ion.rangeSlider.skinNice.css",
                      "~/Content/plugins/ionslider/ion.rangeSlider.skinFlat.css",
                      "~/Content/plugins/bootstrap-slider/slider.css",
                      "~/Content/plugins/ionslider/ion.rangeSlider.css"
            ));

            bundles.Add(new StyleBundle("~/Content/alertacss").Include(
                      "~/Content/Projeto/Layout/Alerta/alerta.css"
            ));

            bundles.Add(new StyleBundle("~/Content/templateCSS").Include(
                   "~/Content/bootstrap/css/bootstrap.min.css",
                   "~/Content/plugins/jvectormap/jquery-jvectormap-1.2.2.css",
                   "~/Content/dist/css/AdminLTE.css",
                   "~/Content/dist/css/skins/_all-skins.css"
            ));

        }
    }
}
