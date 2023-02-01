using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImplementingLinkedList
{
    internal class DoublyLinkedList
    {
        public DoublyLinkedList()
        {
            
        }
        public Node Head { get; set; }
        public Node Tail { get; set; }
        public int Count { get; set; }
        public void AddFirst(int value)
        {
            
            Node newNode = new Node(value);
            Count++;
            if (Head == null)
            {
                
                Head = newNode;
                Tail = newNode;
            }
            else
            {
                Head.Prev = newNode;
                newNode.Next = Head;
                Head = newNode;
            }
        }

        public void AddLast(int value)
        {
            Node newNode = new Node(value);
            Count++;
            if (Tail == null)
            {

                Head = newNode;
                Tail = newNode;
                return;
            }
            
            
            Tail.Next = newNode;
            newNode.Prev = Tail;
            Tail = newNode;
            
        }
    

        public int PeakFirst()
        {
            int result = Head.Value;
            return result;
            
        }

        public int RemoveFirst()
        {
            int result = Head.Value;
            Head = Head.Next == null ? null : Head.Next;
            Head.Prev = null;
            Count--;
            return result; 
        }


        public int PeakLast()
        {
            int result = Tail.Value;
            return result;
        }

        public int RemoveLast()
        {
            int result = Tail.Value;
            Tail = Tail.Prev == null ? null : Tail.Prev;
            Tail.Next = null;
            Count--;
            return result;
        }

        public void Print()
        {
            Node currentNode = Head;
            while(currentNode != null)
            {
                Console.Write($"{currentNode.Value} ");
                currentNode = currentNode.Next;
            }
            Console.Write(Environment.NewLine);
        }

        public void PrintInReverse()
        {
            Node currentNode = Tail;
            while (currentNode != null)
            {
                Console.Write($"{currentNode.Value} ");
                currentNode = currentNode.Prev;
            }
            Console.Write(Environment.NewLine);
        }

        public void ForEach(Action<Node> action)
        {
            Node head = Head;
            while(head != null)
            {
                action(head);
                head = head.Next;
            }
        }

        public void ForEachReversed(Action<Node> action)
        {
            Node tail = Tail;
            while (tail != null)
            {
                action(tail);
                tail = tail.Prev;
            }
        }


    }
}
