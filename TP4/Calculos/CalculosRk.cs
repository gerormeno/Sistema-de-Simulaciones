using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP4.Clases;

namespace TP4.Calculos
{
   public  class CalculosRk
    {

        public double a = 0;
        public double b = 10;
        public double c = 5;
        public double x0 = 0;
        public double dx1_0 = 0;
        public double h = 0.05;
        public double li;
        public double ls;

        public double pico = 0;


        public bool seteado = false;
        public SimulacionRK anteriorRK;
        public SimulacionRK actualRK;

        public Random RND = new Random();

        bool primerPico = false;
        bool segundoPico = false;

        public void setearParametros( double b, double c, double x0, double dx1_0, double h)
        {
           
            this.b = b;
            this.c = c;
            this.x0 = 0;
            this.dx1_0 = dx1_0;
            this.h = h;

            seteado = true;

        }


        public void setA(double a)
        {
            this.a = a;
        }

        public void condicionesInicialesRK()
        {
            anteriorRK = new SimulacionRK();
            actualRK = new SimulacionRK();

            primerPico = false;
            segundoPico = false;

            anteriorRK.t = 0;
            anteriorRK.x1 = x0;
            anteriorRK.x2 = dx1_0;
            anteriorRK.k1 = h * anteriorRK.x2;
            anteriorRK.l1 = h * (-a * anteriorRK.x2 - b * anteriorRK.x1 + Math.Exp(-c * anteriorRK.t));
            anteriorRK.k2 = h * (anteriorRK.x2 + 0.5 * anteriorRK.l1);
            anteriorRK.l2 = h * (-a * (anteriorRK.x2 + 0.5 * anteriorRK.k1) - b * (anteriorRK.x1 + 0.5 * anteriorRK.k1) + Math.Exp(-c * (anteriorRK.t + 0.5 * h)));
            anteriorRK.k3 = h * (anteriorRK.x2 + 0.5 * anteriorRK.l2);
            anteriorRK.l3 = h * (-a * (anteriorRK.x2 + 0.5 * anteriorRK.k2) - b * (anteriorRK.x1 + 0.5 * anteriorRK.k2) + Math.Exp(-c * (anteriorRK.t + 0.5 * h)));
            anteriorRK.k4 = h * (anteriorRK.x2 + anteriorRK.l3);
            anteriorRK.l4 = h * (-a * (anteriorRK.x2 + anteriorRK.k3) - b * (anteriorRK.x1 + anteriorRK.k3) + Math.Exp(-c * (anteriorRK.t + h)));
            anteriorRK.dx2 = -a * anteriorRK.x2 - b * anteriorRK.x1 + Math.Exp(-c * anteriorRK.t);

            //pantallaRK.cargarFila(anteriorRK);
        }

        

        public double calcularRK()
        {
            condicionesInicialesRK();


     

            primerPico = false;
            segundoPico = false;

            while (!segundoPico)
            {

                actualRK.t = anteriorRK.t + h;
                actualRK.x1 = anteriorRK.x1 + (anteriorRK.k1 + 2 * anteriorRK.k2 + 2 * anteriorRK.k3 + anteriorRK.k4) / 6;
                actualRK.x2 = anteriorRK.x2 + (anteriorRK.l1 + 2 * anteriorRK.l2 + 2 * anteriorRK.l3 + anteriorRK.l4) / 6;
                actualRK.k1 = h * actualRK.x2;
                actualRK.l1 = h * (-a * actualRK.x2 - b * actualRK.x1 + Math.Exp(-c * actualRK.t));
                actualRK.k2 = h * (actualRK.x2 + 0.5 * actualRK.l1);
                actualRK.l2 = h * (-a * (actualRK.x2 + 0.5 * actualRK.k1) - b * (actualRK.x1 + 0.5 * actualRK.k1) + Math.Exp(-c * (actualRK.t + 0.5 * h)));
                actualRK.k3 = h * (actualRK.x2 + 0.5 * actualRK.l2);
                actualRK.l3 = h * (-a * (actualRK.x2 + 0.5 * actualRK.k2) - b * (actualRK.x1 + 0.5 * actualRK.k2) + Math.Exp(-c * (actualRK.t + 0.5 * h)));
                actualRK.k4 = h * (actualRK.x2 + actualRK.l3);
                actualRK.l4 = h * (-a * (actualRK.x2 + actualRK.k3) - b * (actualRK.x1 + actualRK.k3) + Math.Exp(-c * (actualRK.t + h)));
                actualRK.dx2 = -a * actualRK.x2 - b * actualRK.x1 + Math.Exp(-c * actualRK.t);

                if (primerPico && (anteriorRK.x2 >= 0 && actualRK.x2 < 0))
                {
                    segundoPico = true;
                    Console.WriteLine("Segundo Pico: " + actualRK.t);
                    pico = actualRK.t;

               
                }

                if (!primerPico && (anteriorRK.x2 >= 0 && actualRK.x2 < 0))
                {
                    primerPico = true;
                    Console.WriteLine("Primer Pico: " + actualRK.t);

                }

                //pantallaRK.cargarFila(actualRK);

                anteriorRK = (SimulacionRK)actualRK.clone();

            }
            return pico;
        }

 
    }
}
