using System;

namespace WebApiReferenceImpl.Core.Extensions
{
    public static class DoubleExtensions
    {
        public static double Round(this double value, int digits)
        {
            return Math.Round(value, digits);
        }
        
        public static TimeSpan Minutes(this double minutes)
        {
            return TimeSpan.FromMinutes(minutes);
        }

        public static TimeSpan Hours(this double hours)
        {
            return TimeSpan.FromHours(hours);
        }

        public static TimeSpan Seconds(this double seconds)
        {
            return TimeSpan.FromSeconds(seconds);
        }

        public static TimeSpan Milliseconds(this double milliseconds)
        {
            return TimeSpan.FromMilliseconds(milliseconds);
        }

        public static TimeSpan Days(this double days)
        {
            return TimeSpan.FromDays(days);
        }

        public static double ToRadians(this double deg)
        {
            return (deg * Math.PI / 180.0);
        }

        public static double ToDegrees(this double rad)
        {
            return (rad / Math.PI * 180.0);
        }
    }
}