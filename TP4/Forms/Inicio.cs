using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TP4.Calculos;
using TP4.Clases;
using TP4.Forms;

namespace TP4
{
    public partial class Inicio : Form
    {
        public Calculo calculos;

        public Simulacion actual;

        public Euler pantallaEuler;

        public PantallaRK pantallaRunge;

        public bool parametrosSeteados = false;

        public double li;
        public double ls;
        public double a;
        public double b;
        public double c;
        public double h;
        public double x0;
        public double dx1_0;

        public ConfiguracionFinEnsamble PantallaConfiguracion;


        public Inicio()
        {
            InitializeComponent();                 
           
            
        }

     

        public void cargarFila(Simulacion s)
        {            
            dgvInicio.Rows.Add(
               
                s.numero,
                s.minutos,
                s.proxEvento,
                s.tiempoEntreLlegadas,
                s.proxLlegada,
                s.finA1,
                s.estadoA1,
                s.colaA1,
                s.finA2,
                s.estadoA2,
                s.colaA2,
                s.finA3,
                s.estadoA3,
                s.colaA3,
                s.finA4,
                s.estadoA4,
                s.colaA4,
                s.finA5,
                s.estadoA5,
                s.colaA5A2,
                s.colaA5A4, s.a,
                s.finEnsamble,
                habilitarBoton(s),
                habilitarBoton(s),
                s.colaEnsambleA3,
                s.colaEnsambleA5,
                s.EnsamblesTerminados,
                Math.Round(s.ProporcionBloqueoEnsamble, 2),
                s.porcTrabajoA1 + " %",
                s.porcTrabajoA2 + " %",
                s.porcTrabajoA3 + " %",
                s.porcTrabajoA4 + " %",
                s.porcTrabajoA5 + " %"               
                
            );         


        }




      

        public string habilitarBoton(Simulacion actual)
        {
            if (actual.a != 0)
            {               
                return "Ver";

            }         
               
            return "-";
            

        }


        private void btnSimular_Click(object sender, EventArgs e)
        {

            dgvInicio.Rows.Clear();
            calculos = new Calculo(this,eleccionFinEncastre());
            if (txtCantEnsambles.Text != "")
            {
                calculos.setEnsambles(int.Parse(txtCantEnsambles.Text),double.Parse(txtLambda.Text),int.Parse(txtDesde.Text),int.Parse(txtHasta.Text));
            }
            else
            {
                calculos.setSimulaciones(int.Parse(txtCantSim.Text), double.Parse(txtLambda.Text), int.Parse(txtDesde.Text), int.Parse(txtHasta.Text));
            }
            parametrosActividades();

            verificacionParametrosFinEnsamble();

            calculos.inicializacion();
        }


        public void verificacionParametrosFinEnsamble()
        {
            if (parametrosSeteados == true)
            {
                if (rdbEuler.Checked)
                {
                    calculos.SetParametrosEuler(li,ls, b, c, x0, dx1_0, h);
                }
                else
                {
                    calculos.SetParametrosRk(li, ls, b, c, x0, dx1_0, h);
                }

            }

        }
        public string eleccionFinEncastre()
        {
            if (rdbEuler.Checked)
            {
                return "Euler";
            }
            return "Runge";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<Ensamble> listado = calculos.devolverEnsambles();
            
        
            ListadoEnsambles listadoEnsamble = new ListadoEnsambles(listado);
            listadoEnsamble.ShowDialog();
        }

        public void mostarCantMaximaEnCola(int  cantidadMaxColaA1,int  cantidadMaxColaA2,int  cantidadMaxColaA3,int  cantidadMaxColaA4,int  cantidadMaxColaA5A2,double  cantidadMaxColaA5A4, int ensambleA3, int ensambleA5)
        {
            txtA1.Text = cantidadMaxColaA1.ToString();
            txtA2.Text = cantidadMaxColaA2.ToString();
            txtA3.Text = cantidadMaxColaA3.ToString();
            txtA4.Text = cantidadMaxColaA4.ToString();
            txtA5A2.Text = cantidadMaxColaA5A2.ToString();
            txtA5A4.Text = cantidadMaxColaA5A4.ToString();
            lblEnsambleA3.Text = ensambleA3.ToString();
            lblEnsambleA5.Text = ensambleA5.ToString();
        }

        public void mostrarPromedioEnsambles(double prom)
        {
            lblPromedioEnsamblado.Text = Math.Round( prom,2).ToString();
        }
        public void ensamblesPromedioEnElSistema(double prom)
        {
            lblEnsamblesEnSitema.Text =prom.ToString();
        }


        public void mostrarPromEnsamblesEnCola(double prom)
        {
            lblEnsamblesEnCola.Text = Math.Round(prom, 2).ToString();
        }



        private void txtA1_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }


        public void parametrosActividades()
        {
            if (chkActividad1.Checked == true)
            {
                calculos.setAct1();
            }
            if (chkActividad2.Checked == true)
            {
                calculos.setAct2();
            }
            if (chkActividad3.Checked == true)
            {
                calculos.setAct3();
            }
            if (chkActividad4.Checked == true)
            {
                calculos.setAct4();
            }
            if (chkActividad5.Checked == true)
            {
                calculos.setAct5();
            }
        }


        public void cargarTiempoPromedioEnCola(Simulacion s)
        {
            lblTiempPromColaA1.Text = s.tiempoPromPermanenciaA1.ToString();
            lblTiempPromColaA2.Text = s.tiempoPromPermanenciaA2.ToString();
            lblTiempPromColaA3.Text = s.tiempoPromPermanenciaA3.ToString();
            lblTiempPromColaA4.Text = s.tiempoPromPermanenciaA4.ToString();
            lblTiempPromColaA5A2.Text = s.tiempoPromPermanenciaA5A2.ToString();
            lblTiempPromColaA5A4.Text = s.tiempoPromPermanenciaA5A4.ToString();
        }


        public void cantidadDeEnsamblesRealizadosRelacionSolicitados(double proporcion)
        {

            lblProporcionTerminadosSolicitados.Text =Math.Round( proporcion,2).ToString();
        }

        private void lblProporcionTerminadosSolicitados_Click(object sender, EventArgs e)
        {

        }

        private void lblTiempPromColaA1_Click(object sender, EventArgs e)
        {

        }

        private void dgvInicio_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

     


            double adgv =double.Parse( dgvInicio.CurrentRow.Cells[21].Value.ToString());

             if (adgv != 0)
            {
                if (e.ColumnIndex == dgvInicio.Columns["bntFuncion"].Index && e.RowIndex >= 0)
                {
                    if (parametrosSeteados == true)
                    {
                        pantallaEuler = new Euler(adgv, b, c, x0, dx1_0, h);
                    }
                    else
                    {
                        pantallaEuler = new Euler(adgv, 10, 5, 0, 0, 0.05);
                    }
                  
                    pantallaEuler.ShowDialog();

                }



                if (e.ColumnIndex == dgvInicio.Columns["btnRk"].Index && e.RowIndex >= 0)
                {

                    if (parametrosSeteados == true)
                    {
                        pantallaRunge = new PantallaRK(adgv, b, c, x0, dx1_0, h);
                    }
                    else
                    {
                        pantallaRunge = new PantallaRK(adgv, 10, 5, 0, 0, 0.05);

                    }
                   
                    pantallaRunge.ShowDialog();
                }

            }
          
        }

        private void button2_Click(object sender, EventArgs e)
        {
            PantallaConfiguracion = new ConfiguracionFinEnsamble(this);
            PantallaConfiguracion.ShowDialog();
        }



        public void setearParametros(double li,double ls, double b, double c, double x0, double dx1_0, double h)
        {
            this.li = li;
            this.ls = ls;
            this.b = b;
            this.c = c;
            this.x0 = 0;
            this.dx1_0 = dx1_0;
            this.h = h;
            parametrosSeteados = true;


        }

    }
}
