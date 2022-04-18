
namespace Login
{
	partial class Principal
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem artículosToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem AgregarArticuloMenu;
		private System.Windows.Forms.ToolStripMenuItem ModifArt;
		private System.Windows.Forms.ToolStripMenuItem verListadoToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem proveedoresToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem agregarProveedores;
		private System.Windows.Forms.ToolStripMenuItem modificarProveedores;
		private System.Windows.Forms.ToolStripMenuItem verListadoToolStripMenuItem1;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Principal));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.archivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ciudadesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aleaciónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.templeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clasificaciónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mediosDePagoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.marcaVehiculoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modeloVehículoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.artículosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AgregarArticuloMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.ModifArt = new System.Windows.Forms.ToolStripMenuItem();
            this.entradasSalidasDeArtículosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cambioDePreciosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.porPorcentajeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.porImporteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.verListadoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.proveedoresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.agregarProveedores = new System.Windows.Forms.ToolStripMenuItem();
            this.modificarProveedores = new System.Windows.Forms.ToolStripMenuItem();
            this.verListadoToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clientesToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.agregarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modificarToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.listadoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.facturaciónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.facturarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.emisiónPresupuestosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.anulaciónDeComprobantesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.comprobantesEmitidosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stockToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.movimientosDeArtículosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.usuarioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mantenimientoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ponerContadoresEnCeroToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ayudaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.AllowMerge = false;
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.archivoToolStripMenuItem,
            this.artículosToolStripMenuItem,
            this.proveedoresToolStripMenuItem,
            this.salirToolStripMenuItem,
            this.clientesToolStripMenuItem1,
            this.facturaciónToolStripMenuItem,
            this.reportesToolStripMenuItem,
            this.usuarioToolStripMenuItem,
            this.mantenimientoToolStripMenuItem,
            this.ayudaToolStripMenuItem});
            resources.ApplyResources(this.menuStrip1, "menuStrip1");
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // archivoToolStripMenuItem
            // 
            this.archivoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ciudadesToolStripMenuItem,
            this.aleaciónToolStripMenuItem,
            this.templeToolStripMenuItem,
            this.clasificaciónToolStripMenuItem,
            this.mediosDePagoToolStripMenuItem,
            this.marcaVehiculoToolStripMenuItem,
            this.modeloVehículoToolStripMenuItem});
            this.archivoToolStripMenuItem.Name = "archivoToolStripMenuItem";
            resources.ApplyResources(this.archivoToolStripMenuItem, "archivoToolStripMenuItem");
            // 
            // ciudadesToolStripMenuItem
            // 
            this.ciudadesToolStripMenuItem.Image = global::Login.Properties.Resources.configDatos;
            this.ciudadesToolStripMenuItem.Name = "ciudadesToolStripMenuItem";
            resources.ApplyResources(this.ciudadesToolStripMenuItem, "ciudadesToolStripMenuItem");
            this.ciudadesToolStripMenuItem.Click += new System.EventHandler(this.ciudadesToolStripMenuItem_Click);
            // 
            // aleaciónToolStripMenuItem
            // 
            this.aleaciónToolStripMenuItem.Image = global::Login.Properties.Resources.configDatos;
            this.aleaciónToolStripMenuItem.Name = "aleaciónToolStripMenuItem";
            resources.ApplyResources(this.aleaciónToolStripMenuItem, "aleaciónToolStripMenuItem");
            this.aleaciónToolStripMenuItem.Click += new System.EventHandler(this.aleaciónToolStripMenuItem_Click);
            // 
            // templeToolStripMenuItem
            // 
            this.templeToolStripMenuItem.Image = global::Login.Properties.Resources.configDatos;
            this.templeToolStripMenuItem.Name = "templeToolStripMenuItem";
            resources.ApplyResources(this.templeToolStripMenuItem, "templeToolStripMenuItem");
            this.templeToolStripMenuItem.Click += new System.EventHandler(this.templeToolStripMenuItem_Click);
            // 
            // clasificaciónToolStripMenuItem
            // 
            this.clasificaciónToolStripMenuItem.Image = global::Login.Properties.Resources.configDatos;
            this.clasificaciónToolStripMenuItem.Name = "clasificaciónToolStripMenuItem";
            resources.ApplyResources(this.clasificaciónToolStripMenuItem, "clasificaciónToolStripMenuItem");
            this.clasificaciónToolStripMenuItem.Click += new System.EventHandler(this.clasificaciónToolStripMenuItem_Click);
            // 
            // mediosDePagoToolStripMenuItem
            // 
            this.mediosDePagoToolStripMenuItem.Image = global::Login.Properties.Resources.configDatos;
            this.mediosDePagoToolStripMenuItem.Name = "mediosDePagoToolStripMenuItem";
            resources.ApplyResources(this.mediosDePagoToolStripMenuItem, "mediosDePagoToolStripMenuItem");
            this.mediosDePagoToolStripMenuItem.Click += new System.EventHandler(this.mediosDePagoToolStripMenuItem_Click);
            // 
            // marcaVehiculoToolStripMenuItem
            // 
            this.marcaVehiculoToolStripMenuItem.Image = global::Login.Properties.Resources.configDatos;
            this.marcaVehiculoToolStripMenuItem.Name = "marcaVehiculoToolStripMenuItem";
            resources.ApplyResources(this.marcaVehiculoToolStripMenuItem, "marcaVehiculoToolStripMenuItem");
            this.marcaVehiculoToolStripMenuItem.Click += new System.EventHandler(this.marcaVehiculoToolStripMenuItem_Click);
            // 
            // modeloVehículoToolStripMenuItem
            // 
            this.modeloVehículoToolStripMenuItem.Image = global::Login.Properties.Resources.configDatos;
            this.modeloVehículoToolStripMenuItem.Name = "modeloVehículoToolStripMenuItem";
            resources.ApplyResources(this.modeloVehículoToolStripMenuItem, "modeloVehículoToolStripMenuItem");
            this.modeloVehículoToolStripMenuItem.Click += new System.EventHandler(this.modeloVehículoToolStripMenuItem_Click);
            // 
            // artículosToolStripMenuItem
            // 
            this.artículosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AgregarArticuloMenu,
            this.ModifArt,
            this.entradasSalidasDeArtículosToolStripMenuItem,
            this.cambioDePreciosToolStripMenuItem,
            this.verListadoToolStripMenuItem});
            this.artículosToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            this.artículosToolStripMenuItem.Name = "artículosToolStripMenuItem";
            resources.ApplyResources(this.artículosToolStripMenuItem, "artículosToolStripMenuItem");
            // 
            // AgregarArticuloMenu
            // 
            this.AgregarArticuloMenu.Image = global::Login.Properties.Resources.agregar;
            this.AgregarArticuloMenu.Name = "AgregarArticuloMenu";
            resources.ApplyResources(this.AgregarArticuloMenu, "AgregarArticuloMenu");
            this.AgregarArticuloMenu.Click += new System.EventHandler(this.AgregarToolStripMenuItemClick);
            // 
            // ModifArt
            // 
            this.ModifArt.Image = global::Login.Properties.Resources.modificar;
            this.ModifArt.Name = "ModifArt";
            resources.ApplyResources(this.ModifArt, "ModifArt");
            this.ModifArt.Click += new System.EventHandler(this.ModifArtClick);
            // 
            // entradasSalidasDeArtículosToolStripMenuItem
            // 
            this.entradasSalidasDeArtículosToolStripMenuItem.Image = global::Login.Properties.Resources.flechas;
            this.entradasSalidasDeArtículosToolStripMenuItem.Name = "entradasSalidasDeArtículosToolStripMenuItem";
            resources.ApplyResources(this.entradasSalidasDeArtículosToolStripMenuItem, "entradasSalidasDeArtículosToolStripMenuItem");
            this.entradasSalidasDeArtículosToolStripMenuItem.Click += new System.EventHandler(this.entradasSalidasDeArtículosToolStripMenuItem_Click);
            // 
            // cambioDePreciosToolStripMenuItem
            // 
            this.cambioDePreciosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.porPorcentajeToolStripMenuItem,
            this.porImporteToolStripMenuItem});
            this.cambioDePreciosToolStripMenuItem.Image = global::Login.Properties.Resources.modificar;
            this.cambioDePreciosToolStripMenuItem.Name = "cambioDePreciosToolStripMenuItem";
            resources.ApplyResources(this.cambioDePreciosToolStripMenuItem, "cambioDePreciosToolStripMenuItem");
            // 
            // porPorcentajeToolStripMenuItem
            // 
            this.porPorcentajeToolStripMenuItem.Image = global::Login.Properties.Resources.porcentaje;
            this.porPorcentajeToolStripMenuItem.Name = "porPorcentajeToolStripMenuItem";
            resources.ApplyResources(this.porPorcentajeToolStripMenuItem, "porPorcentajeToolStripMenuItem");
            this.porPorcentajeToolStripMenuItem.Click += new System.EventHandler(this.porPorcentajeToolStripMenuItem_Click);
            // 
            // porImporteToolStripMenuItem
            // 
            this.porImporteToolStripMenuItem.Image = global::Login.Properties.Resources.dolar;
            this.porImporteToolStripMenuItem.Name = "porImporteToolStripMenuItem";
            resources.ApplyResources(this.porImporteToolStripMenuItem, "porImporteToolStripMenuItem");
            this.porImporteToolStripMenuItem.Click += new System.EventHandler(this.porImporteToolStripMenuItem_Click);
            // 
            // verListadoToolStripMenuItem
            // 
            this.verListadoToolStripMenuItem.Image = global::Login.Properties.Resources.lupa;
            this.verListadoToolStripMenuItem.Name = "verListadoToolStripMenuItem";
            resources.ApplyResources(this.verListadoToolStripMenuItem, "verListadoToolStripMenuItem");
            this.verListadoToolStripMenuItem.Click += new System.EventHandler(this.VerListadoToolStripMenuItemClick);
            // 
            // proveedoresToolStripMenuItem
            // 
            this.proveedoresToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.agregarProveedores,
            this.modificarProveedores,
            this.verListadoToolStripMenuItem1});
            this.proveedoresToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            this.proveedoresToolStripMenuItem.Name = "proveedoresToolStripMenuItem";
            resources.ApplyResources(this.proveedoresToolStripMenuItem, "proveedoresToolStripMenuItem");
            // 
            // agregarProveedores
            // 
            this.agregarProveedores.Image = global::Login.Properties.Resources.agregar;
            this.agregarProveedores.Name = "agregarProveedores";
            resources.ApplyResources(this.agregarProveedores, "agregarProveedores");
            this.agregarProveedores.Click += new System.EventHandler(this.AgregarToolStripMenuItem1Click);
            // 
            // modificarProveedores
            // 
            this.modificarProveedores.Image = global::Login.Properties.Resources.modificar;
            this.modificarProveedores.Name = "modificarProveedores";
            resources.ApplyResources(this.modificarProveedores, "modificarProveedores");
            this.modificarProveedores.Click += new System.EventHandler(this.ModificarToolStripMenuItemClick);
            // 
            // verListadoToolStripMenuItem1
            // 
            this.verListadoToolStripMenuItem1.Image = global::Login.Properties.Resources.listado;
            this.verListadoToolStripMenuItem1.Name = "verListadoToolStripMenuItem1";
            resources.ApplyResources(this.verListadoToolStripMenuItem1, "verListadoToolStripMenuItem1");
            this.verListadoToolStripMenuItem1.Click += new System.EventHandler(this.verListadoToolStripMenuItem1_Click);
            // 
            // salirToolStripMenuItem
            // 
            this.salirToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.salirToolStripMenuItem.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.salirToolStripMenuItem.Image = global::Login.Properties.Resources.stop;
            this.salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            resources.ApplyResources(this.salirToolStripMenuItem, "salirToolStripMenuItem");
            this.salirToolStripMenuItem.Click += new System.EventHandler(this.salirToolStripMenuItem_Click);
            // 
            // clientesToolStripMenuItem1
            // 
            this.clientesToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.agregarToolStripMenuItem,
            this.modificarToolStripMenuItem1,
            this.listadoToolStripMenuItem});
            this.clientesToolStripMenuItem1.Name = "clientesToolStripMenuItem1";
            resources.ApplyResources(this.clientesToolStripMenuItem1, "clientesToolStripMenuItem1");
            // 
            // agregarToolStripMenuItem
            // 
            this.agregarToolStripMenuItem.Image = global::Login.Properties.Resources.agregar;
            this.agregarToolStripMenuItem.Name = "agregarToolStripMenuItem";
            resources.ApplyResources(this.agregarToolStripMenuItem, "agregarToolStripMenuItem");
            this.agregarToolStripMenuItem.Click += new System.EventHandler(this.agregarToolStripMenuItem_Click);
            // 
            // modificarToolStripMenuItem1
            // 
            this.modificarToolStripMenuItem1.Image = global::Login.Properties.Resources.modificar;
            this.modificarToolStripMenuItem1.Name = "modificarToolStripMenuItem1";
            resources.ApplyResources(this.modificarToolStripMenuItem1, "modificarToolStripMenuItem1");
            this.modificarToolStripMenuItem1.Click += new System.EventHandler(this.modificarToolStripMenuItem1_Click_1);
            // 
            // listadoToolStripMenuItem
            // 
            this.listadoToolStripMenuItem.Image = global::Login.Properties.Resources.listado;
            this.listadoToolStripMenuItem.Name = "listadoToolStripMenuItem";
            resources.ApplyResources(this.listadoToolStripMenuItem, "listadoToolStripMenuItem");
            this.listadoToolStripMenuItem.Click += new System.EventHandler(this.listadoToolStripMenuItem_Click);
            // 
            // facturaciónToolStripMenuItem
            // 
            this.facturaciónToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.facturarToolStripMenuItem,
            this.emisiónPresupuestosToolStripMenuItem,
            this.anulaciónDeComprobantesToolStripMenuItem});
            this.facturaciónToolStripMenuItem.Name = "facturaciónToolStripMenuItem";
            resources.ApplyResources(this.facturaciónToolStripMenuItem, "facturaciónToolStripMenuItem");
            // 
            // facturarToolStripMenuItem
            // 
            resources.ApplyResources(this.facturarToolStripMenuItem, "facturarToolStripMenuItem");
            this.facturarToolStripMenuItem.Name = "facturarToolStripMenuItem";
            this.facturarToolStripMenuItem.Click += new System.EventHandler(this.facturarToolStripMenuItem_Click);
            // 
            // emisiónPresupuestosToolStripMenuItem
            // 
            resources.ApplyResources(this.emisiónPresupuestosToolStripMenuItem, "emisiónPresupuestosToolStripMenuItem");
            this.emisiónPresupuestosToolStripMenuItem.Name = "emisiónPresupuestosToolStripMenuItem";
            this.emisiónPresupuestosToolStripMenuItem.Click += new System.EventHandler(this.emisiónPresupuestosToolStripMenuItem_Click);
            // 
            // anulaciónDeComprobantesToolStripMenuItem
            // 
            this.anulaciónDeComprobantesToolStripMenuItem.Image = global::Login.Properties.Resources.borrar;
            this.anulaciónDeComprobantesToolStripMenuItem.Name = "anulaciónDeComprobantesToolStripMenuItem";
            resources.ApplyResources(this.anulaciónDeComprobantesToolStripMenuItem, "anulaciónDeComprobantesToolStripMenuItem");
            this.anulaciónDeComprobantesToolStripMenuItem.Click += new System.EventHandler(this.anulaciónDeComprobantesToolStripMenuItem_Click);
            // 
            // reportesToolStripMenuItem
            // 
            this.reportesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.comprobantesEmitidosToolStripMenuItem,
            this.stockToolStripMenuItem,
            this.movimientosDeArtículosToolStripMenuItem});
            this.reportesToolStripMenuItem.Name = "reportesToolStripMenuItem";
            resources.ApplyResources(this.reportesToolStripMenuItem, "reportesToolStripMenuItem");
            // 
            // comprobantesEmitidosToolStripMenuItem
            // 
            this.comprobantesEmitidosToolStripMenuItem.Image = global::Login.Properties.Resources.listado;
            this.comprobantesEmitidosToolStripMenuItem.Name = "comprobantesEmitidosToolStripMenuItem";
            resources.ApplyResources(this.comprobantesEmitidosToolStripMenuItem, "comprobantesEmitidosToolStripMenuItem");
            this.comprobantesEmitidosToolStripMenuItem.Click += new System.EventHandler(this.comprobantesEmitidosToolStripMenuItem_Click);
            // 
            // stockToolStripMenuItem
            // 
            this.stockToolStripMenuItem.Image = global::Login.Properties.Resources.listado;
            this.stockToolStripMenuItem.Name = "stockToolStripMenuItem";
            resources.ApplyResources(this.stockToolStripMenuItem, "stockToolStripMenuItem");
            this.stockToolStripMenuItem.Click += new System.EventHandler(this.stockToolStripMenuItem_Click);
            // 
            // movimientosDeArtículosToolStripMenuItem
            // 
            this.movimientosDeArtículosToolStripMenuItem.Image = global::Login.Properties.Resources.listado;
            this.movimientosDeArtículosToolStripMenuItem.Name = "movimientosDeArtículosToolStripMenuItem";
            resources.ApplyResources(this.movimientosDeArtículosToolStripMenuItem, "movimientosDeArtículosToolStripMenuItem");
            this.movimientosDeArtículosToolStripMenuItem.Click += new System.EventHandler(this.movimientosDeArtículosToolStripMenuItem_Click);
            // 
            // usuarioToolStripMenuItem
            // 
            this.usuarioToolStripMenuItem.Name = "usuarioToolStripMenuItem";
            resources.ApplyResources(this.usuarioToolStripMenuItem, "usuarioToolStripMenuItem");
            this.usuarioToolStripMenuItem.Click += new System.EventHandler(this.usuarioToolStripMenuItem_Click);
            // 
            // mantenimientoToolStripMenuItem
            // 
            this.mantenimientoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ponerContadoresEnCeroToolStripMenuItem});
            this.mantenimientoToolStripMenuItem.Name = "mantenimientoToolStripMenuItem";
            resources.ApplyResources(this.mantenimientoToolStripMenuItem, "mantenimientoToolStripMenuItem");
            // 
            // ponerContadoresEnCeroToolStripMenuItem
            // 
            this.ponerContadoresEnCeroToolStripMenuItem.Image = global::Login.Properties.Resources.Advertencia;
            this.ponerContadoresEnCeroToolStripMenuItem.Name = "ponerContadoresEnCeroToolStripMenuItem";
            resources.ApplyResources(this.ponerContadoresEnCeroToolStripMenuItem, "ponerContadoresEnCeroToolStripMenuItem");
            this.ponerContadoresEnCeroToolStripMenuItem.Click += new System.EventHandler(this.ponerContadoresEnCeroToolStripMenuItem_Click);
            // 
            // ayudaToolStripMenuItem
            // 
            this.ayudaToolStripMenuItem.Name = "ayudaToolStripMenuItem";
            resources.ApplyResources(this.ayudaToolStripMenuItem, "ayudaToolStripMenuItem");
            this.ayudaToolStripMenuItem.Click += new System.EventHandler(this.ayudaToolStripMenuItem_Click);
            // 
            // Principal
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.BackColor = System.Drawing.Color.Navy;
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Principal";
            this.TransparencyKey = System.Drawing.SystemColors.ButtonShadow;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.PrincipalLoad);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
        private System.Windows.Forms.ToolStripMenuItem archivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ciudadesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ayudaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem usuarioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clasificaciónToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aleaciónToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem templeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem facturaciónToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem facturarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clientesToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem agregarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modificarToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem listadoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem emisiónPresupuestosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mediosDePagoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem anulaciónDeComprobantesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mantenimientoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ponerContadoresEnCeroToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reportesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem comprobantesEmitidosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stockToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cambioDePreciosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem porPorcentajeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem porImporteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem entradasSalidasDeArtículosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem movimientosDeArtículosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem marcaVehiculoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modeloVehículoToolStripMenuItem;
    }
}
