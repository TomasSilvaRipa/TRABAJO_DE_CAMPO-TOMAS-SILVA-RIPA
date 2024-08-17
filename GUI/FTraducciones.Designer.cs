namespace GUI
{
    partial class FTraducciones
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
            this.dgvTraduccion = new System.Windows.Forms.DataGridView();
            this.btnAlta = new System.Windows.Forms.Button();
            this.cbxIdiomas = new System.Windows.Forms.ComboBox();
            this.btnBaja = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.txtIdioma = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTraduccion)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvTraduccion
            // 
            this.dgvTraduccion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTraduccion.Location = new System.Drawing.Point(12, 63);
            this.dgvTraduccion.Name = "dgvTraduccion";
            this.dgvTraduccion.RowHeadersWidth = 51;
            this.dgvTraduccion.RowTemplate.Height = 24;
            this.dgvTraduccion.Size = new System.Drawing.Size(508, 484);
            this.dgvTraduccion.TabIndex = 0;
            // 
            // btnAlta
            // 
            this.btnAlta.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAlta.Location = new System.Drawing.Point(536, 63);
            this.btnAlta.Name = "btnAlta";
            this.btnAlta.Size = new System.Drawing.Size(151, 32);
            this.btnAlta.TabIndex = 1;
            this.btnAlta.Tag = "Ftraducciones_Alta";
            this.btnAlta.Text = "ALTA";
            this.btnAlta.UseVisualStyleBackColor = true;
            this.btnAlta.Click += new System.EventHandler(this.btnAlta_Click);
            // 
            // cbxIdiomas
            // 
            this.cbxIdiomas.FormattingEnabled = true;
            this.cbxIdiomas.Location = new System.Drawing.Point(12, 20);
            this.cbxIdiomas.Name = "cbxIdiomas";
            this.cbxIdiomas.Size = new System.Drawing.Size(170, 24);
            this.cbxIdiomas.TabIndex = 2;
            this.cbxIdiomas.SelectedIndexChanged += new System.EventHandler(this.cbxIdiomas_SelectedIndexChanged_1);
            // 
            // btnBaja
            // 
            this.btnBaja.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBaja.Location = new System.Drawing.Point(536, 101);
            this.btnBaja.Name = "btnBaja";
            this.btnBaja.Size = new System.Drawing.Size(151, 32);
            this.btnBaja.TabIndex = 3;
            this.btnBaja.Tag = "Ftraducciones_Baja";
            this.btnBaja.Text = "BAJA";
            this.btnBaja.UseVisualStyleBackColor = true;
            this.btnBaja.Click += new System.EventHandler(this.btnBaja_Click);
            // 
            // btnModificar
            // 
            this.btnModificar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModificar.Location = new System.Drawing.Point(536, 139);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(151, 32);
            this.btnModificar.TabIndex = 4;
            this.btnModificar.Tag = "Ftraducciones_Mod";
            this.btnModificar.Text = "MODIFICACION";
            this.btnModificar.UseVisualStyleBackColor = true;
            this.btnModificar.Click += new System.EventHandler(this.button3_Click);
            // 
            // txtIdioma
            // 
            this.txtIdioma.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIdioma.Location = new System.Drawing.Point(188, 20);
            this.txtIdioma.Name = "txtIdioma";
            this.txtIdioma.Size = new System.Drawing.Size(170, 30);
            this.txtIdioma.TabIndex = 5;
            // 
            // FTraducciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(722, 611);
            this.Controls.Add(this.txtIdioma);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.btnBaja);
            this.Controls.Add(this.cbxIdiomas);
            this.Controls.Add(this.btnAlta);
            this.Controls.Add(this.dgvTraduccion);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FTraducciones";
            this.Text = "FTraducciones";
            this.Load += new System.EventHandler(this.FTraducciones_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTraduccion)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvTraduccion;
        private System.Windows.Forms.Button btnAlta;
        private System.Windows.Forms.ComboBox cbxIdiomas;
        private System.Windows.Forms.Button btnBaja;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.TextBox txtIdioma;
    }
}