using System.Globalization;

namespace WebApiReferenceImpl.Core.Utils
{
    public static class StringUtil
    {
        public static string FormatInvariant(string format, params object[] parameters)
        {
            return string.Format(CultureInfo.InvariantCulture, format, parameters);
        }
    }
}