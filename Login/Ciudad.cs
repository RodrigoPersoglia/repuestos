using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;


namespace Login
{
    public partial class Ciudad : Form
    {
        public Ciudad()
        {
            InitializeComponent();
        }

        private void Ciudad_Load(object sender, EventArgs e)
        {
            MySqlConnection conectar = Conexion.ObtenerConexion();
            
            conectar.Open();

            try
            {
                ProvinciaCBX.DataSource = null;
                ProvinciaCBX.Items.Clear();
                DataTable dt = Conexion.VerProvincias();
                if (dt != null)
                {
                    DataRow newRow = dt.NewRow();
                    newRow["nombre"] = "Seleccione";
                    dt.Rows.InsertAt(newRow, 0);
                    ProvinciaCBX.DataSource = dt;
                    ProvinciaCBX.DisplayMember = "nombre";
                    ProvinciaCBX.ValueMember = "ID";
                }
            }
            catch (Exception) { }
            finally { conectar.Close(); }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }



        private void cuil2TBX_TextChanged(object sender, EventArgs e)
        {


        }



        private void telefonoTBX_TextChanged(object sender, EventArgs e)
        {

        }

        private void CelularTBX_TextChanged(object sender, EventArgs e)
        {


        }


        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Agregar_Click(object sender, EventArgs e)
        {
            if (ProvinciaCBX.Text != "Seleccione" && descripcionTBX.Text != "")
            {
                try
                {
                    Conexion.AgregarLocalidad(descripcionTBX.Text, (int)ProvinciaCBX.SelectedValue);
                    Limpiar();
                    ProvinciaCBX_SelectionChangeCommitted(sender, e);
                }
                catch (Exception) { MessageBox.Show("No se pudo agregar la Localidad, revise los datos y reintente"); }
            }
            else { MessageBox.Show("Revise los campos ingresados"); }
        }

        private void Limpiar()
        {

            descripcionTBX.Text = "";

        }

        private void ModificarBTN_Click(object sender, EventArgs e)
        {
            
                if (ProvinciaCBX.Text != "Seleccione" && descripcionTBX.Text != "")
                {
                    try
                    {
                        Conexion.ModificarLocalidad((int)Cuadro.Rows[n].Cells[1].Value ,descripcionTBX.Text, (int)ProvinciaCBX.SelectedValue);
                        Limpiar();
                        ProvinciaCBX_SelectionChangeCommitted(sender, e);
                    }
                    catch (Exception) { MessageBox.Show("No se pudo agregar la Localidad, revise los datos y reintente"); }
                }
                else { MessageBox.Show("Revise los campos ingresados"); }
            
        }

   

        int n;
        private void Cuadro_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                n = e.RowIndex;
                if ((bool)Cuadro.Rows[n].Cells[0].Value == true)
                {
                    Cuadro.Rows[n].Cells[0].Value = false;
                    Cuadro.Rows[n].DefaultCellStyle.BackColor = Color.White;
                    Limpiar();

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
                    descripcionTBX.Text = (string)Cuadro.Rows[n].Cells[2].Value;
                }
                catch (Exception) { }


            }

        }
            catch (Exception) { }
        }

        private void EliminarBTN_Click(object sender, EventArgs e)
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
                    Conexion.EliminarLocalidad((int)Cuadro.Rows[n].Cells[1].Value);
                    Limpiar();
                    ProvinciaCBX_SelectionChangeCommitted(sender, e);
                }


                else { MessageBox.Show("No hay ningun registro seleccionado"); }
            }
            catch (Exception) { MessageBox.Show("No se pudo eliminar la categoría, revise los datos y reintente"); }
        }



        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void ProvinciaCBX_SelectionChangeCommitted(object sender, EventArgs e)
        {  
            Cuadro.Rows.Clear();
            try
            {
                int numero = (int)ProvinciaCBX.SelectedValue;
                string consulta5 = "select * from localidad l where l.provincia_ID=" + numero.ToString() + " order by l.nombre" ;
                MySqlConnection conectar = Conexion.ObtenerConexion();
                MySqlDataReader reader;
                conectar.Open();
                try
                {
                    MySqlCommand comand = new MySqlCommand(consulta5, conectar);
                    reader = comand.ExecuteReader();
                    DataTable dt = new DataTable();
                    dt.Load(reader);
                    foreach (DataRow x in dt.Rows)
                    {
                        int n = Cuadro.Rows.Add();
                        Cuadro.Rows[n].Cells[0].Value = false;
                        Cuadro.Rows[n].Cells[1].Value = (int)x[0];
                        Cuadro.Rows[n].Cells[2].Value = (string)x[1];
                        Cuadro.Rows[n].Cells[3].Value = (int)x[2];
                    }
                }
                catch (MySqlException ex) { MessageBox.Show("Error al buscar " + ex.Message); }
                finally { conectar.Close(); }
            }
            catch (Exception) { Limpiar(); }
        }


    }
}
