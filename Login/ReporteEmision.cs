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
			e.Graphics.DrawString("Original", Arial10, Brushes.Black, xfin - 40, 20);

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
				e.Graphics.DrawString("$" + (Math.Round(decimal.Parse(x[4].ToString())* decimal.Parse(x[3].ToString()), 2)).ToString(), Arial10, Brushes.Black, x0 + 625, altura);
				altura += 24;
			}
			e.Graphics.DrawString("Total de artículos:  " + cantidadArticulos.ToString(), Arial10, Brushes.Black, x0 + 40, yfin - 120);

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