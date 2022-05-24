using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

using NLog;

namespace ASPNET_WEBFORM.Modules
{
    public static class Common
    {
        private static Logger _myLogger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// 寫入一行log訊息。
        /// </summary>
        /// <param name="lv"></param>
        /// <param name="msg"></param>
        public static void WriteLog(LogLevel lv, string msg)
        {
            try
            {
                if (_myLogger != null)
                    _myLogger.Log(lv, msg);
            }
            catch (Exception ex)
            {
                // 寫log失敗也不能怎麼樣了。
            }
        }   // WriteLog();

        /// <summary>
        /// 寫入一行log訊息。
        /// </summary>
        /// <param name="lv"></param>
        /// <param name="sessionId"></param>
        /// <param name="aspxName"></param>
        /// <param name="msg"></param>
        public static void WriteLog(LogLevel lv, string sessionId, string aspxName, string msg)
        {
            WriteLog(lv, sessionId + "\t" + aspxName + "\t" + msg);
        }   // WriteLog();

    }   // Common
}   // ASPNET_WEBFORM.Modules