using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP4.Clases;

namespace TP4.Calculos
{
    public class CalculosEuler
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

        public SimulacionEuler anteriorEuler;
        public SimulacionEuler actualEuler;

        public void setA(double a)
        {
            this.a = a;
        }

        public void setearParametros( double b, double c, double x0,double dx1_0, double h)
        {
         
            this.b = b;
            this.c = c;
            this.x0 = 0;
            this.dx1_0 = dx1_0;
            this.h = h;
            seteado = true;


        }





        bool primerPico = false;
        bool segundoPico = false;

        //Pantalla
  

        public void condicionesInicialesEuler()
        {

            anteriorEuler = new SimulacionEuler();
            actualEuler = new SimulacionEuler();

            anteriorEuler.t = 0;
            anteriorEuler.x1 = x0;
            anteriorEuler.x2 = dx1_0;
            anteriorEuler.dx2 = -a * anteriorEuler.x2 - b * anteriorEuler.x1 + Math.Exp(-c * anteriorEuler.t);

        }

        public double calcularEuler()
        {
            condicionesInicialesEuler();

            primerPico = false;
            segundoPico = false;

     
            while (!segundoPico)
            {

                actualEuler.t = anteriorEuler.t + h;
                actualEuler.x1 = anteriorEuler.x1 + h * anteriorEuler.x2;
                actualEuler.x2 = anteriorEuler.x2 + h * anteriorEuler.dx2;
                actualEuler.dx2 = calcularDx2();


                if (primerPico && (anteriorEuler.x2 >= 0 && actualEuler.x2 < 0))
                {
                    segundoPico = true;
                    Console.WriteLine("Segundo Pico: " + actualEuler.t);
                    pico = actualEuler.t;
               
                }

                if (!primerPico && (anteriorEuler.x2 >= 0 && actualEuler.x2 < 0))
                {
                    primerPico = true;
                    Console.WriteLine("Primer Pico: " + actualEuler.t);
                }

             

                anteriorEuler = (SimulacionEuler)actualEuler.clone();

            }

            Console.WriteLine("xd");
            return pico;

        }

       

        public double calcularDx2()
        {
            return (-a * actualEuler.x2 - b * actualEuler.x1 + Math.Exp(-c * actualEuler.t));
        }

    }
}
