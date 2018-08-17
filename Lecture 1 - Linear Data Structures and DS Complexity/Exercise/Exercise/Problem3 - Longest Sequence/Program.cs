using System;
using System.Linq;
using System.Collections.Generic;

namespace Problem3___Longest_Sequence
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> nums = new List<int>();
            nums = Console.ReadLine().Split(' ').Select(int.Parse).ToList();

            List<int> longestSequence = new List<int>();
            int element = nums[0];
            int elementCount = 0;

            int longestSequenceElement = 0;
            int longestSequenceElementCount = 0;

            for (int i = 0; i < nums.Count(); i++)
            {
                if (nums[i] == element)
                {
                    elementCount++;
                }
                else
                {
                    if (elementCount > longestSequenceElementCount)
                    {
                        longestSequenceElementCount = elementCount;
                        longestSequenceElement = element;

                    }
                    element = (nums[i]);
                    elementCount = 1;
                }
            }

            if (elementCount > longestSequenceElementCount)
            {
                longestSequenceElementCount = elementCount;
                longestSequenceElement = element;
            }

            for (int i = 0; i < longestSequenceElementCount; i++)
            {
                longestSequence.Add(longestSequenceElement);
            }
            Console.WriteLine(String.Join(" ", longestSequence));
        }
    }
}
