namespace FunctionProvider.Math
{
    public class Sort
    {
        #region Lazy initialization

        private static readonly Lazy<Sort> lazy = new Lazy<Sort>(() => new Sort());

        public static Sort Task { get { return lazy.Value; } }

        private Sort() { }

        #endregion

        /// <summary>
        /// Sorts an array using the Bubble Sort algorithm.
        /// </summary>
        /// <param name="array">The array to be sorted.</param>
        public void BubbleSort(int[] array)
        {
            int n = array.Length;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        // Swap
                        int temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;
                    }
                }
            }
        }

        /// <summary>
        /// Sorts an array using the Selection Sort algorithm.
        /// </summary>
        /// <param name="array">The array to be sorted.</param>
        public void SelectionSort(int[] array)
        {
            int n = array.Length;
            for (int i = 0; i < n - 1; i++)
            {
                int minIndex = i;
                for (int j = i + 1; j < n; j++)
                {
                    if (array[j] < array[minIndex])
                    {
                        minIndex = j;
                    }
                }
                // Swap
                int temp = array[minIndex];
                array[minIndex] = array[i];
                array[i] = temp;
            }
        }

        /// <summary>
        /// Sorts an array using the Insertion Sort algorithm.
        /// </summary>
        /// <param name="array">The array to be sorted.</param>
        public void InsertionSort(int[] array)
        {
            int n = array.Length;
            for (int i = 1; i < n; ++i)
            {
                int key = array[i];
                int j = i - 1;

                // Move elements of array that are greater than the key
                while (j >= 0 && array[j] > key)
                {
                    array[j + 1] = array[j];
                    j = j - 1;
                }
                array[j + 1] = key;
            }
        }

        /// <summary>
        /// Sorts an array using the Merge Sort algorithm.
        /// </summary>
        /// <param name="array">The array to be sorted.</param>
        public void MergeSort(int[] array)
        {
            if (array.Length <= 1)
                return;

            int mid = array.Length / 2;
            int[] left = new int[mid];
            int[] right = new int[array.Length - mid];

            Array.Copy(array, 0, left, 0, mid);
            Array.Copy(array, mid, right, 0, array.Length - mid);

            MergeSort(left);
            MergeSort(right);
            Merge(array, left, right);
        }

        private void Merge(int[] array, int[] left, int[] right)
        {
            int i = 0, j = 0, k = 0;
            while (i < left.Length && j < right.Length)
            {
                if (left[i] <= right[j])
                {
                    array[k++] = left[i++];
                }
                else
                {
                    array[k++] = right[j++];
                }
            }
            while (i < left.Length)
            {
                array[k++] = left[i++];
            }
            while (j < right.Length)
            {
                array[k++] = right[j++];
            }
        }

        /// <summary>
        /// Sorts an array using the Quick Sort algorithm. (According to CoPilot the fastest Sort algorithm)
        /// </summary>
        /// <param name="array">The array to be sorted.</param>
        public void QuickSort(int[] array)
        {
            QuickSort(array, 0, array.Length - 1);
        }

        private void QuickSort(int[] array, int low, int high)
        {
            if (low < high)
            {
                int pi = Partition(array, low, high);

                QuickSort(array, low, pi - 1);
                QuickSort(array, pi + 1, high);
            }
        }

        private int Partition(int[] array, int low, int high)
        {
            int pivot = array[high];
            int i = (low - 1);

            for (int j = low; j < high; j++)
            {
                if (array[j] < pivot)
                {
                    i++;
                    int temp = array[i];
                    array[i] = array[j];
                    array[j] = temp;
                }
            }

            int temp1 = array[i + 1];
            array[i + 1] = array[high];
            array[high] = temp1;

            return i + 1;
        }

        /// <summary>
        /// Sorts an array using the Heap Sort algorithm.
        /// </summary>
        /// <param name="array">The array to be sorted.</param>
        public void HeapSort(int[] array)
        {
            int n = array.Length;

            for (int i = n / 2 - 1; i >= 0; i--)
                Heapify(array, n, i);

            for (int i = n - 1; i >= 0; i--)
            {
                int temp = array[0];
                array[0] = array[i];
                array[i] = temp;

                Heapify(array, i, 0);
            }
        }

        private void Heapify(int[] array, int n, int i)
        {
            int largest = i;
            int left = 2 * i + 1;
            int right = 2 * i + 2;

            if (left < n && array[left] > array[largest])
                largest = left;

            if (right < n && array[right] > array[largest])
                largest = right;

            if (largest != i)
            {
                int swap = array[i];
                array[i] = array[largest];
                array[largest] = swap;

                Heapify(array, n, largest);
            }
        }

        /// <summary>
        /// Sorts an array using the Shell Sort algorithm.
        /// </summary>
        /// <param name="array">The array to be sorted.</param>
        public void ShellSort(int[] array)
        {
            int n = array.Length;
            for (int gap = n / 2; gap > 0; gap /= 2)
            {
                for (int i = gap; i < n; i++)
                {
                    int temp = array[i];
                    int j;
                    for (j = i; j >= gap && array[j - gap] > temp; j -= gap)
                    {
                        array[j] = array[j - gap];
                    }
                    array[j] = temp;
                }
            }
        }
    }
}
