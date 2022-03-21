﻿using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Data;

namespace Login
{
	public partial class Proyeccion : Form
	{
		string usuario;
		public Proyeccion()
		{
			InitializeComponent();
		}

		public Proyeccion(string user)
		{
			usuario = user;
			InitializeComponent();
		}

		double kgAcumulados = 0;

		
		//Muestra en el cuadro las coincidencias
		void BuscarClick(object sender, EventArgs e)
		{

			if (Ignorar_Chek.Checked == false)
			{
				if (PrensaCBX.Text != "Todas")
				
				{

				
				kgAcumulados = 0;
				//completo el cuadro
				DataTable dt2 = Conexion.ObtenerProyeccion(Fecha1DTP.Value, (int)PrensaCBX.SelectedValue);
				Cuadro.Rows.Clear();

				if (dt2 != null)
				{

					foreach (DataRow x in dt2.Rows)
					{
						int n = Cuadro.Rows.Add();
						Cuadro.Rows[n].Cells[0].Value = true;
						Cuadro.Rows[n].Cells[1].Value = (int)x[0];
						Cuadro.Rows[n].Cells[2].Value = (int)x[1];
						DateTime fecha = (DateTime)x[2];
						string fecha1 = fecha.ToString("dd/MM/yyyy");
						fecha1.Replace("/", "-");

						Cuadro.Rows[n].Cells[3].Value = fecha1;
						DateTime fecha2 = (DateTime)x[15];
						Cuadro.Rows[n].Cells[4].Value = fecha2.ToString("dd/MM/yyyy");

						Cuadro.Rows[n].Cells[5].Value = (string)x[4];
						Cuadro.Rows[n].Cells[6].Value = (string)x[14];
						Cuadro.Rows[n].Cells[7].Value = (string)x[5];
						Cuadro.Rows[n].Cells[8].Value = decimal.ToDouble((decimal)x[13]);

						Cuadro.Rows[n].Cells[9].Value = (string)x[6];
						Cuadro.Rows[n].Cells[10].Value = (int)x[12];
						Cuadro.Rows[n].Cells[11].Value = (string)x[10];
						Cuadro.Rows[n].Cells[12].Value = (string)x[11];
						Cuadro.Rows[n].Cells[13].Value = (string)x[8];
						Cuadro.Rows[n].Cells[14].Value = (string)x[9];
						Cuadro.Rows[n].Cells[15].Value = decimal.ToDouble((decimal)x[3]);
						kgAcumulados += decimal.ToDouble((decimal)x[3]);
						Cuadro.Rows[n].Cells[16].Value = (string)x[7];



					}

					Acumulados.Text = kgAcumulados.ToString();

				}
                }
                else
                {
					kgAcumulados = 0;
					//completo el cuadro
					DataTable dt2 = Conexion.ObtenerProyeccion3(Fecha1DTP.Value, (int)PrensaCBX.SelectedValue);
					Cuadro.Rows.Clear();

					if (dt2 != null)
					{

						foreach (DataRow x in dt2.Rows)
						{
							int n = Cuadro.Rows.Add();
							Cuadro.Rows[n].Cells[0].Value = true;
							Cuadro.Rows[n].Cells[1].Value = (int)x[0];
							Cuadro.Rows[n].Cells[2].Value = (int)x[1];
							DateTime fecha = (DateTime)x[2];
							string fecha1 = fecha.ToString("dd/MM/yyyy");
							fecha1.Replace("/", "-");

							Cuadro.Rows[n].Cells[3].Value = fecha1;
							DateTime fecha2 = (DateTime)x[15];
							Cuadro.Rows[n].Cells[4].Value = fecha2.ToString("dd/MM/yyyy");

							Cuadro.Rows[n].Cells[5].Value = (string)x[4];
							Cuadro.Rows[n].Cells[6].Value = (string)x[14];
							Cuadro.Rows[n].Cells[7].Value = (string)x[5];
							Cuadro.Rows[n].Cells[8].Value = decimal.ToDouble((decimal)x[13]);

							Cuadro.Rows[n].Cells[9].Value = (string)x[6];
							Cuadro.Rows[n].Cells[10].Value = (int)x[12];
							Cuadro.Rows[n].Cells[11].Value = (string)x[10];
							Cuadro.Rows[n].Cells[12].Value = (string)x[11];
							Cuadro.Rows[n].Cells[13].Value = (string)x[8];
							Cuadro.Rows[n].Cells[14].Value = (string)x[9];
							Cuadro.Rows[n].Cells[15].Value = decimal.ToDouble((decimal)x[3]);
							kgAcumulados += decimal.ToDouble((decimal)x[3]);
							Cuadro.Rows[n].Cells[16].Value = (string)x[7];



						}

						Acumulados.Text = kgAcumulados.ToString();

					}
				}
			}
            else
            {

				if (PrensaCBX.Text != "Todas")

				{
					kgAcumulados = 0;
					//completo el cuadro
					DataTable dt2 = Conexion.ObtenerProyeccion2(Fecha1DTP.Value, (int)PrensaCBX.SelectedValue);
					Cuadro.Rows.Clear();

					if (dt2 != null)
					{

						foreach (DataRow x in dt2.Rows)
						{
							int n = Cuadro.Rows.Add();
							Cuadro.Rows[n].Cells[0].Value = true;
							Cuadro.Rows[n].Cells[1].Value = (int)x[0];
							Cuadro.Rows[n].Cells[2].Value = (int)x[1];
							DateTime fecha = (DateTime)x[2];
							Cuadro.Rows[n].Cells[3].Value = fecha.ToString("dd/MM/yyyy");

							DateTime fecha2 = (DateTime)x[15];
							Cuadro.Rows[n].Cells[4].Value = fecha2.ToString("dd/MM/yyyy");

							Cuadro.Rows[n].Cells[5].Value = (string)x[4];
							Cuadro.Rows[n].Cells[6].Value = (string)x[14];
							Cuadro.Rows[n].Cells[7].Value = (string)x[5];
							Cuadro.Rows[n].Cells[8].Value = decimal.ToDouble((decimal)x[13]);

							Cuadro.Rows[n].Cells[9].Value = (string)x[6];
							Cuadro.Rows[n].Cells[10].Value = (int)x[12];
							Cuadro.Rows[n].Cells[11].Value = (string)x[10];
							Cuadro.Rows[n].Cells[12].Value = (string)x[11];
							Cuadro.Rows[n].Cells[13].Value = (string)x[8];
							Cuadro.Rows[n].Cells[14].Value = (string)x[9];
							Cuadro.Rows[n].Cells[15].Value = decimal.ToDouble((decimal)x[3]);
							kgAcumulados += decimal.ToDouble((decimal)x[3]);
							Cuadro.Rows[n].Cells[16].Value = (string)x[7];



						}

						Acumulados.Text = kgAcumulados.ToString();

					}
                }
                else
                {
					kgAcumulados = 0;
					//completo el cuadro
					DataTable dt2 = Conexion.ObtenerProyeccion4(Fecha1DTP.Value, (int)PrensaCBX.SelectedValue);
					Cuadro.Rows.Clear();

					if (dt2 != null)
					{

						foreach (DataRow x in dt2.Rows)
						{
							int n = Cuadro.Rows.Add();
							Cuadro.Rows[n].Cells[0].Value = true;
							Cuadro.Rows[n].Cells[1].Value = (int)x[0];
							Cuadro.Rows[n].Cells[2].Value = (int)x[1];
							DateTime fecha = (DateTime)x[2];
							Cuadro.Rows[n].Cells[3].Value = fecha.ToString("dd/MM/yyyy");

							DateTime fecha2 = (DateTime)x[15];
							Cuadro.Rows[n].Cells[4].Value = fecha2.ToString("dd/MM/yyyy");

							Cuadro.Rows[n].Cells[5].Value = (string)x[4];
							Cuadro.Rows[n].Cells[6].Value = (string)x[14];
							Cuadro.Rows[n].Cells[7].Value = (string)x[5];
							Cuadro.Rows[n].Cells[8].Value = decimal.ToDouble((decimal)x[13]);

							Cuadro.Rows[n].Cells[9].Value = (string)x[6];
							Cuadro.Rows[n].Cells[10].Value = (int)x[12];
							Cuadro.Rows[n].Cells[11].Value = (string)x[10];
							Cuadro.Rows[n].Cells[12].Value = (string)x[11];
							Cuadro.Rows[n].Cells[13].Value = (string)x[8];
							Cuadro.Rows[n].Cells[14].Value = (string)x[9];
							Cuadro.Rows[n].Cells[15].Value = decimal.ToDouble((decimal)x[3]);
							kgAcumulados += decimal.ToDouble((decimal)x[3]);
							Cuadro.Rows[n].Cells[16].Value = (string)x[7];



						}

						Acumulados.Text = kgAcumulados.ToString();

					}

				}

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
			if ((bool)Cuadro.Rows[n].Cells[0].Value == true) { kgAcumulados-=(double)Cuadro.Rows[n].Cells[15].Value; Acumulados.Text = kgAcumulados.ToString();  Cuadro.Rows[n].Cells[0].Value = false; }
			else {
				kgAcumulados += (double)Cuadro.Rows[n].Cells[15].Value; Acumulados.Text = kgAcumulados.ToString();
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



        private void Proyeccion_Load(object sender, EventArgs e)
        {
			Fecha1DTP.Value = DateTime.Today;

			MySqlConnection conectar = Conexion.ObtenerConexion();
			MySqlDataReader reader;
			conectar.Open();
			// COMBOBOX PRENSA
			string consulta = "Select ID,descripcion From Puesto p order by p.descripcion";
			try
			{
				MySqlCommand comand = new MySqlCommand(consulta, conectar);
				reader = comand.ExecuteReader();
				DataTable dt = new DataTable();
				dt.Load(reader);
				DataRow newRow = dt.NewRow();
				newRow["descripcion"] = "Todas";
				dt.Rows.InsertAt(newRow, 0);
				PrensaCBX.DataSource = dt;
				PrensaCBX.DisplayMember = "descripcion";
				PrensaCBX.ValueMember = "ID";
			}
			catch (MySqlException ex) { MessageBox.Show("Error al buscar " + ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error); }
			finally { conectar.Close(); } // Cerramos la conexion a la base de datos

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