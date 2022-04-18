using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Data;

namespace Login
{
	public partial class ReporteStock : Form
	{
		string usuario;
		public ReporteStock()
		{
			InitializeComponent();
		}

		public ReporteStock(string user)
		{
			usuario = user;
			InitializeComponent();
		}

		decimal ImporteAcumulado = 0;


		//Muestra en el cuadro las coincidencias
		void BuscarClick(object sender, EventArgs e)
		{
			ImporteAcumulado = 0;
			//completo el cuadro
			DataTable dt2 = Conexion.ObtenerReporteStock();
			Cuadro.Rows.Clear();

			bool estado = true;
            switch (EstadoCBX.Text)
            {

				case "Sobre-stock":
					if (dt2 != null)
					{
						foreach (DataRow x in dt2.Rows)
						{
                            if (int.Parse(x[6].ToString())>0)
                            {
								int n = Cuadro.Rows.Add();
								Cuadro.Rows[n].Cells[0].Value = true;
								Cuadro.Rows[n].Cells[1].Value = (string)x[0];
								Cuadro.Rows[n].Cells[2].Value = (string)x[1];
								Cuadro.Rows[n].Cells[3].Value = (int)x[2];
								Cuadro.Rows[n].Cells[4].Value = (int)x[3];
								Cuadro.Rows[n].Cells[5].Value = (int)x[4];
								Cuadro.Rows[n].Cells[6].Value = int.Parse(x[5].ToString());
								Cuadro.Rows[n].Cells[7].Value = int.Parse(x[6].ToString());
								DateTime fecha = (DateTime)x[7];
								string fecha1 = fecha.ToString("dd/MM/yyyy");
								fecha1.Replace("/", "-");
								Cuadro.Rows[n].Cells[8].Value = fecha1;
								Cuadro.Rows[n].Cells[9].Value = (string)x[8];
							}
							
						}
					}
					PuntoPedido.Visible = false;
					StockMin.Visible = false;
					StockMax.Visible = true;
					SobreStock.Visible = true;
					this.Width = 689;
					Cancelar.Location = new Point(this.Width - 20 - Cancelar.Width,10);
					Exportarboton.Location = new Point(this.Width - 20 - Exportarboton.Width, 35);
					break;
				case "Faltantes":
					if (dt2 != null)
					{
						foreach (DataRow x in dt2.Rows)
						{
							if (int.Parse(x[5].ToString()) > 0)
							{
								int n = Cuadro.Rows.Add();
								Cuadro.Rows[n].Cells[0].Value = true;
								Cuadro.Rows[n].Cells[1].Value = (string)x[0];
								Cuadro.Rows[n].Cells[2].Value = (string)x[1];
								Cuadro.Rows[n].Cells[3].Value = (int)x[2];
								Cuadro.Rows[n].Cells[4].Value = (int)x[3];
								Cuadro.Rows[n].Cells[5].Value = (int)x[4];
								Cuadro.Rows[n].Cells[6].Value = int.Parse(x[5].ToString());
								Cuadro.Rows[n].Cells[7].Value = int.Parse(x[6].ToString());
								DateTime fecha = (DateTime)x[7];
								string fecha1 = fecha.ToString("dd/MM/yyyy");
								fecha1.Replace("/", "-");
								Cuadro.Rows[n].Cells[8].Value = fecha1;
								Cuadro.Rows[n].Cells[9].Value = (string)x[8];
							}

						}
					}

					PuntoPedido.Visible = true;
					StockMin.Visible = true;
					StockMax.Visible = false;
					SobreStock.Visible = false;
					this.Width = 689;
					Cancelar.Location = new Point(this.Width - 20 - Cancelar.Width, 10);
					Exportarboton.Location = new Point(this.Width - 20 - Exportarboton.Width, 35);

					break;
				default:
					if (dt2 != null)
					{
						foreach (DataRow x in dt2.Rows)
						{
							int n = Cuadro.Rows.Add();
							Cuadro.Rows[n].Cells[0].Value = true;
							Cuadro.Rows[n].Cells[1].Value = (string)x[0];
							Cuadro.Rows[n].Cells[2].Value = (string)x[1];
							Cuadro.Rows[n].Cells[3].Value = (int)x[2];
							Cuadro.Rows[n].Cells[4].Value = (int)x[3];
							Cuadro.Rows[n].Cells[5].Value = (int)x[4];
							Cuadro.Rows[n].Cells[6].Value = int.Parse(x[5].ToString());
							Cuadro.Rows[n].Cells[7].Value = int.Parse(x[6].ToString());
							DateTime fecha = (DateTime)x[7];
							string fecha1 = fecha.ToString("dd/MM/yyyy");
							fecha1.Replace("/", "-");
							Cuadro.Rows[n].Cells[8].Value = fecha1;
							Cuadro.Rows[n].Cells[9].Value = (string)x[8];
						}
					}
					PuntoPedido.Visible = true;
					StockMin.Visible = true;
					StockMax.Visible = true;
					SobreStock.Visible = true;
					this.Width = 809;
					Cancelar.Location = new Point(this.Width - 20 - Cancelar.Width, 10);
					Exportarboton.Location = new Point(this.Width - 20 - Exportarboton.Width, 35);

					break;

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
			Exportar.Exportar_Articulos(Cuadro);

        }



        private void ReporteStock_Load(object sender, EventArgs e)
        {
			EstadoCBX.Text = "Todos";
			Cancelar.Location = new Point(this.Width - 20 - Cancelar.Width, 10);
			Exportarboton.Location = new Point(this.Width - 20 - Exportarboton.Width, 35);
		}







		private void Cuadro_SelectionChanged(object sender, EventArgs e)
        {


		}

        private void Ignorar_Chek_CheckedChanged(object sender, EventArgs e)
        {
			Cuadro.Rows.Clear();
        }
    }
}