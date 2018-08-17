using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem2___Sort_Words
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> words = Console.ReadLine().Split(' ').ToList();
            words.Sort();
            Console.WriteLine(String.Join(" ", words));
        }
    }
}
