using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP4.Clases
{
   public  class SimulacionEuler
    {

        public double t { get; set; }
        public double x1 { get; set; }
        public double x2 { get; set; }
        public double dx2 { get; set; }


        public object clone()
        {
            return this.MemberwiseClone();
        }
    }
}
