using System;
using System.Text;

namespace RingLibrary
{
    public class Ring<T> : IRing<T>
    {
        private RingItem<T>? current;
        private int count = 0;

        public int Count => count;

public void Add(T item)
{
    var node = new RingItem<T>(item);

    if (current == null)
    {
        node.Next = node;
        node.Prev = node;
        current = node;
    }
    else
    {
        var last = current.Prev!;   // последний элемент
        last.Next = node;
        node.Prev = last;
        node.Next = current;
        current.Prev = node;
    }

    count++;
}


        public T Read()
        {
            if (current == null)
                throw new InvalidOperationException("Кільце порожнє");

            return current.Value;
        }

        public T Remove()
        {
            if (current == null)
                throw new InvalidOperationException("Кільце порожнє");

            var value = current.Value;

            if (current.Next == current)
                current = null;
            else
            {
                current.Prev!.Next = current.Next;
                current.Next!.Prev = current.Prev;
                current = current.Next;
            }

            count--;
            return value;
        }

        public void Next() => current = current?.Next;
        public void Prev() => current = current?.Prev;

        public override string ToString()
{
            if (current == null) return "[порожнє кільце]";

            var sb = new StringBuilder();
            var node = current; // используем временную переменную
            var start = node;
            do
            {
                sb.Append($"{node.Value} ");
                node = node.Next!;
            } while (node != start);

            return sb.ToString().Trim();
        }

        // --- Перевантаження операторів ---
        public static Ring<T> operator +(Ring<T> ring, T item)
        {
            ring.Add(item);
            return ring;
                }

        public static Ring<T> operator -(Ring<T> ring)
        {
            ring.Remove();
            return ring;
        }

        public static Ring<T> operator ++(Ring<T> ring)
        {
            ring.Next();
            return ring;
        }

        public static Ring<T> operator --(Ring<T> ring)
        {
            ring.Prev();
            return ring;
        }

        public static bool operator ==(Ring<T> a, Ring<T> b) => a.Count == b.Count;
        public static bool operator !=(Ring<T> a, Ring<T> b) => a.Count != b.Count;

        public override bool Equals(object? obj) => obj is Ring<T> r && this == r;
        public override int GetHashCode() => Count.GetHashCode();

        public static implicit operator int(Ring<T> ring) => ring.Count;
    }
}
