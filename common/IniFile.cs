using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Common.Utility
{
    /// <summary>
    /// Class for reading and writing INI configuration file.
    /// </summary>
    public class IniFile
    {
        /// <summary>
        /// WritePrivateProfileString() from kernel32.dll.
        /// </summary>
        /// <param name="section">The name of the section to which the string will be copied.</param>
        /// <param name="key">The name of the key to be associated with a string.</param>
        /// <param name="value">A null-terminated string to be written to the file. </param>
        /// <param name="filePath">The name of the initialization file.</param>
        /// <returns>
        /// If the function successfully copies the string to the initialization file, the return value is nonzero.
        /// If the function fails, or if it flushes the cached version of the most recently accessed initialization file, 
        /// the return value is zero. To get extended error information, call GetLastError.
        /// </returns>
        [DllImport("kernel32", CharSet = CharSet.Ansi)]
        private static extern Int32 WritePrivateProfileStringA(string section, string key, string value, string filePath);

        /// <summary>
        /// GetPrivateProfileString() from kernel32.dll.
        /// </summary>
        /// <param name="section">The name of the section containing the key name.</param>
        /// <param name="key">The name of the key whose associated string is to be retrieved.</param>
        /// <param name="defaultValue">A default string.</param>
        /// <param name="returnValue">A pointer to the buffer that receives the retrieved string.</param>
        /// <param name="size">The size of the buffer pointed to by the returnValue parameter, in characters.</param>
        /// <param name="filePath">The name of the initialization file.</param>
        /// <returns>
        /// The return value is the number of characters copied to the buffer, not including the terminating null character.
        /// To retrieve extended error information, call GetLastError.
        /// </returns>
        [DllImport("kernel32", CharSet = CharSet.Ansi)]
        private static extern Int32 GetPrivateProfileStringA(string section, string key, string defaultValue, StringBuilder returnValue, int size, string filePath);

        /// <summary>
        /// Retrieves the calling thread's last-error code value. 
        /// </summary>
        /// <returns>
        /// The return value is the calling thread's last-error code.
        /// </returns>
        [DllImport("kernel32")]
        private static extern Int32 GetLastError();

        /// <summary>
        /// Maximum size of string value retrieving from the INI file.
        /// </summary>
        private const int MaxStringSize = 4096;

        /// <summary>
        /// Full path and filename of the INI file.
        /// </summary>
        public string Filename { get; set; }    // Filename

        /// <summary>
        /// Default Constructor of IniFile.
        /// </summary>
        public IniFile()
        {
            Debug.WriteLine("IniFile();");
        }   // IniFile();

        /// <summary>
        /// Constructor of IniFile.
        /// </summary>
        /// <param name="filename">The full path and filename of the INI file.</param>
        public IniFile(string filename) : this()
        {
            Debug.WriteLine("IniFile(" + (filename == null ? "null" : filename) + ");");
            this.Filename = filename.Trim();
        }   // IniFile();

        /// <summary>
        /// Get a string from the INI file.
        /// </summary>
        /// <param name="section"></param>
        /// <param name="key"></param>
        /// <param name="default_value"></param>
        /// <returns>
        /// The string retrieved from the INI file if success, or default value otherwise.
        /// </returns>
        public string GetString(string section, string key, string default_value)
        {
            Debug.WriteLine("IniFile.GetString(" +
                            (section == null ? "null" : section) + "," +
                            (key == null ? "null" : key) + "," +
                            (default_value == null ? "null" : default_value) + ");");
            StringBuilder tmp = new StringBuilder(MaxStringSize);
            int rc = GetPrivateProfileStringA(section, key, default_value, tmp, MaxStringSize, this.Filename);
            if (rc > 0)
                return tmp.ToString();
            else
            {
                // GetPrivateProfileStringA()執行失敗，所以回傳default_value。
                int errno = GetLastError();
                Debug.WriteLine("GetPrivateProfileStringA():GetLastError()=" + errno.ToString());
                return default_value;
            }
        }   // GetString();

        /// <summary>
        /// Write a string into the INI file.
        /// </summary>
        /// <param name="section"></param>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns>
        /// 0 if succeed to write the string into the INI file, or errno retrieved from GetLastError().
        /// </returns>
        public int SetString(string section, string key, string value)
        {
            Debug.WriteLine("IniFile.SetString(" +
                            (section == null ? "null" : section) + "," +
                            (key == null ? "null" : key) + "," +
                            (value == null ? "null" : value) + ");");
            int rc = WritePrivateProfileStringA(section, key, value, this.Filename);
            Debug.WriteLine("WriteProfileStringA()=" + rc.ToString());
            if (0 != rc)
                return 0;
            else
            {
                // WritePrivateProfileStringA()執行失敗，所以回傳GetLastError()取得的errno。
                int errno = GetLastError();
                Debug.WriteLine("WriteProfileStringA():GetLastError()=" + errno.ToString());
                return errno;
            }
        }   // SetString();

    }   // IniFile
}   // Common.Utility
