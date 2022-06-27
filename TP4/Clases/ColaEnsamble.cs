using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP4.Clases
{
    public class ColaEnsamble
    {
        public List<Ensamble> colaA3;
        public List<Ensamble> colaA5;
        public int terminados;
        public ColaEnsamble()
        {
            colaA3 = new List<Ensamble>();
            colaA5 = new List<Ensamble>();
        }

    }
}
