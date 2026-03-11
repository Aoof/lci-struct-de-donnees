namespace DataTypes;

class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Dynamic arrays -----------");

        DynamicArray<int> array = new([1, 2, 3, 4]);

        Console.WriteLine("Stack --------------------");

        Stack<int> stack = new();

        stack.Push(12);
        stack.Push(22);
        stack.Push(32);
        stack.Push(42);
        stack.Push(52);

        stack.Display();

        stack.Pop();
        stack.Pop();
        stack.Pop();

        stack.Display();

        stack.Clear();

        stack.Display();

        Console.WriteLine("Queue --------------------");

        Queue<int> queue = new();

        queue.Enqueue(10);
        queue.Enqueue(20);
        queue.Enqueue(30);
        queue.Enqueue(40);
        queue.Enqueue(50);

        queue.Display();

        Console.WriteLine("Dequeued: " + queue.Dequeue());
        Console.WriteLine("Dequeued: " + queue.Dequeue());

        queue.Display();

        Console.WriteLine("Peek: " + queue.Peek());

        Console.WriteLine("Contains 20: " + queue.Contains(20));
        Console.WriteLine("Contains 100: " + queue.Contains(100));

        Console.WriteLine("Count: " + queue.Count());

        queue.Clear();

        queue.Display();
        Console.WriteLine("Count after clear: " + queue.Count());
    }
}