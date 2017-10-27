using System;
using System.Linq;

namespace WebApiReferenceImpl.Core.Utils
{
    public static class DateTimeUtil
    {
        public static DateTime Min(DateTime one, DateTime two)
        {
            return new DateTime[] { one, two }.Min();
        }

        public static DateTime Max(DateTime one, DateTime two)
        {
            return new DateTime[] { one, two }.Max();
        }

        public static DateTime Min(params DateTime[] dates)
        {
            return dates.Min();
        }

        public static DateTime Max(params DateTime[] dates)
        {
            return dates.Max();
        } 
    }
}