namespace DataTypes;

public interface IQueue<T>
{
    public void Enqueue(T element);

    public T Dequeue();

    public T Peek();

    public bool Contains(T element);

    public int Count();

    public void Clear();

    public void Display();
}