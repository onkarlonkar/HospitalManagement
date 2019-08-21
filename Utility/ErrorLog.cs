using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utility
{
    public class ErrorLog
    {
        #region --- Code For Error Logging ---

        /// <summary>
        /// Logging
        /// </summary>
        /// <param name="ex">Exception</param>
        public static void Logging(params string[] messages)
        {
            string path = string.Empty;
            path = GetConfigValue("ErrorLogging");

            if (IsFolderExist(path))
            {
                StreamWriter sw = null;
                //OldFileDelete(path);
                string fileName = "ErrorLog.txt";
                string filePath = Path.Combine(path, fileName);

                try
                {
                    sw = new StreamWriter(filePath, true);
                    sw.WriteLine("*****************************************************************************************************************");
                    sw.WriteLine("--Date/Time :" + DateTime.Now.ToString());
                    foreach (string message in messages)
                    {
                        sw.WriteLine("--" + message.ToString().Trim());
                    }
                    sw.WriteLine();
                    sw.Flush();
                    sw.Close();
                }
                catch
                {
                }
                finally
                {

                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public static string GetConfigValue(string p)
        {
            return ConfigurationManager.AppSettings[p].ToString();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static bool IsFolderExist(string path)
        {
            if (!System.IO.Directory.Exists(path))
            {
                System.IO.Directory.CreateDirectory(path);
            }
            return true;
        }

        #endregion
    }
}
