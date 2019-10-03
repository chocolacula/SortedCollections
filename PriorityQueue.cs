using System;

namespace SortedCollections
{
    public struct PriorityQueueEntry<T> : IComparable<PriorityQueueEntry<T>>
    {
        public readonly T Value;
        private readonly int _priority;

        public PriorityQueueEntry(T value, int priority)
        {
            Value = value;
            _priority = priority;
        }

        public int CompareTo(PriorityQueueEntry<T> entry)
        {
            return _priority.CompareTo(entry._priority);
        }
    }

    public class PriorityQueue<T>
    {
        private readonly Heap<PriorityQueueEntry<T>> _heap;

        public int Count => _heap.Count;
        public bool IsEmpty => _heap.IsEmpty;
        public bool IsDescending => _heap.IsDescending;

        public PriorityQueue(bool isDesc = false)
        {
            _heap = new Heap<PriorityQueueEntry<T>>(isDesc);
        }

        public void Enqueue(T item, int priority)
        {
            _heap.Push(new PriorityQueueEntry<T>(item, priority));
        }

        public T Dequeue()
        {
            return _heap.Pop().Value;
        }

        public T Peek()
        {
            return _heap.Peek().Value;
        }

        public void Clear()
        {
            _heap.Clear();
        }
    }
}
