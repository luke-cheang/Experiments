using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
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
        private Background bgWorker;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        void Unhandled_Exeception(object sender, UnhandledExceptionEventArgs args)
        {
            string sid = "xxxxxxxxxxxxxxxxxxxxxxxx";
            if ((HttpContext.Current != null) &&
                (HttpContext.Current.Session != null) &&
                !string.IsNullOrWhiteSpace(HttpContext.Current.Session.SessionID))
            {
                sid = HttpContext.Current.Session.SessionID;
            }
            Common.WriteLog(LogLevel.Debug, sid, "Global", "Unhandled_Exeception()");
            Exception ex = args.ExceptionObject as Exception;
            Common.LogException(sid, "Global", ex);
        }

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

            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(Unhandled_Exeception);

            string sid = "xxxxxxxxxxxxxxxxxxxxxxxx";    // Session還未建立。
            Common.WriteLog(LogLevel.Debug, sid, "Global", "Application_Start()");

            Assembly me = Assembly.GetExecutingAssembly();
            AssemblyName myName = me.GetName();
            Common.WriteLog(LogLevel.Debug, sid, "Global", "myName.Name=[" + myName.Name + "]");
            Common.WriteLog(LogLevel.Debug, sid, "Global", "myName.Version=[" + myName.Version.ToString() + "]");

            string s;
            bool b;

            s = ConfigurationManager.AppSettings["EnableBackgroundThread"];
            if (!string.IsNullOrWhiteSpace(s))
            {
                if (bool.TryParse(s, out b))
                {
                    if (b)
                    {
                        bgWorker = new Background();
                        bgWorker.Start();
                    }
                }
            }
        }   // Application_Start();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void Application_End(object sender, EventArgs e)
        {
            string s;
            bool b;

            if (bgWorker != null)
            {
                b = false;
                s = ConfigurationManager.AppSettings["KeepBackgroundThread"];
                if (!string.IsNullOrWhiteSpace(s))
                {
                    if (!bool.TryParse(s, out b))
                        b = false;
                }
                if (!b)
                    bgWorker.Stop();
            }
            string sid = "xxxxxxxxxxxxxxxxxxxxxxxx";    // Session已不可用。
            Common.WriteLog(LogLevel.Debug, sid, "Global", "Application_End()");
        }   // Application_End();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Application_Error(object sender, EventArgs e)
        {
            string sid = "xxxxxxxxxxxxxxxxxxxxxxxx";
            if ((HttpContext.Current != null) &&
                (HttpContext.Current.Session != null) &&
                !string.IsNullOrWhiteSpace(HttpContext.Current.Session.SessionID))
            {
                sid = HttpContext.Current.Session.SessionID;
            }
            Common.WriteLog(LogLevel.Debug, sid, "Global", "Application_Error()");
            Exception ex = Server.GetLastError();    // Get the last error from the server
            Common.LogException(sid, "Global", ex);
        }   // Application_Error();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            string sid = "xxxxxxxxxxxxxxxxxxxxxxxx";    // Session還未建立。
            Common.WriteLog(LogLevel.Debug, sid, "Global", "Application_BeginRequest()");
            if (Request != null)
            {
                Common.WriteLog(LogLevel.Debug, sid, "Global", "request.ApplicationPath=[" + Request.ApplicationPath + "]");
                Common.WriteLog(LogLevel.Debug, sid, "Global", "request.AppRelativeCurrentExecutionFilePath=[" + Request.AppRelativeCurrentExecutionFilePath + "]");
                Common.WriteLog(LogLevel.Debug, sid, "Global", "request.ContentType=[" + Request.ContentType + "]");
                Common.WriteLog(LogLevel.Debug, sid, "Global", "request.CurrentExecutionFilePath=[" + Request.CurrentExecutionFilePath + "]");
                Common.WriteLog(LogLevel.Debug, sid, "Global", "request.CurrentExecutionFilePathExtension=[" + Request.CurrentExecutionFilePathExtension + "]");
                Common.WriteLog(LogLevel.Debug, sid, "Global", "request.FilePath=[" + Request.FilePath + "]");
                Common.WriteLog(LogLevel.Debug, sid, "Global", "request.HttpMethod=[" + Request.HttpMethod + "]");
                Common.WriteLog(LogLevel.Debug, sid, "Global", "request.IsAuthenticated=[" + Request.IsAuthenticated.ToString() + "]");
                Common.WriteLog(LogLevel.Debug, sid, "Global", "request.IsLocal=[" + Request.IsLocal.ToString() + "]");
                Common.WriteLog(LogLevel.Debug, sid, "Global", "request.IsSecureConnection=[" + Request.IsSecureConnection.ToString() + "]");
                Common.WriteLog(LogLevel.Debug, sid, "Global", "request.Path=[" + Request.Path + "]");
                Common.WriteLog(LogLevel.Debug, sid, "Global", "request.PathInfo=[" + Request.PathInfo + "]");
                Common.WriteLog(LogLevel.Debug, sid, "Global", "request.PhysicalApplicationPath=[" + Request.PhysicalApplicationPath + "]");
                Common.WriteLog(LogLevel.Debug, sid, "Global", "request.PhysicalPath=[" + Request.PhysicalPath + "]");
                Common.WriteLog(LogLevel.Debug, sid, "Global", "request.RawUrl=[" + Request.RawUrl + "]");
                Common.WriteLog(LogLevel.Debug, sid, "Global", "request.RequestType=[" + Request.RequestType + "]");
                Common.WriteLog(LogLevel.Debug, sid, "Global", "request.TotalBytes=[" + Request.TotalBytes.ToString() + "]");
                Common.WriteLog(LogLevel.Debug, sid, "Global", "request.UserAgent=[" + Request.UserAgent + "]");
                Common.WriteLog(LogLevel.Debug, sid, "Global", "request.UserHostAddress=[" + Request.UserHostAddress + "]");
                Common.WriteLog(LogLevel.Debug, sid, "Global", "request.UserHostName=[" + Request.UserHostName + "]");
            }
        }   // Application_BeginRequest();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Application_EndRequest(object sender, EventArgs e)
        {
            string sid = "xxxxxxxxxxxxxxxxxxxxxxxx";    // Session還未建立。
            Common.WriteLog(LogLevel.Debug, sid, "Global", "Application_EndRequest()");
        }   // Application_EndRequest();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {
            string sid = "xxxxxxxxxxxxxxxxxxxxxxxx";    // Session還未建立。
            Common.WriteLog(LogLevel.Debug, sid, "Global", "Application_AuthenticateRequest()");
        }   // Application_AuthenticateRequest();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Application_AuthorizeRequest(object sender, EventArgs e)
        {
            string sid = "xxxxxxxxxxxxxxxxxxxxxxxx";    // Session還未建立。
            Common.WriteLog(LogLevel.Debug, sid, "Global", "Application_AuthorizeRequest()");
        }   // Application_AuthorizeRequest();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void Session_Start(object sender, EventArgs e)
        {
            string sid = Session.SessionID;
            Common.WriteLog(LogLevel.Debug, sid, "Global", "Session_Start()");
            Common.WriteLog(LogLevel.Debug, sid, "Global", "Session.CodePage=[" + Session.CodePage.ToString() + "]");
            Common.WriteLog(LogLevel.Debug, sid, "Global", "Session.Count=[" + Session.Count.ToString() + "]");
            Common.WriteLog(LogLevel.Debug, sid, "Global", "Session.IsCookieless=[" + Session.IsCookieless.ToString() + "]");
            Common.WriteLog(LogLevel.Debug, sid, "Global", "Session.IsNewSession=[" + Session.IsNewSession.ToString() + "]");
            Common.WriteLog(LogLevel.Debug, sid, "Global", "Session.IsReadOnly=[" + Session.IsReadOnly.ToString() + "]");
            Common.WriteLog(LogLevel.Debug, sid, "Global", "Session.IsSynchronized=[" + Session.IsSynchronized.ToString() + "]");
            Common.WriteLog(LogLevel.Debug, sid, "Global", "Session.LCID=[" + Session.LCID.ToString() + "]");
            Common.WriteLog(LogLevel.Debug, sid, "Global", "Session.Mode=[" + Session.Mode.ToString() + "]");
            Common.WriteLog(LogLevel.Debug, sid, "Global", "Session.Timeout=[" + Session.Timeout.ToString() + "]");
        }   // Session_Start();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void Session_End(object sender, EventArgs e)
        {
            string sid = Session.SessionID;
            Common.WriteLog(LogLevel.Debug, sid, "Global", "Session_End()");

            string s;
            bool b;
            bool throwException = false;

            s = ConfigurationManager.AppSettings["ThrowBackgroundException"];
            if (!string.IsNullOrWhiteSpace(s))
            {
                if (bool.TryParse(s, out b))
                    throwException = b;
            }
            if (throwException)
            {
                Common.WriteLog(LogLevel.Debug, sid, "Global", "Throw Exception");
                throw new ApplicationException("Exception thrown by Session_End().");
            }
        }   // Session_End();
    }
}