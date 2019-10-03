using System;
using System.Collections;
using System.Collections.Generic;

namespace SortedCollections
{
    public class Heap<T> : IEnumerable<T>
        where T : IComparable<T>
    {
        private readonly List<T> _data = new List<T>();

        public int Count
        {
            get { return _data.Count; }
        }

        public bool IsEmpty
        {
            get { return _data.Count == 0; }
        }

        public bool IsDescending { get; }

        public Heap(bool isDesc = false)
        {
            IsDescending = isDesc;
        }

        public void Push(T value)
        {
            _data.Add(value);
            var i = _data.Count - 1;
            var parent = ParentIdx(i);

            while (i > 0 && Compare(_data[parent], _data[i]) < 0)
            {
                Swap(i, parent);

                i = parent;
                parent = ParentIdx(i);
            }
        }

        public T Pop()
        {
            if (_data.Count == 0)
                throw new InvalidOperationException("Collection does not have any element");

            var result = _data[0];

            _data[0] = _data[_data.Count - 1];
            _data.RemoveAt(_data.Count - 1);

            Heapify(0);

            return result;
        }

        public T Peek()
        {
            if (_data.Count == 0)
                throw new InvalidOperationException("Collection does not have any element");

            return _data[0];
        }

        public void Clear()
        {
            _data.Clear();
        }

        private void Heapify(int startIdx)
        {
            if (_data.Count == 0)
                return;
            
            while (true)
            {
                var leftChild = LeftChildIdx(startIdx);
                var rightChild = RightChildIdx(startIdx);

                if (leftChild >= _data.Count)
                    leftChild = startIdx;

                if (rightChild >= _data.Count)
                    rightChild = startIdx;

                if (Compare(_data[startIdx], _data[leftChild]) >= 0
                    && Compare(_data[startIdx], _data[rightChild]) >= 0)
                    break;

                var largest = Compare(_data[leftChild], _data[rightChild]) > 0 ? leftChild : rightChild;

                Swap(startIdx, largest);
                startIdx = largest;
            }
        }

        private int Compare(T lhs, T rhs)
        {
            return !IsDescending ? lhs.CompareTo(rhs) : rhs.CompareTo(lhs);
        }

        private void Swap(int i, int j)
        {
            var tmp = _data[i];
            _data[i] = _data[j];
            _data[j] = tmp;
        }

        private static int ParentIdx(int childIdx)
        {
            return (childIdx - 1) / 2;
        }

        private static int LeftChildIdx(int parentIdx)
        {
            return parentIdx * 2 + 1;
        }

        private static int RightChildIdx(int parentIdx)
        {
            return LeftChildIdx(parentIdx) + 1;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _data.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
