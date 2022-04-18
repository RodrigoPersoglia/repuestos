
namespace Login
{
    partial class EntradasSalidas
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
            this.label15 = new System.Windows.Forms.Label();
            this.UsuarioCBX = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.EntradaRB = new System.Windows.Forms.RadioButton();
            this.SalidaRB = new System.Windows.Forms.RadioButton();
            this.CodigoTXT = new System.Windows.Forms.TextBox();
            this.BuscarBTN = new System.Windows.Forms.Button();
            this.DescripcionTXT = new System.Windows.Forms.TextBox();
            this.CantidadNUM = new System.Windows.Forms.NumericUpDown();
            this.ObservacionesTXT = new System.Windows.Forms.TextBox();
            this.AceptarBTN = new System.Windows.Forms.Button();
            this.CancelarBTN = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.CantidadNUM)).BeginInit();
            this.SuspendLayout();
            // 
            // label15
            // 
            this.label15.BackColor = System.Drawing.Color.Transparent;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.White;
            this.label15.Location = new System.Drawing.Point(113, 53);
            this.label15.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(76, 18);
            this.label15.TabIndex = 116;
            this.label15.Text = "Usuario:";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // UsuarioCBX
            // 
            this.UsuarioCBX.ForeColor = System.Drawing.Color.Red;
            this.UsuarioCBX.FormattingEnabled = true;
            this.UsuarioCBX.Location = new System.Drawing.Point(194, 50);
            this.UsuarioCBX.Name = "UsuarioCBX";
            this.UsuarioCBX.Size = new System.Drawing.Size(135, 21);
            this.UsuarioCBX.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(13, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(297, 28);
            this.label1.TabIndex = 114;
            this.label1.Text = "Entradas y Salidas de artículos";
            // 
            // EntradaRB
            // 
            this.EntradaRB.AutoSize = true;
            this.EntradaRB.Checked = true;
            this.EntradaRB.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EntradaRB.ForeColor = System.Drawing.Color.White;
            this.EntradaRB.Location = new System.Drawing.Point(127, 94);
            this.EntradaRB.Name = "EntradaRB";
            this.EntradaRB.Size = new System.Drawing.Size(68, 19);
            this.EntradaRB.TabIndex = 1;
            this.EntradaRB.TabStop = true;
            this.EntradaRB.Text = "Entrada";
            this.EntradaRB.UseVisualStyleBackColor = true;
            // 
            // SalidaRB
            // 
            this.SalidaRB.AutoSize = true;
            this.SalidaRB.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SalidaRB.ForeColor = System.Drawing.Color.White;
            this.SalidaRB.Location = new System.Drawing.Point(127, 119);
            this.SalidaRB.Name = "SalidaRB";
            this.SalidaRB.Size = new System.Drawing.Size(60, 19);
            this.SalidaRB.TabIndex = 2;
            this.SalidaRB.Text = "Salida";
            this.SalidaRB.UseVisualStyleBackColor = true;
            // 
            // CodigoTXT
            // 
            this.CodigoTXT.Location = new System.Drawing.Point(127, 144);
            this.CodigoTXT.Name = "CodigoTXT";
            this.CodigoTXT.Size = new System.Drawing.Size(135, 20);
            this.CodigoTXT.TabIndex = 3;
            this.CodigoTXT.TextChanged += new System.EventHandler(this.CodigoTXT_TextChanged);
            // 
            // BuscarBTN
            // 
            this.BuscarBTN.Location = new System.Drawing.Point(268, 144);
            this.BuscarBTN.Name = "BuscarBTN";
            this.BuscarBTN.Size = new System.Drawing.Size(61, 20);
            this.BuscarBTN.TabIndex = 4;
            this.BuscarBTN.Text = "Buscar";
            this.BuscarBTN.UseVisualStyleBackColor = true;
            this.BuscarBTN.Click += new System.EventHandler(this.BuscarBTN_Click);
            // 
            // DescripcionTXT
            // 
            this.DescripcionTXT.Location = new System.Drawing.Point(127, 170);
            this.DescripcionTXT.Name = "DescripcionTXT";
            this.DescripcionTXT.ReadOnly = true;
            this.DescripcionTXT.Size = new System.Drawing.Size(202, 20);
            this.DescripcionTXT.TabIndex = 5;
            // 
            // CantidadNUM
            // 
            this.CantidadNUM.Location = new System.Drawing.Point(127, 196);
            this.CantidadNUM.Name = "CantidadNUM";
            this.CantidadNUM.Size = new System.Drawing.Size(135, 20);
            this.CantidadNUM.TabIndex = 6;
            // 
            // ObservacionesTXT
            // 
            this.ObservacionesTXT.Location = new System.Drawing.Point(127, 222);
            this.ObservacionesTXT.Name = "ObservacionesTXT";
            this.ObservacionesTXT.Size = new System.Drawing.Size(202, 20);
            this.ObservacionesTXT.TabIndex = 7;
            // 
            // AceptarBTN
            // 
            this.AceptarBTN.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AceptarBTN.Location = new System.Drawing.Point(163, 272);
            this.AceptarBTN.Name = "AceptarBTN";
            this.AceptarBTN.Size = new System.Drawing.Size(80, 30);
            this.AceptarBTN.TabIndex = 8;
            this.AceptarBTN.Text = "Aceptar";
            this.AceptarBTN.UseVisualStyleBackColor = true;
            this.AceptarBTN.Click += new System.EventHandler(this.AceptarBTN_Click);
            // 
            // CancelarBTN
            // 
            this.CancelarBTN.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CancelarBTN.Location = new System.Drawing.Point(249, 272);
            this.CancelarBTN.Name = "CancelarBTN";
            this.CancelarBTN.Size = new System.Drawing.Size(80, 30);
            this.CancelarBTN.TabIndex = 9;
            this.CancelarBTN.Text = "Cancelar";
            this.CancelarBTN.UseVisualStyleBackColor = true;
            this.CancelarBTN.Click += new System.EventHandler(this.CancelarBTN_Click);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(46, 144);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 18);
            this.label2.TabIndex = 126;
            this.label2.Text = "Código:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(22, 169);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 18);
            this.label3.TabIndex = 127;
            this.label3.Text = "Descripción:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(22, 194);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 18);
            this.label4.TabIndex = 128;
            this.label4.Text = "Cantidad:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(5, 222);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(117, 18);
            this.label5.TabIndex = 129;
            this.label5.Text = "Observaciones:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // EntradasSalidas
            // 
            this.AcceptButton = this.AceptarBTN;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.CancelButton = this.CancelarBTN;
            this.ClientSize = new System.Drawing.Size(351, 324);
            this.ControlBox = false;
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.CancelarBTN);
            this.Controls.Add(this.AceptarBTN);
            this.Controls.Add(this.ObservacionesTXT);
            this.Controls.Add(this.CantidadNUM);
            this.Controls.Add(this.DescripcionTXT);
            this.Controls.Add(this.BuscarBTN);
            this.Controls.Add(this.CodigoTXT);
            this.Controls.Add(this.SalidaRB);
            this.Controls.Add(this.EntradaRB);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.UsuarioCBX);
            this.Controls.Add(this.label1);
            this.Name = "EntradasSalidas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Entradas y salidas de artículos";
            this.Load += new System.EventHandler(this.EntradasSalidas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.CantidadNUM)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ComboBox UsuarioCBX;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton EntradaRB;
        private System.Windows.Forms.RadioButton SalidaRB;
        private System.Windows.Forms.TextBox CodigoTXT;
        private System.Windows.Forms.Button BuscarBTN;
        private System.Windows.Forms.TextBox DescripcionTXT;
        private System.Windows.Forms.NumericUpDown CantidadNUM;
        private System.Windows.Forms.TextBox ObservacionesTXT;
        private System.Windows.Forms.Button AceptarBTN;
        private System.Windows.Forms.Button CancelarBTN;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}