using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomComparator
{
    public class CustomComparer : IComparer<int>
    {
        public int Compare(int x, int y)
        {
            return comparator(x, y);
        }

        private Func<int, int, int> comparator = (x, y) =>
        {
            if (x % 2 == 0 && y % 2 != 0)
            {
                return -1;
            }

            if (x % 2 != 0 && y % 2 == 0)
            {
                return 1;
            }

            return x.CompareTo(y);
        };
    }
}
