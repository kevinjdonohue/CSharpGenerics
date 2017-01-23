using System;
using CSharpGenerics;
using FluentAssertions;
using Ploeh.AutoFixture;
using Xunit;

namespace CSharpGenericsTests
{
    public class DoubleCircularBufferTests : IDisposable
    {
        private readonly BufferFactory _bufferFactory = new BufferFactory();
        private IBuffer<double> _sut;
        private Fixture _fixture;

        public DoubleCircularBufferTests()
        {
            _sut = _bufferFactory.GetInstance<double>(BufferType.CircularBuffer);
            _fixture = new Fixture();
        }

        public void Dispose()
        {
            _sut = null;
            _fixture = null;
        }

        [Fact]
        public void GivenADefaultBuffer_WhenCapacityIsCalled_ThenFourIsReturned()
        {
            //arrange

            //act
            int capacity = _sut.Capacity;

            //assert
            capacity.Should().Be(3, "a newly constructed default buffer is given a capacity of the desired capacity");
        }

        [Fact]
        public void GivenADefaultBuffer_WithNoElementsAdded_WhenIsEmptyIsCalled_ThenTrueIsReturned()
        {
            //arrange

            //act
            bool isEmpty = _sut.IsEmpty;

            //assert
            isEmpty.Should().BeTrue("a newly constructed buffer should not contain anything");
        }

        [Fact]
        public void GivenADefaultBuffer_WithOneElementAdded_WhenIsEmptyIsCalled_ThenFalseIsReturned()
        {
            //arrange
            _sut.Write(_fixture.Create<double>());
            _sut.Write(_fixture.Create<double>());

            //act
            bool isEmpty = _sut.IsEmpty;

            //assert
            isEmpty.Should().BeFalse("a buffer with a capacity of three and two elements written to it should not be full");
        }

        [Fact]
        public void GivenADefaultBuffer_WithTwoElementsAdded_WhenIsFullIsCalled_ThenFalseIsReturned()
        {
            //arrange
            _sut.Write(_fixture.Create<double>());
            _sut.Write(_fixture.Create<double>());

            //act
            CircularBuffer<double> circularBuffer = _sut as CircularBuffer<double>;
            bool isFull = circularBuffer.IsFull;

            //assert
            isFull.Should().BeFalse("a buffer with a capacity of three and two elements written to it should not be full");
        }

        [Fact]
        public void GivenADefaultBuffer_WithThreeElementsAdded_WhenIsFullIsCalled_ThenTrueIsReturned()
        {
            //arrange
            _sut.Write(_fixture.Create<double>());
            _sut.Write(_fixture.Create<double>());
            _sut.Write(_fixture.Create<double>());

            //act
            CircularBuffer<double> circularBuffer = _sut as CircularBuffer<double>;
            bool isFull = circularBuffer.IsFull;

            //assert
            isFull.Should().BeTrue("a buffer with a capacity of three and three elements written to it should be full");
        }

        [Fact]
        public void GivenADefaultBuffer_WithTwoElementsAdded_WhenReadIsCalled_ThenValuesAreReturnedFirstInFirstOut()
        {
            //arrange
            double expectedValue1 = _fixture.Create<double>();
            double expectedValue2 = _fixture.Create<double>();
            _sut.Write(expectedValue1);
            _sut.Write(expectedValue2);

            //act
            double actualValue1 = _sut.Read();
            double actualValue2 = _sut.Read();

            //assert
            actualValue1.Should().Be(expectedValue1, "the circular buffer returns values first in first out");
            actualValue2.Should().Be(expectedValue2, "the circular buffer returns values first in first out");
        }

        [Fact]
        public void GivenADefaultBuffer_WithFiveElementsAdded_WhenReadIsCalled_ThenValuesAreOverwrittenAndReturnedFirstInFirstOut()
        {
            //arrange
            double expectedValue1 = _fixture.Create<double>();
            double expectedValue2 = _fixture.Create<double>();
            double expectedValue3 = _fixture.Create<double>();
            double expectedValue4 = _fixture.Create<double>();
            double expectedValue5 = _fixture.Create<double>();
            _sut.Write(expectedValue1);
            _sut.Write(expectedValue2);
            _sut.Write(expectedValue3);
            _sut.Write(expectedValue4);
            _sut.Write(expectedValue5);

            //act
            double actualValue1 = _sut.Read();
            double actualValue2 = _sut.Read();
            double actualValue3 = _sut.Read();

            //assert
            actualValue1.Should().Be(expectedValue3, "the circular buffer values were overwritten; return values first in first out");
            actualValue2.Should().Be(expectedValue4, "the circular buffer values were overwritten; return values first in first out");
            actualValue3.Should().Be(expectedValue5, "the circular buffer values were overwritten; return values first in first out");
        }
    }
}