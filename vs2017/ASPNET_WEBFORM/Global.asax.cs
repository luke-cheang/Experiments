using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

using NLog;

using ASPNET_WEBFORM.Modules;

namespace ASPNET_WEBFORM
{
    public class Global : HttpApplication
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            Common.WriteLog(LogLevel.Debug, "xxxxxxxxxxxxxxxxxxxxxxxx", "Global", "Application_Start()");
        }   // Application_Start();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void Application_End(object sender, EventArgs e)
        {
            Common.WriteLog(LogLevel.Debug, "xxxxxxxxxxxxxxxxxxxxxxxx", "Global", "Application_End()");
        }   // Application_End();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void Session_Start(object sender, EventArgs e)
        {
            Common.WriteLog(LogLevel.Debug, Session.SessionID, "Global", "Session_Start()");
        }   // Session_Start();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void Session_End(object sender, EventArgs e)
        {
            Common.WriteLog(LogLevel.Debug, Session.SessionID, "Global", "Session_End()");
        }   // Session_End();

    }   
}