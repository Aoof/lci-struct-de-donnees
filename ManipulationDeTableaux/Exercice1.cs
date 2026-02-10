namespace ManipulationDeTableaux;

static class Exercice1
{
    public static int[] arrayA = [];

    // Time Complexity: O(n)
    // Space Complexity: O(1)
    // Comparisons made: n + 1 ? ou 2n + 1
    public static void DisplayElements()
    {
        Console.Write("[");
        for (int i = 0; i < arrayA.Length; i++)
        {
            if (i % 4 == 0 && i != 0) Console.Write("\n ");
            Console.Write($"{arrayA[i]}, ");
        }
        Console.WriteLine("\b\b]");
    }

    // Time Complexity: O(n)
    // Space Complexity: O(1)
    // Comparisons made: n + 1
    public static int CountEvenNumbers()
    {
        int evens = 0;
        for (int i = 0; i < arrayA.Length; i++)
        {
            if (arrayA[i] % 2 == 0) evens++;
        }
        return evens;
    }
}