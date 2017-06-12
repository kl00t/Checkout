using System.Collections.Generic;
using System.Linq;

namespace Checkout.Core.Extensions
{
    public static class Extensions
    {
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
