using System;

namespace DataStructuresCSharp.AVLTree
{
    static class Test
    {
        public static void Main(string[] args)
        {
            AvlTree tree = new AvlTree();

            tree.Insert(10);
            tree.Insert(20);
            tree.Insert(30);

            Console.ReadKey();
        }
    }
}
