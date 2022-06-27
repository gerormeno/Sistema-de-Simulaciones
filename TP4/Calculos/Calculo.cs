using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test;
using TP4.Clases;

namespace TP4.Calculos
{
    public class Calculo
    {
        public Simulacion anterior;
        public Simulacion actual;
        public GenRandom genRandom;
        

        //Servidores
        public ServidorSimple servidorA1;
        public ServidorSimple servidorA2;
        public ServidorSimple servidorA3;
        public ServidorSimple servidorA4;
        public ServidorSimple servidorA5A2;
        public ServidorSimple servidorA5A4;
        public ServidorSimple colaEnsambleA3;
        public ServidorSimple colaEnsambleA5;
        public ServidorSimple servidorEnsamble;


        public ColaEnsamble colaEnsamble;
        public List<Ensamble> ensamblesTerminados;


        public List<Ensamble> ensamblesSim;

        //Evento
        public string evento;

        //Bandera
        public bool primeraVuelta;
        //pantalla de inicio
        private Inicio inicio;

        //parametros de la simulacion
        public int cantidadSimulaciones;
        public int cantidadEnsambles;
        public string tipo;
        public int desde;
        public int hasta;


        public double ensamblesEnElSistema=0;


        //Algunas metricas
        public int cantidadMaxColaA1=0;
        public int cantidadMaxColaA2=0;
        public int cantidadMaxColaA3=0;
        public int cantidadMaxColaA4=0;
        public int cantidadMaxColaA5A2=0;
        public double cantidadMaxColaA5A4=0;
        public int cantidadMaxColaEnsambleA5 = 0;
        public int cantidadMaxColaEnsambleA3 = 0;


        //Parametros llegada 
        public double lambda=3;
        //parametros distribuciones
        //act1
        public double unidformeAA1 = 20;
        public double uniformeBA1 = 30;
        //act2
        public double uniformeAA2 = 30;
        public double uniformeBA2 = 50;
        //act3
        public double exponencialMA3 = 30;
        //act4
        public double uniformeAA4 = 10;
        public double uniformeBA4 = 20;
        //act 5
        public double exponencialMA5 = 5;


        // Tiempos de permanencias en cola 

        public double tiempoPermanenciaA1;
        public double tiempoPermanenciaA2;
        public double tiempoPermanenciaA3;
        public double tiempoPermanenciaA4;
        public double tiempoPermanenciaA5A2;
        public double tiempoPermanenciaA5A4;

        //tiempo de permanencias en cola cantidad de ensambles pasados por cada servidor
        public double cantidadPermanenciaA1;
        public double cantidadPermanenciaA2;
        public double cantidadPermanenciaA3;
        public double cantidadPermanenciaA4;
        public double cantidadPermanenciaA5A2;
        public double cantidadPermanenciaA5A4;



        //Cantida promedio de ensambles en el sistema
        public double cantidadEnsamblesEnElSistema;
        public double acumuladorProductos;
        public double cantidadPromedioProductos;

        //Varible proporcion bloqueos para ensable terminado

        public double acTiempoBloqueo;


        ////
        //Rouge Kutta

        public CalculosRk CalculoRk;
        public CalculosEuler CalculoEu;
        public string eleccionFinEncastre;
        public bool setParametrosFinEncastre;
        public double a;
        public double li;
        public double ls;
        //



        public Calculo(Inicio inicio , string eleccion)
        {
            actual = new Simulacion();
            anterior = (Simulacion)actual.Clone();
            genRandom = new GenRandom();

            //Inicializacion Servidores
            servidorA1 = new ServidorSimple();
            servidorA2 = new ServidorSimple();
            servidorA3 = new ServidorSimple();
            servidorA4 = new ServidorSimple();
            servidorA5A2 = new ServidorSimple();
            servidorA5A4 = new ServidorSimple();
            colaEnsambleA3 = new ServidorSimple();
            colaEnsambleA5 = new ServidorSimple();
            colaEnsamble = new ColaEnsamble();
            ensamblesSim = new List<Ensamble>();
            ensamblesTerminados = new List<Ensamble>();
            this.inicio = inicio;
            //cantidadSimulaciones = canSimulaciones;
            //this.cantidadEnsambles=cantEnsambles;

            servidorEnsamble = new ServidorSimple();

            CalculoRk = new CalculosRk();
            CalculoEu = new CalculosEuler();
            this.eleccionFinEncastre = eleccion;

        }

        public void setSimulaciones(int cantSimulaciones,double lambda,int desde,int hasta)
        {
            cantidadSimulaciones = cantSimulaciones;
            tipo = "Simulaciones";
            this.lambda = lambda;
            this.desde = desde;
            this.hasta = hasta;
        }
        public void setEnsambles(int cantEnsambles,double lambda, int desde, int hasta)
        {
            this.cantidadEnsambles = cantEnsambles;
            tipo = "Ensamble"; 
            this.lambda = lambda;
            this.desde = desde;
            this.hasta = hasta;
        }


        public void inicializacion()
        {
            resetObjetos();
            anterior.tiempoEntreLlegadas = genRandom.generarSerieExponencial((60/lambda), 1)[0];
            anterior.proxEvento = "ProxLlegada";
            anterior.proxLlegada = anterior.tiempoEntreLlegadas;
            inicio.cargarFila(anterior);

            if (tipo == "Simulaciones")
            {
                for (int i = 1; i <= cantidadSimulaciones; i++)
                {

                    reloj();
                    arrastrarRelojes();
                    eventoActual();
                    proxEvento();
                    actual.proxEvento = evento;
                    actual.numero = i;
                    calcularPromedioMetrica(i);
                    cantidadPromedioEnsamblesEnSistema();

                    porpocionTiempoBloqueoA3oA5();
                    //condicion

                    if (i>=desde && i < hasta)
                    {
                        inicio.cargarFila(actual);
                    }                   

                    calcularMaximosEnCola();
                    actual.a = 0;
                    anterior = (Simulacion)actual.Clone();
                   

                }
                calcularPromedioEnsamble();
                
                cantidadEnsamblesPromedioEnCola();
                //metrica prom de permanencia en cola
                tiempoPromedioPermanenciaEnCola();
               
            }
            else
            {
                int i = 1;
                while (actual.EnsamblesTerminados != cantidadEnsambles)
                {

                    reloj();
                    arrastrarRelojes();
                    eventoActual();
                    proxEvento();
                    actual.proxEvento = evento;
                    actual.numero = i;
                    if (i >= desde && i <= hasta)
                    {
                        inicio.cargarFila(actual);
                    }
                    calcularMaximosEnCola();
                    calcularPromedioMetrica(i);
                    actual.a = 0;
                    anterior = (Simulacion)actual.Clone();
                    cantidadPromedioEnsamblesEnSistema();



                    porpocionTiempoBloqueoA3oA5();



                    i++;
                }
            }
            mostrarCantMaximaEnCola();
            calcularPromedioEnsamble();
            tiempoPromedioPermanenciaEnCola();
            cantidadEnsamblesPromedioEnCola();
            cantidadDeEnsamblesRealizadosRelacionSolicitados();
            mostrarCantidadProductosEnElSitema();
            inicio.cargarTiempoPromedioEnCola(actual);
            inicio.cargarFila(actual);


        }
        public void calcularMaximosEnCola()
        {

            if (actual.colaA1>cantidadMaxColaA1 )
            {
                cantidadMaxColaA1 = actual.colaA1;
            }
            if (actual.colaA2 > cantidadMaxColaA2)
            {
                cantidadMaxColaA2 = actual.colaA2;
            }
            if (actual.colaA3 > cantidadMaxColaA3)
            {
                cantidadMaxColaA3 = actual.colaA3;
            }
            if (actual.colaA4 > cantidadMaxColaA4)
            {
                cantidadMaxColaA4 = actual.colaA4;
            }
           
            if (actual.colaA5A2 > cantidadMaxColaA5A2)
            {
                cantidadMaxColaA5A2 = actual.colaA5A2;
            }
            if (actual.colaA5A4> cantidadMaxColaA5A4)
            {
                cantidadMaxColaA5A4 = actual.colaA5A4;
            }

            if (actual.colaEnsambleA3 >cantidadMaxColaEnsambleA3)
            {
                cantidadMaxColaEnsambleA3 = actual.colaEnsambleA3;
            }


            if (actual.colaEnsambleA5 > cantidadMaxColaEnsambleA5)
            {
                cantidadMaxColaEnsambleA5 = actual.colaEnsambleA5;
            }



        }
       public void mostrarCantMaximaEnCola()
        {


            inicio.mostarCantMaximaEnCola(cantidadMaxColaA1, cantidadMaxColaA2, cantidadMaxColaA3, cantidadMaxColaA4, cantidadMaxColaA5A2, cantidadMaxColaA5A4, cantidadMaxColaEnsambleA3, cantidadMaxColaEnsambleA5);

        }




        public void resetObjetos(){

            actual = new Simulacion();
            anterior = (Simulacion)actual.Clone();
            genRandom = new GenRandom();

            //Inicializacion Servidores
            servidorA1 = new ServidorSimple();
            servidorA2 = new ServidorSimple();
            servidorA3 = new ServidorSimple();
            servidorA4 = new ServidorSimple();
            servidorA5A2 = new ServidorSimple();
            servidorA5A4 = new ServidorSimple();
            colaEnsamble = new ColaEnsamble();
            ensamblesSim = new List<Ensamble>();
            ensamblesTerminados = new List<Ensamble>();


            colaEnsambleA3 = new ServidorSimple();
            colaEnsambleA5 = new ServidorSimple();


        }

        public void reloj()
        {
            double[] minArr = new double[] { anterior.proxLlegada, anterior.finA1, anterior.finA2, anterior.finA3, anterior.finA4, anterior.finA5 ,anterior.finEnsamble};
            double min = minArr[0];

            for (int i = 1; i < minArr.Length; i++)
            {

                if (min > minArr[i] && minArr[i] > 0)
                {
                    min = minArr[i];
                }
            }
            actual.minutos = min;
        }

       public void eventoActual()
        {

            if (actual.minutos == anterior.proxLlegada)
            {
                evento = "ProxLlegada";
                actual.proxLlegada = 0;

            }
            if (actual.minutos == anterior.finA1)
            {
                evento = "FinA1";
                actual.finA1 = 0;
            }
            if (actual.minutos == anterior.finA2)
            {
                evento = "FinA2";
                actual.finA2 = 0;
            }
            if (actual.minutos == anterior.finA3)
            {
                evento = "FinA3";
                actual.finA3 = 0;
            }
            if (actual.minutos == anterior.finA4)
            {
                evento = "FinA4";
                actual.finA4 = 0;
            }
            if (actual.minutos == anterior.finA5)
            {
                evento = "FinA5";
                actual.finA5 = 0;
            }



            //ensamble
            if (actual.minutos == anterior.finEnsamble)
            {
                evento = "Ensamble";
                actual.finEnsamble = 0;
            }

        }


        //Agregado desde el tp anterior nuestro

      public void  arrastrarRelojes()
        {
            actual.proxLlegada = anterior.proxLlegada;
            
            actual.finA1 = anterior.finA1;
            actual.finA2 = anterior.finA2;
            actual.finA3 = anterior.finA3;
            actual.finA4 = anterior.finA4;
            actual.finA5 = anterior.finA5;
            actual.finEnsamble = anterior.finEnsamble;
        }


        public void proxEvento()
        {
            switch (evento)
            {
                case "ProxLlegada":
                    ensamblesEnElSistema += 1;      
                    ProxLlegada();
                    cantidadEnsamblesEnElSistema += 1;
                    break;

                case "FinA1":
                    cantidadPermanenciaA1 += 1;
                    finA1();
                    
                    break;

                case "FinA2":
                    cantidadPermanenciaA2 += 1;
                    finA2();
                    break;

                case "FinA3":
                    cantidadPermanenciaA3 += 1;
                    finA3();
                    break;

                case "FinA4":
                    cantidadPermanenciaA4 += 1;
                    finA4();
                    break;

                case "FinA5":
                    cantidadPermanenciaA5A2 += 1;
                    cantidadPermanenciaA5A4 += 1;
                    finA5();
                    break;


                case "Ensamble":
                    finEnsamble();
                    //cantidadPermanenciaA5A2 += 1;
                    //cantidadPermanenciaA5A4 += 1;
                    //ensamble();
                    break;
            }


        }



        public void ProxLlegada()
        {
            Ensamble ensamble = new Ensamble();
            ensamble.tiempoLlegada = actual.minutos;
            actual.cantEnsambles += 1;
            ensamblesSim.Add(ensamble);
            actual.tiempoEntreLlegadas = genRandom.generarSerieExponencial((60 / lambda), 1)[0];
            actual.proxLlegada = actual.minutos + actual.tiempoEntreLlegadas;

          

            entradaA1(ensamble);
            entradaA2(ensamble);
            entradaA3(ensamble);

        

        }

        public void entradaA1(Ensamble ensamble)
        {
            //metrica tiempo de promedio de permanencia en cada cola
            

            if (servidorA1.Libre)
            {

                actual.finA1 = actual.minutos + genRandom.generarSerieUniforme(unidformeAA1, uniformeBA1, 1)[0];
                servidorA1.procesando = ensamble;
                servidorA1.Libre = false;
                actual.estadoA1 = "Ocupado";
                 

            }
            else
            {
                ensamble.tiempoA1 = actual.minutos;
                ensamble.colaA1 = true;


                servidorA1.cola.Add(ensamble);
                //metrica cola
                ensamble.enCola = true;
                actual.colaA1 = servidorA1.cola.Count;

            }


        }
        public void entradaA2(Ensamble ensamble)
        {

            

            if (servidorA2.Libre)
            {

                actual.finA2 = actual.minutos + genRandom.generarSerieUniforme(uniformeAA2, uniformeBA2, 1)[0];
                servidorA2.procesando = ensamble;
                servidorA2.Libre = false;
                actual.estadoA2 = "Ocupado";


            }
            else
            {
                ensamble.tiempoA2 = actual.minutos;
                ensamble.colaA2 = true;
                
                servidorA2.cola.Add(ensamble);
                
                //metrica cola
                ensamble.enCola = true;
                actual.colaA2 = servidorA2.cola.Count;

            }


        }
        public void entradaA3(Ensamble ensamble)
        {
          
            if (servidorA3.Libre)
            {

                actual.finA3 = actual.minutos + genRandom.generarSerieExponencial( exponencialMA3, 1)[0];
                servidorA3.procesando = ensamble;
                servidorA3.Libre = false;
                actual.estadoA3 = "Ocupado";


            }
            else
            {
                ensamble.tiempoA3 = actual.minutos;
                ensamble.colaA3 = true;
               
                servidorA3.cola.Add(ensamble);
                //metrica cola
                ensamble.enCola = true;
                actual.colaA3 = servidorA3.cola.Count;

            }
       

        }
        public void finA1()
        {
        

            Ensamble ensamble = servidorA1.procesando;
            if (servidorA1.cola.Count > 0)
            {
                if (servidorA1.cola[0].tiempoA1 != 0)
                {
                    tiempoPermanenciaA1 += actual.minutos - servidorA1.cola[0].tiempoA1;
                }

                servidorA1.procesando = servidorA1.cola[0];
                servidorA1.cola.RemoveAt(0);
                actual.colaA1 = servidorA1.cola.Count;
                actual.finA1 = actual.minutos + genRandom.generarSerieUniforme(unidformeAA1, uniformeBA2, 1)[0];

            }
            else
            {
                servidorA1.Libre = true;
                actual.estadoA1 = "Libre";

            }

        

            if (servidorA4.Libre)
            {
                servidorA4.procesando = ensamble;
               
                actual.finA4 = actual.minutos + genRandom.generarSerieUniforme(uniformeAA4, uniformeBA4, 1)[0];
               
                servidorA4.Libre = false;
                actual.estadoA4 = "Ocupado";
            }
            else
            {
                servidorA4.Libre = true;
                ensamble.tiempoA4 = actual.minutos;
                ensamble.colaA4 = true;
                //metrica cola
                ensamble.enCola = true;
                actual.colaA4 = servidorA4.cola.Count;
                servidorA4.cola.Add(ensamble);
            }
           

        }
        public void finA2()
        {
         

            Ensamble ensamble = servidorA2.procesando;

            if (servidorA2.cola.Count > 0)
            {
                if (servidorA2.cola[0].tiempoA2 != 0)
                {
                    tiempoPermanenciaA2 += actual.minutos - servidorA2.cola[0].tiempoA2;
                }
                servidorA2.procesando = servidorA2.cola[0];
                servidorA2.cola.RemoveAt(0);
                actual.colaA2 = servidorA2.cola.Count;
                actual.finA2 = actual.minutos + genRandom.generarSerieUniforme(uniformeAA2, uniformeBA2, 1)[0];

            }
            else
            {
                servidorA2.Libre = true;
                actual.estadoA2 = "Libre";

            }

            //cambios poner la suma de la cola a52 afuera

            // aca esta el problema ya que puede estar en cola pero ya esta agregado

            if (servidorA5A4.cola.Count ==0)
            {
                ensamble.enCola = true;
                ensamble.tiempoA5A2 = actual.minutos;

                servidorA5A2.cola.Add(ensamble);
            }
            else
            {
              
                servidorA5A2.cola.Add(ensamble);
               
            }

            if (servidorA5A4.cola.Count > 0)
            {
                tiempoPermanenciaA5A4 += actual.minutos-servidorA5A4.cola[0].tiempoA5A4;
            }
            
         
            //metrica promedio permanencia
            //REVISAR LA LOGICA PORQUE MEPA QUE ESTA MAL
            
            if ((servidorA5A2.Libre && servidorA5A4.Libre) &&( (servidorA5A2.cola.Count>0) && (servidorA5A4.cola.Count>0)))
            {
              
                servidorA5A4.procesando = ensamble;
                servidorA5A2.procesando = ensamble;

                servidorA5A2.cola.RemoveAt(0);
                servidorA5A4.cola.RemoveAt(0);



                actual.finA5 = actual.minutos + genRandom.generarSerieExponencial(exponencialMA5, 1)[0];

                servidorA5A2.Libre = false;
                servidorA5A4.Libre = false;
                actual.estadoA5 = "Ocupado";              
            }

            //agregado metrica colas
            else
            {
                ensamble.enCola = true;
                ensamble.tiempoA5A2 = actual.minutos;
                ensamble.colaA5A2 = true;
            }


            cantidadPermanenciaA5A2 += 1;
            actual.colaA5A4 = servidorA5A4.cola.Count;
            actual.colaA5A2 = servidorA5A2.cola.Count;
           
        }

        public void finA3()
        {
          


            Ensamble ensamble = servidorA3.procesando;
            if (servidorA3.cola.Count > 0)
            {
                if (servidorA3.cola[0].tiempoA3 != 0)
                {
                    tiempoPermanenciaA3 += actual.minutos - servidorA3.cola[0].tiempoA3;
                }
                servidorA3.procesando = servidorA3.cola[0];
                servidorA3.cola.RemoveAt(0);
                actual.colaA3 = servidorA3.cola.Count;
                actual.finA3 = actual.minutos + genRandom.generarSerieExponencial( exponencialMA3, 1)[0];

            }
            else
            {
                servidorA3.Libre = true;
                actual.estadoA3 = "Libre";

            }


            //Aca o lo ponemos en la cola de ensamble o lo mandamos a terminados
            colaEnsambleA3.cola.Add(ensamble);
            ensamble.tiempoA3 = actual.minutos;

            if((colaEnsambleA3.cola.Count > 0 && colaEnsambleA5.cola.Count > 0) && anterior.finEnsamble==0)
            {
                if (setParametrosFinEncastre == false)
                {
                    actual.a = genRandom.generarSerieUniforme(0.5, 2, 1)[0];
                }
                else
                {
                    actual.a = genRandom.generarSerieUniforme(li,ls,1)[0];
                }



                if (eleccionFinEncastre == "Euler")
                {
                    CalculoEu.setA(actual.a);
                    actual.finEnsamble = actual.minutos + CalculoEu.calcularEuler();
                }
                else
                {
                    CalculoRk.setA(actual.a);
                    actual.finEnsamble = actual.minutos + CalculoRk.calcularRK();
                }


                
             
                servidorEnsamble.procesando = colaEnsambleA3.cola[0];
                colaEnsambleA3.cola.RemoveAt(0);
                colaEnsambleA5.cola.RemoveAt(0);
                servidorEnsamble.Libre = false;

                //actual.EnsamblesTerminados += 1;

            }
            //metrica cola
            else
            {
                ensamble.enCola = true;
                servidorEnsamble.Libre = true;
            }

            actual.colaA3 = servidorA3.cola.Count;
            actual.colaEnsambleA3 = colaEnsambleA3.cola.Count;
            actual.colaEnsambleA5 = colaEnsambleA5.cola.Count;



        }

        public void finA4()
        {
         

            Ensamble ensamble = servidorA4.procesando;
            if (servidorA4.cola.Count > 0)
            {
                if (servidorA4.cola[0].tiempoA4 != 0)
                {
                    tiempoPermanenciaA4 += actual.minutos - servidorA4.cola[0].tiempoA4;
                }
                servidorA4.procesando = servidorA4.cola[0];
                servidorA4.cola.RemoveAt(0);
                actual.colaA4 = servidorA4.cola.Count;
                actual.finA4 = actual.minutos + genRandom.generarSerieUniforme(uniformeAA4,uniformeBA4,1)[0];

            }
            else
            {
                servidorA4.Libre = true;
                actual.estadoA4 = "Libre";

            }



            //fijarse bien esto weon
            if (servidorA5A2.cola.Count > 0)
            {
                servidorA5A4.cola.Add(ensamble);
            }
            else
            {
                ensamble.enCola = true;
                ensamble.tiempoA5A4 = actual.minutos;
                servidorA5A4.cola.Add(ensamble);

               
            }

            if (servidorA5A2.cola.Count > 0)
            {
                tiempoPermanenciaA5A2 += actual.minutos - servidorA5A2.cola[0].tiempoA5A2;
            }

            if ((servidorA5A2.Libre && servidorA5A4.Libre ) && ((servidorA5A2.cola.Count > 0) && (servidorA5A4.cola.Count > 0)))
            {
                //lo pasamos a procesado
                servidorA5A4.procesando = ensamble;
                servidorA5A2.procesando = ensamble;



                //removemos los ensambles de la cola
                servidorA5A2.cola.RemoveAt(0);
                servidorA5A4.cola.RemoveAt(0);

                actual.finA5 = actual.minutos + genRandom.generarSerieExponencial(exponencialMA5, 1)[0];

                
                servidorA5A2.Libre = false;
                servidorA5A4.Libre = false;
                actual.estadoA5 = "Ocupado";


            }
            else
            {
                //metrica cola
                ensamble.enCola = true;
                ensamble.tiempoA5A4 = actual.minutos;
                ensamble.colaA5A4 = true;
            }

            //actualizamos el servidor doble de la actividad 5
            actual.colaA5A4 = servidorA5A4.cola.Count;
            actual.colaA5A2 = servidorA5A2.cola.Count;
            cantidadPermanenciaA5A4 += 1;

        }

        public void finA5()
        {      

            Ensamble ensamble = servidorA5A2.procesando;





            if (servidorA5A2.cola.Count > 0 && servidorA5A4.cola.Count > 0)
            {


                tiempoPermanenciaA5A2 += actual.minutos - servidorA5A2.cola[0].tiempoA5A2;
                tiempoPermanenciaA5A4 += actual.minutos - servidorA5A4.cola[0].tiempoA5A4;


                servidorA5A2.procesando = servidorA5A2.cola[0];
                servidorA5A2.cola.RemoveAt(0);
                actual.colaA5A2 = servidorA5A2.cola.Count;


                servidorA5A4.procesando = servidorA5A4.cola[0];               
                servidorA5A4.cola.RemoveAt(0);
                actual.colaA5A4 = servidorA5A4.cola.Count;


                actual.finA5 = actual.minutos + genRandom.generarSerieExponencial(exponencialMA5, 1)[0];

                Console.WriteLine("TERMINO");
                //servidorA5A2.procesando.tiempoSalida = actual.minutos;
                //ensamblesTerminados.Add(servidorA5A2.procesando);

                //metricas prom de permanencia en cola


            }
            else
            {
                servidorA5A2.Libre = true;

                servidorA5A4.Libre = true;
                //metrica cola
                ensamble.enCola = true;

                actual.estadoA5 = "Libre";

            }


            colaEnsambleA5.cola.Add(ensamble);


            if ((colaEnsambleA3.cola.Count > 0 && colaEnsambleA5.cola.Count > 0 ) && anterior.finEnsamble==0)
            {
                if (setParametrosFinEncastre == false)
                {
                    actual.a = genRandom.generarSerieUniforme(0.5, 2, 1)[0];
                }
                else
                {
                    actual.a = genRandom.generarSerieUniforme(li, ls, 1)[0];
                }

                if (eleccionFinEncastre == "Euler")
                {
                    CalculoEu.setA(actual.a);
                    actual.finEnsamble = actual.minutos + CalculoEu.calcularEuler();
                }
                else
                {
                    CalculoRk.setA(actual.a);
                    actual.finEnsamble = actual.minutos + CalculoRk.calcularRK();
                }

                servidorEnsamble.procesando = colaEnsambleA3.cola[0];
                colaEnsambleA3.cola.RemoveAt(0);
                colaEnsambleA5.cola.RemoveAt(0);

                servidorEnsamble.Libre = false;
             

            }
            else
            {

                //metrica cola
                ensamble.enCola = true;
                servidorEnsamble.Libre = true;
            }

            //actualizamos el servidor doble de la actividad 5
            actual.colaEnsambleA3 = colaEnsambleA3.cola.Count;
            actual.colaEnsambleA5 = colaEnsambleA5.cola.Count;
        }



        public void finEnsamble()
        {

            //double minutos = actual.minutos;
            //colaEnsambleA5.cola[0].setearHoraSalida(minutos);
            //Ensamble ensan = colaEnsambleA3.cola[0];
            //ensan.setearHoraSalida(minutos);
            //ensamblesTerminados.Add(ensan);
            //colaEnsambleA3.cola.RemoveAt(0);
            //colaEnsambleA5.cola.RemoveAt(0);
            //actual.EnsamblesTerminados += 1;



            double minutos = actual.minutos;
            
            Ensamble ensan = servidorEnsamble.procesando;
           
            ensan.setearHoraSalida(minutos);
            ensamblesTerminados.Add(ensan);

            actual.EnsamblesTerminados += 1;


            if (colaEnsambleA3.cola.Count > 0 && colaEnsambleA5.cola.Count > 0)
            {
                
                if (setParametrosFinEncastre == false)
                {
                    actual.a = genRandom.generarSerieUniforme(0.5, 2, 1)[0];
                }
                else
                {
                    actual.a = genRandom.generarSerieUniforme(li, ls, 1)[0];
                }

                if (eleccionFinEncastre == "Euler")
                {
                    CalculoEu.setA(actual.a);
                    actual.finEnsamble = actual.minutos + CalculoEu.calcularEuler();
                }
                else
                {
                    CalculoRk.setA(actual.a);
                    actual.finEnsamble = actual.minutos + CalculoRk.calcularRK();
                }
                servidorEnsamble.procesando = colaEnsambleA3.cola[0];
                colaEnsambleA3.cola.RemoveAt(0);
                colaEnsambleA5.cola.RemoveAt(0);
                servidorEnsamble.Libre = false;



            }
            else
            {
                servidorEnsamble.Libre = false;
            }

            actual.colaEnsambleA3 = colaEnsambleA3.cola.Count;
            actual.colaEnsambleA5 = colaEnsambleA5.cola.Count;
            





        }


        public List<Ensamble> devolverEnsambles()
        {

            return ensamblesTerminados;
        }

       public void calcularPromedioMetrica(int i)
        {
            if (servidorA1.Libre == false)
            {
                servidorA1.cantOcupacion +=1;

            }
            actual.porcTrabajoA1 = Math.Round((servidorA1.cantOcupacion / i), 2) * 100;


            if (servidorA2.Libre == false)
            {
                servidorA2.cantOcupacion += 1;

            }
            actual.porcTrabajoA2 = Math.Round((servidorA2.cantOcupacion / i), 2) * 100;



            if (servidorA3.Libre == false)
            {
                servidorA3.cantOcupacion += 1;

            }
            actual.porcTrabajoA3 = Math.Round((servidorA3.cantOcupacion / i), 2) * 100;



            if (servidorA4.Libre == false)
            {
                servidorA4.cantOcupacion += 1;

            }
            actual.porcTrabajoA4 = Math.Round((servidorA4.cantOcupacion / i), 2) * 100;

            if (servidorA5A4.Libre == false)
            {
                servidorA5A4.cantOcupacion += 1;

            }        
             actual.porcTrabajoA5 = Math.Round((servidorA5A4.cantOcupacion / i), 2) * 100;           

        }



        public void calcularPromedioEnsamble()
        {
            double cantidad = ensamblesTerminados.Count;
            double sumaTiemposEnsamble = 0;
            foreach(var tiempo in ensamblesTerminados)
            {
                sumaTiemposEnsamble += (tiempo.tiempoSalida-tiempo.tiempoLlegada );
            }

            inicio.mostrarPromedioEnsambles((sumaTiemposEnsamble / cantidad));
        }


        public void cantidadPromedioEnsamblesEnSistema()
        {
          

            acumuladorProductos = acumuladorProductos + (ensamblesEnElSistema-ensamblesTerminados.Count);

            cantidadPromedioProductos = acumuladorProductos / actual.numero;
                      


        }
        public void mostrarCantidadProductosEnElSitema()
        {

            inicio.ensamblesPromedioEnElSistema(cantidadPromedioProductos);
        }


        

        public void cantidadEnsamblesPromedioEnCola()
        {
            double promEnsamblesEnCaola;
            double cantidadEnsamblesEnCola=0;
            foreach (var ensamble in ensamblesSim)
            {
                if (ensamble.enCola == true)
                {
                    cantidadEnsamblesEnCola += 1;
                }
                
            }
            promEnsamblesEnCaola = cantidadEnsamblesEnCola / actual.cantEnsambles;

            inicio.mostrarPromEnsamblesEnCola(promEnsamblesEnCaola);  

        }


        //seteo de las actividades

        public void setAct1()
        {
            unidformeAA1 = 16;
            uniformeBA1 = 24;
        }
        public void setAct2()
        {
            uniformeAA2 = 24;
            uniformeBA2 = 40;
        }

        public void setAct3()
        {
            exponencialMA3 = 24;
          
        }

        public void setAct4()
        {
            uniformeAA4 = 8;
            uniformeBA4 = 16;
        }

        public void setAct5()
        {
            exponencialMA5 = 4;
        }


        public void tiempoPromedioPermanenciaEnCola()
        {

            actual.tiempoPromPermanenciaA1 = Math.Round( tiempoPermanenciaA1 / cantidadPermanenciaA1,4);
            actual.tiempoPromPermanenciaA2 = Math.Round(tiempoPermanenciaA2 / cantidadPermanenciaA2, 4);
            actual.tiempoPromPermanenciaA3 = Math.Round(tiempoPermanenciaA3 / cantidadPermanenciaA3, 4);
            actual.tiempoPromPermanenciaA4 = Math.Round(tiempoPermanenciaA4 / cantidadPermanenciaA4, 4);
            actual.tiempoPromPermanenciaA5A2 = Math.Round(tiempoPermanenciaA5A2 / cantidadPermanenciaA5A2, 4);
            actual.tiempoPromPermanenciaA5A4 = Math.Round(tiempoPermanenciaA5A4 / cantidadPermanenciaA5A4, 4);

        }


        public void cantidadDeEnsamblesRealizadosRelacionSolicitados()
        {
            double denominador = actual.EnsamblesTerminados;
            double nominador=actual.cantEnsambles;
            inicio.cantidadDeEnsamblesRealizadosRelacionSolicitados((denominador/nominador));

        }



        public void porpocionTiempoBloqueoA3oA5()
        {


            if( anterior.colaEnsambleA3>0 || anterior.colaEnsambleA5>0)
            {

                acTiempoBloqueo += actual.minutos-anterior.minutos;

            }

            actual.ProporcionBloqueoEnsamble = acTiempoBloqueo / actual.minutos;

        }


        public void SetParametrosEuler(double li, double ls, double b, double c, double x0, double dx1_0, double h)
        {
            CalculoEu.setearParametros( b, c, x0, dx1_0, h);
            setParametrosFinEncastre = true;
            this.li = li;
            this.ls = ls;

        }

        public void SetParametrosRk(double li, double ls, double b, double c, double x0, double dx1_0, double h)
        {
            CalculoRk.setearParametros( b, c, x0, dx1_0, h);
            setParametrosFinEncastre = true;
            this.li = li;
            this.ls = ls;
        }

    }
}
























    







