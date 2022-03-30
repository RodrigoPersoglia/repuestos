using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Net;
using System.Net.NetworkInformation;
using System.IO;
using System.Drawing.Printing;
using System.Drawing;

namespace Login
{
	/// <summary>
	/// Description of Conexion.
	/// </summary>
	public class Conexion
	{

		
		public static MySqlConnection ObtenerConexion()
		{
			string servidor = "xxx"; 
			try
            {
				StreamReader sr = new StreamReader("NombreServidor.txt");
				servidor = sr.ReadLine();
				sr.Close();
			}
			catch (Exception) { }
			MySqlConnection Conexion = new MySqlConnection("Server="+servidor+";database=repuestos;Uid=cualquierUsuario;pwd=;");
			
			return Conexion;
		}


		public static void AgregarArticulo(string codigo,string codigoProveedor,string numeroProducto,string descripcion,decimal precio,int stockMin, int stockMax, int stockActual,string observaciones,int Marca_ID,int Rubro_ID,int Lado_ID, int Proveedor_ID,string ubicacion,DateTime fecha, string usuario)
		{
			MySqlConnection conectar = Conexion.ObtenerConexion();
			conectar.Open();
			try
			{
				MySqlCommand comand = new MySqlCommand("AgregarArticulo", conectar);
				comand.CommandType = CommandType.StoredProcedure;
				comand.Parameters.AddWithValue("@p1",codigo );
				comand.Parameters.AddWithValue("@p2", codigoProveedor);
				comand.Parameters.AddWithValue("@p3", numeroProducto);
				comand.Parameters.AddWithValue("@p4", descripcion);
				comand.Parameters.AddWithValue("@p5",precio );
				comand.Parameters.AddWithValue("@p6", stockMin);
				comand.Parameters.AddWithValue("@p7", stockMax);
				comand.Parameters.AddWithValue("@p8", stockActual);
				comand.Parameters.AddWithValue("@p9", observaciones);
				comand.Parameters.AddWithValue("@p10", Marca_ID);
				comand.Parameters.AddWithValue("@p11", Rubro_ID);
				comand.Parameters.AddWithValue("@p12", Lado_ID);
				comand.Parameters.AddWithValue("@p13", Proveedor_ID);
				comand.Parameters.AddWithValue("@p14", ubicacion);
				comand.Parameters.AddWithValue("@p15", fecha);
				comand.Parameters.AddWithValue("@p16", usuario);

				comand.ExecuteNonQuery();
				AutoClosingMessageBox.Show("Artículo creado correctamente", "Artículo", MessageBoxButtons.OK, MessageBoxIcon.Information, 1600);
			}
			catch (Exception ex) { MessageBox.Show("Error " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
			finally { conectar.Close(); }
		}


		public static void ModificarArticulo(int id, string codigo, string codigoProveedor, string numeroProducto, string descripcion, decimal precio, int stockMin, int stockMax, int stockActual, string observaciones, int Marca_ID, int Rubro_ID, int Lado_ID, int Proveedor_ID, string ubicacion, DateTime fecha, string usuario)
		{
			MySqlConnection conectar = Conexion.ObtenerConexion();
			conectar.Open();
			try
			{
				MySqlCommand comand = new MySqlCommand("ModificarArticulo", conectar);
				comand.CommandType = CommandType.StoredProcedure;
				comand.Parameters.AddWithValue("@p0", id);
				comand.Parameters.AddWithValue("@p1", codigo);
				comand.Parameters.AddWithValue("@p2", codigoProveedor);
				comand.Parameters.AddWithValue("@p3", numeroProducto);
				comand.Parameters.AddWithValue("@p4", descripcion);
				comand.Parameters.AddWithValue("@p5", precio);
				comand.Parameters.AddWithValue("@p6", stockMin);
				comand.Parameters.AddWithValue("@p7", stockMax);
				comand.Parameters.AddWithValue("@p8", stockActual);
				comand.Parameters.AddWithValue("@p9", observaciones);
				comand.Parameters.AddWithValue("@p10", Marca_ID);
				comand.Parameters.AddWithValue("@p11", Rubro_ID);
				comand.Parameters.AddWithValue("@p12", Lado_ID);
				comand.Parameters.AddWithValue("@p13", Proveedor_ID);
				comand.Parameters.AddWithValue("@p14", ubicacion);
				comand.Parameters.AddWithValue("@p15", fecha);
				comand.Parameters.AddWithValue("@p16", usuario);

				comand.ExecuteNonQuery();
				AutoClosingMessageBox.Show("Artículo modificado correctamente", "Artículo", MessageBoxButtons.OK, MessageBoxIcon.Information, 1600);
			}
			catch (Exception ex) { MessageBox.Show("Error " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
			finally { conectar.Close(); }
		}

		public static void AgregarEquivalencia(string codigo, int equivalencia_ID)
		{
			MySqlConnection conectar = Conexion.ObtenerConexion();
			conectar.Open();
			try
			{
				MySqlCommand comand = new MySqlCommand("AgregarEquivalencia", conectar);
				comand.CommandType = CommandType.StoredProcedure;
				comand.Parameters.AddWithValue("@p1", codigo);
				comand.Parameters.AddWithValue("@p2", equivalencia_ID);
				comand.ExecuteNonQuery();
			}
			catch (Exception ex) { MessageBox.Show("Error " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
			finally { conectar.Close(); }
		}

		public static void AgregarCompatibilidad(string codigo, int compatibilidad_ID)
		{
			MySqlConnection conectar = Conexion.ObtenerConexion();
			conectar.Open();
			try
			{
				MySqlCommand comand = new MySqlCommand("AgregarCompatibilidad", conectar);
				comand.CommandType = CommandType.StoredProcedure;
				comand.Parameters.AddWithValue("@p1", codigo);
				comand.Parameters.AddWithValue("@p2", compatibilidad_ID);
				comand.ExecuteNonQuery();
			}
			catch (Exception ex) { MessageBox.Show("Error " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
			finally { conectar.Close(); }
		}



		public static Cliente ObtenerCliente(string busqueda)
		{
			MySqlConnection conectar = Conexion.ObtenerConexion();
			conectar.Open();
			DataTable dt = new DataTable();
            try
            {
                MySqlCommand comand = new MySqlCommand("ObtenerCliente", conectar);
				comand.CommandType = CommandType.StoredProcedure;
				comand.Parameters.AddWithValue("@p1", busqueda);
				MySqlDataAdapter adp = new MySqlDataAdapter(comand);
				adp.Fill(dt);
				if (dt.Rows.Count == 1)
				{
					Cliente cliente = new Cliente();
					foreach (DataRow x in dt.Rows)
					{
						cliente.ID = (int)x[0];
					cliente.Numero = (int)x[1];
					cliente.Alias = (string)x[2];
					
					if (x[3] != null)
					{
						try { cliente.RazonSocial = (string)x[3];}
						catch (Exception) { }
					}

					if (x[4] != null)
					{
						try { cliente.Cuit = (int)x[4]; }
						catch (Exception) { }
					}

					if (x[5] != null)
					{
						try { cliente.Telefono1 = (string)x[5]; }
						catch (Exception) { }
					}

					if (x[6] != null)
					{
						try { cliente.Telefono2 = (string)x[6]; }
						catch (Exception) { }
					}


					cliente.IDDireccion = (int)x[7];
					cliente.Direccion = (string)x[8];
					cliente.Ciudad = (string)x[9];
					cliente.Provincia = (string)x[10];
					cliente.CP = (string)x[11];

					cliente.IDDireccion2 = (int)x[12];
					cliente.Direccion2 = (string)x[13];
					cliente.Ciudad2 = (string)x[14];
					cliente.Provincia2 = (string)x[15];
					cliente.CP2 = (string)x[16];

					cliente.IVA = (string)x[17];
					cliente.TIPODOC = (string)x[18];
					cliente.Bonificacion = (decimal)x[19];
					cliente.Recargo = (decimal)x[20];




					}
					return cliente;
				}
				else { 
					VentanaSeleccion2 selec = new VentanaSeleccion2(busqueda);
					DialogResult resultado = selec.ShowDialog();
					return selec.ClienteSeleccionado; }

        }
            catch (Exception ex) { MessageBox.Show("Error al buscar " + ex.Message,"Atención",MessageBoxButtons.OK,MessageBoxIcon.Error); return null; }
            finally { conectar.Close(); }
        }

		public static Cliente ObtenerClientePorNumero(string busqueda)
		{
			MySqlConnection conectar = Conexion.ObtenerConexion();
			conectar.Open();
			DataTable dt = new DataTable();
			try
			{
				MySqlCommand comand = new MySqlCommand("obtenerClienteporNumero", conectar);
				comand.CommandType = CommandType.StoredProcedure;
				comand.Parameters.AddWithValue("@p1", busqueda);
				MySqlDataAdapter adp = new MySqlDataAdapter(comand);
				adp.Fill(dt);
				if (dt.Rows.Count == 1)
				{
					Cliente cliente = new Cliente();
					foreach (DataRow x in dt.Rows)
					{
						cliente.ID = (int)x[0];
						cliente.Numero = (int)x[1];
						cliente.Alias = (string)x[2];

						if (x[3] != null)
						{
							try { cliente.RazonSocial = (string)x[3]; }
							catch (Exception) { }
						}

						if (x[4] != null)
						{
							try { cliente.Cuit = (int)x[4]; }
							catch (Exception) { }
						}

						if (x[5] != null)
						{
							try { cliente.Telefono1 = (string)x[5]; }
							catch (Exception) { }
						}

						if (x[6] != null)
						{
							try { cliente.Telefono2 = (string)x[6]; }
							catch (Exception) { }
						}


						cliente.IDDireccion = (int)x[7];
						cliente.Direccion = (string)x[8];
						cliente.Ciudad = (string)x[9];
						cliente.Provincia = (string)x[10];
						cliente.CP = (string)x[11];

						cliente.IDDireccion2 = (int)x[12];
						cliente.Direccion2 = (string)x[13];
						cliente.Ciudad2 = (string)x[14];
						cliente.Provincia2 = (string)x[15];
						cliente.CP2 = (string)x[16];

						cliente.IVA = (string)x[17];
						cliente.TIPODOC = (string)x[18];
						cliente.Bonificacion = (decimal)x[19];
						cliente.Recargo = (decimal)x[20];



					}
					return cliente;
				}
				else
				{
					VentanaSeleccion2 selec = new VentanaSeleccion2(busqueda);
					DialogResult resultado = selec.ShowDialog();
					return selec.ClienteSeleccionado;
				}

			}
			catch (Exception ex) { MessageBox.Show("Error al buscar " + ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error); return null; }
			finally { conectar.Close(); }
		}


		public static Cliente ObtenerProveedor(string busqueda)
		{
			MySqlConnection conectar = Conexion.ObtenerConexion();
			conectar.Open();
			DataTable dt = new DataTable();
			try
			{
				MySqlCommand comand = new MySqlCommand("ObtenerProveedor", conectar);
				comand.CommandType = CommandType.StoredProcedure;
				comand.Parameters.AddWithValue("@p1", busqueda);
				MySqlDataAdapter adp = new MySqlDataAdapter(comand);
				adp.Fill(dt);
				if (dt.Rows.Count == 1)
				{
					Cliente cliente = new Cliente();
					foreach (DataRow x in dt.Rows)
					{
						cliente.ID = (int)x[0];
						cliente.Numero = (int)x[1];
						cliente.Alias = (string)x[2];

						if (x[3] != null)
						{
							try { cliente.RazonSocial = (string)x[3]; }
							catch (Exception) { }
						}

						if (x[4] != null)
						{
							try { cliente.Cuit = (int)x[4]; }
							catch (Exception) { }
						}

						if (x[5] != null)
						{
							try { cliente.Telefono1 = (string)x[5]; }
							catch (Exception) { }
						}

						if (x[6] != null)
						{
							try { cliente.Telefono2 = (string)x[6]; }
							catch (Exception) { }
						}


						cliente.IDDireccion = (int)x[7];
						cliente.Direccion = (string)x[8];
						cliente.Ciudad = (string)x[9];
						cliente.Provincia = (string)x[10];
						cliente.CP = (string)x[11];

						cliente.IDDireccion2 = (int)x[12];
						cliente.Direccion2 = (string)x[13];
						cliente.Ciudad2 = (string)x[14];
						cliente.Provincia2 = (string)x[15];
						cliente.CP2 = (string)x[16];

						cliente.IVA = (string)x[17];
						cliente.TIPODOC = (string)x[18];



					}
					return cliente;
				}
				else
				{
					SeleccionProvedores selec = new SeleccionProvedores(busqueda);
					DialogResult resultado = selec.ShowDialog();
					return selec.ClienteSeleccionado;
				}

			}
			catch (Exception ex) { MessageBox.Show("Error al buscar " + ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error); return null; }
			finally { conectar.Close(); }
		}





		public static bool ExisteArticulo(string busqueda)
		{
			MySqlConnection conectar = Conexion.ObtenerConexion();
			MySqlDataReader reader;
			// Hago la consulta a la base de datos
			string consulta = "SELECT a.codigo FROM articulo a";
			conectar.Open();
			try
			{
				MySqlCommand comand = new MySqlCommand(consulta, conectar);
				reader = comand.ExecuteReader();
				if (reader.HasRows)
				{
					while (reader.Read())
					{
						if (busqueda == reader.GetString(0)) { return true; }

					}
				}
				return false;
			}
					
			catch (MySqlException ex) { MessageBox.Show("Error al buscar " + ex.Message,"Atención",MessageBoxButtons.OK,MessageBoxIcon.Error); return false; }
			finally {conectar.Close(); }

		}

		public static Pedido ObtenerPedido(string busqueda)
		{
			MySqlConnection conectar = Conexion.ObtenerConexion();
			conectar.Open();
			DataTable dt = new DataTable();
			try
			{
				MySqlCommand comand = new MySqlCommand("consultaPedidos", conectar);
				comand.CommandType = CommandType.StoredProcedure;
				comand.Parameters.AddWithValue("@parametro1", busqueda);
				MySqlDataAdapter adp = new MySqlDataAdapter(comand);
				adp.Fill(dt);
				if(dt.Rows.Count == 1)
				{
					Pedido pedido = new Pedido();
					foreach (DataRow x in dt.Rows)
					{
						pedido.ID = (int)x[0];
						pedido.Numero = (int)x[1];
						pedido.Fecha = (DateTime)x[2];
                    try { pedido.KgEstimados = (double)x[3]; }
					catch (Exception) { pedido.KgEstimados = 0; }
						pedido.OrdenCompra = (string)x[4];
						pedido.Observaciones = (string)x[5];
						pedido.Cliente = (string)x[6];
						pedido.Articulo = (string)x[7];
						pedido.Unidad = (string)x[8];
						pedido.Terminacion = (string)x[9];
						pedido.Estado = (string)x[10];
						pedido.Prioridad = (string)x[11];
						pedido.Aleacion = (string)x[12];
						pedido.Temple = (string)x[13];
						pedido.Codigo_Articulo = x[17].ToString();
						pedido.Matriz = (int)x[18];
					}
					return pedido;
				}
				else{ MessageBox.Show("El numero ingresado no corresponde a un pedido", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error); return null;}

			}
			catch (Exception ex) { MessageBox.Show("Error al buscar " + ex.Message,"Atención",MessageBoxButtons.OK,MessageBoxIcon.Error); return null; }
			finally { conectar.Close(); }

		}

		public static DataTable ObtenerDetallepedido(string busqueda)
		{
			MySqlConnection conectar = Conexion.ObtenerConexion();
			conectar.Open();
			DataTable dt = new DataTable();
			try
			{
				MySqlCommand comand = new MySqlCommand("consultaPedidoDetalle", conectar);
				comand.CommandType = CommandType.StoredProcedure;
				comand.Parameters.AddWithValue("@parametro1", busqueda);
				MySqlDataAdapter adp = new MySqlDataAdapter(comand);
				adp.Fill(dt);
				if (dt.Rows.Count>0)
				{
					
					return dt;
				}
				else { MessageBox.Show("El numero de pedido ingresado no tiene detalle"); return null; }

			}
			catch (Exception ex) { MessageBox.Show("Error al buscar " + ex.Message,"Atención",MessageBoxButtons.OK,MessageBoxIcon.Error); return null; }
			finally { conectar.Close(); }

		}

		public static void EliminarDetalle(string ID_Pedido)
        {
			MySqlConnection conectar = Conexion.ObtenerConexion();
			conectar.Open();
			try
			{
				MySqlCommand comand = new MySqlCommand("eliminardetalle", conectar);
				comand.CommandType = CommandType.StoredProcedure;
				comand.Parameters.AddWithValue("@parametro1", ID_Pedido);
				comand.ExecuteNonQuery();

			}
			catch (Exception ex) { MessageBox.Show("Error " + ex.Message); }
			finally { conectar.Close(); }
		}

		public static void ModificarPedido(int ID_Pedido,int numero,string fecha,double kgEstimados, string oc,string observaciones,int cliente,int articulo,int unidad, int terminacion, int prioridad,int aleacion,int temple)
		{
			MySqlConnection conectar = Conexion.ObtenerConexion();
			conectar.Open();
			try
			{
				MySqlCommand comand = new MySqlCommand("eliminardetalle", conectar);
				comand.CommandType = CommandType.StoredProcedure;
				comand.Parameters.AddWithValue("@p1", ID_Pedido);
				comand.Parameters.AddWithValue("@p2", numero);
				comand.Parameters.AddWithValue("@p3", fecha);
				comand.Parameters.AddWithValue("@p4", kgEstimados);
				comand.Parameters.AddWithValue("@p5", oc);
				comand.Parameters.AddWithValue("@p6", observaciones);
				comand.Parameters.AddWithValue("@p7", cliente);
				comand.Parameters.AddWithValue("@p8", articulo);
				comand.Parameters.AddWithValue("@p9", unidad);
				comand.Parameters.AddWithValue("@p10", terminacion);
				comand.Parameters.AddWithValue("@p11", prioridad);
				comand.Parameters.AddWithValue("@p12", aleacion);
				comand.Parameters.AddWithValue("@p13", temple);
				comand.ExecuteNonQuery();
				MessageBox.Show("Pedido modificado");
			}
			catch (Exception ex) { MessageBox.Show("Error " + ex.Message); }
			finally { conectar.Close(); }
		}



		public static DataTable VerMatriz(string busqueda)
		{
			MySqlConnection conectar = Conexion.ObtenerConexion();
			conectar.Open();
			DataTable dt = new DataTable();
			try
			{
				MySqlCommand comand = new MySqlCommand("verMatriz", conectar);
				comand.CommandType = CommandType.StoredProcedure;
				comand.Parameters.AddWithValue("@parametro1", busqueda);
				MySqlDataAdapter adp = new MySqlDataAdapter(comand);
				adp.Fill(dt);
				if (dt.Rows.Count >0)
				{
					return dt;
				}
				else { MessageBox.Show("El Artículo ingresado no tiene matrices asociadas disponibles","Atencion",MessageBoxButtons.OK, MessageBoxIcon.Warning); return null; }

			}
			catch (Exception ex) { MessageBox.Show("Error al buscar matriz " + ex.Message); return null; }
			finally { conectar.Close(); }
		}


		public static Matriz ObtenerMatriz(int busqueda)
		{
			MySqlConnection conectar = Conexion.ObtenerConexion();
			conectar.Open();
			DataTable dt = new DataTable();
            try
            {
                MySqlCommand comand = new MySqlCommand("ObtenerMatriz", conectar);
				comand.CommandType = CommandType.StoredProcedure;
				comand.Parameters.AddWithValue("@parametro1", busqueda);
				MySqlDataAdapter adp = new MySqlDataAdapter(comand);
				adp.Fill(dt);
				if (dt.Rows.Count == 1)
				{
					Matriz matriz = new Matriz();
					foreach (DataRow x in dt.Rows)
					{

                        matriz.ID = (int)x[0];
                        matriz.Leyenda = (string)x[1];
                        matriz.Ejemplar = (int)x[2];
                        matriz.Salidas = (int)x[3];
                        matriz.Peso = decimal.ToDouble((decimal)x[4]);
                        matriz.Codigo = (string)x[5];
                        matriz.Estado = (string)x[6];
						matriz.Propietario = (int)x[7];
						matriz.KgAcumulados = (int)x[8];
						matriz.KgAcumulados2 = (int)x[9];
						matriz.Controlada = (bool)x[10];

					}
					return matriz;
				}
				else { MessageBox.Show("El numero ingresado no corresponde a un pedido"); return null; }

        }
            catch (Exception ex) { MessageBox.Show("Error al buscar " + ex.Message,"Atención",MessageBoxButtons.OK,MessageBoxIcon.Error); return null; }
            finally { conectar.Close(); }

        }

		public static string VerEstado(string busqueda)
		{
			MySqlConnection conectar = Conexion.ObtenerConexion();
			conectar.Open();
			DataTable dt = new DataTable();
			try
			{
				MySqlCommand comand = new MySqlCommand("verEstado", conectar);
				comand.CommandType = CommandType.StoredProcedure;
				comand.Parameters.AddWithValue("@p1", busqueda);
				MySqlDataAdapter adp = new MySqlDataAdapter(comand);
				adp.Fill(dt);
				if (dt.Rows.Count == 1)
				{
					string estado = "";
					foreach (DataRow x in dt.Rows)
					{

						//matriz.ID = (int)x[0];
						estado = (string)x[1];

					}
					return estado;
				}
				else { MessageBox.Show("El numero ingresado no corresponde a un pedido"); return null; }

			}
			catch (Exception ex) { MessageBox.Show("Error al buscar " + ex.Message,"Atención",MessageBoxButtons.OK,MessageBoxIcon.Error); return null; }
			finally { conectar.Close(); }

		}


		public static void ModificarEstado(string numPedido,int EstadoID)
		{
			MySqlConnection conectar = Conexion.ObtenerConexion();
			conectar.Open();
			try
			{
				MySqlCommand comand = new MySqlCommand("modificarEstado", conectar);
				comand.CommandType = CommandType.StoredProcedure;
				comand.Parameters.AddWithValue("@p1", numPedido);
				comand.Parameters.AddWithValue("@p2", EstadoID);
				comand.ExecuteNonQuery();
				AutoClosingMessageBox.Show("Estado del pedido Modificado","Pedido",MessageBoxButtons.OK,MessageBoxIcon.Asterisk,1600);
			}
			catch (Exception ex) { MessageBox.Show("Error " + ex.Message); }
			finally { conectar.Close(); }
		}

		public static void ModificarEstado(string numPedido, int EstadoID, bool notificar)
		{
            if (notificar)
			{
				MySqlConnection conectar = Conexion.ObtenerConexion();
				conectar.Open();
				try
				{
					MySqlCommand comand = new MySqlCommand("modificarEstado", conectar);
					comand.CommandType = CommandType.StoredProcedure;
					comand.Parameters.AddWithValue("@p1", numPedido);
					comand.Parameters.AddWithValue("@p2", EstadoID);
					comand.ExecuteNonQuery();
					AutoClosingMessageBox.Show("Estado del pedido Modificado", "Pedido", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, 1600);
				}
				catch (Exception ex) { MessageBox.Show("Error " + ex.Message); }
				finally { conectar.Close(); }

            }
            else
            {
				MySqlConnection conectar = Conexion.ObtenerConexion();
				conectar.Open();
				try
				{
					MySqlCommand comand = new MySqlCommand("modificarEstado", conectar);
					comand.CommandType = CommandType.StoredProcedure;
					comand.Parameters.AddWithValue("@p1", numPedido);
					comand.Parameters.AddWithValue("@p2", EstadoID);
					comand.ExecuteNonQuery();
					
				}
				catch (Exception ex) { MessageBox.Show("Error " + ex.Message); }
				finally { conectar.Close(); }

			}

		}


		public static void AgregarMatriz(int ejemplar,int salidas, double pesoActual,int Articulo_ID,int Cliente_ID)
		{
			MySqlConnection conectar = Conexion.ObtenerConexion();
			conectar.Open();
			try
			{
				MySqlCommand comand = new MySqlCommand("AgregarMatriz", conectar);
				comand.CommandType = CommandType.StoredProcedure;
				comand.Parameters.AddWithValue("@p1", ejemplar);
				comand.Parameters.AddWithValue("@p2", salidas);
				comand.Parameters.AddWithValue("@p3", pesoActual);
				comand.Parameters.AddWithValue("@p4", Articulo_ID);
				comand.Parameters.AddWithValue("@p5", Cliente_ID);
				

				comand.ExecuteNonQuery();
				MessageBox.Show("Matriz Agregada");
			}
			catch (Exception ex) { MessageBox.Show("Error " + ex.Message); }
			finally { conectar.Close(); }
		}



		public static void EliminarLocalidad(string localidad)
		{
			MySqlConnection conectar = Conexion.ObtenerConexion();
			conectar.Open();
			try
			{
				MySqlCommand comand = new MySqlCommand("eliminarLocalidad", conectar);
				comand.CommandType = CommandType.StoredProcedure;
				comand.Parameters.AddWithValue("@p1", localidad);
				comand.ExecuteNonQuery();
				MessageBox.Show("Localidad Eliminada");

			}
			catch (MySqlException) { MessageBox.Show("No se puede eliminar una Localidad que registre actividad"); }
			catch (Exception ex) { MessageBox.Show("Error " + ex.Message); }
			finally { conectar.Close(); }
		}




		public static void CrearCliente(string dirFisc,int provFisc,string CodPosFis,string dirEnt, int provEnt, string CodPosEnt,int numero,string Alias,string RazonSocial,long cuit,string tel1,string tel2,int tipoDoc,int IVA,decimal Bonificacion,decimal Recargo)
		{
			int dirF = 0;
			int dirE = 0;
			DataTable dt = new DataTable();
			MySqlConnection conectar = Conexion.ObtenerConexion();
			conectar.Open();
			try
			{
				MySqlCommand comand = new MySqlCommand("guardarDireccion", conectar);
				comand.CommandType = CommandType.StoredProcedure;
				comand.Parameters.AddWithValue("@p1", dirFisc);
				comand.Parameters.AddWithValue("@p2", provFisc);
				comand.Parameters.AddWithValue("@p3", CodPosFis);
				comand.ExecuteNonQuery();

				MySqlCommand comand2 = new MySqlCommand("guardarDireccion", conectar);
				comand2.CommandType = CommandType.StoredProcedure;
				comand2.Parameters.AddWithValue("@p1", dirEnt);
				comand2.Parameters.AddWithValue("@p2", provEnt);
				comand2.Parameters.AddWithValue("@p3", CodPosEnt);
				comand2.ExecuteNonQuery();


				MySqlCommand comand3 = new MySqlCommand("UltimasDirecciones", conectar);
				comand3.CommandType = CommandType.StoredProcedure;
				MySqlDataAdapter adp = new MySqlDataAdapter(comand3);
				adp.Fill(dt);
				if (dt.Rows.Count == 2)
				{
					int contador = 0;
					foreach (DataRow x in dt.Rows)
					{

						if (contador == 0)
						{
							dirE = (int)x[0];
						}
						else { dirF = (int)x[0]; }
						contador++;
					}
				}


				MySqlCommand comand4 = new MySqlCommand("CrearCliente", conectar);
                comand4.CommandType = CommandType.StoredProcedure;
				comand4.Parameters.AddWithValue("@p1", numero);
				comand4.Parameters.AddWithValue("@p2", Alias);
				comand4.Parameters.AddWithValue("@p3", RazonSocial);
				comand4.Parameters.AddWithValue("@p4", cuit);
				comand4.Parameters.AddWithValue("@p5", tel1);
				comand4.Parameters.AddWithValue("@p6", tel2);
				comand4.Parameters.AddWithValue("@p7", dirF);
				comand4.Parameters.AddWithValue("@p8", dirE);
				comand4.Parameters.AddWithValue("@p9", tipoDoc);
				comand4.Parameters.AddWithValue("@p10", IVA);
				comand4.Parameters.AddWithValue("@p11", Bonificacion);
				comand4.Parameters.AddWithValue("@p12",Recargo);
				comand4.ExecuteNonQuery();

                    MessageBox.Show("Cliente Creado correctamente");
			}
			catch (Exception ex) { MessageBox.Show("Error " + ex.Message); }
			finally { conectar.Close(); }
		}


		public static void CrearProveedor(string dirFisc, int provFisc, string CodPosFis, string dirEnt, int provEnt, string CodPosEnt, int numero, string Alias, string RazonSocial, long cuit, string tel1, string tel2, int tipoDoc, int IVA)
		{
			int dirF = 0;
			int dirE = 0;
			DataTable dt = new DataTable();
			MySqlConnection conectar = Conexion.ObtenerConexion();
			conectar.Open();
			try
			{
				MySqlCommand comand = new MySqlCommand("guardarDireccion", conectar);
				comand.CommandType = CommandType.StoredProcedure;
				comand.Parameters.AddWithValue("@p1", dirFisc);
				comand.Parameters.AddWithValue("@p2", provFisc);
				comand.Parameters.AddWithValue("@p3", CodPosFis);
				comand.ExecuteNonQuery();

				MySqlCommand comand2 = new MySqlCommand("guardarDireccion", conectar);
				comand2.CommandType = CommandType.StoredProcedure;
				comand2.Parameters.AddWithValue("@p1", dirEnt);
				comand2.Parameters.AddWithValue("@p2", provEnt);
				comand2.Parameters.AddWithValue("@p3", CodPosEnt);
				comand2.ExecuteNonQuery();


				MySqlCommand comand3 = new MySqlCommand("UltimasDirecciones", conectar);
				comand3.CommandType = CommandType.StoredProcedure;
				MySqlDataAdapter adp = new MySqlDataAdapter(comand3);
				adp.Fill(dt);
				if (dt.Rows.Count == 2)
				{
					int contador = 0;
					foreach (DataRow x in dt.Rows)
					{

						if (contador == 0)
						{
							dirE = (int)x[0];
						}
						else { dirF = (int)x[0]; }
						contador++;
					}
				}


				MySqlCommand comand4 = new MySqlCommand("CrearProveedor", conectar);
				comand4.CommandType = CommandType.StoredProcedure;
				comand4.Parameters.AddWithValue("@p1", numero);
				comand4.Parameters.AddWithValue("@p2", Alias);
				comand4.Parameters.AddWithValue("@p3", RazonSocial);
				comand4.Parameters.AddWithValue("@p4", cuit);
				comand4.Parameters.AddWithValue("@p5", tel1);
				comand4.Parameters.AddWithValue("@p6", tel2);
				comand4.Parameters.AddWithValue("@p7", dirF);
				comand4.Parameters.AddWithValue("@p8", dirE);
				comand4.Parameters.AddWithValue("@p9", tipoDoc);
				comand4.Parameters.AddWithValue("@p10", IVA);
				comand4.ExecuteNonQuery();

				MessageBox.Show("Proveedor Creado correctamente");
			}
			catch (Exception ex) { MessageBox.Show("Error " + ex.Message); }
			finally { conectar.Close(); }
		}



		public static void AgregarDetallePedido(DateTime fecha, string horaInicio, string horaFin, double kgs, int tiras, string largoPerfil, double pesoMetro, string colada, string observaciones, int largoTocho, int cantidadTochos, int matriz_ID, int puesto_ID, int pedido_ID, int turno_ID, int Aleacion_ID,  int Kg, int diamTocho, double kgPrensa)
		{
			MySqlConnection conectar = Conexion.ObtenerConexion();
			conectar.Open();
            try
            {
                MySqlCommand comand = new MySqlCommand("AgregarDetalleFabricacion", conectar);
				comand.CommandType = CommandType.StoredProcedure;
				comand.Parameters.AddWithValue("@fecha", fecha);
				comand.Parameters.AddWithValue("@horaInicio", horaInicio);
				comand.Parameters.AddWithValue("@horaFin", horaFin);
				comand.Parameters.AddWithValue("@kgs", kgs);
				comand.Parameters.AddWithValue("@tiras", tiras);
				comand.Parameters.AddWithValue("@largoPerfil", largoPerfil);
				comand.Parameters.AddWithValue("@pesoMetro", pesoMetro);
				comand.Parameters.AddWithValue("@colada", colada);
				comand.Parameters.AddWithValue("@observaciones", observaciones);
				comand.Parameters.AddWithValue("@largoTocho", largoTocho);
				comand.Parameters.AddWithValue("@cantidadTochos", cantidadTochos);
				comand.Parameters.AddWithValue("@matriz_ID", matriz_ID);
				comand.Parameters.AddWithValue("@prensa", puesto_ID);
				comand.Parameters.AddWithValue("@pedido_ID", pedido_ID);
				comand.Parameters.AddWithValue("@turno_ID", turno_ID);
				comand.Parameters.AddWithValue("@Aleacion_ID", Aleacion_ID);
				comand.Parameters.AddWithValue("@kg_acumulados", Kg);
				comand.Parameters.AddWithValue("@p18", diamTocho);
				comand.Parameters.AddWithValue("@p19", kgPrensa);
				comand.ExecuteNonQuery();
				MessageBox.Show("Detalle de fabricación guardado");
        }
			catch (Exception ex) { MessageBox.Show("Error " + ex.Message); }
			finally { conectar.Close(); }

		}

		public static DataTable VerDetalleFabricacion(int numero)
		{
			MySqlConnection conectar = Conexion.ObtenerConexion();
			conectar.Open();
			DataTable dt = new DataTable();
			try
			{
				MySqlCommand comand = new MySqlCommand(" VerDetalleFabricacion", conectar);
				comand.CommandType = CommandType.StoredProcedure;
				comand.Parameters.AddWithValue("@p1", numero);
				MySqlDataAdapter adp = new MySqlDataAdapter(comand);
				adp.Fill(dt);
				if (dt.Rows.Count > 0)
				{
					return dt;
				}
				else { MessageBox.Show("No tiene detalle de fabricacion"); return null; }

			}
			catch (Exception ex) { MessageBox.Show("Error al buscar " + ex.Message,"Atención",MessageBoxButtons.OK,MessageBoxIcon.Error); return null; }
			finally { conectar.Close(); }
		}

		public static void ModificarCliente(int clienteID,int numero, string alias, string razonSocial, int cuit, string tel1, string tel2, int tipoDoc, int iva, string calleNumero, int LocalidadID, string codigoPostal,string  calleNumero2, int localidadID2, string codigoPostal2, decimal bonificacion,decimal recargo)
		{
			MySqlConnection conectar = Conexion.ObtenerConexion();
			conectar.Open();
			try
			{
				MySqlCommand comand = new MySqlCommand("ModificarCliente", conectar);
				comand.CommandType = CommandType.StoredProcedure;
				comand.Parameters.AddWithValue("@p0", clienteID);
				comand.Parameters.AddWithValue("@p1", numero);
				comand.Parameters.AddWithValue("@p2", alias);
				comand.Parameters.AddWithValue("@p3", razonSocial);
				comand.Parameters.AddWithValue("@p4", cuit);
				comand.Parameters.AddWithValue("@p5", tel1);
				comand.Parameters.AddWithValue("@p6", tel2);
				comand.Parameters.AddWithValue("@p7", tipoDoc);
				comand.Parameters.AddWithValue("@p8", iva);

				comand.Parameters.AddWithValue("@p9", calleNumero);
				comand.Parameters.AddWithValue("@p10", LocalidadID);
				comand.Parameters.AddWithValue("@p11", codigoPostal);

				comand.Parameters.AddWithValue("@p12", calleNumero2);
				comand.Parameters.AddWithValue("@p13", localidadID2);
				comand.Parameters.AddWithValue("@p14", codigoPostal2);
				comand.Parameters.AddWithValue("@p15", bonificacion);
				comand.Parameters.AddWithValue("@p16", recargo);

				comand.ExecuteNonQuery();
				MessageBox.Show("Cliente modificado");
			}
			catch (Exception ex) { MessageBox.Show("Error " + ex.Message); }
			finally { conectar.Close(); }
		}

		public static void ModificarProveedor(int clienteID, int numero, string alias, string razonSocial, int cuit, string tel1, string tel2, int tipoDoc, int iva, string calleNumero, int LocalidadID, string codigoPostal, string calleNumero2, int localidadID2, string codigoPostal2)
		{
			MySqlConnection conectar = Conexion.ObtenerConexion();
			conectar.Open();
			try
			{
				MySqlCommand comand = new MySqlCommand("ModificarProveedor", conectar);
				comand.CommandType = CommandType.StoredProcedure;
				comand.Parameters.AddWithValue("@p0", clienteID);
				comand.Parameters.AddWithValue("@p1", numero);
				comand.Parameters.AddWithValue("@p2", alias);
				comand.Parameters.AddWithValue("@p3", razonSocial);
				comand.Parameters.AddWithValue("@p4", cuit);
				comand.Parameters.AddWithValue("@p5", tel1);
				comand.Parameters.AddWithValue("@p6", tel2);
				comand.Parameters.AddWithValue("@p7", tipoDoc);
				comand.Parameters.AddWithValue("@p8", iva);

				comand.Parameters.AddWithValue("@p9", calleNumero);
				comand.Parameters.AddWithValue("@p10", LocalidadID);
				comand.Parameters.AddWithValue("@p11", codigoPostal);

				comand.Parameters.AddWithValue("@p12", calleNumero2);
				comand.Parameters.AddWithValue("@p13", localidadID2);
				comand.Parameters.AddWithValue("@p14", codigoPostal2);

				comand.ExecuteNonQuery();
				MessageBox.Show("Proveedor modificado");
			}
			catch (Exception ex) { MessageBox.Show("Error " + ex.Message); }
			finally { conectar.Close(); }
		}




		public static Articulo ObtenerArticulo(string buscar, Form formulario)
		{
			MySqlConnection conectar = Conexion.ObtenerConexion();
			conectar.Open();
			DataTable dt = new DataTable();
            try
            {
                MySqlCommand comand = new MySqlCommand("BuscarArticulo", conectar);
				comand.CommandType = CommandType.StoredProcedure;
				comand.Parameters.AddWithValue("@busqueda", buscar);
				MySqlDataAdapter adp = new MySqlDataAdapter(comand);
				adp.Fill(dt);
				if (dt.Rows.Count == 1)
				{
					Articulo articulo = new Articulo();
					foreach (DataRow x in dt.Rows)
					{
						
						articulo.ID = (int)x[0];
						articulo.Codigo = (string)x[1];
						articulo.CodigoProveedor = (string)x[2];
						articulo.NumeroPieza = (string)x[3];
						articulo.Descripcion = (string)x[4];
						articulo.Precio = decimal.ToDouble((decimal)x[5]);
						articulo.StockMin = (int)x[6];
						articulo.StockMax = (int)x[7];
						articulo.StockActual = (int)x[8];
						try { articulo.Observaciones = (string)x[9]; }
						catch (Exception) { articulo.Observaciones = ""; }
						articulo.Marca = (int)x[10];
						articulo.Rubro = (int)x[11];
						articulo.Lado = (int)x[12];
						articulo.Proveedor = (int)x[13];
						articulo.Ubicacion = (string)x[14];
						articulo.NombreProveedor = (string)x[19];

					}
					return articulo;
				}
				else {
					SeleccionArticulo selec = new SeleccionArticulo(buscar);
					selec.ShowDialog();
					selec.Dispose();
					return selec.ArticuloSeleccionado;
				}

            }
            catch (Exception ex) { MessageBox.Show("Error al buscar en conexion" + ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error); return null; }
            finally { conectar.Close(); }


        }



		public static void ModificarMatriz(int ID, int salidas, double peso, int cliente, int estado , int  kgAcumulados, int kgAcumulados2, bool controlada)
		{
			MySqlConnection conectar = Conexion.ObtenerConexion();
			conectar.Open();
			try
			{
				MySqlCommand comand = new MySqlCommand("ModificarMatriz", conectar);
				comand.CommandType = CommandType.StoredProcedure;
				comand.Parameters.AddWithValue("@p1", ID);
				comand.Parameters.AddWithValue("@p2", salidas);
				comand.Parameters.AddWithValue("@p3", peso);
				comand.Parameters.AddWithValue("@p4", cliente);
				comand.Parameters.AddWithValue("@p5", estado);
				comand.Parameters.AddWithValue("@p6", kgAcumulados);
				comand.Parameters.AddWithValue("@p7", kgAcumulados2);
				comand.Parameters.AddWithValue("@p8", controlada);
				comand.ExecuteNonQuery();
				MessageBox.Show("Matriz modificada");
			}
			catch (Exception ex) { MessageBox.Show("Error " + ex.Message); }
			finally { conectar.Close(); }
		}



		public static DataTable ObtenerProyeccion (DateTime fecha, int prensa_ID)
        {
			MySqlConnection conectar = Conexion.ObtenerConexion();
			conectar.Open();
			DataTable dt = new DataTable();
			try
			{
				MySqlCommand comand = new MySqlCommand("proyeccion", conectar);
				comand.CommandType = CommandType.StoredProcedure;
				comand.Parameters.AddWithValue("@p1", fecha);
				comand.Parameters.AddWithValue("@p2", prensa_ID);
				MySqlDataAdapter adp = new MySqlDataAdapter(comand);
				adp.Fill(dt);
				if (dt.Rows.Count > 0)
				{

					return dt;
				}
				else { MessageBox.Show("No hay registros en el intervalo seleccionado"); return null; }

			}

			catch (Exception ex) { MessageBox.Show("Error al buscar " + ex.Message,"Atención",MessageBoxButtons.OK,MessageBoxIcon.Error); return null; }
			finally { conectar.Close(); }
		}


		public static DataTable ObtenerProyeccion2(DateTime fecha, int prensa_ID)
		{
			MySqlConnection conectar = Conexion.ObtenerConexion();
			conectar.Open();
			DataTable dt = new DataTable();
			try
			{
				MySqlCommand comand = new MySqlCommand("proyeccion2", conectar);
				comand.CommandType = CommandType.StoredProcedure;
				comand.Parameters.AddWithValue("@p1", fecha);
				comand.Parameters.AddWithValue("@p2", prensa_ID);
				MySqlDataAdapter adp = new MySqlDataAdapter(comand);
				adp.Fill(dt);
				if (dt.Rows.Count > 0)
				{

					return dt;
				}
				else { MessageBox.Show("No hay registros en el intervalo seleccionado"); return null; }

			}

			catch (Exception ex) { MessageBox.Show("Error al buscar " + ex.Message,"Atención",MessageBoxButtons.OK,MessageBoxIcon.Error); return null; }
			finally { conectar.Close(); }
		}

		public static DataTable ObtenerProyeccion3(DateTime fecha, int prensa_ID)
		{
			MySqlConnection conectar = Conexion.ObtenerConexion();
			conectar.Open();
			DataTable dt = new DataTable();
			try
			{
				MySqlCommand comand = new MySqlCommand("proyeccion3", conectar);
				comand.CommandType = CommandType.StoredProcedure;
				comand.Parameters.AddWithValue("@p1", fecha);
				comand.Parameters.AddWithValue("@p2", prensa_ID);
				MySqlDataAdapter adp = new MySqlDataAdapter(comand);
				adp.Fill(dt);
				if (dt.Rows.Count > 0)
				{

					return dt;
				}
				else { MessageBox.Show("No hay registros en el intervalo seleccionado"); return null; }

			}

			catch (Exception ex) { MessageBox.Show("Error al buscar " + ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error); return null; }
			finally { conectar.Close(); }
		}

		public static DataTable ObtenerProyeccion4(DateTime fecha, int prensa_ID)
		{
			MySqlConnection conectar = Conexion.ObtenerConexion();
			conectar.Open();
			DataTable dt = new DataTable();
			try
			{
				MySqlCommand comand = new MySqlCommand("proyeccion4", conectar);
				comand.CommandType = CommandType.StoredProcedure;
				comand.Parameters.AddWithValue("@p1", fecha);
				comand.Parameters.AddWithValue("@p2", prensa_ID);
				MySqlDataAdapter adp = new MySqlDataAdapter(comand);
				adp.Fill(dt);
				if (dt.Rows.Count > 0)
				{

					return dt;
				}
				else { MessageBox.Show("No hay registros en el intervalo seleccionado"); return null; }

			}

			catch (Exception ex) { MessageBox.Show("Error al buscar " + ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error); return null; }
			finally { conectar.Close(); }
		}


		public static void ModificarDetallePedido(int idDetalle,DateTime fecha, string horaInicio, string horaFin, double kgs, int tiras, string largoPerfil, double pesoMetro, string colada, string observaciones, int largoTocho, int cantidadTochos, int matriz_ID, int puesto_ID, int turno_ID, int Aleacion_ID,double kgs_Anteriores,int diamTocho, double kgPrensa, int pedido_ID)
		{
			MySqlConnection conectar = Conexion.ObtenerConexion();
			conectar.Open();
			try
			{
				MySqlCommand comand = new MySqlCommand("ModificarDetalleFabricacion", conectar);
				comand.CommandType = CommandType.StoredProcedure;

				comand.Parameters.AddWithValue("@p0", idDetalle);
				comand.Parameters.AddWithValue("@p1", pesoMetro);
				comand.Parameters.AddWithValue("@p2", fecha);
				comand.Parameters.AddWithValue("@p3", horaInicio);
				comand.Parameters.AddWithValue("@p4", horaFin);
				comand.Parameters.AddWithValue("@p5", puesto_ID);
				comand.Parameters.AddWithValue("@p6", turno_ID);
				comand.Parameters.AddWithValue("@p7", Aleacion_ID);
				comand.Parameters.AddWithValue("@p8", colada);
				comand.Parameters.AddWithValue("@p9", largoTocho);
				comand.Parameters.AddWithValue("@p10", cantidadTochos);
				comand.Parameters.AddWithValue("@p11", kgs);
				comand.Parameters.AddWithValue("@p12", tiras);
				comand.Parameters.AddWithValue("@p13", largoPerfil);
				comand.Parameters.AddWithValue("@p14", observaciones);
				comand.Parameters.AddWithValue("@p15", matriz_ID);
				comand.Parameters.AddWithValue("@p16", kgs_Anteriores);
				comand.Parameters.AddWithValue("@p18", diamTocho);
				comand.Parameters.AddWithValue("@p19", kgPrensa);
				comand.Parameters.AddWithValue("@p20", pedido_ID);
				comand.ExecuteNonQuery();
				MessageBox.Show("Detalle de fabricación modificado");
			}
			catch (Exception ex) { MessageBox.Show("Error " + ex.Message); }
			finally { conectar.Close(); }

		}


		public static void EliminarDetallePedido(int idDetalle, int matriz_ID, double kgs_Anteriores)
		{
			MySqlConnection conectar = Conexion.ObtenerConexion();
			conectar.Open();
			try
			{
				MySqlCommand comand = new MySqlCommand("EliminarDetalleFabricacion", conectar);
				comand.CommandType = CommandType.StoredProcedure;

				comand.Parameters.AddWithValue("@p0", idDetalle);
				comand.Parameters.AddWithValue("@p2", matriz_ID);
				comand.Parameters.AddWithValue("@p1", kgs_Anteriores);

				comand.ExecuteNonQuery();
				MessageBox.Show("Detalle de fabricación eliminado");
			}
			catch (Exception ex) { MessageBox.Show("Error " + ex.Message); }
			finally { conectar.Close(); }

		}

		public static DataTable EnProduccion()
		{
			MySqlConnection conectar = Conexion.ObtenerConexion();
			conectar.Open();
			DataTable dt = new DataTable();
			try
			{
				MySqlCommand comand = new MySqlCommand("EnProduccion", conectar);
				comand.CommandType = CommandType.StoredProcedure;
				//comand.Parameters.AddWithValue("@p1", fecha);
				MySqlDataAdapter adp = new MySqlDataAdapter(comand);
				adp.Fill(dt);
				if (dt.Rows.Count > 0)
				{

					return dt;
				}
				else { MessageBox.Show("No hay registros en el intervalo seleccionado"); return null; }

			}

			catch (Exception ex) { MessageBox.Show("Error al buscar " + ex.Message,"Atención",MessageBoxButtons.OK,MessageBoxIcon.Error); return null; }
			finally { conectar.Close(); }
		}


		public static void AgregarUsuario(string usuario, string contraseña , int cliente, int archivos, int articulos, int pedidos , int matrices, int usuarios, int reportes, int altaArticulo, int BajaArticulo, int ModificaArticulo, int AltaCliente, int modificaCliente, int altaPedido, int ModificaPedido, int detallePedido, int altaMatriz, int modificaMatriz, int nitrurado)
		{
			MySqlConnection conectar = Conexion.ObtenerConexion();
			conectar.Open();
            try
            {
                MySqlCommand comand = new MySqlCommand("AgregarUsuario", conectar);
				comand.CommandType = CommandType.StoredProcedure;
				comand.Parameters.AddWithValue("@p1", usuario);
				comand.Parameters.AddWithValue("@p2", contraseña);
				comand.Parameters.AddWithValue("@p3", cliente);
				comand.Parameters.AddWithValue("@p4", archivos);
				comand.Parameters.AddWithValue("@p5", articulos);
				comand.Parameters.AddWithValue("@p6", pedidos);
				comand.Parameters.AddWithValue("@p7", matrices);
				comand.Parameters.AddWithValue("@p8", usuarios);
				comand.Parameters.AddWithValue("@p9", reportes);

				comand.Parameters.AddWithValue("@p10", altaArticulo);
				comand.Parameters.AddWithValue("@p11", BajaArticulo);
				comand.Parameters.AddWithValue("@p12", ModificaArticulo);
				comand.Parameters.AddWithValue("@p13", AltaCliente);
				comand.Parameters.AddWithValue("@p14", modificaCliente);
				comand.Parameters.AddWithValue("@p15", altaPedido);
				comand.Parameters.AddWithValue("@p16", ModificaPedido);
				comand.Parameters.AddWithValue("@p17", detallePedido);
				comand.Parameters.AddWithValue("@p18", altaMatriz);
				comand.Parameters.AddWithValue("@p19", modificaMatriz);
				comand.Parameters.AddWithValue("@p20", nitrurado);
				comand.ExecuteNonQuery();
				AutoClosingMessageBox.Show("Usuario Creado Correctamente","Usuario",MessageBoxButtons.OK,MessageBoxIcon.Information,1600);
            }
            catch (Exception ex) { MessageBox.Show("Error " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            finally { conectar.Close(); }
        }



		public static DataTable ObtenerUsuarios()
		{
			MySqlConnection conectar = Conexion.ObtenerConexion();
			conectar.Open();
			DataTable dt = new DataTable();
			try
			{
				MySqlCommand comand = new MySqlCommand("verUsuarios", conectar);
				comand.CommandType = CommandType.StoredProcedure;
				MySqlDataAdapter adp = new MySqlDataAdapter(comand);
				adp.Fill(dt);
				return dt;
			}

			catch (Exception ex) { MessageBox.Show("Error al buscar " + ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error); return null; }
			finally { conectar.Close(); }
		}



		public static void ModificarUsuario(int id,string usuario, string contraseña, int cliente, int archivos, int articulos, int pedidos, int matrices, int usuarios, int reportes, int altaArticulo, int BajaArticulo, int ModificaArticulo, int AltaCliente, int modificaCliente, int altaPedido, int ModificaPedido, int detallePedido, int altaMatriz, int modificaMatriz, int nitrurado)
		{
			MySqlConnection conectar = Conexion.ObtenerConexion();
			conectar.Open();
			try
			{
				MySqlCommand comand = new MySqlCommand("ModificarUsuario", conectar);
				comand.CommandType = CommandType.StoredProcedure;

				comand.Parameters.AddWithValue("@p0", id);
				comand.Parameters.AddWithValue("@p1", usuario);
				comand.Parameters.AddWithValue("@p2", contraseña);
				comand.Parameters.AddWithValue("@p3", cliente);
				comand.Parameters.AddWithValue("@p4", archivos);
				comand.Parameters.AddWithValue("@p5", articulos);
				comand.Parameters.AddWithValue("@p6", pedidos);
				comand.Parameters.AddWithValue("@p7", matrices);
				comand.Parameters.AddWithValue("@p8", usuarios);
				comand.Parameters.AddWithValue("@p9", reportes);

				comand.Parameters.AddWithValue("@p10", altaArticulo);
				comand.Parameters.AddWithValue("@p11", BajaArticulo);
				comand.Parameters.AddWithValue("@p12", ModificaArticulo);
				comand.Parameters.AddWithValue("@p13", AltaCliente);
				comand.Parameters.AddWithValue("@p14", modificaCliente);
				comand.Parameters.AddWithValue("@p15", altaPedido);
				comand.Parameters.AddWithValue("@p16", ModificaPedido);
				comand.Parameters.AddWithValue("@p17", detallePedido);
				comand.Parameters.AddWithValue("@p18", altaMatriz);
				comand.Parameters.AddWithValue("@p19", modificaMatriz);
				comand.Parameters.AddWithValue("@p20", nitrurado);

				comand.ExecuteNonQuery();
				AutoClosingMessageBox.Show("Usuario Modificado","Usuario",MessageBoxButtons.OK,MessageBoxIcon.Information,1600);
			}
			catch (Exception ex) { MessageBox.Show("Error " + ex.Message,"Atención",MessageBoxButtons.OK,MessageBoxIcon.Error); }
			finally { conectar.Close(); }
		}


		public static void EliminarUsuario(int ID)
		{
			MySqlConnection conectar = ObtenerConexion();
			conectar.Open();
			try
			{
				MySqlCommand comand = new MySqlCommand("EliminarUsuario", conectar);
				comand.CommandType = CommandType.StoredProcedure;
				comand.Parameters.AddWithValue("@p0", ID);
				comand.ExecuteNonQuery();
				AutoClosingMessageBox.Show("Usuario Eliminado", "Usuario", MessageBoxButtons.OK, MessageBoxIcon.Information, 1600);
			}
			catch (Exception ex) { MessageBox.Show("Error " + ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error); }
			finally { conectar.Close(); }

		}


		public static DataTable ObtenerReporteProdu( DateTime fechaIN , DateTime fechaFin)
		{
			MySqlConnection conectar = Conexion.ObtenerConexion();
			conectar.Open();
			DataTable dt = new DataTable();
			try
			{
				MySqlCommand comand = new MySqlCommand("ObtenerKGrango", conectar);
				comand.CommandType = CommandType.StoredProcedure;
				comand.Parameters.AddWithValue("@p1", fechaIN);
				comand.Parameters.AddWithValue("@p2", fechaFin);
				MySqlDataAdapter adp = new MySqlDataAdapter(comand);
				adp.Fill(dt);
				if (dt.Rows.Count > 0)
				{

					return dt;
				}
				else { MessageBox.Show("No hay registros en el intervalo seleccionado"); return null; }

			}

			catch (Exception ex) { MessageBox.Show("Error al buscar " + ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error); return null; }
			finally { conectar.Close(); }
		}

		public static DataTable ObtenerReporteDiario(DateTime fecha)
		{
			MySqlConnection conectar = Conexion.ObtenerConexion();
			conectar.Open();
			DataTable dt = new DataTable();
			try
			{
				MySqlCommand comand = new MySqlCommand("ObtenerKgDia", conectar);
				comand.CommandType = CommandType.StoredProcedure;
				comand.Parameters.AddWithValue("@p1", fecha);
				MySqlDataAdapter adp = new MySqlDataAdapter(comand);
				adp.Fill(dt);
				if (dt.Rows.Count > 0)
				{

					return dt;
				}
				else { MessageBox.Show("No hay registros en la fecha seleccionada"); return null; }

			}

			catch (Exception ex) { MessageBox.Show("Error al buscar " + ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error); return null; }
			finally { conectar.Close(); }
		}



		public static void AgregarNitrurado(DateTime fecha, int matriz_ID)
		{
			MySqlConnection conectar = Conexion.ObtenerConexion();
			conectar.Open();
			try
			{
				MySqlCommand comand = new MySqlCommand("AgregarNitrurado", conectar);
				comand.CommandType = CommandType.StoredProcedure;
				comand.Parameters.AddWithValue("@p1", fecha);
				comand.Parameters.AddWithValue("@p2", matriz_ID);

				comand.ExecuteNonQuery();
				AutoClosingMessageBox.Show("Nitrurado cargado correctamente", "Nitrurado", MessageBoxButtons.OK, MessageBoxIcon.Information, 1600);
			}
			catch (Exception ex) { MessageBox.Show("Error " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
			finally { conectar.Close(); }
		}


		public static DataTable VerLocalidad(int provincia_ID)
		{
			MySqlConnection conectar = Conexion.ObtenerConexion();
			conectar.Open();
			DataTable dt = new DataTable();
			try
			{
				MySqlCommand comand = new MySqlCommand("verLocalidad", conectar);
				comand.CommandType = CommandType.StoredProcedure;
				comand.Parameters.AddWithValue("@p1", provincia_ID);
				MySqlDataAdapter adp = new MySqlDataAdapter(comand);
				adp.Fill(dt);
				if (dt.Rows.Count > 0)
				{

					return dt;
				}
				else { MessageBox.Show("No hay registros en la provincia seleccionada"); return null; }

			}

			catch (Exception ex) { MessageBox.Show("Error al buscar " + ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error); return null; }
			finally { conectar.Close(); }
		}

		public static DataTable VerProvincias()
		{
			MySqlConnection conectar = Conexion.ObtenerConexion();
			conectar.Open();
			DataTable dt = new DataTable();
			MySqlDataReader reader;
			string consulta = "SELECT * FROM provincia";
			try
			{

				MySqlCommand comand = new MySqlCommand(consulta, conectar);
				reader = comand.ExecuteReader();
				dt.Load(reader);
				
				if (dt.Rows.Count > 0)
				{

					return dt;
				}
				else { return null; }

			}

			catch (Exception ex) { MessageBox.Show("Error al buscar " + ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error); return null; }
			finally { conectar.Close(); }
		}


		public static void AgregarLocalidad(string localidad, int Provincia_ID)
		{
			MySqlConnection conectar = Conexion.ObtenerConexion();
			conectar.Open();
			try
			{
				MySqlCommand comand = new MySqlCommand("AgregarLocalidad", conectar);
				comand.CommandType = CommandType.StoredProcedure;
				comand.Parameters.AddWithValue("@p1", localidad);
				comand.Parameters.AddWithValue("@p2", Provincia_ID);
				comand.ExecuteNonQuery();
				AutoClosingMessageBox.Show("Localidad creada correctamente", "Localidad", MessageBoxButtons.OK, MessageBoxIcon.Information, 1600);
			}
			catch (Exception ex) { MessageBox.Show("Error " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
			finally { conectar.Close(); }
		}

		public static void ModificarLocalidad(int id,string localidad, int Provincia_ID)
		{
			MySqlConnection conectar = Conexion.ObtenerConexion();
			conectar.Open();
			try
			{
				MySqlCommand comand = new MySqlCommand("ModificarLocalidad", conectar);
				comand.CommandType = CommandType.StoredProcedure;
				comand.Parameters.AddWithValue("@p0", id);
				comand.Parameters.AddWithValue("@p1", localidad);
				comand.Parameters.AddWithValue("@p2", Provincia_ID);
				comand.ExecuteNonQuery();
				AutoClosingMessageBox.Show("Localidad modificada correctamente", "Localidad", MessageBoxButtons.OK, MessageBoxIcon.Information, 1600);
			}
			catch (Exception ex) { MessageBox.Show("Error " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
			finally { conectar.Close(); }
		}


		public static void EliminarLocalidad(int ID)
		{
			MySqlConnection conectar = ObtenerConexion();
			conectar.Open();
			try
			{
				MySqlCommand comand = new MySqlCommand("EliminarLocalidad", conectar);
				comand.CommandType = CommandType.StoredProcedure;
				comand.Parameters.AddWithValue("@p0", ID);
				comand.ExecuteNonQuery();
				AutoClosingMessageBox.Show("Localidad Eliminada", "Localidad", MessageBoxButtons.OK, MessageBoxIcon.Information, 1600);
			}
			catch (Exception ex) { MessageBox.Show("Error " + ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error); }
			finally { conectar.Close(); }

		}


		public static DataTable VerPuesto()
		{
			MySqlConnection conectar = Conexion.ObtenerConexion();
			conectar.Open();
			DataTable dt = new DataTable();
			MySqlDataReader reader;
			string consulta = "SELECT * FROM puesto p order by p.descripcion";
			try
			{

				MySqlCommand comand = new MySqlCommand(consulta, conectar);
				reader = comand.ExecuteReader();
				dt.Load(reader);

				if (dt.Rows.Count > 0)
				{

					return dt;
				}
				else { return null; }

			}

			catch (Exception ex) { MessageBox.Show("Error al buscar " + ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error); return null; }
			finally { conectar.Close(); }
		}

		public static void AgregarPuesto(string puesto, string maquinista,string encargado)
		{
			MySqlConnection conectar = Conexion.ObtenerConexion();
			conectar.Open();
			try
			{
				MySqlCommand comand = new MySqlCommand("AgregarPuesto", conectar);
				comand.CommandType = CommandType.StoredProcedure;
				comand.Parameters.AddWithValue("@p1", puesto);
				comand.Parameters.AddWithValue("@p2", maquinista);
				comand.Parameters.AddWithValue("@p3", encargado);
				comand.ExecuteNonQuery();
				AutoClosingMessageBox.Show("Puesto creado correctamente", "Puesto", MessageBoxButtons.OK, MessageBoxIcon.Information, 1600);
			}
			catch (Exception ex) { MessageBox.Show("Error " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
			finally { conectar.Close(); }
		}


		public static void ModificarPuesto(int id, string puesto, string maquinista, string encargado)
		{
			MySqlConnection conectar = Conexion.ObtenerConexion();
			conectar.Open();
			try
			{
				MySqlCommand comand = new MySqlCommand("ModificarPuesto", conectar);
				comand.CommandType = CommandType.StoredProcedure;
				comand.Parameters.AddWithValue("@p0", id);
				comand.Parameters.AddWithValue("@p1", puesto);
				comand.Parameters.AddWithValue("@p2", maquinista);
				comand.Parameters.AddWithValue("@p3", encargado);
				comand.ExecuteNonQuery();
				AutoClosingMessageBox.Show("Puesto modificado correctamente", "Puesto", MessageBoxButtons.OK, MessageBoxIcon.Information, 1600);
			}
			catch (Exception ex) { MessageBox.Show("Error " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
			finally { conectar.Close(); }
		}


		public static void EliminarPuesto(int ID)
		{
			MySqlConnection conectar = ObtenerConexion();
			conectar.Open();
			try
			{
				MySqlCommand comand = new MySqlCommand("EliminarPuesto", conectar);
				comand.CommandType = CommandType.StoredProcedure;
				comand.Parameters.AddWithValue("@p0", ID);
				comand.ExecuteNonQuery();
				AutoClosingMessageBox.Show("Puesto Eliminado", "Puesto", MessageBoxButtons.OK, MessageBoxIcon.Information, 1600);
			}
			catch (Exception ex) { MessageBox.Show("Error " + ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error); }
			finally { conectar.Close(); }

		}


		public static DataTable GetClasificacion()
		{
			MySqlConnection conectar = Conexion.ObtenerConexion();
			conectar.Open();
			DataTable dt = new DataTable();
			MySqlDataReader reader;
			string consulta = "SELECT * FROM lado c order by c.descripcion";
			try
			{

				MySqlCommand comand = new MySqlCommand(consulta, conectar);
				reader = comand.ExecuteReader();
				dt.Load(reader);

				if (dt.Rows.Count > 0)
				{

					return dt;
				}
				else { return null; }

			}

			catch (Exception ex) { MessageBox.Show("Error al buscar " + ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error); return null; }
			finally { conectar.Close(); }
		}

		public static void AddClasificacion(string descripcion, string precio)
		{
			string consulta = "insert into lado (descripcion,precio) values ('" + descripcion + "', '" + precio + "')";
			MySqlConnection conectar = Conexion.ObtenerConexion();
			conectar.Open();
			try
			{
				MySqlCommand comand = new MySqlCommand(consulta, conectar);
				comand.ExecuteNonQuery();
				AutoClosingMessageBox.Show("Lado creado correctamente", "Lado", MessageBoxButtons.OK, MessageBoxIcon.Information, 1600);
			}
			catch (Exception ex) { MessageBox.Show("Error " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
			finally { conectar.Close(); }
		}


		public static void SetClasificacion(int id, string descripcion, string precio)
		{
			string consulta = "update lado c set descripcion = '" + descripcion+ "', precio = '" + precio + "' where c.id = '" + id.ToString() + "'";
			MySqlConnection conectar = Conexion.ObtenerConexion();
			conectar.Open();
			try
			{
				MySqlCommand comand = new MySqlCommand(consulta, conectar);
				comand.ExecuteNonQuery();
				AutoClosingMessageBox.Show("Lado modificado correctamente", "Lado", MessageBoxButtons.OK, MessageBoxIcon.Information, 1600);
			}
			catch (Exception ex) { MessageBox.Show("Error " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
			finally { conectar.Close(); }
		}

		public static void DeleteClasificacion(int id)
		{
			string consulta = "delete from lado where id = '" + id.ToString() + "'";
			MySqlConnection conectar = Conexion.ObtenerConexion();
			conectar.Open();
			try
			{
				MySqlCommand comand = new MySqlCommand(consulta, conectar);
				comand.ExecuteNonQuery();
				AutoClosingMessageBox.Show("Lado eliminado correctamente", "Lado", MessageBoxButtons.OK, MessageBoxIcon.Information, 1600);
			}
			catch (Exception ex) { MessageBox.Show("Error " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
			finally { conectar.Close(); }
		}



		public static DataTable GetPrioridad()
		{
			MySqlConnection conectar = Conexion.ObtenerConexion();
			conectar.Open();
			DataTable dt = new DataTable();
			MySqlDataReader reader;
			string consulta = "SELECT * FROM prioridad p order by p.descripcion";
			try
			{

				MySqlCommand comand = new MySqlCommand(consulta, conectar);
				reader = comand.ExecuteReader();
				dt.Load(reader);

				if (dt.Rows.Count > 0)
				{

					return dt;
				}
				else { return null; }

			}

			catch (Exception ex) { MessageBox.Show("Error al buscar " + ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error); return null; }
			finally { conectar.Close(); }
		}

		public static void AddPrioridad(string descripcion, string plazo)
		{
			string consulta = "insert into prioridad (descripcion,plazo) values ('" + descripcion + "', '" + plazo + "')";
			MySqlConnection conectar = Conexion.ObtenerConexion();
			conectar.Open();
			try
			{
				MySqlCommand comand = new MySqlCommand(consulta, conectar);
				comand.ExecuteNonQuery();
				AutoClosingMessageBox.Show("Prioridad creada correctamente", "Prioridad", MessageBoxButtons.OK, MessageBoxIcon.Information, 1600);
			}
			catch (Exception ex) { MessageBox.Show("Error " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
			finally { conectar.Close(); }
		}


		public static void SetPrioridad(int id, string descripcion, string plazo)
		{
			string consulta = "update prioridad p set descripcion = '" + descripcion + "', plazo = '" + plazo + "' where p.id = '" + id.ToString() + "'";
			MySqlConnection conectar = Conexion.ObtenerConexion();
			conectar.Open();
			try
			{
				MySqlCommand comand = new MySqlCommand(consulta, conectar);
				comand.ExecuteNonQuery();
				AutoClosingMessageBox.Show("Prioridad modificada correctamente", "Prioridad", MessageBoxButtons.OK, MessageBoxIcon.Information, 1600);
			}
			catch (Exception ex) { MessageBox.Show("Error " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
			finally { conectar.Close(); }
		}

		public static void DeletePrioridad(int id)
		{
			string consulta = "delete from Prioridad where id = '" + id.ToString() + "'";
			MySqlConnection conectar = Conexion.ObtenerConexion();
			conectar.Open();
			try
			{
				MySqlCommand comand = new MySqlCommand(consulta, conectar);
				comand.ExecuteNonQuery();
				AutoClosingMessageBox.Show("Prioridad eliminada correctamente", "Prioridad", MessageBoxButtons.OK, MessageBoxIcon.Information, 1600);
			}
			catch (Exception ex) { MessageBox.Show("Error " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
			finally { conectar.Close(); }
		}


		public static DataTable GetAleacion()
		{
			MySqlConnection conectar = Conexion.ObtenerConexion();
			conectar.Open();
			DataTable dt = new DataTable();
			MySqlDataReader reader;
			string consulta = "SELECT * FROM marca a order by a.descripcion";
			try
			{

				MySqlCommand comand = new MySqlCommand(consulta, conectar);
				reader = comand.ExecuteReader();
				dt.Load(reader);

				if (dt.Rows.Count > 0)
				{

					return dt;
				}
				else { return null; }

			}

			catch (Exception ex) { MessageBox.Show("Error al buscar " + ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error); return null; }
			finally { conectar.Close(); }
		}

		public static void AddAleacion(string descripcion)
		{
			string consulta = "insert into marca (descripcion) values ('" + descripcion + "')";
			MySqlConnection conectar = Conexion.ObtenerConexion();
			conectar.Open();
			try
			{
				MySqlCommand comand = new MySqlCommand(consulta, conectar);
				comand.ExecuteNonQuery();
				AutoClosingMessageBox.Show("Marca creada correctamente", "Marca", MessageBoxButtons.OK, MessageBoxIcon.Information, 1600);
			}
			catch (Exception ex) { MessageBox.Show("Error " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
			finally { conectar.Close(); }
		}


		public static void SetAleacion(int id, string descripcion)
		{
			string consulta = "update marca a set descripcion = '" + descripcion + "' where a.id = " + id.ToString();
			MySqlConnection conectar = Conexion.ObtenerConexion();
			conectar.Open();
			try
			{
				MySqlCommand comand = new MySqlCommand(consulta, conectar);
				comand.ExecuteNonQuery();
				AutoClosingMessageBox.Show("Marca modificada correctamente", "Marca", MessageBoxButtons.OK, MessageBoxIcon.Information, 1600);
			}
			catch (Exception ex) { MessageBox.Show("Error " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
			finally { conectar.Close(); }
		}

		public static void DeleteAleacion(int id)
		{
			string consulta = "delete from marca where id = '" + id.ToString() + "'";
			MySqlConnection conectar = Conexion.ObtenerConexion();
			conectar.Open();
			try
			{
				MySqlCommand comand = new MySqlCommand(consulta, conectar);
				comand.ExecuteNonQuery();
				AutoClosingMessageBox.Show("Marca eliminada correctamente", "Marca", MessageBoxButtons.OK, MessageBoxIcon.Information, 1600);
			}
			catch (Exception ex) { MessageBox.Show("Error " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
			finally { conectar.Close(); }
		}


		public static DataTable GetTemple()
		{
			MySqlConnection conectar = Conexion.ObtenerConexion();
			conectar.Open();
			DataTable dt = new DataTable();
			MySqlDataReader reader;
			string consulta = "SELECT * FROM rubro a order by a.descripcion";
			try
			{

				MySqlCommand comand = new MySqlCommand(consulta, conectar);
				reader = comand.ExecuteReader();
				dt.Load(reader);

				if (dt.Rows.Count > 0)
				{

					return dt;
				}
				else { return null; }

			}

			catch (Exception ex) { MessageBox.Show("Error al buscar " + ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error); return null; }
			finally { conectar.Close(); }
		}

		public static void AddTemple(string descripcion)
		{
			string consulta = "insert into rubro (descripcion) values ('" + descripcion + "')";
			MySqlConnection conectar = Conexion.ObtenerConexion();
			conectar.Open();
			try
			{
				MySqlCommand comand = new MySqlCommand(consulta, conectar);
				comand.ExecuteNonQuery();
				AutoClosingMessageBox.Show("Rubro creado correctamente", "Rubro", MessageBoxButtons.OK, MessageBoxIcon.Information, 1600);
			}
			catch (Exception ex) { MessageBox.Show("Error " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
			finally { conectar.Close(); }
		}


		public static void SetTemple(int id, string descripcion)
		{
			string consulta = "update rubro a set descripcion = '" + descripcion + "' where a.id = " + id.ToString();
			MySqlConnection conectar = Conexion.ObtenerConexion();
			conectar.Open();
			try
			{
				MySqlCommand comand = new MySqlCommand(consulta, conectar);
				comand.ExecuteNonQuery();
				AutoClosingMessageBox.Show("Rubro modificado correctamente", "Rubro", MessageBoxButtons.OK, MessageBoxIcon.Information, 1600);
			}
			catch (Exception ex) { MessageBox.Show("Error " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
			finally { conectar.Close(); }
		}

		public static void DeleteTemple(int id)
		{
			string consulta = "delete from rubro where id = '" + id.ToString() + "'";
			MySqlConnection conectar = Conexion.ObtenerConexion();
			conectar.Open();
			try
			{
				MySqlCommand comand = new MySqlCommand(consulta, conectar);
				comand.ExecuteNonQuery();
				AutoClosingMessageBox.Show("Rubro eliminado correctamente", "Rubro", MessageBoxButtons.OK, MessageBoxIcon.Information, 1600);
			}
			catch (Exception ex) { MessageBox.Show("Error " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
			finally { conectar.Close(); }
		}


		public static DataTable GetTerminacion()
		{
			MySqlConnection conectar = Conexion.ObtenerConexion();
			conectar.Open();
			DataTable dt = new DataTable();
			MySqlDataReader reader;
			string consulta = "SELECT * FROM terminacion a order by a.descripcion";
			try
			{

				MySqlCommand comand = new MySqlCommand(consulta, conectar);
				reader = comand.ExecuteReader();
				dt.Load(reader);

				if (dt.Rows.Count > 0)
				{

					return dt;
				}
				else { return null; }

			}

			catch (Exception ex) { MessageBox.Show("Error al buscar " + ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error); return null; }
			finally { conectar.Close(); }
		}

		public static void AddTerminacion(string descripcion)
		{
			string consulta = "insert into terminacion (descripcion) values ('" + descripcion + "')";
			MySqlConnection conectar = Conexion.ObtenerConexion();
			conectar.Open();
			try
			{
				MySqlCommand comand = new MySqlCommand(consulta, conectar);
				comand.ExecuteNonQuery();
				AutoClosingMessageBox.Show("Terminación creada correctamente", "Terminación", MessageBoxButtons.OK, MessageBoxIcon.Information, 1600);
			}
			catch (Exception ex) { MessageBox.Show("Error " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
			finally { conectar.Close(); }
		}


		public static void SetTerminacion(int id, string descripcion)
		{
			string consulta = "update terminacion a set descripcion = '" + descripcion + "' where a.id = " + id.ToString();
			MySqlConnection conectar = Conexion.ObtenerConexion();
			conectar.Open();
			try
			{
				MySqlCommand comand = new MySqlCommand(consulta, conectar);
				comand.ExecuteNonQuery();
				AutoClosingMessageBox.Show("Terminación modificada correctamente", "Terminación", MessageBoxButtons.OK, MessageBoxIcon.Information, 1600);
			}
			catch (Exception ex) { MessageBox.Show("Error " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
			finally { conectar.Close(); }
		}

		public static void DeleteTerminacion(int id)
		{
			string consulta = "delete from terminacion where id = '" + id.ToString() + "'";
			MySqlConnection conectar = Conexion.ObtenerConexion();
			conectar.Open();
			try
			{
				MySqlCommand comand = new MySqlCommand(consulta, conectar);
				comand.ExecuteNonQuery();
				AutoClosingMessageBox.Show("Terminación eliminada correctamente", "Terminación", MessageBoxButtons.OK, MessageBoxIcon.Information, 1600);
			}
			catch (Exception ex) { MessageBox.Show("Error " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
			finally { conectar.Close(); }
		}



		public static DataTable ReporteNitrurado(int umbral1,int umbral2, int umbral3)
		{
			MySqlConnection conectar = Conexion.ObtenerConexion();
			conectar.Open();
			DataTable dt = new DataTable();
			try
			{
				MySqlCommand comand = new MySqlCommand("ReporteNitrurado", conectar);
				comand.CommandType = CommandType.StoredProcedure;
				comand.Parameters.AddWithValue("@p0", umbral1);
				comand.Parameters.AddWithValue("@p1", umbral2);
				comand.Parameters.AddWithValue("@p2", umbral3);
				MySqlDataAdapter adp = new MySqlDataAdapter(comand);
				adp.Fill(dt);
				if (dt.Rows.Count > 0)
				{

					return dt;
				}
				else { MessageBox.Show("No hay registros según los parametros ingresados"); return null; }

			}

			catch (Exception ex) { MessageBox.Show("Error al buscar " + ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error); return null; }
			finally { conectar.Close(); }
		}



		public static DataTable ReporteMatricesPesadas()
		{
			MySqlConnection conectar = Conexion.ObtenerConexion();
			conectar.Open();
			DataTable dt = new DataTable();
			try
			{
				MySqlCommand comand = new MySqlCommand("VerMatricesPesadas", conectar);
				comand.CommandType = CommandType.StoredProcedure;
				MySqlDataAdapter adp = new MySqlDataAdapter(comand);
				adp.Fill(dt);
				if (dt.Rows.Count > 0)
				{

					return dt;
				}
				else { MessageBox.Show("No hay registros"); return null; }

			}

			catch (Exception ex) { MessageBox.Show("Error al buscar " + ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error); return null; }
			finally { conectar.Close(); }
		}



		public static Modelo ObtenerModelo(string buscar)
		{
			MySqlConnection conectar = Conexion.ObtenerConexion();
			conectar.Open();
			DataTable dt = new DataTable();
			try
			{
				MySqlCommand comand = new MySqlCommand("BuscarModelo", conectar);
				comand.CommandType = CommandType.StoredProcedure;
				comand.Parameters.AddWithValue("@busqueda", buscar);
				MySqlDataAdapter adp = new MySqlDataAdapter(comand);
				adp.Fill(dt);
				if (dt.Rows.Count == 1)
				{
					Modelo modelo = new Modelo();
					foreach (DataRow x in dt.Rows)
					{

						modelo.ID = (int)x[0];
						modelo.Descripcion = (string)x[1];
						modelo.Año = (int)x[2];
						modelo.MarcaID = (int)x[3];
						modelo.Marca = (string)x[4];

					}
					return modelo;
				}
				else
				{
					BusquedaRapida selec = new BusquedaRapida("marca", "modelo", "año", "modelo", buscar);
					DialogResult resultado = selec.ShowDialog();
					int id = selec.IDBusqueda;

					try
					{
						comand = new MySqlCommand("BuscarModeloID", conectar);
						comand.CommandType = CommandType.StoredProcedure;
						comand.Parameters.AddWithValue("@busqueda", id);
						adp = new MySqlDataAdapter(comand);
						adp.Fill(dt);
							Modelo modelo = new Modelo();
							foreach (DataRow x in dt.Rows)
							{

								modelo.ID = (int)x[0];
								modelo.Descripcion = (string)x[1];
								modelo.Año = (int)x[2];
								modelo.MarcaID = (int)x[3];
								modelo.Marca = (string)x[4];

							}
							return modelo;
						}
					catch (Exception ex) { MessageBox.Show("Error al buscar " + ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error); return null; }


				}

			}
			catch (Exception ex) { MessageBox.Show("Error al buscar " + ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error); return null; }
			finally { conectar.Close(); }


		}


		public static DataTable ObtenerEquivalencias(int ID)
		{
			MySqlConnection conectar = Conexion.ObtenerConexion();
			conectar.Open();
			DataTable dt = new DataTable();
			try
			{
				MySqlCommand comand = new MySqlCommand("VerEquivalencia", conectar);
				comand.CommandType = CommandType.StoredProcedure;
				comand.Parameters.AddWithValue("@p1", ID);
				MySqlDataAdapter adp = new MySqlDataAdapter(comand);
				adp.Fill(dt);
				if (dt.Rows.Count > 0)
				{

					return dt;
				}
				else {return null; }
			}

			catch (Exception ex) { MessageBox.Show("Error al buscar " + ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error); return null; }
			finally { conectar.Close(); }
		}

		public static DataTable ObtenerCompatibilidad(int ID)
		{
			MySqlConnection conectar = Conexion.ObtenerConexion();
			conectar.Open();
			DataTable dt = new DataTable();
			try
			{
				MySqlCommand comand = new MySqlCommand("VerCompatibilidad", conectar);
				comand.CommandType = CommandType.StoredProcedure;
				comand.Parameters.AddWithValue("@p1", ID);
				MySqlDataAdapter adp = new MySqlDataAdapter(comand);
				adp.Fill(dt);
				if (dt.Rows.Count > 0)
				{

					return dt;
				}
				else { return null; }
			}

			catch (Exception ex) { MessageBox.Show("Error al buscar " + ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error); return null; }
			finally { conectar.Close(); }
		}

		public static void AgregarFactura(decimal subTotal, decimal iva,decimal total,int cliente_ID,string cliente,string direccion,string localidad,string cp,string usuario,DataTable detalleFactura,int medioPago)
		{
			MySqlConnection conectar = Conexion.ObtenerConexion();
			conectar.Open();
            try
            {
                MySqlCommand comand4 = new MySqlCommand("AgregarFactura", conectar);
				comand4.CommandType = CommandType.StoredProcedure;
				comand4.Parameters.AddWithValue("@p1", DateTime.Now);
				comand4.Parameters.AddWithValue("@p2", subTotal);
				comand4.Parameters.AddWithValue("@p3", iva);
				comand4.Parameters.AddWithValue("@p4", total);
				comand4.Parameters.AddWithValue("@p5", cliente_ID);
				comand4.Parameters.AddWithValue("@p6", cliente);
				comand4.Parameters.AddWithValue("@p7", direccion);
				comand4.Parameters.AddWithValue("@p8", localidad);
				comand4.Parameters.AddWithValue("@p9", cp);
				comand4.Parameters.AddWithValue("@p10", usuario);
				comand4.Parameters.AddWithValue("@p11", medioPago);
				comand4.ExecuteNonQuery();

				foreach (DataRow x in detalleFactura.Rows)
				{
				MySqlCommand comand5 = new MySqlCommand("agregarDetalleFactura", conectar);
				comand5.CommandType = CommandType.StoredProcedure;
				comand5.Parameters.AddWithValue("@p1", x[1].ToString());
				comand5.Parameters.AddWithValue("@p2", x[2].ToString());
				comand5.Parameters.AddWithValue("@p3", int.Parse(x[3].ToString()));
				comand5.Parameters.AddWithValue("@p4", decimal.Parse((x[4]).ToString()));
				comand5.ExecuteNonQuery();
				}

				AutoClosingMessageBox.Show("Comprobante fc nº "+ UltimaFactura().ToString() + " emitido correctamente", "Emisión de comprobantes", MessageBoxButtons.OK, MessageBoxIcon.Information, 1600);
        }
            catch (Exception ex) { MessageBox.Show("Error al buscar " + ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            finally { conectar.Close(); }
        }

		public static string rutaImagen(string codigo)
        {
			string servidor = "";
			try
			{
				StreamReader sr = new StreamReader("NombreServidor.txt");
				servidor = sr.ReadLine();
				sr.Close();
			}
			catch (Exception) { }

			return "imagenes/" + codigo + ".jpg";
		}

		public static string rutaImagenLogo(string codigo)
		{
			string servidor = "";
			try
			{
				StreamReader sr = new StreamReader("NombreServidor.txt");
				servidor = sr.ReadLine();
				sr.Close();
			}
			catch (Exception) { }

			return "imagenes/" + codigo + ".jpg";
		}

		public static bool Validar(string codigo)
		{
			Validacion validar = new Validacion(codigo);
			validar.ShowDialog();
			validar.Dispose();
			return validar.Respuesta;
		}



		public static decimal obtenerRecargoFinanciero(int IDrecargo)
		{
			decimal recargo = 0;
			MySqlConnection conectar = Conexion.ObtenerConexion();
			conectar.Open();
			DataTable dt = new DataTable();
			try
			{
				MySqlCommand comand = new MySqlCommand("obtenerRecargoFinanciero", conectar);
				comand.CommandType = CommandType.StoredProcedure;
				comand.Parameters.AddWithValue("@p1", IDrecargo);
				MySqlDataAdapter adp = new MySqlDataAdapter(comand);
				adp.Fill(dt);
				foreach (DataRow x in dt.Rows)
				{
					recargo = (decimal)x[0];

				}
				return recargo;
			}
			catch (Exception ex) { MessageBox.Show("Error al buscar " + ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error); return recargo; }
			finally { conectar.Close(); }
		}

		public static int UltimaFactura()
		{
			int numFactura = 0;
			MySqlConnection conectar = Conexion.ObtenerConexion();
			conectar.Open();
			DataTable dt = new DataTable();
			MySqlDataReader reader;
			string consulta = "select max(numero) as numeroFactura from factura limit 1";
			try
			{

				MySqlCommand comand = new MySqlCommand(consulta, conectar);
				reader = comand.ExecuteReader();
				dt.Load(reader);

				foreach (DataRow x in dt.Rows)
				{
					numFactura = (int)x[0];

				}
				return numFactura;

			}

			catch (Exception ex) { MessageBox.Show("Error al buscar " + ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error); return numFactura; }
			finally { conectar.Close(); }
		}






		public static DataTable GetMediosPago()
		{
			MySqlConnection conectar = Conexion.ObtenerConexion();
			conectar.Open();
			DataTable dt = new DataTable();
			MySqlDataReader reader;
			string consulta = "SELECT * FROM mediodepago c order by c.numero";
			try
			{

				MySqlCommand comand = new MySqlCommand(consulta, conectar);
				reader = comand.ExecuteReader();
				dt.Load(reader);

				if (dt.Rows.Count > 0)
				{

					return dt;
				}
				else { return null; }

			}

			catch (Exception ex) { MessageBox.Show("Error al buscar " + ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error); return null; }
			finally { conectar.Close(); }
		}




		public static void AddMediosPago(int numero,string descripcion, string precio)
		{
			string consulta = "insert into mediodepago (numero,descripcion,recargo) values ('" + numero + "','" + descripcion + "', '" + precio + "')";
			MySqlConnection conectar = Conexion.ObtenerConexion();
			conectar.Open();
			try
			{
				MySqlCommand comand = new MySqlCommand(consulta, conectar);
				comand.ExecuteNonQuery();
				AutoClosingMessageBox.Show("Medio de pago creado correctamente", "Medios de pago", MessageBoxButtons.OK, MessageBoxIcon.Information, 1600);
			}
			catch (Exception ex) { MessageBox.Show("Error " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
			finally { conectar.Close(); }
		}


		public static void SetMediosPago(int id, int numero,string descripcion, string precio)
		{
			string consulta = "update mediodepago c set numero = '" + numero + "', descripcion = '" + descripcion + "', recargo = '" + precio + "' where c.id = '" + id.ToString() + "'";
			MySqlConnection conectar = Conexion.ObtenerConexion();
			conectar.Open();
			try
			{
				MySqlCommand comand = new MySqlCommand(consulta, conectar);
				comand.ExecuteNonQuery();
				AutoClosingMessageBox.Show("Medio de pago modificado correctamente", "Medios de pago", MessageBoxButtons.OK, MessageBoxIcon.Information, 1600);
			}
			catch (Exception ex) { MessageBox.Show("Error " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
			finally { conectar.Close(); }
		}

		public static void DeleteMediosPago(int id)
		{
			string consulta = "delete from mediodepago where id = '" + id.ToString() + "'";
			MySqlConnection conectar = Conexion.ObtenerConexion();
			conectar.Open();
			try
			{
				MySqlCommand comand = new MySqlCommand(consulta, conectar);
				comand.ExecuteNonQuery();
				AutoClosingMessageBox.Show("Medio de pago eliminado correctamente", "Medios de pago", MessageBoxButtons.OK, MessageBoxIcon.Information, 1600);
			}
			catch (Exception ex) { MessageBox.Show("Error " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
			finally { conectar.Close(); }
		}


		public static DataTable GetComprobante( int numero)
		{
			MySqlConnection conectar = Conexion.ObtenerConexion();
			conectar.Open();
			DataTable dt = new DataTable();
			MySqlDataReader reader;
			string consulta = "select f.cliente,f.total from factura f where f.numero = "+numero;
			try
			{

				MySqlCommand comand = new MySqlCommand(consulta, conectar);
				reader = comand.ExecuteReader();
				dt.Load(reader);

				if (dt.Rows.Count > 0)
				{

					return dt;
				}
				else {
					MessageBox.Show("El numero de comprobante ingresado no existe", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					return null; }

			}

			catch (Exception ex) { MessageBox.Show("Error al buscar " + ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error); return null; }
			finally { conectar.Close(); }
		}



		public static void AnulacionComprobante(int numero,string Usuario)
		{
			bool activa = true;
			string comprobacion = "select activa from factura f where f.numero = " + numero;
			string consulta = "update factura set activa = false where numero = " + numero;
			string consulta2 = "select df.articulo_ID, df.cantidad from detallefactura df inner join factura f on df.factura_ID = f.id where f.numero = " + numero;
			MySqlConnection conectar = Conexion.ObtenerConexion();
			DataTable dt0 = new DataTable();
			MySqlDataReader reader0;
			DataTable dt = new DataTable();
			MySqlDataReader reader;
			conectar.Open();
			try
			{
				MySqlCommand comand0 = new MySqlCommand(comprobacion, conectar);
				reader0 = comand0.ExecuteReader();
				dt0.Load(reader0);
				foreach (DataRow x in dt0.Rows)
				{
                    if ((bool)x[0] == false)
                    {
						activa = false;
                    }
                    else { activa = true; }
				}

                if (activa)
                {

					if (Conexion.Validar(Usuario))
					{

						MySqlCommand comand = new MySqlCommand(consulta, conectar);
						comand.ExecuteNonQuery();
						MySqlCommand comand2 = new MySqlCommand(consulta2, conectar);
						reader = comand2.ExecuteReader();
						dt.Load(reader);

						foreach (DataRow x in dt.Rows)
						{
							string consulta3 = "update articulo a set stockActual = stockActual + " + x[1].ToString() + " where id=" + x[0].ToString();
							MySqlCommand comand3 = new MySqlCommand(consulta3, conectar);
							comand3.ExecuteNonQuery();
						}

						AutoClosingMessageBox.Show("Comprobante anulado correctamente", "Anulación de comprobantes", MessageBoxButtons.OK, MessageBoxIcon.Information, 1600);

					}
					else { MessageBox.Show("Ingrese un usuario y contraseña válido"); }


				}
                else { AutoClosingMessageBox.Show("El comprobante ya se encuentra anulado", "Anulación de comprobantes", MessageBoxButtons.OK, MessageBoxIcon.Information, 1600); }

				
			}
			catch (Exception ex) { MessageBox.Show("Error " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
			finally { conectar.Close(); }
		}




		public static Comprobante GetUltimoComprobante()
		{
			Comprobante comprobante = new Comprobante();
			MySqlConnection conectar = Conexion.ObtenerConexion();
			conectar.Open();
			DataTable dt = new DataTable();
			MySqlDataReader reader;
            string consulta = "select * from factura f order by f.ID desc limit 1";
            try
            {

                MySqlCommand comand = new MySqlCommand(consulta, conectar);
				reader = comand.ExecuteReader();
				dt.Load(reader);
				
				foreach (DataRow x in dt.Rows)
				{

					comprobante.ID = (int)x[0];
					comprobante.Numero = (int)x[1];
					comprobante.FechaHora = (DateTime)x[2];
					comprobante.SubTotal = (decimal)x[3];
					comprobante.Financiación = (decimal)x[4];
					comprobante.Total = (decimal)x[5];
					comprobante.ClienteID = (int)x[6];
					comprobante.Cliente = (string)x[7];
					comprobante.Direccion = (string)x[8];
					comprobante.Localidad = (string)x[9];
					comprobante.CP = (string)x[10];
					comprobante.Usuario = (string)x[11];
					comprobante.MedioPagoID = (int)x[12];
     //               if ((int)x[13] == 1) { comprobante.Activa = true; }
					//else { comprobante.Activa = false; }

				}
				return comprobante;
        }
			catch (Exception ex) { MessageBox.Show("Error al buscar " + ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error); return comprobante; }
			finally { conectar.Close(); }

		}

		public static Comprobante GetComprobantePorNumero( int numero)
		{
			Comprobante comprobante = new Comprobante();
			MySqlConnection conectar = Conexion.ObtenerConexion();
			conectar.Open();
			DataTable dt = new DataTable();
			MySqlDataReader reader;
			string consulta = "select * from factura f where f.numero="+numero+" limit 1";
			try
			{

				MySqlCommand comand = new MySqlCommand(consulta, conectar);
				reader = comand.ExecuteReader();
				dt.Load(reader);

				foreach (DataRow x in dt.Rows)
				{

					comprobante.ID = (int)x[0];
					comprobante.Numero = (int)x[1];
					comprobante.FechaHora = (DateTime)x[2];
					comprobante.SubTotal = (decimal)x[3];
					comprobante.Financiación = (decimal)x[4];
					comprobante.Total = (decimal)x[5];
					comprobante.ClienteID = (int)x[6];
					comprobante.Cliente = (string)x[7];
					comprobante.Direccion = (string)x[8];
					comprobante.Localidad = (string)x[9];
					comprobante.CP = (string)x[10];
					comprobante.Usuario = (string)x[11];
					comprobante.MedioPagoID = (int)x[12];
					//               if ((int)x[13] == 1) { comprobante.Activa = true; }
					//else { comprobante.Activa = false; }

				}
				return comprobante;
			}
			catch (Exception ex) { MessageBox.Show("Error al buscar " + ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error); return comprobante; }
			finally { conectar.Close(); }

		}


		public static void AgregarPresupuesto(decimal subTotal, decimal iva, decimal total, int cliente_ID, string cliente, string direccion, string localidad, string cp, string usuario, DataTable detalleFactura, int medioPago)
		{
			MySqlConnection conectar = Conexion.ObtenerConexion();
			conectar.Open();
			try
			{
				MySqlCommand comand4 = new MySqlCommand("AgregarPresupuesto", conectar);
				comand4.CommandType = CommandType.StoredProcedure;
				comand4.Parameters.AddWithValue("@p1", DateTime.Now);
				comand4.Parameters.AddWithValue("@p2", subTotal);
				comand4.Parameters.AddWithValue("@p3", iva);
				comand4.Parameters.AddWithValue("@p4", total);
				comand4.Parameters.AddWithValue("@p5", cliente_ID);
				comand4.Parameters.AddWithValue("@p6", cliente);
				comand4.Parameters.AddWithValue("@p7", direccion);
				comand4.Parameters.AddWithValue("@p8", localidad);
				comand4.Parameters.AddWithValue("@p9", cp);
				comand4.Parameters.AddWithValue("@p10", usuario);
				comand4.Parameters.AddWithValue("@p11", medioPago);
				comand4.ExecuteNonQuery();

				foreach (DataRow x in detalleFactura.Rows)
				{
					MySqlCommand comand5 = new MySqlCommand("agregarDetallePresupuesto", conectar);
					comand5.CommandType = CommandType.StoredProcedure;
					comand5.Parameters.AddWithValue("@p1", x[1].ToString());
					comand5.Parameters.AddWithValue("@p2", x[2].ToString());
					comand5.Parameters.AddWithValue("@p3", int.Parse(x[3].ToString()));
					comand5.Parameters.AddWithValue("@p4", decimal.Parse((x[4]).ToString()));
					comand5.ExecuteNonQuery();
				}


				AutoClosingMessageBox.Show("Presupuesto Pr. nº " + GetUltimoPresupuesto().Numero.ToString() + " emitido correctamente", "Emisión de presupuestos", MessageBoxButtons.OK, MessageBoxIcon.Information, 1600);
			}
			catch (Exception ex) { MessageBox.Show("Error al buscar " + ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error); }
			finally { conectar.Close(); }
		}


		public static Comprobante GetUltimoPresupuesto()
		{
			Comprobante comprobante = new Comprobante();
			MySqlConnection conectar = Conexion.ObtenerConexion();
			conectar.Open();
			DataTable dt = new DataTable();
			MySqlDataReader reader;
			string consulta = "select * from presupuesto f order by f.ID desc limit 1";
            try
            {

                MySqlCommand comand = new MySqlCommand(consulta, conectar);
				reader = comand.ExecuteReader();
				dt.Load(reader);

				foreach (DataRow x in dt.Rows)
				{

					comprobante.ID = (int)x[0];
					comprobante.Numero = (int)x[1];
					comprobante.FechaHora = (DateTime)x[2];
					comprobante.SubTotal = (decimal)x[3];
					comprobante.Financiación = (decimal)x[4];
					comprobante.Total = (decimal)x[5];
					comprobante.ClienteID = (int)x[6];
					comprobante.Cliente = (string)x[7];
					comprobante.Direccion = (string)x[8];
					comprobante.Localidad = (string)x[9];
					comprobante.CP = (string)x[10];
					comprobante.Usuario = (string)x[11];
					comprobante.MedioPagoID = (int)x[12];
				}
				return comprobante;
            }
            catch (Exception ex) { MessageBox.Show("Error al buscar " + ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error); return comprobante; }
            finally { conectar.Close(); }

        }


		public static void ReestablecerContadores(string Usuario)
		{
			MySqlConnection conectar = Conexion.ObtenerConexion();
			conectar.Open();
			try
			{

					if (Conexion.Validar(Usuario))
					{

						MySqlCommand comand = new MySqlCommand("limpiarComprobantes", conectar);
						comand.ExecuteNonQuery();
						

						AutoClosingMessageBox.Show("Se reestablecieron correctamente los contadores", "Reestablecer Comprobantes", MessageBoxButtons.OK, MessageBoxIcon.Information, 1600);

					}
					else { MessageBox.Show("Ingrese un usuario y contraseña válido"); }



			}
			catch (Exception ex) { MessageBox.Show("Error " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
			finally { conectar.Close(); }
		}


		public static DataTable ObtenerReporteEmision(bool estado,DateTime fecha1, DateTime fecha2)
		{
			MySqlConnection conectar = Conexion.ObtenerConexion();
			conectar.Open();
			DataTable dt = new DataTable();
			try
			{
				MySqlCommand comand = new MySqlCommand("verfacturas", conectar);
				comand.CommandType = CommandType.StoredProcedure;
				comand.Parameters.AddWithValue("@p0", estado);
				comand.Parameters.AddWithValue("@p1", fecha1);
				comand.Parameters.AddWithValue("@p2", fecha2);
				MySqlDataAdapter adp = new MySqlDataAdapter(comand);
				adp.Fill(dt);
				if (dt.Rows.Count > 0)
				{

					return dt;
				}
				else { MessageBox.Show("No hay registros en el intervalo seleccionado"); return null; }

			}

			catch (Exception ex) { MessageBox.Show("Error al buscar " + ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error); return null; }
			finally { conectar.Close(); }
		}


		public static DataTable ObtenerReporteStock()
		{
			MySqlConnection conectar = Conexion.ObtenerConexion();
			conectar.Open();
			DataTable dt = new DataTable();
			try
			{
				MySqlCommand comand = new MySqlCommand("verStock", conectar);
				comand.CommandType = CommandType.StoredProcedure;
				MySqlDataAdapter adp = new MySqlDataAdapter(comand);
				adp.Fill(dt);
				if (dt.Rows.Count > 0)
				{

					return dt;
				}
				else { MessageBox.Show("No hay registros en el intervalo seleccionado"); return null; }

			}

			catch (Exception ex) { MessageBox.Show("Error al buscar " + ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error); return null; }
			finally { conectar.Close(); }
		}



		public static void ModificarPrecioPorcentaje(int rubroID,decimal modificacion,int proveedorID )
		{
			MySqlConnection conectar = Conexion.ObtenerConexion();
			conectar.Open();
			try
			{
				MySqlCommand comand = new MySqlCommand("CambioPreciosPorcentaje", conectar);
				comand.CommandType = CommandType.StoredProcedure;
				comand.Parameters.AddWithValue("@p0", rubroID);
				comand.Parameters.AddWithValue("@p1", modificacion);
				comand.Parameters.AddWithValue("@p2", proveedorID);

				comand.ExecuteNonQuery();
				MessageBox.Show("Precio actualizado correctamente", "Modificación de Precios", MessageBoxButtons.OK, MessageBoxIcon.Information);

			}
			catch (Exception ex) { MessageBox.Show("Error al buscar " + ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error); }
			finally { conectar.Close(); }
		}

		public static void ModificarPrecioImporte(int rubroID, decimal modificacion, int proveedorID)
		{
			MySqlConnection conectar = Conexion.ObtenerConexion();
			conectar.Open();
			try
			{
				MySqlCommand comand = new MySqlCommand("CambioPreciosImporte", conectar);
				comand.CommandType = CommandType.StoredProcedure;
				comand.Parameters.AddWithValue("@p0", rubroID);
				comand.Parameters.AddWithValue("@p1", modificacion);
				comand.Parameters.AddWithValue("@p2", proveedorID);

				comand.ExecuteNonQuery();
				MessageBox.Show("Precio actualizado correctamente", "Modificación de Precios", MessageBoxButtons.OK, MessageBoxIcon.Information);

			}
			catch (Exception ex) { MessageBox.Show("Error al buscar " + ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error); }
			finally { conectar.Close(); }
		}



		public static void MovimientoStock(DateTime fecha,int articuloID, int tipoMovimientoID,string usuario,string observaciones,int cantidad)
		{
			MySqlConnection conectar = Conexion.ObtenerConexion();
			conectar.Open();
			try
			{
				MySqlCommand comand = new MySqlCommand("AgregarMovimientoStock", conectar);
				comand.CommandType = CommandType.StoredProcedure;
				comand.Parameters.AddWithValue("@p1", fecha);
				comand.Parameters.AddWithValue("@p2", articuloID);
				comand.Parameters.AddWithValue("@p3", tipoMovimientoID);
				comand.Parameters.AddWithValue("@p4", usuario);
				comand.Parameters.AddWithValue("@p5", observaciones);
				comand.Parameters.AddWithValue("@p6", cantidad);


				comand.ExecuteNonQuery();
				AutoClosingMessageBox.Show("Operación confirmada", "Movimiento de artículos", MessageBoxButtons.OK, MessageBoxIcon.Information, 1600);
			}
			catch (Exception ex) { MessageBox.Show("Error " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
			finally { conectar.Close(); }
		}


		public static DataTable ObtenerReporteMovimietos(DateTime fecha1, DateTime fecha2)
		{
			MySqlConnection conectar = Conexion.ObtenerConexion();
			conectar.Open();
			DataTable dt = new DataTable();
			try
			{
				MySqlCommand comand = new MySqlCommand("verMovimientos", conectar);
				comand.CommandType = CommandType.StoredProcedure;
				comand.Parameters.AddWithValue("@p1", fecha1);
				comand.Parameters.AddWithValue("@p2", fecha2);
				MySqlDataAdapter adp = new MySqlDataAdapter(comand);
				adp.Fill(dt);
				if (dt.Rows.Count > 0)
				{

					return dt;
				}
				else { MessageBox.Show("No hay registros en el intervalo seleccionado"); return null; }

			}

			catch (Exception ex) { MessageBox.Show("Error al buscar " + ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error); return null; }
			finally { conectar.Close(); }
		}







		public static DataTable GetMarcaVehiculo()
		{
			MySqlConnection conectar = Conexion.ObtenerConexion();
			conectar.Open();
			DataTable dt = new DataTable();
			MySqlDataReader reader;
			string consulta = "SELECT * FROM marcavehiculo a order by a.descripcion";
			try
			{

				MySqlCommand comand = new MySqlCommand(consulta, conectar);
				reader = comand.ExecuteReader();
				dt.Load(reader);

				if (dt.Rows.Count > 0)
				{

					return dt;
				}
				else { return null; }

			}

			catch (Exception ex) { MessageBox.Show("Error al buscar " + ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error); return null; }
			finally { conectar.Close(); }
		}

		public static void AddMarcaVehiculo(string descripcion)
		{
			string consulta = "insert into marcavehiculo (descripcion) values ('" + descripcion + "')";
			MySqlConnection conectar = Conexion.ObtenerConexion();
			conectar.Open();
			try
			{
				MySqlCommand comand = new MySqlCommand(consulta, conectar);
				comand.ExecuteNonQuery();
				AutoClosingMessageBox.Show("Marca creada correctamente", "Marca", MessageBoxButtons.OK, MessageBoxIcon.Information, 1600);
			}
			catch (Exception ex) { MessageBox.Show("Error " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
			finally { conectar.Close(); }
		}


		public static void SetMarcaVehiculo(int id, string descripcion)
		{
			string consulta = "update marcavehiculo a set descripcion = '" + descripcion + "' where a.id = " + id.ToString();
			MySqlConnection conectar = Conexion.ObtenerConexion();
			conectar.Open();
			try
			{
				MySqlCommand comand = new MySqlCommand(consulta, conectar);
				comand.ExecuteNonQuery();
				AutoClosingMessageBox.Show("Marca modificada correctamente", "Marca", MessageBoxButtons.OK, MessageBoxIcon.Information, 1600);
			}
			catch (Exception ex) { MessageBox.Show("Error " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
			finally { conectar.Close(); }
		}

		public static void DeleteMarcaVehiculo(int id)
		{
			string consulta = "delete from marcavehiculo where id = '" + id.ToString() + "'";
			MySqlConnection conectar = Conexion.ObtenerConexion();
			conectar.Open();
			try
			{
				MySqlCommand comand = new MySqlCommand(consulta, conectar);
				comand.ExecuteNonQuery();
				AutoClosingMessageBox.Show("Marca eliminada correctamente", "Marca", MessageBoxButtons.OK, MessageBoxIcon.Information, 1600);
			}
			catch (Exception ex) { MessageBox.Show("Error " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
			finally { conectar.Close(); }
		}



		public static DataTable GetModeloAuto()
		{
			MySqlConnection conectar = Conexion.ObtenerConexion();
			conectar.Open();
			DataTable dt = new DataTable();
			MySqlDataReader reader;
			string consulta = "SELECT * FROM modelo c order by c.descripcion";
			try
			{

				MySqlCommand comand = new MySqlCommand(consulta, conectar);
				reader = comand.ExecuteReader();
				dt.Load(reader);

				if (dt.Rows.Count > 0)
				{

					return dt;
				}
				else { return null; }

			}

			catch (Exception ex) { MessageBox.Show("Error al buscar " + ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error); return null; }
			finally { conectar.Close(); }
		}

		public static void AddModeloAuto(string descripcion, int año, int marcaID)
		{
			string consulta = "insert into modelo (descripcion,año,Marca_ID) values ('" + descripcion + "', '" + año + "', '" + marcaID + "')";
			MySqlConnection conectar = Conexion.ObtenerConexion();
			conectar.Open();
			try
			{
				MySqlCommand comand = new MySqlCommand(consulta, conectar);
				comand.ExecuteNonQuery();
				AutoClosingMessageBox.Show("Modelo creado correctamente", "Modelo", MessageBoxButtons.OK, MessageBoxIcon.Information, 1600);
			}
			catch (Exception ex) { MessageBox.Show("Error " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
			finally { conectar.Close(); }
		}


		public static void SetModeloAuto(int id, string descripcion, int año, int marcaID)
		{
			string consulta = "update modelo c set descripcion = '" + descripcion + "', año = '" + año + "', Marca_ID = '" + marcaID + "' where c.id = '" + id.ToString() + "'";
			MySqlConnection conectar = Conexion.ObtenerConexion();
			conectar.Open();
			try
			{
				MySqlCommand comand = new MySqlCommand(consulta, conectar);
				comand.ExecuteNonQuery();
				AutoClosingMessageBox.Show("Modelo modificado correctamente", "Modelo", MessageBoxButtons.OK, MessageBoxIcon.Information, 1600);
			}
			catch (Exception ex) { MessageBox.Show("Error " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
			finally { conectar.Close(); }
		}

		public static void DeleteModeloAuto(int id)
		{
			string consulta = "delete from modelo where id = '" + id.ToString() + "'";
			MySqlConnection conectar = Conexion.ObtenerConexion();
			conectar.Open();
			try
			{
				MySqlCommand comand = new MySqlCommand(consulta, conectar);
				comand.ExecuteNonQuery();
				AutoClosingMessageBox.Show("Modelo eliminado correctamente", "Modelo", MessageBoxButtons.OK, MessageBoxIcon.Information, 1600);
			}
			catch (Exception ex) { MessageBox.Show("Error " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
			finally { conectar.Close(); }
		}


		public static DateTime GetDate()
		{
			var result = DateTime.MinValue;

			// Initialize the list of NIST time servers
			// http://tf.nist.gov/tf-cgi/servers.cgi
			string[] servers = new string[] {
		"nist1-ny.ustiming.org",
		"nist1-nj.ustiming.org",
		"nist1-pa.ustiming.org",
		"time-a.nist.gov",
		"time-b.nist.gov",
		"nist1.aol-va.symmetricom.com",
		"nist1.columbiacountyga.gov",
		"nist1-chi.ustiming.org",
		"nist.expertsmi.com",
		"nist.netservicesgroup.com"
};

			// Try 5 servers in random order to spread the load
			Random rnd = new Random();
			foreach (string server in servers.OrderBy(s => rnd.NextDouble()).Take(1))
			{
				try
				{
					// Connect to the server (at port 13) and get the response
					string serverResponse = string.Empty;
					using (var reader = new StreamReader(new System.Net.Sockets.TcpClient(server, 13).GetStream()))
					{
						serverResponse = reader.ReadToEnd();
					}

					// If a response was received
					if (!string.IsNullOrEmpty(serverResponse))
					{
						// Split the response string ("55596 11-02-14 13:54:11 00 0 0 478.1 UTC(NIST) *")
						string[] tokens = serverResponse.Split(' ');

						// Check the number of tokens
						if (tokens.Length >= 6)
						{
							// Check the health status
							string health = tokens[5];
							if (health == "0")
							{
								// Get date and time parts from the server response
								string[] dateParts = tokens[1].Split('-');
								string[] timeParts = tokens[2].Split(':');

								// Create a DateTime instance
								DateTime utcDateTime = new DateTime(
									Convert.ToInt32(dateParts[0]) + 2000,
									Convert.ToInt32(dateParts[1]), Convert.ToInt32(dateParts[2]),
									Convert.ToInt32(timeParts[0]), Convert.ToInt32(timeParts[1]),
									Convert.ToInt32(timeParts[2]));

								// Convert received (UTC) DateTime value to the local timezone
								result = utcDateTime.ToLocalTime();

								return result;
								// Response successfully received; exit the loop

							}
						}

					}

				}
				catch
				{
					// Ignore exception and try the next server
				}
			}
			return result;
		}


		public static DateTime GetfechaExpiracion()
		{
			DateTime fecha = new DateTime();
			MySqlConnection conectar = Conexion.ObtenerConexion();
			conectar.Open();
			DataTable dt = new DataTable();
			MySqlDataReader reader;
			string consulta = "select expira from licencia";
			try
			{

				MySqlCommand comand = new MySqlCommand(consulta, conectar);
				reader = comand.ExecuteReader();
				dt.Load(reader);

				if (dt.Rows.Count == 1)
				{
					foreach (DataRow x in dt.Rows)
					{
						fecha = (DateTime)x[0];
					}
				}
					

					
				return fecha; 

			}

			catch (Exception ex) { MessageBox.Show("Error al buscar " + ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error); return fecha; }
			finally { conectar.Close(); }
		}


		public static bool GetIsActiva()
		{
			bool resultado = true;
			MySqlConnection conectar = Conexion.ObtenerConexion();
			conectar.Open();
			DataTable dt = new DataTable();
			MySqlDataReader reader;
			string consulta = "select valida from licencia";
			try
			{

				MySqlCommand comand = new MySqlCommand(consulta, conectar);
				reader = comand.ExecuteReader();
				dt.Load(reader);

				if (dt.Rows.Count == 1)
				{
					foreach (DataRow x in dt.Rows)
					{
						resultado = (bool)x[0];
					}
				}



				return resultado;

			}

			catch (Exception ex) { MessageBox.Show("Error al buscar " + ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error); return resultado; }
			finally { conectar.Close(); }
		}


		public static void RevocarLicencia()
		{
			string consulta = "update licencia set valida = false";
			MySqlConnection conectar = Conexion.ObtenerConexion();
			conectar.Open();
			try
			{
				MySqlCommand comand = new MySqlCommand(consulta, conectar);
				comand.ExecuteNonQuery();
			}

			finally { conectar.Close(); }
		}


		public static Cliente ObtenerClientePorComprobante(int numero)
		{
			MySqlConnection conectar = Conexion.ObtenerConexion();
			conectar.Open();
			DataTable dt = new DataTable();
			try
			{
				MySqlCommand comand = new MySqlCommand("BuscarClientePorFactura", conectar);
				comand.CommandType = CommandType.StoredProcedure;
				comand.Parameters.AddWithValue("@p1", numero);
				MySqlDataAdapter adp = new MySqlDataAdapter(comand);
				adp.Fill(dt);
				if (dt.Rows.Count == 1)
				{
					Cliente cliente = new Cliente();
					foreach (DataRow x in dt.Rows)
					{
						cliente.ID = (int)x[0];
						cliente.Numero = (int)x[1];
						cliente.Alias = (string)x[2];

						if (x[3] != null)
						{
							try { cliente.RazonSocial = (string)x[3]; }
							catch (Exception) { }
						}

						if (x[4] != null)
						{
							try { cliente.Telefono1 = (string)x[4]; }
							catch (Exception) { }
						}

						if (x[5] != null)
						{
							try { cliente.Telefono2 = (string)x[5]; }
							catch (Exception) { }
						}

						cliente.Direccion = (string)x[6];
						cliente.Ciudad = (string)x[7];
					}
					return cliente;
				}
				else
				{
					return null;
				}

			}
			catch (Exception ex) { MessageBox.Show("Error al buscar " + ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error); return null; }
			finally { conectar.Close(); }
		}

		public static DataTable ObtenerDetalleComprobante(int numero)
		{
			MySqlConnection conectar = Conexion.ObtenerConexion();
			conectar.Open();
			DataTable dt = new DataTable();
			try
			{
				MySqlCommand comand = new MySqlCommand("ObtenerDetalleFactura", conectar);
				comand.CommandType = CommandType.StoredProcedure;
				comand.Parameters.AddWithValue("@p1", numero);
				MySqlDataAdapter adp = new MySqlDataAdapter(comand);
				adp.Fill(dt);
				if (dt.Rows.Count > 0)
				{

					return dt;
				}
				else {return null; }

			}

			catch (Exception ex) { MessageBox.Show("Error al buscar " + ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error); return null; }
			finally { conectar.Close(); }
		}










	}


}