using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructuresCSharp.LinkedList
{
    class LinkedList
    {
        private Node _first;
        private Node _last;
        public int Size { get; private set; }

        public void AddFirst(int value)
        {
            var node = new Node(value);
            if (IsEmpty()) {
                _first = _last = node;
            } else {
                node.Next = _first;
                _first = node;
            }
            Size++;
        }

        public void AddLast(int value)
        {
            var node = new Node(value);
            if (IsEmpty()) {
                _first = _last = node;
            } else {
                _last.Next = node;
                _last = node;
            }
            Size++;
        }

        public void RemoveFirst()
        {
            if (IsEmpty())
                throw new InvalidOperationException("No such element.");

            if (_first == _last) {
                _first = _last = null;
                Size = 0;
                return;
            }

            var second = _first.Next;
            _first.Next = null;
            _first = second;
            Size--;
        }

        public void RemoveLast()
        {
            if (IsEmpty())
                throw new InvalidOperationException("No such element.");

            if (_first == _last) {
                _first = _last = null;
                Size = 0;
                return;
            }

            var previous = Previous(_last);
            _last = previous;
            _last.Next = null;
            Size--;
        }

        private Node Previous(Node node)
        {
            var current = _first;
            while (current != null) {
                if (current.Next == node) return current;
                current = current.Next;
            }
            return null;
        }

        public bool Contains(int value)
        {
            return IndexOf(value) == -1;
        }

        public int IndexOf(int value)
        {
            var node = _first;
            int index = 0;
            while (node != null) {
                if (node.Value == value) {
                    return index;
                }
                node = node.Next;
                index++;
            }
            return -1;
        }

        public bool IsEmpty()
        {
            return _first == null;
        }

        public int[] ToArray()
        {
            int[] array = new int[Size];
            var current = _first;
            int index = 0;
            while (current != null) {
                array[index++] = current.Value;
                current = current.Next;
            }

            return array;
        }

        public void Reverse()
        {
            if (IsEmpty()) return;

            var previous = _first;
            var current = _first.Next;

            while (current != null) {
                var next = current.Next;
                current.Next = previous;
                previous = current;
                current = next;
            }

            _last = _first;
            _last.Next = null;
            _first = previous;
        }

        public int GetKthFromTheEnd(int k)
        {
            if (IsEmpty())
                throw new InvalidOperationException();

            var node1 = _first;
            var node2 = _first;

            for (int i = 0; i < k - 1; i++) {
                node1 = node1.Next;
                if (node1 == null)
                    throw new InvalidOperationException();
            }

            while (node1 != _last) {
                node1 = node1.Next;
                node2 = node2.Next;
            }

            return node2.Value;
        }

        public void Print()
        {
            var node = _first;
            while (node != null) {
                Console.WriteLine(node.Value);
                node = node.Next;
            }
        }
    }
}
