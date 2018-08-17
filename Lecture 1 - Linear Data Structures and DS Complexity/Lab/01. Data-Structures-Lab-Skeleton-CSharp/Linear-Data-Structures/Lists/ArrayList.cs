using System;

public class ArrayList<T>
{
    private const int Initial_Capacity = 2;
    private T[] items;
    public ArrayList()
    {
        this.items = new T[Initial_Capacity];
    }

    public int Count { get; private set; }

    public T this[int index]
    {
        get
        {
            if (index >= this.Count || index < 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            return this.items[index];
        }

        set
        {
            if (index >= this.Count || index < 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            this.items[index] = value;
        }
    }


    public void Add(T item)
    {
        if (this.items.Length == this.Count )
        {
            this.Resize();
        }
        this.items[Count++] = item;
    }

    private void Resize()
    {
        T[] copy = new T[this.items.Length * 2];
        for (int i = 0; i < this.items.Length; i++)
        {
            copy[i] = this.items[i];
        }
        this.items = copy;
    }

    public T RemoveAt(int index)
    {
        if (index >= this.Count || index < 0)
        {
            throw new ArgumentOutOfRangeException();
        }

        T temp = this.items[index];
        this.ShiftLeft(index);
        this.Count--;
        if (this.Count <= this.items.Length/4)
        {
            this.Shrink();
        }
        return temp;
    }

    private void Shrink()
    {
        T[] destination =new T[this.items.Length / 2];
        Array.Copy(this.items, destination, this.Count);
        this.items = destination;
    }

    private void ShiftLeft(int index)
    {
        for (int i = index; i < this.Count-1; i++)
        {
            this.items[i] = this.items[i + 1];
        }
    }
}
