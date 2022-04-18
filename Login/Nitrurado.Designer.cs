
namespace Login
{
    partial class Nitrurado
    {
        /// <summary>
        /// Designer variable used to keep track of non-visual components.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox DescripcionTxt;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox Codigotxt;
        private System.Windows.Forms.NumericUpDown PesoActual;
        private System.Windows.Forms.Button Confirmar;
        private System.Windows.Forms.Button Cancelar;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Nitrurado));
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.DescripcionTxt = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.Codigotxt = new System.Windows.Forms.TextBox();
            this.PesoActual = new System.Windows.Forms.NumericUpDown();
            this.Confirmar = new System.Windows.Forms.Button();
            this.Cancelar = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SalidasTXT = new System.Windows.Forms.NumericUpDown();
            this.ClienteComboBox = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.BuscarBTN = new System.Windows.Forms.Button();
            this.Ejemplar_ComboBox = new System.Windows.Forms.ComboBox();
            this.Estado_ComboBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.KgAcumuladosTXT = new System.Windows.Forms.TextBox();
            this.MetrosTXT = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.Fecha = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.PesoActual)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SalidasTXT)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(5, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(129, 23);
            this.label2.TabIndex = 1;
            this.label2.Text = "CODIGO";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(0, 154);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(129, 23);
            this.label5.TabIndex = 4;
            this.label5.Text = "SALIDAS";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(6, 179);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(129, 23);
            this.label6.TabIndex = 5;
            this.label6.Text = "PESO ACTUAL";
            this.label6.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(0, 127);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(129, 23);
            this.label7.TabIndex = 6;
            this.label7.Text = "EJEMPLAR";
            this.label7.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // DescripcionTxt
            // 
            this.DescripcionTxt.Location = new System.Drawing.Point(152, 104);
            this.DescripcionTxt.MaxLength = 60;
            this.DescripcionTxt.Name = "DescripcionTxt";
            this.DescripcionTxt.ReadOnly = true;
            this.DescripcionTxt.Size = new System.Drawing.Size(141, 19);
            this.DescripcionTxt.TabIndex = 3;
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(5, 104);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(129, 23);
            this.label8.TabIndex = 13;
            this.label8.Text = "DESCRIPCION";
            this.label8.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // Codigotxt
            // 
            this.Codigotxt.Location = new System.Drawing.Point(152, 81);
            this.Codigotxt.MaxLength = 20;
            this.Codigotxt.Name = "Codigotxt";
            this.Codigotxt.Size = new System.Drawing.Size(82, 19);
            this.Codigotxt.TabIndex = 1;
            this.Codigotxt.TextChanged += new System.EventHandler(this.Codigotxt_TextChanged);
            // 
            // PesoActual
            // 
            this.PesoActual.DecimalPlaces = 3;
            this.PesoActual.Location = new System.Drawing.Point(152, 177);
            this.PesoActual.Name = "PesoActual";
            this.PesoActual.ReadOnly = true;
            this.PesoActual.Size = new System.Drawing.Size(141, 19);
            this.PesoActual.TabIndex = 6;
            // 
            // Confirmar
            // 
            this.Confirmar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Confirmar.Location = new System.Drawing.Point(310, 313);
            this.Confirmar.Name = "Confirmar";
            this.Confirmar.Size = new System.Drawing.Size(90, 27);
            this.Confirmar.TabIndex = 11;
            this.Confirmar.Text = "Confirmar";
            this.Confirmar.UseVisualStyleBackColor = true;
            this.Confirmar.Click += new System.EventHandler(this.CrearClick);
            // 
            // Cancelar
            // 
            this.Cancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Cancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cancelar.Location = new System.Drawing.Point(420, 313);
            this.Cancelar.Name = "Cancelar";
            this.Cancelar.Size = new System.Drawing.Size(90, 27);
            this.Cancelar.TabIndex = 12;
            this.Cancelar.Text = "Salir";
            this.Cancelar.UseVisualStyleBackColor = true;
            this.Cancelar.Click += new System.EventHandler(this.CancelarClick);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(310, 78);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(170, 85);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 20;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(17, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(307, 23);
            this.label1.TabIndex = 13;
            this.label1.Text = "NITRURADO DE MATRICES";
            // 
            // SalidasTXT
            // 
            this.SalidasTXT.Location = new System.Drawing.Point(152, 153);
            this.SalidasTXT.Maximum = new decimal(new int[] {
            6000,
            0,
            0,
            0});
            this.SalidasTXT.Name = "SalidasTXT";
            this.SalidasTXT.ReadOnly = true;
            this.SalidasTXT.Size = new System.Drawing.Size(141, 19);
            this.SalidasTXT.TabIndex = 5;
            // 
            // ClienteComboBox
            // 
            this.ClienteComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ClienteComboBox.FormattingEnabled = true;
            this.ClienteComboBox.Location = new System.Drawing.Point(152, 200);
            this.ClienteComboBox.Name = "ClienteComboBox";
            this.ClienteComboBox.Size = new System.Drawing.Size(141, 21);
            this.ClienteComboBox.TabIndex = 7;
            // 
            // label11
            // 
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(0, 202);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(129, 23);
            this.label11.TabIndex = 31;
            this.label11.Text = "CLIENTE";
            this.label11.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // BuscarBTN
            // 
            this.BuscarBTN.Location = new System.Drawing.Point(240, 78);
            this.BuscarBTN.Name = "BuscarBTN";
            this.BuscarBTN.Size = new System.Drawing.Size(53, 23);
            this.BuscarBTN.TabIndex = 2;
            this.BuscarBTN.Text = "Buscar";
            this.BuscarBTN.UseVisualStyleBackColor = true;
            this.BuscarBTN.Click += new System.EventHandler(this.BuscarBTN_Click);
            // 
            // Ejemplar_ComboBox
            // 
            this.Ejemplar_ComboBox.FormattingEnabled = true;
            this.Ejemplar_ComboBox.Location = new System.Drawing.Point(152, 127);
            this.Ejemplar_ComboBox.Name = "Ejemplar_ComboBox";
            this.Ejemplar_ComboBox.Size = new System.Drawing.Size(141, 21);
            this.Ejemplar_ComboBox.TabIndex = 4;
            this.Ejemplar_ComboBox.SelectedIndexChanged += new System.EventHandler(this.Ejemplar_ComboBox_SelectedIndexChanged);
            this.Ejemplar_ComboBox.SelectionChangeCommitted += new System.EventHandler(this.Ejemplar_ComboBox_SelectionChangeCommitted);
            // 
            // Estado_ComboBox
            // 
            this.Estado_ComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Estado_ComboBox.FormattingEnabled = true;
            this.Estado_ComboBox.Location = new System.Drawing.Point(152, 225);
            this.Estado_ComboBox.Name = "Estado_ComboBox";
            this.Estado_ComboBox.Size = new System.Drawing.Size(141, 21);
            this.Estado_ComboBox.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(0, 227);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(129, 23);
            this.label3.TabIndex = 37;
            this.label3.Text = "ESTADO";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(0, 253);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(129, 23);
            this.label4.TabIndex = 38;
            this.label4.Text = "KG ACUMULADOS";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(0, 278);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(129, 23);
            this.label9.TabIndex = 40;
            this.label9.Text = "Metros Estimados";
            this.label9.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // KgAcumuladosTXT
            // 
            this.KgAcumuladosTXT.Location = new System.Drawing.Point(152, 253);
            this.KgAcumuladosTXT.MaxLength = 20;
            this.KgAcumuladosTXT.Name = "KgAcumuladosTXT";
            this.KgAcumuladosTXT.ReadOnly = true;
            this.KgAcumuladosTXT.Size = new System.Drawing.Size(141, 19);
            this.KgAcumuladosTXT.TabIndex = 41;
            this.KgAcumuladosTXT.Text = "0";
            this.KgAcumuladosTXT.TextChanged += new System.EventHandler(this.KgAcumuladosTXT_TextChanged);
            // 
            // MetrosTXT
            // 
            this.MetrosTXT.Location = new System.Drawing.Point(152, 278);
            this.MetrosTXT.MaxLength = 20;
            this.MetrosTXT.Name = "MetrosTXT";
            this.MetrosTXT.ReadOnly = true;
            this.MetrosTXT.Size = new System.Drawing.Size(141, 19);
            this.MetrosTXT.TabIndex = 42;
            this.MetrosTXT.Text = "0";
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(307, 247);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(187, 23);
            this.label10.TabIndex = 46;
            this.label10.Text = "Fecha de envío a nitrurado";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Fecha
            // 
            this.Fecha.Location = new System.Drawing.Point(310, 276);
            this.Fecha.Name = "Fecha";
            this.Fecha.Size = new System.Drawing.Size(200, 19);
            this.Fecha.TabIndex = 45;
            // 
            // Nitrurado
            // 
            this.AcceptButton = this.Confirmar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.CancelButton = this.Cancelar;
            this.ClientSize = new System.Drawing.Size(542, 361);
            this.ControlBox = false;
            this.Controls.Add(this.label10);
            this.Controls.Add(this.Fecha);
            this.Controls.Add(this.MetrosTXT);
            this.Controls.Add(this.KgAcumuladosTXT);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Estado_ComboBox);
            this.Controls.Add(this.Ejemplar_ComboBox);
            this.Controls.Add(this.BuscarBTN);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.ClienteComboBox);
            this.Controls.Add(this.SalidasTXT);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.Cancelar);
            this.Controls.Add(this.Confirmar);
            this.Controls.Add(this.PesoActual);
            this.Controls.Add(this.Codigotxt);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.DescripcionTxt);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Nitrurado";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nitrurado";
            this.Load += new System.EventHandler(this.NitruradoLoad);
            ((System.ComponentModel.ISupportInitialize)(this.PesoActual)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SalidasTXT)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.NumericUpDown SalidasTXT;
        private System.Windows.Forms.ComboBox ClienteComboBox;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button BuscarBTN;
        private System.Windows.Forms.ComboBox Ejemplar_ComboBox;
        private System.Windows.Forms.ComboBox Estado_ComboBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox KgAcumuladosTXT;
        private System.Windows.Forms.TextBox MetrosTXT;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DateTimePicker Fecha;
    }
}
