using System;
using System.Data;
using System.Windows.Forms;
using System.IO;
using MySql.Data.MySqlClient;
using System.Drawing.Imaging;
using System.Drawing;

namespace Login
{
	public partial class AgregarMatriz : Form
	{
		Articulo articulo = new Articulo();

		public AgregarMatriz() {InitializeComponent();}



		// Carga los Combobox iniciales desde la base de datos
		void AgregarMatrizLoad(object sender, EventArgs e)
		{
			MySqlConnection conectar = Conexion.ObtenerConexion();
			conectar.Open();
			MySqlDataReader reader;
			
			// COMBOBOX CLIENTE
			string consulta5 = "Select ID,Alias From Cliente c order by c.Alias";
			try
			{
				MySqlCommand comand = new MySqlCommand(consulta5, conectar);
				reader = comand.ExecuteReader();
				DataTable dt = new DataTable();
				dt.Load(reader);
				DataRow newRow = dt.NewRow();
				newRow["Alias"] = "Seleccione";
				dt.Rows.InsertAt(newRow, 0);
				ClienteComboBox.DataSource = dt;
				ClienteComboBox.DisplayMember = "Alias";
				ClienteComboBox.ValueMember = "ID";
			}
			catch (MySqlException ex) { MessageBox.Show("Error al buscar " + ex.Message,"Atención",MessageBoxButtons.OK,MessageBoxIcon.Error); }
			finally{conectar.Close();} // Cerramos la conexion a la base de datos

		}




		void CancelarClick(object sender, EventArgs e)
		{this.Close();
		}
		
		
		
		void CrearClick(object sender, EventArgs e)
		{
            try
            {
                String _codigo = Codigotxt.Text;
				String _descripcion = DescripcionTxt.Text;
				double _pesoNominal = double.Parse(PesoActualTxt.Text);
				int _ejemplar = int.Parse(EjemplarTXT.Text);
				int _salidas = int.Parse(SalidasTXT.Text);

				if (!Conexion.ExisteArticulo(_codigo)) { MessageBox.Show("El articulo no existe."); }
				else
				{

					if ( _descripcion != "" && _ejemplar > 0  && _salidas >0 &&  ClienteComboBox.Text != "Seleccione")
					{
						Conexion.AgregarMatriz(_ejemplar, _salidas, _pesoNominal, articulo.ID, (int)ClienteComboBox.SelectedValue);

							//limpiar();
							Codigotxt.Text = "";
							DescripcionTxt.Text = "";
							PesoActualTxt.Value = 0;
							EjemplarTXT.Value = 0;
							SalidasTXT.Value = 0;
							ClienteComboBox.Text = "Seleccione";
							pictureBox1.ImageLocation = null;

  
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

        private void BuscarBTN_Click(object sender, EventArgs e)
        {
			articulo = Conexion.ObtenerArticulo(Codigotxt.Text,this);
			Codigotxt.Text = articulo.Codigo;
			DescripcionTxt.Text = articulo.Descripcion;
			try
			{
				string ruta = "//Rodrigo/imagenes/" + articulo.Codigo + ".bmp";
				byte[] imageBytes = File.ReadAllBytes(ruta);

				//byte[] imageBytes = articulo.RutaImagen;
				MemoryStream buf = new MemoryStream(imageBytes);
				pictureBox1.Image = Image.FromStream(buf);
			}
			catch (Exception) { MessageBox.Show("No se encontro una imagen"); pictureBox1.Image = null; }

		}
    }
}
