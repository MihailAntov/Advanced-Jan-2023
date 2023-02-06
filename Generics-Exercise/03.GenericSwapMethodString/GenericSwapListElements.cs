using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.GenericSwapMethodString
{
    public class GenericSwapListElements
    {
        public static List<T> Swap<T>(List<T> list, int index1, int index2)
        {
            T buffer = list[index1];
            list[index1] = list[index2];
            list[index2] = buffer;
            return list;
        }
    }
}
