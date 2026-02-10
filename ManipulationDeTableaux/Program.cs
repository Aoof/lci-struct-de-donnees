namespace ManipulationDeTableaux;

class Program
{
    public static void Main(string[] args)
    {
        Exercice1.arrayA = [ 1, 2, 3, 4, 5, 6, -32, 12, 512, 12313, 122, 312 ];

        // Time Complexity: O(n)
        // Space Complexity: O(1)
        // Comparisons made: n + 1 ? or 2n + 1
        Exercice1.DisplayElements();

        // Time Complexity: O(n)
        // Space Complexity: O(1)
        // Comparisons made: n + 1
        Console.WriteLine("Even numbers are: " + Exercice1.CountEvenNumbers());

        Exercice2.arrayA = (int[])Exercice1.arrayA.Clone();

        // Time Complexity: O(n)
        // Space Complexity: O(1)
        // Comparisons Made: 2n
        (int min, int max) = Exercice2.FindMinMax();
        Console.Write("Minimum: {0} | Maximum: {1}", min, max);
    }
}