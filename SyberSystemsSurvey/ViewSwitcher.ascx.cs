// <copyright file="ViewSwitcher.ascx.cs" company="Adam Litt Test Project.">
// Copyright (c) Adam Litt Test Project.. All rights reserved.
// </copyright>
namespace SyberSystemsSurvey
{
    using System;
    using System.Web;
    using System.Web.Routing;
    using Microsoft.AspNet.FriendlyUrls.Resolvers;

    /// <summary>
    /// ViewSwitcher.
    /// </summary>
    public partial class ViewSwitcher : System.Web.UI.UserControl
    {
        /// <summary>
        /// Gets the current view name.
        /// </summary>
        protected string CurrentView { get; private set; }

        /// <summary>
        /// Gets an alternate.
        /// </summary>
        protected string AlternateView { get; private set; }

        /// <summary>
        /// Gets the URL to switch to.
        /// </summary>
        protected string SwitchUrl { get; private set; }

        /// <summary>
        /// Page Load.
        /// </summary>
        /// <param name="sender">The Sender.</param>
        /// <param name="e">event args.</param>
        protected void Page_Load(object sender, EventArgs e)
        {
            // Determine current view
            var isMobile = WebFormsFriendlyUrlResolver.IsMobileView(new HttpContextWrapper(this.Context));
            this.CurrentView = isMobile ? "Mobile" : "Desktop";

            // Determine alternate view
            this.NewMethod(isMobile);

            // Create switch URL from the route, e.g. ~/__FriendlyUrls_SwitchView/Mobile?ReturnUrl=/Page
            var switchViewRouteName = "AspNet.FriendlyUrls.SwitchView";
            var switchViewRoute = RouteTable.Routes[switchViewRouteName];
            if (switchViewRoute == null)
            {
                // Friendly URLs is not enabled or the name of the switch view route is out of sync
                this.Visible = false;
                return;
            }

            var url = this.GetRouteUrl(switchViewRouteName, new { view = this.AlternateView, __FriendlyUrls_SwitchViews = true });
            url += "?ReturnUrl=" + HttpUtility.UrlEncode(this.Request.RawUrl);
            this.SwitchUrl = url;
        }

        private void NewMethod(bool isMobile)
        {
            this.AlternateView = isMobile ? "Desktop" : "Mobile";
        }
    }
}