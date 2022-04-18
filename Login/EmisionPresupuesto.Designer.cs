
namespace Login
{
	partial class EmisionPresupuesto
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.DataGridView Cuadro;
		private System.Windows.Forms.TextBox txtCodigo;
		private System.Windows.Forms.TextBox txtDescripcion;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.NumericUpDown cant;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Button Buscar;
		private System.Windows.Forms.Button agregar;
		private System.Windows.Forms.Button quitar;
		private System.Windows.Forms.Button ConfirmarBTN;
		private System.Windows.Forms.Button SalirBTN;
		private System.Windows.Forms.CheckBox ImprimeChek;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox NumCliTXT;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox Cliente;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox Telefono;
		private System.Windows.Forms.TextBox Direccion;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.NumericUpDown PrecioNum;
		
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EmisionPresupuesto));
            this.Cuadro = new System.Windows.Forms.DataGridView();
            this.check = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Código = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descripción = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Precio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Subtotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cant = new System.Windows.Forms.NumericUpDown();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.Buscar = new System.Windows.Forms.Button();
            this.agregar = new System.Windows.Forms.Button();
            this.quitar = new System.Windows.Forms.Button();
            this.ConfirmarBTN = new System.Windows.Forms.Button();
            this.ImprimeChek = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.NumCliTXT = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.Cliente = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.Telefono = new System.Windows.Forms.TextBox();
            this.Direccion = new System.Windows.Forms.TextBox();
            this.SalirBTN = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.PrecioNum = new System.Windows.Forms.NumericUpDown();
            this.Limpiar = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.Localidad = new System.Windows.Forms.TextBox();
            this.BonificacionNUM = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.PrecioFinalNum = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.Telefono2 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.button2 = new System.Windows.Forms.Button();
            this.CambiaRec = new System.Windows.Forms.Button();
            this.CambiaBon = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.RecargoNum = new System.Windows.Forms.NumericUpDown();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.label15 = new System.Windows.Forms.Label();
            this.UsuarioCBX = new System.Windows.Forms.ComboBox();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.label17 = new System.Windows.Forms.Label();
            this.RecFinanNum = new System.Windows.Forms.NumericUpDown();
            this.label16 = new System.Windows.Forms.Label();
            this.MediosPagoCBX = new System.Windows.Forms.ComboBox();
            this.TotalNUM = new System.Windows.Forms.NumericUpDown();
            this.label14 = new System.Windows.Forms.Label();
            this.TotalRecargo = new System.Windows.Forms.NumericUpDown();
            this.label13 = new System.Windows.Forms.Label();
            this.SubTotalNUM = new System.Windows.Forms.NumericUpDown();
            this.label12 = new System.Windows.Forms.Label();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            ((System.ComponentModel.ISupportInitialize)(this.Cuadro)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cant)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PrecioNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BonificacionNUM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PrecioFinalNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RecargoNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RecFinanNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TotalNUM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TotalRecargo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SubTotalNUM)).BeginInit();
            this.SuspendLayout();
            // 
            // Cuadro
            // 
            this.Cuadro.BackgroundColor = System.Drawing.SystemColors.ActiveBorder;
            this.Cuadro.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Cuadro.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.Cuadro.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Cuadro.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.check,
            this.Código,
            this.Descripción,
            this.Cantidad,
            this.Precio,
            this.Subtotal});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.Cuadro.DefaultCellStyle = dataGridViewCellStyle3;
            this.Cuadro.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Cuadro.Location = new System.Drawing.Point(0, 0);
            this.Cuadro.Margin = new System.Windows.Forms.Padding(2);
            this.Cuadro.Name = "Cuadro";
            this.Cuadro.ReadOnly = true;
            this.Cuadro.RowHeadersVisible = false;
            this.Cuadro.RowHeadersWidth = 30;
            this.Cuadro.RowTemplate.Height = 24;
            this.Cuadro.Size = new System.Drawing.Size(634, 247);
            this.Cuadro.TabIndex = 100;
            this.Cuadro.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.seleccioncelda);
            // 
            // check
            // 
            this.check.HeaderText = "check";
            this.check.Name = "check";
            this.check.ReadOnly = true;
            this.check.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.check.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.check.Visible = false;
            // 
            // Código
            // 
            this.Código.HeaderText = "Código";
            this.Código.MinimumWidth = 6;
            this.Código.Name = "Código";
            this.Código.ReadOnly = true;
            // 
            // Descripción
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.Descripción.DefaultCellStyle = dataGridViewCellStyle2;
            this.Descripción.HeaderText = "Descripción";
            this.Descripción.MinimumWidth = 6;
            this.Descripción.Name = "Descripción";
            this.Descripción.ReadOnly = true;
            this.Descripción.Width = 230;
            // 
            // Cantidad
            // 
            this.Cantidad.HeaderText = "Cantidad";
            this.Cantidad.MinimumWidth = 6;
            this.Cantidad.Name = "Cantidad";
            this.Cantidad.ReadOnly = true;
            this.Cantidad.Width = 83;
            // 
            // Precio
            // 
            this.Precio.HeaderText = "Precio";
            this.Precio.MinimumWidth = 6;
            this.Precio.Name = "Precio";
            this.Precio.ReadOnly = true;
            // 
            // Subtotal
            // 
            this.Subtotal.HeaderText = "Sub-total";
            this.Subtotal.MinimumWidth = 6;
            this.Subtotal.Name = "Subtotal";
            this.Subtotal.ReadOnly = true;
            this.Subtotal.Width = 120;
            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new System.Drawing.Point(70, 170);
            this.txtCodigo.Margin = new System.Windows.Forms.Padding(2);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(103, 20);
            this.txtCodigo.TabIndex = 2;
            this.txtCodigo.TextChanged += new System.EventHandler(this.txtCodigo_TextChanged);
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(70, 200);
            this.txtDescripcion.Margin = new System.Windows.Forms.Padding(2);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.ReadOnly = true;
            this.txtDescripcion.Size = new System.Drawing.Size(170, 20);
            this.txtDescripcion.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(6, 169);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 18);
            this.label1.TabIndex = 3;
            this.label1.Text = "Artículo";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(48, 351);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 19);
            this.label3.TabIndex = 5;
            this.label3.Text = "Cantidad";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cant
            // 
            this.cant.BackColor = System.Drawing.Color.DimGray;
            this.cant.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cant.ForeColor = System.Drawing.SystemColors.Window;
            this.cant.Location = new System.Drawing.Point(187, 350);
            this.cant.Margin = new System.Windows.Forms.Padding(2);
            this.cant.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.cant.Name = "cant";
            this.cant.Size = new System.Drawing.Size(53, 20);
            this.cant.TabIndex = 4;
            this.cant.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox1.Location = new System.Drawing.Point(40, 50);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(200, 100);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // Buscar
            // 
            this.Buscar.Location = new System.Drawing.Point(177, 170);
            this.Buscar.Margin = new System.Windows.Forms.Padding(2);
            this.Buscar.Name = "Buscar";
            this.Buscar.Size = new System.Drawing.Size(63, 20);
            this.Buscar.TabIndex = 3;
            this.Buscar.Text = "Buscar";
            this.Buscar.UseVisualStyleBackColor = true;
            this.Buscar.Click += new System.EventHandler(this.BuscarClick);
            // 
            // agregar
            // 
            this.agregar.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.agregar.Location = new System.Drawing.Point(51, 387);
            this.agregar.Margin = new System.Windows.Forms.Padding(2);
            this.agregar.Name = "agregar";
            this.agregar.Size = new System.Drawing.Size(90, 23);
            this.agregar.TabIndex = 12;
            this.agregar.Text = "AGREGAR";
            this.agregar.UseVisualStyleBackColor = true;
            this.agregar.Click += new System.EventHandler(this.agregarClick);
            // 
            // quitar
            // 
            this.quitar.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.quitar.Location = new System.Drawing.Point(150, 387);
            this.quitar.Margin = new System.Windows.Forms.Padding(2);
            this.quitar.Name = "quitar";
            this.quitar.Size = new System.Drawing.Size(90, 23);
            this.quitar.TabIndex = 13;
            this.quitar.Text = "QUITAR";
            this.quitar.UseVisualStyleBackColor = true;
            this.quitar.Click += new System.EventHandler(this.QuitarClick);
            // 
            // ConfirmarBTN
            // 
            this.ConfirmarBTN.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ConfirmarBTN.Location = new System.Drawing.Point(452, 32);
            this.ConfirmarBTN.Margin = new System.Windows.Forms.Padding(2);
            this.ConfirmarBTN.Name = "ConfirmarBTN";
            this.ConfirmarBTN.Size = new System.Drawing.Size(90, 47);
            this.ConfirmarBTN.TabIndex = 20;
            this.ConfirmarBTN.Text = "CONFIRMAR";
            this.ConfirmarBTN.UseVisualStyleBackColor = true;
            this.ConfirmarBTN.Click += new System.EventHandler(this.FacturarClick);
            // 
            // ImprimeChek
            // 
            this.ImprimeChek.Checked = true;
            this.ImprimeChek.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ImprimeChek.ForeColor = System.Drawing.Color.White;
            this.ImprimeChek.Location = new System.Drawing.Point(452, 8);
            this.ImprimeChek.Margin = new System.Windows.Forms.Padding(2);
            this.ImprimeChek.Name = "ImprimeChek";
            this.ImprimeChek.Size = new System.Drawing.Size(128, 20);
            this.ImprimeChek.TabIndex = 8;
            this.ImprimeChek.Text = "Imprime Presupuesto";
            this.ImprimeChek.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label4.Location = new System.Drawing.Point(12, 57);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 18);
            this.label4.TabIndex = 15;
            this.label4.Text = "Cliente";
            // 
            // NumCliTXT
            // 
            this.NumCliTXT.Location = new System.Drawing.Point(90, 56);
            this.NumCliTXT.Margin = new System.Windows.Forms.Padding(2);
            this.NumCliTXT.Name = "NumCliTXT";
            this.NumCliTXT.Size = new System.Drawing.Size(68, 20);
            this.NumCliTXT.TabIndex = 0;
            this.NumCliTXT.TextChanged += new System.EventHandler(this.NumCliTXT_TextChanged);
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label5.Location = new System.Drawing.Point(12, 81);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 20);
            this.label5.TabIndex = 19;
            this.label5.Text = "Dirección";
            // 
            // Cliente
            // 
            this.Cliente.Location = new System.Drawing.Point(229, 57);
            this.Cliente.Margin = new System.Windows.Forms.Padding(2);
            this.Cliente.Name = "Cliente";
            this.Cliente.ReadOnly = true;
            this.Cliente.Size = new System.Drawing.Size(176, 20);
            this.Cliente.TabIndex = 22;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(407, 57);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(76, 18);
            this.label6.TabIndex = 21;
            this.label6.Text = "Teléfono";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Telefono
            // 
            this.Telefono.Location = new System.Drawing.Point(482, 58);
            this.Telefono.Margin = new System.Windows.Forms.Padding(2);
            this.Telefono.Name = "Telefono";
            this.Telefono.ReadOnly = true;
            this.Telefono.Size = new System.Drawing.Size(135, 20);
            this.Telefono.TabIndex = 23;
            // 
            // Direccion
            // 
            this.Direccion.Location = new System.Drawing.Point(90, 81);
            this.Direccion.Margin = new System.Windows.Forms.Padding(2);
            this.Direccion.Name = "Direccion";
            this.Direccion.ReadOnly = true;
            this.Direccion.Size = new System.Drawing.Size(135, 20);
            this.Direccion.TabIndex = 24;
            // 
            // SalirBTN
            // 
            this.SalirBTN.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.SalirBTN.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SalirBTN.Location = new System.Drawing.Point(546, 32);
            this.SalirBTN.Margin = new System.Windows.Forms.Padding(2);
            this.SalirBTN.Name = "SalirBTN";
            this.SalirBTN.Size = new System.Drawing.Size(76, 47);
            this.SalirBTN.TabIndex = 21;
            this.SalirBTN.Text = "SALIR";
            this.SalirBTN.UseVisualStyleBackColor = true;
            this.SalirBTN.Click += new System.EventHandler(this.SalirClick);
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(-8, 230);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(92, 19);
            this.label9.TabIndex = 28;
            this.label9.Text = "Precio";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // PrecioNum
            // 
            this.PrecioNum.DecimalPlaces = 2;
            this.PrecioNum.Increment = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.PrecioNum.Location = new System.Drawing.Point(88, 230);
            this.PrecioNum.Margin = new System.Windows.Forms.Padding(2);
            this.PrecioNum.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.PrecioNum.Name = "PrecioNum";
            this.PrecioNum.ReadOnly = true;
            this.PrecioNum.Size = new System.Drawing.Size(95, 20);
            this.PrecioNum.TabIndex = 6;
            this.PrecioNum.ValueChanged += new System.EventHandler(this.PrecioNum_ValueChanged);
            // 
            // Limpiar
            // 
            this.Limpiar.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Limpiar.Location = new System.Drawing.Point(150, 421);
            this.Limpiar.Margin = new System.Windows.Forms.Padding(2);
            this.Limpiar.Name = "Limpiar";
            this.Limpiar.Size = new System.Drawing.Size(90, 23);
            this.Limpiar.TabIndex = 14;
            this.Limpiar.Text = "LIMPIAR";
            this.Limpiar.UseVisualStyleBackColor = true;
            this.Limpiar.Click += new System.EventHandler(this.LimpiarClick);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(162, 56);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(63, 20);
            this.button1.TabIndex = 1;
            this.button1.Text = "Buscar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Localidad
            // 
            this.Localidad.Location = new System.Drawing.Point(229, 81);
            this.Localidad.Margin = new System.Windows.Forms.Padding(2);
            this.Localidad.Name = "Localidad";
            this.Localidad.ReadOnly = true;
            this.Localidad.Size = new System.Drawing.Size(176, 20);
            this.Localidad.TabIndex = 25;
            // 
            // BonificacionNUM
            // 
            this.BonificacionNUM.DecimalPlaces = 2;
            this.BonificacionNUM.Increment = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.BonificacionNUM.Location = new System.Drawing.Point(113, 258);
            this.BonificacionNUM.Margin = new System.Windows.Forms.Padding(2);
            this.BonificacionNUM.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.BonificacionNUM.Name = "BonificacionNUM";
            this.BonificacionNUM.ReadOnly = true;
            this.BonificacionNUM.Size = new System.Drawing.Size(70, 20);
            this.BonificacionNUM.TabIndex = 7;
            this.BonificacionNUM.ValueChanged += new System.EventHandler(this.BonificacionNUM_ValueChanged);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(11, 258);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 19);
            this.label2.TabIndex = 105;
            this.label2.Text = "Bonific.";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // PrecioFinalNum
            // 
            this.PrecioFinalNum.DecimalPlaces = 2;
            this.PrecioFinalNum.Increment = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.PrecioFinalNum.Location = new System.Drawing.Point(145, 320);
            this.PrecioFinalNum.Margin = new System.Windows.Forms.Padding(2);
            this.PrecioFinalNum.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.PrecioFinalNum.Name = "PrecioFinalNum";
            this.PrecioFinalNum.ReadOnly = true;
            this.PrecioFinalNum.Size = new System.Drawing.Size(95, 20);
            this.PrecioFinalNum.TabIndex = 11;
            this.PrecioFinalNum.ValueChanged += new System.EventHandler(this.PrecioFinalNum_ValueChanged);
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(48, 318);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(90, 19);
            this.label8.TabIndex = 107;
            this.label8.Text = "Precio Final";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Telefono2
            // 
            this.Telefono2.Location = new System.Drawing.Point(482, 81);
            this.Telefono2.Margin = new System.Windows.Forms.Padding(2);
            this.Telefono2.Name = "Telefono2";
            this.Telefono2.ReadOnly = true;
            this.Telefono2.Size = new System.Drawing.Size(135, 20);
            this.Telefono2.TabIndex = 26;
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(407, 80);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(76, 18);
            this.label7.TabIndex = 108;
            this.label7.Text = "Teléfono";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.splitContainer1.Panel1.Controls.Add(this.button2);
            this.splitContainer1.Panel1.Controls.Add(this.CambiaRec);
            this.splitContainer1.Panel1.Controls.Add(this.CambiaBon);
            this.splitContainer1.Panel1.Controls.Add(this.label11);
            this.splitContainer1.Panel1.Controls.Add(this.label10);
            this.splitContainer1.Panel1.Controls.Add(this.RecargoNum);
            this.splitContainer1.Panel1.Controls.Add(this.PrecioNum);
            this.splitContainer1.Panel1.Controls.Add(this.txtCodigo);
            this.splitContainer1.Panel1.Controls.Add(this.txtDescripcion);
            this.splitContainer1.Panel1.Controls.Add(this.Limpiar);
            this.splitContainer1.Panel1.Controls.Add(this.PrecioFinalNum);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.label8);
            this.splitContainer1.Panel1.Controls.Add(this.label3);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.cant);
            this.splitContainer1.Panel1.Controls.Add(this.BonificacionNUM);
            this.splitContainer1.Panel1.Controls.Add(this.quitar);
            this.splitContainer1.Panel1.Controls.Add(this.Buscar);
            this.splitContainer1.Panel1.Controls.Add(this.label9);
            this.splitContainer1.Panel1.Controls.Add(this.agregar);
            this.splitContainer1.Panel1.Controls.Add(this.pictureBox1);
            this.splitContainer1.Panel1.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(908, 462);
            this.splitContainer1.SplitterDistance = 270;
            this.splitContainer1.TabIndex = 110;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(187, 230);
            this.button2.Margin = new System.Windows.Forms.Padding(2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(53, 20);
            this.button2.TabIndex = 111;
            this.button2.Text = "Cambiar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // CambiaRec
            // 
            this.CambiaRec.Location = new System.Drawing.Point(187, 288);
            this.CambiaRec.Margin = new System.Windows.Forms.Padding(2);
            this.CambiaRec.Name = "CambiaRec";
            this.CambiaRec.Size = new System.Drawing.Size(53, 20);
            this.CambiaRec.TabIndex = 10;
            this.CambiaRec.Text = "Cambiar";
            this.CambiaRec.UseVisualStyleBackColor = true;
            this.CambiaRec.Click += new System.EventHandler(this.CambiaRec_Click);
            // 
            // CambiaBon
            // 
            this.CambiaBon.Location = new System.Drawing.Point(187, 258);
            this.CambiaBon.Margin = new System.Windows.Forms.Padding(2);
            this.CambiaBon.Name = "CambiaBon";
            this.CambiaBon.Size = new System.Drawing.Size(53, 20);
            this.CambiaBon.TabIndex = 8;
            this.CambiaBon.Text = "Cambiar";
            this.CambiaBon.UseVisualStyleBackColor = true;
            this.CambiaBon.Click += new System.EventHandler(this.CambiaBon_Click);
            // 
            // label11
            // 
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(37, 9);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(196, 18);
            this.label11.TabIndex = 110;
            this.label11.Text = "CARGA DE ARTÍCULOS";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(43, 289);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(66, 19);
            this.label10.TabIndex = 109;
            this.label10.Text = "Recargo";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // RecargoNum
            // 
            this.RecargoNum.DecimalPlaces = 2;
            this.RecargoNum.Increment = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.RecargoNum.Location = new System.Drawing.Point(113, 288);
            this.RecargoNum.Margin = new System.Windows.Forms.Padding(2);
            this.RecargoNum.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.RecargoNum.Name = "RecargoNum";
            this.RecargoNum.ReadOnly = true;
            this.RecargoNum.Size = new System.Drawing.Size(70, 20);
            this.RecargoNum.TabIndex = 9;
            this.RecargoNum.ValueChanged += new System.EventHandler(this.RecargoNum_ValueChanged);
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.splitContainer2.Panel1.Controls.Add(this.label15);
            this.splitContainer2.Panel1.Controls.Add(this.UsuarioCBX);
            this.splitContainer2.Panel1.Controls.Add(this.Localidad);
            this.splitContainer2.Panel1.Controls.Add(this.Telefono2);
            this.splitContainer2.Panel1.Controls.Add(this.label4);
            this.splitContainer2.Panel1.Controls.Add(this.label7);
            this.splitContainer2.Panel1.Controls.Add(this.NumCliTXT);
            this.splitContainer2.Panel1.Controls.Add(this.label5);
            this.splitContainer2.Panel1.Controls.Add(this.button1);
            this.splitContainer2.Panel1.Controls.Add(this.Cliente);
            this.splitContainer2.Panel1.Controls.Add(this.Direccion);
            this.splitContainer2.Panel1.Controls.Add(this.label6);
            this.splitContainer2.Panel1.Controls.Add(this.Telefono);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.splitContainer3);
            this.splitContainer2.Size = new System.Drawing.Size(634, 462);
            this.splitContainer2.SplitterDistance = 114;
            this.splitContainer2.TabIndex = 0;
            // 
            // label15
            // 
            this.label15.BackColor = System.Drawing.Color.Transparent;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.Red;
            this.label15.Location = new System.Drawing.Point(401, 15);
            this.label15.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(76, 18);
            this.label15.TabIndex = 111;
            this.label15.Text = "Emisor:";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // UsuarioCBX
            // 
            this.UsuarioCBX.ForeColor = System.Drawing.Color.Red;
            this.UsuarioCBX.FormattingEnabled = true;
            this.UsuarioCBX.Location = new System.Drawing.Point(482, 12);
            this.UsuarioCBX.Name = "UsuarioCBX";
            this.UsuarioCBX.Size = new System.Drawing.Size(135, 21);
            this.UsuarioCBX.TabIndex = 27;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.Cuadro);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.splitContainer3.Panel2.Controls.Add(this.label17);
            this.splitContainer3.Panel2.Controls.Add(this.RecFinanNum);
            this.splitContainer3.Panel2.Controls.Add(this.label16);
            this.splitContainer3.Panel2.Controls.Add(this.MediosPagoCBX);
            this.splitContainer3.Panel2.Controls.Add(this.TotalNUM);
            this.splitContainer3.Panel2.Controls.Add(this.label14);
            this.splitContainer3.Panel2.Controls.Add(this.TotalRecargo);
            this.splitContainer3.Panel2.Controls.Add(this.label13);
            this.splitContainer3.Panel2.Controls.Add(this.SubTotalNUM);
            this.splitContainer3.Panel2.Controls.Add(this.label12);
            this.splitContainer3.Panel2.Controls.Add(this.ConfirmarBTN);
            this.splitContainer3.Panel2.Controls.Add(this.ImprimeChek);
            this.splitContainer3.Panel2.Controls.Add(this.SalirBTN);
            this.splitContainer3.Size = new System.Drawing.Size(634, 344);
            this.splitContainer3.SplitterDistance = 247;
            this.splitContainer3.TabIndex = 0;
            // 
            // label17
            // 
            this.label17.BackColor = System.Drawing.Color.Transparent;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.Color.White;
            this.label17.Location = new System.Drawing.Point(74, 63);
            this.label17.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(21, 18);
            this.label17.TabIndex = 120;
            this.label17.Text = "%";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // RecFinanNum
            // 
            this.RecFinanNum.DecimalPlaces = 2;
            this.RecFinanNum.Increment = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.RecFinanNum.Location = new System.Drawing.Point(15, 61);
            this.RecFinanNum.Margin = new System.Windows.Forms.Padding(2);
            this.RecFinanNum.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.RecFinanNum.Name = "RecFinanNum";
            this.RecFinanNum.ReadOnly = true;
            this.RecFinanNum.Size = new System.Drawing.Size(55, 20);
            this.RecFinanNum.TabIndex = 16;
            this.RecFinanNum.ValueChanged += new System.EventHandler(this.RecFinanNum_ValueChanged);
            // 
            // label16
            // 
            this.label16.BackColor = System.Drawing.Color.Transparent;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.White;
            this.label16.Location = new System.Drawing.Point(12, 8);
            this.label16.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(111, 18);
            this.label16.TabIndex = 118;
            this.label16.Text = "Medio de pago";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // MediosPagoCBX
            // 
            this.MediosPagoCBX.ForeColor = System.Drawing.Color.Black;
            this.MediosPagoCBX.FormattingEnabled = true;
            this.MediosPagoCBX.Location = new System.Drawing.Point(15, 35);
            this.MediosPagoCBX.Name = "MediosPagoCBX";
            this.MediosPagoCBX.Size = new System.Drawing.Size(176, 21);
            this.MediosPagoCBX.TabIndex = 15;
            this.MediosPagoCBX.SelectionChangeCommitted += new System.EventHandler(this.MediosPagoCBX_SelectionChangeCommitted);
            // 
            // TotalNUM
            // 
            this.TotalNUM.DecimalPlaces = 2;
            this.TotalNUM.Location = new System.Drawing.Point(325, 59);
            this.TotalNUM.Margin = new System.Windows.Forms.Padding(2);
            this.TotalNUM.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.TotalNUM.Name = "TotalNUM";
            this.TotalNUM.ReadOnly = true;
            this.TotalNUM.Size = new System.Drawing.Size(95, 20);
            this.TotalNUM.TabIndex = 19;
            // 
            // label14
            // 
            this.label14.BackColor = System.Drawing.Color.Transparent;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.White;
            this.label14.Location = new System.Drawing.Point(228, 57);
            this.label14.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(92, 19);
            this.label14.TabIndex = 116;
            this.label14.Text = "Total:";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // TotalRecargo
            // 
            this.TotalRecargo.DecimalPlaces = 2;
            this.TotalRecargo.Location = new System.Drawing.Point(325, 34);
            this.TotalRecargo.Margin = new System.Windows.Forms.Padding(2);
            this.TotalRecargo.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.TotalRecargo.Name = "TotalRecargo";
            this.TotalRecargo.ReadOnly = true;
            this.TotalRecargo.Size = new System.Drawing.Size(95, 20);
            this.TotalRecargo.TabIndex = 18;
            // 
            // label13
            // 
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.White;
            this.label13.Location = new System.Drawing.Point(182, 34);
            this.label13.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(138, 19);
            this.label13.TabIndex = 114;
            this.label13.Text = "Rec. Financ.";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // SubTotalNUM
            // 
            this.SubTotalNUM.DecimalPlaces = 2;
            this.SubTotalNUM.Location = new System.Drawing.Point(325, 9);
            this.SubTotalNUM.Margin = new System.Windows.Forms.Padding(2);
            this.SubTotalNUM.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.SubTotalNUM.Name = "SubTotalNUM";
            this.SubTotalNUM.ReadOnly = true;
            this.SubTotalNUM.Size = new System.Drawing.Size(95, 20);
            this.SubTotalNUM.TabIndex = 17;
            this.SubTotalNUM.ValueChanged += new System.EventHandler(this.SubTotalNUM_ValueChanged);
            // 
            // label12
            // 
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(228, 10);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(92, 19);
            this.label12.TabIndex = 112;
            this.label12.Text = "Sub-Total:";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // EmisionPresupuesto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.CancelButton = this.SalirBTN;
            this.ClientSize = new System.Drawing.Size(908, 462);
            this.ControlBox = false;
            this.Controls.Add(this.splitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "EmisionPresupuesto";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Emisión de presupuestos";
            this.Load += new System.EventHandler(this.factura_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Cuadro)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cant)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PrecioNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BonificacionNUM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PrecioFinalNum)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.RecargoNum)).EndInit();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.RecFinanNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TotalNUM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TotalRecargo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SubTotalNUM)).EndInit();
            this.ResumeLayout(false);

		}
		private System.Windows.Forms.Button Limpiar;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox Localidad;
        private System.Windows.Forms.NumericUpDown BonificacionNUM;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown PrecioFinalNum;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox Telefono2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.DataGridViewCheckBoxColumn check;
        private System.Windows.Forms.DataGridViewTextBoxColumn Código;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descripción;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn Precio;
        private System.Windows.Forms.DataGridViewTextBoxColumn Subtotal;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.NumericUpDown RecargoNum;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.NumericUpDown TotalNUM;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.NumericUpDown TotalRecargo;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.NumericUpDown SubTotalNUM;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ComboBox UsuarioCBX;
        private System.Windows.Forms.Button CambiaRec;
        private System.Windows.Forms.Button CambiaBon;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.ComboBox MediosPagoCBX;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.NumericUpDown RecFinanNum;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.Button button2;
    }
}
