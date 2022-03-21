using System;
using System.Data;
using System.Windows.Forms;
using System.IO;
using MySql.Data.MySqlClient;
using System.Drawing.Imaging;
using System.Drawing;

namespace Login
{
	public partial class AnulacionComprobantes : Form
	{

		private Usuario usuario;

		public AnulacionComprobantes(Usuario user) 
		{
			InitializeComponent();
			usuario = user;
		}

		// Carga los Combobox iniciales desde la base de datos
		void AnulacionComprobantesLoad(object sender, EventArgs e)
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




		void CancelarClick(object sender, EventArgs e)
		{this.Close();
		}
		
		
		
		void CrearClick(object sender, EventArgs e)
		{
            if (ClienteTXT.Text != "")
            {
				DialogResult result = MessageBox.Show("¿Desea confirmar la operación?", "Emisión de comprobantes", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
				switch (result)
				{
					case DialogResult.Yes:
						if (Conexion.Validar(UsuarioCBX.Text))
						{
							Conexion.AnulacionComprobante(int.Parse(NumCompNumeric.Value.ToString()));

						}
						else { MessageBox.Show("Ingrese un usuario y contraseña válido"); }

						break;
					case DialogResult.No:
						break;
				}
			}
            else
            {
				MessageBox.Show("Seleccione un comprobante", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}

		}

        private void BuscarBoton_Click(object sender, EventArgs e)
        {
			if (NumCompNumeric.Value > 0)
			{
				DataTable dt = Conexion.GetComprobante(int.Parse(NumCompNumeric.Value.ToString()));
                if (dt != null) 
				{
					foreach (DataRow x in dt.Rows)
					{
						ClienteTXT.Text = x[0].ToString();
						ImporteNUM.Value = (decimal)x[1];
					}
				}
                else
                {
					ClienteTXT.Text = "";
					ImporteNUM.Value = 0;
				}

            }
            else
            {
				MessageBox.Show("El numero de comprobante debe ser mayor a cero", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}

		}



		private byte[] Convertir_Imagen_Bytes(string ruta)
		{
			byte[] imagen = File.ReadAllBytes(ruta);
			return imagen;
		}

        private void Codigotxt_TextChanged(object sender, EventArgs e)
        {
		}

        private void NumCompNumeric_ValueChanged(object sender, EventArgs e)
        {
			BuscarBoton_Click(sender, e);

		}
    }
}
