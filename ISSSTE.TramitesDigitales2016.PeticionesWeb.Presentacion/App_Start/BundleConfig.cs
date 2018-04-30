using System.Web;
using System.Web.Optimization;
using ISSSTE.Tramites2015.Common.Web;

namespace ISSSTE.TramitesDigitales2016.PeticionesWeb.Presentacion
{
    public class BundleConfig
    {
        // Para obtener más información sobre Bundles, visite http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            //bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
            //            "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jquery")
               .IncludeDirectory("~/Scripts/Libraries/jQuery", "*.js", false)
             );
            bundles.Add(new ScriptBundle("~/bundles/JQueryValidaciones")
            .Include("~/Scripts/jQueryTablero/jQueryReports.js",
            "~/Scripts/jquery-1.10.2.js",
            "~/Scripts/jquery-1.10.2.min.js",
            "~/Scripts/jquery-ui.js",
            "~/Scripts/jquery.validate.js",
            "~/Scripts/jquery.validate.min.js",
            "~/Scripts/jquery.validate.unobtrusive.min.js",
            "~/Scripts/Modulos/JsMenuDatlleSR.js"
            ));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/angularjs").Include(
                    "~/Scripts/angular.min.js",
                    "~/Scripts/angular-messages.min.js",
                    "~/Scripts/angular-busy.min.js"
            ));

            bundles.Add(new StyleBundle("~/request-form/css").Include(
                        "~/Content/request-form.styles.css",
                        "~/Content/angular-busy.min.css"
            ));
            bundles.Add(new ScriptBundle("~/bundles/history-form").Include(
                        "~/Scripts/history-form/history-form.module.js"));

            bundles.Add(new ScriptBundle("~/bundles/followup-form").Include(
                        "~/Scripts/followup-form/followup-form.module.js"));

            bundles.Add(new ScriptBundle("~/bundles/bitacora-form").Include(
              "~/Scripts/bitacora-form/bitacora-form.component.js",
              "~/Scripts/dirPagination.js",
              "~/Scripts/bitacora-form/bitacora-form.event.js"
            ));

            bundles.Add(new ScriptBundle("~/bundles/request-form").Include(
                        "~/Scripts/request-form/request-form.module.js",
                        "~/Scripts/request-form/request-form.component.js",
                        "~/Scripts/request-form/request-form.events.js"
                ));
            bundles.Add(new ScriptBundle("~/bundles/jQureyTablero")
            .Include("~/Scripts/jQueryTablero/jQueryReports.js",
            "~/Scripts/jquery-1.10.2.js",
            "~/Scripts/jquery-1.10.2.min.js",
            "~/Scripts/jquery-ui.js"
            ));
            bundles.Add(new StyleBundle("~/bundles/DatePicker")
            .Include("~/Content/jquery-ui.css",
            "~/Content/jquery-ui.structure.css",
            "~/Content/jquery-ui.structure.min.css",
            "~/Content/jquery-ui.theme.css",
            "~/Content/jquery-ui.theme.min.css",
            "~/Content/CssLayoutPeticiones/datepickerInput.css"));
            //Estilos de: Grafica base y Estancias.
            bundles.Add(new StyleBundle("~/bundles/OpenSans").
            Include("~/Content/Fonts/fontOpenSans.css"));
            
            bundles.Add(new StyleBundle("~/bundles/SansSerif").
            Include("~/Content/Fonts/fontSansSerif.css"));
            
            bundles.Add(new StyleBundle("~/bundles/generalCSS").
            Include("~/Content/Administrator/general.css"));
            
            bundles.Add(new StyleBundle("~/bundles/menuLateral").
            Include("~/Content/Administrator/menu-lateral.css"));
         // Utilice la versión de desarrollo de Modernizr para desarrollar y obtener información. De este modo, estará
         // preparado para la producción y podrá utilizar la herramienta de compilación disponible en http://modernizr.com para seleccionar solo las pruebas que necesite.
         //bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
         //            "~/Scripts/modernizr-*"));

         bundles.Add(new ScriptBundle("~/bundles/modernizr")
                .IncludeDirectory("~/Scripts/Libraries/Modernizr", "*.js", false)
            );


            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));
            bundles.Add(new StyleBundle("~/Content/LayoutPeticionesCss").Include(
                      "~/Content/CssLayoutPeticiones/Site.css",
                      "~/Content/CssLayoutPeticiones/menu-lateral.css",
                      "~/Content/CssLayoutPeticiones/menu.css"
          ));


            //Issste velaciones

            bundles.Add(new ScriptBundle("~/bundles/ramda")
                .Include(
                    "~/Scripts/Libraries/ramda/ramda.js"
                )
            );

            bundles.Add(new ScriptBundle("~/bundles/angular")
                .Include(
                    "~/Scripts/Libraries/Angular/angular.js",
                    "~/Scripts/Libraries/Angular/angular-route.js",
                    "~/Scripts/Libraries/Angular/angular-sanitize.js",
                    "~/Scripts/Libraries/Angular/angular-local-storage.js",
                    "~/Scripts/Libraries/Angular/angular-local-storage.js"
                )
            );

            bundles.Add(new ScriptBundle("~/bundles/angular-auto-validate")
                .Include(
                    "~/Scripts/Libraries/AngularAutoValidate/jcs-auto-validate.js"
                )
            );

            bundles.Add(new ScriptBundle("~/bundles/angular-upload")
                .Include(
                    "~/Scripts/Libraries/AngularUpload/startup.js",
                    "~/Scripts/Libraries/AngularUpload/ng-file-upload-all.js"
                )
            );

            bundles.Add(new ScriptBundle("~/bundles/bootstrap-datetimepicker")
                .Include(
                    "~/Scripts/Libraries/BootstrapDatetimePicker/moment-with-locales.js",
                    "~/Scripts/Libraries/BootstrapDatetimePicker/bootstrap-datetimepicker.js",
                    "~/Scripts/Libraries/BootstrapDatetimePicker/angular-bootstrap-datetimepicker-directive.js"
                )
            );

            bundles.Add(new ScriptBundle("~/bundles/respond")
                .IncludeDirectory("~/Scripts/Libraries/Respond", "*.js", false)
            );

            bundles.Add(new ScriptBundle("~/bundles/utils")
                .IncludeDirectory("~/Scripts/Libraries/Util", "*.js", false)
            );

            //Applications CSS and UI Scripts
            bundles.Add(new StyleBundle("~/bundles/CssLayoutPeticiones/css")
            .IncludeWithCssRewriteTransform(
            "~/Content/CssLayoutPeticiones/fontModal.css"
            ));
            bundles.Add(new StyleBundle("~/bundles/entitle/css")
                .IncludeWithCssRewriteTransform(
                "~/Content/Entitle/breadcrum.css",
                "~/Content/Entitle/bootstrap-datetimepicker.css",
                "~/Content/Entitle/abl.css",
                "~/Content/Entitle/custom.css",
                "~/Content/Entitle/site.css",
                "~/Content/Entitle/gobmxfix.css"
                )
            );

            bundles.Add(new ScriptBundle("~/bundles/entitle/javascript")
                .Include(
                    "~/Scripts/Entitle/UI/bootstrap.min.js",
                    "~/Scripts/Entitle/UI/moment-with-locales.js",
                    "~/Scripts/Entitle/UI/bootstrap-datetimepicker.js",
                    "~/Scripts/Entitle/UI/scripts.js",
                    "~/Scripts/Entitle/UI/systemAlerts.js"
                )
            );

            bundles.Add(new StyleBundle("~/bundles/administrator/css")
                .IncludeWithCssRewriteTransform(
                    "~/Content/Administrator/bootstrap.css",
                    "~/Content/Administrator/font-awesome.min.css",
                    "~/Content/Administrator/general.css",
                    "~/Content/Administrator/menu.css",
                    "~/Content/Administrator/menu-lateral.css",
                    "~/Content/Administrator/buscador.css",
                    "~/Content/Administrator/site.css"
                )
            );

            bundles.Add(new ScriptBundle("~/bundles/administrator/javascript")
                .Include(
                    "~/Scripts/Administrator/UI/bootstrap.js",
                    "~/Scripts/Administrator/UI/scripts.js",
                    "~/Scripts/Administrator/UI/agregar-tabla.js"
                )
            );

            //Application Angular Modules
            bundles.Add(new ScriptBundle("~/bundles/entitle/app")
                .Include(
                    "~/Scripts/Entitle/App/app.js",
                    "~/Scripts/Entitle/App/config.js",
                    "~/Scripts/Entitle/App/config.exceptionHandler.js",
                    "~/Scripts/Entitle/App/config.routes.js"
                )
                .IncludeDirectory("~/Scripts/Entitle/App/resources", "*.js", true)
                .IncludeDirectory("~/Scripts/Entitle/App/common", "*.js", true)
                .IncludeDirectory("~/Scripts/Entitle/App/error", "*.js", true)
                .IncludeDirectory("~/Scripts/Entitle/App/home", "*.js", true)
                .IncludeDirectory("~/Scripts/Entitle/App/requests", "*.js", true)
            );

            bundles.Add(new ScriptBundle("~/bundles/administrator/app")
                .IncludeDirectory("~/Scripts/Administrator/App/resources", "*.js", true)
                .Include(
                    "~/Scripts/Administrator/App/app.js",
                    "~/Scripts/Administrator/App/config.js",
                    "~/Scripts/Administrator/App/config.exceptionHandler.js",
                    "~/Scripts/Administrator/App/config.routes.js"
                )
                .IncludeDirectory("~/Scripts/Administrator/App/common", "*.js", true)
                .IncludeDirectory("~/Scripts/Administrator/App/error", "*.js", true)
                .IncludeDirectory("~/Scripts/Administrator/App/fileDisplay", "*.js", true)
                .IncludeDirectory("~/Scripts/Administrator/App/fileUpload", "*.js", true)
                .IncludeDirectory("~/Scripts/Administrator/App/search", "*.js", true)
                .IncludeDirectory("~/Scripts/Administrator/App/requests", "*.js", true)
                .IncludeDirectory("~/Scripts/Administrator/App/catalogs", "*.js", true)
                .IncludeDirectory("~/Scripts/Administrator/App/login", "*.js", true)
                .IncludeDirectory("~/Scripts/Administrator/App/indicators", "*.js", true)
                .IncludeDirectory("~/Scripts/Administrator/App/support", "*.js", true)
            );

            bundles.Add(new ScriptBundle("~/bundles/administrator/app/login")
               .IncludeDirectory("~/Scripts/Administrator/App/resources", "*.js", true)
               .Include(
                   "~/Scripts/Administrator/App/app.js",
                   "~/Scripts/Administrator/App/config.js",
                   "~/Scripts/Administrator/App/config.exceptionHandler.js"
               )
               .IncludeDirectory("~/Scripts/Administrator/App/common", "*.js", true)
               .IncludeDirectory("~/Scripts/Administrator/App/login", "*.js", true)
           );

            //Se deshabilita el bundle, pues cuando se minifica se tiene un problema con las rutas de las fuentes de bootstrap
            BundleTable.EnableOptimizations = false;

            //#if DEBUG
            //            BundleTable.EnableOptimizations = false;
            //#else
            //            BundleTable.EnableOptimizations = true;
            //#endif

        }
    }
}
