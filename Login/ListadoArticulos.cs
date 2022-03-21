using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Data;
using System.Drawing;
using System.IO;

namespace Login
{
	public partial class ListadoArticulos : Form
	{
		
		// Constructor
		public ListadoArticulos(string texto){InitializeComponent();
			BusquedaTXT.Text =texto;
		}
		
		
		//Muestra en el cuadro las coincidencias
		void BuscarClick(object sender, EventArgs e)
		{
			Cuadro.Rows.Clear();
			Cuadro2.Rows.Clear();
			Cuadro3.Rows.Clear();

			MySqlConnection conectar = Conexion.ObtenerConexion();
			DataTable dt = new DataTable();
			conectar.Open();
            try
            {

                MySqlCommand comand = new MySqlCommand("BuscarArticulo", conectar);
				comand.CommandType = CommandType.StoredProcedure;
				comand.Parameters.AddWithValue("@busqueda", BusquedaTXT.Text);
				MySqlDataAdapter adp = new MySqlDataAdapter(comand);
				adp.Fill(dt);


				if (dt.Rows.Count>0)
				{
					foreach (DataRow x in dt.Rows)
					{
						int n = Cuadro.Rows.Add();
						Cuadro.Rows[n].Cells[0].Value = (int)x[0];
						Cuadro.Rows[n].Cells[1].Value = (string)x[1];
						Cuadro.Rows[n].Cells[2].Value = (string)x[2];
						Cuadro.Rows[n].Cells[3].Value = (string)x[3];
						Cuadro.Rows[n].Cells[4].Value = (string)x[4];
						Cuadro.Rows[n].Cells[5].Value = decimal.ToDouble((decimal)x[5]);
						Cuadro.Rows[n].Cells[6].Value = (string)x[28];
						Cuadro.Rows[n].Cells[7].Value = (int)x[6];
						Cuadro.Rows[n].Cells[8].Value = (int)x[7];
						Cuadro.Rows[n].Cells[9].Value = (int)x[8];
						try { Cuadro.Rows[n].Cells[10].Value = (string)x[9]; }
						catch (Exception) { Cuadro.Rows[n].Cells[10].Value = ""; }
						Cuadro.Rows[n].Cells[11].Value = (int)x[10];
						Cuadro.Rows[n].Cells[12].Value = (int)x[11];
						Cuadro.Rows[n].Cells[13].Value = (int)x[12];
						Cuadro.Rows[n].Cells[14].Value = (int)x[13];
						Cuadro.Rows[n].Cells[15].Value = (string)x[14];
						Cuadro.Rows[n].Cells[16].Value = (string)x[17];

					}
			}

			else{MessageBox.Show("No se encontraron registros");}
            }

            catch (MySqlException ex){ MessageBox.Show("Error al buscar seleccion articulo" + ex.Message);}
            finally{ conectar.Close();}

        }



		void Buscar2()
		{
			Cuadro.Rows.Clear();
			Cuadro2.Rows.Clear();
			Cuadro3.Rows.Clear();

			MySqlConnection conectar = Conexion.ObtenerConexion();
			DataTable dt = new DataTable();
			conectar.Open();
			try
			{

				MySqlCommand comand = new MySqlCommand("BuscarArticuloID", conectar);
				comand.CommandType = CommandType.StoredProcedure;
				comand.Parameters.AddWithValue("@busqueda", BusquedaTXT.Text);
				MySqlDataAdapter adp = new MySqlDataAdapter(comand);
				adp.Fill(dt);


				if (dt.Rows.Count > 0)
				{
					foreach (DataRow x in dt.Rows)
					{
						int n = Cuadro.Rows.Add();
						Cuadro.Rows[n].Cells[0].Value = (int)x[0];
						Cuadro.Rows[n].Cells[1].Value = (string)x[1];
						Cuadro.Rows[n].Cells[2].Value = (string)x[2];
						Cuadro.Rows[n].Cells[3].Value = (string)x[3];
						Cuadro.Rows[n].Cells[4].Value = (string)x[4];
						Cuadro.Rows[n].Cells[5].Value = decimal.ToDouble((decimal)x[5]);
						Cuadro.Rows[n].Cells[6].Value = (string)x[28];
						Cuadro.Rows[n].Cells[7].Value = (int)x[6];
						Cuadro.Rows[n].Cells[8].Value = (int)x[7];
						Cuadro.Rows[n].Cells[9].Value = (int)x[8];
						try { Cuadro.Rows[n].Cells[10].Value = (string)x[9]; }
						catch (Exception) { Cuadro.Rows[n].Cells[10].Value = ""; }
						Cuadro.Rows[n].Cells[11].Value = (int)x[10];
						Cuadro.Rows[n].Cells[12].Value = (int)x[11];
						Cuadro.Rows[n].Cells[13].Value = (int)x[12];
						Cuadro.Rows[n].Cells[14].Value = (int)x[13];
						Cuadro.Rows[n].Cells[15].Value = (string)x[14];
						Cuadro.Rows[n].Cells[16].Value = (string)x[17];

					}
				}

				else { MessageBox.Show("No se encontraron registros"); }
			}

			catch (MySqlException ex) { MessageBox.Show("Error al buscar seleccion articulo" + ex.Message); }
			finally { conectar.Close(); }

		}




		// Devuelve el indice de la celda seleccionada
		int n;
		void Selecccioncelda(object sender, DataGridViewCellEventArgs e)
		{
			
			n = e.RowIndex;

			string codigo = (string)Cuadro.Rows[n].Cells[2].Value;
			try
			{
				string ruta = "//Rodrigo/imagenes/" + codigo + ".bmp";
				byte[] imageBytes = File.ReadAllBytes(ruta);
				MemoryStream buf = new MemoryStream(imageBytes);
				pictureBox1.Image = Image.FromStream(buf);
			}
			catch (Exception) { pictureBox1.Image = null; }

			DataTable dt1, dt2;

			try
            {
				int ID  = (int)Cuadro.Rows[n].Cells[0].Value;
				
				dt1 = Conexion.ObtenerEquivalencias(ID);
				Cuadro.Rows.Clear();
				if (dt1 != null)
				{
					foreach (DataRow x in dt1.Rows)
                    {
						int n = Cuadro.Rows.Add();
						Cuadro2.Rows[n].Cells[0].Value = (string)x[0];
						Cuadro2.Rows[n].Cells[1].Value = (string)x[1];
						Cuadro2.Rows[n].Cells[2].Value = (string)x[2];
					}	
				}
			}
            catch (Exception) { }



		}

		
		//Cierra la ventana y escribe la informacion en las propiedades
		void AceptarClick(object sender, EventArgs e){
			
			this.Close();

		}

        private void articuloBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void ListadoArticulos_Load(object sender, EventArgs e)
        {
			//MySqlConnection conectar = Conexion.ObtenerConexion();
			//DataTable dt = new DataTable();
			//conectar.Open();
			//try
			//{
			//	MySqlCommand comand = new MySqlCommand("BuscarArticulo", conectar);
			//	comand.CommandType = CommandType.StoredProcedure;
			//	comand.Parameters.AddWithValue("@busqueda", "");
			//	MySqlDataAdapter adp = new MySqlDataAdapter(comand);
			//	adp.Fill(dt);


			//	if (dt.Rows.Count > 0)
			//	{
			//		foreach (DataRow x in dt.Rows)
			//		{
			//			int n = Cuadro.Rows.Add();
			//			Cuadro.Rows[n].Cells[0].Value = (int)x[0];
			//			Cuadro.Rows[n].Cells[1].Value = (string)x[1];
			//			Cuadro.Rows[n].Cells[2].Value = (string)x[2];
			//			Cuadro.Rows[n].Cells[3].Value = (string)x[3];
			//			Cuadro.Rows[n].Cells[4].Value = (string)x[4];
			//			Cuadro.Rows[n].Cells[5].Value = decimal.ToDouble((decimal)x[5]);
			//			Cuadro.Rows[n].Cells[6].Value = (string)x[28];
			//			Cuadro.Rows[n].Cells[7].Value = (int)x[6];
			//			Cuadro.Rows[n].Cells[8].Value = (int)x[7];
			//			Cuadro.Rows[n].Cells[9].Value = (int)x[8];
			//			try { Cuadro.Rows[n].Cells[10].Value = (string)x[9]; }
			//			catch (Exception) { Cuadro.Rows[n].Cells[10].Value = ""; }
			//			Cuadro.Rows[n].Cells[11].Value = (int)x[10];
			//			Cuadro.Rows[n].Cells[12].Value = (int)x[11];
			//			Cuadro.Rows[n].Cells[13].Value = (int)x[12];
			//			Cuadro.Rows[n].Cells[14].Value = (int)x[13];
			//			Cuadro.Rows[n].Cells[15].Value = (string)x[14];
			//			Cuadro.Rows[n].Cells[16].Value = (string)x[17];

			//		}
			//	}

			//	else { MessageBox.Show("No se encontraron registros"); }
			//}

			//catch (MySqlException ex) { MessageBox.Show("Error al buscar seleccion articulo" + ex.Message); }
			//finally { conectar.Close(); }


		}

        private void VerTodos_Click(object sender, EventArgs e)
        {
			Cuadro.Rows.Clear();
			Cuadro2.Rows.Clear();
			Cuadro3.Rows.Clear();
			MySqlConnection conectar = Conexion.ObtenerConexion();
			DataTable dt = new DataTable();
			conectar.Open();
			try
			{

				MySqlCommand comand = new MySqlCommand("BuscarArticulo", conectar);
				comand.CommandType = CommandType.StoredProcedure;
				comand.Parameters.AddWithValue("@busqueda", "");
				MySqlDataAdapter adp = new MySqlDataAdapter(comand);
				adp.Fill(dt);


				if (dt.Rows.Count > 0)
				{
					foreach (DataRow x in dt.Rows)
					{
						int n = Cuadro.Rows.Add();
						Cuadro.Rows[n].Cells[0].Value = (int)x[0];
						Cuadro.Rows[n].Cells[1].Value = (string)x[1];
						Cuadro.Rows[n].Cells[2].Value = (string)x[2];
						Cuadro.Rows[n].Cells[3].Value = (string)x[3];
						Cuadro.Rows[n].Cells[4].Value = (string)x[4];
						Cuadro.Rows[n].Cells[5].Value = decimal.ToDouble((decimal)x[5]);
						Cuadro.Rows[n].Cells[6].Value = (string)x[28];
						Cuadro.Rows[n].Cells[7].Value = (int)x[6];
						Cuadro.Rows[n].Cells[8].Value = (int)x[7];
						Cuadro.Rows[n].Cells[9].Value = (int)x[8];
						try { Cuadro.Rows[n].Cells[10].Value = (string)x[9]; }
						catch (Exception) { Cuadro.Rows[n].Cells[10].Value = ""; }
						Cuadro.Rows[n].Cells[11].Value = (int)x[10];
						Cuadro.Rows[n].Cells[12].Value = (int)x[11];
						Cuadro.Rows[n].Cells[13].Value = (int)x[12];
						Cuadro.Rows[n].Cells[14].Value = (int)x[13];
						Cuadro.Rows[n].Cells[15].Value = (string)x[14];
						Cuadro.Rows[n].Cells[16].Value = (string)x[17];

					}
				}

				else { MessageBox.Show("No se encontraron registros"); }
			}

			catch (MySqlException ex) { MessageBox.Show("Error al buscar seleccion articulo" + ex.Message); }
			finally { conectar.Close(); }

		}

        private void ExportarBTN_Click(object sender, EventArgs e)
        {
			Exportar.Exportar_Articulos(Cuadro);
		}



        private void Cuadro_CellClick(object sender, DataGridViewCellEventArgs e)
        {
			n = e.RowIndex; 
			try
            {
				string codigo = (string)Cuadro.Rows[n].Cells[2].Value;
				try
				{
					byte[] imageBytes = File.ReadAllBytes(Conexion.rutaImagen(codigo));
					MemoryStream buf = new MemoryStream(imageBytes);
					pictureBox1.Image = Image.FromStream(buf);
				}
				catch (Exception) { pictureBox1.Image = null; }

				DataTable dt1, dt2;

				try
				{
					int ID = (int)Cuadro.Rows[n].Cells[0].Value;

					dt1 = Conexion.ObtenerEquivalencias(ID);

					Cuadro2.Rows.Clear();
					if (dt1 != null)
					{
						foreach (DataRow x in dt1.Rows)
						{
							int n = Cuadro2.Rows.Add();
							Cuadro2.Rows[n].Cells[0].Value = (int)x[0];
							Cuadro2.Rows[n].Cells[1].Value = (string)x[1];
							Cuadro2.Rows[n].Cells[2].Value = (string)x[2];
							Cuadro2.Rows[n].Cells[3].Value = (string)x[3];
						}
					}
				}
				catch (Exception) { }

				try
				{
					int ID2 = (int)Cuadro.Rows[n].Cells[0].Value;
					dt2 = Conexion.ObtenerCompatibilidad(ID2);
					Cuadro3.Rows.Clear();
					if (dt2 != null)
					{
						foreach (DataRow x in dt2.Rows)
						{
							int n = Cuadro3.Rows.Add();
							Cuadro3.Rows[n].Cells[0].Value = (string)x[0];
							Cuadro3.Rows[n].Cells[1].Value = (string)x[1];
							Cuadro3.Rows[n].Cells[2].Value = (int)x[2];
						}
					}
				}
				catch (Exception) { }
			}
            catch (Exception) { }

		}

        private void Cuadro_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
			n = e.RowIndex;
			int id = (int)Cuadro.Rows[n].Cells[0].Value;
			BusquedaTXT.Text = id.ToString();
			Buscar2();
			BusquedaTXT.Text = "";
		}

        private void Cuadro2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
			BusquedaTXT.Text = ((int)Cuadro2.Rows[e.RowIndex].Cells[0].Value).ToString();
			Buscar2();
            BusquedaTXT.Text = "";

		}

        private void Busqueda2_Click(object sender, EventArgs e)
		{
			Cuadro.Rows.Clear();
			Cuadro2.Rows.Clear();
			Cuadro3.Rows.Clear();

			MySqlConnection conectar = Conexion.ObtenerConexion();
			DataTable dt = new DataTable();
			conectar.Open();
			try
			{

				MySqlCommand comand = new MySqlCommand("BuscarArticuloEspecifica", conectar);
				comand.CommandType = CommandType.StoredProcedure;
				comand.Parameters.AddWithValue("@busqueda", BusquedaTXT.Text);
				MySqlDataAdapter adp = new MySqlDataAdapter(comand);
				adp.Fill(dt);


				if (dt.Rows.Count > 0)
				{
					foreach (DataRow x in dt.Rows)
					{
						int n = Cuadro.Rows.Add();
						Cuadro.Rows[n].Cells[0].Value = (int)x[0];
						Cuadro.Rows[n].Cells[1].Value = (string)x[1];
						Cuadro.Rows[n].Cells[2].Value = (string)x[2];
						Cuadro.Rows[n].Cells[3].Value = (string)x[3];
						Cuadro.Rows[n].Cells[4].Value = (string)x[4];
						Cuadro.Rows[n].Cells[5].Value = decimal.ToDouble((decimal)x[5]);
						Cuadro.Rows[n].Cells[6].Value = (string)x[28];
						Cuadro.Rows[n].Cells[7].Value = (int)x[6];
						Cuadro.Rows[n].Cells[8].Value = (int)x[7];
						Cuadro.Rows[n].Cells[9].Value = (int)x[8];
						try { Cuadro.Rows[n].Cells[10].Value = (string)x[9]; }
						catch (Exception) { Cuadro.Rows[n].Cells[10].Value = ""; }
						Cuadro.Rows[n].Cells[11].Value = (int)x[10];
						Cuadro.Rows[n].Cells[12].Value = (int)x[11];
						Cuadro.Rows[n].Cells[13].Value = (int)x[12];
						Cuadro.Rows[n].Cells[14].Value = (int)x[13];
						Cuadro.Rows[n].Cells[15].Value = (string)x[14];
						Cuadro.Rows[n].Cells[16].Value = (string)x[17];

					}
				}

				else { MessageBox.Show("No se encontraron registros"); }
			}

			catch (MySqlException ex) { MessageBox.Show("Error al buscar seleccion articulo" + ex.Message); }
			finally { conectar.Close(); }

		}
    }
}