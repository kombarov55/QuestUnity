using System;
using System.Globalization;

namespace DefaultNamespace
{
    public static class DateUtil
    {
        private static readonly string Pattern = "yyyy'-'MM'-'dd'T'HH':'mm':'ss";
        
        public static string DateToString(DateTime dateTime)
        {
            return dateTime.ToString(Pattern);
        }

        public static DateTime StringToDate(string str)
        {
            return DateTime.ParseExact(str, Pattern, CultureInfo.InvariantCulture);
        }
    }
}