using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TP4.Forms
{
    public partial class GraficosRk : Form
    {
        List<double> x1;
        List<double> x2;
        List<double> dx2;
        List<double> t;

        public GraficosRk(List<double> x1, List<double> x2, List<double> dx2, List<double> t)
        {
            //x1.Clear();
            //x2.Clear();
            //dx2.Clear();
            //t.Clear();

            InitializeComponent();

            this.x1 = x1;
            this.x2 = x2;
            this.dx2 = dx2;
            this.t = t;

            cargarDatos();
        }

        public void cargarDatos()
        {
            for (int i = 0; i < x1.Count; i++)
            {
                chartRK1.Series["Series1"].Points.AddXY(x1.ElementAt(i), x2.ElementAt(i));
                chartRK2.Series["Series1"].Points.AddXY(x1.ElementAt(i), dx2.ElementAt(i));
                chartRK3.Series["Series1"].Points.AddXY(x2.ElementAt(i), dx2.ElementAt(i));
                chartRK4.Series["Series1"].Points.AddXY(t.ElementAt(i), x1.ElementAt(i));
                chartRK4.Series["Series2"].Points.AddXY(t.ElementAt(i), x2.ElementAt(i));
                chartRK4.Series["Series3"].Points.AddXY(t.ElementAt(i), dx2.ElementAt(i));


            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
