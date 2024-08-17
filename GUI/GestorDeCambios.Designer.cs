namespace GUI
{
    partial class GestorDeCambios
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
            this.dataGridViewHistoricoUsuario = new System.Windows.Forms.DataGridView();
            this.comboBoxUsuarios = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewHistoricoUsuario)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewHistoricoUsuario
            // 
            this.dataGridViewHistoricoUsuario.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewHistoricoUsuario.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridViewHistoricoUsuario.Location = new System.Drawing.Point(9, 10);
            this.dataGridViewHistoricoUsuario.Name = "dataGridViewHistoricoUsuario";
            this.dataGridViewHistoricoUsuario.RowHeadersWidth = 51;
            this.dataGridViewHistoricoUsuario.RowTemplate.Height = 24;
            this.dataGridViewHistoricoUsuario.Size = new System.Drawing.Size(667, 492);
            this.dataGridViewHistoricoUsuario.TabIndex = 0;
            // 
            // comboBoxUsuarios
            // 
            this.comboBoxUsuarios.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxUsuarios.FormattingEnabled = true;
            this.comboBoxUsuarios.Location = new System.Drawing.Point(685, 33);
            this.comboBoxUsuarios.Name = "comboBoxUsuarios";
            this.comboBoxUsuarios.Size = new System.Drawing.Size(187, 24);
            this.comboBoxUsuarios.TabIndex = 1;
            this.comboBoxUsuarios.SelectedIndexChanged += new System.EventHandler(this.comboBoxUsuarios_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(687, 82);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(185, 34);
            this.button1.TabIndex = 2;
            this.button1.Tag = "btnRecuperarInstancia";
            this.button1.Text = "Recuperar Instancia";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(682, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 16);
            this.label1.TabIndex = 3;
            this.label1.Tag = "labelUsuarioGC";
            this.label1.Text = "Usuarios";
            // 
            // GestorDeCambios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 514);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.comboBoxUsuarios);
            this.Controls.Add(this.dataGridViewHistoricoUsuario);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GestorDeCambios";
            this.Text = "GestorDeCambios";
            this.Load += new System.EventHandler(this.GestorDeCambios_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewHistoricoUsuario)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewHistoricoUsuario;
        private System.Windows.Forms.ComboBox comboBoxUsuarios;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
    }
}