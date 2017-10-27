using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace WebApiReferenceImpl.Core.Extensions
{
    public static class StringExtensions
    {
        public static T To<T>(this string val)
        {
            if (val == null)
            {
                return default(T);
            }

            Type t = typeof(T);

            if (t.IsGenericType && (t.GetGenericTypeDefinition() == typeof(Nullable<>)))
            {
                return (T)Convert.ChangeType(val, Nullable.GetUnderlyingType(t));
            }
            else
            {
                return (T)Convert.ChangeType(val, t);
            }
        }

        public static bool IsEmpty(this string stringValue)
        {
            return string.IsNullOrEmpty(stringValue);
        }

        public static bool IsNotEmpty(this string stringValue)
        {
            return !string.IsNullOrEmpty(stringValue);
        }

        public static string Left(this string stringValue, int numCharacters)
        {
            return stringValue.Trim().Substring(0, numCharacters);
        }

        public static string Right(this string stringValue, int numCharacters)
        {
            var trimmed = stringValue.Trim();
            return trimmed.Substring(trimmed.Length - numCharacters - 1, numCharacters);
        }

        public static IEnumerable<string> FromCsv(this string val)
        {
            if (string.IsNullOrEmpty(val)) return new List<string>();
            if (!val.Contains(",")) return new List<string>() { val };

            return val.Split(new char[] { ',' });
        }

        public static string ToDelimited<T>(this IEnumerable<T> selections, char delimiter)
        {
            string retval = selections.Aggregate(string.Empty, (current, selection) => current + (selection + delimiter.ToString()));

            return retval.Length == 0 ? retval : retval.Substring(0, retval.Length - 1);
        }

        public static string ToCsv<T>(this IEnumerable<T> selections)
        {
            return ToDelimited(selections, ',');
        }

        public static string AlphaOnly(this string stringToClean)
        {
            if (stringToClean.IsEmpty())
                return stringToClean;

            return Regex.Replace(stringToClean, @"[^a-zA-Z]", "");
        }

        public static string NumericOnly(this string stringToClean)
        {
            if (stringToClean.IsEmpty())
                return stringToClean;

            return Regex.Replace(stringToClean, @"[^0-9]", "");
        }

        public static string AlphaNumericOnly(this string stringToClean)
        {
            if (stringToClean.IsEmpty())
                return stringToClean;

            return Regex.Replace(stringToClean, @"[^a-zA-Z0-9]", "");
        }

        public static string ToUrlFriendly(this string stringToClean)
        {
            if (stringToClean.IsEmpty())
                return stringToClean;

            string myCleanString = Regex.Replace(stringToClean, @"[^a-zA-Z0-9-_ ]", "");
            return myCleanString.Replace(' ', '_');
        }

        public static string ToSafeJson(this string json)
        {
            if (json.IsEmpty())
                return "";

            return json.Replace("{", "{{").Replace("}", "}}");
        }

        public static string ToUnixPlatform(this string text)
        {
            if (text.IsEmpty())
                return "";

            return text.Replace("\r\n", "\n");
        }

        public static string SanitizeHtml(this string html)
        {
            const string acceptable = "i|b|u|sup|sub|ol|ul|li|br|h2|h3|h4|h5|span|div|p|a|img|blockquote";
            const string stringPattern = @"</?(?(?=" + acceptable + @")notag|[a-z,A-Z,0-9]+)(?:\s[a-z,A-Z,0-9,\-]+=?(?:(["",']?).*?\1?))*\s*/?>";
            return Regex.Replace(html, stringPattern, "");
        }

        public static string Repeat(this string input, int times)
        {
            string retval = input;

            for (int i = 0; i < times; i++)
                retval += input;

            return retval;
        }

        public static string Reverse(this string input)
        {
            if (string.IsNullOrEmpty(input))
                return "";

            string revstr = "";
            for (int i = input.Length - 1; i >= 0; i--)
            {
                revstr += input[i];
            }
            return revstr;
        }
    }
}
