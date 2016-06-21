using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfiniteLinq
{
    /// <summary>
    /// Extension methods for IEnumerable,
    /// extending LINQ.
    /// </summary>
    public static class LinqExtensions
    {
        /// <summary>
        /// Prints this collection to the console,
        /// one item per line.
        /// </summary>
        public static void PrintToConsole(this IEnumerable e)
        {
            foreach (var item in e)
                Console.WriteLine(item);
        }

        /// <summary>
        /// Reduces a stream of 2-tuple of 2-tuple and value to
        /// a stream of 3-tuples, like this: ((a,b),c) --> (a,b,c)
        /// </summary>
        public static IEnumerable<Tuple<T1, T2, T3>> FlattenTuples<T1, T2, T3>(this IEnumerable<Tuple<Tuple<T1, T2>, T3>> e)
        {
            foreach (var item in e)
            {
                yield return Tuple.Create(item.Item1.Item1, item.Item1.Item2, item.Item2);
            }
        }

        /// <summary>
        /// Returns the prime numbers of the given seqence using
        /// an implicit sieve of erathothenes.
        /// </summary>
        public static IEnumerable<int> Primes(this IEnumerable<int> e)
        {
            int p = e.First(); //this is prime
            yield return p;

            foreach (var item in Primes(e.Skip(1).Where(x => x % p != 0)))
                yield return item;
        }
    }
}
