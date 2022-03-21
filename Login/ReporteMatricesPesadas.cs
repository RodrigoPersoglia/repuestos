using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Data;

namespace Login
{
	public partial class ReporteMatricesPesadas : Form
	{
		string usuario;
		public ReporteMatricesPesadas()
		{
			InitializeComponent();
		}

		public ReporteMatricesPesadas(string user)
		{
			usuario = user;
			InitializeComponent();
		}

		double kgAcumulados = 0;

		
		//Muestra en el cuadro las coincidencias
		void BuscarClick(object sender, EventArgs e)
		{








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
			//if ((bool)Cuadro.Rows[n].Cells[0].Value == true) { kgAcumulados-=(double)Cuadro.Rows[n].Cells[15].Value; Acumulados.Text = kgAcumulados.ToString();  Cuadro.Rows[n].Cells[0].Value = false; }
			//else {
			//	kgAcumulados += (double)Cuadro.Rows[n].Cells[15].Value; Acumulados.Text = kgAcumulados.ToString();
			//	Cuadro.Rows[n].Cells[0].Value = true; }

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



        private void ReporteMatricesPesadas_Load(object sender, EventArgs e)
        {
			DataTable dt = Conexion.ReporteMatricesPesadas();
			Cuadro.Rows.Clear();
			if (dt != null)
			{
				foreach (DataRow x in dt.Rows)
				{
					int n = Cuadro.Rows.Add();
					Cuadro.Rows[n].Cells[0].Value = (int)x[0];
					Cuadro.Rows[n].Cells[1].Value = (string)x[1];
					Cuadro.Rows[n].Cells[2].Value = (string)x[2];
					Cuadro.Rows[n].Cells[3].Value = (string)x[3];
					Cuadro.Rows[n].Cells[4].Value = (int)x[4];
					Cuadro.Rows[n].Cells[5].Value = (decimal)x[5];
					Cuadro.Rows[n].Cells[6].Value = (decimal)x[6];
				}

			}

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