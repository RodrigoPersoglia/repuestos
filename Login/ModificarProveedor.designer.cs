namespace Login
{
	partial class ModificarProveedor
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox Alias_Txt;
		private System.Windows.Forms.TextBox DirFisc_Txt;
		private System.Windows.Forms.TextBox DirEntrega_txt;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.TextBox RazonSocial_Txt;
		private System.Windows.Forms.ComboBox IVA_Cbx;
		private System.Windows.Forms.Button Modificar;
		private System.Windows.Forms.Button Cancelar;
		private System.Windows.Forms.Label label1;
		
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ModificarProveedor));
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.Alias_Txt = new System.Windows.Forms.TextBox();
            this.DirFisc_Txt = new System.Windows.Forms.TextBox();
            this.DirEntrega_txt = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.RazonSocial_Txt = new System.Windows.Forms.TextBox();
            this.IVA_Cbx = new System.Windows.Forms.ComboBox();
            this.Modificar = new System.Windows.Forms.Button();
            this.Cancelar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.TipoDoc_Cbx = new System.Windows.Forms.ComboBox();
            this.NumDoc = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.Tel1_tex = new System.Windows.Forms.TextBox();
            this.Tel2_text = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.ProvEnt_Cbx = new System.Windows.Forms.ComboBox();
            this.LocEnt_Cbx = new System.Windows.Forms.ComboBox();
            this.LocFis_Cbx = new System.Windows.Forms.ComboBox();
            this.ProvFisc_Cbx = new System.Windows.Forms.ComboBox();
            this.CPFisc = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.CPEnt = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.BuscarBoton = new System.Windows.Forms.Button();
            this.NumCli = new System.Windows.Forms.TextBox();
            this.CheckDireccion = new System.Windows.Forms.CheckBox();
            this.EditarBTN = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.NumDoc)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(22, 95);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(129, 23);
            this.label2.TabIndex = 1;
            this.label2.Text = "PROVEEDOR";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(5, 160);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(146, 23);
            this.label3.TabIndex = 2;
            this.label3.Text = "DIRECCION FISCAL";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(22, 263);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(129, 23);
            this.label4.TabIndex = 3;
            this.label4.Text = "DIR.ENTREGA";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(22, 403);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(129, 23);
            this.label5.TabIndex = 4;
            this.label5.Text = "TIPO/DOC";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // Alias_Txt
            // 
            this.Alias_Txt.Location = new System.Drawing.Point(157, 124);
            this.Alias_Txt.Name = "Alias_Txt";
            this.Alias_Txt.Size = new System.Drawing.Size(262, 19);
            this.Alias_Txt.TabIndex = 3;
            // 
            // DirFisc_Txt
            // 
            this.DirFisc_Txt.Location = new System.Drawing.Point(157, 163);
            this.DirFisc_Txt.Name = "DirFisc_Txt";
            this.DirFisc_Txt.Size = new System.Drawing.Size(262, 19);
            this.DirFisc_Txt.TabIndex = 4;
            // 
            // DirEntrega_txt
            // 
            this.DirEntrega_txt.Location = new System.Drawing.Point(157, 263);
            this.DirEntrega_txt.Name = "DirEntrega_txt";
            this.DirEntrega_txt.Size = new System.Drawing.Size(262, 19);
            this.DirEntrega_txt.TabIndex = 8;
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(22, 119);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(129, 23);
            this.label8.TabIndex = 13;
            this.label8.Text = "ALIAS";
            this.label8.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // RazonSocial_Txt
            // 
            this.RazonSocial_Txt.Location = new System.Drawing.Point(157, 99);
            this.RazonSocial_Txt.Name = "RazonSocial_Txt";
            this.RazonSocial_Txt.Size = new System.Drawing.Size(262, 19);
            this.RazonSocial_Txt.TabIndex = 2;
            // 
            // IVA_Cbx
            // 
            this.IVA_Cbx.FormattingEnabled = true;
            this.IVA_Cbx.Location = new System.Drawing.Point(157, 432);
            this.IVA_Cbx.Name = "IVA_Cbx";
            this.IVA_Cbx.Size = new System.Drawing.Size(204, 21);
            this.IVA_Cbx.TabIndex = 16;
            // 
            // Modificar
            // 
            this.Modificar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Modificar.Location = new System.Drawing.Point(157, 484);
            this.Modificar.Name = "Modificar";
            this.Modificar.Size = new System.Drawing.Size(90, 27);
            this.Modificar.TabIndex = 17;
            this.Modificar.Text = "Modificar";
            this.Modificar.UseVisualStyleBackColor = true;
            this.Modificar.Click += new System.EventHandler(this.Crear_Click);
            // 
            // Cancelar
            // 
            this.Cancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Cancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cancelar.Location = new System.Drawing.Point(271, 484);
            this.Cancelar.Name = "Cancelar";
            this.Cancelar.Size = new System.Drawing.Size(90, 27);
            this.Cancelar.TabIndex = 18;
            this.Cancelar.Text = "Salir";
            this.Cancelar.UseVisualStyleBackColor = true;
            this.Cancelar.Click += new System.EventHandler(this.CancelarClick);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(17, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(307, 23);
            this.label1.TabIndex = 13;
            this.label1.Text = "MODIFICAR PROVEEDOR";
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(22, 355);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(129, 23);
            this.label6.TabIndex = 5;
            this.label6.Text = "TELEFONO";
            this.label6.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // TipoDoc_Cbx
            // 
            this.TipoDoc_Cbx.FormattingEnabled = true;
            this.TipoDoc_Cbx.Location = new System.Drawing.Point(157, 405);
            this.TipoDoc_Cbx.Name = "TipoDoc_Cbx";
            this.TipoDoc_Cbx.Size = new System.Drawing.Size(78, 21);
            this.TipoDoc_Cbx.TabIndex = 14;
            // 
            // NumDoc
            // 
            this.NumDoc.Location = new System.Drawing.Point(241, 405);
            this.NumDoc.Maximum = new decimal(new int[] {
            1215752191,
            23,
            0,
            0});
            this.NumDoc.Name = "NumDoc";
            this.NumDoc.Size = new System.Drawing.Size(120, 19);
            this.NumDoc.TabIndex = 15;
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(22, 75);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(129, 23);
            this.label9.TabIndex = 101;
            this.label9.Text = "NUMERO";
            this.label9.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(22, 380);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(129, 23);
            this.label7.TabIndex = 103;
            this.label7.Text = "TELEFONO 2";
            this.label7.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // Tel1_tex
            // 
            this.Tel1_tex.Location = new System.Drawing.Point(157, 355);
            this.Tel1_tex.Name = "Tel1_tex";
            this.Tel1_tex.Size = new System.Drawing.Size(262, 19);
            this.Tel1_tex.TabIndex = 12;
            // 
            // Tel2_text
            // 
            this.Tel2_text.Location = new System.Drawing.Point(157, 380);
            this.Tel2_text.Name = "Tel2_text";
            this.Tel2_text.Size = new System.Drawing.Size(262, 19);
            this.Tel2_text.TabIndex = 13;
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(22, 432);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(129, 23);
            this.label10.TabIndex = 106;
            this.label10.Text = "IVA";
            this.label10.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // ProvEnt_Cbx
            // 
            this.ProvEnt_Cbx.FormattingEnabled = true;
            this.ProvEnt_Cbx.Location = new System.Drawing.Point(157, 288);
            this.ProvEnt_Cbx.Name = "ProvEnt_Cbx";
            this.ProvEnt_Cbx.Size = new System.Drawing.Size(126, 21);
            this.ProvEnt_Cbx.TabIndex = 9;
            this.ProvEnt_Cbx.SelectionChangeCommitted += new System.EventHandler(this.ProvEnt_Cbx_SelectionChangeCommitted);
            // 
            // LocEnt_Cbx
            // 
            this.LocEnt_Cbx.FormattingEnabled = true;
            this.LocEnt_Cbx.Location = new System.Drawing.Point(289, 288);
            this.LocEnt_Cbx.Name = "LocEnt_Cbx";
            this.LocEnt_Cbx.Size = new System.Drawing.Size(130, 21);
            this.LocEnt_Cbx.TabIndex = 10;
            // 
            // LocFis_Cbx
            // 
            this.LocFis_Cbx.FormattingEnabled = true;
            this.LocFis_Cbx.Location = new System.Drawing.Point(289, 188);
            this.LocFis_Cbx.Name = "LocFis_Cbx";
            this.LocFis_Cbx.Size = new System.Drawing.Size(130, 21);
            this.LocFis_Cbx.TabIndex = 6;
            // 
            // ProvFisc_Cbx
            // 
            this.ProvFisc_Cbx.FormattingEnabled = true;
            this.ProvFisc_Cbx.Location = new System.Drawing.Point(157, 188);
            this.ProvFisc_Cbx.Name = "ProvFisc_Cbx";
            this.ProvFisc_Cbx.Size = new System.Drawing.Size(126, 21);
            this.ProvFisc_Cbx.TabIndex = 5;
            this.ProvFisc_Cbx.SelectedIndexChanged += new System.EventHandler(this.ProvFisc_Cbx_SelectedIndexChanged);
            this.ProvFisc_Cbx.SelectionChangeCommitted += new System.EventHandler(this.ProvFisc_Cbx_SelectionChangeCommitted);
            // 
            // CPFisc
            // 
            this.CPFisc.Location = new System.Drawing.Point(157, 215);
            this.CPFisc.Name = "CPFisc";
            this.CPFisc.Size = new System.Drawing.Size(126, 19);
            this.CPFisc.TabIndex = 7;
            // 
            // label11
            // 
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(5, 211);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(146, 23);
            this.label11.TabIndex = 112;
            this.label11.Text = "cod. Postal";
            this.label11.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label12
            // 
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(5, 189);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(146, 23);
            this.label12.TabIndex = 113;
            this.label12.Text = "Prov/Loc.";
            this.label12.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label13
            // 
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.White;
            this.label13.Location = new System.Drawing.Point(5, 311);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(146, 23);
            this.label13.TabIndex = 115;
            this.label13.Text = "cod. Postal";
            this.label13.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // CPEnt
            // 
            this.CPEnt.Location = new System.Drawing.Point(157, 315);
            this.CPEnt.Name = "CPEnt";
            this.CPEnt.Size = new System.Drawing.Size(126, 19);
            this.CPEnt.TabIndex = 11;
            // 
            // label14
            // 
            this.label14.BackColor = System.Drawing.Color.Transparent;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.White;
            this.label14.Location = new System.Drawing.Point(5, 286);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(146, 23);
            this.label14.TabIndex = 116;
            this.label14.Text = "Prov/Loc.";
            this.label14.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // BuscarBoton
            // 
            this.BuscarBoton.Location = new System.Drawing.Point(426, 95);
            this.BuscarBoton.Margin = new System.Windows.Forms.Padding(4);
            this.BuscarBoton.Name = "BuscarBoton";
            this.BuscarBoton.Size = new System.Drawing.Size(75, 23);
            this.BuscarBoton.TabIndex = 117;
            this.BuscarBoton.Text = "Buscar";
            this.BuscarBoton.UseVisualStyleBackColor = true;
            this.BuscarBoton.Click += new System.EventHandler(this.BuscarBoton_Click);
            // 
            // NumCli
            // 
            this.NumCli.Location = new System.Drawing.Point(157, 75);
            this.NumCli.Name = "NumCli";
            this.NumCli.ReadOnly = true;
            this.NumCli.Size = new System.Drawing.Size(90, 19);
            this.NumCli.TabIndex = 118;
            // 
            // CheckDireccion
            // 
            this.CheckDireccion.AutoSize = true;
            this.CheckDireccion.BackColor = System.Drawing.Color.Transparent;
            this.CheckDireccion.ForeColor = System.Drawing.Color.White;
            this.CheckDireccion.Location = new System.Drawing.Point(157, 240);
            this.CheckDireccion.Name = "CheckDireccion";
            this.CheckDireccion.Size = new System.Drawing.Size(210, 17);
            this.CheckDireccion.TabIndex = 7;
            this.CheckDireccion.Text = "Dirección comercial y fiscal son iguales";
            this.CheckDireccion.UseVisualStyleBackColor = false;
            this.CheckDireccion.CheckedChanged += new System.EventHandler(this.CheckDireccion_CheckedChanged);
            // 
            // EditarBTN
            // 
            this.EditarBTN.Location = new System.Drawing.Point(426, 186);
            this.EditarBTN.Name = "EditarBTN";
            this.EditarBTN.Size = new System.Drawing.Size(75, 23);
            this.EditarBTN.TabIndex = 119;
            this.EditarBTN.Text = "Editar";
            this.EditarBTN.UseVisualStyleBackColor = true;
            this.EditarBTN.Click += new System.EventHandler(this.EditarBTN_Click);
            // 
            // ModificarProveedor
            // 
            this.AcceptButton = this.Modificar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.CancelButton = this.Cancelar;
            this.ClientSize = new System.Drawing.Size(562, 523);
            this.ControlBox = false;
            this.Controls.Add(this.EditarBTN);
            this.Controls.Add(this.CheckDireccion);
            this.Controls.Add(this.NumCli);
            this.Controls.Add(this.BuscarBoton);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.CPEnt);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.CPFisc);
            this.Controls.Add(this.LocFis_Cbx);
            this.Controls.Add(this.ProvFisc_Cbx);
            this.Controls.Add(this.LocEnt_Cbx);
            this.Controls.Add(this.ProvEnt_Cbx);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.Tel2_text);
            this.Controls.Add(this.Tel1_tex);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.NumDoc);
            this.Controls.Add(this.TipoDoc_Cbx);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Cancelar);
            this.Controls.Add(this.Modificar);
            this.Controls.Add(this.IVA_Cbx);
            this.Controls.Add(this.RazonSocial_Txt);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.DirEntrega_txt);
            this.Controls.Add(this.DirFisc_Txt);
            this.Controls.Add(this.Alias_Txt);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ModificarProveedor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Modificar Proveedor";
            this.Load += new System.EventHandler(this.ModificarCliente_Load);
            ((System.ComponentModel.ISupportInitialize)(this.NumDoc)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		private System.Windows.Forms.NumericUpDown NumDoc;
		private System.Windows.Forms.ComboBox TipoDoc_Cbx;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox Tel1_tex;
        private System.Windows.Forms.TextBox Tel2_text;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox ProvEnt_Cbx;
        private System.Windows.Forms.ComboBox LocEnt_Cbx;
        private System.Windows.Forms.ComboBox LocFis_Cbx;
        private System.Windows.Forms.ComboBox ProvFisc_Cbx;
        private System.Windows.Forms.TextBox CPFisc;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox CPEnt;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button BuscarBoton;
        private System.Windows.Forms.TextBox NumCli;
        private System.Windows.Forms.CheckBox CheckDireccion;
        private System.Windows.Forms.Button EditarBTN;
    }
}
