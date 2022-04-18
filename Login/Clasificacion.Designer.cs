
namespace Login
{
    partial class Clasificacion
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.PrecioNum = new System.Windows.Forms.NumericUpDown();
            this.EliminarBTN = new System.Windows.Forms.Button();
            this.ModificarBTN = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.descripcionTBX = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.CancelarBTN = new System.Windows.Forms.Button();
            this.Agregar = new System.Windows.Forms.Button();
            this.Cuadro = new System.Windows.Forms.DataGridView();
            this.check = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PrecioNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Cuadro)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.splitContainer1.Panel1.Controls.Add(this.PrecioNum);
            this.splitContainer1.Panel1.Controls.Add(this.EliminarBTN);
            this.splitContainer1.Panel1.Controls.Add(this.ModificarBTN);
            this.splitContainer1.Panel1.Controls.Add(this.label4);
            this.splitContainer1.Panel1.Controls.Add(this.descripcionTBX);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.CancelarBTN);
            this.splitContainer1.Panel1.Controls.Add(this.Agregar);
            this.splitContainer1.Panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer1_Panel1_Paint);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.Cuadro);
            this.splitContainer1.Panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer1_Panel2_Paint);
            this.splitContainer1.Size = new System.Drawing.Size(284, 441);
            this.splitContainer1.SplitterDistance = 129;
            this.splitContainer1.TabIndex = 12;
            // 
            // PrecioNum
            // 
            this.PrecioNum.DecimalPlaces = 2;
            this.PrecioNum.Location = new System.Drawing.Point(54, 68);
            this.PrecioNum.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.PrecioNum.Name = "PrecioNum";
            this.PrecioNum.Size = new System.Drawing.Size(120, 20);
            this.PrecioNum.TabIndex = 24;
            this.PrecioNum.Visible = false;
            // 
            // EliminarBTN
            // 
            this.EliminarBTN.Location = new System.Drawing.Point(197, 68);
            this.EliminarBTN.Name = "EliminarBTN";
            this.EliminarBTN.Size = new System.Drawing.Size(75, 23);
            this.EliminarBTN.TabIndex = 7;
            this.EliminarBTN.Text = "Eliminar";
            this.EliminarBTN.UseVisualStyleBackColor = true;
            this.EliminarBTN.Click += new System.EventHandler(this.EliminarBTN_Click);
            // 
            // ModificarBTN
            // 
            this.ModificarBTN.Location = new System.Drawing.Point(197, 38);
            this.ModificarBTN.Name = "ModificarBTN";
            this.ModificarBTN.Size = new System.Drawing.Size(75, 23);
            this.ModificarBTN.TabIndex = 6;
            this.ModificarBTN.Text = "Modificar";
            this.ModificarBTN.UseVisualStyleBackColor = true;
            this.ModificarBTN.Click += new System.EventHandler(this.ModificarBTN_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label4.Location = new System.Drawing.Point(8, 68);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 15);
            this.label4.TabIndex = 23;
            this.label4.Text = "Precio:";
            this.label4.Visible = false;
            // 
            // descripcionTBX
            // 
            this.descripcionTBX.BackColor = System.Drawing.SystemColors.Window;
            this.descripcionTBX.Location = new System.Drawing.Point(12, 38);
            this.descripcionTBX.Name = "descripcionTBX";
            this.descripcionTBX.Size = new System.Drawing.Size(168, 20);
            this.descripcionTBX.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label2.Location = new System.Drawing.Point(9, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Descripción:";
            // 
            // CancelarBTN
            // 
            this.CancelarBTN.Location = new System.Drawing.Point(197, 98);
            this.CancelarBTN.Name = "CancelarBTN";
            this.CancelarBTN.Size = new System.Drawing.Size(75, 23);
            this.CancelarBTN.TabIndex = 8;
            this.CancelarBTN.Text = "Cancelar";
            this.CancelarBTN.UseVisualStyleBackColor = true;
            this.CancelarBTN.Click += new System.EventHandler(this.button2_Click);
            // 
            // Agregar
            // 
            this.Agregar.Location = new System.Drawing.Point(197, 8);
            this.Agregar.Name = "Agregar";
            this.Agregar.Size = new System.Drawing.Size(75, 23);
            this.Agregar.TabIndex = 5;
            this.Agregar.Text = "Agregar";
            this.Agregar.UseVisualStyleBackColor = true;
            this.Agregar.Click += new System.EventHandler(this.Agregar_Click);
            // 
            // Cuadro
            // 
            this.Cuadro.AllowUserToAddRows = false;
            this.Cuadro.AllowUserToDeleteRows = false;
            this.Cuadro.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Cuadro.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.check,
            this.ID,
            this.Descripcion,
            this.numero});
            this.Cuadro.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Cuadro.Location = new System.Drawing.Point(0, 0);
            this.Cuadro.Name = "Cuadro";
            this.Cuadro.ReadOnly = true;
            this.Cuadro.RowHeadersVisible = false;
            this.Cuadro.Size = new System.Drawing.Size(284, 308);
            this.Cuadro.TabIndex = 9;
            this.Cuadro.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Cuadro_CellClick);
            // 
            // check
            // 
            this.check.HeaderText = " ";
            this.check.Name = "check";
            this.check.ReadOnly = true;
            this.check.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.check.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.check.Width = 30;
            // 
            // ID
            // 
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Visible = false;
            // 
            // Descripcion
            // 
            this.Descripcion.HeaderText = "Descripción";
            this.Descripcion.Name = "Descripcion";
            this.Descripcion.ReadOnly = true;
            this.Descripcion.Width = 250;
            // 
            // numero
            // 
            this.numero.HeaderText = "Precio";
            this.numero.Name = "numero";
            this.numero.ReadOnly = true;
            this.numero.Visible = false;
            // 
            // Clasificacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(284, 441);
            this.ControlBox = false;
            this.Controls.Add(this.splitContainer1);
            this.Name = "Clasificacion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lado";
            this.Load += new System.EventHandler(this.Clasificacion_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PrecioNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Cuadro)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button CancelarBTN;
        private System.Windows.Forms.Button Agregar;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox descripcionTBX;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button EliminarBTN;
        private System.Windows.Forms.Button ModificarBTN;
        private System.Windows.Forms.DataGridView Cuadro;
        private System.Windows.Forms.NumericUpDown PrecioNum;
        private System.Windows.Forms.DataGridViewCheckBoxColumn check;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn numero;
    }
}