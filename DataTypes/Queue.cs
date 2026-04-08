namespace DataTypes;

using System;
using System.Collections.Generic;

public class Queue<T> : IQueue<T>
{
    public class Node
    {
        public T value;
        public Node? next;

        public Node(T value = default!, Node? next = null)
        {
            this.value = value;
            this.next = next;
        }
    }

    Node? head;
    Node? tail;
    int count = 0;

    public int Count => count;

    public void Enqueue(T element)
    {
        Node newElem = new(element);

        if (count == 0) head = tail = newElem;
        else            
        {
            tail!.next = newElem;
            tail = newElem;
        }

        count++;
    }

    public T Dequeue()
    {
        if (count == 0) throw new IndexOutOfRangeException("Cannot dequeue an empty queue");
        T res = head!.value;
        head = head!.next;
        count--;
        if (count == 0)
            tail = null;
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
            if (EqualityComparer<T>.Default.Equals(curr.value, element))
                return true;
            curr = curr.next;
        }
        return false;
    }

    public void Clear()
    {
        head = null;
        tail = null;
	count = 0;
        // Garbage collector will do it I think
    }

    public void Display()
    {
        Node? cur = head;
        Console.WriteLine("- Queue -");
        while (cur != null)
        {
            Console.WriteLine("|   " + cur.value + "  |");
            cur = cur.next;
        }   
    }
}
