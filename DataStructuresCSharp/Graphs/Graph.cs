using System;
using System.Linq;
using System.Collections.Generic;

namespace DataStructuresCSharp.Graphs
{
    class Graph
    {
        private readonly Dictionary<string, Node> Nodes = new Dictionary<string, Node>();
        private readonly Dictionary<Node, List<Node>> AdjacencyList = new Dictionary<Node, List<Node>>();

        public void AddNode(string label)
        {
            var node = new Node(label);
            Nodes.TryAdd(label, node);
            AdjacencyList.Add(node, new List<Node>());
        }
        public void RemoveNode(string label)
        {
            var node = Nodes[label];
            if (node is null) return;

            foreach (var key in AdjacencyList.Keys)
                AdjacencyList[key].Remove(node);

            AdjacencyList.Remove(node);
            Nodes.Remove(node.Label);
        }
        public void AddEdge(string from, string to)
        {
            var fromNode = Nodes[from];
            var toNode = Nodes[to];

            if (fromNode is null || toNode is null)
                throw new InvalidOperationException();

            AdjacencyList[fromNode].Add(toNode);
        }
        public void RemoveEdge(string from, string to) 
        {
            var fromNode = Nodes[from];
            var toNode = Nodes[to];

            if (fromNode is null || toNode is null)
                return;

            AdjacencyList[fromNode].Remove(toNode);
        }
        public void Print()
        {
            foreach (var key in AdjacencyList.Keys)
            {
                if (AdjacencyList[key].Count > 0)
                {
                    var list = AdjacencyList[key]
                        .Select(n => n.ToString())
                        .Aggregate((a, b) => a + ", " + b);
                    Console.WriteLine($"{key} is connected to [{list}]");
                }
            }
        }

        private class Node
        {
            public string Label { get; set; }

            public Node(string label)
            {
                Label = label;
            }

            public override string ToString()
            {
                return Label;
            }
        }
    }
}
