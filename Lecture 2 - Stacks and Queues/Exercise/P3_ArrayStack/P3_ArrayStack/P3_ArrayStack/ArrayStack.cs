using System;
using System.Collections.Generic;
using System.Linq;

public class ArrayStack<T>
{
    private T[] elements;
    public int Count { get; private set; }
    private const int InitialCapacity = 16;
    public ArrayStack(int capacity = InitialCapacity)
    {
        this.elements = new T[capacity];
    }
    public void Push(T element)
    {
        if (this.Count == this.elements.Length)
        {
            this.Grow();
        }
        this.elements[Count++] = element;
    }
    public T Pop()
    {
        if (this.Count == 0)
        {
            throw new InvalidOperationException();
        }

        return this.elements[Count--];
    }
    public T[] ToArray()
    {
        T[] result = new T[this.Count];
        for (int i = 0; i < this.Count; i++)
        {
            result[i] = this.elements[i];
        }
        return result;
    }
    private void Grow()
    {
        T[] newElements = new T[this.Count * 2];
        for (int i = 0; i < this.Count; i++)
        {
            newElements[i] = this.elements[i];
        }
        this.elements = newElements;
    }
}