using System;
using System.Security.Cryptography;
using Microsoft.VisualBasic;

namespace SortingAlgorithms;

class Program
{
    public static int[] scrambled = [];
    public static void Main(string[] args)
    {
        // Generate a random 10000 elem array  
        scrambled = new int[10000];

        for (int i = 0; i < scrambled.Length - 1; i++)
        {
            scrambled[i] = RandomNumberGenerator.GetInt32(0, 10000);
        }

        AnalyzeMethod(Algorithms.BubbleSort, "Bubble Sort");
        AnalyzeMethod(Algorithms.InsertionSort, "Insertion Sort");
        AnalyzeMethod(Algorithms.SelectionSort, "Selection Sort");
    }

    public static void AnalyzeMethod(Action<int[]> SortingAlgorithm, string name)
    {
        Console.WriteLine("Here is a random piece of the array to show that the array is unsorted...");
        int[] customSortArray = (int[])scrambled.Clone();
        (int startIndex, int endIndex) = ArrayUtils.PrintArray(customSortArray);
        DateTime start = DateTime.Now;
        SortingAlgorithm(customSortArray);
        DateTime end = DateTime.Now;
        int timetook = end.Subtract(start).Milliseconds;
        Console.WriteLine("Running the " + name + " algorithm took: " + timetook + " ms\nAnd the same piece of the array we selected at " + startIndex + ", " + endIndex + " is...");
        ArrayUtils.PrintArray(customSortArray, startIndex, endIndex);
    }
}