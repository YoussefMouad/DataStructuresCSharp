using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace DataStructuresCSharp.Trees
{
    class Test
    {
        static void Main(string[] args)
        {
            Tree tree1 = new Tree();

            tree1.Insert(7);
            tree1.Insert(4);
            tree1.Insert(9);
            tree1.Insert(1);
            tree1.Insert(6);
            tree1.Insert(8);
            tree1.Insert(10);

            tree1.TraverseLevelOrder();

            
            Console.ReadKey();
        }
    }
}
