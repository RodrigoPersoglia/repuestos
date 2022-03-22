using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Login
{
    public partial class fondo : Form
    {
        Usuario user;
        public fondo()
        {
            InitializeComponent();
        }
        public fondo(Usuario usuario)
        {
            InitializeComponent();
            user = usuario;
        }
        private void fondo_Load(object sender, EventArgs e)
        {


            Calendario.Location = new Point(this.Width-20-Calendario.Width, this.Height -20- Calendario.Height);
            label2.Text = "Usuario: " + user.User;
            label2.Location = new Point(this.Width - 10 - label2.Width, 10);
            label1.Location = new Point(20, this.Height - 20 - label1.Height);
            SistemaLabel.Location = new Point(20, 20);
        }

        private void fondo_Click(object sender, EventArgs e)
        {
            if(Calendario.Visible == false) { Calendario.Visible = true ; }
            else { Calendario.Visible = false; }
            
        }

        private void Calendario_MouseEnter(object sender, EventArgs e)
        {
            //Calendario.Size = new Size(Calendario.Width * 2, Calendario.Height * 2);
            //Calendario.Location = new Point(this.Width - 20 - Calendario.Width, this.Height - 20 - Calendario.Height);
            //Calendario.BackColor = Color.Gray;
        }

        private void Calendario_MouseLeave(object sender, EventArgs e)
        {
            //Calendario.Size = new Size(248, 162);
            //Calendario.Location = new Point(this.Width - 20 - Calendario.Width, this.Height - 20 - Calendario.Height);
            //Calendario.BackColor = Color.Gray;
        }


       

    }
}
