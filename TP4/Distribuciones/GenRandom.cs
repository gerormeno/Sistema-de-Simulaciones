using System;


namespace Test
{
    public class GenRandom
    {
        private double[] serieExponencial { get; set; }
        private double[] serieNormal { get; set; }
        private double[] serieUniforme { get; set; }
        private double[] seriePoisson { get; set; }
        private Random rndExp;
        private Random rndUnif;
        private Random rndNormal;
        private Random rndPoisson;

        public GenRandom()
        {
            rndExp = new Random();
            rndUnif = new Random();
            rndNormal = new Random();
            rndPoisson = new Random();
        }

        public double[] generarSerieExponencial(double media, int cantNumeros)
        {

            //Console.WriteLine("Serie Exponencial");

            //--- Datos de entrada (Media y Cantidad de Numeros) ---//
            //	Console.WriteLine("media " + media);
            //Console.WriteLine("cantNumeros " + cantNumeros);
            //Declaracion de variables//
            double[] serieExponencial = new double[cantNumeros];
            //Random rnd = new Random();

            for (int i = 0; i < cantNumeros; i++)
            {
                double nRand = rndExp.NextDouble();
                serieExponencial[i] = Math.Round(-media * Math.Log(1 - nRand), 4);
                //Console.WriteLine(serieExponencial[i]);
            }
            return serieExponencial;
        }
        public double[] generarSerieNormal(double media, double varianza, int cantNumeros)
        {
            //--- Datos de entrada (Media y Varianza) ---//

            //Console.WriteLine("Serie Normal");

            double desviacion = Math.Sqrt(varianza);
            double[] serieNormal = new double[cantNumeros];

            //Box Muller//

            bool impar = false;

            Random rnd = new Random();


            if (cantNumeros % 2 == 1) { impar = true; }

            for (int i = 0; i < cantNumeros; i += 2)
            {
                //Generacion de 2 numeros Aleatorios
                double nRnd1 = rndNormal.NextDouble();
                double nRnd2 = rndNormal.NextDouble();

                //Generacion de n1 y n2
                double n1 = (Math.Sqrt(-2 * Math.Log(nRnd1)) * Math.Cos(2 * Math.PI * nRnd2)) * desviacion + media;
                double n2 = (Math.Sqrt(-2 * Math.Log(nRnd1)) * Math.Sin(2 * Math.PI * nRnd2)) * desviacion + media;

                //Llenado del array de la serie
                serieNormal[i] = Math.Round(n1, 4);

                if (impar == true && i == cantNumeros - 1)
                {
                    break;
                }

                serieNormal[i + 1] = Math.Round(n2, 4);
                //Console.WriteLine(serieNormal[i]);
                //Console.WriteLine(serieNormal[i + 1]);

            }
            return serieNormal;
        }
        public double[] generarSerieUniforme(double li, double ls, int cantNumeros)
        {

            double[] serieUniforme = new double[cantNumeros];
            //Console.WriteLine("Serie Uniforme");
            Random rnd = new Random();

            for (int i = 0; i < cantNumeros; i++)
            {
                double nRnd = rndUnif.NextDouble();
                double x = li + nRnd * (ls - li);
                serieUniforme[i] = Math.Round(x, 4);

                //Console.WriteLine(serieUniforme[i]);
            }
            //Console.WriteLine(serieUniforme[0]);
            return serieUniforme;
        }
        public double[] generarSeriePoisson(double lambda, int cantNumeros)
        {
            Console.WriteLine("Serie Poisson");

            //Definicion de constantes
            double[] seriePoisson = new double[cantNumeros];

            Random rnd = new Random();
            //Generacion de los valores 'x'//
            for (int i = 0; i < cantNumeros; i++)
            {
                int x = -1;
                double p = 1;
                double a = Math.Exp(-lambda);

                do
                {
                    double u = rnd.NextDouble();
                    p = p * u;
                    x++;
                } while (p >= a);

                seriePoisson[i] = x;
                Console.WriteLine(seriePoisson[i]);

            }

            return seriePoisson;
        }

        //static void Main(string[] args)
        //{
        //Agregar parametros Media - Cantida de Numeros 
        //generarSerieExponencial(10, 50);

        //Agregar parametros Media - Varianza - Cantidad de Numeros
        //generarSerieNormal(0, 5, 200);

        //Agregar parametros Li - ls - Cantidad de Numeros
        //generarSerieUniforme(5, 10, 200);

        //Agregar parametros Lambda - Cantidad de Numeros
        //generarSeriePoisson(10, 500);
        //}

        //public static void test()
        //{  
        //	//Agregar parametros Media - Cantida de Numeros 
        //   //generarSerieExponencial(10, 50);

        //	//Agregar parametros Media - Varianza - Cantidad de Numeros
        //	generarSerieNormal(0, 5, 50);

        //	//Agregar parametros Li - ls - Cantidad de Numeros
        //	generarSerieUniforme(5, 10, 50);

        //	//Agregar parametros Lambda - Cantidad de Numeros
        //	generarSeriePoisson(10, 50);
        //}
    }
}

