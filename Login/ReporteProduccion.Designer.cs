/*
 * Creado por SharpDevelop.
 * Usuario: rodri
 * Fecha: 7/8/2020
 * Hora: 20:49
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
namespace Login
{
    partial class ReporteProduccion
    {
        /// <summary>
        /// Designer variable used to keep track of non-visual components.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Disposes resources used by the form.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReporteProduccion));
            this.Buscar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.Cancelar = new System.Windows.Forms.Button();
            this.Exportarboton = new System.Windows.Forms.Button();
            this.Fecha1DTP = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.Cuadro = new System.Windows.Forms.DataGridView();
            this.imprime = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Kgs = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.Fecha2DTP = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Acumulados = new System.Windows.Forms.TextBox();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.Cuadro2 = new System.Windows.Forms.DataGridView();
            this.OP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn201 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Articulo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KgsPresa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn200 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rendi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewButtonColumn1 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.TiempoTXT = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.kgHoraTXT = new System.Windows.Forms.TextBox();
            this.tochoHoraTXT = new System.Windows.Forms.TextBox();
            this.kgDespachoTXT = new System.Windows.Forms.TextBox();
            this.kgPrensaTXT = new System.Windows.Forms.TextBox();
            this.totalBarrotesTXT = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.TiempoParadaTXT = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.Cuadro)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Cuadro2)).BeginInit();
            this.SuspendLayout();
            // 
            // Buscar
            // 
            this.Buscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Buscar.Location = new System.Drawing.Point(163, 66);
            this.Buscar.Margin = new System.Windows.Forms.Padding(2);
            this.Buscar.Name = "Buscar";
            this.Buscar.Size = new System.Drawing.Size(67, 24);
            this.Buscar.TabIndex = 10;
            this.Buscar.Text = "Buscar";
            this.Buscar.UseVisualStyleBackColor = true;
            this.Buscar.Click += new System.EventHandler(this.BuscarClick);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(11, 11);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(276, 33);
            this.label2.TabIndex = 26;
            this.label2.Text = "Reporte de Producción";
            // 
            // Cancelar
            // 
            this.Cancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Cancelar.Location = new System.Drawing.Point(656, 12);
            this.Cancelar.Margin = new System.Windows.Forms.Padding(2);
            this.Cancelar.Name = "Cancelar";
            this.Cancelar.Size = new System.Drawing.Size(67, 24);
            this.Cancelar.TabIndex = 11;
            this.Cancelar.Text = "Salir";
            this.Cancelar.UseVisualStyleBackColor = true;
            this.Cancelar.Click += new System.EventHandler(this.Cancelar_Click);
            // 
            // Exportarboton
            // 
            this.Exportarboton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Exportarboton.Location = new System.Drawing.Point(656, 43);
            this.Exportarboton.Margin = new System.Windows.Forms.Padding(2);
            this.Exportarboton.Name = "Exportarboton";
            this.Exportarboton.Size = new System.Drawing.Size(67, 24);
            this.Exportarboton.TabIndex = 12;
            this.Exportarboton.Text = "Exportar";
            this.Exportarboton.UseVisualStyleBackColor = true;
            this.Exportarboton.Click += new System.EventHandler(this.Exportarboton_Click);
            // 
            // Fecha1DTP
            // 
            this.Fecha1DTP.CustomFormat = "dd/MM/yyyy";
            this.Fecha1DTP.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.Fecha1DTP.Location = new System.Drawing.Point(63, 46);
            this.Fecha1DTP.Margin = new System.Windows.Forms.Padding(2);
            this.Fecha1DTP.Name = "Fecha1DTP";
            this.Fecha1DTP.Size = new System.Drawing.Size(84, 20);
            this.Fecha1DTP.TabIndex = 5;
            this.Fecha1DTP.Value = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(10, 46);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 17);
            this.label3.TabIndex = 37;
            this.label3.Text = "Desde:";
            // 
            // Cuadro
            // 
            this.Cuadro.AllowUserToAddRows = false;
            this.Cuadro.AllowUserToDeleteRows = false;
            this.Cuadro.BackgroundColor = System.Drawing.SystemColors.ActiveBorder;
            this.Cuadro.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Cuadro.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.imprime,
            this.Fecha,
            this.Kgs});
            this.Cuadro.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Cuadro.Location = new System.Drawing.Point(0, 0);
            this.Cuadro.Margin = new System.Windows.Forms.Padding(2);
            this.Cuadro.Name = "Cuadro";
            this.Cuadro.ReadOnly = true;
            this.Cuadro.RowHeadersVisible = false;
            this.Cuadro.RowHeadersWidth = 51;
            this.Cuadro.RowTemplate.Height = 24;
            this.Cuadro.Size = new System.Drawing.Size(215, 448);
            this.Cuadro.TabIndex = 38;
            this.Cuadro.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Cuadro_CellClick);
            this.Cuadro.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Cuadro_CellContentClick);
            this.Cuadro.SelectionChanged += new System.EventHandler(this.Cuadro_SelectionChanged);
            // 
            // imprime
            // 
            this.imprime.FalseValue = "";
            this.imprime.HeaderText = " ";
            this.imprime.Name = "imprime";
            this.imprime.ReadOnly = true;
            this.imprime.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.imprime.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.imprime.TrueValue = "";
            this.imprime.Width = 30;
            // 
            // Fecha
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.Format = "d";
            dataGridViewCellStyle1.NullValue = null;
            this.Fecha.DefaultCellStyle = dataGridViewCellStyle1;
            this.Fecha.HeaderText = "Fecha";
            this.Fecha.MinimumWidth = 6;
            this.Fecha.Name = "Fecha";
            this.Fecha.ReadOnly = true;
            // 
            // Kgs
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Kgs.DefaultCellStyle = dataGridViewCellStyle2;
            this.Kgs.HeaderText = "Kgs";
            this.Kgs.MinimumWidth = 6;
            this.Kgs.Name = "Kgs";
            this.Kgs.ReadOnly = true;
            this.Kgs.Width = 87;
            // 
            // splitContainer1
            // 
            this.splitContainer1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.splitContainer1.Panel1.Controls.Add(this.Fecha2DTP);
            this.splitContainer1.Panel1.Controls.Add(this.label4);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.Acumulados);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.Buscar);
            this.splitContainer1.Panel1.Controls.Add(this.Cancelar);
            this.splitContainer1.Panel1.Controls.Add(this.Exportarboton);
            this.splitContainer1.Panel1.Controls.Add(this.Fecha1DTP);
            this.splitContainer1.Panel1.Controls.Add(this.label3);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(862, 562);
            this.splitContainer1.SplitterDistance = 110;
            this.splitContainer1.TabIndex = 50;
            // 
            // Fecha2DTP
            // 
            this.Fecha2DTP.CustomFormat = "dd/MM/yyyy";
            this.Fecha2DTP.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.Fecha2DTP.Location = new System.Drawing.Point(63, 70);
            this.Fecha2DTP.Margin = new System.Windows.Forms.Padding(2);
            this.Fecha2DTP.Name = "Fecha2DTP";
            this.Fecha2DTP.Size = new System.Drawing.Size(84, 20);
            this.Fecha2DTP.TabIndex = 48;
            this.Fecha2DTP.Value = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(12, 70);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 17);
            this.label4.TabIndex = 50;
            this.label4.Text = "Hasta:";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(328, 63);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 25);
            this.label1.TabIndex = 47;
            this.label1.Text = "Total Kg: ";
            // 
            // Acumulados
            // 
            this.Acumulados.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Acumulados.ForeColor = System.Drawing.Color.Red;
            this.Acumulados.Location = new System.Drawing.Point(428, 65);
            this.Acumulados.Name = "Acumulados";
            this.Acumulados.Size = new System.Drawing.Size(100, 22);
            this.Acumulados.TabIndex = 46;
            this.Acumulados.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.Cuadro);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.splitContainer3);
            this.splitContainer2.Size = new System.Drawing.Size(862, 448);
            this.splitContainer2.SplitterDistance = 215;
            this.splitContainer2.TabIndex = 39;
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
            this.splitContainer3.Panel1.Controls.Add(this.Cuadro2);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.BackColor = System.Drawing.Color.DimGray;
            this.splitContainer3.Panel2.Controls.Add(this.TiempoParadaTXT);
            this.splitContainer3.Panel2.Controls.Add(this.label11);
            this.splitContainer3.Panel2.Controls.Add(this.TiempoTXT);
            this.splitContainer3.Panel2.Controls.Add(this.label8);
            this.splitContainer3.Panel2.Controls.Add(this.kgHoraTXT);
            this.splitContainer3.Panel2.Controls.Add(this.tochoHoraTXT);
            this.splitContainer3.Panel2.Controls.Add(this.kgDespachoTXT);
            this.splitContainer3.Panel2.Controls.Add(this.kgPrensaTXT);
            this.splitContainer3.Panel2.Controls.Add(this.totalBarrotesTXT);
            this.splitContainer3.Panel2.Controls.Add(this.label9);
            this.splitContainer3.Panel2.Controls.Add(this.label10);
            this.splitContainer3.Panel2.Controls.Add(this.label7);
            this.splitContainer3.Panel2.Controls.Add(this.label6);
            this.splitContainer3.Panel2.Controls.Add(this.label5);
            this.splitContainer3.Size = new System.Drawing.Size(643, 448);
            this.splitContainer3.SplitterDistance = 304;
            this.splitContainer3.TabIndex = 40;
            // 
            // Cuadro2
            // 
            this.Cuadro2.AllowUserToAddRows = false;
            this.Cuadro2.AllowUserToDeleteRows = false;
            this.Cuadro2.BackgroundColor = System.Drawing.SystemColors.ActiveBorder;
            this.Cuadro2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Cuadro2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.OP,
            this.dataGridViewTextBoxColumn201,
            this.Articulo,
            this.KgsPresa,
            this.dataGridViewTextBoxColumn200,
            this.rendi,
            this.dataGridViewButtonColumn1});
            this.Cuadro2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Cuadro2.Location = new System.Drawing.Point(0, 0);
            this.Cuadro2.Margin = new System.Windows.Forms.Padding(2);
            this.Cuadro2.Name = "Cuadro2";
            this.Cuadro2.ReadOnly = true;
            this.Cuadro2.RowHeadersVisible = false;
            this.Cuadro2.RowHeadersWidth = 51;
            this.Cuadro2.RowTemplate.Height = 24;
            this.Cuadro2.Size = new System.Drawing.Size(643, 304);
            this.Cuadro2.TabIndex = 39;
            this.Cuadro2.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Cuadro2_CellClick);
            // 
            // OP
            // 
            this.OP.HeaderText = "OP";
            this.OP.Name = "OP";
            this.OP.ReadOnly = true;
            this.OP.Width = 40;
            // 
            // dataGridViewTextBoxColumn201
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.Format = "d";
            dataGridViewCellStyle3.NullValue = null;
            this.dataGridViewTextBoxColumn201.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewTextBoxColumn201.HeaderText = "Cliente";
            this.dataGridViewTextBoxColumn201.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn201.Name = "dataGridViewTextBoxColumn201";
            this.dataGridViewTextBoxColumn201.ReadOnly = true;
            this.dataGridViewTextBoxColumn201.Width = 150;
            // 
            // Articulo
            // 
            this.Articulo.HeaderText = "Artículo";
            this.Articulo.Name = "Articulo";
            this.Articulo.ReadOnly = true;
            this.Articulo.Width = 150;
            // 
            // KgsPresa
            // 
            this.KgsPresa.HeaderText = "Kgs Presa";
            this.KgsPresa.Name = "KgsPresa";
            this.KgsPresa.ReadOnly = true;
            this.KgsPresa.Width = 70;
            // 
            // dataGridViewTextBoxColumn200
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridViewTextBoxColumn200.DefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridViewTextBoxColumn200.HeaderText = "Kgs Despacho";
            this.dataGridViewTextBoxColumn200.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn200.Name = "dataGridViewTextBoxColumn200";
            this.dataGridViewTextBoxColumn200.ReadOnly = true;
            this.dataGridViewTextBoxColumn200.Width = 70;
            // 
            // rendi
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.Format = "N2";
            dataGridViewCellStyle5.NullValue = null;
            this.rendi.DefaultCellStyle = dataGridViewCellStyle5;
            this.rendi.HeaderText = "Rend. %";
            this.rendi.Name = "rendi";
            this.rendi.ReadOnly = true;
            this.rendi.Width = 60;
            // 
            // dataGridViewButtonColumn1
            // 
            this.dataGridViewButtonColumn1.HeaderText = "Puesto";
            this.dataGridViewButtonColumn1.MinimumWidth = 6;
            this.dataGridViewButtonColumn1.Name = "dataGridViewButtonColumn1";
            this.dataGridViewButtonColumn1.ReadOnly = true;
            this.dataGridViewButtonColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewButtonColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewButtonColumn1.Text = "Ver Detalle";
            // 
            // TiempoTXT
            // 
            this.TiempoTXT.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TiempoTXT.ForeColor = System.Drawing.Color.Red;
            this.TiempoTXT.Location = new System.Drawing.Point(506, 16);
            this.TiempoTXT.Name = "TiempoTXT";
            this.TiempoTXT.ReadOnly = true;
            this.TiempoTXT.Size = new System.Drawing.Size(100, 22);
            this.TiempoTXT.TabIndex = 61;
            this.TiempoTXT.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(356, 16);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(145, 30);
            this.label8.TabIndex = 60;
            this.label8.Text = "Tiempo de Trabajo:";
            // 
            // kgHoraTXT
            // 
            this.kgHoraTXT.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kgHoraTXT.ForeColor = System.Drawing.Color.Red;
            this.kgHoraTXT.Location = new System.Drawing.Point(506, 106);
            this.kgHoraTXT.Name = "kgHoraTXT";
            this.kgHoraTXT.ReadOnly = true;
            this.kgHoraTXT.Size = new System.Drawing.Size(100, 22);
            this.kgHoraTXT.TabIndex = 59;
            this.kgHoraTXT.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tochoHoraTXT
            // 
            this.tochoHoraTXT.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tochoHoraTXT.ForeColor = System.Drawing.Color.Red;
            this.tochoHoraTXT.Location = new System.Drawing.Point(506, 76);
            this.tochoHoraTXT.Name = "tochoHoraTXT";
            this.tochoHoraTXT.ReadOnly = true;
            this.tochoHoraTXT.Size = new System.Drawing.Size(100, 22);
            this.tochoHoraTXT.TabIndex = 58;
            this.tochoHoraTXT.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // kgDespachoTXT
            // 
            this.kgDespachoTXT.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kgDespachoTXT.ForeColor = System.Drawing.Color.Red;
            this.kgDespachoTXT.Location = new System.Drawing.Point(179, 76);
            this.kgDespachoTXT.Name = "kgDespachoTXT";
            this.kgDespachoTXT.ReadOnly = true;
            this.kgDespachoTXT.Size = new System.Drawing.Size(100, 22);
            this.kgDespachoTXT.TabIndex = 57;
            this.kgDespachoTXT.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // kgPrensaTXT
            // 
            this.kgPrensaTXT.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kgPrensaTXT.ForeColor = System.Drawing.Color.Red;
            this.kgPrensaTXT.Location = new System.Drawing.Point(178, 46);
            this.kgPrensaTXT.Name = "kgPrensaTXT";
            this.kgPrensaTXT.ReadOnly = true;
            this.kgPrensaTXT.Size = new System.Drawing.Size(100, 22);
            this.kgPrensaTXT.TabIndex = 56;
            this.kgPrensaTXT.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // totalBarrotesTXT
            // 
            this.totalBarrotesTXT.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalBarrotesTXT.ForeColor = System.Drawing.Color.Red;
            this.totalBarrotesTXT.Location = new System.Drawing.Point(178, 16);
            this.totalBarrotesTXT.Name = "totalBarrotesTXT";
            this.totalBarrotesTXT.ReadOnly = true;
            this.totalBarrotesTXT.Size = new System.Drawing.Size(100, 22);
            this.totalBarrotesTXT.TabIndex = 51;
            this.totalBarrotesTXT.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(373, 106);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(175, 33);
            this.label9.TabIndex = 55;
            this.label9.Text = "Prom. Kgs/hora:";
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(356, 76);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(145, 30);
            this.label10.TabIndex = 54;
            this.label10.Text = "Prom. Tocho/hora:";
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(16, 76);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(158, 33);
            this.label7.TabIndex = 53;
            this.label7.Text = "Total Kgs Despacho:";
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(38, 46);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(175, 33);
            this.label6.TabIndex = 52;
            this.label6.Text = "Total Kgs Prensa:";
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(58, 16);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(145, 30);
            this.label5.TabIndex = 51;
            this.label5.Text = "Total Barrotes:";
            // 
            // TiempoParadaTXT
            // 
            this.TiempoParadaTXT.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TiempoParadaTXT.ForeColor = System.Drawing.Color.Red;
            this.TiempoParadaTXT.Location = new System.Drawing.Point(506, 46);
            this.TiempoParadaTXT.Name = "TiempoParadaTXT";
            this.TiempoParadaTXT.ReadOnly = true;
            this.TiempoParadaTXT.Size = new System.Drawing.Size(100, 22);
            this.TiempoParadaTXT.TabIndex = 63;
            this.TiempoParadaTXT.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label11
            // 
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(354, 46);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(145, 30);
            this.label11.TabIndex = 62;
            this.label11.Text = "Tiempo de parada:";
            // 
            // ReporteProduccion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Navy;
            this.CancelButton = this.Cancelar;
            this.ClientSize = new System.Drawing.Size(862, 562);
            this.ControlBox = false;
            this.Controls.Add(this.splitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ReporteProduccion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reporte de Producción";
            this.Load += new System.EventHandler(this.ReporteProduccion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Cuadro)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            this.splitContainer3.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Cuadro2)).EndInit();
            this.ResumeLayout(false);

        }
        private System.Windows.Forms.Button Cancelar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button Buscar;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn codigoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn descripcionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn pesoNominalDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn toleranciaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn multiploDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn rutaImagenDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn aleacionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn templeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn clasificacionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn topologiaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn13;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn14;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn15;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn16;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn17;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn18;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn19;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn20;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn21;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn22;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn23;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn24;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn25;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn26;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn27;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn28;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn29;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn30;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn31;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn32;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn33;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn34;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn35;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn36;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn37;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn38;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn39;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn40;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn41;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn42;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn43;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn44;
        private System.Windows.Forms.DataGridViewTextBoxColumn precioDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn45;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn46;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn47;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn48;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn49;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn50;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn51;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn52;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn53;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn54;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn55;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn56;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn57;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn58;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn59;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn60;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn61;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn62;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn63;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn64;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn65;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn66;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn67;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn68;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn69;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn70;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn71;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn72;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn73;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn74;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn75;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn76;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn77;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn78;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn79;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn80;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn81;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn82;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn83;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn84;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn85;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn86;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn87;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn88;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn89;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn90;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn91;
        private System.Windows.Forms.DataGridViewTextBoxColumn clienteDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn92;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn93;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn94;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn95;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn96;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn97;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn98;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn99;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn100;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn101;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn102;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn103;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn104;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn105;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn106;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn107;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn108;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn109;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn110;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn111;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn112;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn113;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn114;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn115;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn116;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn117;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn118;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn119;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn120;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn121;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn122;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn123;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn124;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn125;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn126;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn127;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn128;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn129;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn130;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn131;
        private System.Windows.Forms.Button Exportarboton;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn132;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn133;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn134;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn135;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn136;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn137;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn138;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn139;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn140;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn141;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn142;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn143;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn144;
        private System.Windows.Forms.DateTimePicker Fecha1DTP;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView Cuadro;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn145;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn numeroDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn146;
        private System.Windows.Forms.DataGridViewTextBoxColumn articuloDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cantidadDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn unidadDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn largoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn kgEstimadosDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn147;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn148;
        private System.Windows.Forms.DataGridViewTextBoxColumn terminacionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn prioridadDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn detalleDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn estadoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn observacionesDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ordenCompraDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn149;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn150;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn151;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn152;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn153;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn154;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn155;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn156;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn157;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn158;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn159;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn160;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn161;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn162;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn163;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn164;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn165;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn166;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn167;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn168;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn169;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn170;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn171;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn172;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn173;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn174;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn175;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn176;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn177;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn178;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn179;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn180;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn181;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn182;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn183;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn184;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn185;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn186;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn187;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn188;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn189;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn190;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn191;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn192;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn193;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn194;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn195;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn196;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn197;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn198;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn199;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox Acumulados;
        private System.Windows.Forms.DateTimePicker Fecha2DTP;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.DataGridView Cuadro2;
        private System.Windows.Forms.DataGridViewCheckBoxColumn imprime;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn Kgs;
        private System.Windows.Forms.DataGridViewTextBoxColumn OP;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn201;
        private System.Windows.Forms.DataGridViewTextBoxColumn Articulo;
        private System.Windows.Forms.DataGridViewTextBoxColumn KgsPresa;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn200;
        private System.Windows.Forms.DataGridViewTextBoxColumn rendi;
        private System.Windows.Forms.DataGridViewButtonColumn dataGridViewButtonColumn1;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox kgHoraTXT;
        private System.Windows.Forms.TextBox tochoHoraTXT;
        private System.Windows.Forms.TextBox kgDespachoTXT;
        private System.Windows.Forms.TextBox kgPrensaTXT;
        private System.Windows.Forms.TextBox totalBarrotesTXT;
        private System.Windows.Forms.TextBox TiempoTXT;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox TiempoParadaTXT;
        private System.Windows.Forms.Label label11;
    }
}