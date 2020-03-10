using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace DataStructuresCSharp.Queue
{
    class ArrayQueue<T>
    {
        private readonly T[] _items;
        private int _front;
        private int _rear;
        private int _count;

        public ArrayQueue(int size)
        {
            _items = new T[size];
            _front = _rear = _count = 0;
        }

        public void Enqueue(T item)
        {
            if (_count == _items.Length)
                throw new InvalidOperationException("Queue is full.");

            _items[_rear] = item;

            //Circular arrays, return the index to 0 if out of bounds
            _rear = (_rear + 1) % _items.Length;
            _count++;
        }

        public T Dequeue()
        {
            var item = _items[_front];
            _items[_front] = default;

            //Circular arrays, return the index to 0 if out of bounds
            _front = (_front + 1) % _items.Length;
            _count--;
            return item;
        }

        public T Peek {
            get { return _items[_front]; }
        }

        public bool IsEmpty {
            get { return !IsFull; }
        }

        public bool IsFull {
            get { return _rear == _front; }
        }

        public override string ToString()
        {
            return "[" + _items
                            .Select(item => item.ToString())
                            .Aggregate((a, b) => a + ", " + b) + "]";
        }
    }
}
