using System;

public class CircularQueue<T>
{
    private class Node
    {
        public Node Next { set; get; }
        public T Value { set; get; }
        public Node()
        {

        }
        public Node(T value)
        {
            this.Value = value;
        }
    }
    private T[] items;
    private const int DefaultCapacity = 4;
    public int Count { get; private set; }
    private int Tail;
    private int Head;

    public CircularQueue(int capacity = DefaultCapacity)
    {
        this.items = new T[capacity];
        this.Count = 0;
        this.Head = 0;
        this.Tail = 0;
    }

    public void Enqueue(T element)
    {
        if (this.Count == this.items.Length)
        {
            this.Resize();
        }
        if (this.Count == 0)
        {
            this.Head = 0;
            this.Tail = 0;
            this.items[Count++] = element;
        }
        else
        if (this.Tail < this.items.Length - 1)
        {
            this.Tail++;
            this.items[Tail] = element;
            this.Count++;
        }
        else
        {
            this.Tail = 0;
            this.items[Tail] = element;
        }
    }

    private void Resize()
    {
        T[] newItems = new T[this.items.Length * 2];
        CopyAllElements(newItems);
        this.Head = 0;
        this.Tail = this.Count-1;
        this.items = newItems;
    }

    private void CopyAllElements(T[] newArray)
    {
        int index = this.Head;
        for (int i = 0; i < this.Count; i++)
        {
            newArray[i] = this.items[index++];
            if (index == this.items.Length)
            {
                index = 0;
            }
        }

    }

    // Should throw InvalidOperationException if the queue is empty
    public T Dequeue()
    {
        if (this.Count == 0)
        {
            throw new InvalidOperationException();
        }
        T result = this.items[Head];

        if (Head == this.items.Length)
        {
            this.Head = 0;
        }
        else
        {
            this.Head++;
        }
        this.Count--;
        return result;

    }

    public T[] ToArray()
    {
        T[] result = new T[this.Count];
        int index = this.Head;
        for (int i = 0; i < this.Count; i++)
        {
            result[i] = this.items[index++];
            if (index == this.items.Length)
            {
                index = 0;
            }
        }
        return result;
    }
}


public class Example
{
    public static void Main()
    {

        CircularQueue<int> queue = new CircularQueue<int>();

        queue.Enqueue(1);
        queue.Enqueue(2);
        queue.Enqueue(3);
        queue.Enqueue(4);
        queue.Enqueue(5);
        queue.Enqueue(6);

        Console.WriteLine("Count = {0}", queue.Count);
        Console.WriteLine(string.Join(", ", queue.ToArray()));
        Console.WriteLine("---------------------------");

        int first = queue.Dequeue();
        Console.WriteLine("First = {0}", first);
        Console.WriteLine("Count = {0}", queue.Count);
        Console.WriteLine(string.Join(", ", queue.ToArray()));
        Console.WriteLine("---------------------------");

        queue.Enqueue(-7);
        queue.Enqueue(-8);
        queue.Enqueue(-9);
        Console.WriteLine("Count = {0}", queue.Count);
        Console.WriteLine(string.Join(", ", queue.ToArray()));
        Console.WriteLine("---------------------------");

        first = queue.Dequeue();
        Console.WriteLine("First = {0}", first);
        Console.WriteLine("Count = {0}", queue.Count);
        Console.WriteLine(string.Join(", ", queue.ToArray()));
        Console.WriteLine("---------------------------");

        queue.Enqueue(-10);
        Console.WriteLine("Count = {0}", queue.Count);
        Console.WriteLine(string.Join(", ", queue.ToArray()));
        Console.WriteLine("---------------------------");

        first = queue.Dequeue();
        Console.WriteLine("First = {0}", first);
        Console.WriteLine("Count = {0}", queue.Count);
        Console.WriteLine(string.Join(", ", queue.ToArray()));
        Console.WriteLine("---------------------------");
    }
}
