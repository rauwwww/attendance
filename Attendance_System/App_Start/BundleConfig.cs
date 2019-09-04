using System.Web;
using System.Web.Optimization;

namespace Attendance_System
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/moment.min.js",
                        "~/Scripts/jquery-3.2.1.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/adminlte").Include(
                        "~/Scripts/AdminLTe/adminlte.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/adminltedashboard").Include(
                        "~/Scripts/AdminLTe/dashboard2.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.min.js",
                      "~/Scripts/popper.min.js",
                      "~/Scripts/bootstrap-datetimepicker.min.js",
                      "~/Scripts/respond.min.js"));



            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/Styling/bootstrap.min.css",
                      "~/Content/bootstrap-datetimepicker.min.css",
                      "~/Content/Styling/AdminLTE/AdminLTE.min.css",
                      "~/Content/Styling/AdminLTE/skins/_all-skins.min.css",
                      "~/Content/Styling/custom.min.css",
                      "~/Content/Styling/magic.min.css",
                      "~/Src/scss/custom.min.css"));
        }
    }
}
