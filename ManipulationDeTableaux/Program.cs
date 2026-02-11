namespace ManipulationDeTableaux;

class Program
{
    public static void Main(string[] args)
    {
        // ############## EXERCICE 1 ##############
        Exercice1.arrayA = [ 1, 2, 3, 4, 5, 6, -32, 12, 512, 12313, 122, 312 ];

        // Time Complexity: O(n)
        // Space Complexity: O(1)
        // Comparisons made: n + 1 ? or 2n + 1
        Exercice1.DisplayElements();

        // Time Complexity: O(n)
        // Space Complexity: O(1)
        // Comparisons made: n + 1
        Console.WriteLine("Even numbers are: " + Exercice1.CountEvenNumbers());

        // ############## EXERCICE 2 ##############
        Exercice2.arrayA = (int[])Exercice1.arrayA.Clone();

        // Time Complexity: O(n)
        // Space Complexity: O(1)
        // Comparisons Made: 2n
        (int min, int max) = Exercice2.FindMinMax();
        Console.WriteLine("Minimum: {0} | Maximum: {1}", min, max);
        
        // ############## EXERCICE 3 ##############
        Exercice3.arrayA = (int[])Exercice1.arrayA.Clone();

        // Best case
        int ind1 = Exercice3.FindIndexOfElement(1);

        // Worst case
        int ind2 = Exercice3.FindIndexOfElement(312);

        Exercice1.DisplayElements();
        Console.WriteLine("Element 1 is at index: {0}, and Element 312 is at index: {1}", ind1, ind2);


        // ############## EXERCICE 4 ##############
        Exercice4.arrayA = (int[])Exercice1.arrayA.Clone();

        Console.WriteLine("Before inversing...");
        Exercice4.DisplayElements();
        Exercice4.InverseArray(Exercice4.arrayA);
        Console.WriteLine("After inversing...");
        Exercice4.DisplayElements();

    }
}