using System;

namespace DefaultNamespace
{
    public class Utils
    {
        public static long currentTime()
        {
            var datetime = DateTime.UtcNow - new DateTime(1970, 1, 1);
            double milliseconds = datetime.TotalMilliseconds;
            return (long) milliseconds;
        }
    }
}