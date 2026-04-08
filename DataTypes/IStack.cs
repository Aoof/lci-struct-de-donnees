namespace DataTypes;

public interface IStack<T>
{
    public void Push(T element);

    public T Pop();

    public T Peek();

    public bool Contains(T element);

    public int Count { get; }

    public void Clear();

    public void Display();
}