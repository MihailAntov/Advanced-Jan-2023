using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Froggy
{
    public class Lake : IEnumerable<int>
    {
        List<int> evenNumbers;
        List<int> oddNumbers;

        public Lake(params int[] stones)
        {
            evenNumbers = new List<int>();
            oddNumbers = new List<int>();
            for(int i = 0; i < stones.Length; i++)
            {
                if(i%2 == 0)
                {
                    evenNumbers.Add(stones[i]);
                }
                else
                {
                    oddNumbers.Add(stones[i]);
                }
            }
        }

        public IEnumerator<int> GetEnumerator()
        {
            for (int i = 0; i < evenNumbers.Count; i++)
            {
                yield return evenNumbers[i];
            }

            for (int i = oddNumbers.Count-1; i>= 0; i--)
            {
                yield return oddNumbers[i];
            }


        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
