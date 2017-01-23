using System;
using CSharpGenerics;

namespace CircularBufferApp
{
    public class CircularBufferExample
    {
        public void Run()
        {
            IBuffer<double> buffer = InstantiateCircularBuffer();

            ProcessUserInput(buffer);

            ProcessBuffer(buffer);
        }

        private IBuffer<double> InstantiateCircularBuffer()
        {
            BufferFactory bufferFactory = new BufferFactory();
            IBuffer<double> buffer = bufferFactory.GetInstance<double>(BufferType.CircularBuffer);

            return buffer;
        }

        private void ProcessBuffer(IBuffer<double> buffer)
        {
            double sum = 0.0;

            Console.WriteLine("Buffer: ");

            while (!buffer.IsEmpty)
            {
                sum += buffer.Read();
            }

            Console.WriteLine(sum);
        }

        private void ProcessUserInput(IBuffer<double> buffer)
        {
            while (true)
            {
                double value = 0.0;

                string input = Console.ReadLine();

                if (Double.TryParse(input, out value))
                {
                    buffer.Write(value);
                    continue;
                }

                break;
            }
        }
    }
}