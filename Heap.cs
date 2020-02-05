using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace AI_Coursework
{
    public class Heap<T> where T : IHeapITem<T>
    {
        private T[] items;
        private int currenNoItems;

        public int CurrenNoItems { get => currenNoItems;}

        public Heap(int heapSize)
        {
            items = new T[heapSize];
        }

        public void Add(T item)
        {
            item.Index = currenNoItems;
            items[currenNoItems] = item; // add in the end
            SortItemUp(item); // sort based on the right index
            currenNoItems++;
        }

        public T PopItem()
        {
            T firstItem = items[0];
            currenNoItems--;
            items[0] = items[currenNoItems]; // put the end to the top
            items[0].Index = 0;
            SortItemDown(items[0]); // sort down to the right index
            return firstItem;
        }

        public bool Contains(T item)
        {
            return Equals(items[item.Index], item);
        }

        public void UpdateItem(T item)
        {
            SortItemUp(item); // in pathfinding we only need to decrease the index (lower f-cost), sort down is not required.
        }

        private void SortItemUp(T item)
        {
            int parentIndex = (item.Index - 1) / 2;

            while (true)
            {
                T parentItem = items[parentIndex];

                if (item.CompareTo(parentItem) > 0)
                {
                    SwapItems(item, parentItem);
                }
                else
                {
                    break;
                }

                parentIndex = (item.Index - 1) / 2;
            }
        }

        private void SortItemDown(T item)
        {
            while (true)
            {
                int childIndexLeft = (item.Index * 2) + 1;
                int childIndexRight = (item.Index * 2) + 2;
                int swapIndex = 0;

                if (childIndexLeft < currenNoItems)
                {
                    swapIndex = childIndexLeft;

                    if (childIndexRight < currenNoItems)
                    {
                        if (items[childIndexLeft].CompareTo(items[childIndexRight]) < 0)
                            swapIndex = childIndexRight;
                    }

                    T childItem = items[swapIndex];

                    if (item.CompareTo(childItem) < 0)
                    {
                        SwapItems(item, childItem);
                    }
                    else
                    {
                        return;
                    }
                }
                else
                {
                    return;
                }
            }
        }

        private void SwapItems(T itemA, T itemB)
        {
            items[itemA.Index] = itemB;
            items[itemB.Index] = itemA;
            int tempIndex = itemA.Index;
            itemA.Index = itemB.Index;
            itemB.Index = tempIndex;
        }
    }

    public interface IHeapITem<T> : IComparable<T>
    {
        int Index { get; set; }
    }
}
