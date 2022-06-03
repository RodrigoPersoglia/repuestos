using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Login
{
    public partial class Impresora : Form
    {
        public Impresora()
        {
            InitializeComponent();
        }

        private void Impresora_Load(object sender, EventArgs e)
        {
            ImpresoraTXT.Text = Conexion.GetImpresora();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ModificarBTN_Click(object sender, EventArgs e)
        {
            PrintDialog printDialog1 = new PrintDialog();
            DialogResult result = printDialog1.ShowDialog();
            string impresora = printDialog1.PrinterSettings.PrinterName.ToString();
            Conexion.SetImpresora(impresora);
            Impresora_Load (sender,e);
        }
    }
}
