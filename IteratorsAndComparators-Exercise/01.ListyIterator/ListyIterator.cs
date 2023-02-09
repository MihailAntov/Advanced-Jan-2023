using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSListyIterator
{
    public class ListyIterator<T> : IEnumerable<T>
    {
        List<T> items;
        int internalIndex;
        public ListyIterator(params T[] items)
        {
            this.items = items.ToList();
            internalIndex = 0;
        }

        public bool Move()
        {
            if(HasNext())
            {
                internalIndex++;
                return true;
            }
            return false;
            
        }

        public bool HasNext()
        {
            if(internalIndex == items.Count-1)
            {
                return false;
            }
            return true;
        }

        public void Print()
        {
            if(items.Count == 0)
            {
                Console.WriteLine("Invalid Operation!");
                return;
            }
            Console.WriteLine(items[internalIndex]);
        }
        public void PrintAll()
        {
            foreach(T item in this)
            {
                Console.Write(item+" ");
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            for(int i = 0; i < items.Count; i++)
            {
                yield return items[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
