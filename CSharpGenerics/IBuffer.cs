using System.Collections.Generic;

namespace CSharpGenerics
{
    public interface IBuffer<T> : IEnumerable<T>
    {
        bool IsEmpty { get; }
        int Capacity { get; }
        void Write(T value);
        T Read();
    }
}