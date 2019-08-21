using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utility
{
    public static class Util
    {
        public static string TrimEnd(this string input, string suffixToRemove, StringComparison comparisonType)
        {

            if (input != null && suffixToRemove != null
              && input.EndsWith(suffixToRemove, comparisonType))
            {
                return input.Substring(0, input.Length - suffixToRemove.Length);
            }
            else return input;
        }

        public static string readRichTextbox(string[] valuearray)
        {
            StringBuilder sbText = new StringBuilder();
            try
            {
                foreach (string line in valuearray)
                {
                    string linevalue = line.Trim();
                    if (!string.IsNullOrEmpty(linevalue))
                    {
                        sbText.Append(linevalue);
                        sbText.Append(@" \line ");
                    }
                }
            }
            catch (Exception ex)
            {
                Utility.ErrorLog.Logging("OPD History", ex.Message.ToString(), ex.StackTrace.ToString());
            }
            return sbText != null ? TrimEnd(sbText.ToString(), @" \line ", StringComparison.OrdinalIgnoreCase) : "";

        }
        public static string getValueFromConfig(string key)
        {
            return Convert.ToString(ConfigurationManager.AppSettings[key]);
        }
    }



    public enum LookUp
    {
        Department = 1,
        RoleCategory,
        Status,
        OPDRate

    }

    public enum OPD_STATUS
    {
        Waiting = 1,
        Pending,
        Inprogress,
        NotAvailable,
        Done
    }

    public enum P_TYPE
    {
        ECG = 1,
        XRAY,
        CHARITY,
        LABCHARITY
    }
}
