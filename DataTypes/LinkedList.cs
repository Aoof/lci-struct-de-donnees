namespace DataTypes;

using System;
using System.Collections;
using System.Collections.Generic;

public class LinkedList<T> : IEnumerable<T>
{
	public class Node
	{
		public T Value;
		public Node? Next;

		public Node(T value, Node? next = null)
		{
			Value = value;
			Next = next;
		}
	}

	private Node? head;
	private Node? tail;
	private int count;

	public int Count => count;

	public void AddFirst(T value)
	{
		Node node = new(value, head);
		head = node;
		if (tail == null)
			tail = node;
		count++;
	}

	public void AddLast(T value)
	{
		Node node = new(value);
		if (tail == null)
		{
			head = tail = node;
		}
		else
		{
			tail.Next = node;
			tail = node;
		}

		count++;
	}

	public T RemoveFirst()
	{
		if (head == null)
			throw new IndexOutOfRangeException("Cannot remove from an empty linked list.");

		T value = head.Value;
		head = head.Next;
		count--;

		if (count == 0)
			tail = null;

		return value;
	}

	public T RemoveLast()
	{
		if (head == null)
			throw new IndexOutOfRangeException("Cannot remove from an empty linked list.");

		if (head.Next == null)
			return RemoveFirst();

		Node previous = head;
		Node current = head.Next;

		while (current.Next != null)
		{
			previous = current;
			current = current.Next;
		}

		previous.Next = null;
		tail = previous;
		count--;
		return current.Value;
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
		Node? current = head;
		int index = 0;
		int foundAt = -1;

		while (current != null)
		{
			if (EqualityComparer<T>.Default.Equals(current.Value, value))
				foundAt = index;

			current = current.Next;
			index++;
		}

		return foundAt;
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

		Node previous = GetNodeAt(index - 1);
		previous.Next = new Node(value, previous.Next);
		count++;
	}

	public T RemoveAt(int index)
	{
		if (index < 0 || index >= count)
			throw new ArgumentOutOfRangeException(nameof(index), "Index is out of range.");

		if (index == 0)
			return RemoveFirst();

		Node previous = GetNodeAt(index - 1);
		Node target = previous.Next!;
		previous.Next = target.Next;

		if (target == tail)
			tail = previous;

		count--;
		return target.Value;
	}

	public void Clear()
	{
		head = null;
		tail = null;
		count = 0;
	}

	public void Display()
	{
		Console.WriteLine("- LinkedList -");
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
		Node? current = head;
		for (int i = 0; i < index; i++)
			current = current!.Next;

		return current!;
	}
}
