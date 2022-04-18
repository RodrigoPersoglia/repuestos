using System;
using System.Data;
using System.Windows.Forms;
using System.IO;
using MySql.Data.MySqlClient;
using System.Drawing.Imaging;
using System.Drawing;

namespace Login
{
	public partial class ModificarMatriz : Form
	{
		Articulo articulo = new Articulo();

		public ModificarMatriz() {InitializeComponent();}



		// Carga los Combobox iniciales desde la base de datos
		void ModificarMatrizLoad(object sender, EventArgs e)
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

			// COMBOBOX ESTADO MATRIZ
			string consulta6 = "Select ID,estado From estadoMatriz e order by e.estado";
			try
			{
				MySqlCommand comand = new MySqlCommand(consulta6, conectar);
				reader = comand.ExecuteReader();
				DataTable dt = new DataTable();
				dt.Load(reader);
				DataRow newRow = dt.NewRow();
				newRow["estado"] = "Seleccione";
				dt.Rows.InsertAt(newRow, 0);
				Estado_ComboBox.DataSource = dt;
				Estado_ComboBox.DisplayMember = "estado";
				Estado_ComboBox.ValueMember = "ID";
			}
			catch (MySqlException ex) { MessageBox.Show("Error al buscar " + ex.Message,"Atención",MessageBoxButtons.OK,MessageBoxIcon.Error); }
			finally {conectar.Close();} // Cerramos la conexion a la base de datos

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
				double _pesoNominal = double.Parse(PesoActual.Text);
				int _salidas = int.Parse(SalidasTXT.Text);

				if (!Conexion.ExisteArticulo(_codigo)) { MessageBox.Show("El articulo no existe."); }
				else
				{

					if ( _descripcion != "" && _salidas >0 &&  ClienteComboBox.Text != "Seleccione" && Estado_ComboBox.Text != "Seleccione" && KgAcumuladosTXT.ForeColor!=Color.Red)
					{
						Conexion.ModificarMatriz((int)Ejemplar_ComboBox.SelectedValue, _salidas, _pesoNominal,(int)ClienteComboBox.SelectedValue,(int)Estado_ComboBox.SelectedValue, int.Parse(KgAcumuladosTXT.Text), int.Parse(KgAcumulados2TBX.Text) , ControladaCKB.Checked);

							//limpiar();
							Codigotxt.Text = "";
							DescripcionTxt.Text = "";
							PesoActual.Value = 0;
							SalidasTXT.Value = 0;
						    KgAcumuladosTXT.Text = "0";
							MetrosTXT.Text = "0";
							KgAcumulados2TBX.Text = "0";
							Metros2TBX.Text = "0";
							ClienteComboBox.Text = "Seleccione";
							pictureBox1.ImageLocation = null;

  
                    }
					else
					{
						MessageBox.Show("Revise los campos ingresados","Atención",MessageBoxButtons.OK,MessageBoxIcon.Warning);
					}
				}
        }
			catch (FormatException fex)
			{
				MessageBox.Show("Datos incorrectos: " + fex.Message,"Atención", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
			ClienteComboBox.Text = "Seleccione";

			//Limpio el comboBox de ejemplar y cargo los datos nuevos
			Ejemplar_ComboBox.DataSource = null;
			Ejemplar_ComboBox.Items.Clear();
			MySqlConnection conectar = Conexion.ObtenerConexion();
			conectar.Open();
			DataTable dt = new DataTable();
			try
			{
				MySqlCommand comand = new MySqlCommand(" obtenerejemplar", conectar);
				comand.CommandType = CommandType.StoredProcedure;
				comand.Parameters.AddWithValue("@parametro", articulo.ID.ToString());
				MySqlDataAdapter adp = new MySqlDataAdapter(comand);
				adp.Fill(dt);
				DataRow newRow = dt.NewRow();
				newRow["ejemplar"] = "Seleccione";
				dt.Rows.InsertAt(newRow, 0);
				Ejemplar_ComboBox.DataSource = dt;
				Ejemplar_ComboBox.DisplayMember = "ejemplar";
				Ejemplar_ComboBox.ValueMember = "ID";
			}
			catch (MySqlException ex) { MessageBox.Show("Error al buscar " + ex.Message,"Atención",MessageBoxButtons.OK,MessageBoxIcon.Error); }
			finally { conectar.Close(); }

		}

        private void Codigotxt_TextChanged(object sender, EventArgs e)
        {
			DescripcionTxt.Text = "";
			SalidasTXT.Value = 0;
			PesoActual.Value = 0;
			MetrosTXT.Text = "0";
			KgAcumuladosTXT.Text = "0";
			ClienteComboBox.Text = "Seleccione";
			Estado_ComboBox.Text = "Seleccione";
			Ejemplar_ComboBox.DataSource = null;
			Ejemplar_ComboBox.Items.Clear();
			matrizEjemplar = null;


		}
		Matriz matrizEjemplar;

		private void Ejemplar_ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {


		}

        private void Ejemplar_ComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                matrizEjemplar = Conexion.ObtenerMatriz((int)Ejemplar_ComboBox.SelectedValue);
			if (matrizEjemplar != null)
			{
					
				SalidasTXT.Value = matrizEjemplar.Salidas;
				PesoActual.Value = (decimal)matrizEjemplar.Peso;
				ClienteComboBox.SelectedValue = matrizEjemplar.Propietario;
				Estado_ComboBox.Text = matrizEjemplar.Estado;
					KgAcumuladosTXT.Text = matrizEjemplar.KgAcumulados.ToString();
					try { MetrosTXT.Text = (Math.Round(Double.Parse(KgAcumuladosTXT.Text) / decimal.ToDouble(PesoActual.Value),2)).ToString(); }
					catch (Exception) { }
					KgAcumulados2TBX.Text = matrizEjemplar.KgAcumulados2.ToString();
					try { Metros2TBX.Text = (Math.Round(Double.Parse(KgAcumulados2TBX.Text) / decimal.ToDouble(PesoActual.Value), 2)).ToString(); }
					catch (Exception) { }

					ControladaCKB.Checked = matrizEjemplar.Controlada;
				
			}



        }
			catch (Exception){
				SalidasTXT.Value = 0;
				PesoActual.Value = 0;
				ClienteComboBox.Text = "Seleccione";
				Estado_ComboBox.Text = "Seleccione";
				MetrosTXT.Text = "0";
			}
}

        private void KgAcumuladosTXT_TextChanged(object sender, EventArgs e)
        {
			//Controla que el texto ingresado sea un INT, sino cambia el color de la fuente a Rojo
			int numero;
			try
			{
				numero = int.Parse(KgAcumuladosTXT.Text);
				KgAcumuladosTXT.ForeColor = System.Drawing.Color.Black;
			}
			catch (Exception) { KgAcumuladosTXT.ForeColor = System.Drawing.Color.Red; }
		}
    }
}
