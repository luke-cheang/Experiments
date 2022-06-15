using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLUtil
{
    public class Common
    {
        /// <summary>
        /// 取得完整的每一層Exceptioin訊息。
        /// </summary>
        /// <param name="ex"></param>
        /// <returns></returns>
        public static String GetExceptionString(Exception ex)
        {
            String msg = String.Empty;
            int i = 0;

            if (ex != null)
            {
                msg += "Exception[" + i.ToString() + "]: Source=[" + ex.Source + "], Message=[" + ex.Message + "]\n";
                i++;
                Exception ex1 = ex.InnerException;
                while (ex1 != null)
                {
                    msg += "Exception[" + i.ToString() + "]: Source=[" + ex1.Source + "], Message=[" + ex1.Message + "]\n";
                    i++;
                    ex1 = ex1.InnerException;
                }
            }

            return msg;
        }   // GetExceptionString();

    }   // Common
}   // SQLUtil
