using System;
using System.Data;
using System.Windows.Forms;
using System.IO;
using MySql.Data.MySqlClient;
using System.Drawing.Imaging;
using System.Drawing;

namespace Login
{
	public partial class AgregarArticulo : Form
	{
		public AgregarArticulo() {InitializeComponent();}

		// Carga los Combobox iniciales desde la base de datos
		void AgregarArticuloLoad(object sender, EventArgs e)
		{
			MySqlConnection conectar = Conexion.ObtenerConexion();

			// COMBOBOX MARCA
			MySqlDataReader reader;
			string consulta = "Select ID,descripcion From marca a order by a.descripcion";
			conectar.Open();

			try{
				MySqlCommand comand = new MySqlCommand(consulta, conectar);
				reader = comand.ExecuteReader();
				DataTable dt = new DataTable();
				dt.Load(reader);
				DataRow newRow = dt.NewRow();
				newRow["descripcion"] = "Seleccione";
				dt.Rows.InsertAt(newRow, 0);
				MarcaCBX.DataSource = dt;
				MarcaCBX.DisplayMember = "descripcion";
				MarcaCBX.ValueMember = "ID";

			}
			catch (MySqlException ex){MessageBox.Show("Error al buscar " + ex.Message,"Atención",MessageBoxButtons.OK,MessageBoxIcon.Error);}

			// COMBOBOX RUBRO
			string consulta2 = "Select ID,descripcion From rubro t order by t.descripcion";
			try
			{
				MySqlCommand comand = new MySqlCommand(consulta2, conectar);
				reader = comand.ExecuteReader();
				DataTable dt = new DataTable();
				dt.Load(reader);
				DataRow newRow = dt.NewRow();
				newRow["descripcion"] = "Seleccione";
				dt.Rows.InsertAt(newRow, 0);
				RubroCBX.DataSource = dt;
				RubroCBX.DisplayMember = "descripcion";
				RubroCBX.ValueMember = "ID";
			}
			catch (MySqlException ex) { MessageBox.Show("Error al buscar " + ex.Message,"Atención",MessageBoxButtons.OK,MessageBoxIcon.Error); }

			// COMBOBOX LADO
			string consulta3 = "Select ID,descripcion From lado c order by c.descripcion ";
			try
			{
				MySqlCommand comand = new MySqlCommand(consulta3, conectar);
				reader = comand.ExecuteReader();
				DataTable dt = new DataTable();
				dt.Load(reader);
				DataRow newRow = dt.NewRow();
				newRow["descripcion"] = "Seleccione";
				dt.Rows.InsertAt(newRow, 0);
				LadoCBX.DataSource = dt;
				LadoCBX.DisplayMember = "descripcion";
				LadoCBX.ValueMember = "ID";
			}
			catch (MySqlException ex) { MessageBox.Show("Error al buscar " + ex.Message,"Atención",MessageBoxButtons.OK,MessageBoxIcon.Error); }


			// COMBOBOX PROVEEDOR
			string consulta5 = "Select ID,Alias From proveedor c order by c.Alias";
			try
			{
				MySqlCommand comand = new MySqlCommand(consulta5, conectar);
				reader = comand.ExecuteReader();
				DataTable dt = new DataTable();
				dt.Load(reader);
				DataRow newRow = dt.NewRow();
				newRow["Alias"] = "Seleccione";
				dt.Rows.InsertAt(newRow, 0);
				ProveedorCBX.DataSource = dt;
				ProveedorCBX.DisplayMember = "Alias";
				ProveedorCBX.ValueMember = "ID";
			}
			catch (MySqlException ex) { MessageBox.Show("Error al buscar " + ex.Message,"Atención",MessageBoxButtons.OK,MessageBoxIcon.Error); }
			finally { conectar.Close(); } // Cerramos la conexion a la base de datos
		}




		void CancelarClick(object sender, EventArgs e)
		{this.Close();
		}

		private void limpiar()
        {
			Codigotxt.Text = "";
			CodigoProvTXT.Text = "";
			numPiezaTXT.Text = "";
			DescripcionTxt.Text = "";
			PrecioNum.Value = 0;
			stockMinNum.Value = 0;
			stockMaxNum.Value = 0;
			stockActualNum.Value = 0;
			MarcaCBX.Text = "Seleccione";
			ProveedorCBX.Text = "Seleccione";
			LadoCBX.Text = "Seleccione";
			RubroCBX.Text = "Seleccione";
			UbicacionTXT.Text = "";
			OberservacionesTXT.Text = "";
			Cuadro.Rows.Clear();
			Cuadro2.Rows.Clear();
			productoTXT.Text = "";
			vehiculoCompTXT.Text = "";
		}
		
		
		
		void CrearClick(object sender, EventArgs e)
		{
            try
            {
                String _codigo = Codigotxt.Text;
				String _descripcion = DescripcionTxt.Text;
				double _pesoNominal = double.Parse(PrecioNum.Text);
				int _stockMin = int.Parse(stockMinNum.Text);
				int _stockMax = int.Parse(stockMaxNum.Text);
				int _stockActual = int.Parse(stockActualNum.Text);
				int _aleacionID = (int)MarcaCBX.SelectedValue;
				int _templeID = (int)RubroCBX.SelectedValue;
				int _clasificacionID = (int)LadoCBX.SelectedValue;
				int _clienteID = (int)ProveedorCBX.SelectedValue;

				if (Conexion.ExisteArticulo(_codigo)) { MessageBox.Show("el codigo ingresado ya existe. Ingrese otro."); }
				else
				{

					if ( CodigoProvTXT.Text!="" && numPiezaTXT.Text!="" && _descripcion != "" && _stockMin > 0  && _stockMax > 0 && MarcaCBX.Text != "Seleccione" && RubroCBX.Text != "Seleccione" && LadoCBX.Text != "Seleccione" &&  ProveedorCBX.Text != "Seleccione")
					{

						Conexion.AgregarArticulo(Codigotxt.Text, CodigoProvTXT.Text, numPiezaTXT.Text, DescripcionTxt.Text, PrecioNum.Value, decimal.ToInt32(stockMinNum.Value), decimal.ToInt32(stockMaxNum.Value), decimal.ToInt32(stockActualNum.Value), OberservacionesTXT.Text, (int)MarcaCBX.SelectedValue, (int)RubroCBX.SelectedValue, (int)LadoCBX.SelectedValue, (int)ProveedorCBX.SelectedValue, UbicacionTXT.Text);

						if (Cuadro.Rows.Count > 1)
                        {
							try
							{
								for (int fila = 0; fila < Cuadro.Rows.Count - 1; fila++)
								{
									Conexion.AgregarEquivalencia(Codigotxt.Text,(int)Cuadro.Rows[fila].Cells[1].Value);
								}
							}
							catch (Exception ex) { MessageBox.Show("error al cargar las equivalencias: " + ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error); }
						}


						if (Cuadro2.Rows.Count > 1)
						{
							try
							{
								for (int fila = 0; fila < Cuadro2.Rows.Count - 1; fila++)
								{
									Conexion.AgregarCompatibilidad(Codigotxt.Text, (int)Cuadro2.Rows[fila].Cells[1].Value);
								}
							}
							catch (Exception ex) { MessageBox.Show("error al cargar las equivalencias: " + ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error); }
						}


						limpiar();

					}
					else
					{
						MessageBox.Show("Debe completar todos los campos");
					}
				}
        }
			catch (FormatException fex)
			{
				MessageBox.Show("Datos incorrectos: " + fex.Message);
			}


}

        private void label17_Click(object sender, EventArgs e)
        {

        }

		Articulo equivalencia = null;

        private void BuscarBTN_Click(object sender, EventArgs e)
        {
			equivalencia = Conexion.ObtenerArticulo(productoTXT.Text, this);

            if (equivalencia != null)
            {
				productoTXT.Text = equivalencia.Descripcion;
				codigoEquivalencia.Text = equivalencia.Codigo;	
            }
        }

        private void AgregarBtn_Click(object sender, EventArgs e)
        {
			if (codigoEquivalencia.Text !="")
			{
				int n = Cuadro.Rows.Add();
				Cuadro.Rows[n].Cells[0].Value = false;
				Cuadro.Rows[n].Cells[1].Value = equivalencia.ID;
				Cuadro.Rows[n].Cells[2].Value = equivalencia.Codigo;
				Cuadro.Rows[n].Cells[3].Value = equivalencia.Descripcion;
				Cuadro.Rows[n].Cells[4].Value = equivalencia.NombreProveedor;
			}
			else { MessageBox.Show("Seleccione un artículo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }
		}

		int n;
		private void Cuadro_CellClick(object sender, DataGridViewCellEventArgs e)
        {
			try
			{
				n = e.RowIndex;
				if ((bool)Cuadro.Rows[n].Cells[0].Value == true)
				{
					Cuadro.Rows[n].Cells[0].Value = false;
					Cuadro.Rows[n].DefaultCellStyle.BackColor = Color.White;
				}
				else
				{
					try
					{
						for (int fila = 0; fila < Cuadro.Rows.Count; fila++)
						{
							Cuadro.Rows[fila].Cells[0].Value = false;
							Cuadro.Rows[fila].DefaultCellStyle.BackColor = Color.White;

						}
						Cuadro.CurrentRow.DefaultCellStyle.BackColor = Color.Yellow;
						Cuadro.Rows[n].Cells[0].Value = true;
					}
					catch (Exception) { }
				}
			}

			catch (Exception) { }
		}

        private void QuitarBtn_Click(object sender, EventArgs e)
        {
			try
			{
				bool check = false;
				for (int fila = 0; fila < Cuadro.Rows.Count; fila++)
				{
					if ((bool)Cuadro.Rows[fila].Cells[0].Value == true)
					{
						check = true; break;
					}
				}

				if (check == true)
				{
					Cuadro.Rows.RemoveAt(n);
				}


				else { MessageBox.Show("No hay ningun registro seleccionado"); }
			}
			catch (Exception) { }
		}

        private void productoTXT_TextChanged(object sender, EventArgs e)
        {
			codigoEquivalencia.Text = "";

		}

        private void vehiculoCompTXT_TextChanged(object sender, EventArgs e)
        {
			codCompatibilidad.Text = "";
        }


		Modelo modelo = new Modelo();
        private void button1_Click(object sender, EventArgs e)
        {
			string busqueda = "";
            if (vehiculoCompTXT.Text != null) { busqueda = vehiculoCompTXT.Text; }
			modelo = Conexion.ObtenerModelo(busqueda);

			if (modelo != null)
			{
				vehiculoCompTXT.Text = modelo.Descripcion;
				codCompatibilidad.Text = modelo.ID.ToString();
			}

		}

        private void button3_Click(object sender, EventArgs e)
        {
			if (codCompatibilidad.Text != "")
			{
				int n = Cuadro2.Rows.Add();
				Cuadro2.Rows[n].Cells[0].Value = false;
				Cuadro2.Rows[n].Cells[1].Value = modelo.ID;
				Cuadro2.Rows[n].Cells[2].Value = modelo.Marca;
				Cuadro2.Rows[n].Cells[3].Value = modelo.Descripcion;
				Cuadro2.Rows[n].Cells[4].Value = modelo.Año;
			}
			else { MessageBox.Show("Seleccione un artículo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }

		}




        private void button2_Click(object sender, EventArgs e)
        {
			try
			{
				bool check = false;
				for (int fila = 0; fila < Cuadro2.Rows.Count; fila++)
				{
					if ((bool)Cuadro2.Rows[fila].Cells[0].Value == true)
					{
						check = true; break;
					}
				}

				if (check == true)
				{
					Cuadro2.Rows.RemoveAt(n);
				}


				else { MessageBox.Show("No hay ningun registro seleccionado"); }
			}
			catch (Exception) { }

		}


		int n2;
        private void Cuadro2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
			try
			{
				n2 = e.RowIndex;
				if ((bool)Cuadro2.Rows[n2].Cells[0].Value == true)
				{
					Cuadro2.Rows[n2].Cells[0].Value = false;
					Cuadro2.Rows[n2].DefaultCellStyle.BackColor = Color.White;
				}
				else
				{
					try
					{
						for (int fila = 0; fila < Cuadro2.Rows.Count; fila++)
						{
							Cuadro2.Rows[fila].Cells[0].Value = false;
							Cuadro2.Rows[fila].DefaultCellStyle.BackColor = Color.White;

						}
						Cuadro2.CurrentRow.DefaultCellStyle.BackColor = Color.Yellow;
						Cuadro2.Rows[n2].Cells[0].Value = true;
					}
					catch (Exception) { }
				}
			}

			catch (Exception) { }
		}
    }
}
