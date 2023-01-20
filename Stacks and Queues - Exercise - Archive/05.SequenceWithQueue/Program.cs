using System;
using System.Collections.Generic;

namespace _05.SequenceWithQueue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            long n = long.Parse(Console.ReadLine());


            Queue<long> results = new Queue<long>();
            Queue<long> workingQueue = new Queue<long>();

            
            results.Enqueue(n);
            long s1 = n;
            while(results.Count < 50)
            {
                long s2 = s1 + 1;
                long s3 = 2 * s1 + 1;
                long s4 = s1 + 2;

                results.Enqueue(s2);
                results.Enqueue(s3);
                results.Enqueue(s4);

                workingQueue.Enqueue(s2);
                workingQueue.Enqueue(s3);
                workingQueue.Enqueue(s4);

                s1 = workingQueue.Dequeue();
            }

            for(int i = 0; i < 50; i ++)
            {
                Console.Write($"{results.Dequeue()}"+" ");
            }
        }


    }
}
