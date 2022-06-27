using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP4.Clases
{
    public class ServidorSimple
    {
        public bool Libre { get; set; }
        public Ensamble procesando;
        public List<Ensamble> cola { get; set; }
        public double cantOcupacion { get; set; }
        public ServidorSimple()
        {
            cola = new List<Ensamble>();
            Libre = true;
        }
    } 
}
