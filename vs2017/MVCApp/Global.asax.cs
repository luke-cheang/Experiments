using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

using NLog;
using MVCApp.Modules;

namespace MVCApp
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            Common.WriteLog(LogLevel.Debug, "xxxxxxxxxxxxxxxxxxxxxxxx", "Global", "Application_Start");
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            Assembly me = Assembly.GetExecutingAssembly();
            AssemblyName myName = me.GetName();
            Common.WriteLog(LogLevel.Debug, "xxxxxxxxxxxxxxxxxxxxxxxx", "Global", "myName.Name=[" + myName.Name + "]");
            Common.WriteLog(LogLevel.Debug, "xxxxxxxxxxxxxxxxxxxxxxxx", "Global", "myName.Version=[" + myName.Version.ToString() + "]");
        }

        protected void Application_End()
        {
            Common.WriteLog(LogLevel.Debug, "xxxxxxxxxxxxxxxxxxxxxxxx", "Global", "Application_End");
        }

        protected void Session_Start(object sender, EventArgs args)
        {
            if ((Session != null) && !string.IsNullOrWhiteSpace(Session.SessionID))
                Common.WriteLog(LogLevel.Debug, Session.SessionID, "Global", "Session_Start()");
            else
                Common.WriteLog(LogLevel.Debug, "xxxxxxxxxxxxxxxxxxxxxxxx", "Global", "Session_Start()");
        }

        protected void Session_End(object sender, EventArgs args)
        {
            if ((Session != null) && !string.IsNullOrWhiteSpace(Session.SessionID))
                Common.WriteLog(LogLevel.Debug, Session.SessionID, "Global", "Session_End()");
            else
                Common.WriteLog(LogLevel.Debug, "xxxxxxxxxxxxxxxxxxxxxxxx", "Global", "Session_End()");
        }
    }
}
