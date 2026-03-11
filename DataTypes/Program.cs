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
    }
}