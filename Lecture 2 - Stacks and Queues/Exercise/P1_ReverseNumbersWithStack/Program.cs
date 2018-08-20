using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static void Main(string[] args)
    {
        var nums = Console.ReadLine().Split().Select(int.Parse);
        var stack = new Stack<int>();
        foreach (var num in nums)
        {
            stack.Push(num);
        }
        Console.WriteLine(String.Join(" ", stack.ToArray()));

    }
}

