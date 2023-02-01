using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImplementingLinkedList
{
    internal class Node
    {
        public Node(int value)
        {
            Value = value;
        }
        public int Value { get; set; }
        public Node Next { get; set; }
        public Node Prev { get; set; }
    }
}
