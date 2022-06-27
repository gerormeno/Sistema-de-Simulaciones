using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP4.Clases;
using TP4.Forms;

namespace TP4.CalculosPantallaRk_Euler
{
   public class RkEuler
    {
        public double a = 0;
        public double b = 10;
        public double c = 5;
        public double x0 = 0;
        public double dx1_0 = 0;
        public double h = 0.05;

        public double pico = 0;

        public SimulacionEuler anteriorEuler;
        public SimulacionEuler actualEuler;

        public SimulacionRK anteriorRK;
        public SimulacionRK actualRK;

        public Random RND = new Random();

        bool primerPico = false;
        bool segundoPico = false;

        //Pantalla
        public Euler pantallaEulerRK;
        public PantallaRK pantallaRK;


        public void setearParametros(double a, double b, double c, double x0, double dx1_0, double h)
        {
            this.a = a;
            this.b = b;
            this.c = c;
            this.x0 = x0;
            this.dx1_0 = dx1_0;
            this.h = h;
         
        }




            public RkEuler(Euler pantallaEulerRK, double a) 
        {
            this.a = a;
            anteriorEuler = new SimulacionEuler();
            actualEuler = new SimulacionEuler();



            primerPico = false;
            segundoPico = false;

            this.pantallaEulerRK = pantallaEulerRK;

        }

        public RkEuler(PantallaRK pantallaRK, double a )
        {
            this.a = a;
           

            anteriorRK = new SimulacionRK();
            actualRK = new SimulacionRK();

            primerPico = false;
            segundoPico = false;

            this.pantallaRK = pantallaRK;
        }

        public void condicionesInicialesEuler()
        {
            anteriorEuler.t = 0;
            anteriorEuler.x1 = x0;
            anteriorEuler.x2 = dx1_0;
            anteriorEuler.dx2 = -a * anteriorEuler.x2 - b * anteriorEuler.x1 + Math.Exp(-c * anteriorEuler.t);

            pantallaEulerRK.cargarFila(anteriorEuler);
        }

        public void condicionesInicialesRK()
        {
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

            pantallaRK.cargarFila(anteriorRK);
        }

        public void calcularEuler()
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


                    int i = 0;
                    while (i < 50)
                    {
                        actualEuler.t = anteriorEuler.t + h;
                        actualEuler.x1 = anteriorEuler.x1 + h * anteriorEuler.x2;
                        actualEuler.x2 = anteriorEuler.x2 + h * anteriorEuler.dx2;
                        actualEuler.dx2 = calcularDx2();

                        anteriorEuler = (SimulacionEuler)actualEuler.clone();

                        pantallaEulerRK.cargarFila(actualEuler);

                        i++;
                    }
                }

                if (!primerPico && (anteriorEuler.x2 >= 0 && actualEuler.x2 < 0))
                {
                    primerPico = true;
                    Console.WriteLine("Primer Pico: " + actualEuler.t);
                }

                pantallaEulerRK.cargarFila(actualEuler);

                anteriorEuler = (SimulacionEuler)actualEuler.clone();

            }

            Console.WriteLine("xd");
            pantallaEulerRK.mostrarSegundoPico(Math.Round( pico,2));
        }

        public void calcularRK()
        {
            condicionesInicialesRK();


            Console.WriteLine(a);

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

                    int i = 0;
                    while (i < 50)
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

                        pantallaRK.cargarFila(actualRK);

                        anteriorRK = (SimulacionRK)actualRK.clone();

                        i++;
                    }
                }

                if (!primerPico && (anteriorRK.x2 >= 0 && actualRK.x2 < 0))
                {
                    primerPico = true;
                    Console.WriteLine("Primer Pico: " + actualRK.t);

                }

                pantallaRK.cargarFila(actualRK);


               
                anteriorRK = (SimulacionRK)actualRK.clone();

            }
            pantallaRK.cargarSegundoPico(Math.Round( pico,2));
        }

        public double calcularDx2()
        {
            return (-a * actualEuler.x2 - b * actualEuler.x1 + Math.Exp(-c * actualEuler.t));
        }

    }
}
