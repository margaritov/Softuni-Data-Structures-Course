using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem7__Labyrinth
{
    class Program
    {
        class Position
        {
            public Position(int row = -1, int col = -1)
            {
                this.Row = row;
                this.Col = col;
            }
            public int Row { set; get; }
            public int Col { set; get; }
        }

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string[,] lab = new string[n, n];

            for (int row = 0; row < n; row++)
            {
                char[] line = Console.ReadLine().ToCharArray();
                for (int col = 0; col < n; col++)
                {
                    lab[row, col] = line[col].ToString();
                }
            }

            Position start = FindStart(lab);
            Position current = new Position();
            int currentSteps = 0;

            Queue<Position> pending = new Queue<Position>();
            pending.Enqueue(start);

            while (pending.Any())
            {
                current = pending.Dequeue();
                if (lab[current.Row, current.Col] == "*")
                {
                    currentSteps = 0;
                }
                else
                {
                    currentSteps = int.Parse(lab[current.Row, current.Col]);
                }

                //up
                if (current.Row > 0 && lab[current.Row - 1, current.Col] == "0")
                {
                    lab[current.Row - 1, current.Col] = (currentSteps + 1).ToString();
                    pending.Enqueue(new Position(current.Row - 1, current.Col));

                }

                //right
                if (current.Col + 1 < lab.GetLength(1) && lab[current.Row, current.Col + 1] == "0")
                {
                    lab[current.Row, current.Col + 1] = (currentSteps + 1).ToString();
                    pending.Enqueue(new Position(current.Row, current.Col + 1));
                }

                //down
                if (current.Row + 1 < lab.GetLength(0) && lab[current.Row + 1, current.Col] == "0")
                {
                    lab[current.Row + 1, current.Col] = (currentSteps + 1).ToString();
                    pending.Enqueue(new Position(current.Row + 1, current.Col));
                }

                //left
                if (current.Col > 0 && lab[current.Row, current.Col - 1] == "0")
                {
                    lab[current.Row, current.Col - 1] = (currentSteps + 1).ToString();
                    pending.Enqueue(new Position(current.Row, current.Col - 1));
                }
            }
            PrintMatrix(lab);
            Console.WriteLine();
        }

        private static void PrintMatrix(string[,] lab)
        {
            for (int row = 0; row < lab.GetLength(0); row++)
            {
                for (int col = 0; col < lab.GetLength(1); col++)
                {
                    if (lab[row, col] == "0")
                    {
                        lab[row, col] = "u";
                    }
                    Console.Write(lab[row, col]);
                }
                Console.WriteLine();
            }
        }

        private static Position FindStart(string[,] lab)
        {
            Position start = new Position();
            for (int row = 0; row < lab.GetLength(0); row++)
            {
                for (int col = 0; col < lab.GetLength(1); col++)
                {
                    if (lab[row, col] == "*")
                    {
                        start.Row = row;
                        start.Col = col;
                        return start;
                    }
                }
            }
            return start;
        }
    }
}
