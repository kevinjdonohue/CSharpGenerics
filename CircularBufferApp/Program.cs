using System;
using CSharpGenerics;

namespace CircularBufferApp
{
    class Program
    {
        static void Main(string[] args)
        {
            CircularBuffer<double> buffer = new CircularBuffer<double>(3);

            while (true)
            {
                double value = 0.0;

                string input = Console.ReadLine();

                if (double.TryParse(input, out value))
                {
                    buffer.Write(value);
                    continue;
                }

                break;
            }

            double sum = 0.0;

            Console.WriteLine("Buffer: ");

            while (!buffer.IsEmpty)
            {
                sum += buffer.Read();
            }

            Console.WriteLine(sum);

            Console.ReadLine();
        }
    }
}
