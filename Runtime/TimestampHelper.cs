using System;
using System.Globalization;

namespace UUtils
{
    public static class TimestampHelper
    {
        public static string GetTimestamp()
        {
            return DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);
        }

        public static string GetSimplifiedTimestamp()
        {
            return DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss", CultureInfo.InvariantCulture);
        }
    }
}