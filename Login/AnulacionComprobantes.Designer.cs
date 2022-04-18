
namespace Login
{
	partial class AnulacionComprobantes
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox ClienteTXT;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.NumericUpDown ImporteNUM;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AnulacionComprobantes));
            this.label2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.ClienteTXT = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.ImporteNUM = new System.Windows.Forms.NumericUpDown();
            this.AnularBoton = new System.Windows.Forms.Button();
            this.Cancelar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.NumCompNumeric = new System.Windows.Forms.NumericUpDown();
            this.BuscarBoton = new System.Windows.Forms.Button();
            this.label15 = new System.Windows.Forms.Label();
            this.UsuarioCBX = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.ImporteNUM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumCompNumeric)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(21, 110);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(141, 28);
            this.label2.TabIndex = 1;
            this.label2.Text = "Nº  de comprobante:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(84, 169);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(78, 28);
            this.label6.TabIndex = 5;
            this.label6.Text = "IMPORTE:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // ClienteTXT
            // 
            this.ClienteTXT.Location = new System.Drawing.Point(161, 141);
            this.ClienteTXT.Margin = new System.Windows.Forms.Padding(4);
            this.ClienteTXT.MaxLength = 60;
            this.ClienteTXT.Name = "ClienteTXT";
            this.ClienteTXT.ReadOnly = true;
            this.ClienteTXT.Size = new System.Drawing.Size(176, 19);
            this.ClienteTXT.TabIndex = 2;
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(92, 141);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(70, 28);
            this.label8.TabIndex = 13;
            this.label8.Text = "CLIENTE:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // ImporteNUM
            // 
            this.ImporteNUM.DecimalPlaces = 3;
            this.ImporteNUM.Location = new System.Drawing.Point(161, 169);
            this.ImporteNUM.Margin = new System.Windows.Forms.Padding(4);
            this.ImporteNUM.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.ImporteNUM.Name = "ImporteNUM";
            this.ImporteNUM.ReadOnly = true;
            this.ImporteNUM.Size = new System.Drawing.Size(105, 19);
            this.ImporteNUM.TabIndex = 3;
            // 
            // AnularBoton
            // 
            this.AnularBoton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AnularBoton.Location = new System.Drawing.Point(153, 241);
            this.AnularBoton.Margin = new System.Windows.Forms.Padding(4);
            this.AnularBoton.Name = "AnularBoton";
            this.AnularBoton.Size = new System.Drawing.Size(85, 33);
            this.AnularBoton.TabIndex = 12;
            this.AnularBoton.Text = "Anular";
            this.AnularBoton.UseVisualStyleBackColor = true;
            this.AnularBoton.Click += new System.EventHandler(this.CrearClick);
            // 
            // Cancelar
            // 
            this.Cancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Cancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cancelar.Location = new System.Drawing.Point(246, 241);
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
            this.label1.Size = new System.Drawing.Size(409, 28);
            this.label1.TabIndex = 13;
            this.label1.Text = "ANULACIÓN DE COMPROBANTES";
            // 
            // NumCompNumeric
            // 
            this.NumCompNumeric.Location = new System.Drawing.Point(161, 111);
            this.NumCompNumeric.Margin = new System.Windows.Forms.Padding(4);
            this.NumCompNumeric.Maximum = new decimal(new int[] {
            6000,
            0,
            0,
            0});
            this.NumCompNumeric.Name = "NumCompNumeric";
            this.NumCompNumeric.Size = new System.Drawing.Size(105, 19);
            this.NumCompNumeric.TabIndex = 5;
            this.NumCompNumeric.ValueChanged += new System.EventHandler(this.NumCompNumeric_ValueChanged);
            // 
            // BuscarBoton
            // 
            this.BuscarBoton.Location = new System.Drawing.Point(274, 111);
            this.BuscarBoton.Margin = new System.Windows.Forms.Padding(4);
            this.BuscarBoton.Name = "BuscarBoton";
            this.BuscarBoton.Size = new System.Drawing.Size(63, 20);
            this.BuscarBoton.TabIndex = 33;
            this.BuscarBoton.Text = "Buscar";
            this.BuscarBoton.UseVisualStyleBackColor = true;
            this.BuscarBoton.Click += new System.EventHandler(this.BuscarBoton_Click);
            // 
            // label15
            // 
            this.label15.BackColor = System.Drawing.Color.Transparent;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.White;
            this.label15.Location = new System.Drawing.Point(121, 43);
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
            this.UsuarioCBX.Location = new System.Drawing.Point(202, 40);
            this.UsuarioCBX.Name = "UsuarioCBX";
            this.UsuarioCBX.Size = new System.Drawing.Size(135, 21);
            this.UsuarioCBX.TabIndex = 112;
            // 
            // AnulacionComprobantes
            // 
            this.AcceptButton = this.AnularBoton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.CancelButton = this.Cancelar;
            this.ClientSize = new System.Drawing.Size(358, 301);
            this.ControlBox = false;
            this.Controls.Add(this.label15);
            this.Controls.Add(this.UsuarioCBX);
            this.Controls.Add(this.BuscarBoton);
            this.Controls.Add(this.NumCompNumeric);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Cancelar);
            this.Controls.Add(this.AnularBoton);
            this.Controls.Add(this.ImporteNUM);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.ClienteTXT);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label2);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "AnulacionComprobantes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Anulación de Comprobantes";
            this.Load += new System.EventHandler(this.AnulacionComprobantesLoad);
            ((System.ComponentModel.ISupportInitialize)(this.ImporteNUM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumCompNumeric)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

        private System.Windows.Forms.NumericUpDown NumCompNumeric;
        private System.Windows.Forms.Button BuscarBoton;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ComboBox UsuarioCBX;
    }
}
