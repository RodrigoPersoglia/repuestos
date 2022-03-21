using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Data;

namespace Login
{
	public partial class VentanaSeleccion2 : Form
	{
		//Declaracion de variables, sirve para vincular con la ventana que las instancia.
		private Cliente clienteSeleccionado = new Cliente();

		
		
		// Constructor
		public VentanaSeleccion2(string texto){InitializeComponent();
			Busquedatext.Text =texto;
		}
		
		//Propiedades, solo Get
		public Cliente ClienteSeleccionado
		{
			get{return clienteSeleccionado; }
		}

		
		
		//Muestra en el cuadro las coincidencias
		void BuscarClick(object sender, EventArgs e){
			Cuadro.DataSource = null;
			Cuadro.Rows.Clear();

			MySqlConnection conectar = Conexion.ObtenerConexion();
			conectar.Open();
			DataTable dt = new DataTable();
            try
            {
                MySqlCommand comand = new MySqlCommand("ObtenerCliente", conectar);
				comand.CommandType = CommandType.StoredProcedure;
				comand.Parameters.AddWithValue("@p1", Busquedatext.Text);
				MySqlDataAdapter adp = new MySqlDataAdapter(comand);
				adp.Fill(dt);
				foreach (DataRow x in dt.Rows)
				{
					int n = Cuadro.Rows.Add();
					Cuadro.Rows[n].Cells[0].Value = (int)x[0];
					Cuadro.Rows[n].Cells[1].Value = (int)x[1];
					Cuadro.Rows[n].Cells[2].Value = (string)x[2];
                    try 
					{
						Cuadro.Rows[n].Cells[3].Value = (string)x[3];
					}
					catch (Exception) { }
					try
					{
						Cuadro.Rows[n].Cells[4].Value = (int)x[4];
					}
					catch (Exception) { }
					try
					{
						Cuadro.Rows[n].Cells[5].Value = (string)x[5];
					}
					catch (Exception) { }
					try
					{
						Cuadro.Rows[n].Cells[6].Value = (string)x[6];
					}
					catch (Exception) { }


					Cuadro.Rows[n].Cells[7].Value = (int)x[7];
					Cuadro.Rows[n].Cells[8].Value = (string)x[8];
					Cuadro.Rows[n].Cells[9].Value = (string)x[9];
					Cuadro.Rows[n].Cells[10].Value = (string)x[10];
					Cuadro.Rows[n].Cells[11].Value = (string)x[11];
					Cuadro.Rows[n].Cells[12].Value = (int)x[12];
					Cuadro.Rows[n].Cells[13].Value = (string)x[13];
					Cuadro.Rows[n].Cells[14].Value = (string)x[14];
					Cuadro.Rows[n].Cells[15].Value = (string)x[15];
					Cuadro.Rows[n].Cells[16].Value = (string)x[16];
					Cuadro.Rows[n].Cells[17].Value = (string)x[17];
					Cuadro.Rows[n].Cells[18].Value = (string)x[18];
					Cuadro.Rows[n].Cells[19].Value = (decimal)x[19];
					Cuadro.Rows[n].Cells[20].Value = (decimal)x[20];
			}
            }
            catch (Exception ex) { MessageBox.Show("Error al buscar " + ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            finally { conectar.Close(); }
        }

		
		// Devuelve el indice de la celda seleccionada
		int n;
		void Selecccioncelda(object sender, DataGridViewCellEventArgs e)
		{n = e.RowIndex;}

		
		//Cierra la ventana y escribe la informacion en las propiedades
		void AceptarClick(object sender, EventArgs e){
			ClienteSeleccionado.ID = int.Parse(Cuadro.Rows[n].Cells[0].Value.ToString());
			ClienteSeleccionado.Numero = int.Parse(Cuadro.Rows[n].Cells[1].Value.ToString());
			ClienteSeleccionado.Alias = Cuadro.Rows[n].Cells[2].Value.ToString();

			if (Cuadro.Rows[n].Cells[3].Value != null){
				try { ClienteSeleccionado.RazonSocial = Cuadro.Rows[n].Cells[3].Value.ToString(); }
				catch (Exception) { }
			}
			if (Cuadro.Rows[n].Cells[4].Value!=null)
			{
				try { ClienteSeleccionado.Cuit = int.Parse(Cuadro.Rows[n].Cells[4].Value.ToString()); }
				catch (Exception) { }
			}

			if (Cuadro.Rows[n].Cells[5].Value!=null)
			{
				try { ClienteSeleccionado.Telefono1 = Cuadro.Rows[n].Cells[5].Value.ToString(); }
				catch (Exception) { }

			}
			if (Cuadro.Rows[n].Cells[6].Value!=null)
			{
				try { ClienteSeleccionado.Telefono2 = Cuadro.Rows[n].Cells[6].Value.ToString(); }
				catch (Exception) { }

			}
			ClienteSeleccionado.IDDireccion = int.Parse(Cuadro.Rows[n].Cells[7].Value.ToString());
			ClienteSeleccionado.Direccion = Cuadro.Rows[n].Cells[8].Value.ToString();
			ClienteSeleccionado.Ciudad = Cuadro.Rows[n].Cells[9].Value.ToString();
			ClienteSeleccionado.Provincia = Cuadro.Rows[n].Cells[10].Value.ToString();
			ClienteSeleccionado.CP = Cuadro.Rows[n].Cells[11].Value.ToString();
			ClienteSeleccionado.IDDireccion2 = int.Parse(Cuadro.Rows[n].Cells[12].Value.ToString());
			ClienteSeleccionado.Direccion2 = Cuadro.Rows[n].Cells[13].Value.ToString();
			ClienteSeleccionado.Ciudad2 = Cuadro.Rows[n].Cells[14].Value.ToString();
			ClienteSeleccionado.Provincia2 = Cuadro.Rows[n].Cells[15].Value.ToString();
			ClienteSeleccionado.CP2 = Cuadro.Rows[n].Cells[16].Value.ToString();
			ClienteSeleccionado.IVA = Cuadro.Rows[n].Cells[17].Value.ToString();
			ClienteSeleccionado.TIPODOC = Cuadro.Rows[n].Cells[18].Value.ToString();
			ClienteSeleccionado.Bonificacion = decimal.Parse(Cuadro.Rows[n].Cells[19].Value.ToString());
			ClienteSeleccionado.Recargo = decimal.Parse(Cuadro.Rows[n].Cells[20].Value.ToString());
		}

        private void articuloBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void VentanaSeleccion2_Load(object sender, EventArgs e)
        {

        }
    }
}