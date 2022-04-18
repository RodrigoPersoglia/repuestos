using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Data;

namespace Login
{
	public partial class ReporteMovimientos : Form
	{

		public ReporteMovimientos()
		{
			InitializeComponent();
		}

		//Muestra en el cuadro las coincidencias
		void BuscarClick(object sender, EventArgs e)
		{
            DataTable dt2 = Conexion.ObtenerReporteMovimietos(Fecha1DTP.Value, Fecha2DTP.Value);
            Cuadro.Rows.Clear();
            if (dt2 != null)
            {

                foreach (DataRow x in dt2.Rows)
                {
                    int n = Cuadro.Rows.Add();

                    Cuadro.Rows[n].Cells[0].Value = true;
					DateTime fecha = (DateTime)x[0];
					string fecha1 = fecha.ToString("dd/MM/yyyy");
					fecha1.Replace("/", "-");
					Cuadro.Rows[n].Cells[1].Value = fecha1;

					Cuadro.Rows[n].Cells[2].Value = (string)x[1];
					Cuadro.Rows[n].Cells[3].Value = (string)x[2];
					Cuadro.Rows[n].Cells[4].Value = (int)x[3];
					Cuadro.Rows[n].Cells[5].Value = (string)x[4];
					Cuadro.Rows[n].Cells[6].Value = (string)x[5];
					Cuadro.Rows[n].Cells[7].Value = (string)x[6];

                }

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
			try
            {
				if ((bool)Cuadro.Rows[n].Cells[0].Value == true) { Cuadro.Rows[n].Cells[0].Value = false; }
				else
				{
					Cuadro.Rows[n].Cells[0].Value = true;
				}

			}
            catch (Exception) { }


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



        private void ReporteMovimientos_Load(object sender, EventArgs e)
        {
			Fecha1DTP.Value = new DateTime(DateTime.Now.Year, DateTime.Today.Month, 1);
			Fecha2DTP.Value = DateTime.Today;
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