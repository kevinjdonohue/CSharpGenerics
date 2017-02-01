using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using CSharpGenerics;
using FluentAssertions;
using Xunit;
using Xunit.Abstractions;

namespace CSharpGenericsTests
{
    public class BufferExtensionsTests
    {
        private ITestOutputHelper _output;

        public BufferExtensionsTests(ITestOutputHelper output)
        {
            _output = output;
        }

        [Fact]
        public void GivenABuffer_WithThreeDoublesAdded_WhenAsEnumerableOfIntIsCalled_ThenAnIEnumerableOfIntsIsReturned()
        {
            //arrange
            Buffer<double> doubleBuffer = new Buffer<double>();
            doubleBuffer.Write(1.1);
            doubleBuffer.Write(2.2);
            doubleBuffer.Write(3.3);

            //act
            IEnumerable<int> enumerableOfInts = doubleBuffer.AsEnumerableOf<double, int>();

            //assert
            List<int> listOfInts = enumerableOfInts.ToList();
            listOfInts.Should().HaveCount(3);
            listOfInts[0].Should().Be(1);
            listOfInts[1].Should().Be(2);
            listOfInts[2].Should().Be(3);
        }

        [Fact]
        public void GivenABuffer_WithThreeDoublesAdded_WhenDumpContentsIsCalled_ThenTheBufferContentsAreOutputToTheConsole()
        {
            //arrange
            Buffer<double> doubleBuffer = new Buffer<double>();
            doubleBuffer.Write(1.1);
            doubleBuffer.Write(2.2);
            doubleBuffer.Write(3.3);

            //act
            doubleBuffer.DumpContents(UnitTestWrite);

            //TextWriter standardOut = Console.Out;

            //using (TextWriter tempOut = new StringWriter())
            //{
            //    Console.SetOut(tempOut);

                //act


            //    doubleBuffer.DumpContents(write);

                //assert
            //    string output = tempOut.ToString();
            //    output.Should().Be("1.1\r\n2.2\r\n3.3\r\n");
            //}

            //cleanup
            //Console.SetOut(standardOut);
        }

        public void UnitTestWrite(double data)
        {
            _output.WriteLine(data.ToString());
        }

    }
}