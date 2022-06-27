using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP4.Clases
{
    public class Ensamble
    {

        public static int cantEnsambles = 0;
       
        public bool A1 { get; set; }
        public bool A2 { get; set; }
        public bool A3 { get; set; }
        public bool A4 { get; set; }
        public bool A5 { get; set; }
        public double tiempoLlegada { get; set; }
        public double tiempoSalida { get; set; }
        public int id { get; set; }

        public bool enCola { get; set; }

        //metrica de tiempos promedio de permanencia en cola
        public double tiempoA1 { get; set; }
        public double tiempoA2 { get; set; }
        public double tiempoA3 { get; set; }
        public double tiempoA4 { get; set; }
        public double tiempoA5A2 { get; set; }
        public double tiempoA5A4 { get; set; }
        public double tiempoA5 { get; set; }

        public bool colaA1 { get; set; }
        public bool colaA2 { get; set; }
        public bool colaA3 { get; set; }
        public bool colaA4 { get; set; }
        public bool colaA5A2 { get; set; }
        public bool colaA5A4 { get; set; }



        public Ensamble()
        {
            incrementarId();
            enCola = false;
            colaA1 = false;
            colaA2 = false;
            colaA3 = false;
            colaA4 = false;
            colaA5A2 = false;
            colaA5A4 = false;
        }

        public void incrementarId()
        {
            cantEnsambles += 1;
            id = cantEnsambles;
        }

        public void setearHoraSalida(double salida)
        {
            this.tiempoSalida = salida;

        }

        public double tiempoEnsamble()
        {
            return tiempoSalida-tiempoLlegada;
        }
    }
}
