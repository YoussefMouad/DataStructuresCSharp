using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace DataStructuresCSharp.Trees
{
    class Tree : IEquatable<Tree>
    {
        private Node Root { get; set; }

        public void Insert(int value)
        {
            var newNode = new Node(value);
            if (Root == null) {
                Root = newNode;
                return;
            }

            var current = Root;
            while (true) {
                if (value < current.Value) {
                    if (current.Left is null) {
                        current.Left = newNode;
                        break;
                    }
                    current = current.Left;
                } else {
                    if (current.Right is null) {
                        current.Right = newNode;
                        break;
                    }
                    current = current.Right;
                }
            }
        }

        public bool Find(int value)
        {
            var current = Root;

            while (current != null) {
                if (value < current.Value) {
                    current = current.Left;
                } else if (value > current.Value) {
                    current = current.Right;
                } else {
                    return true;
                }
            }
            return false;
        }

        public void TraversePreOrder()
        {
            TraversePreOrder(Root);
        }

        private void TraversePreOrder(Node root)
        {
            if (root is null)
                return;
            Console.WriteLine(root.Value);
            TraversePreOrder(root.Left);
            TraversePreOrder(root.Right);
        }

        public void TraversePostOrder()
        {
            TraversePostOrder(Root);
        }

        private void TraversePostOrder(Node root)
        {
            if (root is null)
                return;
            TraversePostOrder(root.Left);
            TraversePostOrder(root.Right);
            Console.WriteLine(root.Value);
        }

        public void TraverseInOrder()
        {
            TraverseInOrder(Root);
        }

        private void TraverseInOrder(Node root)
        {
            if (root is null)
                return;
            TraverseInOrder(root.Left);
            Console.WriteLine(root.Value);
            TraverseInOrder(root.Right);
        }

        public int Height()
        {
            return Height(Root);
        }

        private int Height(Node root)
        {
            if (root is null)
                return -1;

            if (IsLeaf(root))
                return 0;

            return 1 + Math.Max(Height(root.Left), Height(root.Right));
        }

        public int Min()
        {
            return Min(Root);
        }

        private int Min(Node root)
        {
            if (IsLeaf(root))
                return root.Value;

            var left = Min(root.Left);
            var right = Min(root.Right);

            return Math.Min(Math.Min(left, right), root.Value);
        }

        private bool IsLeaf(Node node)
        {
            return node.Left is null && node.Right is null;
        }

        private bool Equals(Node first, Node second)
        {
            if (first is null && second is null)
                return true;


            if (first != null && second != null)
                return first.Value == second.Value
                    && Equals(first.Left, second.Left)
                    && Equals(first.Right, second.Right);

            return false;
        }

        public bool Equals([AllowNull] Tree other)
        {
            return Equals(Root, other.Root);
        }

        public bool IsBinarySearchTree()
        {
            return IsBinarySearchTree(Root, int.MinValue, int.MaxValue);
        }

        private bool IsBinarySearchTree(Node node, int min, int max)
        {
            if (node is null)
                return true;

            if (node.Value < min && node.Value > max)
                return false;
            return IsBinarySearchTree(node.Left, min, node.Value - 1) && IsBinarySearchTree(node.Right, node.Value + 1, max);
        }

        public List<int> GetNodesAtDistance(int distance)
        {
            var list = new List<int>();
            GetNodesAtDistance(Root, distance, list);
            return list;
        }

        private void GetNodesAtDistance(Node node, int distance, List<int> list)
        {
            if (node == null) return;

            if (distance == 0) {
                list.Add(node.Value);
                return;
            }
            GetNodesAtDistance(node.Left, distance - 1, list);
            GetNodesAtDistance(node.Right, distance - 1, list);
        }

        public void TraverseLevelOrder()
        {
            for (int i = 0; i <= Height(); i++) {
                foreach (var value in GetNodesAtDistance(i)) {
                    Console.WriteLine(value);
                }
            }
        }

        private class Node
        {
            public int Value { get; set; }
            public Node Left { get; set; }
            public Node Right { get; set; }

            public Node(int value)
            {
                Value = value;
            }

            public override string ToString()
            {
                return "Node  = " + Value;
            }
        }
    }
}
