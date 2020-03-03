using System;

namespace DataStructuresCSharp.Stacks
{
    static class Test
    {
        public static void Main(string[] args)
        {
            Stack stack = new Stack(5);

            stack.Push(10);
            stack.Push(20);
            stack.Push(30);

            Console.WriteLine(stack.Pop());
            Console.WriteLine(stack.Peek());
            
            Console.WriteLine(stack);
        }
    }
}
