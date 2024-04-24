using System;
using System.Collections.Generic;

namespace 二叉树
{
    class Program
    {
        static void Main(string[] args)
        {
            // 如果实现一个链表树 则要满足 listNode 中存在 子节点左和子节点右
            
            // 如果是数组型的树 则 左节点的位置索引 leftIndex = 2 * parentIndex + 1;
            //右节点的位置索引 rightIndex = 2 * parentIndex + 2;
            // 父节点的位置索引则为 parentIndex =  (childIndex - 1) / 2;
            
            // 小顶堆的实现 如果插入数据 则跟父节点进行比较 小于则交换
            PriorityQueue<int> priorityQueue = new PriorityQueue<int>();
            
            priorityQueue.Enqueue(10);
            priorityQueue.Enqueue(20);
            priorityQueue.Enqueue(1);
            priorityQueue.Enqueue(50);
            priorityQueue.Enqueue(-1);
            priorityQueue.Enqueue(6);

           int a = priorityQueue.Dequeue();
           a =priorityQueue.Dequeue();
           a =priorityQueue.Dequeue();
           a =priorityQueue.Dequeue();
        }

        /// <summary>
        /// 优先队列 小顶堆
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public class PriorityQueue<T> where T : IComparable
        {
            private List<T> list;

            public PriorityQueue(int capacity = 4)
            {
                list = new List<T>(capacity);
            }
    
            /// <summary>
            /// 交换
            /// </summary>
            private void Swap(int a, int b)
            {
                (list[a], list[b]) = (list[b], list[a]);
            }
    
            /// <summary>
            /// 新增数据
            /// </summary>
            /// <param name="_item"></param>
            public void Enqueue(T _item)
            {
                list.Add(_item);
        
                int childIndex = list.Count - 1;
                int parentIndex = (childIndex - 1) / 2; // 找到父节点

                while (parentIndex >= 0 && list[childIndex].CompareTo(list[parentIndex]) < 0)
                {
                    Swap(childIndex, parentIndex);
                    childIndex = parentIndex;
                    parentIndex = (childIndex - 1) / 2;
                }
            }

    
            /// <summary>
            /// 弹出数据
            /// </summary>
            /// <returns></returns>
            public T Dequeue()
            {
                if(list.Count == 0)
                    return default(T);

                T _item = list[0];
                int _endIndex = list.Count - 1;
                list[0] = list[_endIndex];
                list.RemoveAt(_endIndex);
                --_endIndex;

                int parentIndex = 0;
                while (true)
                {
                    int _minIndex = parentIndex;
            
                    int _childIndex = parentIndex * 2 + 1;
                    if (_childIndex <= _endIndex && list[_childIndex].CompareTo(list[_minIndex]) < 0)
                    {
                        _minIndex = _childIndex;
                    }

                    _childIndex = parentIndex * 2 + 2;
                    if (_childIndex <= _endIndex && list[_childIndex].CompareTo(list[_minIndex]) < 0)
                    {
                        _minIndex = _childIndex;
                    }
            
                    if(_minIndex == parentIndex)
                        break;
            
                    Swap(parentIndex, _minIndex);
                    parentIndex = _minIndex;
                }

                return _item;
            }
        }
    }
}