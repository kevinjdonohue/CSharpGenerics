using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;

namespace CSharpGenerics
{
    public class Buffer<T> : IBuffer<T>
    {
        protected readonly Queue<T> Queue = new Queue<T>();

        public virtual bool IsEmpty => Queue.Count == 0;

        public virtual int Capacity => Queue.Count;

        public virtual void Write(T value)
        {
            Queue.Enqueue(value);
        }

        public virtual T Read()
        {
            return Queue.Dequeue();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerator<T> GetEnumerator()
        {
            //return Queue.GetEnumerator();
            foreach (T item in Queue)
            {
                yield return item;
            }
        }
    }
}
