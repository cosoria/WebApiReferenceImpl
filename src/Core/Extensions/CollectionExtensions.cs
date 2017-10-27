using System.Collections.Generic;

namespace WebApiReferenceImpl.Core.Extensions
{
    public static class CollectionExtensions
    {
        public static ICollection<T> AddRange<T>(this ICollection<T> collection, IEnumerable<T> items)
        {
            Ensure.Argument.NotNull(() => collection);
            Ensure.Argument.NotNull(() => items);
            
            foreach (var item in items)
            {
                collection.Add(item);
            }
            return collection;
        }


        public static ICollection<T> RemoveRange<T>(this ICollection<T> collection, IEnumerable<T> items)
        {
            Ensure.Argument.NotNull(() => collection);
            Ensure.Argument.NotNull(() => items);

            foreach (var item in items)
            {
                collection.Remove(item);
            }

            return collection;
        }


        public static bool IsEmpty<T>(this ICollection<T> self)
        {
            Ensure.Argument.NotNull(self);
            
            return self.Count == 0;
        }
    }
}