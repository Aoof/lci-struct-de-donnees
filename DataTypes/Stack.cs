namespace DataTypes;

class Stack<T> : IStack<T>
{
    public class Node
    {
        public T value;
        public Node? prev;
        public Node(T value = default!, Node? prev = null)
        {
            this.value = value;
            this.prev = prev;
        }
    }

    Node? top;
    
    int count = 0;

    public void Push(T element)
    {
        top = new Node(element, top);
        count++;
    }

    public T Pop()
    {
        if (top == null || count == 0)
            throw new IndexOutOfRangeException("Can't pop an empty Stack...");
        
        T response = top.value;
        top = top.prev;
        count--;
        return response;
    }

    public T Peek()
    {
        if (top == null || count == 0)
            throw new IndexOutOfRangeException("Can't peek an empty Stack...");

        return top!.value;
    }

    public bool Contains(T element)
    {
        Node? cur = top;
        while (cur != null)
        {
            if (cur!.value!.Equals(element))
                return true;
            cur = cur.prev;
        }
        return false;
    }

    public int Count()
    {
        return count;
    }

    public void Clear()
    {
        top = null;
    }

    public void Display()
    {
        Node? cur = top;
        Console.WriteLine("- Stack -");
        while (cur != null)
        {
            Console.WriteLine("|   " + cur.value + "  |");
            cur = cur.prev;
        }
    }
}