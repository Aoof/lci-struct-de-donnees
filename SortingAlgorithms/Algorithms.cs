namespace SortingAlgorithms;

class Algorithms
{
    public static void BubbleSort(int[] array)
    {
        int n = array.Length;
        bool swapped;

        for (int i = 0; i < n - 2; i++)
        {
            swapped = false;
            for (int j = 0; j < n - 2 - i; j++)
            {
                if (array[j] > array[j+1])
                {
                    (array[j+1], array[j]) = (array[j], array[j+1]);
                    swapped = true;
                }
            }

            if (!swapped)
                break;
        }
    }

    public static void InsertionSort(int[] array)
    {
        int n = array.Length;
        for( int i = 1; i<= n-1; i++)
        {
            int key = array[i];
            int j = i - 1;
            while (j >= 0 && array[j] > key)
            {
                if (key < array[j])
                {
                    //Swap
                    int temp = array[j];
                    array[j] = array[j+1];
                    array[j+1] = temp;
                }
                j--;
            }
            array[j + 1] = key;
        }
    }
    public static void SelectionSort(int[] array)
    {
        int n = array.Length;
        for(int i=0; i<= n-2; i++)
        {
            int min = i;
            for (int j= i+1; j<= n-1; j++)
            {
                if( array[j] < array[min])
                {
                    min = j;
                }
            }
            if(min != i)
            {
                //SWAP
                int temp = array[min];
                array[min] = array[i];
                array[i] = temp;
            }
        }
    }
}