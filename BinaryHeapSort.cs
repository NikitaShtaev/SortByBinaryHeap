using System;
using System.Collections.Generic;

namespace SortByBinaryHeap
{
    public class BinaryHeapSort<T>
        where T: IComparable
    {
        /// <summary>
        /// Coleection of elements.
        /// </summary>
        public List<T> Items = new List<T>();
        /// <summary>
        /// Quantity of elements.
        /// </summary>
        public int Count => Items.Count;
        public BinaryHeapSort(){ }
        public BinaryHeapSort(IEnumerable<T> collection)
        {
            foreach (var item in collection)
            {
                Add(item);
            }
        }
        /// <summary>
        /// Adding element to collection.
        /// </summary>
        /// <param name="item"></param>
        public void Add(T item)
        {
            Items.Add(item);
            BalanceHeap();
        }
        /// <summary>
        /// Sort of collection and return it as List.
        /// </summary>
        /// <returns></returns>
        public List<T> Sort()
        {
            var lst = new List<T>();
            while (Items.Count > 0)
            {
                lst.Add(GetMax());
            }
            return lst;
        }
        /// <summary>
        /// Returns first item from collection(max). Copy collection and going throw it by deleting first item. 
        /// </summary>
        /// <returns></returns>
        private T GetMax()
        {
            var newItems = Items;
            var result = newItems[0];
            newItems[0] = newItems[Count - 1];
            newItems.RemoveAt(Count - 1);
            Sort(0);
            return result;
        }
        /// <summary>
        /// Sort program for collection based on parant and current indexes.
        /// </summary>
        /// <param name="currentIndex"></param>
        private void Sort(int currentIndex)
        {
            int leftIndex, rightIndex;
            int maxIndex = currentIndex;
            while (currentIndex < Count)
            {
                leftIndex = 2 * currentIndex + 1;
                rightIndex = 2 * currentIndex + 2;
                if (leftIndex < Count && Items[maxIndex].CompareTo(Items[leftIndex]) == -1)
                {
                    maxIndex = leftIndex;
                }
                if (rightIndex < Count && Items[maxIndex].CompareTo(Items[rightIndex]) == -1)
                {
                    maxIndex = rightIndex;
                }
                if (maxIndex == currentIndex)
                {
                    break;
                }
                SwapMethod(currentIndex, maxIndex);
                currentIndex = maxIndex;
            }
        }
        /// <summary>
        /// Balancing for collection for adding element.
        /// </summary>
        private void BalanceHeap()
        {
            int currentIndex = Count - 1;
            int parantIndex = GetParantIndex(currentIndex);
            while (currentIndex > 0 && Items[parantIndex].CompareTo(Items[currentIndex]) == -1)
            {
                SwapMethod(currentIndex, parantIndex);
                currentIndex = parantIndex;
                parantIndex = GetParantIndex(currentIndex);
            }
        }
        /// <summary>
        /// Swap elements of collection.
        /// </summary>
        /// <param name="currentIndex"></param>
        /// <param name="parantIndex"></param>
        private void SwapMethod(int currentIndex, int parantIndex)
        {
            var temp = Items[currentIndex];
            Items[currentIndex] = Items[parantIndex];
            Items[parantIndex] = temp;
        }
        /// <summary>
        /// Returns parant index for current element by it's index.
        /// </summary>
        /// <param name="currentIndex"></param>
        /// <returns></returns>
        private int GetParantIndex(int currentIndex)
        {
            return (currentIndex - 1) / 2;
        }
    }
}
