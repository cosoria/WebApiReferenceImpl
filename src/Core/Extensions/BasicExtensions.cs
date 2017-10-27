using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using WebApiReferenceImpl.Core.Reflection;

namespace WebApiReferenceImpl.Core.Extensions
{
    public static class BasicExtensions
    {
        public static bool In<T>(this T stringValue, IEnumerable<T> values)
        {
            return values.Any(value => stringValue.Equals(value));
        }

        public static bool In<T>(this T stringValue, params T[] values)
        {
            return values.Any(value => stringValue.Equals(value));
        }

        public static bool NotIn<T>(this T stringValue, IEnumerable<T> values)
        {
            return !In(stringValue, values);
        }

        public static bool NotIn<T>(this T stringValue, params T[] values)
        {
            return !In(stringValue, values);
        }

        public static DataTable ToDataTable<T>(this IList<T> data)
        {
            PropertyDescriptorCollection props = TypeDescriptor.GetProperties(typeof (T));

            DataTable table = new DataTable();
            for (int i = 0; i < props.Count; i++)
            {
                PropertyDescriptor prop = props[i];
                table.Columns.Add(prop.Name, prop.PropertyType);
            }
            object[] values = new object[props.Count];
            foreach (T item in data)
            {
                for (int i = 0; i < values.Length; i++)
                {
                    values[i] = props[i].GetValue(item);
                }
                table.Rows.Add(values);
            }
            return table;
        }

        public static string ToFormat(this string stringFormat, params object[] args)
        {
            return String.Format(stringFormat, args);
        }

        public static bool IsInRange(this int intValue, int min, int max)
        {
            return intValue >= min && intValue <= max;
        }

        public static bool IsInRange(this double val, double min, double max)
        {
            return val >= min && val <= max;
        }

        public static bool IsInRange(this DateTime val, DateTime min, DateTime max)
        {
            return val >= min && val <= max;
        }

        public static bool IsNotInRange(this int intValue, int min, int max)
        {
            return !intValue.IsInRange(min, max);
        }

        public static int GetAsZeroIfNull(this int? value)
        {
            return value.HasValue ? value.Value : 0;
        }

        public static double GetAsZeroIfNull(this double? value)
        {
            return value.HasValue ? value.Value : 0;
        }

        public static VALUE Get<KEY, VALUE>(this IDictionary<KEY, VALUE> dictionary, KEY key)
        {
            return dictionary.Get(key, default(VALUE));
        }

        public static VALUE Get<KEY, VALUE>(this IDictionary<KEY, VALUE> dictionary, KEY key, VALUE defaultValue)
        {
            if (dictionary.ContainsKey(key)) return dictionary[key];
            return defaultValue;
        }

        public static string GetViewModelProperty<VIEWMODEL>(this IDictionary<string, object> dictionary,
                                                             Expression<Func<VIEWMODEL, object>> expression)
        {
            string key = ReflectionHelper.GetProperty(expression).Name;
            if (dictionary.ContainsKey(key)) return dictionary[key].ToString();
            return string.Empty;
        }

        public static IEnumerable<T> Each<T>(this IEnumerable<T> values, Action<T> eachAction)
        {
            foreach (var item in values) eachAction(item);

            return values;
        }

        public static IEnumerable Each(this IEnumerable values, Action<object> eachAction)
        {
            foreach (var item in values) eachAction(item);

            return values;
        }

        public static bool IsNullable(this Type theType)
        {
            return (!theType.IsValueType) || theType.IsNullableOfT();
        }

        public static bool IsNullableOfT(this Type theType)
        {
            return theType.IsGenericType && theType.GetGenericTypeDefinition().Equals(typeof (Nullable<>));
        }

        public static bool IsNullableOf(this Type theType, Type otherType)
        {
            return theType.IsNullableOfT() && theType.GetGenericArguments()[0].Equals(otherType);
        }

        public static IList<T> AddMany<T>(this IList<T> list, params T[] items)
        {
            return list.AddRange(items);
        }

        public static IList<T> AddRange<T>(this IList<T> list, IEnumerable<T> items)
        {
            items.Each(list.Add);
            return list;
        }

        public static U ValueOrDefault<T, U>(this T root, Expression<Func<T, U>> expression) where T : class
        {
            if (root == null)
            {
                return default(U);
            }

            var accessor = ReflectionHelper.GetAccessor(expression);

            object result = accessor.GetValue(root);

            return (U) (result ?? default(U));
        }

        public static int OnesDigit(this int val)
        {
            val = System.Math.Abs(val);

            return val%10;
        }

        /// <remarks>Could be made more efficient</remarks>
        public static int TensDigit(this int val)
        {
            val = System.Math.Abs(val);

            var str = val.ToString();

            if (str.Length > 1) return str.Substring(str.Length - 2, 1).To<int>();
            else return 0;
        }

        /// <remarks>Could be made more efficient</remarks>
        public static int HundredsDigit(this int val)
        {
            var str = val.ToString();

            if (str.Length > 2) return str.Substring(str.Length - 3, 1).To<int>();
            else return 0;
        }
    }
}
