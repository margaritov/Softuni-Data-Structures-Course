using System;
using System.Collections;
using System.Collections.Generic;

public class DoublyLinkedList<T> : IEnumerable<T>
{

    private class ListNode<T>
    {
        public T Value { get; private set; }
        public ListNode<T> NextNode { set; get; }
        public ListNode<T> PrevNode { set; get; }
        public ListNode(T value)
        {
            this.Value = value;
        }
    }

    private ListNode<T> Head;
    private ListNode<T> Tail;
    public int Count { get; private set; }

    public void AddFirst(T element)
    {
        if (this.Count == 0)
        {
            this.Head = new ListNode<T>(element);
            this.Tail = this.Head;
        }
        else
        {
            var newHead = new ListNode<T>(element);
            newHead.NextNode = this.Head;
            this.Head.PrevNode = newHead;
            this.Head = newHead;
        }
        this.Count++;
    }

    public void AddLast(T element)
    {
        if (Count == 0)
        {
            this.AddFirst(element);
        } else
        {
            //var oldTail = this.Tail;
            var newTail = new ListNode<T>(element);
            this.Tail.NextNode = newTail;
            newTail.PrevNode = this.Tail;
            this.Tail = newTail;
            this.Count++;

        }
    }

    public T RemoveFirst()
    {
        var result = this.Head;
       if (this.Count ==0)
        {
            throw new InvalidOperationException();
        }
       else if (this.Count==1)
        {
            this.Head = null;
            this.Tail = null;
        } else
        {
            this.Head = this.Head.NextNode;
            this.Head.PrevNode = null;
        }
        this.Count--;
        return result.Value;
    }

    public T RemoveLast()
    {
        var result = this.Tail;

        if (this.Count == 0)
        {
            throw new InvalidOperationException();
        }
        else if (this.Count == 1)
        {
            this.Head = null;
            this.Tail = null;
        }
        else
        {
            this.Tail = this.Tail.PrevNode;
            this.Tail.NextNode = null;
        }
        this.Count--;
        return result.Value;
    }

    public void ForEach(Action<T> action)
    {
        var currentNode = this.Head;
        while (currentNode!=null)
        {
            action(currentNode.Value);
            currentNode = currentNode.NextNode;
        }

    }

    public IEnumerator<T> GetEnumerator()
    {
        var current = this.Head;
        while (current != null)
        {
            yield return current.Value;
            current = current.NextNode;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }

    public  T[] ToArray()
    {
        T[] result = new T[this.Count];
        var currentNode = this.Head;
        for (int i=0; i < this.Count; i++)
        {
            result[i] = currentNode.Value;
            currentNode = currentNode.NextNode;
        }

        return result;
    }
}


class Example
{
    static void Main()
    {
        var list = new DoublyLinkedList<int>();

        list.ForEach(Console.WriteLine);
        Console.WriteLine("--------------------");

        list.AddLast(5);
        list.AddFirst(3);
        list.AddFirst(2);
        list.AddLast(10);
        Console.WriteLine("Count = {0}", list.Count);

        list.ForEach(Console.WriteLine);
        Console.WriteLine("--------------------");

        list.RemoveFirst();
        list.RemoveLast();
        list.RemoveFirst();

        list.ForEach(Console.WriteLine);
        Console.WriteLine("--------------------");

        list.RemoveLast();

        list.ForEach(Console.WriteLine);
        Console.WriteLine("--------------------");
    }
}
