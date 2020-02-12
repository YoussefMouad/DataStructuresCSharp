using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructuresCSharp.AVLTree
{
    class Test
    {
        public static void Main(string[] args)
        {
            AVLTree tree = new AVLTree();

            tree.Insert(10);
            tree.Insert(20);
            tree.Insert(30);

            Console.ReadKey();
        }
    }
}
