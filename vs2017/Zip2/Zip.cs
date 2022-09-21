using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Ionic.Zip;

namespace Zip2
{
    public class Zip
    {
        /// <summary>
        /// 驗證壓縮檔。
        /// </summary>
        /// <param name="zipFilename">目標壓縮檔完整路徑名稱</param>
        /// <param name="cntFiles">此壓縮檔中應該有幾個檔案</param>
        /// <returns></returns>
        public static bool VerifyZip(string zipFilename, int cntFiles)
        {
            bool brc = false;
            string trgFolder = Path.Combine(Path.GetTempPath(), Path.GetFileNameWithoutExtension(zipFilename));

            ZipFile trgZip = ZipFile.Read(zipFilename);
            Debug.WriteLine("Extract all files to [" + trgFolder + "]");
            if (!Directory.Exists(trgFolder))
                Directory.CreateDirectory(trgFolder);
            else
                Directory.Delete(trgFolder, true);  // 先刪掉暂存目錄及檔案。
            trgZip.ExtractAll(trgFolder, ExtractExistingFileAction.OverwriteSilently);
            string[] lstFiles = Directory.GetFiles(trgFolder);
            Debug.WriteLine("Total " + lstFiles.Length.ToString() + " file(s) extracted");
            Directory.Delete(trgFolder, true);  // 刪掉產生出來的暫存目錄及檔案。

            if (lstFiles.Length == cntFiles)
                brc = true;

            return brc;
        }   // VerifyZip();

        /// <summary>
        /// 產生壓縮檔。
        /// </summary>
        /// <param name="destFilename">目標壓縮檔完整路徑名稱</param>
        /// <param name="srcFilelist">要加入至壓縮檔的檔案清單(完整路徑名稱)</param>
        /// <param name="verify">產生壓縮檔後是否要驗證</param>
        /// <returns></returns>
        public static bool CreateZip(string destFilename, List<string> srcFilelist, bool verify = false)
        {
            bool brc = false;
            string tmpFilename = Path.GetTempFileName();
            int cnt = 0;

            // 先在暫存目錄產生壓縮檔。
            if (File.Exists(tmpFilename))
                File.Delete(tmpFilename);
            Debug.WriteLine("Create zip file [" + tmpFilename + "]");
            ZipFile destZip = new ZipFile(tmpFilename);
            for (int i = 0; i < srcFilelist.Count; i++)
            {
                if (File.Exists(srcFilelist[i]))
                {
                    Debug.WriteLine("Add file [" + srcFilelist[i] + "] to zip");
                    destZip.AddFile(srcFilelist[i], "");
                    cnt++;
                }
            }
            destZip.Save();
            Debug.WriteLine("Saved " + cnt.ToString() + " file(s) to zip");
            // 再從暫存目錄把壓縮檔移到目標目錄。
            if (File.Exists(destFilename))
                File.Delete(destFilename);
            File.Move(tmpFilename, destFilename);

            if (!verify)
                brc = true;
            else
                brc = VerifyZip(destFilename, cnt); // 驗證所產生的壓縮檔。

            return brc;
        }   // CreateZip();

    }   // Zip
}   // Zip2
