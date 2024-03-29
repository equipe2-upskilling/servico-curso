﻿using System.Web.Optimization;

namespace ServiceCourse.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/sb-admin-2").Include(
            "~/Scripts/sb-admin-2-*"));

            bundles.Add(new ScriptBundle("~/course").Include(
                        "~/js/course/delete.js"));

            bundles.Add(new ScriptBundle("~/lesson").Include(
                        "~/js/lesson/delete.js",
                         "~/js/lesson/edit.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new Bundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css",
                      "~/Content/sb-admin-2.min.css",
                      "~/Content/sb-admin-2.css"));
        }
    }
}
