using System;
using System.Linq;
using System.Collections.Generic;

namespace Problem_5___Occurences
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            Dictionary<int, int> dict = new Dictionary<int, int>();
            foreach (var num in nums)
            {
                if (dict.ContainsKey(num) == false)
                {
                    dict[num] = 1;
                }
                else
                {
                    dict[num]++;
                }
            }

            foreach (var item in dict.OrderBy(a => a.Key))
            {
                Console.WriteLine($"{item.Key} -> {item.Value} times");
            }
            Console.WriteLine();
        }
    }
}
