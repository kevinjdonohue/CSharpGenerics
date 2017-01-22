﻿using System;
using CSharpGenerics;

namespace CircularBufferApp
{
    class Program
    {
        static void Main(string[] args)
        {
            IBuffer<double> buffer = new CircularBuffer<double>(3);

            ProcessUserInput(buffer);

            ProcessBuffer(buffer);

            Console.ReadLine();
        }

        private static void ProcessBuffer(IBuffer<double> buffer)
        {
            double sum = 0.0;

            Console.WriteLine("Buffer: ");

            while (!buffer.IsEmpty)
            {
                sum += buffer.Read();
            }

            Console.WriteLine(sum);
        }

        private static void ProcessUserInput(IBuffer<double> buffer)
        {
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
        }
    }
}
