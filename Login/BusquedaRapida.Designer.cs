
namespace Login
{
    partial class BusquedaRapida
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
            this.Campo2Chek = new System.Windows.Forms.CheckBox();
            this.Buscar = new System.Windows.Forms.Button();
            this.BusquedaTBX = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.CancelarBTN = new System.Windows.Forms.Button();
            this.Aceptar = new System.Windows.Forms.Button();
            this.Cuadro = new System.Windows.Forms.DataGridView();
            this.check = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Campo3Chek = new System.Windows.Forms.CheckBox();
            this.Campo1Chek = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
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
            this.splitContainer1.Panel1.Controls.Add(this.Campo3Chek);
            this.splitContainer1.Panel1.Controls.Add(this.Campo1Chek);
            this.splitContainer1.Panel1.Controls.Add(this.Campo2Chek);
            this.splitContainer1.Panel1.Controls.Add(this.Buscar);
            this.splitContainer1.Panel1.Controls.Add(this.BusquedaTBX);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.CancelarBTN);
            this.splitContainer1.Panel1.Controls.Add(this.Aceptar);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.Cuadro);
            this.splitContainer1.Size = new System.Drawing.Size(444, 441);
            this.splitContainer1.SplitterDistance = 90;
            this.splitContainer1.TabIndex = 12;
            // 
            // Campo2Chek
            // 
            this.Campo2Chek.AutoCheck = false;
            this.Campo2Chek.AutoSize = true;
            this.Campo2Chek.Checked = true;
            this.Campo2Chek.CheckState = System.Windows.Forms.CheckState.Checked;
            this.Campo2Chek.Location = new System.Drawing.Point(84, 64);
            this.Campo2Chek.Name = "Campo2Chek";
            this.Campo2Chek.Size = new System.Drawing.Size(67, 17);
            this.Campo2Chek.TabIndex = 9;
            this.Campo2Chek.Text = "campo 2";
            this.Campo2Chek.UseVisualStyleBackColor = true;
            // 
            // Buscar
            // 
            this.Buscar.Location = new System.Drawing.Point(234, 14);
            this.Buscar.Name = "Buscar";
            this.Buscar.Size = new System.Drawing.Size(75, 23);
            this.Buscar.TabIndex = 3;
            this.Buscar.Text = "Buscar";
            this.Buscar.UseVisualStyleBackColor = true;
            this.Buscar.Click += new System.EventHandler(this.Buscar_Click);
            // 
            // BusquedaTBX
            // 
            this.BusquedaTBX.BackColor = System.Drawing.SystemColors.Window;
            this.BusquedaTBX.Location = new System.Drawing.Point(84, 16);
            this.BusquedaTBX.Name = "BusquedaTBX";
            this.BusquedaTBX.Size = new System.Drawing.Size(144, 20);
            this.BusquedaTBX.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label2.Location = new System.Drawing.Point(10, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Busqueda:";
            // 
            // CancelarBTN
            // 
            this.CancelarBTN.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelarBTN.Location = new System.Drawing.Point(352, 43);
            this.CancelarBTN.Name = "CancelarBTN";
            this.CancelarBTN.Size = new System.Drawing.Size(75, 23);
            this.CancelarBTN.TabIndex = 5;
            this.CancelarBTN.Text = "Cancelar";
            this.CancelarBTN.UseVisualStyleBackColor = true;
            this.CancelarBTN.Click += new System.EventHandler(this.button2_Click);
            // 
            // Aceptar
            // 
            this.Aceptar.Location = new System.Drawing.Point(352, 14);
            this.Aceptar.Name = "Aceptar";
            this.Aceptar.Size = new System.Drawing.Size(75, 23);
            this.Aceptar.TabIndex = 4;
            this.Aceptar.Text = "Aceptar";
            this.Aceptar.UseVisualStyleBackColor = true;
            this.Aceptar.Click += new System.EventHandler(this.Agregar_Click);
            // 
            // Cuadro
            // 
            this.Cuadro.AllowUserToAddRows = false;
            this.Cuadro.AllowUserToDeleteRows = false;
            this.Cuadro.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Cuadro.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.check,
            this.ID,
            this.numero,
            this.Descripcion});
            this.Cuadro.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Cuadro.Location = new System.Drawing.Point(0, 0);
            this.Cuadro.Name = "Cuadro";
            this.Cuadro.ReadOnly = true;
            this.Cuadro.RowHeadersVisible = false;
            this.Cuadro.Size = new System.Drawing.Size(444, 347);
            this.Cuadro.TabIndex = 6;
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
            // numero
            // 
            this.numero.HeaderText = "Numero";
            this.numero.Name = "numero";
            this.numero.ReadOnly = true;
            this.numero.Width = 60;
            // 
            // Descripcion
            // 
            this.Descripcion.HeaderText = "Descripción";
            this.Descripcion.Name = "Descripcion";
            this.Descripcion.ReadOnly = true;
            this.Descripcion.Width = 350;
            // 
            // Campo3Chek
            // 
            this.Campo3Chek.AutoCheck = false;
            this.Campo3Chek.AutoSize = true;
            this.Campo3Chek.Checked = true;
            this.Campo3Chek.CheckState = System.Windows.Forms.CheckState.Checked;
            this.Campo3Chek.Location = new System.Drawing.Point(206, 43);
            this.Campo3Chek.Name = "Campo3Chek";
            this.Campo3Chek.Size = new System.Drawing.Size(67, 17);
            this.Campo3Chek.TabIndex = 11;
            this.Campo3Chek.Text = "campo 3";
            this.Campo3Chek.UseVisualStyleBackColor = true;
            this.Campo3Chek.Visible = false;
            // 
            // Campo1Chek
            // 
            this.Campo1Chek.AutoCheck = false;
            this.Campo1Chek.AutoSize = true;
            this.Campo1Chek.Checked = true;
            this.Campo1Chek.CheckState = System.Windows.Forms.CheckState.Checked;
            this.Campo1Chek.Location = new System.Drawing.Point(84, 43);
            this.Campo1Chek.Name = "Campo1Chek";
            this.Campo1Chek.Size = new System.Drawing.Size(67, 17);
            this.Campo1Chek.TabIndex = 10;
            this.Campo1Chek.Text = "campo 2";
            this.Campo1Chek.UseVisualStyleBackColor = true;
            // 
            // BusquedaRapida
            // 
            this.AcceptButton = this.Aceptar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.CancelarBTN;
            this.ClientSize = new System.Drawing.Size(444, 441);
            this.ControlBox = false;
            this.Controls.Add(this.splitContainer1);
            this.Name = "BusquedaRapida";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Busqueda Rápida";
            this.Load += new System.EventHandler(this.BusquedaRapida_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Cuadro)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView Cuadro;
        private System.Windows.Forms.Button Buscar;
        private System.Windows.Forms.TextBox BusquedaTBX;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button CancelarBTN;
        private System.Windows.Forms.Button Aceptar;
        private System.Windows.Forms.DataGridViewCheckBoxColumn check;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn numero;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descripcion;
        private System.Windows.Forms.CheckBox Campo2Chek;
        private System.Windows.Forms.CheckBox Campo3Chek;
        private System.Windows.Forms.CheckBox Campo1Chek;
    }
}