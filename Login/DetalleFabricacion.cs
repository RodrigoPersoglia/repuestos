using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Data;

namespace Login
{
	public partial class DetalleFabricacion : Form
	{
		
		public DetalleFabricacion()
		{
			InitializeComponent();
		}


		public DetalleFabricacion( string pedido)
		{
			InitializeComponent();
			NumOPTXT.Text = pedido;


		}

		//Declaracion de variables, sirve para vincular con la ventana que las instancia.
		private Articulo articuloSeleccionado = new Articulo();
		private Pedido pedido = new Pedido();
		private DateTime HoraInicio = new DateTime();
		private Matriz matriz = new Matriz();

		//Propiedades, solo Get
		public Articulo ArticuloSeleccionado{
			get{return articuloSeleccionado; }
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

			//string numeroPedido = Cuadro.Rows[n].Cells[1].Value.ToString();
			//MessageBox.Show("NUMERO DE PEDIDO= "+ numeroPedido);

		}

		string pedidoSeleccionado;
		private void Cuadro_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			n = e.RowIndex;
			if ((bool)Cuadro.Rows[n].Cells[0].Value == true) { 
				Cuadro.Rows[n].Cells[0].Value = false;
				Limpiar();
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
					FechaDTP.Value = new DateTime(int.Parse(((string)Cuadro.Rows[n].Cells[3].Value).Substring(6, 4)), int.Parse(((string)Cuadro.Rows[n].Cells[3].Value).Substring(3, 2)), int.Parse(((string)Cuadro.Rows[n].Cells[3].Value).Substring(0, 2)));
					MatrizComboBox.SelectedValue = (int)Cuadro.Rows[n].Cells[6].Value;
					PrensaCBX.Text = (string)Cuadro.Rows[n].Cells[8].Value;
					TurnoCBX.Text = (string)Cuadro.Rows[n].Cells[9].Value;
					AleacionComboBox.Text = (string)Cuadro.Rows[n].Cells[10].Value;
					ColadaTXT.Text = (string)Cuadro.Rows[n].Cells[11].Value;

					DiamTocho.Value = (int)Cuadro.Rows[n].Cells[12].Value;
					try { LargoTochoTXT.Text = ((int)Cuadro.Rows[n].Cells[13].Value).ToString(); }
				catch (Exception) { LargoTochoTXT.Text = ""; }


				try { CanTochoTXT.Text = ((int)Cuadro.Rows[n].Cells[14].Value).ToString(); }
				catch (Exception) { CanTochoTXT.Text = ""; }


			

				horaIN.Text = (string)Cuadro.Rows[n].Cells[15].Value;
				HoraFin.Text = (string)Cuadro.Rows[n].Cells[16].Value;

					try { KgPrensa.Text = ((double)Cuadro.Rows[n].Cells[17].Value).ToString(); }
					catch (Exception) { KgTXT.Text = ""; }

				try { KgTXT.Text = ((double)Cuadro.Rows[n].Cells[18].Value).ToString(); }
				catch (Exception) { KgTXT.Text  = ""; }

                try { TirasTXT.Text = ((int)Cuadro.Rows[n].Cells[19].Value).ToString(); }
                catch (Exception) { TirasTXT.Text = ""; }

                try { LargoTXT.Text = (string)Cuadro.Rows[n].Cells[20].Value; }
                catch (Exception) { LargoTXT.Text = ""; }

                try { ObervTXT.Text = (string)Cuadro.Rows[n].Cells[21].Value; }
                catch (Exception) { ObervTXT.Text = ""; }


                }
                catch (Exception) { }



            }

			CanTochoTXT_Leave(sender, e);



		}


		private void Cancelar_Click(object sender, EventArgs e)
        {
			this.Close();
        }

        private void Exportarboton_Click(object sender, EventArgs e)
        {
			Exportar.Exportar_Articulos(Cuadro);

        }



        private void DetalleFabricacion_Load(object sender, EventArgs e)
        {
			FechaDTP.Value = DateTime.Today;
			MySqlConnection conectar = Conexion.ObtenerConexion();
			// COMBOBOX ALEACION
			MySqlDataReader reader;
			string consulta = "Select ID,descripcion From Aleacion a order by a.descripcion";
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
				AleacionComboBox.DataSource = dt;
				AleacionComboBox.DisplayMember = "descripcion";
				AleacionComboBox.ValueMember = "ID";

			}
			catch (MySqlException ex) { MessageBox.Show("Error al buscar " + ex.Message,"Atención",MessageBoxButtons.OK,MessageBoxIcon.Error); }

			// COMBOBOX PRENSA
			MySqlDataReader reader2;
			string consulta2 = "Select ID,descripcion From Puesto a where a.descripcion <> 'Sin Asignar' order by a.descripcion";
			

			try
			{
				MySqlCommand comand = new MySqlCommand(consulta2, conectar);
				reader2 = comand.ExecuteReader();
				DataTable dt = new DataTable();
				dt.Load(reader2);
				DataRow newRow = dt.NewRow();
				newRow["descripcion"] = "Seleccione";
				dt.Rows.InsertAt(newRow, 0);
				PrensaCBX.DataSource = dt;
				PrensaCBX.DisplayMember = "descripcion";
				PrensaCBX.ValueMember = "ID";

			}
			catch (MySqlException ex) { MessageBox.Show("Error al buscar " + ex.Message,"Atención",MessageBoxButtons.OK,MessageBoxIcon.Error); }

			// COMBOBOX TURNO
			MySqlDataReader reader3;
			string consulta3 = "Select ID,descripcion From Turno a order by a.descripcion";
			

			try
			{
				MySqlCommand comand = new MySqlCommand(consulta3, conectar);
				reader3 = comand.ExecuteReader();
				DataTable dt = new DataTable();
				dt.Load(reader3);
				DataRow newRow = dt.NewRow();
				newRow["descripcion"] = "Seleccione";
				dt.Rows.InsertAt(newRow, 0);
				TurnoCBX.DataSource = dt;
				TurnoCBX.DisplayMember = "descripcion";
				TurnoCBX.ValueMember = "ID";

			}
			catch (MySqlException ex) { MessageBox.Show("Error al buscar " + ex.Message,"Atención",MessageBoxButtons.OK,MessageBoxIcon.Error); }
			finally { conectar.Close();}

			if (NumOPTXT.Text != "")
            {
				Buscar_Click(sender, e);

			}
		}

        private void Articulocambia(object sender, EventArgs e)
        {
			
        }

       

        private void button1_Click(object sender, EventArgs e)
        {
			ModificarPedido Modif = new ModificarPedido(pedidoSeleccionado);
			Modif.MdiParent = this.MdiParent;
			Modif.Show();
        }

       
        private void Cuadro_SelectionChanged(object sender, EventArgs e)
        {

		}

        private void button1_Click_1(object sender, EventArgs e)
        {
            try 
			{
				
				HoraInicio = DateTime.Parse(horaIN.Text);
				MessageBox.Show(HoraInicio.ToString());

			}
			catch (Exception) { MessageBox.Show("formato incorrecto"); }
			

		}

        private void Buscar_Click(object sender, EventArgs e)
        {
            pedido = Conexion.ObtenerPedido(NumOPTXT.Text);
            if (pedido != null)
			{
				ClienteTBX.Text = pedido.Cliente;
				ArticuloTXB.Text = pedido.Articulo;
				CodigoTXB.Text = pedido.Codigo_Articulo;
				AleacionComboBox.Text = pedido.Aleacion;

				// pasar a modificar articulos
				try
				{
					MatrizComboBox.DataSource = null;
					MatrizComboBox.Items.Clear();
					DataTable dt = Conexion.VerMatriz(pedido.Codigo_Articulo);
					if (dt != null)
					{
						DataRow newRow = dt.NewRow();
						MatrizComboBox.DataSource = dt;
						MatrizComboBox.DisplayMember = "matriz";
						MatrizComboBox.ValueMember = "ID";
						MatrizComboBox.SelectedValue = pedido.Matriz;
					}
				}
				catch (Exception) { }




			
					//completo el cuadro
					DataTable dt2 = Conexion.VerDetalleFabricacion(pedido.Numero);
					Cuadro.Rows.Clear();

					if (dt2 != null)
					{
						
						foreach (DataRow x in dt2.Rows)
						{	int n = Cuadro.Rows.Add();
							Cuadro.Rows[n].Cells[0].Value = false;
							Cuadro.Rows[n].Cells[1].Value = (int)x[0];
							Cuadro.Rows[n].Cells[2].Value = (int)x[1];
							DateTime fecha = (DateTime)x[2];
							Cuadro.Rows[n].Cells[3].Value = fecha.ToString("dd/MM/yyyy");
							Cuadro.Rows[n].Cells[4].Value = (string)x[3];
							Cuadro.Rows[n].Cells[5].Value = (string)x[4];
							Cuadro.Rows[n].Cells[6].Value = (int)x[5];
							Cuadro.Rows[n].Cells[7].Value = decimal.ToDouble((decimal)x[6]);
							Cuadro.Rows[n].Cells[8].Value = (string)x[7];
							Cuadro.Rows[n].Cells[9].Value = (string)x[8];
							Cuadro.Rows[n].Cells[10].Value = (string)x[9];
							Cuadro.Rows[n].Cells[11].Value = (string)x[10];
							Cuadro.Rows[n].Cells[12].Value = (int)x[19];
							Cuadro.Rows[n].Cells[13].Value = (int)x[11];
							Cuadro.Rows[n].Cells[14].Value = (int)x[12];
							Cuadro.Rows[n].Cells[15].Value = ((TimeSpan)x[13]).ToString(@"hh\:mm");
						Cuadro.Rows[n].Cells[16].Value = ((TimeSpan)x[14]).ToString(@"hh\:mm");
						Cuadro.Rows[n].Cells[17].Value = decimal.ToDouble((decimal)x[20]);
							Cuadro.Rows[n].Cells[18].Value = decimal.ToDouble((decimal)x[15]);
							Cuadro.Rows[n].Cells[19].Value = (int)x[16];
							Cuadro.Rows[n].Cells[20].Value = (string)x[17];
							Cuadro.Rows[n].Cells[21].Value = (string)x[18];

						}
					}
			}

		}

        private void NumOPTextBox_TextChanged(object sender, EventArgs e)
        {
			//Limpiar
			ClienteTBX.Text = "";
			ArticuloTXB.Text = "";
			CodigoTXB.Text = "";
			AleacionComboBox.Text = "Seleccione";
			MatrizComboBox.DataSource = null;
			MatrizComboBox.Items.Clear();
			PesoMetroTXT.Text = "";
			Cuadro.Rows.Clear();

		}

		private void AgregarBTN_Click(object sender, EventArgs e)
		{


			bool prueba = true;
			double peso_metro = 0;
			double kg_fabricados = 0;
			int tiras_fabricadas = 0;
			int cantidad_tochos = 0;
			int largo_tochos = 0;

			if (horaIN.Text != "")
			{
				try
				{ DateTime hora= DateTime.Parse("01.01.21 " +  horaIN.Text);}

				catch (Exception) { MessageBox.Show("Revisar campo Hora Inicio. Formato incorrecto"); prueba = false; }
			}

			if (HoraFin.Text != "")
			{
				try
				{ DateTime hora = DateTime.Parse(HoraFin.Text); }

				catch (Exception) { MessageBox.Show("Revisar campo Hora Fin. Formato incorrecto"); prueba = false; }
			}



			if (PesoMetroTXT.Text != "")
			{
				try
				{peso_metro = double.Parse(PesoMetroTXT.Text);}

				catch (Exception) { MessageBox.Show("Revisar campo peso/metro. Formato incorrecto"); prueba = false; }
			}
            else {
				matriz = Conexion.ObtenerMatriz(pedido.Matriz);
				peso_metro = matriz.Peso;
				//MessageBox.Show(peso_metro.ToString());
			} 


			if (KgTXT.Text != "")
			{
				try
				{

					kg_fabricados = double.Parse(KgTXT.Text);
				}

				catch (Exception) { MessageBox.Show("Revisar campo Kg fabricados. Formato incorrecto"); prueba = false; }
			}

			if (TirasTXT.Text != "")
			{
				try
			{
				
					tiras_fabricadas = int.Parse(TirasTXT.Text);
				}
			
			catch (Exception) { MessageBox.Show("Revisar campo Tiras. Formato incorrecto"); prueba = false; }
			}


			if (CanTochoTXT.Text != "")
			{
				try
				{

					cantidad_tochos = int.Parse(CanTochoTXT.Text);
				}

				catch (Exception) { MessageBox.Show("Revisar campo cantidad de tochos. Formato incorrecto"); prueba = false; }
			}


			if (LargoTochoTXT.Text != "")
			{
				try
				{

					largo_tochos = int.Parse(LargoTochoTXT.Text);
				}

				catch (Exception) { MessageBox.Show("Revisar campo largo de tochos. Formato incorrecto"); prueba = false; }
			}

			if (prueba == true && MatrizComboBox.Text!="Seleccione"  && PrensaCBX.Text != "Seleccione" && NumOPTXT.Text != "" && TurnoCBX.Text != "Seleccione" && AleacionComboBox.Text != "Seleccione")
            {
				int kg_acumulados = 0;
                try
                {
					kg_acumulados = int.Parse(KgTXT.Text);

				}
				catch (Exception) { }

				Conexion.AgregarDetallePedido(FechaDTP.Value, horaIN.Text, HoraFin.Text, kg_fabricados, tiras_fabricadas, LargoTXT.Text, peso_metro, ColadaTXT.Text, ObervTXT.Text, largo_tochos, cantidad_tochos,(int)MatrizComboBox.SelectedValue, (int)PrensaCBX.SelectedValue, pedido.ID, (int)TurnoCBX.SelectedValue, (int)AleacionComboBox.SelectedValue, kg_acumulados,decimal.ToInt32(DiamTocho.Value),double.Parse(KgPrensa.Text));
				Limpiar();
				Buscar_Click(sender, e);

				DialogResult result = MessageBox.Show("¿Desea marcar el pedido " + pedido.Numero.ToString() + " como Terminado?", "Reporte de Producción", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

				switch (result)
				{
					case DialogResult.Yes:
						Conexion.ModificarEstado(pedido.Numero.ToString(), 5,false);
						break;
					case DialogResult.No:
						//Conexion.ModificarEstado(pedido.Numero.ToString(), 2,false);
						break;

				}

			}
            else
            {
				MessageBox.Show("revise los campos ingresados");
            }
        }



		private void Limpiar()
		{
			
			ClienteTBX.Text = "";
			ArticuloTXB.Text = "";
			CodigoTXB.Text = "";
			AleacionComboBox.Text = "Seleccione";
			MatrizComboBox.DataSource = null;
			MatrizComboBox.Items.Clear();

			PesoMetroTXT.Text = "";
			FechaDTP.Value = DateTime.Today;
			horaIN.Text = "";
			HoraFin.Text = "";
			PrensaCBX.Text = "Seleccione";
			AleacionComboBox.Text = "Seleccione";
			TurnoCBX.Text = "Seleccione";
			ColadaTXT.Text = "";
			LargoTochoTXT.Text = "";
			CanTochoTXT.Text = "";
			KgTXT.Text = "";
			TirasTXT.Text = "";
			LargoTXT.Text = "";
			ObervTXT.Text = "";
			KgPrensa.Text = "";


		}

        private void ModificarBTN_Click(object sender, EventArgs e)
        {
			bool prueba = true;
			double peso_metro = 0;
			double kg_fabricados = 0;
			int tiras_fabricadas = 0;
			int cantidad_tochos = 0;
			int largo_tochos = 0;

			if (horaIN.Text != "")
			{
				try
				{ DateTime hora = DateTime.Parse("01.01.21 " + horaIN.Text); }

				catch (Exception) { MessageBox.Show("Revisar campo Hora Inicio. Formato incorrecto"); prueba = false; }
			}

			if (HoraFin.Text != "")
			{
				try
				{ DateTime hora = DateTime.Parse(HoraFin.Text); }

				catch (Exception) { MessageBox.Show("Revisar campo Hora Fin. Formato incorrecto"); prueba = false; }
			}



			if (PesoMetroTXT.Text != "")
			{
				try
				{ peso_metro = double.Parse(PesoMetroTXT.Text); }

				catch (Exception) { MessageBox.Show("Revisar campo peso/metro. Formato incorrecto"); prueba = false; }
			}
			else
			{
				matriz = Conexion.ObtenerMatriz(pedido.Matriz);
				peso_metro = matriz.Peso;
				//MessageBox.Show(peso_metro.ToString());
			}


			if (KgTXT.Text != "")
			{
				try
				{

					kg_fabricados = double.Parse(KgTXT.Text);
				}

				catch (Exception) { MessageBox.Show("Revisar campo Kg fabricados. Formato incorrecto"); prueba = false; }
			}

			if (TirasTXT.Text != "")
			{
				try
				{

					tiras_fabricadas = int.Parse(TirasTXT.Text);
				}

				catch (Exception) { MessageBox.Show("Revisar campo Tiras. Formato incorrecto"); prueba = false; }
			}


			if (CanTochoTXT.Text != "")
			{
				try
				{

					cantidad_tochos = int.Parse(CanTochoTXT.Text);
				}

				catch (Exception) { MessageBox.Show("Revisar campo cantidad de tochos. Formato incorrecto"); prueba = false; }
			}


			if (LargoTochoTXT.Text != "")
			{
				try
				{

					largo_tochos = int.Parse(LargoTochoTXT.Text);
				}

				catch (Exception) { MessageBox.Show("Revisar campo largo de tochos. Formato incorrecto"); prueba = false; }
			}

			if (prueba == true && MatrizComboBox.Text != "Seleccione" && PrensaCBX.Text != "Seleccione" && NumOPTXT.Text != "" && TurnoCBX.Text != "Seleccione" && AleacionComboBox.Text != "Seleccione")
			{
				bool check = false;
				for (int fila = 0; fila < Cuadro.Rows.Count; fila++)
				{	
					if ((bool)Cuadro.Rows[fila].Cells[0].Value == true)
					{
						check = true;break;
					}	
				}

				if (check == true)
				{
					Conexion.ModificarDetallePedido((int)Cuadro.Rows[n].Cells[1].Value, FechaDTP.Value, horaIN.Text, HoraFin.Text, kg_fabricados, tiras_fabricadas, LargoTXT.Text, peso_metro, ColadaTXT.Text, ObervTXT.Text, largo_tochos, cantidad_tochos, (int)MatrizComboBox.SelectedValue, (int)PrensaCBX.SelectedValue, (int)TurnoCBX.SelectedValue, (int)AleacionComboBox.SelectedValue, (double)Cuadro.Rows[n].Cells[18].Value, decimal.ToInt32(DiamTocho.Value),double.Parse(KgPrensa.Text),pedido.ID);
					Limpiar();
					Buscar_Click(sender, e);

					DialogResult result = MessageBox.Show("¿Desea marcar el pedido " + pedido.Numero.ToString() + " como Terminado?", "Reporte de Producción", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

					switch (result)
					{
						case DialogResult.Yes:
							Conexion.ModificarEstado(pedido.Numero.ToString(), 5, false);
							break;
						case DialogResult.No:
							//Conexion.ModificarEstado(pedido.Numero.ToString(), 2, false);
							break;

					}
				}


				else { MessageBox.Show("No hay ningun registro seleccionado"); }



			}
			else
			{
				MessageBox.Show("revise los campos ingresados");
			}

		}

        private void QuitarBTN_Click(object sender, EventArgs e)
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
				Conexion.EliminarDetallePedido((int)Cuadro.Rows[n].Cells[1].Value, (int)Cuadro.Rows[n].Cells[6].Value, (double)Cuadro.Rows[n].Cells[18].Value);
				Limpiar();
				Buscar_Click(sender, e);
			}


			else { MessageBox.Show("No hay ningun registro seleccionado"); }
		}

        private void CanTochoTXT_TextChanged(object sender, EventArgs e)
        {

		}

		private void CanTochoTXT_Leave(object sender, EventArgs e)
		{
            try
            {
                double radioTocho = (decimal.ToDouble(DiamTocho.Value) * 25.4) / 2;
				double largoBarrote = double.Parse(LargoTochoTXT.Text) / 1000;
				int cantidadBarrotes = int.Parse(CanTochoTXT.Text);
				double pesobarrote = Math.Round((radioTocho * radioTocho) * Math.PI /1000 * 2.7 * largoBarrote, 2);
				double kgPrensa = Math.Round(pesobarrote * 0.7 * cantidadBarrotes, 2);
				KgPrensa.Text = kgPrensa.ToString();
			}
            catch (Exception) { KgPrensa.Text = "0"; }

		}

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void KgPrensa_TextChanged(object sender, EventArgs e)
        {
            try
            {
                double radioTocho = (decimal.ToDouble(DiamTocho.Value) * 25.4) / 2;
                double largoBarrote = double.Parse(LargoTochoTXT.Text) / 1000;
                int cantidadBarrotes = int.Parse(CanTochoTXT.Text);
                double pesobarrote = Math.Round((radioTocho * radioTocho) * Math.PI / 1000 * 2.7 * largoBarrote, 2);
                double kgPrensa = double.Parse(KgPrensa.Text);
                double porcentaje = kgPrensa / cantidadBarrotes / pesobarrote * 100;
                Rendimiento1.Value = decimal.Parse(porcentaje.ToString());
			}
            catch (Exception) {
			}

}

        private void KgTXT_TextChanged(object sender, EventArgs e)
        {
			try
			{
				double radioTocho = (decimal.ToDouble(DiamTocho.Value) * 25.4) / 2;
				double largoBarrote = double.Parse(LargoTochoTXT.Text) / 1000;
				int cantidadBarrotes = int.Parse(CanTochoTXT.Text);
				double pesobarrote = Math.Round((radioTocho * radioTocho) * Math.PI / 1000 * 2.7 * largoBarrote, 2);
				double kgr = double.Parse(KgTXT.Text);
				double porcentaje = kgr / cantidadBarrotes / pesobarrote * 100;
				Rendimiento2.Value = decimal.Parse(porcentaje.ToString());
			}
			catch (Exception)
			{
			}
		}
    }
}