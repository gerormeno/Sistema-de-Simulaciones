using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TP4.Clases;

namespace TP4.Forms
{
    public partial class ListadoEnsambles : Form
    {

        public List<Ensamble> ensambles;
        public bool primeraVuelta=false;
        public double duracionEnsambleAnterior;
        public double duracionMaxEnsambles;
        public double tiempoSalidaUltimoEnsamble;

        public ListadoEnsambles( List<Ensamble> ensambles )
        {
            this.ensambles = ensambles;
            InitializeComponent();
            mostrarEnsambles();
            
            ensamblexHora();
            //la segunda parte que pide el promedio no la entendi ni chota



        }



        public void mostrarEnsambles()
        {

            foreach (var ensamble in ensambles ){
                if (primeraVuelta == false)
                {
                    llenardvgPrimeraVez(ensamble);
                    primeraVuelta = true;
                }
                else { llenardvg(ensamble); }
                
                
            }

        }


        public void llenardvg(Ensamble en)
        {

            double acDuracionEnsamble = duracionEnsambleAnterior + en.tiempoEnsamble();
            dvgEnsambles.Rows.Add(en.id,
                en.tiempoLlegada,
                en.tiempoSalida,
                en.tiempoEnsamble(),
                acDuracionEnsamble,
               Math.Round( (acDuracionEnsamble/en.id),2)
                );


                
            duracionEnsambleAnterior = acDuracionEnsamble;
            tiempoSalidaUltimoEnsamble = en.tiempoSalida;
        }


        public void llenardvgPrimeraVez(Ensamble en)
        {

            dvgEnsambles.Rows.Add(en.id,
               en.tiempoLlegada,
               en.tiempoSalida,
               en.tiempoEnsamble(),
               en.tiempoEnsamble(),
               en.tiempoEnsamble()


               );
            duracionEnsambleAnterior = en.tiempoEnsamble();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        public void calcularPromedio(double numero)
        {
            double cantidadEnsambles = ensambles.Count();
            double porcentaje= ((cantidadEnsambles / tiempoSalidaUltimoEnsamble) * (60 / numero));
            lblPorc.Text =Math.Round( porcentaje,4)+" %";

        }

        public void ensamblexHora()
        {
            lblEnsamblesPorHora.Text = Math.Round( ((60 * ensambles.Count()) / tiempoSalidaUltimoEnsamble),2).ToString();

        }






        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void CalcularProbabilidad(object sender, EventArgs e)
        {
            calcularPromedio(double.Parse(txtCantidad.Text));
        }
    }
}
