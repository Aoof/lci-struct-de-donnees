using System.Security.Cryptography;

namespace SortingAlgorithms;

public static class ArrayUtils
{
    public const int printableLength = 50;
    public const int elementsPerLine = 4;


    /// <summary>
    /// Prints an array or a subset of it. If the array is too large, prints a random slice.
    /// </summary>
    /// <returns>The actual start and end indices that were printed</returns>
    public static (int start, int end) PrintArray(int[] array, int? requestedStart = null, int? requestedEnd = null)
    {
        int n = array.Length;

        // Determine which portion of the array to print
        (int start, int end) = DetermineRangeToPrint(n, requestedStart, requestedEnd);

        // Print the array elements
        PrintArrayRange(array, start, end);

        return (start, end);
    }

    private static (int start, int end) DetermineRangeToPrint(int arrayLength, int? requestedStart, int? requestedEnd)
    {
        // If explicit range provided, use it
        if (requestedStart.HasValue && requestedEnd.HasValue)
        {
            return (requestedStart.Value, requestedEnd.Value);
        }

        // If array is small enough, print all of it
        if (arrayLength <= printableLength)
        {
            return (0, arrayLength - 1);
        }

        // For large arrays, select a random slice
        int randomStart = RandomNumberGenerator.GetInt32(0, arrayLength - printableLength);
        int randomEnd = randomStart + printableLength;
        return (randomStart, randomEnd);
    }

    private static void PrintArrayRange(int[] array, int start, int end)
    {
        // Calculate alignment offset so columns line up nicely
        int alignmentOffset = start % elementsPerLine;

        Console.Write("[");
        
        for (int i = start; i < end; i++)
        {
            // Add newline every 4 elements (except at the very start)
            bool shouldWrapLine = (i - alignmentOffset) % elementsPerLine == 0 && i != start;
            if (shouldWrapLine)
            {
                Console.Write("\n ");
            }
            
            Console.Write($"{array[i]}, ");
        }
        
        // Remove trailing comma and space, then close bracket
        Console.WriteLine("\b\b]");
    }
}