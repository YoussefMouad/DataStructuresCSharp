using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructuresCSharp.AVLTree
{
    /// <summary>
    /// Balanced version of Trees
    /// </summary>
    class AVLTree
    {
        private AVLNode Root { get; set; }

        public void Insert(int value)
        {
            Root = Insert(Root, value);
        }

        private AVLNode Insert(AVLNode root, int value)
        {
            if (root == null) {
                return new AVLNode(value);
            }

            if (value < Root.Value)
                root.Left = Insert(root.Left, value);
            else
                root.Right = Insert(root.Right, value);

            SetHeight(root);

            return Balance(root);
        }

        private AVLNode Balance(AVLNode root)
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

        private AVLNode LeftRotate(AVLNode root)
        {
            var newRoot = root.Right;
            root.Right = newRoot.Left;
            newRoot.Left = root;

            SetHeight(root);
            SetHeight(newRoot);

            return newRoot;
        }

        private AVLNode RightRotate(AVLNode root)
        {
            var newRoot = root.Left;
            root.Left = newRoot.Right;
            newRoot.Right = root;

            SetHeight(root);
            SetHeight(newRoot);

            return root;
        }

        private void SetHeight(AVLNode node)
        {
            node.Height = Math.Max(Height(node.Left), Height(node.Right)) + 1;
        }

        private int BalanceFactor(AVLNode root)
        {
            return Height(root.Left) - Height(root.Right);
        }

        private bool IsLeftHeavy(AVLNode root)
        {
            return BalanceFactor(root) > 1;
        }

        private bool IsRightHeavy(AVLNode root)
        {
            return BalanceFactor(root) < -1;
        }

        public int Height()
        {
            return Height(Root);
        }

        private int Height(AVLNode root)
        {
            return (root == null) ? -1 : root.Height;
        }

        private class AVLNode
        {
            public int Value { get; set; }
            public AVLNode Left { get; set; }
            public AVLNode Right { get; set; }
            public int Height { get; set; }

            public AVLNode(int value)
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
