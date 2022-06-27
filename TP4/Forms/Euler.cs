using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TP4.CalculosPantallaRk_Euler;
using TP4.Clases;

namespace TP4.Forms
{
    public partial class Euler : Form
    {

        public RkEuler calculosEulerRK;
        
        
       
        public List<double> x1;
        public List<double> x2;
        public List<double> dx2;
        public List<double> t;

        GraficosRk pantallaGraficosRK;

        public Euler(double a, double b, double c, double x0, double dx1_0, double h)
        {
            InitializeComponent();

            calculosEulerRK = new RkEuler(this,a);
            calculosEulerRK.setearParametros( a,  b,  c,  x0,  dx1_0,  h);
            calculosEulerRK.calcularEuler();


            x1 = new List<double>();
            x2 = new List<double>();
            dx2 = new List<double>();
            t = new List<double>();

        }



        public void cargarFila(SimulacionEuler sim)
        {
            dgvEuler.Rows.Add(
                Math.Round( sim.t,4),
                  Math.Round(sim.x1,4),
                  Math.Round(sim.x2,4),
                  Math.Round(sim.dx2,4)
            );
        }

        public void mostrarSegundoPico(double pico)
        {
            lblSegundoPico.Text = pico.ToString();
        }

        private void btnGraficar_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dgvEuler.Rows.Count - 1; i++)
            {
                x1.Add(double.Parse(dgvEuler.Rows[i].Cells[1].Value.ToString()));
                x2.Add(double.Parse(dgvEuler.Rows[i].Cells[2].Value.ToString()));
                dx2.Add(double.Parse(dgvEuler.Rows[i].Cells[3].Value.ToString()));
                t.Add(double.Parse(dgvEuler.Rows[i].Cells[0].Value.ToString()));
            }

            pantallaGraficosRK = new GraficosRk(x1, x2, dx2, t);
            pantallaGraficosRK.ShowDialog();

        }
    }
}
