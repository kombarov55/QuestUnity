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
            if (str == "")
            {
                return DateTime.Now;
            }
            
            return DateTime.ParseExact(str, Pattern, CultureInfo.InvariantCulture);
        }

        public static string TimeSpanToString(TimeSpan timeSpan)
        {
            string minstr = timeSpan.Minutes >= 10 ? "" + timeSpan.Minutes : "0" + timeSpan.Minutes;
            string secstr = timeSpan.Seconds >= 10 ? "" + timeSpan.Seconds : "0" + timeSpan.Seconds;

            return minstr + ":" + secstr;
        } 
        
    }
}