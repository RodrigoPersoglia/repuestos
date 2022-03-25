using MySql.Data.MySqlClient;
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
    public partial class EntradasSalidas : Form
    {
        Articulo articulo = new Articulo();
        Usuario usuario;
       
        public EntradasSalidas(Usuario user)
        {
            InitializeComponent();
            usuario = user;

        }

        private void BuscarBTN_Click(object sender, EventArgs e)
        {
            articulo = Conexion.ObtenerArticulo(CodigoTXT.Text,this);
            CodigoTXT.Text = articulo.Codigo;
            DescripcionTXT.Text = articulo.Descripcion;
        }

        private void CodigoTXT_TextChanged(object sender, EventArgs e)
        {
            DescripcionTXT.Text = "";
        }

        private void AceptarBTN_Click(object sender, EventArgs e)
        {
            if(DescripcionTXT.Text!="" && CantidadNUM.Value > 0)
            {
                DialogResult result = MessageBox.Show("¿Desea confirmar la operación?", "Movimiento de artículos", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                switch (result)
                {
                    case DialogResult.Yes:

                        if (Conexion.Validar(UsuarioCBX.Text))
                        {
                            int tipoMovimiento = 1;
                            if (SalidaRB.Checked) { tipoMovimiento = 2; }
                            Conexion.MovimientoStock(DateTime.Today, articulo.ID, tipoMovimiento, UsuarioCBX.Text, ObservacionesTXT.Text, int.Parse(CantidadNUM.Value.ToString()));

                        }
                        else { MessageBox.Show("Ingrese un usuario y contraseña válido"); }

                        break;
                    case DialogResult.No:
                        break;
                }

            }
            else { MessageBox.Show("Revise los campos ingresados", "Movimiento de artículos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }

		}

        private void EntradasSalidas_Load(object sender, EventArgs e)
        {
            MySqlConnection conectar = Conexion.ObtenerConexion();

            // COMBOBOX USUARIO
            MySqlDataReader reader;
            string consulta = "Select ID,usuario From usuario a order by a.usuario";
            conectar.Open();

            try
            {
                MySqlCommand comand = new MySqlCommand(consulta, conectar);
                reader = comand.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(reader);
                UsuarioCBX.DataSource = dt;
                UsuarioCBX.DisplayMember = "usuario";
                UsuarioCBX.ValueMember = "ID";

            }
            catch (MySqlException ex) { MessageBox.Show("Error al buscar " + ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            finally { conectar.Close(); }
            UsuarioCBX.Text = usuario.User;
        }

        private void CancelarBTN_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
