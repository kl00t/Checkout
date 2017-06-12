using System.Collections.Generic;
using System.Linq;

namespace Checkout.Core.Extensions
{
    /// <summary>
    /// Extensions class for lists.
    /// </summary>
    public static class Extensions
    {
        /// <summary>
        /// Splits the items.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source">The source.</param>
        /// <param name="chunksize">The chunksize.</param>
        /// <returns>Returns a grouped list of items.</returns>
        public static IEnumerable<IEnumerable<T>> SplitItems<T>(this IEnumerable<T> source, int chunksize)
        {
            while (source.Any())
            {
                yield return source.Take(chunksize);
                source = source.Skip(chunksize);
            }
        }
    }
}