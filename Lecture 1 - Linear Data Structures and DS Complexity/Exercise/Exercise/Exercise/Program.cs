using System;
using System.Linq;
using System.Collections.Generic;

namespace Exercise
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> nums = new List<int>();
            nums = Console.ReadLine().Split(' ').Select(a => int.Parse(a)).ToList();
            int sum = nums.Sum();
            double avg = nums.Sum() / (double)nums.Count();
            Console.WriteLine($"Sum={sum}; Average={avg:f2}");
        }
    }
}
