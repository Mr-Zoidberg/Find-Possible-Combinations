using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearch
{
    class Program
    {
        static void Main(string[] args)
        {
            const int target = 20;
            var numbers = new [] { 1, 2, 5, 8, 12, 14, 9 };

            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            var subsets = GetSubsets(numbers, target);

            stopWatch.Stop();
            Console.WriteLine($"Elapsed time: {stopWatch.Elapsed.TotalMilliseconds}");

            foreach (var s in subsets) Console.WriteLine($"{s} = {target}");
            Console.WriteLine($"Number of Combinations: {subsets.Count()}");
            Console.ReadKey();
        }


        private static IEnumerable<string> GetSubsets(int[] array, int target)
        {      
            Array.Sort((Array)array);
            List<string> result = new List<string>();

            for (int i = array.Length-1; i >= 0; i--)
            {
                var eq = $"{array[i]}";
                var sum = array[i];
                var toAdd = 0;

                while (sum != target)
                {
                    var mid = Array.BinarySearch(array, 0, sum <= target / 2 && sum != array[i] ? array.Length - 1 : i, target - sum);
                    mid = mid < 0 ? ~mid - 1 : mid;
                    if (mid == i  || mid < 0 || toAdd == array[mid] ) break;

                    toAdd = array[mid];
                    sum += array[mid];
                    eq += $" + {array[mid]}";
                    if (sum == target) result.Add(eq);
                }
            }
            return result;
        }
    }
}
