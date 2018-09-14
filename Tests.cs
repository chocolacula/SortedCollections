using System;
using NUnit.Framework;

namespace SortedCollections
{
    [TestFixture]
    public class Tests
    {
        private readonly Random _random = new Random();

        [Test]
        public void HeapTest()
        {
            var heapAsc = new Heap<int>();

            for (var i = 0; i < 5; i++)
            {
                OneHeapTest(heapAsc);
                heapAsc.Clear();
            }
            
            var heapDesc = new Heap<int>(true);

            for (var i = 0; i < 5; i++)
            {
                OneHeapTest(heapDesc);
                heapDesc.Clear();
            }
        }

        private void OneHeapTest(Heap<int> heap)
        {
            for (var i = 0; i < 100; i++)
            {
                heap.Push(_random.Next(0, 1000));
            }

            do
            {
                var lhs = heap.Pop();
                var rhs = heap.Pop();

                Assert.True(lhs == rhs || lhs > rhs != heap.IsDescending);
            } while (!heap.IsEmpty);
        }
        
        [Test]
        public void PriorityQueueTest()
        {
            var queueAsc = new PriorityQueue<int>();

            for (var i = 0; i < 5; i++)
            {
                OneQueueTest(queueAsc);
                queueAsc.Clear();
            }
            
            var queueDesc = new PriorityQueue<int>(true);

            for (var i = 0; i < 5; i++)
            {
                OneQueueTest(queueAsc);
                queueAsc.Clear();
            }
        }
        
        private void OneQueueTest(PriorityQueue<int> queue)
        {
            for (var i = 0; i < 100; i++)
            {
                queue.Enqueue(0, _random.Next(0, 1000));
            }

            do
            {
                var lhs = queue.Dequeue();
                var rhs = queue.Dequeue();

                Assert.True(lhs == rhs || lhs > rhs != queue.IsDescending);
            } while (!queue.IsEmpty);
        }
    }
}