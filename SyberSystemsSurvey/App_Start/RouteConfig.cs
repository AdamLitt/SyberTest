// <copyright file="RouteConfig.cs" company="Adam Litt Test Project.">
// Copyright (c) Adam Litt Test Project.. All rights reserved.
// </copyright>
namespace SyberSystemsSurvey
{
    using System.Web.Mvc;
    using System.Web.Routing;
    using Microsoft.AspNet.FriendlyUrls;

    /// <summary>
    /// Route Config.
    /// </summary>
    public static class RouteConfig
    {
        /// <summary>
        /// Registering Routes.
        /// </summary>
        /// <param name="routes">the collection of routes.</param>
        public static void RegisterRoutes(RouteCollection routes)
        {
            var settings = new FriendlyUrlSettings();
            settings.AutoRedirectMode = RedirectMode.Permanent;
            routes.EnableFriendlyUrls(settings);

            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                    name: "Default",
                    url: "{controller}/{action}/{id}",
                    defaults: new { action = "Index", id = UrlParameter.Optional });
        }
    }
}
