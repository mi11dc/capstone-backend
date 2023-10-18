using System;
using System.Collections.Generic;
using System.Text;

namespace SLH.Service.Common
{
    public class UtilityFunctions
    {
        public static string SetDateFormate(DateTime date, bool type = true)
        {
            Formats formats = AppSettings.Formates;
            return date.ToString(type ? formats.DateFormat1 : formats.DateFormat);
        }
    }
}
