using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoxOfT
{
    public class Box<T>
    {
        private int count;
        private List<T> items;

        public Box()
        {
            Items = new List<T>();
        }

        public List<T> Items { get { return items; } private set { items = value; } }
        public int Count { get { return count; } private set { count = value; } }

        public void Add(T element)
        {
            Items.Add(element);
            Count++;

        }

        public T Remove()
        {
            T element = Items[Items.Count - 1];
            Items.RemoveAt(Items.Count - 1);
            Count--;
            return element;
        }
    }
}
