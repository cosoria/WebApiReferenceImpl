using System;

namespace Rigel.Core
{
    public class SystemTime
    {
        public static Func<DateTimeOffset> UtcDateTimeResolver;
        public static Func<DateTimeOffset> LocalDateTimeResolver;

        public static DateTimeOffset UtcNow
        {
            get { return UtcDateTimeResolver == null ? DateTimeOffset.UtcNow : UtcDateTimeResolver(); }
        }

        public static DateTimeOffset Now
        {
            get { return LocalDateTimeResolver == null ? DateTimeOffset.Now : LocalDateTimeResolver(); }
        }
    }
}