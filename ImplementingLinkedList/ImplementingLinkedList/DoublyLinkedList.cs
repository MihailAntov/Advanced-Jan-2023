using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomDoublyLinkedList
{
    public class DoublyLinkedList<T>
    {
        private Node<T> head;
        private Node<T> tail;
        public int Count { get; private set; }
        public void AddFirst(T value)
        {

            Node<T> newNode = new Node<T>(value);
            Count++;
            if (head == null)
            {

                head = newNode;
                tail = newNode;
            }
            else
            {
                head.Previous = newNode;
                newNode.Next = head;
                head = newNode;
            }
        }

        public void AddLast(T value)
        {
            Node<T> newNode = new Node<T>(value);
            Count++;
            if (tail == null)
            {

                head = newNode;
                tail = newNode;
                return;
            }


            tail.Next = newNode;
            newNode.Previous = tail;
            tail = newNode;
            
        }
    

        //public T PeakFirst()
        //{
        //    T result = Head.Value;
        //    return result;
            
        //}

        public T RemoveFirst()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("The list is empty");
            }

            T result = head.Value;

            head = head.Next;
            if(head != null)
            {
                head.Previous = null;
            }
            else
            {
                tail = null;
            }
            Count--;
            return result;
        }


        //public T PeakLast()
        //{
        //    T result = Tail.Value;
        //    return result;
        //}

        public T RemoveLast()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("The list is empty");
            }
            T result = tail.Value;
            tail = tail.Previous;
            if(tail != null)
            {
                tail.Next = null;
            }
            else
            {
                head = null;
            }
            
            
            Count--;
            return result;
        }

        //public void Print()
        //{
        //    ListNode<T> currentNode = Head;
        //    while(currentNode != null)
        //    {
        //        Console.Write($"{currentNode.Value} ");
        //        currentNode = currentNode.NextNode;
        //    }
        //    Console.Write(Environment.NewLine);
        //}

        //public void PrintInReverse()
        //{
        //    ListNode<T> currentNode = Tail;
        //    while (currentNode != null)
        //    {
        //        Console.Write($"{currentNode.Value} ");
        //        currentNode = currentNode.PreviousNode;
        //    }
        //    Console.Write(Environment.NewLine);
        //}

        public void ForEach(Action<T> action)
        {
            Node<T> current = head;
            while(current != null)
            {
                action(current.Value);
                current = current.Next;
            }
        }

        //public void ForEachReversed(Action<ListNode<T>> action)
        //{
        //    ListNode<T> tail = Tail;
        //    while (tail != null)
        //    {
        //        action(tail);
        //        tail = tail.PreviousNode;
        //    }
        //}

        public T[] ToArray()
        {
            T[] result = new T[Count];
            Node<T> currentNode = head;
            for(int i = 0; i < Count; i++)
            {
                result[i] = currentNode.Value;
                currentNode = currentNode.Next;
            }
            return result;
        }


    }
}
