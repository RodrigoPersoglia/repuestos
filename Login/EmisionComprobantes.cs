
using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Data;
using System.Drawing.Printing;

namespace Login
{
	/// <summary>
	/// Description of factura.
	/// </summary>
	public partial class EmisionComprobantes : Form
	{
		//variables
		private Usuario usuario;
		Cliente cliente = null;
		Comprobante comprobante;

		//Constructor
		public EmisionComprobantes( Usuario user)
		{
			usuario = user;
			InitializeComponent(); }

		private void ActualizaSubTotal()
        {
			decimal subTotalActualizado=0;
            try
            {
				for (int fila = 0; fila < Cuadro.Rows.Count - 1; fila++)
				{
					subTotalActualizado += decimal.Parse(Cuadro.Rows[fila].Cells[5].Value.ToString());
				}
				SubTotalNUM.Value = subTotalActualizado;
			}
            catch (Exception) { }
        }


		void agregarClick(object sender, EventArgs e)
		{
			if (txtCodigo.Text != "" && txtDescripcion.Text != "" && cant.Text != "0") {
				//Adicionamos un nuevo renglon
				int n = Cuadro.Rows.Add();
				Cuadro.Rows[n].Cells[0].Value = false;
				Cuadro.Rows[n].Cells[1].Value = txtCodigo.Text;
				Cuadro.Rows[n].Cells[2].Value = txtDescripcion.Text;
				Cuadro.Rows[n].Cells[3].Value = cant.Value;
				Cuadro.Rows[n].Cells[4].Value = PrecioFinalNum.Value;
				Cuadro.Rows[n].Cells[5].Value = (cant.Value * PrecioFinalNum.Value);
				ActualizaSubTotal();
				LimpiarArticulo();
				txtCodigo.Text = "";
				txtCodigo.Focus();
			}
			else { MessageBox.Show("Revise los campos ingresados", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }
		}

		int n;
		
		void seleccioncelda(object sender, DataGridViewCellEventArgs e)
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
		
		
		void QuitarClick(object sender, EventArgs e)
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
					ActualizaSubTotal();
				}


				else { MessageBox.Show("No hay ningun registro seleccionado"); }
			}
            catch (Exception) { }
		}


	

		void BuscarClick(object sender, EventArgs e)
		{
            if (Cliente.Text != "")
            {
				string texto = txtCodigo.Text.ToString();
				Articulo articulo = Conexion.ObtenerArticulo(texto, this);
                if (articulo != null)
                {
					txtCodigo.Text = articulo.Codigo.ToString();
					txtDescripcion.Text = articulo.Descripcion;
					PrecioNum.Value = Convert.ToDecimal(articulo.Precio);
					ActualizarPrecioFinal();
					if (articulo.Codigo == "SC") { txtDescripcion.ReadOnly = false; PrecioNum.ReadOnly = false; PrecioNum.Increment = 1; }
					else { txtDescripcion.ReadOnly = true; ; PrecioNum.ReadOnly = true; PrecioNum.Increment = 0; }


					try
					{
						byte[] imageBytes = File.ReadAllBytes(Conexion.rutaImagen(articulo.Codigo));
						MemoryStream buf = new MemoryStream(imageBytes);
						pictureBox1.Image = Image.FromStream(buf);
					}
					catch (Exception) { pictureBox1.Image = null; }

					cant.Focus();
				}

                else { MessageBox.Show("No selecciono ningun artículo", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error); }
			}
				
            else
            {
				MessageBox.Show("Debe seleccionar un cliente primero", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}

		}

		private void ActualizarPrecioFinal()
        {
			PrecioFinalNum.Value = PrecioNum.Value + PrecioNum.Value * ((RecargoNum.Value - BonificacionNUM.Value)/100);
		}


		private DataTable Convert_to_DT(DataGridView cuadro)
		{
			//Creating DataTable.
			DataTable dt = new DataTable();
			//Adding the Columns.
			foreach (DataGridViewColumn column in cuadro.Columns)
			{
                //dt.Columns.Add(column.HeaderText, column.ValueType);
                dt.Columns.Add(column.HeaderText);
            }
            //Adding the Rows.
            foreach (DataGridViewRow row in cuadro.Rows)
            {
				if (row.Cells[1].Value != null)
                {
					dt.Rows.Add();
					foreach (DataGridViewCell cell in row.Cells)
					{
						dt.Rows[dt.Rows.Count - 1][cell.ColumnIndex] = cell.Value.ToString();
					}
				}
            }
            return dt;
		}

		void FacturarClick(object sender, EventArgs e)
        {
			if(Cuadro.Rows.Count > 1)
            {
				DialogResult result = MessageBox.Show("¿Desea confirmar la operación?", "Emisión de comprobantes", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
				switch (result)
				{
					case DialogResult.Yes:
						if (Conexion.Validar(UsuarioCBX.Text))
						{
							dt = Convert_to_DT(Cuadro);
							Conexion.AgregarFactura(SubTotalNUM.Value, TotalRecargo.Value, TotalNUM.Value, cliente.ID, Cliente.Text, Direccion.Text, Localidad.Text, cliente.CP, "Rodrigo", Convert_to_DT(Cuadro),(int)MediosPagoCBX.SelectedValue);
                            if (ImprimeChek.Checked)
                            {
								comprobante = Conexion.GetUltimoComprobante();
								ImprimirComprobante(sender, e);
								ImprimirDuplicado(sender, e);
							}

							LimpiarCliente();
                            LimpiarArticulo();
							bloquearModificacion();

						}
                        else { MessageBox.Show("Ingrese un usuario y contraseña válido"); }

						break;
					case DialogResult.No:
						break;
				}
			}
            else { MessageBox.Show("No ingreso ningun artículo", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }
		}

		void SalirClick(object sender, EventArgs e)
		{ this.Close(); }



		void LimpiarClick(object sender, EventArgs e)
		{
			Cuadro.Rows.Clear();
			ActualizaSubTotal();
			LimpiarArticulo();
		}


		private void factura_Load(object sender, EventArgs e)
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

			// COMBOBOX MEDIO DE PAGO
			MySqlDataReader reader2;
			string consulta2 = "Select id,recargo,descripcion From medioDePago a order by a.numero";

			try
			{
				MySqlCommand comand = new MySqlCommand(consulta2, conectar);
				reader2 = comand.ExecuteReader();
				DataTable dt = new DataTable();
				dt.Load(reader2);
				MediosPagoCBX.DataSource = dt;
				MediosPagoCBX.DisplayMember = "descripcion";
				MediosPagoCBX.ValueMember = "id";

			}
			catch (MySqlException ex) { MessageBox.Show("Error al buscar " + ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error); }
			finally { conectar.Close(); }

			UsuarioCBX.Text = usuario.User;
			RecFinanNum.Value = Conexion.obtenerRecargoFinanciero((int)MediosPagoCBX.SelectedValue);
			splitContainer2.Panel1.Focus();
			NumCliTXT.Focus();

		}
		
        private void button1_Click(object sender, EventArgs e)
        {
			cliente = Conexion.ObtenerClientePorNumero(NumCliTXT.Text);
            if (cliente == null)
            {
				cliente = Conexion.ObtenerCliente(NumCliTXT.Text);

				if (cliente != null)
				{
					NumCliTXT.Text = cliente.Numero.ToString();
					Cliente.Text = cliente.Alias;
					Direccion.Text = cliente.Direccion;
					Localidad.Text = cliente.Ciudad;
					Telefono.Text = cliente.Telefono1;
					Telefono2.Text = cliente.Telefono2;
					BonificacionNUM.Value = cliente.Bonificacion;
					RecargoNum.Value = cliente.Recargo;
				}

			}
            else
            {
				NumCliTXT.Text = cliente.Numero.ToString();
				Cliente.Text = cliente.Alias;
				Direccion.Text = cliente.Direccion;
				Localidad.Text = cliente.Ciudad;
				Telefono.Text = cliente.Telefono1;
				Telefono2.Text = cliente.Telefono2;
				BonificacionNUM.Value = cliente.Bonificacion;
				RecargoNum.Value = cliente.Recargo;

			}




        }

		private void LimpiarCliente()
        {
			Cliente.Text = "";
			Direccion.Text = "";
			Localidad.Text = "";
			Telefono.Text = "";
			Telefono2.Text = "";
			BonificacionNUM.Value = 0;
			RecargoNum.Value = 0;
			Cuadro.Rows.Clear();
		}

        private void NumCliTXT_TextChanged(object sender, EventArgs e)
        {
			LimpiarCliente();
			LimpiarArticulo();
			bloquearModificacion();
		}

		private void LimpiarArticulo()
        {
			txtDescripcion.Text = "";
			PrecioNum.Value = 0;
			PrecioFinalNum.Value = 0;
			cant.Value = 0;
        }

        private void txtCodigo_TextChanged(object sender, EventArgs e)
        {
			LimpiarArticulo();
		}

        private void PrecioNum_ValueChanged(object sender, EventArgs e)
        {
			ActualizarPrecioFinal();
		}

        private void BonificacionNUM_ValueChanged(object sender, EventArgs e)
        {
			ActualizarPrecioFinal();
		}

        private void PrecioFinalNum_ValueChanged(object sender, EventArgs e)
        {

        }

        private void RecargoNum_ValueChanged(object sender, EventArgs e)
        {
			ActualizarPrecioFinal();
		}

        private void SubTotalNUM_ValueChanged(object sender, EventArgs e)
        {

			TotalRecargo.Value = SubTotalNUM.Value * (RecFinanNum.Value/100);
			TotalNUM.Value = SubTotalNUM.Value + TotalRecargo.Value;
        }

		private void bloquearModificacion()
        {
			BonificacionNUM.Increment = 0;
			BonificacionNUM.ReadOnly = true;
			RecargoNum.Increment = 0;
			RecargoNum.ReadOnly = true;
		}

        private void CambiaBon_Click(object sender, EventArgs e)
        {
            if (Conexion.Validar("Administrador"))
            {
				BonificacionNUM.Increment = 1;
				BonificacionNUM.ReadOnly = false;
            }
            else { MessageBox.Show("Necesita permiso del Administrador"); }
        }

        private void CambiaRec_Click(object sender, EventArgs e)
        {
			if (Conexion.Validar("Administrador"))
			{
				RecargoNum.Increment = 1;
				RecargoNum.ReadOnly = false;
			}
			else { MessageBox.Show("Necesita permiso del Administrador"); }
		}

        private void MediosPagoCBX_SelectionChangeCommitted(object sender, EventArgs e)
        {
			RecFinanNum.Value = Conexion.obtenerRecargoFinanciero((int)MediosPagoCBX.SelectedValue);
		}

        private void RecFinanNum_ValueChanged(object sender, EventArgs e)
        {
			SubTotalNUM_ValueChanged(sender, e);

		}




		private void ImprimirComprobante(object sender, EventArgs e)
		{
			printDocument1 = new PrintDocument();
			PrinterSettings ps = new PrinterSettings();
			PaperSize A4 = new PaperSize();
			A4.RawKind = (int)PaperKind.A4;
			ps.DefaultPageSettings.PaperSize = A4;
			printDocument1.PrinterSettings = ps;
			printDocument1.PrintPage += imprimir;
			printDocument1.Print();

		}
		private void ImprimirDuplicado(object sender, EventArgs e)
		{
			printDocument1 = new PrintDocument();
			PrinterSettings ps = new PrinterSettings();
			PaperSize A4 = new PaperSize();
			A4.RawKind = (int)PaperKind.A4;
			ps.DefaultPageSettings.PaperSize = A4;
			printDocument1.PrinterSettings = ps;
			printDocument1.PrintPage += imprimirduplicado;
			printDocument1.Print();

		}
		DataTable dt = null;

		private void imprimir(object sender, PrintPageEventArgs e)
		{
			//Parametros
			Font Arial10 = new Font("Arial", 10, FontStyle.Regular);
			Font Arial12 = new Font("Arial", 12, FontStyle.Regular);
			Font ArialB14 = new Font("Arial Black", 14, FontStyle.Regular);
			Font ArialB12 = new Font("Arial Black", 12, FontStyle.Regular);
			Pen lineaFina = new Pen(Color.Black, 1);
			Pen lineaGruesa = new Pen(Color.Black, 3);
			int x0 = 40;
			int y0 = 40;
			int xfin = 745;
			int yfin = 1090;

			//Estructura lineas gruesas
			e.Graphics.DrawRectangle(lineaGruesa, new Rectangle(x0, y0, xfin, yfin));
			e.Graphics.DrawRectangle(lineaGruesa, new Rectangle(x0, 280, xfin, 40));
			e.Graphics.DrawRectangle(lineaGruesa, new Rectangle(x0, 280, 80, 544));
			e.Graphics.DrawRectangle(lineaGruesa, new Rectangle(120, 280, 420, 544));
			e.Graphics.DrawRectangle(lineaGruesa, new Rectangle(540, 280, 120, 544));
			e.Graphics.DrawRectangle(lineaGruesa, new Rectangle(660, 280, xfin - 620, 544));
			e.Graphics.DrawRectangle(lineaGruesa, new Rectangle(660, 824, xfin - 620, 40));
			e.Graphics.DrawRectangle(lineaGruesa, new Rectangle(660, 864, xfin - 620, 40));
			e.Graphics.DrawRectangle(lineaGruesa, new Rectangle(660, 904, xfin - 620, 40));

			//Estructuras lineas finas
			int lineaInicial = 344;
			for (int x = 0; x < 21; x++)
			{
				e.Graphics.DrawLine(lineaFina, x0, lineaInicial, xfin - x0 + 80, lineaInicial);
				lineaInicial += 24;
			}
			e.Graphics.DrawLine(lineaFina, x0 + 40, yfin - 40, x0 + 200, yfin - 40);

			//Logo
			Rectangle rect15 = new Rectangle(45, 60, 270, 90);
			string ruta = Conexion.rutaImagenLogo("Logo");
			try
			{
				Image logo = Image.FromFile(ruta);
				e.Graphics.DrawImage(logo, rect15);
			}
			catch (Exception) { }

			//Texto estatico
			e.Graphics.DrawString("Recibí Conforme", Arial10, Brushes.Black, x0 + 70, yfin - 40);
			e.Graphics.DrawString("*Los trabajos de reparación y colocación de repuestos tienen un limite de 15 dias para retirarlos.", Arial10, Brushes.Black, x0 +5, yfin - 5);
			e.Graphics.DrawString("Pasado ese tiempo NO SE ACEPTAN RECLAMOS.", Arial10, Brushes.Black, x0 + 5, 1110);
			e.Graphics.DrawString("Cantidad", Arial10, Brushes.Black, x0 + 10, 295);
			e.Graphics.DrawString("Descripción", Arial10, Brushes.Black, x0 + 90, 295);
			e.Graphics.DrawString("Precio", Arial10, Brushes.Black, x0 + 510, 295);
			e.Graphics.DrawString("Importe", Arial10, Brushes.Black, x0 + 630, 295);
			e.Graphics.DrawString("Documento no válido como factura", Arial10, Brushes.Black, 560, 98);
			e.Graphics.DrawString("Original", Arial10, Brushes.Black, xfin-40, 20);

			//agregar la fecha y n° de comprobante desde el parametro
			e.Graphics.DrawString("Fecha: "+comprobante.FechaHora.ToString("dd/MM/yyyy"), Arial12, Brushes.Black, 630, 50);
			e.Graphics.DrawString("Comprobante n°: "+comprobante.Numero.ToString().PadLeft(8, '0'), Arial12, Brushes.Black, 565, 74);
			e.Graphics.DrawString("Sub-Total", ArialB12, Brushes.Black, x0 + 520, 830);
			e.Graphics.DrawString("$"+comprobante.SubTotal.ToString(), Arial10, Brushes.Black, x0 + 628, 832);
			e.Graphics.DrawString("Finaciación", ArialB12, Brushes.Black, x0 + 500, 870);
			e.Graphics.DrawString("$" + comprobante.Financiación.ToString(), Arial10, Brushes.Black, x0 + 628, 872);
			e.Graphics.DrawString("Total", ArialB12, Brushes.Black, x0 + 555, 910);
			e.Graphics.DrawString("$" + comprobante.Total.ToString(), Arial10, Brushes.Black, x0 + 628, 912);

			//Agregar Datos del cliente
			e.Graphics.DrawString(cliente.Alias.ToUpper(), ArialB12, Brushes.Black, 64, 165);
			e.Graphics.DrawString(cliente.Direccion, Arial12, Brushes.Black, 64, 197);
			e.Graphics.DrawString(cliente.Ciudad, Arial12, Brushes.Black, 64, 221);
			e.Graphics.DrawString(cliente.Telefono1+"  "+cliente.Telefono2, Arial12, Brushes.Black, 64, 245);
			int cantidadArticulos = 0;
			int altura = 325;
			foreach(DataRow x in dt.Rows)
            {
				e.Graphics.DrawString(x[3].ToString(), Arial10, Brushes.Black, x0 + 30, altura);
				cantidadArticulos += int.Parse(x[3].ToString());
				e.Graphics.DrawString((string)x[2], Arial10, Brushes.Black, x0 + 80, altura);
				e.Graphics.DrawString("$"+(Math.Round(decimal.Parse(x[4].ToString()),2)).ToString(), Arial10, Brushes.Black, x0 + 505, altura);
				e.Graphics.DrawString("$"+(Math.Round(decimal.Parse(x[5].ToString()), 2)).ToString(), Arial10, Brushes.Black, x0 + 625, altura);
				altura += 24;
			}
			e.Graphics.DrawString("Total de artículos:  "+cantidadArticulos.ToString(), Arial10, Brushes.Black, x0 + 40, yfin - 120);

		}
		private void imprimirduplicado(object sender, PrintPageEventArgs e)
		{
			//Parametros
			Font Arial10 = new Font("Arial", 10, FontStyle.Regular);
			Font Arial12 = new Font("Arial", 12, FontStyle.Regular);
			Font ArialB14 = new Font("Arial Black", 14, FontStyle.Regular);
			Font ArialB12 = new Font("Arial Black", 12, FontStyle.Regular);
			Pen lineaFina = new Pen(Color.Black, 1);
			Pen lineaGruesa = new Pen(Color.Black, 3);
			int x0 = 40;
			int y0 = 40;
			int xfin = 745;
			int yfin = 1090;

			//Estructura lineas gruesas
			e.Graphics.DrawRectangle(lineaGruesa, new Rectangle(x0, y0, xfin, yfin));
			e.Graphics.DrawRectangle(lineaGruesa, new Rectangle(x0, 280, xfin, 40));
			e.Graphics.DrawRectangle(lineaGruesa, new Rectangle(x0, 280, 80, 544));
			e.Graphics.DrawRectangle(lineaGruesa, new Rectangle(120, 280, 420, 544));
			e.Graphics.DrawRectangle(lineaGruesa, new Rectangle(540, 280, 120, 544));
			e.Graphics.DrawRectangle(lineaGruesa, new Rectangle(660, 280, xfin - 620, 544));
			e.Graphics.DrawRectangle(lineaGruesa, new Rectangle(660, 824, xfin - 620, 40));
			e.Graphics.DrawRectangle(lineaGruesa, new Rectangle(660, 864, xfin - 620, 40));
			e.Graphics.DrawRectangle(lineaGruesa, new Rectangle(660, 904, xfin - 620, 40));

			//Estructuras lineas finas
			int lineaInicial = 344;
			for (int x = 0; x < 21; x++)
			{
				e.Graphics.DrawLine(lineaFina, x0, lineaInicial, xfin - x0 + 80, lineaInicial);
				lineaInicial += 24;
			}
			e.Graphics.DrawLine(lineaFina, x0 + 40, yfin - 40, x0 + 200, yfin - 40);

			//Logo
			Rectangle rect15 = new Rectangle(45, 60, 270, 90);
			string ruta = Conexion.rutaImagenLogo("Logo");
			try
			{
				Image logo = Image.FromFile(ruta);
				e.Graphics.DrawImage(logo, rect15);
			}
			catch (Exception) { }

			//Texto estatico
			e.Graphics.DrawString("Recibí Conforme", Arial10, Brushes.Black, x0 + 70, yfin - 40);
			e.Graphics.DrawString("*Los trabajos de reparación y colocación de repuestos tienen un limite de 15 dias para retirarlos.", Arial10, Brushes.Black, x0 + 5, yfin - 5);
			e.Graphics.DrawString("Pasado ese tiempo NO SE ACEPTAN RECLAMOS.", Arial10, Brushes.Black, x0 + 5, 1110);
			e.Graphics.DrawString("Cantidad", Arial10, Brushes.Black, x0 + 10, 295);
			e.Graphics.DrawString("Descripción", Arial10, Brushes.Black, x0 + 90, 295);
			e.Graphics.DrawString("Precio", Arial10, Brushes.Black, x0 + 510, 295);
			e.Graphics.DrawString("Importe", Arial10, Brushes.Black, x0 + 630, 295);
			e.Graphics.DrawString("Documento no válido como factura", Arial10, Brushes.Black, 560, 98);
			e.Graphics.DrawString("Duplicado", Arial10, Brushes.Black, xfin - 40, 20);

			//agregar la fecha y n° de comprobante desde el parametro
			e.Graphics.DrawString("Fecha: " + comprobante.FechaHora.ToString("dd/MM/yyyy"), Arial12, Brushes.Black, 630, 50);
			e.Graphics.DrawString("Comprobante n°: " + comprobante.Numero.ToString().PadLeft(8, '0'), Arial12, Brushes.Black, 565, 74);
			e.Graphics.DrawString("Sub-Total", ArialB12, Brushes.Black, x0 + 520, 830);
			e.Graphics.DrawString("$" + comprobante.SubTotal.ToString(), Arial10, Brushes.Black, x0 + 628, 832);
			e.Graphics.DrawString("Finaciación", ArialB12, Brushes.Black, x0 + 500, 870);
			e.Graphics.DrawString("$" + comprobante.Financiación.ToString(), Arial10, Brushes.Black, x0 + 628, 872);
			e.Graphics.DrawString("Total", ArialB12, Brushes.Black, x0 + 555, 910);
			e.Graphics.DrawString("$" + comprobante.Total.ToString(), Arial10, Brushes.Black, x0 + 628, 912);

			//Agregar Datos del cliente
			e.Graphics.DrawString(cliente.Alias.ToUpper(), ArialB12, Brushes.Black, 64, 165);
			e.Graphics.DrawString(cliente.Direccion, Arial12, Brushes.Black, 64, 197);
			e.Graphics.DrawString(cliente.Ciudad, Arial12, Brushes.Black, 64, 221);
			e.Graphics.DrawString(cliente.Telefono1 + "  " + cliente.Telefono2, Arial12, Brushes.Black, 64, 245);
			int cantidadArticulos = 0;
			int altura = 325;
			foreach (DataRow x in dt.Rows)
			{
				e.Graphics.DrawString(x[3].ToString(), Arial10, Brushes.Black, x0 + 30, altura);
				cantidadArticulos += int.Parse(x[3].ToString());
				e.Graphics.DrawString((string)x[2], Arial10, Brushes.Black, x0 + 80, altura);
				e.Graphics.DrawString("$" + (Math.Round(decimal.Parse(x[4].ToString()), 2)).ToString(), Arial10, Brushes.Black, x0 + 505, altura);
				e.Graphics.DrawString("$" + (Math.Round(decimal.Parse(x[5].ToString()), 2)).ToString(), Arial10, Brushes.Black, x0 + 625, altura);
				altura += 24;
			}
			e.Graphics.DrawString("Total de artículos:  " + cantidadArticulos.ToString(), Arial10, Brushes.Black, x0 + 40, yfin - 120);

		}

        private void button2_Click(object sender, EventArgs e)
        {
			if (Conexion.Validar("Administrador"))
			{
				PrecioNum.Increment = 1;
				PrecioNum.ReadOnly = false;
			}
			else { MessageBox.Show("Necesita permiso del Administrador"); }
		}



        private void txtCodigo_TextChanged_2(object sender, EventArgs e)
        {
			LimpiarArticulo();
		}

        private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                BuscarClick(sender, e);
				cant.Value = 1;
				agregarClick(sender, e);


			}
        }

        private void EmisionComprobantes_KeyPress(object sender, KeyPressEventArgs e)
        {


			
		}
    }
}
