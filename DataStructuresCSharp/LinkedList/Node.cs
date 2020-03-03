namespace DataStructuresCSharp.LinkedList
{
    class Node
    {
        public int Value { get; set; }
        public Node Next { get; set; }

        public Node(int value)
        {
            Value = value;
        }

        public override string ToString()
        {
            return "Value = " + Value;
        }
    }
}
