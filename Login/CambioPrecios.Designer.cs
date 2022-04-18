
namespace Login
{
	partial class CambioPrecios
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.NumericUpDown ModificacionNUM;
		private System.Windows.Forms.Button AnularBoton;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CambioPrecios));
            this.label6 = new System.Windows.Forms.Label();
            this.ModificacionNUM = new System.Windows.Forms.NumericUpDown();
            this.AnularBoton = new System.Windows.Forms.Button();
            this.Cancelar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.UsuarioCBX = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.ProveedorCBX = new System.Windows.Forms.ComboBox();
            this.RubroCBX = new System.Windows.Forms.ComboBox();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.Aumento = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.ModificacionNUM)).BeginInit();
            this.SuspendLayout();
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(32, 225);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(139, 28);
            this.label6.TabIndex = 5;
            this.label6.Text = "Importe o Porcentaje";
            this.label6.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // ModificacionNUM
            // 
            this.ModificacionNUM.DecimalPlaces = 3;
            this.ModificacionNUM.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.ModificacionNUM.Location = new System.Drawing.Point(179, 226);
            this.ModificacionNUM.Margin = new System.Windows.Forms.Padding(4);
            this.ModificacionNUM.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.ModificacionNUM.Name = "ModificacionNUM";
            this.ModificacionNUM.Size = new System.Drawing.Size(105, 19);
            this.ModificacionNUM.TabIndex = 3;
            // 
            // AnularBoton
            // 
            this.AnularBoton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AnularBoton.Location = new System.Drawing.Point(121, 294);
            this.AnularBoton.Margin = new System.Windows.Forms.Padding(4);
            this.AnularBoton.Name = "AnularBoton";
            this.AnularBoton.Size = new System.Drawing.Size(85, 33);
            this.AnularBoton.TabIndex = 12;
            this.AnularBoton.Text = "Modificar";
            this.AnularBoton.UseVisualStyleBackColor = true;
            this.AnularBoton.Click += new System.EventHandler(this.CrearClick);
            // 
            // Cancelar
            // 
            this.Cancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Cancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cancelar.Location = new System.Drawing.Point(214, 294);
            this.Cancelar.Margin = new System.Windows.Forms.Padding(4);
            this.Cancelar.Name = "Cancelar";
            this.Cancelar.Size = new System.Drawing.Size(91, 33);
            this.Cancelar.TabIndex = 13;
            this.Cancelar.Text = "Cancelar";
            this.Cancelar.UseVisualStyleBackColor = true;
            this.Cancelar.Click += new System.EventHandler(this.CancelarClick);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(2, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(297, 28);
            this.label1.TabIndex = 13;
            this.label1.Text = "MODIFICACIÓN DE PRECIOS";
            // 
            // label15
            // 
            this.label15.BackColor = System.Drawing.Color.Transparent;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.White;
            this.label15.Location = new System.Drawing.Point(211, 43);
            this.label15.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(76, 18);
            this.label15.TabIndex = 113;
            this.label15.Text = "Usuario:";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // UsuarioCBX
            // 
            this.UsuarioCBX.ForeColor = System.Drawing.Color.Red;
            this.UsuarioCBX.FormattingEnabled = true;
            this.UsuarioCBX.Location = new System.Drawing.Point(292, 40);
            this.UsuarioCBX.Name = "UsuarioCBX";
            this.UsuarioCBX.Size = new System.Drawing.Size(135, 21);
            this.UsuarioCBX.TabIndex = 112;
            // 
            // label11
            // 
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(33, 122);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(129, 23);
            this.label11.TabIndex = 117;
            this.label11.Text = "PROVEEDOR";
            this.label11.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(33, 152);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(129, 23);
            this.label4.TabIndex = 116;
            this.label4.Text = "RUBRO";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // ProveedorCBX
            // 
            this.ProveedorCBX.FormattingEnabled = true;
            this.ProveedorCBX.Location = new System.Drawing.Point(179, 122);
            this.ProveedorCBX.Name = "ProveedorCBX";
            this.ProveedorCBX.Size = new System.Drawing.Size(200, 21);
            this.ProveedorCBX.TabIndex = 114;
            // 
            // RubroCBX
            // 
            this.RubroCBX.FormattingEnabled = true;
            this.RubroCBX.Location = new System.Drawing.Point(179, 152);
            this.RubroCBX.Name = "RubroCBX";
            this.RubroCBX.Size = new System.Drawing.Size(200, 21);
            this.RubroCBX.TabIndex = 115;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.ForeColor = System.Drawing.Color.White;
            this.radioButton1.Location = new System.Drawing.Point(179, 202);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(77, 17);
            this.radioButton1.TabIndex = 118;
            this.radioButton1.Text = "Descuento";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // Aumento
            // 
            this.Aumento.AutoSize = true;
            this.Aumento.Checked = true;
            this.Aumento.ForeColor = System.Drawing.SystemColors.Control;
            this.Aumento.Location = new System.Drawing.Point(179, 179);
            this.Aumento.Name = "Aumento";
            this.Aumento.Size = new System.Drawing.Size(67, 17);
            this.Aumento.TabIndex = 119;
            this.Aumento.TabStop = true;
            this.Aumento.Text = "Aumento";
            this.Aumento.UseVisualStyleBackColor = true;
            // 
            // CambioPrecios
            // 
            this.AcceptButton = this.AnularBoton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.CancelButton = this.Cancelar;
            this.ClientSize = new System.Drawing.Size(439, 351);
            this.ControlBox = false;
            this.Controls.Add(this.Aumento);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.ProveedorCBX);
            this.Controls.Add(this.RubroCBX);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.UsuarioCBX);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Cancelar);
            this.Controls.Add(this.AnularBoton);
            this.Controls.Add(this.ModificacionNUM);
            this.Controls.Add(this.label6);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "CambioPrecios";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Modificar Precios";
            this.Load += new System.EventHandler(this.CambioPreciosLoad);
            ((System.ComponentModel.ISupportInitialize)(this.ModificacionNUM)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ComboBox UsuarioCBX;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox ProveedorCBX;
        private System.Windows.Forms.ComboBox RubroCBX;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton Aumento;
    }
}
