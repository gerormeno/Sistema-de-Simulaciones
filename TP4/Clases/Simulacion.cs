using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP4.Clases
{
    public class Simulacion
    {
        public int numero { get; set; }
        public double minutos { get; set; }
        public string proxEvento { get; set; }
        public double tiempoEntreLlegadas { get; set; }
        public double proxLlegada { get; set; }
        public double finA1 { get; set; }
        public string estadoA1 { get; set; }
        public int colaA1 { get; set; }
        public double finA2 { get; set; }
        public string estadoA2 { get; set; }
        public int colaA2 { get; set; }
        public double finA3 { get; set; }
        public string estadoA3 { get; set; }
        public int colaA3 { get; set; }
        public double finA4 { get; set; }
        public string estadoA4 { get; set; }
        public int colaA4 { get; set; }
        public double finA5 { get; set; }
        public string estadoA5 { get; set; }
        public int colaA5A2 { get; set; }
        public double colaA5A4 { get; set; }
        public int colaEnsambleA3 { get; set; }
        public int colaEnsambleA5 { get; set; }
        public int EnsamblesTerminados { get; set; }
        public int cantEnsambles { get; set; }



        // cola ensamble
        public double finEnsamble { get; set; }
        public double a { get; set; }

        //porcentaje de trabajo
        public double porcTrabajoA1 { get; set; }
        public double porcTrabajoA2 { get; set; }
        public double porcTrabajoA3 { get; set; }
        public double porcTrabajoA4 { get; set; }
        public double porcTrabajoA5 { get; set; }


        //tiempo promedio ensamble
        public double tiempoPromEnsamble { get; set; }


        //tiempo promedio permanencia en cola 
        public double tiempoPromPermanenciaA1 { get; set; }
        public double tiempoPromPermanenciaA2 { get; set; }
        public double tiempoPromPermanenciaA3 { get; set; }
        public double tiempoPromPermanenciaA4 { get; set; }
        public double tiempoPromPermanenciaA5A4 { get; set; }
        public double tiempoPromPermanenciaA5A2 { get; set; }




        //Terminado
 

        public double CantidadPromedioEnsamblesEnSistema { get; set; }


        //proporcion bloqueo encastre A3 o A5

        public double ProporcionBloqueoEnsamble { get; set; }



        public Simulacion()
        {
            estadoA1 = "Libre";
            estadoA2 = "Libre";
            estadoA3 = "Libre";
            estadoA4 = "Libre";
            estadoA5 = "Libre";
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
