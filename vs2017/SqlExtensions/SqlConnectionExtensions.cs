using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

public static class SqlConnectionExtensions
{
    /// <summary>
    /// 帶有自動重試功能的開啟資料庫連線。
    /// </summary>
    /// <param name="connection">SqlConnection物件</param>
    /// <param name="maxRetryCount">最大重試次數</param>
    /// <param name="delayMilliseconds">等待多久後再重試</param>
    /// <returns></returns>
    public static void OpenWithRetry(this SqlConnection connection, int maxRetryCount = 5, int delayMilliseconds = 100)
    {
        int retryCount = 0;
        bool isConnected = false;
        SqlException ex0 = null;

        Debug.WriteLine("OpenWithRetry(maxRetryCount=" + maxRetryCount.ToString() + ",delayMilliseconds=" + delayMilliseconds.ToString());
        while (retryCount <= maxRetryCount && !isConnected)
        {
            try
            {
                Debug.WriteLine("retryCount=" + retryCount.ToString() + ",connection.Open()");
                connection.Open();
                isConnected = true;
            }
            catch (SqlException ex)
            {
                ex0 = ex;
                retryCount++;
                if (retryCount <= maxRetryCount) 
                {
                    Debug.WriteLine("retryCount=" + retryCount.ToString() + ",Thred.Sleep()");
                    Thread.Sleep(delayMilliseconds);    // 如果要重試，稍等一下再做。
                }
            }
        }

        if (!isConnected)
            throw ex0;  // 把最後一次Exception丟回去。
    }   // OpenWithRetry();

}
