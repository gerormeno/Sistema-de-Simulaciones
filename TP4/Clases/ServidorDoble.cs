using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP4.Clases
{
    public class ServidorDoble
    {
        public bool Libre { get; set; }
        public Ensamble procesando;
        public List<Ensamble> colaA2 { get; set; }
        public List<Ensamble> colaA4 { get; set; }

        public ServidorDoble()
        {
            Libre = true;
            colaA2 = new List<Ensamble>();
            colaA4 = new List<Ensamble>();
        }

    }
}
