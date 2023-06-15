using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

using NLog;

namespace MVCApp.Modules
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

        /// <summary>
        /// 把Exception內容Log下來。
        /// </summary>
        /// <param name="sessionId"></param>
        /// <param name="aspxName"></param>
        /// <param name="ex"></param>
        public static void LogException(string sessionId, string aspxName, Exception ex)
        {
            try
            {
                int idx = 0;
                Exception ex0 = ex;
                while (null != ex0)
                {
                    WriteLog(LogLevel.Error, sessionId, aspxName, "Exception[" + idx.ToString() + "]:" + ex0.Source + " - " + ex0.Message);
                    ex0 = ex0.InnerException;
                    idx++;
                }
                if (!string.IsNullOrWhiteSpace(ex.StackTrace))
                    WriteLog(LogLevel.Error, sessionId, aspxName, "StackTrace:\n" + ex.StackTrace);
            }
            catch
            {
                // 寫log失敗也不能怎麼樣了。
            }
        }   // LogException();


    }   // Common

}   // MVCApp.Modules