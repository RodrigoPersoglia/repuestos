using System;
using System.Data;
using System.Windows.Forms;
using System.IO;
using MySql.Data.MySqlClient;
using System.Drawing.Imaging;
using System.Drawing;

namespace Login
{
	public partial class CambioPrecios : Form
	{

		private Usuario usuario;
		private bool IngresaPorcentaje = true;

		public CambioPrecios(Usuario user,string ingreso, bool IngPorcentaje) 
		{
			InitializeComponent();
			usuario = user;
			label6.Text = ingreso;
			IngresaPorcentaje = IngPorcentaje;
		}

		// Carga los Combobox iniciales desde la base de datos
		void CambioPreciosLoad(object sender, EventArgs e)
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
			string consulta2 = "Select ID,descripcion From rubro t order by t.descripcion";
			try
			{
				MySqlCommand comand = new MySqlCommand(consulta2, conectar);
				reader = comand.ExecuteReader();
				DataTable dt = new DataTable();
				dt.Load(reader);
				DataRow newRow = dt.NewRow();
                newRow["descripcion"] = "Todos";
                dt.Rows.InsertAt(newRow, 0);
                RubroCBX.DataSource = dt;
				RubroCBX.DisplayMember = "descripcion";
				RubroCBX.ValueMember = "ID";
			}
			catch (MySqlException ex) { MessageBox.Show("Error al buscar " + ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error); }
			// COMBOBOX PROVEEDOR
			string consulta5 = "Select ID,Alias From proveedor c order by c.Alias";
			try
			{
				MySqlCommand comand = new MySqlCommand(consulta5, conectar);
				reader = comand.ExecuteReader();
				DataTable dt = new DataTable();
				dt.Load(reader);
				DataRow newRow = dt.NewRow();
                newRow["Alias"] = "Todos";
                dt.Rows.InsertAt(newRow, 0);
                ProveedorCBX.DataSource = dt;
				ProveedorCBX.DisplayMember = "Alias";
				ProveedorCBX.ValueMember = "ID";
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
			int rubroID = (int)RubroCBX.SelectedValue;
			int proveedorID = (int)ProveedorCBX.SelectedValue;
            if (RubroCBX.Text == "Todos"){rubroID = 0;}
			if(ProveedorCBX.Text == "Todos") { proveedorID = 0; }

			DialogResult result = MessageBox.Show("¿Desea confirmar la operación?", "Emisión de comprobantes", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
			switch (result)
			{
				case DialogResult.Yes:

					if (Conexion.Validar(UsuarioCBX.Text))
					{
						if (IngresaPorcentaje)
						{
							decimal valor = 0;
							if (Aumento.Checked == true)
							{ valor = 1 + (ModificacionNUM.Value / 100); }
							else
							{ valor = 1 - (ModificacionNUM.Value / 100); }
							Conexion.ModificarPrecioPorcentaje(rubroID, valor, proveedorID);
						}
						else
						{
							decimal valor = 0;
							if (Aumento.Checked == true)
							{ valor = 1 * ModificacionNUM.Value; }
							else
							{ valor = -1 * ModificacionNUM.Value; }
							Conexion.ModificarPrecioImporte(rubroID, valor, proveedorID);
						}

					}
					else { MessageBox.Show("Ingrese un usuario y contraseña válido"); }

					break;
				case DialogResult.No:
					break;
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


    }
}
