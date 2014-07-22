using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfiniteLinq
{
    /// <summary>
    /// Generators for infinite sequences, meant as an extension
    /// to the Enumerable-class.
    /// </summary>
    public static class EnumerableEx
    {
        public static IEnumerable<int> InfiniteRange(int start, int step = 1)
        {
            int current = start;
            while (true)
            {
                yield return current;
                current += step;
            }
        }

        public static IEnumerable<long> InfiniteRange(long start, long step = 1)
        {
            long current = start;
            while (true)
            {
                yield return current;
                current += step;
            }
        }

        //and so on for double, float, etc...

        public static IEnumerable<Tuple<T1, T2>> ZipTuple<T1, T2>(IEnumerable<T1> seq1, IEnumerable<T2> seq2)
        {
            //both sequences might be infinite, but Cantor has found a solution to this: http://en.wikipedia.org/wiki/Pairing_function

            //var enum1 = seq1.GetEnumerator();

            int seq1cnt = 0;
            var e0 = seq1.GetEnumerator();
            while(e0.MoveNext())
            {
                seq1cnt++;
                var e1 = seq1.Take(seq1cnt).Reverse().GetEnumerator();
                var e2 = seq2.GetEnumerator();
                while(e1.MoveNext() && e2.MoveNext())
                {
                    yield return Tuple.Create(e1.Current, e2.Current);
                }

            }
        }
    }
}
