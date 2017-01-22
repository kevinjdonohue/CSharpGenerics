using System.Collections.Generic;

namespace CSharpGenerics
{
    class Buffer<T> : IBuffer<T>
    {
        readonly Queue<T> _queue = new Queue<T>();

        public bool IsEmpty => _queue.Count == 0;

        public bool IsFull { get; }

        public int Capacity => _queue.Count;

        public void Write(T value)
        {
            _queue.Enqueue(value);
        }

        public T Read()
        {
            return _queue.Dequeue();
        }
    }
}
