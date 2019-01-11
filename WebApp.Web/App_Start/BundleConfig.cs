using System.Web.Optimization;

namespace WebApp.Web.App_Start
{
	public class BundleConfig
	{
		// For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
		public static void RegisterBundles(BundleCollection bundles)
		{
			bundles.Add(new ScriptBundle("~/js/jquery").Include(
					"~/Dist/js/jquery-2.1.4.min.js",
					"~/Dist/js/wow.min.js",
					"~/Dist/libs/mustache/mustache.js"
				));
			bundles.Add(new ScriptBundle("~/js/plugin").Include(
					"~/Dist/js/bootstrap.js",
					"~/Dist/js/lightbox-plus-jquery.min.js",
					"~/Dist/js/numscroller-1.0.js",
					"~/Dist/js/responsiveslides.min.js",
					"~/Dist/js/jquery.magnific-popup.js",
					"~/Dist/js/jquery.vide.min.js",
					"~/Dist/js/SmoothScroll.min.js",
					"~/Dist/js/move-top.js",
					"~/Dist/js/easing.js",
					"~/Dist/js/jquery.flexslider.js"
				));
			bundles.Add(new StyleBundle("~/css/base").Include("~/Dist/css/bootstrap.css", new CssRewriteUrlTransform())
					.Include("~/Dist/css/style.css", new CssRewriteUrlTransform())
					.Include("~/Dist/css/font-awesome.css", new CssRewriteUrlTransform())
					.Include("~/Dist/css/popuo-box.css", new CssRewriteUrlTransform())
					.Include("~/Dist/css/lightbox.css", new CssRewriteUrlTransform())
					.Include("~/Dist/css/flexslider.css", new CssRewriteUrlTransform())
				);

			BundleTable.EnableOptimizations = true;
		}
	}
}