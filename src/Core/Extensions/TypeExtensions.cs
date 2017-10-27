using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace WebApiReferenceImpl.Core.Extensions
{
    public static class TypeExtensions
    {
        public static T[] GetAttributes<T>(this ICustomAttributeProvider target, bool inherit) where T : Attribute
        {
            if (target.IsDefined(typeof(T), inherit))
            {
                return target
                    .GetCustomAttributes(typeof(T), inherit)
                    .Cast<T>()
                    .ToArray();
            }
            
            return new T[0];
        }

        public static T GetAttribute<T>(this ICustomAttributeProvider target, bool inherit) where T : Attribute
        {
            if (target.IsDefined(typeof(T), inherit))
            {
                var attributes = target.GetCustomAttributes(typeof(T), inherit);
                if (attributes.Length > 1)
                {
                    throw new InvalidOperationException("More than one attribute is declared");
                }
                return (T)attributes[0];
            }
            return null;
        }
       
        public static IEnumerable<Type> MarkedWith<T>(this IEnumerable<Type> types, bool inherit) where T : Attribute
        {
            return types.Where(type => (!type.IsAbstract) && type.IsDefined(typeof(T), inherit));
        }
    }
}