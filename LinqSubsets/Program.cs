using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace LinqSubsets
{
    class Program
    {
        static void Main(string[] args)
        {
            const int target = 20;
            var numbers = new int[] { 1, 2, 5, 8, 12, 14, 9 };

            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            var matches = numbers.GetSubsets().Where(s => s.Sum() == target).ToArray();

            stopWatch.Stop();
            Console.WriteLine($"Elapsed time: {stopWatch.Elapsed}");

            foreach (var match in matches) Console.WriteLine(match.Select(m => m.ToString()).Aggregate((a, n) => $"{a} + {n}") + $" = {target}");

            Console.WriteLine($"Number of Combinations: {matches.Length}");
            Console.ReadKey();
        }
    }

    public static class Extension
    {
        public static IEnumerable<IEnumerable<T>> GetSubsets<T>(this IEnumerable<T> collection)
        {
            if (!collection.Any()) return Enumerable.Repeat(Enumerable.Empty<T>(), 1);
            var element = collection.Take(1);
            var ignoreFirstSubsets = GetSubsets(collection.Skip(1));
            var subsets = ignoreFirstSubsets.Select(set => element.Concat(set));
            return subsets.Concat(ignoreFirstSubsets);
        }
    }
}
