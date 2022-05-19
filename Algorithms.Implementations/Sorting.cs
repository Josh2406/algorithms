namespace Algorithms.Implementations
{
    public static class Sorting
    {
        
        public static void BubbleSort(this Algorithm _, int[] arr)
        {
            for(int max = arr.Length - 1; max >= 0; max--)
            {
                bool swapped = false;
                for(int i = 0; i < max; i++)
                {
                    var first = arr[i];
                    var next = arr[i + 1];

                    if(next < first)
                    {
                        arr[i] = next;
                        arr[i + 1] = first;
                        swapped = true;
                    }
                }

                if (!swapped)
                {
                    break;
                }
            }
        }

        public static void SelectionSort(this Algorithm _, int[] arr)
        {
            for(int i = 0; i < arr.Length - 1; i++)
            {
                int min_idx = i;

                for(int j = i + 1; j < arr.Length; j++)
                {
                    if(arr[j] < arr[min_idx])
                        min_idx = j;
                }
                
                //Swap
                int temp = arr[min_idx];
                arr[min_idx] = arr[i];
                arr[i] = temp;
            }
        }
    }
}
