using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace CSharpGenerics
{
    public static class BufferExtensions
    {
        public delegate void Write<T>(T data);

        public static IEnumerable<TOutput> AsEnumerableOf<T, TOutput>(this IBuffer<T> buffer)
        {
            TypeConverter converter = TypeDescriptor.GetConverter(typeof(T));

            foreach (var item in buffer)
            {
//                if (!converter.CanConvertTo(typeof(TOutput))) continue;

                TOutput result = (TOutput)converter.ConvertTo(item, typeof(TOutput));

                yield return result;
            }
        }

        public static void DumpContents<T>(this IBuffer<T> buffer, Write<T> write)
        {
            foreach (T item in buffer)
            {
                write(item);
            }
        }
    }
}