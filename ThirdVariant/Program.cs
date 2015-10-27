using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThirdVariant
{
    class Program
    {
        static void Main(string[] args)
        {
            const int target = 20;
            var numbers = new [] { 1, 2, 5, 8, 12, 14, 9 };
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            var result = GetSubsets(numbers, target, "");

            stopWatch.Stop();
            Console.WriteLine($"Elapsed time: {stopWatch.Elapsed.TotalMilliseconds}");

            foreach (var subset in result) Console.WriteLine($"{subset} = {target}");
            Console.WriteLine($"Number of Combinations: {result.Count()}");
            Console.ReadLine();
        }

        public static IEnumerable<string> GetSubsets(int[] set, int sum, string values)
        {
            for (var i = 0; i < set.Length; i++)
            {
                var left = sum - set[i];
                var vals = values != "" ? $"{set[i]} + {values}" : $"{set[i]}";
                if (left == 0) yield return vals;
                else
                {
                    int[] possible = set.Take(i).Where(n => n <= sum).ToArray();
                    if (possible.Length <= 0) continue;
                    foreach (string s in GetSubsets(possible, left, vals)) yield return s;
                }
            }
        }
    }
}
