using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Data;

namespace Login
{
	public partial class ListadoPedidos : Form
	{
		Usuario usuario;
		public ListadoPedidos()
		{
			InitializeComponent();
		}

		public ListadoPedidos(Usuario user)
		{
			usuario = user;
			InitializeComponent();
		}

		//Declaracion de variables, sirve para vincular con la ventana que las instancia.
		private Articulo articuloSeleccionado = new Articulo();
		private string filtroEstado = "";
		private string filtroCliente = "";


		//Propiedades, solo Get
		public Articulo ArticuloSeleccionado{
			get{return articuloSeleccionado; }
		}

		
		
		//Muestra en el cuadro las coincidencias
		void BuscarClick(object sender, EventArgs e){
			pictureBox1.Image = null;
			MySqlConnection conectar = Conexion.ObtenerConexion();
			MySqlDataReader reader;
			conectar.Open();
			string condicion2 = "";
			string condicion3 = "";
			string condicion4 = "";
			string condicion5 = "";

			try
			{
				Cuadro.Rows.Clear();
				DateTime fecha1 = Fecha1DTP.Value;
				DateTime fecha2 = fecha2DTP.Value;
				string consultaNueva = "";
				if (NumOPTextBox.Text != "")
				{
					condicion3 = "and p.numero = '" + NumOPTextBox.Text + "'";
					TodosRB.Checked = true;
					ClienteComboBox.Text = "Todos los clientes";
					ArticuloTextBox.Text = "";
					Fecha1DTP.Value = Convert.ToDateTime("2000/01/01");
					fecha2DTP.Value = DateTime.Today;
				}
				if (ClienteComboBox.Text!="Todos los clientes")
                {
					condicion2 = "and p.cliente = '" + ClienteComboBox.Text + "'";
                }

				if (IDArticulo.Text!="")
				{
					condicion4 = "and p.articulo = '" + ArticuloTextBox.Text + "'";
				}

				if (EstadosActuales.Text != "Todos")
				{
					condicion5 = "and p.estado like '" + EstadosActuales.Text + "'";
				}





				if (ActivosRB.Checked == true)
				{
					consultaNueva = "select * from pedidosActivos p where p.fecha >= '" + fecha1.ToString("yyyyMMdd") + "' and p.fecha <= '" + fecha2.ToString("yyyyMMdd") + "'" + condicion2 + condicion3 + condicion4 + condicion5;
				}
				else if (TodosRB.Checked == true)
				{
					consultaNueva = "select * from pedidosTodos p where p.fecha >= '" + fecha1.ToString("yyyyMMdd") + "' and p.fecha <= '" + fecha2.ToString("yyyyMMdd") + "'" + condicion2 + condicion3 + condicion4 + condicion5;
				}
                else
                {
					consultaNueva = "select * from pedidosHistorial p where p.fecha >= '" + fecha1.ToString("yyyyMMdd") + "' and p.fecha <= '" + fecha2.ToString("yyyyMMdd") + "'" + condicion2 + condicion3 + condicion4 + condicion5;
				}



				MySqlCommand comand = new MySqlCommand(consultaNueva, conectar);
				reader = comand.ExecuteReader();
				if (reader.HasRows)
				{
					List<Pedido> resultadoBusqueda = new List<Pedido>();
					while (reader.Read())
					{
						Pedido pedido = new Pedido();
						pedido.ID = int.Parse(reader.GetString(0));
						pedido.Numero = int.Parse(reader.GetString(1));
						pedido.Fecha = DateTime.Parse(reader.GetString(2));
						try { pedido.KgEstimados = double.Parse(reader.GetString(3)); }
						catch (Exception) { pedido.KgEstimados = 0; }
						pedido.OrdenCompra = reader.GetString(4);
						pedido.Observaciones = reader.GetString(5);
						pedido.Cliente = reader.GetString(6);
						pedido.Articulo = reader.GetString(7);
						pedido.Unidad = reader.GetString(8);
						pedido.Terminacion = reader.GetString(9);
						pedido.Estado = reader.GetString(10);
						pedido.Prioridad = reader.GetString(11);
						pedido.Aleacion = reader.GetString(12);
						pedido.Temple = reader.GetString(13);

						pedido.Largo = reader.GetString(14);
						pedido.Cantidad = double.Parse(reader.GetString(15));
						pedido.Detalle = int.Parse(reader.GetString(16));
						if (pedido.Detalle > 1) { pedido.Largo = "varios"; }

						resultadoBusqueda.Add(pedido);


						int n = Cuadro.Rows.Add();
						Cuadro.Rows[n].Cells[0].Value = pedido.ID;
						Cuadro.Rows[n].Cells[1].Value = pedido.Numero;
						Cuadro.Rows[n].Cells[2].Value = pedido.Fecha.ToString("dd-MM-yyyy");
						Cuadro.Rows[n].Cells[3].Value = pedido.Cliente;
						Cuadro.Rows[n].Cells[4].Value = reader.GetString(17);
						Cuadro.Rows[n].Cells[5].Value = pedido.Articulo;
						Cuadro.Rows[n].Cells[6].Value = pedido.Cantidad;
						Cuadro.Rows[n].Cells[7].Value = pedido.Unidad;
						Cuadro.Rows[n].Cells[8].Value = pedido.Largo;
						Cuadro.Rows[n].Cells[9].Value = pedido.Aleacion;
						Cuadro.Rows[n].Cells[10].Value = pedido.Temple;
						Cuadro.Rows[n].Cells[11].Value = pedido.Terminacion;
						Cuadro.Rows[n].Cells[12].Value = pedido.Estado;
						Cuadro.Rows[n].Cells[13].Value = pedido.Prioridad;
						Cuadro.Rows[n].Cells[14].Value = pedido.KgEstimados;
						Cuadro.Rows[n].Cells[15].Value = pedido.OrdenCompra;
						Cuadro.Rows[n].Cells[16].Value = pedido.Observaciones;
						Cuadro.Rows[n].Cells[17].Value = pedido.Detalle;
						
					}

					
					
				}
				else
				{
					AutoClosingMessageBox.Show("No se encontraron registros", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning,2000);
				}
			}
			catch (MySqlException ex)
			{
				MessageBox.Show("Error al buscar " + ex.Message,"Atención",MessageBoxButtons.OK,MessageBoxIcon.Error);
			}
			finally
			{
				conectar.Close();
			}

		}
		
	
		
		
		// Devuelve el indice de la celda seleccionada
		int n;
		void Selecccioncelda(object sender, DataGridViewCellEventArgs e)
		{    //n = e.RowIndex;
			//string numeroPedido = Cuadro.Rows[n].Cells[1].Value.ToString();
			//MessageBox.Show(n.ToString());
		}

		private void Cuadro_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
			//n = e.RowIndex;

			//string numeroPedido = Cuadro.Rows[n].Cells[1].Value.ToString();
			//MessageBox.Show("NUMERO DE PEDIDO= "+ numeroPedido);

		}
		string pedidoSeleccionado;
		private void Cuadro_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			try
			{
				n = e.RowIndex;

				string codigo = (string)Cuadro.Rows[n].Cells[4].Value;
				try
				{
					string ruta = "//Rodrigo/imagenes/" + codigo + ".bmp";
					byte[] imageBytes = File.ReadAllBytes(ruta);
					MemoryStream buf = new MemoryStream(imageBytes);
					pictureBox1.Image = Image.FromStream(buf);
				}
				catch (Exception) { pictureBox1.Image = null; }



				int numero_ID = (int)Cuadro.Rows[n].Cells[0].Value;

				string numeroPedido = Cuadro.Rows[n].Cells[1].Value.ToString();

				pedidoSeleccionado = numeroPedido;

				AutoClosingMessageBox.Show("Pedido Seleccionado: " + numeroPedido, "Selección", MessageBoxButtons.OK, MessageBoxIcon.Information,1200);
				


				MySqlConnection conectar = Conexion.ObtenerConexion();
				MySqlDataReader reader;
				conectar.Open();
				// COMBOBOX ESTADO
				string consulta = "Select ID,descripcion From Estado u order by u.descripcion";
				try
				{
					MySqlCommand comand = new MySqlCommand(consulta, conectar);
					reader = comand.ExecuteReader();
					DataTable dt = new DataTable();
					dt.Load(reader);
					EstadocomboBox.DataSource = dt;
					EstadocomboBox.DisplayMember = "descripcion";
					EstadocomboBox.ValueMember = "ID";
				}
				catch (MySqlException ex) { MessageBox.Show("Error al buscar " + ex.Message,"Atención",MessageBoxButtons.OK,MessageBoxIcon.Error); }

				finally { conectar.Close(); }

				EstadocomboBox.Text = Conexion.VerEstado(numeroPedido);

			}
			catch (Exception){ }

        }


		private void Cancelar_Click(object sender, EventArgs e)
        {
			this.Close();
        }

        private void Exportarboton_Click(object sender, EventArgs e)
        {
			Exportar.Exportar_Articulos(Cuadro);

        }



        private void ListadoPedidos_Load(object sender, EventArgs e)
        {
			ModificarBTN.Enabled = usuario.ModificaPedidos;
			GuardarBTN.Enabled = usuario.ModificaPedidos;


			fecha2DTP.Value = DateTime.Today;
			MySqlConnection conectar = Conexion.ObtenerConexion();
			MySqlDataReader reader;
			conectar.Open();
			// COMBOBOX CLIENTE
			string consulta5 = "Select ID,Alias From Cliente c order by c.Alias";
			try
			{
				MySqlCommand comand = new MySqlCommand(consulta5, conectar);
				reader = comand.ExecuteReader();
				DataTable dt = new DataTable();
				dt.Load(reader);
				DataRow newRow = dt.NewRow();
				newRow["Alias"] = "Todos los clientes";
				dt.Rows.InsertAt(newRow, 0);
				ClienteComboBox.DataSource = dt;
				ClienteComboBox.DisplayMember = "Alias";
				ClienteComboBox.ValueMember = "ID";
			}
			catch (MySqlException ex) { MessageBox.Show("Error al buscar " + ex.Message,"Atención",MessageBoxButtons.OK,MessageBoxIcon.Error); }

			MySqlDataReader reader2;
			
			// COMBOBOX ESTADO
			string consulta6 = "Select ID,descripcion From Estado e where  e.id<6  order by e.descripcion";
			try
			{
				MySqlCommand comand = new MySqlCommand(consulta6, conectar);
				reader2 = comand.ExecuteReader();
				DataTable dt = new DataTable();
				dt.Load(reader2);
				DataRow newRow = dt.NewRow();
				newRow["descripcion"] = "Todos";
				dt.Rows.InsertAt(newRow, 0);
				EstadosActuales.DataSource = dt;
				EstadosActuales.DisplayMember = "descripcion";
				EstadosActuales.ValueMember = "ID";
			}
			catch (MySqlException ex) { MessageBox.Show("Error al buscar " + ex.Message,"Atención",MessageBoxButtons.OK,MessageBoxIcon.Error); }


			finally { conectar.Close(); } // Cerramos la conexion a la base de datos


		}

        private void Articulocambia(object sender, EventArgs e)
        {
			IDArticulo.Text = "";
        }

        private void Buscar2BTN_Click(object sender, EventArgs e)
        {
			if (ArticuloTextBox.Text != "")
			{
				Articulo articulo = Conexion.ObtenerArticulo(ArticuloTextBox.Text,this);
				ArticuloTextBox.Text = articulo.Descripcion;
				IDArticulo.Text = articulo.ID.ToString();
			}
            else
            {
				MessageBox.Show("El campo artículo esta vacio");
            }

		}

        private void button1_Click(object sender, EventArgs e)
        {
			ModificarPedido Modif = new ModificarPedido(pedidoSeleccionado);
			Modif.MdiParent = this.MdiParent;
			Modif.Show();
        }

        private void GuardarBTN_Click(object sender, EventArgs e)
        {
			int EstadoID; 
			
			if (EstadocomboBox.SelectedValue != null)
            {
				EstadoID = (int)EstadocomboBox.SelectedValue;
				Conexion.ModificarEstado(pedidoSeleccionado, EstadoID);

				EstadocomboBox.DataSource = null;
				EstadocomboBox.Items.Clear();
				n = 0;
				Cuadro.Rows.Clear();
				BuscarClick(sender, e);


			}
			else { AutoClosingMessageBox.Show("Seleccione un pedido","Atención",MessageBoxButtons.OK,MessageBoxIcon.Warning,1600) ; }
			
        }

        private void Cuadro_SelectionChanged(object sender, EventArgs e)
        {
			EstadocomboBox.DataSource = null;
			EstadocomboBox.Items.Clear();
			n = 0;

		}

        private void ActivosRB_CheckedChanged(object sender, EventArgs e)
        {
			EstadosActuales.DataSource = null;
			EstadosActuales.Items.Clear();
			

			if (ActivosRB.Checked)
			{
				MySqlConnection conectar = Conexion.ObtenerConexion();
				conectar.Open();
				// COMBOBOX ESTADO
				MySqlDataReader reader2;
				string consulta6 = "Select ID,descripcion From Estado e where  e.id<6  order by e.descripcion";
				try
				{
					MySqlCommand comand = new MySqlCommand(consulta6, conectar);
					reader2 = comand.ExecuteReader();
					DataTable dt = new DataTable();
					dt.Load(reader2);
					DataRow newRow = dt.NewRow();
					newRow["descripcion"] = "Todos";
					dt.Rows.InsertAt(newRow, 0);
					EstadosActuales.DataSource = dt;
					EstadosActuales.DisplayMember = "descripcion";
					EstadosActuales.ValueMember = "ID";
				}
				catch (MySqlException ex) { MessageBox.Show("Error al buscar " + ex.Message,"Atención",MessageBoxButtons.OK,MessageBoxIcon.Error); }
				finally { conectar.Close(); } // Cerramos la conexion a la base de datos
			}

			if (TodosRB.Checked)
			{
				MySqlConnection conectar = Conexion.ObtenerConexion();
				conectar.Open();
				// COMBOBOX ESTADO
				MySqlDataReader reader2;
				string consulta6 = "Select ID,descripcion From Estado e order by e.descripcion";
				try
				{
					MySqlCommand comand = new MySqlCommand(consulta6, conectar);
					reader2 = comand.ExecuteReader();
					DataTable dt = new DataTable();
					dt.Load(reader2);
					DataRow newRow = dt.NewRow();
					newRow["descripcion"] = "Todos";
					dt.Rows.InsertAt(newRow, 0);
					EstadosActuales.DataSource = dt;
					EstadosActuales.DisplayMember = "descripcion";
					EstadosActuales.ValueMember = "ID";
				}
				catch (MySqlException ex) { MessageBox.Show("Error al buscar " + ex.Message,"Atención",MessageBoxButtons.OK,MessageBoxIcon.Error); }
				finally { conectar.Close(); } // Cerramos la conexion a la base de datos
			}


			if (HistorialRB.Checked)
			{
				MySqlConnection conectar = Conexion.ObtenerConexion();
				conectar.Open();
				// COMBOBOX ESTADO
				MySqlDataReader reader2;
				string consulta6 = "Select ID,descripcion From Estado e where e.id=6  order by e.descripcion";
				try
				{
					MySqlCommand comand = new MySqlCommand(consulta6, conectar);
					reader2 = comand.ExecuteReader();
					DataTable dt = new DataTable();
					dt.Load(reader2);
					DataRow newRow = dt.NewRow();
					newRow["descripcion"] = "Todos";
					dt.Rows.InsertAt(newRow, 0);
					EstadosActuales.DataSource = dt;
					EstadosActuales.DisplayMember = "descripcion";
					EstadosActuales.ValueMember = "ID";
				}
				catch (MySqlException ex) { MessageBox.Show("Error al buscar " + ex.Message,"Atención",MessageBoxButtons.OK,MessageBoxIcon.Error); }
				finally { conectar.Close(); } // Cerramos la conexion a la base de datos
			}



		}

        private void TodosRB_CheckedChanged(object sender, EventArgs e)
		{
			EstadosActuales.DataSource = null;
			EstadosActuales.Items.Clear();


			if (ActivosRB.Checked)
			{
				MySqlConnection conectar = Conexion.ObtenerConexion();
				conectar.Open();
				// COMBOBOX ESTADO
				MySqlDataReader reader2;
				string consulta6 = "Select ID,descripcion From Estado e where  e.id<6  order by e.descripcion";
				try
				{
					MySqlCommand comand = new MySqlCommand(consulta6, conectar);
					reader2 = comand.ExecuteReader();
					DataTable dt = new DataTable();
					dt.Load(reader2);
					DataRow newRow = dt.NewRow();
					newRow["descripcion"] = "Todos";
					dt.Rows.InsertAt(newRow, 0);
					EstadosActuales.DataSource = dt;
					EstadosActuales.DisplayMember = "descripcion";
					EstadosActuales.ValueMember = "ID";
				}
				catch (MySqlException ex) { MessageBox.Show("Error al buscar " + ex.Message,"Atención",MessageBoxButtons.OK,MessageBoxIcon.Error); }
				finally { conectar.Close(); } // Cerramos la conexion a la base de datos
			}

			if (TodosRB.Checked)
			{
				MySqlConnection conectar = Conexion.ObtenerConexion();
				conectar.Open();
				// COMBOBOX ESTADO
				MySqlDataReader reader2;
				string consulta6 = "Select ID,descripcion From Estado e order by e.descripcion";
				try
				{
					MySqlCommand comand = new MySqlCommand(consulta6, conectar);
					reader2 = comand.ExecuteReader();
					DataTable dt = new DataTable();
					dt.Load(reader2);
					DataRow newRow = dt.NewRow();
					newRow["descripcion"] = "Todos";
					dt.Rows.InsertAt(newRow, 0);
					EstadosActuales.DataSource = dt;
					EstadosActuales.DisplayMember = "descripcion";
					EstadosActuales.ValueMember = "ID";
				}
				catch (MySqlException ex) { MessageBox.Show("Error al buscar " + ex.Message,"Atención",MessageBoxButtons.OK,MessageBoxIcon.Error); }
				finally { conectar.Close(); } // Cerramos la conexion a la base de datos
			}


			if (HistorialRB.Checked)
			{
				MySqlConnection conectar = Conexion.ObtenerConexion();
				conectar.Open();
				// COMBOBOX ESTADO
				MySqlDataReader reader2;
				string consulta6 = "Select ID,descripcion From Estado e where e.id=6  order by e.descripcion";
				try
				{
					MySqlCommand comand = new MySqlCommand(consulta6, conectar);
					reader2 = comand.ExecuteReader();
					DataTable dt = new DataTable();
					dt.Load(reader2);
					DataRow newRow = dt.NewRow();
					newRow["descripcion"] = "Todos";
					dt.Rows.InsertAt(newRow, 0);
					EstadosActuales.DataSource = dt;
					EstadosActuales.DisplayMember = "descripcion";
					EstadosActuales.ValueMember = "ID";
				}
				catch (MySqlException ex) { MessageBox.Show("Error al buscar " + ex.Message,"Atención",MessageBoxButtons.OK,MessageBoxIcon.Error); }
				finally { conectar.Close(); } // Cerramos la conexion a la base de datos
			}



		}

        private void HistorialRB_CheckedChanged(object sender, EventArgs e)
        {
			EstadosActuales.DataSource = null;
			EstadosActuales.Items.Clear();


			if (ActivosRB.Checked)
			{
				MySqlConnection conectar = Conexion.ObtenerConexion();
				conectar.Open();
				// COMBOBOX ESTADO
				MySqlDataReader reader2;
				string consulta6 = "Select ID,descripcion From Estado e where  e.id<6  order by e.descripcion";
				try
				{
					MySqlCommand comand = new MySqlCommand(consulta6, conectar);
					reader2 = comand.ExecuteReader();
					DataTable dt = new DataTable();
					dt.Load(reader2);
					DataRow newRow = dt.NewRow();
					newRow["descripcion"] = "Todos";
					dt.Rows.InsertAt(newRow, 0);
					EstadosActuales.DataSource = dt;
					EstadosActuales.DisplayMember = "descripcion";
					EstadosActuales.ValueMember = "ID";
				}
				catch (MySqlException ex) { MessageBox.Show("Error al buscar " + ex.Message,"Atención",MessageBoxButtons.OK,MessageBoxIcon.Error); }
				finally { conectar.Close(); } // Cerramos la conexion a la base de datos
			}

			if (TodosRB.Checked)
			{
				MySqlConnection conectar = Conexion.ObtenerConexion();
				conectar.Open();
				// COMBOBOX ESTADO
				MySqlDataReader reader2;
				string consulta6 = "Select ID,descripcion From Estado e order by e.descripcion";
				try
				{
					MySqlCommand comand = new MySqlCommand(consulta6, conectar);
					reader2 = comand.ExecuteReader();
					DataTable dt = new DataTable();
					dt.Load(reader2);
					DataRow newRow = dt.NewRow();
					newRow["descripcion"] = "Todos";
					dt.Rows.InsertAt(newRow, 0);
					EstadosActuales.DataSource = dt;
					EstadosActuales.DisplayMember = "descripcion";
					EstadosActuales.ValueMember = "ID";
				}
				catch (MySqlException ex) { MessageBox.Show("Error al buscar " + ex.Message,"Atención",MessageBoxButtons.OK,MessageBoxIcon.Error); }
				finally { conectar.Close(); } // Cerramos la conexion a la base de datos
			}


			if (HistorialRB.Checked)
			{
				MySqlConnection conectar = Conexion.ObtenerConexion();
				conectar.Open();
				// COMBOBOX ESTADO
				MySqlDataReader reader2;
				string consulta6 = "Select ID,descripcion From Estado e where e.id=6  order by e.descripcion";
				try
				{
					MySqlCommand comand = new MySqlCommand(consulta6, conectar);
					reader2 = comand.ExecuteReader();
					DataTable dt = new DataTable();
					dt.Load(reader2);
					DataRow newRow = dt.NewRow();
					newRow["descripcion"] = "Todos";
					dt.Rows.InsertAt(newRow, 0);
					EstadosActuales.DataSource = dt;
					EstadosActuales.DisplayMember = "descripcion";
					EstadosActuales.ValueMember = "ID";
				}
				catch (MySqlException ex) { MessageBox.Show("Error al buscar " + ex.Message,"Atención",MessageBoxButtons.OK,MessageBoxIcon.Error); }
				finally { conectar.Close(); } // Cerramos la conexion a la base de datos
			}

		}

        private void ClienteComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
			NumOPTextBox.Text = "";
			ActivosRB.Checked = true;
			Cuadro.Rows.Clear();
			
        }




    }
}