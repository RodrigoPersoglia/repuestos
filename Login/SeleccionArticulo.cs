using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Data;
using System.IO;
using System.Drawing;

namespace Login
{
	public partial class SeleccionArticulo : Form
	{
		//Declaracion de variables, sirve para vincular con la ventana que las instancia.
		private Articulo articuloSeleccionado = new Articulo();

		
		
		// Constructor
		public SeleccionArticulo(string texto){InitializeComponent();
			Busquedatext.Text =texto;
		}
		
		//Propiedades, solo Get
		public Articulo ArticuloSeleccionado{
			get{return articuloSeleccionado; }
		}



		//Muestra en el cuadro las coincidencias
		void BuscarClick(object sender, EventArgs e)
		{
			Cuadro.Rows.Clear();

			MySqlConnection conectar = Conexion.ObtenerConexion();
			DataTable dt = new DataTable();
			conectar.Open();
            try
            {

                MySqlCommand comand = new MySqlCommand("BuscarArticulo", conectar);
				comand.CommandType = CommandType.StoredProcedure;
				comand.Parameters.AddWithValue("@busqueda", Busquedatext.Text);
				MySqlDataAdapter adp = new MySqlDataAdapter(comand);
				adp.Fill(dt);


				if (dt.Rows.Count>0)
				{
					//Matriz matriz = new Matriz();
					foreach (DataRow x in dt.Rows)
					{
						int n = Cuadro.Rows.Add();
						Cuadro.Rows[n].Cells[0].Value = (int)x[0];
						Cuadro.Rows[n].Cells[1].Value = (string)x[1];
						Cuadro.Rows[n].Cells[2].Value = (string)x[2];
						Cuadro.Rows[n].Cells[3].Value = (string)x[3];
						Cuadro.Rows[n].Cells[4].Value = (string)x[4];
						Cuadro.Rows[n].Cells[5].Value = decimal.ToDouble((decimal)x[5]);
						Cuadro.Rows[n].Cells[6].Value = (int)x[6];
						Cuadro.Rows[n].Cells[7].Value = (int)x[7];
						Cuadro.Rows[n].Cells[8].Value = (int)x[8];
						try { Cuadro.Rows[n].Cells[9].Value = (string)x[9]; }
						catch (Exception) { Cuadro.Rows[n].Cells[9].Value = ""; }
						Cuadro.Rows[n].Cells[10].Value = (int)x[10];
						Cuadro.Rows[n].Cells[11].Value = (int)x[11];
						Cuadro.Rows[n].Cells[12].Value = (int)x[12];
						Cuadro.Rows[n].Cells[13].Value = (int)x[13];
						Cuadro.Rows[n].Cells[14].Value = (string)x[14];
						Cuadro.Rows[n].Cells[15].Value = (string)x[19];

					}
			}

			else{MessageBox.Show("No se encontraron registros");}
            }

            catch (MySqlException ex){ MessageBox.Show("Error al buscar seleccion articulo" + ex.Message);}
            finally{ conectar.Close();}

        }
		
	
		
		
		// Devuelve el indice de la celda seleccionada
		int n;
		void Selecccioncelda(object sender, DataGridViewCellEventArgs e)
		{n = e.RowIndex;
			string codigo = (string)Cuadro.Rows[n].Cells[2].Value;
			try
			{

				byte[] imageBytes = File.ReadAllBytes(Conexion.rutaImagen(codigo)) ;
				MemoryStream buf = new MemoryStream(imageBytes);
				pictureBox1.Image = Image.FromStream(buf);
			}
			catch (Exception) { pictureBox1.Image = null; }

		}

		
		//Cierra la ventana y escribe la informacion en las propiedades
		void AceptarClick(object sender, EventArgs e){
			ArticuloSeleccionado.ID = int.Parse(Cuadro.Rows[n].Cells[0].Value.ToString());
			ArticuloSeleccionado.Codigo = Cuadro.Rows[n].Cells[1].Value.ToString();
			ArticuloSeleccionado.CodigoProveedor = Cuadro.Rows[n].Cells[2].Value.ToString();
			ArticuloSeleccionado.NumeroPieza = Cuadro.Rows[n].Cells[3].Value.ToString();
			ArticuloSeleccionado.Descripcion = Cuadro.Rows[n].Cells[4].Value.ToString();
			ArticuloSeleccionado.Precio = Double.Parse(Cuadro.Rows[n].Cells[5].Value.ToString());
			ArticuloSeleccionado.StockMin = int.Parse(Cuadro.Rows[n].Cells[6].Value.ToString());
			ArticuloSeleccionado.StockMax = int.Parse(Cuadro.Rows[n].Cells[7].Value.ToString());
			ArticuloSeleccionado.StockActual = int.Parse(Cuadro.Rows[n].Cells[8].Value.ToString());
			ArticuloSeleccionado.Observaciones = Cuadro.Rows[n].Cells[9].Value.ToString();
			ArticuloSeleccionado.Marca = int.Parse(Cuadro.Rows[n].Cells[10].Value.ToString());
			ArticuloSeleccionado.Rubro = int.Parse(Cuadro.Rows[n].Cells[11].Value.ToString());
			ArticuloSeleccionado.Lado = int.Parse(Cuadro.Rows[n].Cells[12].Value.ToString());
			ArticuloSeleccionado.Proveedor = int.Parse(Cuadro.Rows[n].Cells[13].Value.ToString());
			ArticuloSeleccionado.Ubicacion = Cuadro.Rows[n].Cells[14].Value.ToString();
            ArticuloSeleccionado.NombreProveedor = Cuadro.Rows[n].Cells[15].Value.ToString();

            this.Close();

		}

        private void articuloBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void SeleccionArticulo_Load(object sender, EventArgs e)
        {
			MySqlConnection conectar = Conexion.ObtenerConexion();
			DataTable dt = new DataTable();
			conectar.Open();
			try
			{

				MySqlCommand comand = new MySqlCommand("BuscarArticulo", conectar);
				comand.CommandType = CommandType.StoredProcedure;
				comand.Parameters.AddWithValue("@busqueda", Busquedatext.Text);
				MySqlDataAdapter adp = new MySqlDataAdapter(comand);
				adp.Fill(dt);


				if (dt.Rows.Count > 0)
				{
					Matriz matriz = new Matriz();
					foreach (DataRow x in dt.Rows)
					{
						int n = Cuadro.Rows.Add();
						Cuadro.Rows[n].Cells[0].Value = (int)x[0];
						Cuadro.Rows[n].Cells[1].Value = (string)x[1];
						Cuadro.Rows[n].Cells[2].Value = (string)x[2];
						Cuadro.Rows[n].Cells[3].Value = (string)x[3];
						Cuadro.Rows[n].Cells[4].Value = (string)x[4];
						Cuadro.Rows[n].Cells[5].Value = decimal.ToDouble((decimal)x[5]);
						Cuadro.Rows[n].Cells[6].Value = (int)x[6];
						Cuadro.Rows[n].Cells[7].Value = (int)x[7];
						Cuadro.Rows[n].Cells[8].Value = (int)x[8]; 
						try { Cuadro.Rows[n].Cells[9].Value = (string)x[9];}
                        catch (Exception) { Cuadro.Rows[n].Cells[9].Value = ""; }
						Cuadro.Rows[n].Cells[10].Value = (int)x[10];
						Cuadro.Rows[n].Cells[11].Value = (int)x[11];
						Cuadro.Rows[n].Cells[12].Value = (int)x[12];
						Cuadro.Rows[n].Cells[13].Value = (int)x[13];
						Cuadro.Rows[n].Cells[14].Value = (string)x[14];
                        Cuadro.Rows[n].Cells[15].Value = (string)x[19];

                    }
                }

				else { MessageBox.Show("No se encontraron registros"); }
			}

			catch (MySqlException ex) { MessageBox.Show("Error al buscar seleccion articulo" + ex.Message); }
			finally { conectar.Close(); }


		}
	}
}