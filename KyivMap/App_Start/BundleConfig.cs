namespace KyivMap.App_Start
{
	using System.Web.Optimization;
	public class BundleConfig
	{
		// For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
		public static void RegisterBundles(BundleCollection bundles)
		{

			bundles.Add(new ScriptBundle("~/bundles/Scripts/framework").Include(
				"~/Scripts/frameworks/jquery-2.1.1.js",
				"~/Scripts/frameworks/jquery-ui-1.10.4.js",
				"~/Scripts/frameworks/jquery.ui.widget.js",
				"~/Scripts/frameworks/jquery.unobtrusive-ajax.js",
				"~/Scripts/frameworks/jquery.validate.js",
				"~/Scripts/frameworks/jquery.validate.unobtrusive.js",
				"~/Scripts/frameworks/bootstrap.js",
				"~/Scripts/frameworks/md5.js",
				"~/Scripts/controls/jquery.numeric.js"
				));

			bundles.Add(new ScriptBundle("~/bundles/Scripts/common").Include(
				"~/Scripts/pages/common.js"
				));

			bundles.Add(new ScriptBundle("~/bundles/Scripts/svgjs").Include(
				"~/Scripts/controls/svg/svg.js",
				"~/Scripts/controls/svg/svg.absorb.js",
				"~/Scripts/controls/svg/svg.filter.js",
				"~/Scripts/controls/svg/svg.import.js"
			));

			bundles.Add(new ScriptBundle("~/bundles/Scripts/select2").Include(
				"~/Scripts/controls/select2/select2.js"
				));

			bundles.Add(new ScriptBundle("~/bundles/Scripts/fileupload").Include(
				"~/Scripts/controls/fileupload/jquery.fileupload.js",
				"~/Scripts/controls/fileupload/jquery.fileupload-jquery-ui.js",
				"~/Scripts/controls/fileupload/jquery.fileupload-process.js",
				"~/Scripts/controls/fileupload/jquery.fileupload-ui.js",
				"~/Scripts/controls/fileupload/jquery.iframe-transport.js",
				"~/Scripts/controls/fileupload/fileupload.init.js"
				));


			bundles.Add(new StyleBundle("~/bundles/Content/bootstrap").Include(
				"~/Content/bootstrap.css",
				"~/Content/bootstrap-theme.css",
				"~/Content/bootstrap.datepicker3.css"
				));

			bundles.Add(new StyleBundle("~/bundles/Content/select2").Include(
				"~/Content/select2-bootstrap.css",
				"~/Content/select2.css"
				));

			bundles.Add(new StyleBundle("~/bundles/Content/site").Include(
				"~/Content/site.css"
				));
		}
	}
}
