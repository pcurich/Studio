using System.Web;
using System.Web.Optimization;

namespace Studio
{
    public class BundleConfig
    {
        // Para obtener más información acerca de Bundling, consulte http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            BundleTable.EnableOptimizations = false;

            // Utilice la versión de desarrollo de Modernizr para desarrollar y obtener información sobre los formularios. De este modo, estará
            // preparado para la producción y podrá utilizar la herramienta de creación disponible en http://modernizr.com para seleccionar solo las pruebas que necesite.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            //jQuery + CDN           
            bundles.UseCdn = true;
            bundles.Add(new ScriptBundle("~/bundles/jquery",
                                         "//ajax.aspnetcdn.com/ajax/jQuery/jquery-2.0.3.js") //CDN
                                         .Include("~/Scripts/jquery-{version}.js")); //Local


            bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
                        "~/Scripts/jquery-ui-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.unobtrusive*",
                        "~/Scripts/jquery.validate*"));

            //Directory
            bundles.Add(new ScriptBundle("~/bundles/Plugin")
                .IncludeDirectory("~/Scripts/Plugin", //Virtual Path
                                  "*.js", // Search pattern
                                  searchSubdirectories: true)); //Search subdirectories

            ////Custom scripts
            //bundles.Add(new ScriptBundle("~/bundles/app")
            //    .IncludeDirectory("~/Scripts/app", "*.js")); //Be careful!

            /* BootstrapCSS */
            bundles.Add(new StyleBundle("~/bundles/bootstrapcss").Include(
                        "~/Content/bootstrap.css",
                        "~/Content/bootstrap-theme.css",
                        "~/Content/Menu/sb-admin.css",
                        "~/Scripts/Plugin/Three/themes/default/style.css"
                        ));

            /* Site SPecific CSS */
            bundles.Add(new StyleBundle("~/bundles/css").Include(
                        "~/Content/site.css",
                        "~/Content/style.css",
                        "~/Content/style-metro.css"
                        ));
            
            /* BootstrapJS */
            bundles.Add(new ScriptBundle("~/bundles/bootstrapjs").Include(
                        "~/Scripts/bootstrap.js"
                        ));


            bundles.Add(new StyleBundle("~/Content/themes/base/css").Include(
                        "~/Content/themes/base/jquery.ui.core.css",
                        "~/Content/themes/base/jquery.ui.resizable.css",
                        "~/Content/themes/base/jquery.ui.selectable.css",
                        "~/Content/themes/base/jquery.ui.accordion.css",
                        "~/Content/themes/base/jquery.ui.autocomplete.css",
                        "~/Content/themes/base/jquery.ui.button.css",
                        "~/Content/themes/base/jquery.ui.dialog.css",
                        "~/Content/themes/base/jquery.ui.slider.css",
                        "~/Content/themes/base/jquery.ui.tabs.css",
                        "~/Content/themes/base/jquery.ui.datepicker.css",
                        "~/Content/themes/base/jquery.ui.progressbar.css",
                        "~/Content/themes/base/jquery.ui.theme.css"
                        ));
                               

            bundles.Add(new ScriptBundle("~/bundles/Mustaje").Include(
                        "~/Scripts/mustache.js"));

            bundles.Add(new ScriptBundle("~/bundles/glyphicons").Include(
                        "~/Assets/Plugins/glyphicons/css/glyphicons.css"
                        ));

            bundles.Add(new StyleBundle("~//Assets/Plugins/bootstrap-toggle-buttons").Include(
                        "~/Assets/Plugins/bootstrap-toggle-buttons/static/stylesheets/bootstrap-toggle-buttons.css"
                        ));
            bundles.Add(new ScriptBundle("~/js/bootstrap-toggle-buttons").Include(
                        "~/Assets/Plugins/bootstrap-toggle-buttons/static/js/jquery.toggle.buttons.js"
                        ));
            
            
        }
    }
}