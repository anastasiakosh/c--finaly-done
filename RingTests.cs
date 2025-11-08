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
            Assert.Equal("A", ring.Read());
        }

        [Fact]
        public void Remove_Works()
    {
            var ring = new Ring<int>();
            ring.Add(1);
            ring.Add(2);
            var removed = ring.Remove();
            Assert.Equal(1, ring.Count);
            Assert.Equal(1, removed); // теперь корректно
        }


        [Fact]
        public void OperatorMinus_Works()
        {
            var ring = new Ring<int>();
            ring += 5;
            ring += 10;
            ring = -ring; // удаляет текущий элемент (5)
            Assert.Equal(1, ring.Count);
            Assert.Equal(10, ring.Read()); // оставшийся элемент

        }

        [Fact]
        public void NextPrev_Works()
        {
            var ring = new Ring<string>();
            ring += "X";
            ring += "Y";
            ring += "Z";

            Assert.Equal("X", ring.Read());
            ++ring;
            Assert.Equal("Y", ring.Read());
            ++ring;
            Assert.Equal("Z", ring.Read());
            ++ring;
            Assert.Equal("X", ring.Read());

            --ring;
            Assert.Equal("Z", ring.Read());
            --ring;
            Assert.Equal("Y", ring.Read());
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

            int size = ring; // неявное приведение
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
        public void PrevOnEmpty_DoesNotThrow()
        {
            var ring = new Ring<int>();
            // можно вызывать Prev на пустом кольце без ошибки
            ring.Prev();
            Assert.Equal(0, ring.Count);
        }

        [Fact]
        public void NextOnEmpty_DoesNotThrow()
        {
            var ring = new Ring<int>();
            ring.Next();
            Assert.Equal(0, ring.Count);
        }

        [Fact]
        public void AddNullReference_Works()
        {
            var ring = new Ring<string?>();
            ring += null;
            Assert.Equal(1, ring.Count);
            Assert.Null(ring.Read());
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
