namespace CSharpGenerics
{
    public class BufferFactory
    {
        public IBuffer<T> GetInstance<T>(BufferType bufferType)
        {
            if (bufferType == BufferType.CircularBuffer)
            {
                return new CircularBuffer<T>();
            }

            return new Buffer<T>();
        }
    }
}