﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP4.Clases
{
  public class SimulacionRK
    {

        public double t { get; set; }
        public double x1 { get; set; }
        public double k1 { get; set; }
        public double k2 { get; set; }
        public double k3 { get; set; }
        public double k4 { get; set; }
        public double x2 { get; set; }
        public double l1 { get; set; }
        public double l2 { get; set; }
        public double l3 { get; set; }
        public double l4 { get; set; }
        public double dx2 { get; set; }

        public object clone()
        {
            return this.MemberwiseClone();
        }
    }
}
