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
    public partial class ConfiguracionFinEnsamble : Form
    {
        public Inicio pantallaInicio;
        public ConfiguracionFinEnsamble(Inicio pantallaInicio)
        {
            InitializeComponent();
           this.pantallaInicio = pantallaInicio;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            pantallaInicio.setearParametros(double.Parse(txtLi.Text),double.Parse(txtLs.Text),double.Parse( txtb.Text),double.Parse( txtc.Text),double.Parse( txtx.Text), double.Parse(txtxPrima.Text), double.Parse(txth.Text));
            this.Close();
        }
    }
}
