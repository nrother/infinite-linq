using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfiniteLinq
{
    class Program
    {
        static void Main(string[] args)
        {
            EnumerableEx.InfiniteRange(1).Take(10).PrintToConsole(); //Simple

            Console.WriteLine();

            EnumerableEx.InfiniteRange(2).Primes().Take(20).PrintToConsole(); //Sieve of Erathothenes!

            Console.WriteLine();

            //Tuples (SelectMany is kind of a cross join)
            Enumerable.Range(1, 5).SelectMany(x => Enumerable.Range(1, 5).Select(y => Tuple.Create(x, y))).PrintToConsole();

            Console.WriteLine();

            //Easier to read using this form of LINQ
            (from x in Enumerable.Range(1, 5)
             from y in Enumerable.Range(1, 5)
             select new Tuple<int, int>(x, y)).PrintToConsole();

            Console.WriteLine();

            //Works with infinite enumerables, but will yield (1,1)..(1, 10), not (1,1),(1,2),(2,1) or such
            (from x in EnumerableEx.InfiniteRange(1)
             from y in EnumerableEx.InfiniteRange(1)
             select new Tuple<int, int>(x, y)).Take(10).PrintToConsole();

            Console.WriteLine();

            //this does handle inifinite sequences correctly:
            EnumerableEx.ZipTuple(EnumerableEx.InfiniteRange(1), EnumerableEx.InfiniteRange(1)).Take(20).PrintToConsole();

            Console.WriteLine();

            //so lets compute the first few pythagorean triples: http://en.wikipedia.org/wiki/Pythagorean_triple
            EnumerableEx.ZipTuple(EnumerableEx.ZipTuple(EnumerableEx.InfiniteRange(1), EnumerableEx.InfiniteRange(1)), EnumerableEx.InfiniteRange(1)).FlattenTuples().Where(
                t =>
                {
                    int x = t.Item1;
                    int y = t.Item2;
                    int z = t.Item3;
                    return x * x + y * y == z * z;
                }).Take(20).PrintToConsole();

            Console.WriteLine();

            Console.WriteLine("Press any key to exit.");
            Console.ReadKey(true);
        }
    }
}
