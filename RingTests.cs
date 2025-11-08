using Xunit;
using System;
using RingLibrary;

namespace RingLibrary.Tests
{
    public class RingTests
    {
        [Fact]
        public void AddAndRead_Works()
        {
            var ring = new Ring<int>();
            ring.Add(10);
            Assert.Equal(10, ring.Read());
            Assert.Equal(1, ring.Count);
        }

        [Fact]
        public void OperatorAdd_Works()
        {
            var ring = new Ring<string>();
            ring += "A";
            ring += "B";
            ring += "C";
            Assert.Equal(3, ring.Count);
        }

        [Fact]
        public void Remove_Works()
        {
            var ring = new Ring<int>();
            ring.Add(1);
            ring.Add(2);
            var removed = ring.Remove();
            Assert.Equal(1, ring.Count);
        }

        [Fact]
        public void NextPrev_Works()
        {
            var ring = new Ring<string>();
            ring += "X";
            ring += "Y";
            ring += "Z";

            Assert.Equal("X", ring.Read());
            ring++;
            Assert.Equal("Y", ring.Read());
            ring++;
            Assert.Equal("Z", ring.Read());
            ring++;
            Assert.Equal("X", ring.Read());

            ring--;
            Assert.Equal("Z", ring.Read());
            ring--;
            Assert.Equal("Y", ring.Read());
        }

        [Fact]
        public void OperatorMinus_Works()
      {
            var ring = new Ring<int>();
            ring += 5;
            ring += 10;
            ring = -ring; // удаляет текущий элемент через оператор
            Assert.Equal(1, ring.Count);
        }

        [Fact]
        public void EqualityOperators_Works()
        {
            var a = new Ring<int>();
            var b = new Ring<int>();
            a += 1; a += 2;
            b += 3; b += 4;

            Assert.True(a == b);
            a += 5;
            Assert.True(a != b);
        }

        [Fact]
        public void ImplicitConversionToInt_Works()
    {
            var ring = new Ring<int>();
            ring += 1;
            ring += 2;

            int size = (int)ring; // явное приведение
            Assert.Equal(2, size);
        }

        [Fact]
        public void RemoveFromEmpty_Throws()
        {
            var ring = new Ring<int>();
            Assert.Throws<InvalidOperationException>(() => ring.Remove());
        }

        [Fact]
        public void ReadFromEmpty_Throws()
        {
            var ring = new Ring<int>();
            Assert.Throws<InvalidOperationException>(() => ring.Read());
        }

        [Fact]
        public void ToString_Works()
        {
            var ring = new Ring<string>();
            ring += "A";
            ring += "B";
            ring += "C";

            string result = ring.ToString();
            Assert.Contains("A", result);
            Assert.Contains("B", result);
            Assert.Contains("C", result);
        }
    }
}
