using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_4___Remove_Odd
{
    class Program
    {
        static void Main(string[] args)
        {
            int [] nums = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            Dictionary<int, int> dict = new Dictionary<int, int>();
            foreach (var num in nums)
            {
                if (dict.ContainsKey(num)==false)
                {
                    dict[num] = 1;
                }else
                {
                    dict[num]++;
                }
            }

            var filter = dict.Where(a => a.Value % 2 != 1).Select(a => a.Key).ToArray();

            var result = String.Join(" ", nums.Where(n => filter.Contains(n)).ToArray());
            Console.WriteLine(result);
        }
    }
}
