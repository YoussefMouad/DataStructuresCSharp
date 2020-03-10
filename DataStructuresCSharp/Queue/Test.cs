using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructuresCSharp.Queue
{
    static class Test
    {
        public static void Main(string[] args)
        {
            ArrayQueue<int> queue = new ArrayQueue<int>(5);
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);
            queue.Enqueue(4);
            queue.Enqueue(5);

            queue.Dequeue();
            queue.Enqueue(6);

            Console.WriteLine(queue.Peek);
            Console.WriteLine(queue);
            Console.WriteLine(queue.IsFull);
        }
    }
}
