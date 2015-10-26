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

            foreach (var s in subsets) Console.WriteLine(s);
            Console.WriteLine($"Number of Combinations: {subsets.Count()}");
            Console.ReadKey();
        }

        static IEnumerable<string> GetSubsets(int[] array, int target)
        {
            Array.Sort((Array) array);
            List<string> result = new List<string>();
 
            for (int i = 0; i < array.Length; i++)
            {   
                
                for (int j = array.Length - 1; j > i; j--)
                {
                    var sum = 0;
                    string eq = $"{array[i]} + {array[j]}";
                    var consistent = true;
                    var addToSum = 0;

                    if (sum + array[j] == target) continue;
                    sum = array[i] + array[j];
                    
                    while (sum != target)
                    {
                        var remains = target - sum;
                        if (remains == 0) break;
                        if (sum > target)
                        {
                            consistent = false;
                            break;
                        }

                        var next = Array.BinarySearch(array, i + 1 < array.Length ? i + 1 : i, j - i, remains);

                        next = next < 0 ? -(next + 2) : next;
                        
                        if (next == i || next == j || array[next] == addToSum)
                        {
                            consistent = false;
                            break;
                        }
                        addToSum = array[next];

                        sum += addToSum;
                        eq += $" + {addToSum}";
                    }

                    if (!consistent) continue;
                    result.Add($"{eq} = {target}");
                }
            }
            return result;
        }

       
    }
}
