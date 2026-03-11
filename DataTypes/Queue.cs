namespace DataTypes;

public class Queue<T> : IQueue<T>
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

    Node? head;
    Node? tail;
    int count = 0;

    public void Enqueue(T element)
    {
        Node newElem = new(element);
        tail!.prev = newElem;
        tail = newElem;
        count++;
    }

    public T Dequeue()
    {
        if (count == 0) throw new IndexOutOfRangeException("Cannot dequeue an empty queue");
        T res = head!.value;
        head = head.prev;
        count--;
        return res;
    }

    public T Peek()
    {
        if (count == 0) throw new IndexOutOfRangeException("Cannot peek an empty queue");
        return head!.value;
    }

    public bool Contains(T element)
    {
        if (count == 0) return false;
        Node? curr = head!;
        while (curr != null)
        {
            if (curr!.value!.Equals(element))
                return true;
            curr = head!.prev;
        }
        return false;
    }

    public void Clear()
    {
        head = null;
        tail = null;
        // Garbage collector will do it
    }

    public void Display()
    {
        Node? cur = head;
        Console.WriteLine("- Queue -");
        while (cur != null)
        {
            Console.WriteLine("|   " + cur.value + "  |");
            cur = cur.prev;
        }   
    }

    public int Count()
    {
        return count;
    }

    
}