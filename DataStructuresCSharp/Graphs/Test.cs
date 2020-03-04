using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructuresCSharp.Graphs
{
    static class Test
    {
        public static void Main(string[] args)
        {
            var graph = new Graph();

            graph.AddNode("A");
            graph.AddNode("B");
            graph.AddNode("C");
            
            graph.AddEdge("A", "B");
            graph.AddEdge("A", "C");
            graph.AddEdge("C", "A");

            graph.Print();
            Console.WriteLine("-------------------------");

            graph.RemoveEdge("A", "C");

            graph.Print();
            Console.WriteLine("-------------------------");

            graph.RemoveNode("C");

            graph.Print();
        }
    }
}
