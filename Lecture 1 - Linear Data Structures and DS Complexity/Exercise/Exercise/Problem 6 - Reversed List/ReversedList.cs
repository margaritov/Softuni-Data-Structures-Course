using System;
using System.Collections;
using System.Collections.Generic;

public class ReversedList<T> : IEnumerable<T>
{
    private const int InitialCapacity = 2;
    private T[] items;

    public ReversedList()
    {
        this.items = new T[InitialCapacity];
    }

    public int Count { get; private set; }

    public int Capacity { get; private set; }

    private void isValidIndex(int index)
    {
        if (index < 0 || index >= this.Count)
        {
            throw new ArgumentOutOfRangeException();
        }
    }

    public T this[int index]
    {
        get
        {
            int reversedIndex = this.Count - index - 1;
            isValidIndex(reversedIndex);

            return this.items[reversedIndex];
        }

        set
        {
            int reversedIndex = this.Count - index - 1;
            isValidIndex(reversedIndex);

            this.items[reversedIndex] = value;
        }
    }

    public void Add(T item)
    {
        if (this.Count == this.items.Length)
        {
            this.Resize();
        }
        this.items[Count++] = item;
    }

    private void Resize()
    {

        T[] newArray = new T[this.Count * 2];
        for (var i = 0; i < Count; i++)
        {
            newArray[i] = this.items[i];
        }
        this.Capacity = this.Count * 2;
        this.items = newArray;
    }

    public void RemoveAt(int index)
    {

        int reversedIndex = this.Count - index - 1;
        isValidIndex(reversedIndex);

        for (int i = reversedIndex; i < this.Count - 1; i++)
        {
            this.items[i] = this.items[i + 1];
        }
        this.Count--;
    }

    public IEnumerator<T> GetEnumerator()
    {
        for (int i = this.Count - 1; i >= 0; i--)
        {
            yield return items[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }

}




