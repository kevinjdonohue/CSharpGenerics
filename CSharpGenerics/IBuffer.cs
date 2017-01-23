namespace CSharpGenerics
{
    public interface IBuffer<T>
    {
        bool IsEmpty { get; }
        int Capacity { get; }
        void Write(T value);
        T Read();
    }
}