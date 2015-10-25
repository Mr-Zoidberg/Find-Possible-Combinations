using System;
using System.Collections.Generic;
using System.Linq;

namespace FindSum20
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = new List<int> { 12, 6, 5, 4, 7, 9, 3, 1, 3, 10, 12, 3, 9, 8, 4, 5, 7, 10 };
            Console.WriteLine($"Number of Combinations: {SumCounter(numbers, 20)}");
            Console.ReadKey();
        }

       
        private static int SumCounter(IReadOnlyList<int> numbers, int target)
        {
            var result = 0;
            RecursiveCounter(numbers, target, new List<int>(), ref result);
            return result;
        }

        private static void RecursiveCounter(IReadOnlyList<int> numbers, int target, List<int> partial, ref int result)
        {
            var sum = partial.Sum();
            if (sum == target)
            {
                result++;
                Console.WriteLine(string.Join(" + ", partial.ToArray()) + " = " + target);
            }

            if (sum >= target)
                return;

            for (var i = 0; i < numbers.Count; i++)
            {
                var remaining = new List<int>();
                var n = numbers[i];
                for (var j = i + 1; j < numbers.Count; j++) remaining.Add(numbers[j]);

                var partRec = new List<int>(partial) {n};
                RecursiveCounter(remaining, target, partRec, ref result);
            }
        }
    }

}

