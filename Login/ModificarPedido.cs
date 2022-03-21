using System;
using System.Data;
using System.Windows.Forms;
using System.IO;
using MySql.Data.MySqlClient;
using System.Drawing;
using System.Drawing.Printing;
namespace Login
{
	public partial class ModificarPedido : Form
	{
		int celdaSeleccionada; // variables
		double kgsEstimados = 0;
		Articulo articuloPedido = new Articulo();
		Matriz matriz = new Matriz();
		double largoOK = 0;

		public ModificarPedido() { InitializeComponent(); } // Constructor
		public ModificarPedido(string numeroPedido) // Constructor2
		{ 
			InitializeComponent();
			NumeroTxt.Text = numeroPedido;

		} 

		void ModificarPedidoLoad(object sender, EventArgs e) // Carga los Combobox iniciales desde la base de datos. EVENTO LOAD
		{
			Fecha.Value = DateTime.Today;
			MySqlConnection conectar = Conexion.ObtenerConexion();
			MySqlDataReader reader;
			conectar.Open();

			// COMBOBOX UNIDAD
			string consulta2 = "Select ID,descripcion From Unidad u order by u.descripcion";
			try
			{
				MySqlCommand comand = new MySqlCommand(consulta2, conectar);
				reader = comand.ExecuteReader();
				DataTable dt = new DataTable();
				dt.Load(reader);
				DataRow newRow = dt.NewRow();
				newRow["descripcion"] = "Seleccione";
				dt.Rows.InsertAt(newRow, 0);
				UnidadComboBox.DataSource = dt;
				UnidadComboBox.DisplayMember = "descripcion";
				UnidadComboBox.ValueMember = "ID";
			}
			catch (MySqlException ex) { MessageBox.Show("Error al buscar " + ex.Message,"Atención",MessageBoxButtons.OK,MessageBoxIcon.Error); }

			// COMBOBOX TERMINACION
			string consulta3 = "Select ID,descripcion From Terminacion t order by t.descripcion ";
			try
			{
				MySqlCommand comand = new MySqlCommand(consulta3, conectar);
				reader = comand.ExecuteReader();
				DataTable dt = new DataTable();
				dt.Load(reader);
				DataRow newRow = dt.NewRow();
				newRow["descripcion"] = "Seleccione";
				dt.Rows.InsertAt(newRow, 0);
				TerminacionComboBox.DataSource = dt;
				TerminacionComboBox.DisplayMember = "descripcion";
				TerminacionComboBox.ValueMember = "ID";
			}
			catch (MySqlException ex) { MessageBox.Show("Error al buscar " + ex.Message,"Atención",MessageBoxButtons.OK,MessageBoxIcon.Error); }

			// COMBOBOX PRIORIDAD
			string consulta4 = "Select ID,descripcion From Prioridad p order by p.descripcion";
			try
			{
				MySqlCommand comand = new MySqlCommand(consulta4, conectar);
				reader = comand.ExecuteReader();
				DataTable dt = new DataTable();
				dt.Load(reader);
				DataRow newRow = dt.NewRow();
				newRow["descripcion"] = "Seleccione";
				dt.Rows.InsertAt(newRow, 0);
				PrioridadComboBox.DataSource = dt;
				PrioridadComboBox.DisplayMember = "descripcion";
				PrioridadComboBox.ValueMember = "ID";
			}
			catch (MySqlException ex) { MessageBox.Show("Error al buscar " + ex.Message,"Atención",MessageBoxButtons.OK,MessageBoxIcon.Error); }

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

			// COMBOBOX ALEACION
			string consulta6 = "Select ID,descripcion From Aleacion p order by p.descripcion";
			try
			{
				MySqlCommand comand = new MySqlCommand(consulta6, conectar);
				reader = comand.ExecuteReader();
				DataTable dt = new DataTable();
				dt.Load(reader);
				DataRow newRow = dt.NewRow();
				newRow["descripcion"] = "Seleccione";
				dt.Rows.InsertAt(newRow, 0);
				AleacionComboBox.DataSource = dt;
				AleacionComboBox.DisplayMember = "descripcion";
				AleacionComboBox.ValueMember = "ID";
			}
			catch (MySqlException ex) { MessageBox.Show("Error al buscar " + ex.Message,"Atención",MessageBoxButtons.OK,MessageBoxIcon.Error); }

			// COMBOBOX CLIENTE
			string consulta7 = "Select ID,descripcion From Temple p order by p.descripcion";
			try
			{
				MySqlCommand comand = new MySqlCommand(consulta7, conectar);
				reader = comand.ExecuteReader();
				DataTable dt = new DataTable();
				dt.Load(reader);
				DataRow newRow = dt.NewRow();
				newRow["descripcion"] = "Seleccione";
				dt.Rows.InsertAt(newRow, 0);
				TemplecomboBox.DataSource = dt;
				TemplecomboBox.DisplayMember = "descripcion";
				TemplecomboBox.ValueMember = "ID";
			}
			catch (MySqlException ex) { MessageBox.Show("Error al buscar " + ex.Message,"Atención",MessageBoxButtons.OK,MessageBoxIcon.Error); }
			finally { conectar.Close(); } // Cerramos la conexion a la base de datos

            if (NumeroTxt.Text != "")
            {
				try
				{
					Pedido pedido = Conexion.ObtenerPedido(NumeroTxt.Text);
					if (pedido != null)
					{
						NumeroTxt.Text = pedido.Numero.ToString();
						Fecha.Value = pedido.Fecha;
						IDPedido.Text = pedido.ID.ToString();
						articuloPedido = Conexion.ObtenerArticulo(pedido.Codigo_Articulo,this);
						PerfilTxt.Text = articuloPedido.Codigo;
						IDtxt.Text = articuloPedido.ID.ToString();
						DescripcionTxt.Text = articuloPedido.Descripcion;

						matriz = Conexion.ObtenerMatriz(pedido.Matriz);
						try
						{
							string ruta = "//Rodrigo/imagenes/" + articuloPedido.Codigo + ".bmp";
							byte[] imageBytes = File.ReadAllBytes(ruta);
							MemoryStream buf = new MemoryStream(imageBytes);
							pictureBox1.Image = Image.FromStream(buf);
						}
						catch (Exception) { MessageBox.Show("No se encontro una imagen"); pictureBox1.Image = null; }

						ClienteComboBox.Text = pedido.Cliente;
						UnidadComboBox.Text = pedido.Unidad;
						TerminacionComboBox.Text = pedido.Terminacion;
						PrioridadComboBox.Text = pedido.Prioridad;
						OCTxt.Text = pedido.OrdenCompra;
						ObservacionesTxt.Text = pedido.Observaciones;
						TemplecomboBox.Text = pedido.Temple;
						AleacionComboBox.Text = pedido.Aleacion;



						//completo el cuadro
						DataTable dt = Conexion.ObtenerDetallepedido(NumeroTxt.Text); // obtengo el detalle del pedido
						dataGridView1.Rows.Clear();
						foreach (DataRow x in dt.Rows)
						{
							pedido.ID = (int)x[0];
							int n = dataGridView1.Rows.Add();
							dataGridView1.Rows[n].Cells[0].Value = (int)x[1];
							dataGridView1.Rows[n].Cells[1].Value = (int)x[2];
							double longitud = (int)x[2];
							if (longitud > largoOK)
							{

								largoOK = longitud;

							}

							if (x[4] != null)
							{
								decimal y = (decimal)(x[4]);
								dataGridView1.Rows[n].Cells[2].Value = decimal.ToDouble(y);
							}

						}

						try
						{
							matrizComboBox.DataSource = null;
							matrizComboBox.Items.Clear();
							DataTable dt2 = Conexion.VerMatriz(articuloPedido.Codigo);
							if (dt != null)
							{
								DataRow newRow = dt.NewRow();
								matrizComboBox.DataSource = dt2;
								matrizComboBox.DisplayMember = "matriz";
								matrizComboBox.ValueMember = "ID";
								matrizComboBox.SelectedValue = matriz.ID;
							}
						}
						catch (Exception) { }
					}
					else
					{
						//Limpiamos los datos de la insercion realizada
						IDtxt.Text = "";
						DescripcionTxt.Text = "";
						AleacionComboBox.Text = "Seleccione";
						TemplecomboBox.Text = "Seleccione";
						PerfilTxt.Text = "";
						ClienteComboBox.Text = "Seleccione";
						UnidadComboBox.Text = "Seleccione";
						TerminacionComboBox.Text = "Seleccione";
						PrioridadComboBox.Text = "Seleccione";
						OCTxt.Text = "";
						ObservacionesTxt.Text = "";
						pictureBox1.Image = null;
						dataGridView1.Rows.Clear();

					}



				}
				catch (Exception ex) { MessageBox.Show("Error: " + ex.Message); }

			}

		}



		void CancelarClick(object sender, EventArgs e) //Cierra la ventana
		{ this.Close(); }


		void CrearClick(object sender, EventArgs e) // VER  Modifica el pedido en la base de datos
		{
            try
            {


                kgsEstimados = 0;
				//Tomamos los datos geniunos a ingresar a la base de datos
				for (int fila = 0; fila < dataGridView1.Rows.Count - 1; fila++)
				{
					
					kgsEstimados += (double)dataGridView1.Rows[fila].Cells[2].Value;
				}
				

				int _idPedido = int.Parse(IDPedido.Text);
				int _numero = int.Parse(NumeroTxt.Text);
				DateTime _fecha2 = Fecha.Value;
				string _fecha = _fecha2.ToString("yyyy-MM-dd"); // Casteo de fecha al formato de la base de datos
				string _oc = OCTxt.Text;
				string _observaciones = ObservacionesTxt.Text;
				//Tomamos los datos con valores de Fk desde los combobox.
				int _clienteID = (int)ClienteComboBox.SelectedValue;
				int _articuloID = int.Parse(IDtxt.Text);
				int _unidadID = (int)UnidadComboBox.SelectedValue;
				int _terminacionID = (int)TerminacionComboBox.SelectedValue;
				int _PrioridadID = (int)PrioridadComboBox.SelectedValue;
				int _aleacionID = (int)AleacionComboBox.SelectedValue;
				int _templeID = (int)TemplecomboBox.SelectedValue;

				if (dataGridView1.Rows.Count>1 && _fecha != null && AleacionComboBox.Text != "Seleccione" && UnidadComboBox.Text != "Seleccione" && TerminacionComboBox.Text != "Seleccione" && PrioridadComboBox.Text != "Seleccione" && ClienteComboBox.Text != "Seleccione" && _articuloID != 0 && TemplecomboBox.Text != "Seleccione") {
					//Establecemos la conexión
					MySqlConnection conexionBD = Conexion.ObtenerConexion();
					conexionBD.Open();
					 
					try
					{
						MySqlCommand comando = new MySqlCommand("ModificarPedido", conexionBD);
						comando.CommandType = CommandType.StoredProcedure;
						comando.Parameters.AddWithValue("@p1", _idPedido);
						comando.Parameters.AddWithValue("@p2", _numero);
						comando.Parameters.AddWithValue("@p3", _fecha2);
						comando.Parameters.AddWithValue("@p4", kgsEstimados);
						comando.Parameters.AddWithValue("@p5", _oc);
						comando.Parameters.AddWithValue("@p6", _observaciones);
						comando.Parameters.AddWithValue("@p7", _clienteID);
						comando.Parameters.AddWithValue("@p8", _articuloID);
						comando.Parameters.AddWithValue("@p9", _unidadID);
						comando.Parameters.AddWithValue("@p10", _terminacionID);
						comando.Parameters.AddWithValue("@p11", _PrioridadID);
						comando.Parameters.AddWithValue("@p12", _aleacionID);
						comando.Parameters.AddWithValue("@p13", _templeID);
						comando.Parameters.AddWithValue("@p14", matriz.ID);
						comando.ExecuteNonQuery();

					}

					catch (Exception ex) { MessageBox.Show("Error al guardar: " + ex.Message); }

					finally { conexionBD.Close(); }

					//Elimino el detalle anterior y lo reemplazo por el nuevo
					Conexion.EliminarDetalle(IDPedido.Text);
					MySqlConnection conexionBD2 = Conexion.ObtenerConexion();
					conexionBD2.Open();
					try
					{
						for (int fila = 0; fila < dataGridView1.Rows.Count - 1; fila++)
						{
							string sql3 = "Insert into pedidoDetalle (cantidad,largo,Pedido_ID,kgEstimados) VALUES ('" + dataGridView1.Rows[fila].Cells[0].Value + "', '" + dataGridView1.Rows[fila].Cells[1].Value + "', '" + _idPedido + "', '" + dataGridView1.Rows[fila].Cells[2].Value + "')";
							MySqlCommand comando2 = new MySqlCommand(sql3, conexionBD2);
							comando2.ExecuteNonQuery();
						}
					}
					catch (Exception ex) { MessageBox.Show("error pedido detalle: " + ex.Message); }
					finally { conexionBD2.Close(); }

					MessageBox.Show("Registro guardado");

					if (checkImprimir.Checked == true)
					{
                        try
                        {
                            printDocument1 = new PrintDocument();
							PrinterSettings ps = new PrinterSettings();
							PaperSize A4 = new PaperSize();
							A4.RawKind = (int)PaperKind.A4;
							ps.DefaultPageSettings.PaperSize = A4;
							ps.DefaultPageSettings.Landscape = true;
							printDocument1.PrinterSettings = ps;
							printDocument1.PrintPage += imprimir2;
							printDocument1.Print();
                        }

                        catch (Exception) { MessageBox.Show("No se pudo imprimir el pedido"); }

                    }

					//Limpiamos los datos de la insercion realizada
					IDtxt.Text = "";
					DescripcionTxt.Text = "";
					AleacionComboBox.Text = "Seleccione";
					TemplecomboBox.Text = "Seleccione";
					PerfilTxt.Text = "";
					ClienteComboBox.Text = "Seleccione";
					UnidadComboBox.Text = "Seleccione";
					TerminacionComboBox.Text = "Seleccione";
					PrioridadComboBox.Text = "Seleccione";
					OCTxt.Text = "";
					ObservacionesTxt.Text = "";
					pictureBox1.Image = null;



				}
				else { MessageBox.Show("Debe completar todos los campos"); }

            }
            catch (Exception fex) { MessageBox.Show("Datos incorrectos: " + fex.Message); }
        }


		private void BuscarBtn_Click(object sender, EventArgs e) // Buscamos un articulo y mostramos sus propiedades
		{
			articuloPedido = Conexion.ObtenerArticulo(PerfilTxt.Text,this);
			PerfilTxt.Text = articuloPedido.Codigo;
			ClienteComboBox.Text = articuloPedido.Cliente;
			DescripcionTxt.Text = articuloPedido.Descripcion;
			IDtxt.Text = articuloPedido.ID.ToString();
			AleacionComboBox.Text = articuloPedido.Aleacion;
			TemplecomboBox.Text = articuloPedido.Temple;
			
			try
			{
				matrizComboBox.DataSource = null;
				matrizComboBox.Items.Clear();
				DataTable dt = Conexion.VerMatriz(articuloPedido.Codigo);
				if (dt != null)
				{
					DataRow newRow = dt.NewRow();
					matrizComboBox.DataSource = dt;
					matrizComboBox.DisplayMember = "matriz";
					matrizComboBox.ValueMember = "ID";
				}
			}
			catch (Exception) { }
			// Si el articulo tiene imagen en la base de datos la mostramos, sino mensaje de error e imagen nula
			try {
				string ruta = "//Rodrigo/imagenes/" + articuloPedido.Codigo + ".bmp";
				byte[] imageBytes = File.ReadAllBytes(ruta);
				MemoryStream buf = new MemoryStream(imageBytes);
				pictureBox1.Image = Image.FromStream(buf);
			}
			catch (Exception) { MessageBox.Show("No se encontro una imagen"); pictureBox1.Image = null; }
		}


		void Selecccioncelda(object sender, DataGridViewCellEventArgs e) // Devuelve el indice de la celda seleccionada
		{ celdaSeleccionada = e.RowIndex; }


        private void AgrgarBtn_Click(object sender, EventArgs e) // Agrega una nueva fila al cuadro
        {
			try
			{
				if (dataGridView1.Rows.Count < 9)
				{
					if (UnidadComboBox.Text == "Seleccione" || DescripcionTxt.Text == "" || DescripcionTxt.Text == null || matrizComboBox.Text == "Seleccione" || matrizComboBox.SelectedValue == null) { MessageBox.Show("Complete el campos unidad, seleccione un articulo y una matriz", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
				else
				{
					int id = (int)matrizComboBox.SelectedValue;
					matriz = Conexion.ObtenerMatriz(id);

					if (LargoNumeric.Value > 0 && CantidadNumeric.Value > 0)
					{
						if (decimal.ToDouble(LargoNumeric.Value) > largoOK)
						{
							largoOK = decimal.ToDouble(LargoNumeric.Value);

						}

						//Adicionamos un nuevo renglon
						int n = dataGridView1.Rows.Add();
						dataGridView1.Rows[n].Cells[0].Value = CantidadNumeric.Value;
						dataGridView1.Rows[n].Cells[1].Value = LargoNumeric.Value;
						if ((int)UnidadComboBox.SelectedValue == 1) { dataGridView1.Rows[n].Cells[2].Value = (double)CantidadNumeric.Value; kgsEstimados += (double)CantidadNumeric.Value; }
						else
						{

							double num = 0;
							num = decimal.ToDouble(CantidadNumeric.Value) * decimal.ToDouble(LargoNumeric.Value / 1000) * matriz.Peso;
							kgsEstimados += num;
							dataGridView1.Rows[n].Cells[2].Value = num;

						}
						//Ponemos en cero 
						LargoNumeric.Value = 0; CantidadNumeric.Value = 0;


					}
					else { MessageBox.Show("Revise los campos ingresados", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }
			}
				}

				else { MessageBox.Show("No se pueden ingresar mas de 8 registros", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
			}
			catch (Exception ex) { MessageBox.Show("Error: " + ex.Message); }
		}


        private void QuitarBtn_Click(object sender, EventArgs e) // Quita la fila seleccionada al cuadro
		{
			try
			{
				if (celdaSeleccionada> -1)
				{
					double num = 0;
					num = (double)dataGridView1.Rows[celdaSeleccionada].Cells[2].Value;
					kgsEstimados -= num;
					dataGridView1.Rows.RemoveAt(celdaSeleccionada);
				}
			}

			catch (Exception) { MessageBox.Show("Acción Invalida", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
		} 


        private void CambiaUnidad(object sender, EventArgs e) // Si se cambia de unidad limpiamos el cuadro
        {
			dataGridView1.Rows.Clear();
			kgsEstimados = 0;
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Font fuente = new Font("Arial",12,FontStyle.Regular);
			//e.Graphics.DrawRectangle(10, 20);
			e.Graphics.DrawString("hola mundo", fuente, Brushes.Black, 20, 20);
			//pd.DefaultPageSettings.Landscape = true;

			e.PageSettings.Landscape = false;
			

		}

        private void ImprimirBtn_Click(object sender, EventArgs e)
        {
			printPreviewDialog1.ShowDialog();
        }

        private void BuscarPedBTN_Click(object sender, EventArgs e)
        {

            try
            {
                Pedido pedido = Conexion.ObtenerPedido(NumeroTxt.Text);
				if (pedido != null)
				{
					NumeroTxt.Text = pedido.Numero.ToString();
					Fecha.Value = pedido.Fecha;
					IDPedido.Text = pedido.ID.ToString();
					articuloPedido = Conexion.ObtenerArticulo(pedido.Codigo_Articulo,this);
					PerfilTxt.Text = articuloPedido.Codigo;
					IDtxt.Text = articuloPedido.ID.ToString();
					DescripcionTxt.Text = articuloPedido.Descripcion;

					matriz = Conexion.ObtenerMatriz(pedido.Matriz);
					try
					{
						string ruta = "//Rodrigo/imagenes/" + articuloPedido.Codigo + ".bmp";
						byte[] imageBytes = File.ReadAllBytes(ruta);
						MemoryStream buf = new MemoryStream(imageBytes);
						pictureBox1.Image = Image.FromStream(buf);
					}
					catch (Exception) { MessageBox.Show("No se encontro una imagen"); pictureBox1.Image = null; }

					ClienteComboBox.Text = pedido.Cliente;
					UnidadComboBox.Text = pedido.Unidad;
					TerminacionComboBox.Text = pedido.Terminacion;
					PrioridadComboBox.Text = pedido.Prioridad;
					OCTxt.Text = pedido.OrdenCompra;
					ObservacionesTxt.Text = pedido.Observaciones;
					TemplecomboBox.Text = pedido.Temple;
					AleacionComboBox.Text = pedido.Aleacion;



					//completo el cuadro
					DataTable dt = Conexion.ObtenerDetallepedido(NumeroTxt.Text); // obtengo el detalle del pedido
					dataGridView1.Rows.Clear();
					foreach (DataRow x in dt.Rows)
					{
						pedido.ID = (int)x[0];
						int n = dataGridView1.Rows.Add();
						dataGridView1.Rows[n].Cells[0].Value = (int)x[1];
						dataGridView1.Rows[n].Cells[1].Value = (int)x[2];
					double longitud = (int)x[2];
					if (longitud > largoOK)
						{
						
							largoOK = longitud;

						}

						if (x[4] != null)
						{
							decimal y = (decimal)(x[4]);
							dataGridView1.Rows[n].Cells[2].Value = decimal.ToDouble(y);
						}

					}

					try
					{
						matrizComboBox.DataSource = null;
						matrizComboBox.Items.Clear();
						DataTable dt2 = Conexion.VerMatriz(articuloPedido.Codigo);
						if (dt != null)
						{
							DataRow newRow = dt.NewRow();
							matrizComboBox.DataSource = dt2;
							matrizComboBox.DisplayMember = "matriz";
							matrizComboBox.ValueMember = "ID";
							matrizComboBox.SelectedValue = matriz.ID;
						}
					}
					catch (Exception) { }
				}
                else
                {
					//Limpiamos los datos de la insercion realizada
					IDtxt.Text = "";
					DescripcionTxt.Text = "";
					AleacionComboBox.Text = "Seleccione";
					TemplecomboBox.Text = "Seleccione";
					PerfilTxt.Text = "";
					ClienteComboBox.Text = "Seleccione";
					UnidadComboBox.Text = "Seleccione";
					TerminacionComboBox.Text = "Seleccione";
					PrioridadComboBox.Text = "Seleccione";
					OCTxt.Text = "";
					ObservacionesTxt.Text = "";
					pictureBox1.Image = null;
					dataGridView1.Rows.Clear();

				}



        }
			catch (Exception ex) { MessageBox.Show("Error: "+ex.Message); }

}

        private void button1_Click(object sender, EventArgs e)
        {
			Conexion.EliminarDetalle(IDPedido.Text);
		}

        private void matrizComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
			int id = (int)matrizComboBox.SelectedValue;
			matriz = Conexion.ObtenerMatriz(id);
			dataGridView1.Rows.Clear();
			kgsEstimados = 0;
			MessageBox.Show(matriz.ID.ToString());
		}

        private void cambiaPerfil(object sender, EventArgs e)
        {
			//Limpiamos los datos de la insercion realizada
			IDtxt.Text = "";
			DescripcionTxt.Text = "";
			AleacionComboBox.Text = "Seleccione";
			TemplecomboBox.Text = "Seleccione";
			//PerfilTxt.Text = "";
			ClienteComboBox.Text = "Seleccione";
			UnidadComboBox.Text = "Seleccione";
			TerminacionComboBox.Text = "Seleccione";
			PrioridadComboBox.Text = "Seleccione";
			OCTxt.Text = "";
			ObservacionesTxt.Text = "";
			pictureBox1.Image = null;
			dataGridView1.Rows.Clear();
			matrizComboBox.DataSource = null;
			matrizComboBox.Items.Clear();
		}

		private void imprimir2(object sender, PrintPageEventArgs e)
		{
			Font Arial10 = new Font("Arial", 10, FontStyle.Regular);
			Font ArialB14 = new Font("Arial Black", 14, FontStyle.Regular);
			Font ArialB12 = new Font("Arial Black", 12, FontStyle.Regular);
			Pen lineaFina = new Pen(Color.Black, 1);
			Pen lineaGruesa = new Pen(Color.Black, 3);
			int x = 40;
			int y = 142;





			// dimensiones de la hoja A4 en puntos 1169 x 826 (297 x 210 mm) factor de conversion 3.93
			Rectangle rect0 = new Rectangle(20, 20, 1129, 786);
			e.Graphics.DrawRectangle(lineaGruesa, rect0);


			Rectangle rect = new Rectangle(40, 140, 280, 40);
			e.Graphics.DrawRectangle(lineaFina, rect);
			Rectangle rect_ = new Rectangle(37, 137, 286, 46);
			e.Graphics.DrawRectangle(lineaFina, rect_);
			e.Graphics.DrawString("CLIENTE ", Arial10, Brushes.Black, x, y);
			e.Graphics.DrawString(ClienteComboBox.Text, Arial10, Brushes.Black, x, y + 20);

			Rectangle rect2 = new Rectangle(40, 200, 280, 40);
			e.Graphics.DrawRectangle(lineaFina, rect2);
			Rectangle rect2_ = new Rectangle(37, 197, 286, 46);
			e.Graphics.DrawRectangle(lineaFina, rect2_);
			e.Graphics.DrawString("PERFIL/CÓDIGO ", Arial10, Brushes.Black, x, y + 60);
			e.Graphics.DrawString(articuloPedido.Codigo, Arial10, Brushes.Black, x + 160, y + 60);
			e.Graphics.DrawString(DescripcionTxt.Text, Arial10, Brushes.Black, x, y + 80);

			Rectangle rect3 = new Rectangle(40, 260, 280, 100);
			e.Graphics.DrawRectangle(lineaFina, rect3);
			Rectangle rect3_ = new Rectangle(37, 257, 286, 106);
			e.Graphics.DrawRectangle(lineaFina, rect3_);
			e.Graphics.DrawString("CORTE A MEDIDA (mm): ", Arial10, Brushes.Black, x, y + 120);

			try
			{
				int altura = y + 140;
				for (int fila = 0; fila < dataGridView1.Rows.Count - 1; fila++)
				{
					if (fila < 4)
					{
						string cantidad = dataGridView1.Rows[fila].Cells[0].Value.ToString();
						string largo = dataGridView1.Rows[fila].Cells[1].Value.ToString();
						e.Graphics.DrawString(cantidad + " " + UnidadComboBox.Text + " x " + largo + " mm.", Arial10, Brushes.Black, x, altura);
						altura += 20;
					}
					else
					{
						if (fila == 4) { altura = y + 140; }

						string cantidad = dataGridView1.Rows[fila].Cells[0].Value.ToString();
						string largo = dataGridView1.Rows[fila].Cells[1].Value.ToString();
						e.Graphics.DrawString(cantidad + " " + UnidadComboBox.Text + " x " + largo + " mm.", Arial10, Brushes.Black, 180, altura);
						altura += 20;
					}
				}
			}
			catch (Exception ex) { MessageBox.Show("error: " + ex.Message); }






			Rectangle rect4 = new Rectangle(40, 380, 280, 60);
			e.Graphics.DrawRectangle(lineaFina, rect4);
			Rectangle rect4_ = new Rectangle(37, 377, 286, 66);
			e.Graphics.DrawRectangle(lineaFina, rect4_);
			e.Graphics.DrawString("CANTIDAD ", Arial10, Brushes.Black, x, y + 240);
			e.Graphics.DrawString("KG ", Arial10, Brushes.Black, x, y + 260);
			e.Graphics.DrawString("TIRAS ", Arial10, Brushes.Black, 180, y + 260);
			int cant = 0;
			if (UnidadComboBox.Text == "Tiras")
			{
				e.Graphics.DrawString("(estimados)", Arial10, Brushes.Black, x + 20, y + 260);
				e.Graphics.DrawString(Math.Round(kgsEstimados, 0).ToString(), Arial10, Brushes.Black, x, y + 280);

				for (int fila = 0; fila < dataGridView1.Rows.Count - 1; fila++)
				{
                    try { cant += decimal.ToInt32((decimal)dataGridView1.Rows[fila].Cells[0].Value);}
					catch (Exception) { cant += (int)dataGridView1.Rows[fila].Cells[0].Value; }
					
					
				}
				e.Graphics.DrawString(cant.ToString(), Arial10, Brushes.Black, 180, y + 280);
			}
			else
			{
				e.Graphics.DrawString(kgsEstimados.ToString(), Arial10, Brushes.Black, x, y + 280);


			}


			Rectangle rect5 = new Rectangle(40, 460, 280, 20);
			e.Graphics.DrawRectangle(lineaFina, rect5);
			Rectangle rect5_ = new Rectangle(37, 457, 286, 26);
			e.Graphics.DrawRectangle(lineaFina, rect5_);
			e.Graphics.DrawString("FECHA DE ENTREGA: ", Arial10, Brushes.Black, x, y + 320);
			//aplicar logica para calcular la fecha de acuerdo a la prioridad

			Rectangle rect6 = new Rectangle(40, 500, 460, 60);
			e.Graphics.DrawRectangle(lineaFina, rect6);
			Rectangle rect6_ = new Rectangle(37, 497, 466, 66);
			e.Graphics.DrawRectangle(lineaFina, rect6_);
			e.Graphics.DrawString("OBSERVACIONES: ", Arial10, Brushes.Black, x, 501);
			e.Graphics.DrawString(ObservacionesTxt.Text, Arial10, Brushes.Black, x, 521);

			Rectangle rect7 = new Rectangle(40, 580, 280, 20);
			e.Graphics.DrawRectangle(lineaFina, rect7);
			Rectangle rect7_ = new Rectangle(37, 577, 286, 26);
			e.Graphics.DrawRectangle(lineaFina, rect7_);
			e.Graphics.DrawString("TIEMPO PRODUC: ", Arial10, Brushes.Black, x, 582);
			if ((int)PrioridadComboBox.SelectedValue == 1)
			{
				e.Graphics.DrawString("SUPER URGENTE!!!", Arial10, Brushes.Black, 180, 582);
			}
			else
			{
				if ((int)PrioridadComboBox.SelectedValue == 2)
				{
					e.Graphics.DrawString("URGENTE", Arial10, Brushes.Black, 180, 582);

				}
				else
				{
					e.Graphics.DrawString("Normal", Arial10, Brushes.Black, 180, 582);
				}
			}

			Rectangle rect8 = new Rectangle(340, 140, 160, 40);
			e.Graphics.DrawRectangle(lineaFina, rect8);
			Rectangle rect8_ = new Rectangle(337, 137, 166, 46);
			e.Graphics.DrawRectangle(lineaFina, rect8_);
			e.Graphics.DrawString("FECHA ", Arial10, Brushes.Black, 340, 141);
			e.Graphics.DrawString(Fecha.Value.ToString("dd/MM/yyyy"), Arial10, Brushes.Black, 340, 161);

			Rectangle rect9 = new Rectangle(340, 200, 160, 40);
			e.Graphics.DrawRectangle(lineaFina, rect9);
			Rectangle rect9_ = new Rectangle(337, 197, 166, 46);
			e.Graphics.DrawRectangle(lineaFina, rect9_);
			e.Graphics.DrawString(" ALEACION", Arial10, Brushes.Black, 340, 201);
			e.Graphics.DrawString(AleacionComboBox.Text, Arial10, Brushes.Black, 340, 221);

			Rectangle rect10 = new Rectangle(340, 260, 160, 40);
			e.Graphics.DrawRectangle(lineaFina, rect10);
			Rectangle rect10_ = new Rectangle(337, 257, 166, 46);
			e.Graphics.DrawRectangle(lineaFina, rect10_);
			e.Graphics.DrawString("TEMPLE ", Arial10, Brushes.Black, 340, 261);
			e.Graphics.DrawString(TemplecomboBox.Text, Arial10, Brushes.Black, 340, 281);

			Rectangle rect11 = new Rectangle(340, 320, 160, 40);
			e.Graphics.DrawRectangle(lineaFina, rect11);
			Rectangle rect11_ = new Rectangle(337, 317, 166, 46);
			e.Graphics.DrawRectangle(lineaFina, rect11_);
			e.Graphics.DrawString("PESO/METRO ", Arial10, Brushes.Black, 340, 321);
			e.Graphics.DrawString((Math.Round(matriz.Peso, 3).ToString()).PadRight(5, '0'), Arial10, Brushes.Black, 340, 341);
			//e.Graphics.DrawString(Math.Round(matriz.Peso, 3).ToString(), Arial10, Brushes.Black, 340, 341);

			Rectangle rect12 = new Rectangle(340, 380, 160, 40);
			e.Graphics.DrawRectangle(lineaFina, rect12);
			Rectangle rect12_ = new Rectangle(337, 377, 166, 46);
			e.Graphics.DrawRectangle(lineaFina, rect12_);
			e.Graphics.DrawString("ACABADO ", Arial10, Brushes.Black, 340, 381);
			e.Graphics.DrawString(TerminacionComboBox.Text, Arial10, Brushes.Black, 340, 401);

			Rectangle rect13 = new Rectangle(340, 440, 160, 40);
			e.Graphics.DrawRectangle(lineaFina, rect13);
			Rectangle rect13_ = new Rectangle(337, 437, 166, 46);
			e.Graphics.DrawRectangle(lineaFina, rect13_);
			e.Graphics.DrawString("O.C. CLIENTE", Arial10, Brushes.Black, 340, 441);
			e.Graphics.DrawString(OCTxt.Text, Arial10, Brushes.Black, 340, 461);

			//Imagen
			Rectangle rect14 = new Rectangle(585, 90, 320, 160);
			e.Graphics.DrawRectangle(lineaFina, rect14);

			Rectangle rect15 = new Rectangle(586, 91, 318, 158);
			// Draw image to screen.
			try
			{
				e.Graphics.DrawImage(pictureBox1.Image, rect15);
			}
			catch (Exception) { }


			e.Graphics.DrawString("SUGERENCIAS DE RENDIMIENTOS DE BARROTES (diam 6 pulg.)", Arial10, Brushes.Black, 585, 270);
			e.Graphics.DrawString("Nº de salidas consideradas: " + matriz.Salidas.ToString(), Arial10, Brushes.Black, 585, 290);
			e.Graphics.DrawString("TOCHOS(mm)  LARGO tira(m)   CORTES  RENDIMIENTO  DESPUNTE(m)  TOCHOS", Arial10, Brushes.Black, 585, 310);
			//CALCULO RENDIMIENTOS
			rendimiento rend400 = new rendimiento(largoOK, matriz.Peso, matriz.Salidas, 6, 400, kgsEstimados);
			e.Graphics.DrawString(rend400.largoTocho.ToString(), Arial10, Brushes.Black, 585, 330);
			e.Graphics.DrawString(rend400.largoExtrusion.ToString(), Arial10, Brushes.Black, 685, 330);
			e.Graphics.DrawString(rend400.cortes.ToString(), Arial10, Brushes.Black, 795, 330);
			e.Graphics.DrawString(rend400.rendimientos.ToString() + " %", Arial10, Brushes.Black, 860, 330);
			e.Graphics.DrawString(rend400.despunte_Perfil.ToString(), Arial10, Brushes.Black, 965, 330);
			e.Graphics.DrawString(rend400.cant_Tochos.ToString(), Arial10, Brushes.Black, 1070, 330);

			rendimiento rend450 = new rendimiento(largoOK, matriz.Peso, matriz.Salidas, 6, 450, kgsEstimados);
			e.Graphics.DrawString(rend450.largoTocho.ToString(), Arial10, Brushes.Black, 585, 350);
			e.Graphics.DrawString(rend450.largoExtrusion.ToString(), Arial10, Brushes.Black, 685, 350);
			e.Graphics.DrawString(rend450.cortes.ToString(), Arial10, Brushes.Black, 795, 350);
			e.Graphics.DrawString(rend450.rendimientos.ToString() + " %", Arial10, Brushes.Black, 860, 350);
			e.Graphics.DrawString(rend450.despunte_Perfil.ToString(), Arial10, Brushes.Black, 965, 350);
			e.Graphics.DrawString(rend450.cant_Tochos.ToString(), Arial10, Brushes.Black, 1070, 350);

			rendimiento rend560 = new rendimiento(largoOK, matriz.Peso, matriz.Salidas, 6, 560, kgsEstimados);
			e.Graphics.DrawString(rend560.largoTocho.ToString(), Arial10, Brushes.Black, 585, 370);
			e.Graphics.DrawString(rend560.largoExtrusion.ToString(), Arial10, Brushes.Black, 685, 370);
			e.Graphics.DrawString(rend560.cortes.ToString(), Arial10, Brushes.Black, 795, 370);
			e.Graphics.DrawString(rend560.rendimientos.ToString() + " %", Arial10, Brushes.Black, 860, 370);
			e.Graphics.DrawString(rend560.despunte_Perfil.ToString(), Arial10, Brushes.Black, 965, 370);
			e.Graphics.DrawString(rend560.cant_Tochos.ToString(), Arial10, Brushes.Black, 1070, 370);

			rendimiento rend630 = new rendimiento(largoOK, matriz.Peso, matriz.Salidas, 6, 630, kgsEstimados);
			e.Graphics.DrawString(rend630.largoTocho.ToString(), Arial10, Brushes.Black, 585, 390);
			e.Graphics.DrawString(rend630.largoExtrusion.ToString(), Arial10, Brushes.Black, 685, 390);
			e.Graphics.DrawString(rend630.cortes.ToString(), Arial10, Brushes.Black, 795, 390);
			e.Graphics.DrawString(rend630.rendimientos.ToString() + " %", Arial10, Brushes.Black, 860, 390);
			e.Graphics.DrawString(rend630.despunte_Perfil.ToString(), Arial10, Brushes.Black, 965, 390);
			e.Graphics.DrawString(rend630.cant_Tochos.ToString(), Arial10, Brushes.Black, 1070, 390);


			e.Graphics.DrawString("SUGERENCIAS DE RENDIMIENTOS DE BARROTES (diam 5 pulg.)", Arial10, Brushes.Black, 585, 430);
			e.Graphics.DrawString("Nº de salidas consideradas: " + matriz.Salidas.ToString(), Arial10, Brushes.Black, 585, 450);
			e.Graphics.DrawString("TOCHOS(mm)  LARGO tira(m)   CORTES  RENDIMIENTO  DESPUNTE(m)  TOCHOS", Arial10, Brushes.Black, 585, 470);

			//CALCULO RENDIMIENTOS
			rendimiento rend400_ = new rendimiento(largoOK, matriz.Peso, matriz.Salidas, 5, 400, kgsEstimados);
			e.Graphics.DrawString(rend400_.largoTocho.ToString(), Arial10, Brushes.Black, 585, 490);
			e.Graphics.DrawString(rend400_.largoExtrusion.ToString(), Arial10, Brushes.Black, 685, 490);
			e.Graphics.DrawString(rend400_.cortes.ToString(), Arial10, Brushes.Black, 795, 490);
			e.Graphics.DrawString(rend400_.rendimientos.ToString() + " %", Arial10, Brushes.Black, 860, 490);
			e.Graphics.DrawString(rend400_.despunte_Perfil.ToString(), Arial10, Brushes.Black, 965, 490);
			e.Graphics.DrawString(rend400_.cant_Tochos.ToString(), Arial10, Brushes.Black, 1070, 490);

			rendimiento rend450_ = new rendimiento(largoOK, matriz.Peso, matriz.Salidas, 5, 450, kgsEstimados);
			e.Graphics.DrawString(rend450_.largoTocho.ToString(), Arial10, Brushes.Black, 585, 510);
			e.Graphics.DrawString(rend450_.largoExtrusion.ToString(), Arial10, Brushes.Black, 685, 510);
			e.Graphics.DrawString(rend450_.cortes.ToString(), Arial10, Brushes.Black, 795, 510);
			e.Graphics.DrawString(rend450_.rendimientos.ToString() + " %", Arial10, Brushes.Black, 860, 510);
			e.Graphics.DrawString(rend450_.despunte_Perfil.ToString(), Arial10, Brushes.Black, 965, 510);
			e.Graphics.DrawString(rend450_.cant_Tochos.ToString(), Arial10, Brushes.Black, 1070, 510);

			rendimiento rend560_ = new rendimiento(largoOK, matriz.Peso, matriz.Salidas, 5, 560, kgsEstimados);
			e.Graphics.DrawString(rend560_.largoTocho.ToString(), Arial10, Brushes.Black, 585, 530);
			e.Graphics.DrawString(rend560_.largoExtrusion.ToString(), Arial10, Brushes.Black, 685, 530);
			e.Graphics.DrawString(rend560_.cortes.ToString(), Arial10, Brushes.Black, 795, 530);
			e.Graphics.DrawString(rend560_.rendimientos.ToString() + " %", Arial10, Brushes.Black, 860, 530);
			e.Graphics.DrawString(rend560_.despunte_Perfil.ToString(), Arial10, Brushes.Black, 965, 530);
			e.Graphics.DrawString(rend560_.cant_Tochos.ToString(), Arial10, Brushes.Black, 1070, 530);

			rendimiento rend630_ = new rendimiento(largoOK, matriz.Peso, matriz.Salidas, 5, 630, kgsEstimados);
			e.Graphics.DrawString(rend630_.largoTocho.ToString(), Arial10, Brushes.Black, 585, 550);
			e.Graphics.DrawString(rend630_.largoExtrusion.ToString(), Arial10, Brushes.Black, 685, 550);
			e.Graphics.DrawString(rend630_.cortes.ToString(), Arial10, Brushes.Black, 795, 550);
			e.Graphics.DrawString(rend630_.rendimientos.ToString() + " %", Arial10, Brushes.Black, 860, 550);
			e.Graphics.DrawString(rend630_.despunte_Perfil.ToString(), Arial10, Brushes.Black, 965, 550);
			e.Graphics.DrawString(rend630_.cant_Tochos.ToString(), Arial10, Brushes.Black, 1070, 550);
			string prensa = "";

			string consulta5 = "select p.descripcion from puesto p where p.ID=" + articuloPedido.Prensa + " limit 1";
			MySqlConnection conectar = Conexion.ObtenerConexion();
			MySqlDataReader reader;
			conectar.Open();
			try
			{
				MySqlCommand comand = new MySqlCommand(consulta5, conectar);
				reader = comand.ExecuteReader();
				DataTable dt = new DataTable();
				dt.Load(reader);
				foreach (DataRow i in dt.Rows)
				{

					prensa = (string)i[0];
				}
			}
			catch (MySqlException ex) { MessageBox.Show("Error al buscar " + ex.Message); }
			finally { conectar.Close(); }

			e.Graphics.DrawString("PRENSA ASIGNADA: " + prensa, ArialB12, Brushes.Black, 585, 580);





			e.Graphics.DrawString("IMAGEN:", Arial10, Brushes.Black, 585, 70);
			e.Graphics.DrawString("DATOS ADICIONALES", Arial10, Brushes.Black, 920, 90);
			e.Graphics.DrawString("Peso nominal (kg/m): ", Arial10, Brushes.Black, 920, 120);
			e.Graphics.DrawString(articuloPedido.PesoNominal.ToString(), Arial10, Brushes.Black, 1060, 120);
			e.Graphics.DrawString("Peso máximo (kg/m):", Arial10, Brushes.Black, 920, 150);
			e.Graphics.DrawString(Math.Round((articuloPedido.PesoNominal * 1.12), 3).ToString(), Arial10, Brushes.Black, 1060, 150);
			e.Graphics.DrawString("Multiplo (mm):", Arial10, Brushes.Black, 920, 180);
			e.Graphics.DrawString(articuloPedido.Multiplo.ToString(), Arial10, Brushes.Black, 1060, 180);
			e.Graphics.DrawString("Precio:", Arial10, Brushes.Black, 920, 210);
			e.Graphics.DrawString(articuloPedido.Clasificacion, Arial10, Brushes.Black, 1060, 210);
			e.Graphics.DrawString("Ubicación matriz: " + articuloPedido.Ubicacion, Arial10, Brushes.Black, 920, 240);

			Rectangle rect00 = new Rectangle(340, 92, 160, 30);
			e.Graphics.DrawRectangle(lineaGruesa, rect00);
			e.Graphics.DrawString("ORDEN DE PRODUCCION", ArialB14, Brushes.Black, 45, 93);
			e.Graphics.DrawString(NumeroTxt.Text, ArialB14, Brushes.Black, 342, 93);

			Point ubicacionlogo = new Point(25, 23);
			string ruta = "//Rodrigo/imagenes/logo.bmp";
			Image logo = Image.FromFile(ruta);
			e.Graphics.DrawImage(logo, ubicacionlogo);


			e.Graphics.DrawLine(lineaGruesa, 20, 620, 1149, 620);
			e.Graphics.DrawString("FABRICADO", ArialB14, Brushes.Black, 40, 620);
			e.Graphics.DrawString("  KG.       PTES      TIRAS      LARGO      DUREZA     ENTREGADO", Arial10, Brushes.Black, 40, 650);
			e.Graphics.DrawString("  KG.       PTES      TIRAS      LARGO      DUREZA     ENTREGADO", Arial10, Brushes.Black, 585, 650);
			e.Graphics.DrawLine(lineaFina, 40, 690, 500, 690);
			e.Graphics.DrawLine(lineaFina, 40, 710, 500, 710);
			e.Graphics.DrawLine(lineaFina, 40, 730, 500, 730);
			e.Graphics.DrawLine(lineaFina, 40, 750, 500, 750);
			e.Graphics.DrawLine(lineaFina, 40, 770, 500, 770);
			e.Graphics.DrawLine(lineaFina, 40, 790, 500, 790);

			e.Graphics.DrawLine(lineaFina, 585, 690, 1045, 690);
			e.Graphics.DrawLine(lineaFina, 585, 710, 1045, 710);
			e.Graphics.DrawLine(lineaFina, 585, 730, 1045, 730);
			e.Graphics.DrawLine(lineaFina, 585, 750, 1045, 750);
			e.Graphics.DrawLine(lineaFina, 585, 770, 1045, 770);
			e.Graphics.DrawLine(lineaFina, 585, 790, 1045, 790);



		}

        private void BuscarImagen_Click(object sender, EventArgs e)
        {
			try
			{
				if (openFileDialog1.ShowDialog() == DialogResult.OK)
				{ 
					openFileDialog1.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png, *.bmp) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png; *.bmp";
					string imagen = openFileDialog1.FileName;
					pictureBox1.Image = Image.FromFile(imagen);
				}
			}
			catch (Exception ex)
			{
				pictureBox1.Image = null;
				MessageBox.Show("El archivo seleccionado no es un tipo de imagen válido");
			}
		}
    }
}
