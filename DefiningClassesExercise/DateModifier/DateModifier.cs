using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DateModifier
{
    public class DateModifier
    {
        
        public int CalculateDifference(string input1, string input2)
        {
            DateTime date1 = DateTime.Parse(input1);
            DateTime date2 = DateTime.Parse(input2);

            return Math.Abs((date2 - date1).Days);
        }
    }
}
