﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RawData
{
    public class Tire
    {
        public Tire(int age, double pressure)
        {
            Age = age;
            Pressure = pressure;
        }
        public int Age { get; set; }
        public double Pressure { get; set; }
    }
}
