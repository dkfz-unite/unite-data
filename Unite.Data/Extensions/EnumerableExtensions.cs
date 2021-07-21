using System;
using System.Collections.Generic;
using System.Linq;

namespace Unite.Data.Extensions
{
    public static class EnumerableExtensions
    {
        /// <summary>
        /// Executes given action for each element of collection
        /// </summary>
        /// <typeparam name="T">Element type</typeparam>
        /// <param name="items">Source collection of elements</param>
        /// <param name="action">Action to execute</param>
        public static void ForEach<T>(this IEnumerable<T> items, Action<T> action)
        {
            foreach (var item in items)
            {
                action.Invoke(item);
            }
        }

        /// <summary>
        /// Selects unique elements of collection by given property
        /// </summary>
        /// <typeparam name="T">Element type</typeparam>
        /// <typeparam name="TProp">Property type</typeparam>
        /// <param name="items">Source collection of elements</param>
        /// <param name="property">Property selector</param>
        /// <returns>Unique elements of collection selected by given property.</returns>
        public static IEnumerable<T> DistinctBy<T, TProp>(this IEnumerable<T> items, Func<T, TProp> property)
            where T : class
        {
            return items
                .GroupBy(property)
                .Select(group => group.First());
        }
    }
}
