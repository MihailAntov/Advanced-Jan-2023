using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.CustomStack
{
    public class CStack<T> : IEnumerable<T>
    {
        List<T> items;
        int count;

        public CStack()
        {
            items = new List<T>();
        }
        public int Count { get { return count; } }
        public IEnumerator<T> GetEnumerator()
        {
            for(int i = count-1; i >=0; i--)
            {
                yield return items[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public string Pop()
        {
            if(count == 0)
            {
                throw new InvalidOperationException("No elements");
            }
            
            T result = items[count-1];
            items.RemoveAt(count - 1);
            count--;
            return result.ToString();
        }

        public void Push(params T[] values)
        {
            foreach(T item in values)
            {
                items.Add(item);
            }
            count += values.Length;
        }
    }
}
