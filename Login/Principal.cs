
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Net;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;

namespace Login
{

	public partial class Principal : Form
	{
		private Usuario usuario { get; }
		public Principal()
		{InitializeComponent();}

		public Principal(Usuario user)
		{
			usuario = user;
			
			InitializeComponent(); }

		void AgregarToolStripMenuItemClick(object sender, EventArgs e)
		{
			int contador = 0;
			foreach (Form f in Application.OpenForms)
			{
				if (f is AgregarArticulo)
				{
					f.Show();
					if (f.WindowState == FormWindowState.Minimized)
						f.WindowState = FormWindowState.Normal;
					f.BringToFront();
					contador++;
					return;
				}

			}
			if (contador == 0)
			{
				AgregarArticulo nuevoart = new AgregarArticulo(usuario);
				nuevoart.MdiParent = this;
				nuevoart.Show();
			}
			contador = 0;


			
	
		}
		

		void EliminarToolStripMenuItemClick(object sender, EventArgs e)
		{
			int contador = 0;
			foreach (Form f in Application.OpenForms)
			{
				if (f is EliminarArticulo)
				{
					f.Show();
					if (f.WindowState == FormWindowState.Minimized)
						f.WindowState = FormWindowState.Normal;
					f.BringToFront();
					contador++;
					return;
				}

			}
			if (contador == 0)
			{
				EliminarArticulo elimart = new EliminarArticulo();
				elimart.MdiParent = this;
				elimart.Show();
			}
			contador = 0;


	
		}
		void ModifArtClick(object sender, EventArgs e)
		{
			int contador = 0;
			foreach (Form f in Application.OpenForms)
			{
				if (f is ModificarArticulo)
				{
					f.Show();
					if (f.WindowState == FormWindowState.Minimized)
						f.WindowState = FormWindowState.Normal;
					f.BringToFront();
					contador++;
					return;
				}

			}
			if (contador == 0)
			{
				ModificarArticulo nuevoart = new ModificarArticulo();
				nuevoart.MdiParent = this;
				nuevoart.Show();
			}
			contador = 0;

			
	
		}
		//void FacturaToolStripMenuItemClick(object sender, EventArgs e)
		//{
		//	factura fact = new factura();
		//	fact.MdiParent = this;
		//	fact.Show();
	
		//}
		void PrincipalLoad(object sender, EventArgs e)	
		{
			//El formulario fondo cubre todo el area de la pantalla principal
			fondo fond = new fondo(usuario);
			fond.MdiParent = this;
			fond.Dock = DockStyle.Fill;
			fond.Show();

			//opciones de menu principal
			clientesToolStripMenuItem.Visible = usuario.TablaCliente;
			archivoToolStripMenuItem.Visible = usuario.TablaArchivos;
			//matricesToolStripMenuItem.Visible = usuario.TablaMatrices;
			//PedidosToolStripMenuItem.Visible = usuario.TablaPedidos;
			artículosToolStripMenuItem.Visible = usuario.TablaArticulos;
			usuarioToolStripMenuItem.Visible = usuario.Tablausuario;
			//reportesToolStripMenuItem.Visible = usuario.TablaReporte;
			//opciones de articulos
			AgregarArticuloMenu.Visible = usuario.AltaArticulos;
			//EliminarArticuloMenu.Visible = usuario.BajaArticulos;
			ModifArt.Visible = usuario.ModificaArticulos;
			//opciones de cliente
			agregarToolStripMenuItem1.Visible = usuario.AltaClientes;
			modificarToolStripMenuItem.Visible = usuario.ModificaClientes;
			//opciones de pedidos
			//AgregarPedidoMenu.Visible = usuario.AltaPedidos;
			//ModificarPedidoMenu.Visible = usuario.ModificaPedidos;
			//detallaDeFabricaciónMenu.Visible = usuario.DetallePedidos;
			//opciones de matrices
			//agregarToolStripMenuItem2.Visible = usuario.AltaMatrices;
			//modificarToolStripMenuItem1.Visible = usuario.ModificaMatrices;
			//toolStripMenuItem1.Visible = usuario.Nitrurado;
			//reporteMatricesPesadasToolStripMenuItem.Visible = true;

			if (usuario.User  != "Rodrigo")
            {
				ControlBox = false;

			}

		}
		
		
		void VerListadoToolStripMenuItemClick(object sender, EventArgs e)
		{
			int contador = 0;
			foreach (Form f in Application.OpenForms)
			{
				if (f is ListadoArticulos)
				{
					f.Show();
					if (f.WindowState == FormWindowState.Minimized)
						f.WindowState = FormWindowState.Normal;
					f.BringToFront();
					contador++;
					return;
				}

			}
			if (contador == 0)
			{
			ListadoArticulos listado = new ListadoArticulos("");
			listado.MdiParent = this;
			listado.Show();		
			}
			contador = 0;
			
		}
		
		void AgregarToolStripMenuItem1Click(object sender, EventArgs e)
		{
			int contador = 0;
			foreach (Form f in Application.OpenForms)
			{
				if (f is AgregarProvedor)
				{
					f.Show();
					if (f.WindowState == FormWindowState.Minimized)
						f.WindowState = FormWindowState.Normal;
					f.BringToFront();
					contador++;
					return;
				}

			}
			if (contador == 0)
			{
				AgregarProvedor clientenuevo = new AgregarProvedor();
				clientenuevo.MdiParent = this;
				clientenuevo.Show();
			}
			contador = 0;
		}
		
		void ModificarToolStripMenuItemClick(object sender, EventArgs e)
		{
			int contador = 0;
			foreach (Form f in Application.OpenForms)
			{
				if (f is ModificarProveedor)
				{
					f.Show();
					if (f.WindowState == FormWindowState.Minimized)
						f.WindowState = FormWindowState.Normal;
					f.BringToFront();
					contador++;
					return;
				}

			}
			if (contador == 0)
			{
				ModificarProveedor modificarcli = new ModificarProveedor();
				modificarcli.MdiParent = this;
				modificarcli.Show();
			}
			contador = 0;
		}

        private void pruebaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void PedidoToolStripMenuItem_Click(object sender, EventArgs e)
        {
			//int contador = 0;
			//foreach (Form f in Application.OpenForms)
			//{
			//	if (f is AgregarPedido)
			//	{
			//		f.Show();
			//		if (f.WindowState == FormWindowState.Minimized)
			//			f.WindowState = FormWindowState.Normal;
			//		f.BringToFront();
			//		contador++;
			//		return;
			//	}

			//}
			//if (contador == 0)
			//{
			//	AgregarPedido agregarpe = new AgregarPedido();
			//	agregarpe.MdiParent = this;
			//	agregarpe.Show();
			//}
			//contador = 0;
		}

        private void listadoAcredoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
			//int contador = 0;
			//foreach (Form f in Application.OpenForms)
			//{
			//	if (f is ListadoPedidos)
			//	{
			//		f.Show();
			//		if (f.WindowState == FormWindowState.Minimized)
			//			f.WindowState = FormWindowState.Normal;
			//		f.BringToFront();
			//		contador++;
			//		return;
			//	}

			//}
			//if (contador == 0)
			//{
			//	ListadoPedidos listPed = new ListadoPedidos(usuario);
			//	listPed.MdiParent = this;
			//	listPed.Show();
			//}
			//contador = 0;
		}

        private void listadoDeudoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
			//int contador = 0;
			//foreach (Form f in Application.OpenForms)
			//{
			//	if (f is ModificarPedido)
			//	{
			//		f.Show();
			//		if (f.WindowState == FormWindowState.Minimized)
			//			f.WindowState = FormWindowState.Normal;
			//		f.BringToFront();
			//		contador++;
			//		return;
			//	}

			//}
			//if (contador == 0)
			//{
			//	ModificarPedido modificarpedido = new ModificarPedido();
			//	modificarpedido.MdiParent = this;
			//	modificarpedido.Show();
			//}
			//contador = 0;
		}

        private void agregarToolStripMenuItem2_Click(object sender, EventArgs e)
        {
			int contador = 0;
			foreach (Form f in Application.OpenForms)
			{
				if (f is AgregarMatriz)
				{
					f.Show();
					if (f.WindowState == FormWindowState.Minimized)
						f.WindowState = FormWindowState.Normal;
					f.BringToFront();
					contador++;
					return;
				}

			}
			if (contador == 0)
			{
				AgregarMatriz agregarMat = new AgregarMatriz();
				agregarMat.MdiParent = this;
				agregarMat.Show();
			}
			contador = 0;
		}

        private void ciudadesToolStripMenuItem_Click(object sender, EventArgs e)
        {
			int contador = 0;
			foreach (Form f in Application.OpenForms)
			{
				if (f is AgregarCiudad)
				{
					f.Show();
					if (f.WindowState == FormWindowState.Minimized)
						f.WindowState = FormWindowState.Normal;
					f.BringToFront();
					contador++;
					return;
				}

			}
			if (contador == 0)
			{
				Ciudad ciudad = new Ciudad();
				ciudad.MdiParent = this;
				ciudad.Show();
			}
			contador = 0;
		}

        private void detallaDeFabricaciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
			//int contador = 0;
			//foreach (Form f in Application.OpenForms)
			//{
			//	if (f is DetalleFabricacion)
			//	{
			//		f.Show();
			//		if (f.WindowState == FormWindowState.Minimized)
			//			f.WindowState = FormWindowState.Normal;
			//		f.BringToFront();
			//		contador++;
			//		return;
			//	}

			//}
			//if (contador == 0)
			//{
			//	DetalleFabricacion dt = new DetalleFabricacion();
			//	dt.MdiParent = this;
			//	dt.Show();
			//}
			//contador = 0;
		}

        private void button1_Click(object sender, EventArgs e)
        {
			IPHostEntry host;
			string localIP = "";
			host = Dns.GetHostEntry(Dns.GetHostName());
			foreach (IPAddress ip in host.AddressList)
			{
				if (ip.AddressFamily.ToString() == "InterNetwork")
				{
					localIP = ip.ToString();
				}
			}
			MessageBox.Show("Tú IP Local Es: " + localIP);
		}

        private void button1_Click_1(object sender, EventArgs e)
        {
			System.Windows.Forms.Application.Exit();

		}

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
			System.Windows.Forms.Application.Exit();

		}

        private void verListadoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
			int contador = 0;
			foreach (Form f in Application.OpenForms)
			{
				if (f is ListadoProveedores)
				{
					f.Show();
					if (f.WindowState == FormWindowState.Minimized)
						f.WindowState = FormWindowState.Normal;
					f.BringToFront();
					contador++;
					return;
				}

			}
			if (contador == 0)
			{
				ListadoProveedores listadoCli = new ListadoProveedores("");
				listadoCli.MdiParent = this;
				listadoCli.Show();
			}
			contador = 0;


		}

        private void modificarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
			int contador = 0;
			foreach (Form f in Application.OpenForms)
			{
				if (f is ModificarMatriz)
				{
					f.Show();
					if (f.WindowState == FormWindowState.Minimized)
						f.WindowState = FormWindowState.Normal;
					f.BringToFront();
					contador++;
					return;
				}

			}
			if (contador == 0)
			{
				ModificarMatriz modmat = new ModificarMatriz();
				modmat.MdiParent = this;
				modmat.Show();
			}
			contador = 0;
		}

        private void ayudaToolStripMenuItem_Click(object sender, EventArgs e)
        {
			int contador = 0;
			foreach (Form f in Application.OpenForms)
			{
				if (f is Contacto)
				{
					f.Show();
					if (f.WindowState == FormWindowState.Minimized)
						f.WindowState = FormWindowState.Normal;
					f.BringToFront();
					contador++;
					return;
				}

			}
			if (contador == 0)
			{
				Contacto cont = new Contacto();
				cont.MdiParent = this;
				cont.Show();
			}
			contador = 0;
        }

  //      private void proyecciónToolStripMenuItem_Click(object sender, EventArgs e)
  //      {

		//}

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {

        }

        //private void enProduccionToolStripMenuItem_Click(object sender, EventArgs e)
        //{

        //}

        private void usuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
			int contador = 0;
			foreach (Form f in Application.OpenForms)
			{
				if (f is User)
				{
					f.Show();
					if (f.WindowState == FormWindowState.Minimized)
						f.WindowState = FormWindowState.Normal;
					f.BringToFront();
					contador++;
					return;
				}

			}
			if (contador == 0)
			{
				User gestionUsuario = new User();
				gestionUsuario.MdiParent = this;
				gestionUsuario.Show();
			}
			contador = 0;
		}

        //private void reporteProducciónToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    ReporteProduccion reporte = new ReporteProduccion();
        //    reporte.MdiParent = this;
        //    reporte.Show();
        //}



        private void proyeccionToolStripMenuItem_Click(object sender, EventArgs e)
        {//ok
			int contador = 0;
			foreach (Form f in Application.OpenForms)
			{
				if (f is Proyeccion)
				{
					f.Show();
					if (f.WindowState == FormWindowState.Minimized)
						f.WindowState = FormWindowState.Normal;
					f.BringToFront();
					contador++;
					return;
				}

			}
			if (contador == 0)
			{
				Proyeccion proye = new Proyeccion();
				proye.MdiParent = this;
				proye.Show();
			}
			contador = 0;

		}

        private void enProducciónToolStripMenuItem_Click_1(object sender, EventArgs e)
        {//ok
			int contador = 0;
			foreach (Form f in Application.OpenForms)
			{
				if (f is EnProduccion)
				{
					f.Show();
					if (f.WindowState == FormWindowState.Minimized)
						f.WindowState = FormWindowState.Normal;
					f.BringToFront();
					contador++;
					return;
				}

			}
			if (contador == 0)
			{
				EnProduccion produ = new EnProduccion();
				produ.MdiParent = this;
				produ.Show();
			}
			contador = 0;
		}

        private void reporteDeProducciónToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
			//int contador = 0;
			//foreach (Form f in Application.OpenForms)
			//{
			//	if (f is ReporteProduccion)
			//	{
			//		f.Show();
			//		if (f.WindowState == FormWindowState.Minimized)
			//			f.WindowState = FormWindowState.Normal;
			//		f.BringToFront();
			//		contador++;
			//		return;
			//	}

			//}
			//if (contador == 0)
   //         {
			//	ReporteProduccion reporte = new ReporteProduccion();
			//	reporte.MdiParent = this;
			//	reporte.Show();
			//}
			//contador = 0;
		}

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
			int contador = 0;
			foreach (Form f in Application.OpenForms)
			{
				if (f is Nitrurado)
				{
					f.Show();
					if (f.WindowState == FormWindowState.Minimized)
						f.WindowState = FormWindowState.Normal;
					f.BringToFront();
					contador++;
					return;
				}

			}
			if (contador == 0)
			{
				Nitrurado nitrurado = new Nitrurado();
				nitrurado.MdiParent = this;
				nitrurado.Show();
			}
			contador = 0;
        }

        private void puestosDeTrabajoToolStripMenuItem_Click(object sender, EventArgs e)
		{
			int contador = 0;
			foreach (Form f in Application.OpenForms)
			{
				if (f is Puesto)
				{
					f.Show();
					if (f.WindowState == FormWindowState.Minimized)
						f.WindowState = FormWindowState.Normal;
					f.BringToFront();
					contador++;
					return;
				}

			}
			if (contador == 0)
			{
				Puesto puesto = new Puesto();
				puesto.MdiParent = this;
				puesto.Show();
			}
			contador = 0;
		}

        private void clasificaciónToolStripMenuItem_Click(object sender, EventArgs e)
		{
			int contador = 0;
			foreach (Form f in Application.OpenForms)
			{
				if (f is Clasificacion)
				{
					f.Show();
					if (f.WindowState == FormWindowState.Minimized)
						f.WindowState = FormWindowState.Normal;
					f.BringToFront();
					contador++;
					return;
				}

			}
			if (contador == 0)
			{
				Clasificacion clasificacion = new Clasificacion();
				clasificacion.MdiParent = this;
				clasificacion.Show();
			}
			contador = 0;
		}

        private void prioridadToolStripMenuItem_Click(object sender, EventArgs e)
		{
			int contador = 0;
			foreach (Form f in Application.OpenForms)
			{
				if (f is Prioridad)
				{
					f.Show();
					if (f.WindowState == FormWindowState.Minimized)
						f.WindowState = FormWindowState.Normal;
					f.BringToFront();
					contador++;
					return;
				}

			}
			if (contador == 0)
			{
				Prioridad prioridad = new Prioridad();
				prioridad.MdiParent = this;
				prioridad.Show();
			}
			contador = 0;
		}

        private void aleaciónToolStripMenuItem_Click(object sender, EventArgs e)
		{
			int contador = 0;
			foreach (Form f in Application.OpenForms)
			{
				if (f is Aleacion)
				{
					f.Show();
					if (f.WindowState == FormWindowState.Minimized)
						f.WindowState = FormWindowState.Normal;
					f.BringToFront();
					contador++;
					return;
				}

			}
			if (contador == 0)
			{
				Aleacion ventana = new Aleacion();
				ventana.MdiParent = this;
				ventana.Show();
			}
			contador = 0;
		}

        private void templeToolStripMenuItem_Click(object sender, EventArgs e)
		{
			int contador = 0;
			foreach (Form f in Application.OpenForms)
			{
				if (f is Rubro)
				{
					f.Show();
					if (f.WindowState == FormWindowState.Minimized)
						f.WindowState = FormWindowState.Normal;
					f.BringToFront();
					contador++;
					return;
				}

			}
			if (contador == 0)
			{
				Rubro ventana = new Rubro();
				ventana.MdiParent = this;
				ventana.Show();
			}
			contador = 0;
		}

        private void terminaciónToolStripMenuItem_Click(object sender, EventArgs e)
		{
			int contador = 0;
			foreach (Form f in Application.OpenForms)
			{
				if (f is Terminacion)
				{
					f.Show();
					if (f.WindowState == FormWindowState.Minimized)
						f.WindowState = FormWindowState.Normal;
					f.BringToFront();
					contador++;
					return;
				}

			}
			if (contador == 0)
			{
				Terminacion ventana = new Terminacion();
				ventana.MdiParent = this;
				ventana.Show();
			}
			contador = 0;
		}

  //      private void reporteDeNitruradoToolStripMenuItem_Click(object sender, EventArgs e)
		//{
		//	int contador = 0;
		//	foreach (Form f in Application.OpenForms)
		//	{
		//		if (f is ReporteNitrurado)
		//		{
		//			f.Show();
		//			if (f.WindowState == FormWindowState.Minimized)
		//				f.WindowState = FormWindowState.Normal;
		//			f.BringToFront();
		//			contador++;
		//			return;
		//		}

		//	}
		//	if (contador == 0)
		//	{
		//		ReporteNitrurado ventana = new ReporteNitrurado();
		//		ventana.MdiParent = this;
		//		ventana.Show();
		//	}
		//	contador = 0;
		//}

  //      private void reporteMatricesPesadasToolStripMenuItem_Click(object sender, EventArgs e)
  //      {
		//	int contador = 0;
		//	foreach (Form f in Application.OpenForms)
		//	{
		//		if (f is ReporteMatricesPesadas)
		//		{
		//			f.Show();
		//			if (f.WindowState == FormWindowState.Minimized)
		//				f.WindowState = FormWindowState.Normal;
		//			f.BringToFront();
		//			contador++;
		//			return;
		//		}

		//	}
		//	if (contador == 0)
		//	{
		//		ReporteMatricesPesadas ventana = new ReporteMatricesPesadas();
		//		ventana.MdiParent = this;
		//		ventana.Show();
		//	}
		//	contador = 0;

		//}

        private void facturarToolStripMenuItem_Click(object sender, EventArgs e)
		{
			int contador = 0;
			foreach (Form f in Application.OpenForms)
			{
				if (f is EmisionComprobantes)
				{
					f.Show();
					if (f.WindowState == FormWindowState.Minimized)
						f.WindowState = FormWindowState.Normal;
					f.BringToFront();
					contador++;
					return;
				}

			}
			if (contador == 0)
			{
				EmisionComprobantes ventana = new EmisionComprobantes(usuario);
				ventana.MdiParent = this;
				ventana.Show();
			}
			contador = 0;

		}

        private void agregarToolStripMenuItem_Click(object sender, EventArgs e)
		{
			int contador = 0;
			foreach (Form f in Application.OpenForms)
			{
				if (f is AgregarCliente)
				{
					f.Show();
					if (f.WindowState == FormWindowState.Minimized)
						f.WindowState = FormWindowState.Normal;
					f.BringToFront();
					contador++;
					return;
				}

			}
			if (contador == 0)
			{
				AgregarCliente ventana = new AgregarCliente();
				ventana.MdiParent = this;
				ventana.Show();
			}
			contador = 0;

		}

        private void modificarToolStripMenuItem1_Click_1(object sender, EventArgs e)
		{
			int contador = 0;
			foreach (Form f in Application.OpenForms)
			{
				if (f is ModificarCliente)
				{
					f.Show();
					if (f.WindowState == FormWindowState.Minimized)
						f.WindowState = FormWindowState.Normal;
					f.BringToFront();
					contador++;
					return;
				}

			}
			if (contador == 0)
			{
				ModificarCliente ventana = new ModificarCliente();
				ventana.MdiParent = this;
				ventana.Show();
			}
			contador = 0;

		}

        private void listadoToolStripMenuItem_Click(object sender, EventArgs e)
		{
			int contador = 0;
			foreach (Form f in Application.OpenForms)
			{
				if (f is ListadoClientes)
				{
					f.Show();
					if (f.WindowState == FormWindowState.Minimized)
						f.WindowState = FormWindowState.Normal;
					f.BringToFront();
					contador++;
					return;
				}

			}
			if (contador == 0)
			{
				ListadoClientes ventana = new ListadoClientes("");
				ventana.MdiParent = this;
				ventana.Show();
			}
			contador = 0;

		}

        private void mediosDePagoToolStripMenuItem_Click(object sender, EventArgs e)
		{
			int contador = 0;
			foreach (Form f in Application.OpenForms)
			{
				if (f is MediosPago)
				{
					f.Show();
					if (f.WindowState == FormWindowState.Minimized)
						f.WindowState = FormWindowState.Normal;
					f.BringToFront();
					contador++;
					return;
				}

			}
			if (contador == 0)
			{
				MediosPago ventana = new MediosPago();
				ventana.MdiParent = this;
				ventana.Show();
			}
			contador = 0;

		}

        private void anulaciónDeComprobantesToolStripMenuItem_Click(object sender, EventArgs e)
		{
			int contador = 0;
			foreach (Form f in Application.OpenForms)
			{
				if (f is AnulacionComprobantes)
				{
					f.Show();
					if (f.WindowState == FormWindowState.Minimized)
						f.WindowState = FormWindowState.Normal;
					f.BringToFront();
					contador++;
					return;
				}

			}
			if (contador == 0)
			{
				AnulacionComprobantes ventana = new AnulacionComprobantes(usuario);
				ventana.MdiParent = this;
				ventana.Show();
			}

		}

        private void emisiónPresupuestosToolStripMenuItem_Click(object sender, EventArgs e)
		{
			int contador = 0;
			foreach (Form f in Application.OpenForms)
			{
				if (f is EmisionPresupuesto)
				{
					f.Show();
					if (f.WindowState == FormWindowState.Minimized)
						f.WindowState = FormWindowState.Normal;
					f.BringToFront();
					contador++;
					return;
				}

			}
			if (contador == 0)
			{
				EmisionPresupuesto ventana = new EmisionPresupuesto(usuario);
				ventana.MdiParent = this;
				ventana.Show();
			}

		}

        private void ponerContadoresEnCeroToolStripMenuItem_Click(object sender, EventArgs e)
		{
			int contador = 0;
			foreach (Form f in Application.OpenForms)
			{
				if (f is RestablecerContadores)
				{
					f.Show();
					if (f.WindowState == FormWindowState.Minimized)
						f.WindowState = FormWindowState.Normal;
					f.BringToFront();
					contador++;
					return;
				}

			}
			if (contador == 0)
			{
				RestablecerContadores ventana = new RestablecerContadores(usuario);
				ventana.MdiParent = this;
				ventana.Show();
			}

		}

        private void comprobantesEmitidosToolStripMenuItem_Click(object sender, EventArgs e)
		{
			int contador = 0;
			foreach (Form f in Application.OpenForms)
			{
				if (f is ReporteEmision)
				{
					f.Show();
					if (f.WindowState == FormWindowState.Minimized)
						f.WindowState = FormWindowState.Normal;
					f.BringToFront();
					contador++;
					return;
				}

			}
			if (contador == 0)
			{
				ReporteEmision ventana = new ReporteEmision();
				ventana.MdiParent = this;
				ventana.Show();
			}

		}

        private void stockToolStripMenuItem_Click(object sender, EventArgs e)
		{
			int contador = 0;
			foreach (Form f in Application.OpenForms)
			{
				if (f is ReporteStock)
				{
					f.Show();
					if (f.WindowState == FormWindowState.Minimized)
						f.WindowState = FormWindowState.Normal;
					f.BringToFront();
					contador++;
					return;
				}

			}
			if (contador == 0)
			{
				ReporteStock ventana = new ReporteStock();
				ventana.MdiParent = this;
				ventana.Show();
			}

		}

        private void porPorcentajeToolStripMenuItem_Click(object sender, EventArgs e)
		{
			int contador = 0;
			foreach (Form f in Application.OpenForms)
			{
				if (f is CambioPrecios)
				{
					f.Show();
					if (f.WindowState == FormWindowState.Minimized)
						f.WindowState = FormWindowState.Normal;
					f.BringToFront();
					contador++;
					return;
				}

			}
			if (contador == 0)
			{
				CambioPrecios ventana = new CambioPrecios(usuario,"Porcentaje",true);
				ventana.MdiParent = this;
				ventana.Show();
			}

		}

        private void porImporteToolStripMenuItem_Click(object sender, EventArgs e)
		{
			int contador = 0;
			foreach (Form f in Application.OpenForms)
			{
				if (f is CambioPrecios)
				{
					f.Show();
					if (f.WindowState == FormWindowState.Minimized)
						f.WindowState = FormWindowState.Normal;
					f.BringToFront();
					contador++;
					return;
				}

			}
			if (contador == 0)
			{
				CambioPrecios ventana = new CambioPrecios(usuario, "Importe", false);
				ventana.MdiParent = this;
				ventana.Show();
			}

		}

        private void entradasSalidasDeArtículosToolStripMenuItem_Click(object sender, EventArgs e)
		{
			int contador = 0;
			foreach (Form f in Application.OpenForms)
			{
				if (f is EntradasSalidas)
				{
					f.Show();
					if (f.WindowState == FormWindowState.Minimized)
						f.WindowState = FormWindowState.Normal;
					f.BringToFront();
					contador++;
					return;
				}

			}
			if (contador == 0)
			{
				EntradasSalidas ventana = new EntradasSalidas(usuario);
				ventana.MdiParent = this;
				ventana.Show();
			}

		}

        private void movimientosDeArtículosToolStripMenuItem_Click(object sender, EventArgs e)
		{
			int contador = 0;
			foreach (Form f in Application.OpenForms)
			{
				if (f is ReporteMovimientos)
				{
					f.Show();
					if (f.WindowState == FormWindowState.Minimized)
						f.WindowState = FormWindowState.Normal;
					f.BringToFront();
					contador++;
					return;
				}

			}
			if (contador == 0)
			{
				ReporteMovimientos ventana = new ReporteMovimientos();
				ventana.MdiParent = this;
				ventana.Show();
			}

		}
	}
}
