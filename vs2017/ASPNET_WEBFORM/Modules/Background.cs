using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading;
using System.Web;

using NLog;

using ASPNET_WEBFORM.Modules;


namespace ASPNET_WEBFORM.Modules
{
    public class Background
    {
        private Thread _MyThread { get; set; }

        private bool _Running { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Background()
        {
            string sid = "xxxxxxxxxxxxxxxxxxxxxxxx";    // 背景作業並無Session。
            Common.WriteLog(LogLevel.Debug, sid, "Background", "Background()");
            _MyThread = new Thread(ThreadWorker);
            _Running = false;
        }   // Background();

        /// <summary>
        /// 啟動背景作業。
        /// </summary>
        public void Start()
        {
            string sid = "xxxxxxxxxxxxxxxxxxxxxxxx";    // 背景作業並無Session。
            if (!_Running)  // 要避免重複呼叫。
            {
                Common.WriteLog(LogLevel.Debug, sid, "Background", "Start()");
                _Running = true;
                _MyThread.Start();
                Common.WriteLog(LogLevel.Debug, sid, "Background", "Thread started");
            }
        }   // Start();

        /// <summary>
        /// 結束背景作業。
        /// </summary>
        public void Stop()
        {
            string sid = "xxxxxxxxxxxxxxxxxxxxxxxx";    // 背景作業並無Session。
            if (_Running)
            {
                Common.WriteLog(LogLevel.Debug, sid, "Background", "Stop()");
                _Running = false;
                _MyThread.Join();
                Common.WriteLog(LogLevel.Debug, sid, "Background", "Thread joined");
            }
        }   // Stop();

        private void ThreadWorker()
        {
            string sid = "xxxxxxxxxxxxxxxxxxxxxxxx";    // 背景作業並無Session。
            string s;
            bool b;
            int i;
            bool throwException = false;
            int waitCount = 0;

            s = ConfigurationManager.AppSettings["ThrowBackgroundException"];
            if (!string.IsNullOrWhiteSpace(s))
            {
                if (bool.TryParse(s, out b))
                    throwException = b;
            }
            if (throwException)
            {
                s = ConfigurationManager.AppSettings["ThrowAfter"];
                if (!string.IsNullOrWhiteSpace(s))
                {
                    if (int.TryParse(s, out i))
                        waitCount = i;
                }
            }
            Common.WriteLog(LogLevel.Debug, sid, "Background", "Starting ThreadWorker()");
            while (_Running)
            {
                Thread.Sleep(1000 * 60);
                Common.WriteLog(LogLevel.Debug, sid, "Background", "Thread working");
                if (throwException)
                {
                    waitCount--;
                    if (waitCount <= 0)
                    {
                        Common.WriteLog(LogLevel.Debug, sid, "Background", "Throw Exception");
                        throw new ApplicationException("Exception thrown by ThreadWorker().");
                    }
                }
            }   // while(_Running);
            Common.WriteLog(LogLevel.Debug, sid, "Background", "ThreadWorker() Stopped");
        }   // ThreadWorker();

    }   // Background
}   // ASPNET_WEBFORM.Modules