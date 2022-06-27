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
    public partial class PantallaRK : Form
    {


        RkEuler calculosEulerRK;

        public List<double> x1;
        public List<double> x2;
        public List<double> dx2;
        public List<double> t;

        GraficosRk pantallaGraficosRK;

        public PantallaRK(double a, double b, double c, double x0, double dx1_0, double h)
        {
            InitializeComponent();

            calculosEulerRK = new RkEuler(this,a);
            calculosEulerRK.setearParametros(a, b, c, x0, dx1_0, h);
            calculosEulerRK.calcularRK();

            x1 = new List<double>();
            x2 = new List<double>();
            dx2 = new List<double>();
            t = new List<double>();
        }

        public void cargarFila(SimulacionRK sim)
        {
            dgvRK.Rows.Add(
                Math.Round( sim.t,4),
               Math.Round(sim.x1,4),
               Math.Round(sim.k1,4),
               Math.Round(sim.k2,4),
               Math.Round(sim.k3,4),
               Math.Round(sim.k4,4),
               sim.x2,
               Math.Round(sim.l1,4),
               Math.Round(sim.l2,4),
               Math.Round(sim.l3,4),
                Math.Round(sim.l4,4),
               Math.Round(sim.dx2,4)
            );
        }

        //public void clickGraficar(Object sender, EventArgs e)
        //{

        //    for (int i = 0; i < dgvRK.Rows.Count - 1; i++)
        //    {
        //        x1.Add(double.Parse(dgvRK.Rows[i].Cells[1].Value.ToString()));
        //        x2.Add(double.Parse(dgvRK.Rows[i].Cells[6].Value.ToString()));
        //        dx2.Add(double.Parse(dgvRK.Rows[i].Cells[11].Value.ToString()));
        //        t.Add(double.Parse(dgvRK.Rows[i].Cells[0].Value.ToString()));
        //    }

        //    pantallaGraficosRK = new GraficosRK(x1, x2, dx2, t);
        //    pantallaGraficosRK.ShowDialog();

        //}






        public void cargarSegundoPico(double pico)
        {

            lblSegundoPico.Text = pico.ToString();
        }










        private void dgvEuler_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnGraficar_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dgvRK.Rows.Count - 1; i++)
            {
                x1.Add(double.Parse(dgvRK.Rows[i].Cells[1].Value.ToString()));
                x2.Add(double.Parse(dgvRK.Rows[i].Cells[6].Value.ToString()));
                dx2.Add(double.Parse(dgvRK.Rows[i].Cells[11].Value.ToString()));
                t.Add(double.Parse(dgvRK.Rows[i].Cells[0].Value.ToString()));
            }

            pantallaGraficosRK = new GraficosRk(x1, x2, dx2, t);
            pantallaGraficosRK.ShowDialog();

        }
    }
}
