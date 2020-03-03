using System;

namespace DataStructuresCSharp.AVLTree
{
    /// <summary>
    /// Balanced version of Trees
    /// </summary>
    class AvlTree
    {
        private AvlNode Root { get; set; }

        public void Insert(int value)
        {
            Root = Insert(Root, value);
        }

        private AvlNode Insert(AvlNode root, int value)
        {
            if (root == null) {
                return new AvlNode(value);
            }

            if (value < Root.Value)
                root.Left = Insert(root.Left, value);
            else
                root.Right = Insert(root.Right, value);

            SetHeight(root);

            return Balance(root);
        }

        private AvlNode Balance(AvlNode root)
        {
            if (IsLeftHeavy(root)) {
                if (BalanceFactor(root.Left) < 0)
                    root.Left = LeftRotate(root.Left);
                return RightRotate(root);
            } else if (IsRightHeavy(root)) {
                if (BalanceFactor(root.Right) > 0)
                    root.Right = RightRotate(root.Right);
                return LeftRotate(root);
            }

            return root;
        }

        private AvlNode LeftRotate(AvlNode root)
        {
            var newRoot = root.Right;
            root.Right = newRoot.Left;
            newRoot.Left = root;

            SetHeight(root);
            SetHeight(newRoot);

            return newRoot;
        }

        private AvlNode RightRotate(AvlNode root)
        {
            var newRoot = root.Left;
            root.Left = newRoot.Right;
            newRoot.Right = root;

            SetHeight(root);
            SetHeight(newRoot);

            return root;
        }

        private void SetHeight(AvlNode node)
        {
            node.Height = Math.Max(Height(node.Left), Height(node.Right)) + 1;
        }

        private int BalanceFactor(AvlNode root)
        {
            return Height(root.Left) - Height(root.Right);
        }

        private bool IsLeftHeavy(AvlNode root)
        {
            return BalanceFactor(root) > 1;
        }

        private bool IsRightHeavy(AvlNode root)
        {
            return BalanceFactor(root) < -1;
        }

        public int Height()
        {
            return Height(Root);
        }

        private int Height(AvlNode root)
        {
            return (root == null) ? -1 : root.Height;
        }

        private class AvlNode
        {
            public int Value { get; set; }
            public AvlNode Left { get; set; }
            public AvlNode Right { get; set; }
            public int Height { get; set; }

            public AvlNode(int value)
            {
                Value = value;
                Height = 0;
            }

            public override string ToString()
            {
                return "Node  = " + Value;
            }
        }
    }
}
