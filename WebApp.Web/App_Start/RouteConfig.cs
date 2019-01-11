﻿using System.Web.Mvc;
using System.Web.Routing;

namespace WebApp.Web
{
	public class RouteConfig
	{
		public static void RegisterRoutes(RouteCollection routes)
		{
			routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

			// BotDetect requests must not be routed
			routes.IgnoreRoute("{*botdetect}",
			  new { botdetect = @"(.*)BotDetectCaptcha\.ashx" });

			routes.MapRoute(
				name: "Default",
				url: "{controller}/{action}/{id}",
				defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
				namespaces: new string[] { "WebApp.Web.Controllers" }
			);
		}
	}
}