using System;
using System.Data;
using System.Windows.Forms;
using System.IO;
using MySql.Data.MySqlClient;
using System.Drawing.Imaging;
using System.Drawing;

namespace Login
{
	public partial class AgregarCiudad : Form
	{
		Articulo articulo = new Articulo();

		public AgregarCiudad() {InitializeComponent();}



		// Carga los Combobox iniciales desde la base de datos
		void AgregarCiudadLoad(object sender, EventArgs e)
		{
			MySqlConnection conectar = Conexion.ObtenerConexion();
			conectar.Open();
			MySqlDataReader reader;
			
			// COMBOBOX PROVINCIA
			string consulta5 = "Select ID,nombre From Provincia p order by p.nombre";
			try
			{
				MySqlCommand comand = new MySqlCommand(consulta5, conectar);
				reader = comand.ExecuteReader();
				DataTable dt = new DataTable();
				dt.Load(reader);
				DataRow newRow = dt.NewRow();
				newRow["nombre"] = "Seleccione";
				dt.Rows.InsertAt(newRow, 0);
				ProvinciaComboBox.DataSource = dt;
				ProvinciaComboBox.DisplayMember = "nombre";
				ProvinciaComboBox.ValueMember = "ID";
			}
			catch (MySqlException ex) { MessageBox.Show("Error al buscar " + ex.Message,"Atención",MessageBoxButtons.OK,MessageBoxIcon.Error); }
			finally{conectar.Close();} // Cerramos la conexion a la base de datos

		}




		void CancelarClick(object sender, EventArgs e)
		{this.Close();
		}
		
		
		
		void CrearClick(object sender, EventArgs e)
		{
			if (ProvinciaComboBox.Text != "Seleccione" && LocalidadNueva.Text != "")
			{
				string sql = "INSERT INTO Localidad (nombre,Provincia_ID) VALUES ('" + LocalidadNueva.Text + "', '" + ProvinciaComboBox.SelectedValue + "')";

				MySqlConnection conexionBD = Conexion.ObtenerConexion();
				conexionBD.Open();
				try
				{
					MySqlCommand comando = new MySqlCommand(sql, conexionBD);
					comando.ExecuteNonQuery();
					MessageBox.Show("Registro guardado");
					//limpiar();
					LocalidadNueva.Text = "";
					
					


				}
				catch (MySqlException ex)
				{
					MessageBox.Show("Error al guardar: " + ex.Message);
				}
				finally
				{
					conexionBD.Close();
					MySqlConnection conectar = Conexion.ObtenerConexion();
					// COMBOBOX LOCALIDAD ENTREGA
					LocalidadExistente.DataSource = null;
					LocalidadExistente.Items.Clear();
					MySqlDataReader reader;
					string consulta = "Select ID,nombre From localidad l where l.Provincia_ID = '" + ProvinciaComboBox.SelectedValue.ToString() + "' order by l.nombre";
					conectar.Open();

					try
					{
						MySqlCommand comand = new MySqlCommand(consulta, conectar);
						reader = comand.ExecuteReader();
						DataTable dt = new DataTable();
						dt.Load(reader);
						DataRow newRow = dt.NewRow();
						newRow["nombre"] = "Seleccione";
						dt.Rows.InsertAt(newRow, 0);
						LocalidadExistente.DataSource = dt;
						LocalidadExistente.DisplayMember = "nombre";
						LocalidadExistente.ValueMember = "ID";

					}
					catch (MySqlException ex) { MessageBox.Show("Error al buscar " + ex.Message,"Atención",MessageBoxButtons.OK,MessageBoxIcon.Error); }
					finally { conectar.Close(); }
				}

			}
			else { MessageBox.Show("Complete todos los campos"); }


		}

        private void ProvinciaComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ProvinciaComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
			MySqlConnection conectar = Conexion.ObtenerConexion();
			// COMBOBOX LOCALIDAD ENTREGA
			LocalidadExistente.DataSource = null;
			LocalidadExistente.Items.Clear();
			MySqlDataReader reader;
			string consulta = "Select ID,nombre From localidad l where l.Provincia_ID = '" + ProvinciaComboBox.SelectedValue.ToString() + "' order by l.nombre";
			conectar.Open();

			try
			{
				MySqlCommand comand = new MySqlCommand(consulta, conectar);
				reader = comand.ExecuteReader();
				DataTable dt = new DataTable();
				dt.Load(reader);
				DataRow newRow = dt.NewRow();
				newRow["nombre"] = "Seleccione";
				dt.Rows.InsertAt(newRow, 0);
				LocalidadExistente.DataSource = dt;
				LocalidadExistente.DisplayMember = "nombre";
				LocalidadExistente.ValueMember = "ID";

			}
			catch (MySqlException ex) { MessageBox.Show("Error al buscar " + ex.Message,"Atención",MessageBoxButtons.OK,MessageBoxIcon.Error); }
			finally { conectar.Close(); }
		}

        private void EliminarBTN_Click(object sender, EventArgs e)
        {
			if (LocalidadExistente.Text != "" && LocalidadExistente.Text!="Seleccione" && LocalidadExistente != null)
            {
				Conexion.EliminarLocalidad(LocalidadExistente.Text);
				MySqlConnection conectar = Conexion.ObtenerConexion();
				// COMBOBOX LOCALIDAD ENTREGA
				LocalidadExistente.DataSource = null;
				LocalidadExistente.Items.Clear();
				MySqlDataReader reader;
				string consulta = "Select ID,nombre From localidad l where l.Provincia_ID = '" + ProvinciaComboBox.SelectedValue.ToString() + "' order by l.nombre";
				conectar.Open();

                try
                {
                    MySqlCommand comand = new MySqlCommand(consulta, conectar);
					reader = comand.ExecuteReader();
					DataTable dt = new DataTable();
					dt.Load(reader);
					DataRow newRow = dt.NewRow();
					newRow["nombre"] = "Seleccione";
					dt.Rows.InsertAt(newRow, 0);
					LocalidadExistente.DataSource = dt;
					LocalidadExistente.DisplayMember = "nombre";
					LocalidadExistente.ValueMember = "ID";

                }
                catch (MySqlException) { MessageBox.Show("No se puede eliminar una Localidad que registre actividad"); }
                catch (Exception ex) { MessageBox.Show("Error al buscar " + ex.Message,"Atención",MessageBoxButtons.OK,MessageBoxIcon.Error); }
                finally { conectar.Close(); }
            }
            else { MessageBox.Show("Seleccione una localidad a eliminar"); }
        }
    }
}
