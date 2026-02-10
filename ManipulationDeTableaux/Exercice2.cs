namespace ManipulationDeTableaux;

static class Exercice2
{
    public static int[] arrayA = [];

    // Time Complexity: O(n)
    // Space Complexity: O(1)
    // Comparisons Made: 2n
    public static (int min, int max) FindMinMax()
    {
        if (arrayA.Length == 0) return (-1, -1);
        int min = arrayA[0];
        int max = arrayA[0];
        for (int i = 0; i < arrayA.Length; i++)
        {
            int temp = arrayA[i];
            if (temp < min) min = temp;
            if (temp > max) max = temp;
        }

        return (min, max);
    }
}