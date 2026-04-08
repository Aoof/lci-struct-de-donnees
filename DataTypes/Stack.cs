namespace DataTypes;

using System;
using System.Collections.Generic;

public class Stack<T> : IStack<T>
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

    Node? top;
    
    int count = 0;

    public int Count => count;

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
        top = top.next;
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
            if (EqualityComparer<T>.Default.Equals(cur.value, element))
                return true;
            cur = cur.next;
        }
        return false;
    }

    public void Clear()
    {
        top = null;
        count = 0;
    }

    public void Display()
    {
        Node? cur = top;
        Console.WriteLine("- Stack -");
        while (cur != null)
        {
            Console.WriteLine("|   " + cur.value + "  |");
            cur = cur.next;
        }
    }
}