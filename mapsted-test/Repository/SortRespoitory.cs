using MapstedTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MapstedTest.Repository
{
    public class SortRespoitory : ISortRespoitory
    {

        /// <summary>
        /// Sorts a list and returns snapshots of each sort stage
        /// </summary>
        public List<List<int>> SortList(SortTask<int> sContext)
        {
            switch (sContext.SortType)
            {
                case SortType.Quick:
                    List<List<int>> snapShotList = new List<List<int>>();
                    return QuickSort(sContext.ListToSort);
                case SortType.Bubble:
                    return BubbleSort(sContext.ListToSort);
                case SortType.Bucket:
                    return BucketSort(sContext.ListToSort);
                default:
                    return null;
            }
        }

        public List<List<double>> SortList(SortTask<double> sContext)
        {
            switch (sContext.SortType)
            {
                case SortType.Quick:
                    return QuickSort(sContext.ListToSort);
                case SortType.Bubble:
                    return BubbleSort(sContext.ListToSort);
                case SortType.Bucket:
                    return BucketSort(sContext.ListToSort);
                default:
                    return null;
            }
        }

        /// <summary>
        /// Quick Sort
        /// </summary>
        private List<List<int>> QuickSort(List<int> listToSort)
        {
            List<List<int>> snapShotList = new List<List<int>>();
            snapShotList.Add(new List<int>(listToSort));
            QuickSortHelper(listToSort, 0, listToSort.Count - 1, snapShotList);
            return snapShotList;
        }

        private void QuickSortHelper(List<int> listToSort, int left, int right, List<List<int>> snapShotList)
        {
            if (left < right)
            {
                int pivot = Partition(listToSort, left, right, snapShotList);

                if (pivot > 1)
                {
                    QuickSortHelper(listToSort, left, pivot - 1, snapShotList);
                }
                if (pivot + 1 < right)
                {
                    QuickSortHelper(listToSort, pivot + 1, right, snapShotList);
                }
            }

        }

        private int Partition(List<int> listToSort, int left, int right, List<List<int>> snapShotList)
        {
            int pivot = listToSort[left];
            while (true)
            {

                while (listToSort[left] < pivot)
                {
                    left++;
                }

                while (listToSort[right] > pivot)
                {
                    right--;
                }

                if (left < right)
                {
                    if (listToSort[left] == listToSort[right]) return right;

                    int temp = listToSort[left];
                    listToSort[left] = listToSort[right];
                    listToSort[right] = temp;
                    snapShotList.Add(new List<int>(listToSort));
                }
                else
                {
                    return right;
                }
            }
        }

        private List<List<double>> QuickSort(List<double> listToSort)
        {
            List<List<double>> snapShotList = new List<List<double>>();
            snapShotList.Add(new List<double>(listToSort));
            QuickSortHelper(listToSort, 0, listToSort.Count - 1, snapShotList);
            return snapShotList;
        }

        private void QuickSortHelper(List<double> listToSort, int left, int right, List<List<double>> snapShotList)
        {
            if (left < right)
            {
                int pivot = Partition(listToSort, left, right, snapShotList);

                if (pivot > 1)
                {
                    QuickSortHelper(listToSort, left, pivot - 1, snapShotList);
                }
                if (pivot + 1 < right)
                {
                    QuickSortHelper(listToSort, pivot + 1, right, snapShotList);
                }
            }

        }

        private int Partition(List<double> listToSort, int left, int right, List<List<double>> snapShotList)
        {
            double pivot = listToSort[left];
            while (true)
            {

                while (listToSort[left] < pivot)
                {
                    left++;
                }

                while (listToSort[right] > pivot)
                {
                    right--;
                }

                if (left < right)
                {
                    if (listToSort[left] == listToSort[right]) return right;

                    double temp = listToSort[left];
                    listToSort[left] = listToSort[right];
                    listToSort[right] = temp;
                    snapShotList.Add(new List<double>(listToSort));
                }
                else
                {
                    return right;
                }
            }
        }

        /// <summary>
        /// Bubble Sort
        /// </summary>
        private List<List<int>> BubbleSort(List<int> listToSort)
        {
            List<List<int>> snapShotList = new List<List<int>>();
            snapShotList.Add(new List<int>(listToSort));

            bool flag = true;
            int passes = 0;
            while (flag)
            {
                passes++;
                flag = false;
                for (int i = 0; i < listToSort.Count - passes; i++)
                {
                    if (listToSort[i] > listToSort[i + 1])
                    {
                        int temp = listToSort[i];
                        listToSort[i] = listToSort[i + 1];
                        listToSort[i + 1] = temp;
                        flag = true;
                        snapShotList.Add(new List<int>(listToSort));
                    }
                }
            }
            return snapShotList;
        }

        private List<List<double>> BubbleSort(List<double> listToSort)
        {
            List<List<double>> snapShotList = new List<List<double>>();
            snapShotList.Add(new List<double>(listToSort));

            bool flag = true;
            int passes = 0;
            while (flag)
            {
                passes++;
                flag = false;
                for (int i = 0; i < listToSort.Count - passes; i++)
                {
                    if (listToSort[i] > listToSort[i + 1])
                    {
                        double temp = listToSort[i];
                        listToSort[i] = listToSort[i + 1];
                        listToSort[i + 1] = temp;
                        flag = true;
                        snapShotList.Add(new List<double>(listToSort));
                    }
                }
            }
            return snapShotList;
        }


        /// <summary>
        /// Bucket Sort
        /// </summary>
        public List<List<int>> BucketSort(List<int> listToSort)
        {
            List<List<int>> snapShotList = new List<List<int>>();
            snapShotList.Add(new List<int>(listToSort));

            int minValue = listToSort[0];
            int maxValue = listToSort[0];

            for (int i = 1; i < listToSort.Count; i++)
            {
                if (listToSort[i] > maxValue)
                    maxValue = listToSort[i];
                if (listToSort[i] < minValue)
                    minValue = listToSort[i];
            }

            List<int>[] bucket = new List<int>[maxValue - minValue + 1];

            for (int i = 0; i < bucket.Length; i++)
            {
                bucket[i] = new List<int>();
            }

            for (int i = 0; i < listToSort.Count; i++)
            {
                bucket[listToSort[i] - minValue].Add(listToSort[i]);
            }

            int k = 0;
            for (int i = 0; i < bucket.Length; i++)
            {
                if (bucket[i].Count > 0)
                {
                    for (int j = 0; j < bucket[i].Count; j++)
                    {
                        listToSort[k] = bucket[i][j];
                        snapShotList.Add(new List<int>(listToSort));
                        k++;
                    }
                }
            }
            return snapShotList;
        }

        public List<List<double>> BucketSort(List<double> listToSort)
        {
            List<List<double>> snapShotList = new List<List<double>>();
            snapShotList.Add(new List<double>(listToSort));

            double minValue = listToSort[0];
            double maxValue = listToSort[0];

            for (int i = 1; i < listToSort.Count; i++)
            {
                if (listToSort[i] > maxValue)
                    maxValue = listToSort[i];
                if (listToSort[i] < minValue)
                    minValue = listToSort[i];
            }

            List<double>[] bucket = new List<double>[(int)maxValue - (int)minValue + 1];

            for (int i = 0; i < bucket.Length; i++)
            {
                bucket[i] = new List<double>();
            }

            for (int i = 0; i < listToSort.Count; i++)
            {
                bucket[(int)listToSort[i] - (int)minValue].Add(listToSort[i]);
            }

            int k = 0;
            for (int i = 0; i < bucket.Length; i++)
            {
                if (bucket[i].Count > 0)
                {
                    for (int j = 0; j < bucket[i].Count; j++)
                    {
                        listToSort[k] = bucket[i][j];
                        snapShotList.Add(new List<double>(listToSort));
                        k++;
                    }
                }
            }
            return snapShotList;
        }

    }
}
