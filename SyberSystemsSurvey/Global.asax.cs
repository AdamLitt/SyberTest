// <copyright file="Global.asax.cs" company="Adam Litt Test Project.">
// Copyright (c) Adam Litt Test Project.. All rights reserved.
// </copyright>
namespace SyberSystemsSurvey
{
    using System;
    using System.Web;
    using System.Web.Mvc;
    using System.Web.Optimization;
    using System.Web.Routing;

    /// <summary>
    /// Global.
    /// </summary>
    public class Global : HttpApplication
    {
        /// <summary>
        /// App start method.
        /// </summary>
        /// <param name="sender">the sender.</param>
        /// <param name="e">event arguments.</param>
        public void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}