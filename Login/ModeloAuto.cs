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
    public partial class ModeloAuto : Form
    {
        public ModeloAuto()
        {
            InitializeComponent();
        }

        private void ModeloAuto_Load(object sender, EventArgs e)
        {
            MySqlConnection conectar = Conexion.ObtenerConexion();

            // COMBOBOX marca
            MySqlDataReader reader;
            string consulta = "Select ID,descripcion From marcavehiculo p order by p.descripcion";
            conectar.Open();

            try
            {
                MySqlCommand comand = new MySqlCommand(consulta, conectar);
                reader = comand.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(reader);
                DataRow newRow = dt.NewRow();
                newRow["descripcion"] = "Seleccione";
                dt.Rows.InsertAt(newRow, 0);
                MarcaCBX.DataSource = dt;
                MarcaCBX.DisplayMember = "descripcion";
                MarcaCBX.ValueMember = "ID";

            }
            catch (MySqlException ex) { MessageBox.Show("Error al buscar " + ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error); }


            try
            {
                //completo el cuadro
                DataTable dt2 = Conexion.GetModeloAuto();
                Cuadro.Rows.Clear();
                if (dt2 != null)
                {

                    foreach (DataRow x in dt2.Rows)
                    {
                        int n = Cuadro.Rows.Add();
                        Cuadro.Rows[n].Cells[0].Value = false;
                        Cuadro.Rows[n].Cells[1].Value = (int)x[0];
                        Cuadro.Rows[n].Cells[2].Value = (string)x[1];
                        Cuadro.Rows[n].Cells[3].Value = (int)x[2];
                        Cuadro.Rows[n].Cells[4].Value = (int)x[3];

                    }
                }

            }
            catch (MySqlException ex) { MessageBox.Show("Error al buscar " + ex.Message); }



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
            if (MarcaCBX.Text != "Seleccione" && descripcionTBX.Text != "" && AñoNum.Value > 0)
            {
                try
                {
                    Conexion.AddModeloAuto(descripcionTBX.Text,int.Parse(AñoNum.Value.ToString()), (int)MarcaCBX.SelectedValue);
                    Limpiar();
                    ModeloAuto_Load(sender, e);
                }
                catch (Exception) { MessageBox.Show("No se pudo agregar el modelo, revise los datos y reintente"); }
            }
            else { MessageBox.Show("Revise los campos ingresados"); }
        }

        private void Limpiar()
        {

            descripcionTBX.Text = "";
            AñoNum.Value = 0;

        }

        private void ModificarBTN_Click(object sender, EventArgs e)
        {

            if (MarcaCBX.Text != "Seleccione" && descripcionTBX.Text != "" && AñoNum.Value>0)
            {
                try
                {
                    Conexion.SetModeloAuto((int)Cuadro.Rows[n].Cells[1].Value, descripcionTBX.Text,int.Parse(AñoNum.Value.ToString()), (int)MarcaCBX.SelectedValue);
                    Limpiar();
                    ModeloAuto_Load(sender, e);
                }
                catch (Exception) { MessageBox.Show("No se pudo modificar el modelo, revise los datos y reintente"); }
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
                    AñoNum.Value = (int)Cuadro.Rows[n].Cells[3].Value;
                    MarcaCBX.SelectedValue = (int)Cuadro.Rows[n].Cells[4].Value;

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
                    Conexion.DeleteModeloAuto((int)Cuadro.Rows[n].Cells[1].Value);
                    Limpiar();
                    ModeloAuto_Load(sender, e);
                }


                else { MessageBox.Show("No hay ningun registro seleccionado"); }
            }
            catch (Exception) { MessageBox.Show("No se pudo eliminar el modelo, revise los datos y reintente"); }
        }



        private void label3_Click(object sender, EventArgs e)
        {

        }


        


    }
}
