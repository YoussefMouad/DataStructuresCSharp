using System;
using System.Linq;

namespace DataStructuresCSharp.Stacks
{
    class Stack
    {
        private int[] items;
        private int count;

        public Stack(int size)
        {
            items = new int[size];
        }

        public void Push(int item)
        {
            if (count == items.Length)
                throw new StackOverflowException();

            items[count++] = item;
        }

        public int Pop()
        {
            if (count == 0)
                throw new InvalidOperationException();

            return items[--count];
        }

        public int Peek()
        {
            if (count == 0)
                throw new InvalidOperationException();

            return items[count - 1];
        }

        public bool IsEmpty()
        {
            return count == 0;
        }

        public override string ToString()
        {
            return $"[{string.Join(", ", items.Where((item, index) => index < count))}]";
        }
    }
}
