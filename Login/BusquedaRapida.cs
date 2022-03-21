using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;


namespace Login
{
    public partial class BusquedaRapida : Form
    {
        public BusquedaRapida(string campo1,string campo2,string tabla)
        {
            InitializeComponent();
            Campo1 = campo1;Campo2 = campo2;Tabla = tabla;
        }

        public BusquedaRapida(string campo1, string campo2,string campo3, string tabla)
        {
            InitializeComponent();
            Campo1 = campo1; Campo2 = campo2; Tabla = tabla; Campo3 = campo3;
        }

        public BusquedaRapida(string campo1, string campo2, string campo3, string tabla, string busqueda)
        {
            InitializeComponent();
            Campo1 = campo1; Campo2 = campo2; Tabla = tabla; Campo3 = campo3;BusquedaTBX.Text = busqueda;
        }

        public BusquedaRapida(string campo1, string campo2, string tabla,string condicion, int numero)
        {
            InitializeComponent();
            Campo1 = campo1; Campo2 = campo2; Tabla = tabla; Condicion = condicion+numero.ToString();
        }

        //Variables
        private string Campo1, Campo2, Campo3, Tabla;
        private string Condicion="";
        public int IDBusqueda { get; set; }
        private int n;

        private void BusquedaRapida_Load(object sender, EventArgs e)
        {
            Cuadro.Columns[2].HeaderText = Campo1.ToUpper();
            Cuadro.Columns[3].HeaderText = Campo2.ToUpper();
            Campo1Chek.Text = Campo1.ToLower();
            Campo2Chek.Text = Campo2.ToLower();
            if (Campo3 != null)
            {
                Campo3Chek.Visible = true;
                Campo3Chek.Text = Campo3.ToLower();

            }

            if (BusquedaTBX.Text != "") { Buscar_Click(sender, e); }

            


        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void Agregar_Click(object sender, EventArgs e)
        {
            
            IDBusqueda = int.Parse(Cuadro.Rows[n].Cells[1].Value.ToString());
    
            this.Close();
        }

        private void Cuadro_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                n = e.RowIndex;
                if ((bool)Cuadro.Rows[n].Cells[0].Value == true)
                {
                    Cuadro.Rows[n].Cells[0].Value = false;
                    Buscar_Click(sender, e);
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
                }
                catch (Exception) { }


            }

        }
            catch (Exception) { }
        }



        private void Buscar_Click(object sender, EventArgs e)
        {
            if (Campo3 == null)
            {
                string consultaNueva = "";
                if (Condicion == "")
                {
                    consultaNueva = "select t.ID, t." + Campo1 + ", t." + Campo2 + " from " + Tabla + " t where t." + Campo1 + " like '%" + BusquedaTBX.Text + "%' or t." + Campo2 + " like '%" + BusquedaTBX.Text + "%' order by t." + Campo1;
                }
                //else {
                //    consultaNueva = "select t.ID, t." + Campo1 + ", t." + Campo2 + " from " + Tabla + " t where "+Condicion+" and (t." + Campo1 + " like '%" + BusquedaTBX.Text + "%' or t." + Campo2 + " like '%" + BusquedaTBX.Text + "%' ) order by t." + Campo1;
                //}

                else
                {
                    consultaNueva = "select ma.descripcion,m.descripcion,m.`año` from modelo m inner join marcavehiculo ma on m.Marca_ID = ma.ID where ma.descripcion = '%"+BusquedaTBX.Text+ "%' and m.descripcion like '%" + BusquedaTBX.Text + "%'";
                }
                Cuadro.Rows.Clear();
                MySqlConnection conectar = Conexion.ObtenerConexion();
                conectar.Open();
                DataTable dt = new DataTable();
                try
                {
                    MessageBox.Show(consultaNueva);
                    MySqlCommand comand = new MySqlCommand(consultaNueva, conectar);
                    MySqlDataAdapter adp = new MySqlDataAdapter(comand);
                    adp.Fill(dt);
                    if (dt.Rows.Count == 0) { MessageBox.Show("La busqueda no arrojo ningún resultado"); }
                    else
                    {
                        foreach (DataRow x in dt.Rows)
                        {
                            int n = Cuadro.Rows.Add();
                            Cuadro.Rows[n].Cells[0].Value = false;
                            Cuadro.Rows[n].Cells[1].Value = (int)x[0];
                            try { Cuadro.Rows[n].Cells[2].Value = (int)x[1]; } catch (Exception) { Cuadro.Rows[n].Cells[2].Value = (string)x[1]; }

                            try { Cuadro.Rows[n].Cells[3].Value = (int)x[2]; } catch (Exception) { Cuadro.Rows[n].Cells[3].Value = (string)x[2]; }

                        }
                    }
                }
                catch (Exception ex) { MessageBox.Show("Error al buscar " + ex.Message); }
                finally { conectar.Close(); }
            }

            else
            {
                //string consultaNueva = "select t.ID,  t." + Campo1 + ", concat(t." + Campo2+",' ' ,t." + Campo3+") as empleado" + " from " + Tabla + " t where t." + Campo1 + " like '%" + BusquedaTBX.Text + "%' or t." + Campo2 + " like '%" + BusquedaTBX.Text + "%' or t." + Campo3 + " like '%" + BusquedaTBX.Text + "%' order by t." + Campo1;
                string consultaNueva = "select m.id,ma.descripcion,m.descripcion,m.`año` from modelo m inner join marcavehiculo ma on m.Marca_ID = ma.ID where ma.descripcion like '%" + BusquedaTBX.Text + "%' or m.descripcion like '%" + BusquedaTBX.Text + "%'";
                Cuadro.Columns[3].HeaderText = "MODELO/AÑO";
                Cuadro.Rows.Clear();
                MySqlConnection conectar = Conexion.ObtenerConexion();
                conectar.Open();
                DataTable dt = new DataTable();
                try
                {
                    MySqlCommand comand = new MySqlCommand(consultaNueva, conectar);
                    MySqlDataAdapter adp = new MySqlDataAdapter(comand);
                    adp.Fill(dt);
                    if (dt.Rows.Count == 0) { MessageBox.Show("La busqueda no arrojo ningún resultado"); }
                    else
                    {
                        foreach (DataRow x in dt.Rows)
                        {
                            int n = Cuadro.Rows.Add();
                            Cuadro.Rows[n].Cells[0].Value = false;
                            Cuadro.Rows[n].Cells[1].Value = (int)x[0];
                            try { Cuadro.Rows[n].Cells[2].Value = (int)x[1]; } catch (Exception) { Cuadro.Rows[n].Cells[2].Value = (string)x[1]; }

                            try { Cuadro.Rows[n].Cells[3].Value = (int)x[2]; } catch (Exception) { Cuadro.Rows[n].Cells[3].Value = (string)x[2] +"   Año:"+((int)x[3]).ToString(); }

                        }
                    }
                }
                catch (Exception ex) { MessageBox.Show("Error al buscar " + ex.Message); }
                finally { conectar.Close(); }

            }
        }
    }
}
