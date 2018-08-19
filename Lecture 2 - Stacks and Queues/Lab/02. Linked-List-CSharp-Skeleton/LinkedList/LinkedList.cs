using System;
using System.Collections;
using System.Collections.Generic;

public class LinkedList<T> : IEnumerable<T>
{
    public class Node
    {
        public T Value { set; get; }
        public Node Next { set; get; }
        public Node(T value)
        {
            this.Value = value;
        }

    }
    public int Count { get; private set; }
    public Node Head { get; private set; }
    public Node Tail { get; private set; }


    public void AddFirst(T item)
    {
        Node temp = new Node(item);

        if (this.Count == 0)
        {
            this.Head = temp;
            this.Tail = temp;
        }
        else
        {
            Node oldHead = this.Head;
            temp.Next = oldHead;
            this.Head = temp;
        }
        this.Count++;

    }

    public void AddLast(T item)
    {
        Node newTail = new Node(item);
        if (this.Count == 0)
        {
            this.Head = newTail;
            this.Tail = newTail;
        }
        else
        {
            Node oldTail = this.Tail;
            oldTail.Next = newTail;
            this.Tail = newTail;
        }
        this.Count++;
    }

    public T RemoveFirst()
    {
        this.isEmpty();

        Node oldHead = this.Head;
        if (this.Count == 1)
        {
            this.Head = null;
            this.Tail = null;
            Count = 0;
        }
        else
        {
            this.Count--;

            
            if (this.Count == 0)
            {
                this.Tail.Next = null;
            } else
            {
                this.Head = this.Head.Next;
            }
        }
        
        
        return oldHead.Value;
    }



    public T RemoveLast()
    {
        isEmpty();
        Node oldTail = this.Tail;
        if (this.Count == 1)
        {
            this.Head = null;
            this.Tail = null;
            this.Count = 0;
        }
        else
        {

            Node current = this.Head;
            while (current.Next != this.Tail)
            {
                current = current.Next;
            }

            current.Next = null;

            this.Tail = current;
            this.Count--;


        }
        return oldTail.Value;
    }

    private void isEmpty()
    {
        if (this.Count == 0) { throw new InvalidOperationException(); }
    }

    public IEnumerator<T> GetEnumerator()
    {
        Node current = this.Head;
        while (current != null)
        {
            yield return current.Value;
            current = current.Next;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
}
