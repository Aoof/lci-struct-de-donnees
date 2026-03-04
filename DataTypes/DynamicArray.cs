namespace DataTypes;

public class DynamicArray<T>
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
        if (capacity <= 0)
            throw new ArgumentException("Capacity must be positive.", nameof(capacity));

        this.capacity = capacity;
        array = new T[capacity];
    }

    public DynamicArray(ICollection<T> collection, bool readOnly = false) : this(collection.Count)
    {
        if (collection == null)
            throw new ArgumentNullException(nameof(collection));

        collection.CopyTo(array, 0);
        count = collection.Count;
        this.readOnly = readOnly;
    }

    public void Add(T item)
    {
        if (readOnly)
            throw new InvalidOperationException("Collection is read-only.");

        if (count == capacity)
            Resize(capacity * 2);
        array[count++] = item;
    }

    public void Clear()
    {
        if (readOnly)
            throw new InvalidOperationException("Collection is read-only.");

        for (int i = 0; i < count; i++)
            array[i] = default!;
        count = 0;
    }

    public bool Contains(T item)
    {
        for (int i = 0; i < count; i++)
            if (array[i]!.Equals(item))
                return true;

        return false;
    }

    public bool Remove(T item)
    {
        if (readOnly)
            throw new InvalidOperationException("Collection is read-only.");

        for (int i = 0; i < count; i++)
            if (array[i]!.Equals(item))
                return RemoveAt(i);
        return false;
    }

    public bool RemoveAt(int index)
    {
        if (readOnly)
            throw new InvalidOperationException("Collection is read-only.");
        if (index < 0 || index >= count)
            throw new ArgumentOutOfRangeException(nameof(index), "Index is out of range.");

        for (int i = index; i < count - 1; i++)
            array[i] = array[i + 1];
        array[count - 1] = default!;
        count--;
        return true;
    }

    public void Resize(int newCap)
    {
        if (newCap < count)
            throw new ArgumentException("New capacity cannot be less than current count.", nameof(newCap));
        if (newCap <= 0)
            throw new ArgumentException("New capacity must be positive.", nameof(newCap));
            
        T[] temp = new T[newCap];
        for (int i = 0; i < count; i++)
            temp[i] = array[i];
        array = temp;
        capacity = newCap;
    }

    public IEnumerator<T> GetEnumerator()
    {
        for (int i = 0; i < count; i++)
            yield return array[i];
    }
}