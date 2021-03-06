﻿using System;

namespace WebApiReferenceImpl.Core.Utils
{
    public class ArrayUtil
    {
        /// <summary>
        /// Returns <em>True</em> if the provided array is null or empty
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        public static bool IsNullOrEmpty(Array array)
        {
            return array == null || array.Length == 0;
        }

        /// <summary>
        /// Empty array of <see cref="Guid"/>
        /// </summary>
        public static readonly Guid[] EmptyGuid = Empty<Guid>();
        /// <summary>
        /// Empty array of <see cref="int"/>
        /// </summary>
        public static readonly int[] EmptyInt32 = Empty<int>();
        /// <summary>
        /// Empty array of <see cref="string"/>
        /// </summary>
        public static readonly string[] EmptyString = Empty<string>();

        /// <summary>
        /// Returns empty array instance
        /// </summary>
        /// <typeparam name="T">type of the item for the array</typeparam>
        /// <returns>empty array singleton</returns>
        public static T[] Empty<T>()
        {
            return ArrayUtil<T>.Empty;
        } 
    }

    static class ArrayUtil<T>
    {
        internal static readonly T[] Empty = new T[0];
    }
}