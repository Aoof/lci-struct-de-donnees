namespace ManipulationDeTableaux;

static class Exercice3
{
    public static int[] arrayA = [];

    // Best Time Complexity: O(1)
    // Worst Time Complexity: O(n)
    // Space Complexity: O(1)
    // Comparisons Made: 2n
    public static int FindIndexOfElement(int target)
    {
        for (int i = 0; i < arrayA.Length; i++)
        {
            if (arrayA[i] == target) return i;
        }

        return -1;
    }
}