using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Login
{
	public partial class AgregarCliente : Form
	{
		public AgregarCliente()
		{InitializeComponent();}


		
		void CancelarClick(object sender, EventArgs e)
		{this.Close();}


        private void AgregarCliente_Load(object sender, EventArgs e)
        {
			MySqlConnection conectar = Conexion.ObtenerConexion();

			// COMBOBOX PROVINCIA
			MySqlDataReader reader;
			string consulta = "Select ID,nombre From Provincia p order by p.nombre";
			conectar.Open();

			try
			{
				MySqlCommand comand = new MySqlCommand(consulta, conectar);
				reader = comand.ExecuteReader();
				DataTable dt = new DataTable();
				dt.Load(reader);
				DataRow newRow = dt.NewRow();
				newRow["nombre"] = "Seleccione";
				dt.Rows.InsertAt(newRow, 0);
				ProvFisc_Cbx.DataSource = dt;
				ProvFisc_Cbx.DisplayMember = "nombre";
				ProvFisc_Cbx.ValueMember = "ID";

			}
			catch (MySqlException ex) { MessageBox.Show("Error al buscar " + ex.Message,"Atención",MessageBoxButtons.OK,MessageBoxIcon.Error); }
			try
			{
				MySqlCommand comand = new MySqlCommand(consulta, conectar);
				reader = comand.ExecuteReader();
				DataTable dt = new DataTable();
				dt.Load(reader);
				DataRow newRow = dt.NewRow();
				newRow["nombre"] = "Seleccione";
				dt.Rows.InsertAt(newRow, 0);
				ProvEnt_Cbx.DataSource = dt;
				ProvEnt_Cbx.DisplayMember = "nombre";
				ProvEnt_Cbx.ValueMember = "ID";


			}
			catch (MySqlException ex) { MessageBox.Show("Error al buscar " + ex.Message,"Atención",MessageBoxButtons.OK,MessageBoxIcon.Error); }


			// COMBOBOX IVA
			MySqlDataReader reader2;
			string consulta2 = "Select ID,descripcion From IVA i order by i.descripcion";
			

			try
			{
				MySqlCommand comand = new MySqlCommand(consulta2, conectar);
				reader2 = comand.ExecuteReader();
				DataTable dt = new DataTable();
				dt.Load(reader2);
				DataRow newRow = dt.NewRow();
				newRow["descripcion"] = "Seleccione";
				dt.Rows.InsertAt(newRow, 0);
				IVA_Cbx.DataSource = dt;
				IVA_Cbx.DisplayMember = "descripcion";
				IVA_Cbx.ValueMember = "ID";

			}
			catch (MySqlException ex) { MessageBox.Show("Error al buscar " + ex.Message,"Atención",MessageBoxButtons.OK,MessageBoxIcon.Error); }

			// COMBOBOX DOCUMENTO
			MySqlDataReader reader3;
			string consulta3 = "Select ID,descripcion From TipoDocumento i order by i.descripcion";


			try
			{
				MySqlCommand comand = new MySqlCommand(consulta3, conectar);
				reader3 = comand.ExecuteReader();
				DataTable dt = new DataTable();
				dt.Load(reader3);
				DataRow newRow = dt.NewRow();
				newRow["descripcion"] = "Seleccione";
				dt.Rows.InsertAt(newRow, 0);
				TipoDoc_Cbx.DataSource = dt;
				TipoDoc_Cbx.DisplayMember = "descripcion";
				TipoDoc_Cbx.ValueMember = "ID";

			}
			catch (MySqlException ex) { MessageBox.Show("Error al buscar " + ex.Message,"Atención",MessageBoxButtons.OK,MessageBoxIcon.Error); }


			// TEXTBOX NUMERO CLIENTE
			string consulta8 = "select max(c.numero) from cliente c limit 1";
			decimal numero = 0;
			try
			{
				MySqlCommand comand = new MySqlCommand(consulta8, conectar);
				reader = comand.ExecuteReader();
				if (reader.HasRows)
				{
					while (reader.Read())
					{
						try
						{
							numero = decimal.Parse(reader.GetString(0));
							numero++;
							NumCliente.Value = numero;
						}
						catch (Exception) { }
					}
				}
			}
			catch (MySqlException ex) { MessageBox.Show("Error al buscar " + ex.Message,"Atención",MessageBoxButtons.OK,MessageBoxIcon.Error); }
			finally { conectar.Close(); }



		}

        private void ProvFisc_Cbx_SelectionChangeCommitted(object sender, EventArgs e)
        {
			MySqlConnection conectar = Conexion.ObtenerConexion();
			// COMBOBOX LOCALIDAD FISCAL ANIDADO CON PROVINCIA

			LocFis_Cbx.DataSource = null;  //  Ponemos el ComboBox en blanco
			LocFis_Cbx.Items.Clear();      //  Ponemos el ComboBox en blanco

			MySqlDataReader reader;
			string consulta = "Select ID,nombre From localidad l where l.Provincia_ID = '"+ ProvFisc_Cbx.SelectedValue.ToString()+ "' order by l.nombre";
			conectar.Open();

			try
			{
				MySqlCommand comand = new MySqlCommand(consulta, conectar);
				reader = comand.ExecuteReader();
				DataTable dt = new DataTable();
				dt.Load(reader);
				DataRow newRow = dt.NewRow();
				newRow["nombre"] = "Seleccione";
				dt.Rows.InsertAt(newRow, 0);
				LocFis_Cbx.DataSource = dt;
				LocFis_Cbx.DisplayMember = "nombre";
				LocFis_Cbx.ValueMember = "ID";

			}
			catch (MySqlException ex) { MessageBox.Show("Error al buscar " + ex.Message,"Atención",MessageBoxButtons.OK,MessageBoxIcon.Error); }
            finally { conectar.Close(); }
		}

        private void ProvEnt_Cbx_SelectionChangeCommitted(object sender, EventArgs e)
        {
			MySqlConnection conectar = Conexion.ObtenerConexion();
			// COMBOBOX LOCALIDAD ENTREGA
			LocEnt_Cbx.DataSource = null;
			LocEnt_Cbx.Items.Clear();
			MySqlDataReader reader;
			string consulta = "Select ID,nombre From localidad l where l.Provincia_ID = '" + ProvEnt_Cbx.SelectedValue.ToString() + "' order by l.nombre";
			conectar.Open();

			try
			{
				MySqlCommand comand = new MySqlCommand(consulta, conectar);
				reader = comand.ExecuteReader();
				DataTable dt = new DataTable();
				dt.Load(reader);
				DataRow newRow = dt.NewRow();
				newRow["nombre"] = "Seleccione";
				dt.Rows.InsertAt(newRow, 0);
				LocEnt_Cbx.DataSource = dt;
				LocEnt_Cbx.DisplayMember = "nombre";
				LocEnt_Cbx.ValueMember = "ID";

			}
			catch (MySqlException ex) { MessageBox.Show("Error al buscar " + ex.Message,"Atención",MessageBoxButtons.OK,MessageBoxIcon.Error); }
			finally { conectar.Close(); }

		}

        private void ProvFisc_Cbx_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

		private void Crear_Click(object sender, EventArgs e)
		{
			if (DirFisc_Txt.Text != "" && ProvFisc_Cbx.Text != "Seleccione" && DirEntrega_txt.Text != "" && ProvEnt_Cbx.Text != "Seleccione" && Alias_Txt.Text != "" && RazonSocial_Txt.Text != "" && (long)NumDoc.Value > 0 && Tel1_tex.Text != "" && Tel2_text.Text != "" && TipoDoc_Cbx.Text != "Seleccione" && IVA_Cbx.Text != "Seleccione" && LocEnt_Cbx.Text!="Seleccione" &&  LocFis_Cbx.Text!="Seleccione")
			{
				Conexion.CrearCliente(DirFisc_Txt.Text, (int)LocFis_Cbx.SelectedValue,CPFisc.Text, DirEntrega_txt.Text, (int)LocEnt_Cbx.SelectedValue,CPEnt.Text, (int)NumCliente.Value, Alias_Txt.Text, RazonSocial_Txt.Text, (long)NumDoc.Value, Tel1_tex.Text, Tel2_text.Text, (int)TipoDoc_Cbx.SelectedValue, (int)IVA_Cbx.SelectedValue,BonifNum.Value,RecargoNum.Value);
				// Limpiar datos
				NumCliente.Value = NumCliente.Value + 1;
				RazonSocial_Txt.Text = "";
				Alias_Txt.Text = "";
				DirEntrega_txt.Text = "";
				DirFisc_Txt.Text = "";
				ProvEnt_Cbx.Text = "Seleccione";
				ProvFisc_Cbx.Text = "Seleccione";
				CPFisc.Text = "";
				CPEnt.Text = "";
				Tel1_tex.Text = "";
				Tel2_text.Text = "";
				TipoDoc_Cbx.Text = "Seleccione";
				NumDoc.Value = 0;
				IVA_Cbx.Text = "Seleccione";
				LocEnt_Cbx.DataSource = null;
				LocEnt_Cbx.Items.Clear();
				LocFis_Cbx.DataSource = null;
				LocFis_Cbx.Items.Clear();




			}
			else { MessageBox.Show("Complete todos los campos"); }
		}

        private void EditarBTN_Click(object sender, EventArgs e)
        {
			ProvEnt_Cbx.Text = "Seleccione";
			ProvFisc_Cbx.Text = "Seleccione";
			LocFis_Cbx.DataSource = null;  //  Ponemos el ComboBox en blanco
			LocFis_Cbx.Items.Clear();      //  Ponemos el ComboBox en blanco
			LocEnt_Cbx.DataSource = null;  //  Ponemos el ComboBox en blanco
			LocEnt_Cbx.Items.Clear();      //  Ponemos el ComboBox en blanco

			Ciudad agregar = new Ciudad();
			DialogResult resultado = agregar.ShowDialog();
        }

        private void CheckDireccion_CheckedChanged(object sender, EventArgs e)
        {
			if (CheckDireccion.Checked == true)
			{
				try
				{
					if (ProvFisc_Cbx.Text != "Seleccione" && LocFis_Cbx.Text != "Seleccione" && DirFisc_Txt.Text!="" && CPFisc.Text!="")
					{


						DirEntrega_txt.Text = DirFisc_Txt.Text;
						ProvEnt_Cbx.SelectedValue = ProvFisc_Cbx.SelectedValue;
						ProvEnt_Cbx_SelectionChangeCommitted(sender, e);
						LocEnt_Cbx.SelectedValue = LocFis_Cbx.SelectedValue;
						CPEnt.Text = CPFisc.Text;

						DirEntrega_txt.Enabled = false;
						ProvEnt_Cbx.Enabled = false;
						LocEnt_Cbx.Enabled = false;
						CPEnt.Enabled = false;
					}

					else { CheckDireccion.Checked = false; MessageBox.Show("Complete todos los campos de la dirección de entrega"); }
				}
				catch (Exception) { CheckDireccion.Checked = false; }

			}

			if (CheckDireccion.Checked == false)
			{

				DirEntrega_txt.Enabled = true;
				ProvEnt_Cbx.Enabled = true;
				LocEnt_Cbx.Enabled = true;
				CPEnt.Enabled = true;
			}
		}
    }
}
