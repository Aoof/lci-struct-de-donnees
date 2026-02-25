using System.Collections;

namespace DataTypes;

public class DynamicArray<T> : ICollection<T>
{
    private T[] array;
    private int count = 0;
    private int capacity = 2;
    private bool readOnly = false;

    public int Count { get => count; }
    public int Capacity { get => capacity; }
    public bool IsReadOnly { get => readOnly; }

    public DynamicArray(int capacity = 2)
    {
        this.capacity = 2;
        array = new T[capacity];
    }

    public DynamicArray(ICollection<T> collection, bool readOnly = false) : this(collection.Count)
    {
        collection.CopyTo(array, 0);
        count = collection.Count;
        this.readOnly = readOnly;
    }

    public void Add(T item)
    {
        if (count == capacity)
            Resize(capacity * 2);
        array[count++] = item;
    }

    public void Clear()
    {
        for (int i = 0; i < count; i++)
            array[i] = default!;
        count = 0;
    }

    public bool Contains(T item)
    {
        for (int i = 0; i < count; i++)
        {
            if (array[i]!.Equals(item))
                return true;
        }
        return false;
    }

    public void CopyTo(T[] destination, int arrayIndex)
    {
        for (int i = 0; i < count; i++)
            destination[arrayIndex + i] = array[i];
    }

    public bool Remove(T item)
    {
        for (int i = 0; i < count; i++)
        {
            if (array[i]!.Equals(item))
            {
                for (int j = i; j < count - 1; j++)
                    array[j] = array[j + 1];
                array[count - 1] = default!;
                count--;
                return true;
            }
        }
        return false;
    }

    public void Resize(int newCap)
    {
        T[] temp = new T[newCap];
        for (int i = 0; i < count; i++)
            temp[i] = array[i];
        array = temp;
        capacity = newCap;
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    public IEnumerator<T> GetEnumerator()
    {
        for (int i = 0; i < count; i++)
            yield return array[i];
    }
}