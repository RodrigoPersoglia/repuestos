using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Data;
using System.Drawing.Printing;

namespace Login
{
	public partial class ReporteEmision : Form
	{
		string usuario;
		private Comprobante comprobante = new Comprobante();
		private Cliente cliente = new Cliente();
		DataTable dt;
		public ReporteEmision()
		{
			InitializeComponent();
		}

		public ReporteEmision(string user)
		{
			usuario = user;
			InitializeComponent();
		}

		decimal ImporteAcumulado = 0;


		//Muestra en el cuadro las coincidencias
		void BuscarClick(object sender, EventArgs e)
		{
			bool estado = true;
            switch (EstadoCBX.Text)
            {
				case "Anuladas": estado = false; break;
				case "Activas": estado = true;break;
			}


			ImporteAcumulado = 0;
			//completo el cuadro
			DataTable dt2 = Conexion.ObtenerReporteEmision(estado,Fecha1DTP.Value, Fecha2DTP.Value);
			Cuadro.Rows.Clear();

			if (dt2 != null)
			{

                foreach (DataRow x in dt2.Rows)
                {
                    int n = Cuadro.Rows.Add();

					Cuadro.Rows[n].Cells[0].Value = false;
					DateTime fecha = (DateTime)x[0];
					string fecha1 = fecha.ToString("dd/MM/yyyy");
					fecha1.Replace("/", "-");
					Cuadro.Rows[n].Cells[1].Value = fecha1;
					Cuadro.Rows[n].Cells[2].Value = (int)x[1];
					Cuadro.Rows[n].Cells[3].Value = (string)x[2];
					Cuadro.Rows[n].Cells[4].Value = (decimal)x[3];
					ImporteAcumulado +=(decimal)x[3];
					Cuadro.Rows[n].Cells[5].Value = (string)x[4];
					Cuadro.Rows[n].Cells[6].Value = (string)x[5];



                }

                ImporteTXT.Text = ImporteAcumulado.ToString();





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
			n = e.RowIndex;
			if ((bool)Cuadro.Rows[n].Cells[0].Value == true) {   Cuadro.Rows[n].Cells[0].Value = false; }
			else {
				Cuadro.Rows[n].Cells[0].Value = true; }

		}
		private void Cuadro_CellClick(object sender, DataGridViewCellEventArgs e)
		{

        }


		private void Cancelar_Click(object sender, EventArgs e)
        {
			this.Close();
        }

        private void Exportarboton_Click(object sender, EventArgs e)
        {
			Exportar.Exportar2(Cuadro);

        }



        private void ReporteEmision_Load(object sender, EventArgs e)
        {
			Fecha1DTP.Value = new DateTime(DateTime.Now.Year, DateTime.Today.Month, 1);
			Fecha2DTP.Value = DateTime.Today;
			EstadoCBX.Text = "Activas";
		}







		private void Cuadro_SelectionChanged(object sender, EventArgs e)
        {


		}

        private void Ignorar_Chek_CheckedChanged(object sender, EventArgs e)
        {
			Cuadro.Rows.Clear();
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

		private void imprimir(object sender, PrintPageEventArgs e)
		{
			//Parametros
			Font Arial8 = new Font("Arial", 8, FontStyle.Regular);
			Font Arial10 = new Font("Arial", 10, FontStyle.Regular);
			Font Arial12 = new Font("Arial", 12, FontStyle.Regular);
			Font ArialB14 = new Font("Arial Black", 14, FontStyle.Regular);
			Font ArialB12 = new Font("Arial Black", 12, FontStyle.Regular);
			Pen lineaFina = new Pen(Color.Black, 1);
			Pen lineaGruesa = new Pen(Color.Black, 3);
			int x0 = 40;
			int xfin = 745;
			e.Graphics.DrawLine(lineaFina, x0, 600, xfin+x0, 600);

			//Estructura lineas gruesas
			e.Graphics.DrawRectangle(lineaGruesa, new Rectangle(x0, 205, xfin, 40));
			e.Graphics.DrawRectangle(lineaGruesa, new Rectangle(x0, 205, 80, 280));
			e.Graphics.DrawRectangle(lineaGruesa, new Rectangle(120, 205, 420, 280));
			e.Graphics.DrawRectangle(lineaGruesa, new Rectangle(540, 205, 120, 280));
			e.Graphics.DrawRectangle(lineaGruesa, new Rectangle(660, 205, xfin - 620, 280));

			//Estructuras lineas finas
			int lineaInicial = 269;
			for (int x = 0; x < 9; x++)
			{
				e.Graphics.DrawLine(lineaFina, x0, lineaInicial, xfin - x0 + 80, lineaInicial);
				lineaInicial += 24;
			}

			//Logo
			Rectangle rect15 = new Rectangle(x0, 15, 270, 90);
			string ruta = Conexion.rutaImagenLogo("Logo");
			try
			{
				Image logo = Image.FromFile(ruta);
				e.Graphics.DrawImage(logo, rect15);
			}
			catch (Exception) { }

			//Texto estatico
			e.Graphics.DrawString("*Los trabajos de reparación y colocación de repuestos tienen un limite de 15 dias", Arial8, Brushes.Black, x0 + 5, 525);
			e.Graphics.DrawString("para retirarlos. Pasado ese tiempo NO SE ACEPTAN RECLAMOS.", Arial8, Brushes.Black, x0 + 5, 537);
			e.Graphics.DrawString("Cantidad", Arial10, Brushes.Black, x0 + 10, 220);
			e.Graphics.DrawString("Descripción", Arial10, Brushes.Black, x0 + 90, 220);
			e.Graphics.DrawString("Precio", Arial10, Brushes.Black, x0 + 510, 220);
			e.Graphics.DrawString("Importe", Arial10, Brushes.Black, x0 + 630, 220);
			e.Graphics.DrawString("Documento no válido como factura", Arial10, Brushes.Black, 560, 58);


			//agregar la fecha y n° de comprobante desde el parametro
			e.Graphics.DrawString("Fecha: " + comprobante.FechaHora.ToString("dd/MM/yyyy"), Arial12, Brushes.Black, 630, 10);
			e.Graphics.DrawString("Comprobante n°: " + comprobante.Numero.ToString().PadLeft(8, '0'), Arial12, Brushes.Black, 565, 34);
			
			e.Graphics.DrawString("Sub-Total:", ArialB12, Brushes.Black, x0 + 520, 495);
			e.Graphics.DrawString("$" + comprobante.SubTotal.ToString(), Arial10, Brushes.Black, x0 + 628, 497);
			e.Graphics.DrawString("Finaciación:", ArialB12, Brushes.Black, x0 + 500, 515);
			e.Graphics.DrawString("$" + comprobante.Financiación.ToString(), Arial10, Brushes.Black, x0 + 628, 517);
			e.Graphics.DrawString("Total:", ArialB12, Brushes.Black, x0 + 555, 535);
			e.Graphics.DrawString("$" + comprobante.Total.ToString(), Arial10, Brushes.Black, x0 + 628, 537);

			//Agregar Datos del cliente
			e.Graphics.DrawString(cliente.Alias.ToUpper(), ArialB12, Brushes.Black, x0, 110);
			e.Graphics.DrawString(cliente.Direccion, Arial12, Brushes.Black, x0, 135);
			e.Graphics.DrawString(cliente.Ciudad, Arial12, Brushes.Black, x0, 155);
			e.Graphics.DrawString(cliente.Telefono1 + "  " + cliente.Telefono2, Arial12, Brushes.Black, x0, 175);
			int cantidadArticulos = 0;
			int altura = 250;
			foreach (DataRow x in dt.Rows)
			{
				e.Graphics.DrawString(x[3].ToString(), Arial10, Brushes.Black, x0 + 30, altura);
				cantidadArticulos += int.Parse(x[3].ToString());
				e.Graphics.DrawString((string)x[2], Arial10, Brushes.Black, x0 + 80, altura);
				e.Graphics.DrawString("$" + (Math.Round(decimal.Parse(x[4].ToString()), 2)).ToString(), Arial10, Brushes.Black, x0 + 505, altura);
				e.Graphics.DrawString("$" + (Math.Round(decimal.Parse(x[4].ToString())* decimal.Parse(x[3].ToString()), 2)).ToString(), Arial10, Brushes.Black, x0 + 625, altura);
				altura += 24;
			}
			e.Graphics.DrawString("Total de artículos:  " + cantidadArticulos.ToString(), Arial10, Brushes.Black, x0 + 10, 495);

			//segunda parte *****************************************************************
			int diferencia = 560;

			e.Graphics.DrawRectangle(lineaGruesa, new Rectangle(x0, 245+diferencia, xfin, 40));
			e.Graphics.DrawRectangle(lineaGruesa, new Rectangle(x0, 245 + diferencia, 80, 280));
			e.Graphics.DrawRectangle(lineaGruesa, new Rectangle(120, 245 + diferencia, 420, 280));
			e.Graphics.DrawRectangle(lineaGruesa, new Rectangle(540, 245 + diferencia, 120, 280));
			e.Graphics.DrawRectangle(lineaGruesa, new Rectangle(660, 245 + diferencia, xfin - 620, 280));

			//Estructuras lineas finas
			lineaInicial = 309 + diferencia;
			for (int x = 0; x < 9; x++)
			{
				e.Graphics.DrawLine(lineaFina, x0, lineaInicial, xfin - x0 + 80, lineaInicial);
				lineaInicial += 24;
			}


			//Logo
			rect15 = new Rectangle(x0, 55 + diferencia, 270, 90);
		
			try
			{
				Image logo = Image.FromFile(ruta);
				e.Graphics.DrawImage(logo, rect15);
			}
			catch (Exception) { }

			//Texto estatico
			e.Graphics.DrawString("*Los trabajos de reparación y colocación de repuestos tienen un limite de 15 dias", Arial8, Brushes.Black, x0 + 5, 565 + diferencia);
			e.Graphics.DrawString("para retirarlos. Pasado ese tiempo NO SE ACEPTAN RECLAMOS.", Arial8, Brushes.Black, x0 + 5, 577 + diferencia);

			e.Graphics.DrawString("Cantidad", Arial10, Brushes.Black, x0 + 10, 260 + diferencia);
			e.Graphics.DrawString("Descripción", Arial10, Brushes.Black, x0 + 90, 260 + diferencia);
			e.Graphics.DrawString("Precio", Arial10, Brushes.Black, x0 + 510, 260 + diferencia);
			e.Graphics.DrawString("Importe", Arial10, Brushes.Black, x0 + 630, 260 + diferencia);
			e.Graphics.DrawString("Documento no válido como factura", Arial10, Brushes.Black, 560, 98 + diferencia);

			//agregar la fecha y n° de comprobante desde el parametro
			e.Graphics.DrawString("Fecha: " + comprobante.FechaHora.ToString("dd/MM/yyyy"), Arial12, Brushes.Black, 630, 50 + diferencia);
			e.Graphics.DrawString("Comprobante n°: " + comprobante.Numero.ToString().PadLeft(8, '0'), Arial12, Brushes.Black, 565, 74 + diferencia);

			e.Graphics.DrawString("Sub-Total:", ArialB12, Brushes.Black, x0 + 520, 535 + diferencia);
			e.Graphics.DrawString("$" + comprobante.SubTotal.ToString(), Arial10, Brushes.Black, x0 + 628, 537 + diferencia);
			e.Graphics.DrawString("Finaciación:", ArialB12, Brushes.Black, x0 + 500, 555 + diferencia);
			e.Graphics.DrawString("$" + comprobante.Financiación.ToString(), Arial10, Brushes.Black, x0 + 628, 557 + diferencia);
			e.Graphics.DrawString("Total:", ArialB12, Brushes.Black, x0 + 555, 575 + diferencia);
			e.Graphics.DrawString("$" + comprobante.Total.ToString(), Arial10, Brushes.Black, x0 + 628, 577 + diferencia);

			//Agregar Datos del cliente
			e.Graphics.DrawString(cliente.Alias.ToUpper(), ArialB12, Brushes.Black, x0, 150 + diferencia);
			e.Graphics.DrawString(cliente.Direccion, Arial12, Brushes.Black, x0, 175 + diferencia);
			e.Graphics.DrawString(cliente.Ciudad, Arial12, Brushes.Black, x0, 195 + diferencia);
			e.Graphics.DrawString(cliente.Telefono1 + "  " + cliente.Telefono2, Arial12, Brushes.Black, x0, 215 + diferencia);
			cantidadArticulos = 0;
			altura = 290 + diferencia;
			foreach (DataRow x in dt.Rows)
			{
				e.Graphics.DrawString(x[3].ToString(), Arial10, Brushes.Black, x0 + 30, altura);
				cantidadArticulos += int.Parse(x[3].ToString());
				e.Graphics.DrawString((string)x[2], Arial10, Brushes.Black, x0 + 80, altura);
				e.Graphics.DrawString("$" + (Math.Round(decimal.Parse(x[4].ToString()), 2)).ToString(), Arial10, Brushes.Black, x0 + 505, altura);
				e.Graphics.DrawString("$" + (Math.Round(decimal.Parse(x[4].ToString()) * decimal.Parse(x[3].ToString()), 2)).ToString(), Arial10, Brushes.Black, x0 + 625, altura);
				altura += 24;
			}
			e.Graphics.DrawString("Total de artículos:  " + cantidadArticulos.ToString(), Arial10, Brushes.Black, x0 +10, 535 + diferencia);

		}

        private void Reimprimir_Click(object sender, EventArgs e)
        {
			try
			{
				for (int fila = 0; fila < Cuadro.Rows.Count; fila++)
				{
					if ((bool)Cuadro.Rows[fila].Cells[0].Value == true)
					{
						int numero = (int)Cuadro.Rows[fila].Cells[2].Value;
						comprobante = Conexion.GetComprobantePorNumero(numero);
						cliente = Conexion.ObtenerClientePorComprobante(numero);
						dt = Conexion.ObtenerDetalleComprobante(numero);
						if(comprobante!=null && cliente!=null && dt != null)
                        {
							ImprimirComprobante(sender, e);

						}

					}
				}


			}
			catch (Exception) { }
		}
	
    }
}