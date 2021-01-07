using System;
using System.Linq;

namespace QuickSort
{
    class Program
    {
        static void Main()
        {
            var arr = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            QuickSort<int>(arr);

            Console.WriteLine(string.Join(' ', arr));
        }

        static void QuickSort<T>(T[] arr) where T : IComparable

        {
            T pivotItem = arr[arr.Length / 2];

            int itemsBiggerThanPivot = 0;

            foreach (var item in arr)
            {
                if (item.CompareTo(pivotItem) > 0)
                {
                    itemsBiggerThanPivot++;
                }
            }

            T[] smallerThanPivotItemsArr = new T[arr.Length - itemsBiggerThanPivot - 1];
            T[] biggerThanPivotItemsArr = new T[itemsBiggerThanPivot];

            int itemsSmallerThanPivot = 0;
            itemsBiggerThanPivot = 0;

            bool check = false;

            foreach (var item in arr)
            {
                if (item.CompareTo(pivotItem) <= 0)
                {
                    if (item.CompareTo(pivotItem) == 0 && !check)
                    {
                        check = true;
                        continue;
                    }
                    smallerThanPivotItemsArr[itemsSmallerThanPivot] = item;
                    itemsSmallerThanPivot++;
                }
                else
                {
                    biggerThanPivotItemsArr[itemsBiggerThanPivot] = item;
                    itemsBiggerThanPivot++;
                }
            }

            if (smallerThanPivotItemsArr.Length > 1)
            {
                QuickSort(smallerThanPivotItemsArr);
            }
            if (biggerThanPivotItemsArr.Length > 1)
            {
                QuickSort(biggerThanPivotItemsArr);
            }

            itemsSmallerThanPivot = 0;

            foreach (var item in smallerThanPivotItemsArr)
            {
                arr[itemsSmallerThanPivot] = item;
                itemsSmallerThanPivot++;
            }

            arr[itemsSmallerThanPivot] = pivotItem;
            itemsSmallerThanPivot++;

            foreach (var item in biggerThanPivotItemsArr)
            {
                arr[itemsSmallerThanPivot] = item;
                itemsSmallerThanPivot++;
            }
        }
    }
}
