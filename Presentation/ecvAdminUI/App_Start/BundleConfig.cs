using System.Web;
using System.Web.Optimization;

namespace ecvAdminUI.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                                    "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                                "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                                  "~/Scripts/bootstrap.js",
                                  "~/Content/datatables/css/datatables.bootstrap.css"
                                  ));
           
            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/ecvStyleSheet001.css",
                      "~/Content/dashboard.css",
                      "~/Content/chosen.css",
                      "~/Content/chosen.min.css",
                      "~/Content/datatables/css/datatables.bootstrap.css"
                      ));

            //------For DateTimePicker
            bundles.Add(new ScriptBundle("~/bundles/datetime").Include(
                "~/Scripts/moment*",
                "~/Scripts/bootstrap-datetimepicker*"));

            //------For Chosen script
            bundles.Add(new ScriptBundle("~/bundles/chosen").Include(
                                  "~/Scripts/chosen.jquery.js",
                                  "~/Scripts/chosen.jquery.min.js",
                                  "~/Scripts/chosen.proto.js",
                                  "~/Scripts/chosen.proto.min.js"
                                  ));

            //------For jQuery Datatable
            bundles.Add(new ScriptBundle("~/bundles/jquerydatatable").Include(
                                  "~/Scripts/datatables/jquery.datatables.js",
                                  "~/Scripts/datatables/datatables.bootstrap.js"
                                  ));

        }

    }// End of -- public class BundleConfig
}