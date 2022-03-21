
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Data;
using MySql.Data.MySqlClient;

namespace Login
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class Login : Form
	{
		public Login()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		void SalirClick(object sender, EventArgs e)
		{
			this.Close();
	
		}


		void EntrarClick(object sender, EventArgs e)
        {
			try
			{


				MySqlConnection conectar = Conexion.ObtenerConexion();
				conectar.Open();
				DataTable dt = new DataTable();
				try
				{
					MySqlCommand comand = new MySqlCommand("ObtenerUsuario", conectar);
					comand.CommandType = CommandType.StoredProcedure;
					comand.Parameters.AddWithValue("@parametro1", Usuario.Text);
					MySqlDataAdapter adp = new MySqlDataAdapter(comand);
					adp.Fill(dt);
					if (dt.Rows.Count == 1)
					{

						bool prueba = false;
						foreach (DataRow x in dt.Rows)
						{
							if (Usuario.Text != (string)x[1])
							{
								MessageBox.Show("El usuario ingresado no existe", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error);
							}
							else
							{
								if (Contraseña.Text == (string)x[2]) { prueba = true; }


								if (prueba)
								{
									Usuario usuarioNuevo = new Usuario();
									foreach (DataRow y in dt.Rows)
									{
										usuarioNuevo.User = (string)x[1];
										if ((int)y[3] == 0) { usuarioNuevo.TablaCliente = false; }
										else { usuarioNuevo.TablaCliente = true; }

										if ((int)y[4] == 0) { usuarioNuevo.TablaArchivos = false; }
										else { usuarioNuevo.TablaArchivos = true; }

										if ((int)y[5] == 0) { usuarioNuevo.TablaArticulos = false; }
										else { usuarioNuevo.TablaArticulos = true; }

										if ((int)y[6] == 0) { usuarioNuevo.TablaPedidos = false; }
										else { usuarioNuevo.TablaPedidos = true; }

										if ((int)y[7] == 0) { usuarioNuevo.TablaMatrices = false; }
										else { usuarioNuevo.TablaMatrices = true; }


										if ((int)y[8] == 0) { usuarioNuevo.Tablausuario = false; }
										else { usuarioNuevo.Tablausuario = true; }


										if ((int)y[9] == 0) { usuarioNuevo.TablaReporte = false; }
										else { usuarioNuevo.TablaReporte = true; }

										//Items Menu
										if ((int)y[10] == 0) { usuarioNuevo.AltaArticulos = false; }
										else { usuarioNuevo.AltaArticulos = true; }

										if ((int)y[11] == 0) { usuarioNuevo.BajaArticulos = false; }
										else { usuarioNuevo.BajaArticulos = true; }

										if ((int)y[12] == 0) { usuarioNuevo.ModificaArticulos = false; }
										else { usuarioNuevo.ModificaArticulos = true; }

										if ((int)y[13] == 0) { usuarioNuevo.AltaClientes = false; }
										else { usuarioNuevo.AltaClientes = true; }

										if ((int)y[14] == 0) { usuarioNuevo.ModificaClientes = false; }
										else { usuarioNuevo.ModificaClientes = true; }

										if ((int)y[15] == 0) { usuarioNuevo.AltaPedidos = false; }
										else { usuarioNuevo.AltaPedidos = true; }

										if ((int)y[16] == 0) { usuarioNuevo.ModificaPedidos = false; }
										else { usuarioNuevo.ModificaPedidos = true; }

										if ((int)y[17] == 0) { usuarioNuevo.DetallePedidos = false; }
										else { usuarioNuevo.DetallePedidos = true; }

										if ((int)y[18] == 0) { usuarioNuevo.AltaMatrices = false; }
										else { usuarioNuevo.AltaMatrices = true; }

										if ((int)y[19] == 0) { usuarioNuevo.ModificaMatrices = false; }
										else { usuarioNuevo.ModificaMatrices = true; }

										if ((int)y[20] == 0) { usuarioNuevo.Nitrurado = false; }
										else { usuarioNuevo.Nitrurado = true; }

									}

									Principal vnappal = new Principal(usuarioNuevo);
									vnappal.Show();
									this.Hide();
								}
								else { MessageBox.Show("Contraseña Incorrecta", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error); }
							}
						}

					}



					else { MessageBox.Show("El usuario ingresado no existe", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error); }
				}

				catch (MySqlException ex) { MessageBox.Show("Error al buscar " + ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error); ; }
				catch (Exception ex) { MessageBox.Show("Error al buscar " + ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error); ; }

				finally { conectar.Close(); }
			}

            catch (Exception)
			{ 
				AutoClosingMessageBox.Show("No se encuentra el servidor","Error",MessageBoxButtons.OK,MessageBoxIcon.Error,1200);
				NombreServidor nameServer = new NombreServidor();
				nameServer.Show();
			}
		}

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}
