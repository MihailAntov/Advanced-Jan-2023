using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericScale
{
    public class EqualityScale<T>
    {
        public EqualityScale(T left, T right)
        {
            Left = left;
            Right = right;
        }

        T Left { get; set; }
        T Right { get; set; }
        public bool AreEqual()
        {
            return Left.Equals(Right);
        }

    }
}
