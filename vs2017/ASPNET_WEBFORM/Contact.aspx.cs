using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using NLog;

using ASPNET_WEBFORM.Modules;

namespace ASPNET_WEBFORM
{
    public partial class Contact : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Common.WriteLog(LogLevel.Debug, Session.SessionID, "Contact", "Page_Load()");
            if (!Page.IsPostBack)
            {
                Common.WriteLog(LogLevel.Debug, Session.SessionID, "Contact", "Page_Load(!IsPostBack)");
            }
        }

        protected void Page_Unload(object sender, EventArgs e)
        {
            Common.WriteLog(LogLevel.Debug, Session.SessionID, "Contact", "Page_Unload()");
            if (!Page.IsPostBack)
            {
                Common.WriteLog(LogLevel.Debug, Session.SessionID, "Contact", "Page_Unload(!IsPostBack)");
            }
        }
    }   // Contact
}   // ASPNET_WEBFORM