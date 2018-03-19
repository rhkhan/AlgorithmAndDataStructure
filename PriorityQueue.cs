using System;
using System.Collections;
using System.Collections.Generic;


namespace PriorityQueue1
{
    class Class1
    {
        static void Main(string[] args)
        {
            PriorityQueue<int, int> p = new PriorityQueue<int, int>();
            KeyValuePair<int, int> kvp = new KeyValuePair<int, int>(3, 10);
            p.Add(kvp); // Add key,value pair in the priority queue
            KeyValuePair<int, int> kvp1 = new KeyValuePair<int, int>(2, 25);
            p.Add(kvp1); // Add key, value pair in the priority queue
            //p.Dequeue();

            List<KeyValuePair<int, int>> a = new List<KeyValuePair<int, int>>();
            a.Add(p.Peek()); //peek the item of minimum priority from the priority queue and add it to a list.
            p.Remove(p.Peek()); // After peeking the item remove it from the priority queue
            a.Add(p.Peek()); //peek the available item of minimum priority from the priority queue and add it to a list.
            p.Remove(p.Peek()); // After peeking the item remove it from the priority queue

            for (int i = 0; i < a.Count; i++)
                Console.WriteLine(a[i]);

            Console.Read();
        }
    }

    public class PriorityQueue<TPriority, TValue> : ICollection<KeyValuePair<TPriority, TValue>>
    {
        private List<KeyValuePair<TPriority, TValue>> _baseHeap;
        private IComparer<TPriority> _comparer;

        #region Constructors
        public PriorityQueue()
            : this(Comparer<TPriority>.Default)
        {
        }

        public PriorityQueue(IComparer<TPriority> comparer)
        {
            if (comparer == null)
                throw new ArgumentNullException();

            _baseHeap = new List<KeyValuePair<TPriority, TValue>>();
            _comparer = comparer;
        }

        #endregion


        #region Priority queue operations

        public void Enqueue(TPriority priority, TValue value)
        {
            Insert(priority, value);
        }


        public KeyValuePair<TPriority, TValue> Peek()
        {
            if (!IsEmpty)
                return _baseHeap[0];
            else
                throw new InvalidOperationException("Priority queue is empty");
        }



        /// <summary>
        /// Gets whether priority queue is empty
        /// </summary>
        public bool IsEmpty
        {
            get { return _baseHeap.Count == 0; }
        }

        #endregion

        #region Heap operations

        private void ExchangeElements(int pos1, int pos2)
        {
            KeyValuePair<TPriority, TValue> val = _baseHeap[pos1];
            _baseHeap[pos1] = _baseHeap[pos2];
            _baseHeap[pos2] = val;
        }

        private void Insert(TPriority priority, TValue value)
        {
            KeyValuePair<TPriority, TValue> val = new KeyValuePair<TPriority, TValue>(priority, value);
            _baseHeap.Add(val);

            // heap[i] have children heap[2*i + 1] and heap[2*i + 2] and parent heap[(i-1)/ 2];

            // heapify after insert, from end to beginning
            HeapifyFromEndToBeginning(_baseHeap.Count - 1);
        }


        private int HeapifyFromEndToBeginning(int pos)
        {
            if (pos >= _baseHeap.Count) return -1;

            while (pos > 0)
            {
                int parentPos = (pos - 1) / 2;
                if (_comparer.Compare(_baseHeap[parentPos].Key, _baseHeap[pos].Key) > 0)
                {
                    ExchangeElements(parentPos, pos);
                    pos = parentPos;
                }
                else break;
            }
            return pos;
        }



        private void HeapifyFromBeginningToEnd(int pos)
        {
            if (pos >= _baseHeap.Count) return;

            // heap[i] have children heap[2*i + 1] and heap[2*i + 2] and parent heap[(i-1)/ 2];

            while (true)
            {
                // on each iteration exchange element with its smallest child
                int smallest = pos;
                int left = 2 * pos + 1;
                int right = 2 * pos + 2;
                if (left < _baseHeap.Count && _comparer.Compare(_baseHeap[smallest].Key, _baseHeap[left].Key) > 0)
                    smallest = left;
                if (right < _baseHeap.Count && _comparer.Compare(_baseHeap[smallest].Key, _baseHeap[right].Key) > 0)
                    smallest = right;

                if (smallest != pos)
                {
                    ExchangeElements(smallest, pos);
                    pos = smallest;
                }
                else break;
            }
        }

        #endregion

        public void Add(KeyValuePair<TPriority, TValue> item)
        {
            Enqueue(item.Key, item.Value);
        }

        public void Clear()
        {
            _baseHeap.Clear();
        }
        public bool Contains(KeyValuePair<TPriority, TValue> item)
        {
            return _baseHeap.Contains(item);
        }
        public int Count
        {
            get { return _baseHeap.Count; }
        }
        public void CopyTo(KeyValuePair<TPriority, TValue>[] array, int arrayIndex)
        {
            _baseHeap.CopyTo(array, arrayIndex);
        }
        public bool IsReadOnly
        {
            get { return false; }
        }

        public bool Remove(KeyValuePair<TPriority, TValue> item)
        {
            // find element in the collection and remove it
            int elementIdx = _baseHeap.IndexOf(item);
            if (elementIdx < 0) return false;

            //remove element
            _baseHeap[elementIdx] = _baseHeap[_baseHeap.Count - 1];
            _baseHeap.RemoveAt(_baseHeap.Count - 1);

            // heapify
            int newPos = HeapifyFromEndToBeginning(elementIdx);
            if (newPos == elementIdx)
                HeapifyFromBeginningToEnd(elementIdx);

            return true;
        }

        public IEnumerator<KeyValuePair<TPriority, TValue>> GetEnumerator()
        {
            return _baseHeap.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

    }
}
