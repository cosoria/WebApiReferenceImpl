using System;

namespace WebApiReferenceImpl.Core.Extensions
{
    public static class IntegerExtensions
    {
        public static int Kb(this int value)
        {
            return value * 1024;
        }

        public static int Mb(this int value)
        {
            return value * 1024 * 1024;
        }

        public static int Gb(this int value)
        {
            return value * 1024 * 1024 * 1024;
        }

        public static TimeSpan Minutes(this int minutes)
        {
            return TimeSpan.FromMinutes(minutes);
        }

        public static TimeSpan Seconds(this int seconds)
        {
            return TimeSpan.FromSeconds(seconds);
        }

        public static TimeSpan Milliseconds(this int milliseconds)
        {
            return TimeSpan.FromMilliseconds(milliseconds);
        }

        public static TimeSpan Days(this int days)
        {
            return TimeSpan.FromDays(days);
        }

        public static TimeSpan Hours(this int hours)
        {
            return TimeSpan.FromHours(hours);
        }
    }
}