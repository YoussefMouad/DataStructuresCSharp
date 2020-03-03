using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructuresCSharp.Graphs
{
    class Graph
    {



        private class Node
        {
            public string Label { get; set; }

            public Node(string label)
            {
                Label = label;
            }

            public override string ToString()
            {
                return "Node  = " + Label;
            }
        }
    }
}
