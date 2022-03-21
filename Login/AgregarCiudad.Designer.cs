
namespace Login
{
    partial class AgregarCiudad
    {
        /// <summary>
        /// Designer variable used to keep track of non-visual components.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Button Crear;
        private System.Windows.Forms.Button Cancelar;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AgregarCiudad));
            this.Crear = new System.Windows.Forms.Button();
            this.Cancelar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.ProvinciaComboBox = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.LocalidadNueva = new System.Windows.Forms.TextBox();
            this.LocalidadExistente = new System.Windows.Forms.ComboBox();
            this.EliminarBTN = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Crear
            // 
            this.Crear.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Crear.Location = new System.Drawing.Point(317, 100);
            this.Crear.Name = "Crear";
            this.Crear.Size = new System.Drawing.Size(90, 27);
            this.Crear.TabIndex = 12;
            this.Crear.Text = "Agregar";
            this.Crear.UseVisualStyleBackColor = true;
            this.Crear.Click += new System.EventHandler(this.CrearClick);
            // 
            // Cancelar
            // 
            this.Cancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Cancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cancelar.Location = new System.Drawing.Point(162, 198);
            this.Cancelar.Name = "Cancelar";
            this.Cancelar.Size = new System.Drawing.Size(90, 27);
            this.Cancelar.TabIndex = 13;
            this.Cancelar.Text = "Salir";
            this.Cancelar.UseVisualStyleBackColor = true;
            this.Cancelar.Click += new System.EventHandler(this.CancelarClick);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(11, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(132, 23);
            this.label1.TabIndex = 13;
            this.label1.Text = "CIUDADES";
            // 
            // ProvinciaComboBox
            // 
            this.ProvinciaComboBox.FormattingEnabled = true;
            this.ProvinciaComboBox.Location = new System.Drawing.Point(98, 63);
            this.ProvinciaComboBox.Name = "ProvinciaComboBox";
            this.ProvinciaComboBox.Size = new System.Drawing.Size(200, 21);
            this.ProvinciaComboBox.TabIndex = 10;
            this.ProvinciaComboBox.SelectedIndexChanged += new System.EventHandler(this.ProvinciaComboBox_SelectedIndexChanged);
            this.ProvinciaComboBox.SelectionChangeCommitted += new System.EventHandler(this.ProvinciaComboBox_SelectionChangeCommitted);
            // 
            // label11
            // 
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(8, 63);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(84, 23);
            this.label11.TabIndex = 31;
            this.label11.Text = "PROVINCIA";
            this.label11.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // LocalidadNueva
            // 
            this.LocalidadNueva.Location = new System.Drawing.Point(98, 105);
            this.LocalidadNueva.Name = "LocalidadNueva";
            this.LocalidadNueva.Size = new System.Drawing.Size(200, 19);
            this.LocalidadNueva.TabIndex = 32;
            // 
            // LocalidadExistente
            // 
            this.LocalidadExistente.FormattingEnabled = true;
            this.LocalidadExistente.Location = new System.Drawing.Point(98, 143);
            this.LocalidadExistente.Name = "LocalidadExistente";
            this.LocalidadExistente.Size = new System.Drawing.Size(200, 21);
            this.LocalidadExistente.TabIndex = 33;
            // 
            // EliminarBTN
            // 
            this.EliminarBTN.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EliminarBTN.Location = new System.Drawing.Point(317, 137);
            this.EliminarBTN.Name = "EliminarBTN";
            this.EliminarBTN.Size = new System.Drawing.Size(90, 27);
            this.EliminarBTN.TabIndex = 34;
            this.EliminarBTN.Text = "Eliminar";
            this.EliminarBTN.UseVisualStyleBackColor = true;
            this.EliminarBTN.Click += new System.EventHandler(this.EliminarBTN_Click);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(3, 143);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 23);
            this.label2.TabIndex = 35;
            this.label2.Text = "LOCALIDAD";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(3, 104);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 23);
            this.label3.TabIndex = 36;
            this.label3.Text = "LOCALIDAD";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // AgregarCiudad
            // 
            this.AcceptButton = this.Crear;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Navy;
            this.CancelButton = this.Cancelar;
            this.ClientSize = new System.Drawing.Size(429, 237);
            this.ControlBox = false;
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.EliminarBTN);
            this.Controls.Add(this.LocalidadExistente);
            this.Controls.Add(this.LocalidadNueva);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.ProvinciaComboBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Cancelar);
            this.Controls.Add(this.Crear);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AgregarCiudad";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ciudades";
            this.Load += new System.EventHandler(this.AgregarCiudadLoad);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        private System.Windows.Forms.ComboBox ProvinciaComboBox;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox LocalidadNueva;
        private System.Windows.Forms.ComboBox LocalidadExistente;
        private System.Windows.Forms.Button EliminarBTN;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}
