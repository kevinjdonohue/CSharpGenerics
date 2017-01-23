namespace CSharpGenerics
{
    public class CircularBuffer<T> : Buffer<T>
    {
        private readonly int _capacity;

        public CircularBuffer(int capacity = 3)
        {
            _capacity = capacity;
        }

        public override int Capacity => _capacity;

        public bool IsFull => Queue.Count == _capacity;

        public override void Write(T value)
        {
            base.Write(value);
            if (Queue.Count > _capacity)
            {
                Queue.Dequeue();  //throw away an item
            }
        }
    }
}