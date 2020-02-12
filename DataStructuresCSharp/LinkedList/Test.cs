using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructuresCSharp.LinkedList
{
    class Test
    {
        public static void Main(string[] args)
        {
            LinkedList list = new LinkedList();

            list.AddLast(10);
            list.AddLast(20);
            list.AddLast(30);
            list.AddLast(40);
            list.AddLast(50);

            list.Print();

            Console.WriteLine("------------\n{0}", list.GetKthFromTheEnd(3));
        }
    }
}
