using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

using NLog;

namespace ASP.NET.Modules
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
        /// 寫入一行Debug log訊息。
        /// </summary>
        /// <param name="msg"></param>
        public static void WriteLog(string msg)
        {
            WriteLog(LogLevel.Debug, msg);
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
        /// 寫入一行Debug log訊息。
        /// </summary>
        /// <param name="sessionId"></param>
        /// <param name="aspxName"></param>
        /// <param name="msg"></param>
        public static void WriteLog(string sessionId, string aspxName, string msg)
        {
            WriteLog(LogLevel.Debug, sessionId, aspxName, msg);
        }   // WriteLog();

        /// <summary>
        /// 寫入一行Debug log訊息。
        /// </summary>
        /// <param name="aspxName"></param>
        /// <param name="msg"></param>
        public static void WriteLog(string aspxName, string msg)
        {
            WriteLog("xxxxxxxxxxxxxxxxxxxxxxxx", aspxName, msg);
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
                    WriteLog(LogLevel.Error, sessionId, aspxName, "Exception[" + idx.ToString() + "].Source=[" + ex0.Source + "]");
                    WriteLog(LogLevel.Error, sessionId, aspxName, "Exception[" + idx.ToString() + "].Message=[" + ex0.Message + "]");
                    WriteLog(LogLevel.Error, sessionId, aspxName, "TargetSite[" + idx.ToString() + "].Module=[" + ex0.TargetSite.Module + "]");
                    WriteLog(LogLevel.Error, sessionId, aspxName, "TargetSite[" + idx.ToString() + "].Name=[" + ex0.TargetSite.Name + "]");
                    if (ex0.Data.Count > 0)
                    {
                        foreach (DictionaryEntry de in ex0.Data)
                        {
                            WriteLog(LogLevel.Error, sessionId, aspxName, "Data[" + idx.ToString() + "].Key[" + de.Key.ToString() + "]=[" + de.Value.ToString() + "]");
                        }
                    }

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

        /// <summary>
        /// 把Exception內容Log下來。
        /// </summary>
        /// <param name="aspxName"></param>
        /// <param name="ex"></param>
        public static void LogException(string aspxName, Exception ex)
        {
            LogException("xxxxxxxxxxxxxxxxxxxxxxxx", aspxName, ex);
        }   // LogException();

    }   // Common

}   // ASP.NET.Modules