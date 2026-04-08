namespace DataTypes;

using System;
using System.Collections;
using System.Collections.Generic;

public class DoublyLinkedList<T> : IEnumerable<T>
{
    public class Node
    {
        public T Value;
        public Node? Next;
        public Node? Previous;

        public Node(T value, Node? previous = null, Node? next = null)
        {
            Value = value;
            Previous = previous;
            Next = next;
        }
    }

    private Node? head;
    private Node? tail;
    private int count;

    public int Count => count;

    public void AddFirst(T value)
    {
        Node node = new(value, null, head);
        if (head != null)
            head.Previous = node;
        else
            tail = node;

        head = node;
        count++;
    }

    public void AddLast(T value)
    {
        Node node = new(value, tail, null);
        if (tail != null)
            tail.Next = node;
        else
            head = node;

        tail = node;
        count++;
    }

    public T RemoveFirst()
    {
        if (head == null)
            throw new IndexOutOfRangeException("Cannot remove from an empty doubly linked list.");

        T value = head.Value;
        head = head.Next;

        if (head != null)
            head.Previous = null;
        else
            tail = null;

        count--;
        return value;
    }

    public T RemoveLast()
    {
        if (tail == null)
            throw new IndexOutOfRangeException("Cannot remove from an empty doubly linked list.");

        T value = tail.Value;
        tail = tail.Previous;

        if (tail != null)
            tail.Next = null;
        else
            head = null;

        count--;
        return value;
    }

    public bool Contains(T value)
    {
        return Find(value) >= 0;
    }

    public int Find(T value)
    {
        Node? current = head;
        int index = 0;

        while (current != null)
        {
            if (EqualityComparer<T>.Default.Equals(current.Value, value))
                return index;

            current = current.Next;
            index++;
        }

        return -1;
    }

    public int FindLast(T value)
    {
        Node? current = tail;
        int index = count - 1;

        while (current != null)
        {
            if (EqualityComparer<T>.Default.Equals(current.Value, value))
                return index;

            current = current.Previous;
            index--;
        }

        return -1;
    }

    public void InsertAt(int index, T value)
    {
        if (index < 0 || index > count)
            throw new ArgumentOutOfRangeException(nameof(index), "Index is out of range.");

        if (index == 0)
        {
            AddFirst(value);
            return;
        }

        if (index == count)
        {
            AddLast(value);
            return;
        }

        Node next = GetNodeAt(index);
        Node previous = next.Previous!;
        Node newNode = new(value, previous, next);

        previous.Next = newNode;
        next.Previous = newNode;
        count++;
    }

    public T RemoveAt(int index)
    {
        if (index < 0 || index >= count)
            throw new ArgumentOutOfRangeException(nameof(index), "Index is out of range.");

        if (index == 0)
            return RemoveFirst();

        if (index == count - 1)
            return RemoveLast();

        Node node = GetNodeAt(index);
        Node previous = node.Previous!;
        Node next = node.Next!;

        previous.Next = next;
        next.Previous = previous;
        count--;

        return node.Value;
    }

    public void Clear()
    {
        head = null;
        tail = null;
        count = 0;
    }

    public IEnumerable<T> EnumerateReverse()
    {
        Node? current = tail;
        while (current != null)
        {
            yield return current.Value;
            current = current.Previous;
        }
    }

    public void Display()
    {
        Console.WriteLine("- DoublyLinkedList -");
        foreach (T value in this)
            Console.WriteLine("|   " + value + "  |");
    }

    public IEnumerator<T> GetEnumerator()
    {
        Node? current = head;
        while (current != null)
        {
            yield return current.Value;
            current = current.Next;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    private Node GetNodeAt(int index)
    {
        if (index <= count / 2)
        {
            Node? current = head;
            for (int i = 0; i < index; i++)
                current = current!.Next;

            return current!;
        }

        Node? reverse = tail;
        for (int i = count - 1; i > index; i--)
            reverse = reverse!.Previous;

        return reverse!;
    }
}
