using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.GenericBoxOfString
{
    internal class GenericCount
    {
        public static int Count<T> (List<T> list, T element) where T : IComparable
        {
            int count = 0;
            foreach(T item in list)
            {
                if (item.CompareTo(element) > 0)
                {
                    count++;
                }
            }
            return count;
        }
    }
}
