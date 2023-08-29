using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

using MVC.Modules;

namespace MVC
{
    public class MvcApplication : System.Web.HttpApplication
    {
        /// <summary>
        /// 
        /// </summary>
        protected void Application_Start()
        {
            Common.WriteLog("Global.asax", "Application_Start");

            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }   // Application_Start();

        /// <summary>
        /// 
        /// </summary>
        protected void Application_Stop()
        {
            Common.WriteLog("Global.asax", "Application_Stop");
        }   // Application_End();

        /// <summary>
        /// 
        /// </summary>
        protected void Application_Error()
        {
            Common.WriteLog("Global.asax", "Application_Error");
            Exception ex = Server.GetLastError();   // 取得最後一次的Exception。
            Common.LogException("Global.aspx", ex);
        }   // Application_Error();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        protected void Session_Start(object sender, EventArgs args)
        {
            Common.WriteLog(Session.SessionID, "Global.asax", "Session_Start");
        }   // Session_Start();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        protected void Session_End(object sender, EventArgs args)
        {
            Common.WriteLog(Session.SessionID, "Global.asax", "Session_End");
        }   // Session_End();

    }
}
