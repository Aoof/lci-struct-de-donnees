namespace ManipulationDeTableaux;

class Exercice4
{
    public static int[] arrayA = [];

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

    
    public static void InverseArray(int[] array)
    {
        for (int i = 0; i < array.Length / 2; i++)
        {
            (array[i], array[array.Length - i - 1]) = (array[array.Length - i - 1], array[i]);
        }
    }
}