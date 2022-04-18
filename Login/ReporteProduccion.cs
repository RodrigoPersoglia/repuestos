using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Data;

namespace Login
{
	public partial class ReporteProduccion : Form
	{
		string usuario;
		public ReporteProduccion()
		{
			InitializeComponent();
		}

		public ReporteProduccion(string user)
		{
			usuario = user;
			InitializeComponent();
		}

		double kgAcumulados = 0;

		
		//Muestra en el cuadro las coincidencias
		void BuscarClick(object sender, EventArgs e)
		{
			Cuadro2.Rows.Clear();
			kgAcumulados = 0;
			//completo el cuadro
			DataTable dt2 = Conexion.ObtenerReporteProdu(Fecha1DTP.Value, Fecha2DTP.Value);
				Cuadro.Rows.Clear();

				if (dt2 != null)
				{

					foreach (DataRow x in dt2.Rows)
					{
						int n = Cuadro.Rows.Add();
						Cuadro.Rows[n].Cells[0].Value = false;
						Cuadro.Rows[n].Cells[1].Value = ((DateTime)x[0]).ToString("dd-MM-yyyy");
						Cuadro.Rows[n].Cells[2].Value = ((decimal)x[1]).ToString();
						kgAcumulados += decimal.ToDouble((decimal)x[1]);


				}

					Acumulados.Text = kgAcumulados.ToString();

				}







		}
		
	
		
		
		// Devuelve el indice de la celda seleccionada
		int n;
		void Selecccioncelda(object sender, DataGridViewCellEventArgs e)
		{    


		}


		private void Cuadro_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
			n = e.RowIndex;

		}


		private double rendimiento(int diamTocho,double largo,int cantidad,double kgs)
		{
			try
			{
				double radioTocho = (diamTocho * 25.4) / 2;
				double largoBarrote = largo / 1000;
				double pesobarrote = Math.Round((radioTocho * radioTocho) * Math.PI / 1000 * 2.7 * largoBarrote, 2);
				double porcentaje = kgs / cantidad / pesobarrote * 100;
				return Math.Round(porcentaje,2);
			}
			catch (Exception)
			{
				return 0;
			}
		}

		private void limpiar2()
        {
			totalBarrotesTXT.Text = "";
			kgPrensaTXT.Text = "";
			kgDespachoTXT.Text = "";
			tochoHoraTXT.Text = "";
			kgHoraTXT.Text = "";
			TiempoTXT.Text = "";
		}

		private double TimeToDouble(TimeSpan tiempo)
        {
			double min = Math.Round(tiempo.Minutes/60.00,2);
			double hora = tiempo.Hours;
			double x = min + hora;
			return x;
        }

		private void Cuadro_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			limpiar2();
			int cantbarrotes = 0;
			double kgPrensa = 0;
			double kgDesacho = 0;
			TimeSpan tiempo = new TimeSpan(0, 0, 0);
			TimeSpan inicio = new TimeSpan(25, 0, 0);
			TimeSpan fin = new TimeSpan(0, 0, 0);
			n = e.RowIndex;
			if ((bool)Cuadro.Rows[n].Cells[0].Value == true)
			{
				Cuadro.Rows[n].Cells[0].Value = false;
				Cuadro.Rows[n].DefaultCellStyle.BackColor = Color.White;
				Cuadro2.Rows.Clear();
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
					Cuadro.Rows[n].DefaultCellStyle.BackColor = Color.Yellow;
					Cuadro.Rows[n].Cells[0].Value = true;
					//string seleccion = (string)Cuadro.Rows[n].Cells[1].Value;
					DateTime fecha = new DateTime(int.Parse(((string)Cuadro.Rows[n].Cells[1].Value).Substring(6, 4)), int.Parse(((string)Cuadro.Rows[n].Cells[1].Value).Substring(3, 2)), int.Parse(((string)Cuadro.Rows[n].Cells[1].Value).Substring(0, 2)));
					
					DataTable dt2 = Conexion.ObtenerReporteDiario(fecha);
					Cuadro2.Rows.Clear();

					if (dt2 != null)
					{
						TimeSpan horaFin, horaIn;


						foreach (DataRow x in dt2.Rows)
						{
						double rend = rendimiento((int)x[8], double.Parse(((int)x[6]).ToString()), (int)x[7], decimal.ToDouble((decimal)x[3]));
							int n = Cuadro2.Rows.Add();
							Cuadro2.Rows[n].Cells[0].Value = (int)x[0];
							Cuadro2.Rows[n].Cells[1].Value = (string)x[1];
							Cuadro2.Rows[n].Cells[2].Value = (string)x[2];
							Cuadro2.Rows[n].Cells[3].Value = ((decimal)x[5]).ToString();
							Cuadro2.Rows[n].Cells[4].Value = ((decimal)x[3]).ToString();
							
							Cuadro2.Rows[n].Cells[5].Value = rend;
							Cuadro2.Rows[n].Cells[6].Value = (string)x[4];

							cantbarrotes += (int)x[7];
							kgDesacho += decimal.ToDouble((decimal)x[3]);
							kgPrensa+= decimal.ToDouble((decimal)x[5]);

							if(fin< (TimeSpan)x[9])
                            {
								fin = (TimeSpan)x[9];

							}
							if (inicio > (TimeSpan)x[10])
							{
								inicio = (TimeSpan)x[10];
							}


							try
                            {
                                horaFin = (TimeSpan)x[9];
							}
                            catch (Exception) { horaFin = new TimeSpan(0, 0, 0); }

							try
							{
								horaIn = (TimeSpan)x[10];
							}
							catch (Exception) { horaIn = new TimeSpan(0, 0, 0); }


							tiempo+=(horaFin - horaIn);


						}
					}

					totalBarrotesTXT.Text = cantbarrotes.ToString();
					kgPrensaTXT.Text = kgPrensa.ToString();
					kgDespachoTXT.Text = kgDesacho.ToString();
					TiempoTXT.Text = tiempo.ToString();
					tochoHoraTXT.Text =(Math.Round( cantbarrotes / TimeToDouble(tiempo),2)).ToString();
					kgHoraTXT.Text = (Math.Round(kgDesacho / TimeToDouble(tiempo), 2)).ToString();
					TiempoParadaTXT.Text = ((fin - inicio) - tiempo).ToString();


				}

                catch (Exception) { }
            }
		}


		private void Cancelar_Click(object sender, EventArgs e)
        {
			this.Close();
        }

        private void Exportarboton_Click(object sender, EventArgs e)
        {
			Exportar.Exportar_Articulos(Cuadro);
        }



        private void ReporteProduccion_Load(object sender, EventArgs e)
        {
			Fecha1DTP.Value = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
			Fecha2DTP.Value = DateTime.Today;

		}







        private void Cuadro_SelectionChanged(object sender, EventArgs e)
        {


		}

        private void Ignorar_Chek_CheckedChanged(object sender, EventArgs e)
        {
			Cuadro.Rows.Clear();
        }

		int n2 = 0-1;
        private void Cuadro2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
			n2 = e.RowIndex;
			if (n2 != -1)
            {
				DialogResult result = MessageBox.Show("¿Desea ver el detalle de produccion del pedido " + (Cuadro2.Rows[n2].Cells[0].Value).ToString()+"?", "Reporte de Producción", MessageBoxButtons.YesNo,MessageBoxIcon.Question);

				switch (result)
				{
					case DialogResult.Yes:
						DetalleFabricacion detalleFabricacion = new DetalleFabricacion((Cuadro2.Rows[n2].Cells[0].Value).ToString());
						detalleFabricacion.MdiParent = this.MdiParent;
						detalleFabricacion.Show();
						break;
					case DialogResult.No:
						break;

				}

            }
		}
    }
}