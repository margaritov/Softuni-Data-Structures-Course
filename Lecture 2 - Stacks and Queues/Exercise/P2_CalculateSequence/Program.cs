using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static void Main(string[] args)
    {
        var q = new Queue<int>();
        int n = int.Parse(Console.ReadLine());
        int cnt = 0;
        q.Enqueue(n);
        var result = new Queue<int>();
        while (result.Count < 50)
        {
            var a = q.Dequeue();
            result.Enqueue(a);
            q.Enqueue(a + 1);

            q.Enqueue(2 * a + 1);
            q.Enqueue(a + 2);
            cnt += 2;
        }
        Console.WriteLine(String.Join(", ", result.ToArray()));
    }
}

