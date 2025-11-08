using System;
using RingLibrary;

namespace RingConsoleApp
{
    class Program
    {
        static void Main()
        {
            var ring = new Ring<string>();

            ring += "A";
            ring += "B";
            ring += "C";

            Console.WriteLine("Початкове кільце:");
            Console.WriteLine(ring);

            ring++;
            Console.WriteLine("\nПісля ++:");
            Console.WriteLine(ring.Read());

            ring--;
            Console.WriteLine("\nПісля --:");
            Console.WriteLine(ring.Read());

            ring.Remove();
            Console.WriteLine($"\nПісля видалення одного елемента, кількість: {ring.Count}");

            int size = ring;
            Console.WriteLine($"\nНеявне приведення до int: {size}");
        }
    }
}
