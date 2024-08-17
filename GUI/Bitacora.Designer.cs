namespace GUI
{
    partial class Bitacora
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
            this.dateTimePickerDesde = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerHasta = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridViewBitacora = new System.Windows.Forms.DataGridView();
            this.btnFiltrar = new System.Windows.Forms.Button();
            this.comboBoxTipo = new System.Windows.Forms.ComboBox();
            this.radioButtonFecha = new System.Windows.Forms.RadioButton();
            this.radioButtonTipo = new System.Windows.Forms.RadioButton();
            this.radioButtonFYT = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBitacora)).BeginInit();
            this.SuspendLayout();
            // 
            // dateTimePickerDesde
            // 
            this.dateTimePickerDesde.Location = new System.Drawing.Point(22, 27);
            this.dateTimePickerDesde.Name = "dateTimePickerDesde";
            this.dateTimePickerDesde.Size = new System.Drawing.Size(240, 20);
            this.dateTimePickerDesde.TabIndex = 0;
            // 
            // dateTimePickerHasta
            // 
            this.dateTimePickerHasta.Location = new System.Drawing.Point(331, 27);
            this.dateTimePickerHasta.Name = "dateTimePickerHasta";
            this.dateTimePickerHasta.Size = new System.Drawing.Size(240, 20);
            this.dateTimePickerHasta.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Desde";
            this.label1.Tag = "Fbitacora_Desde";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(328, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Hasta";
            this.label2.Tag = "Fbitacora_Hasta";
            // 
            // dataGridViewBitacora
            // 
            this.dataGridViewBitacora.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewBitacora.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridViewBitacora.Location = new System.Drawing.Point(12, 106);
            this.dataGridViewBitacora.Name = "dataGridViewBitacora";
            this.dataGridViewBitacora.Size = new System.Drawing.Size(867, 332);
            this.dataGridViewBitacora.TabIndex = 100;
            this.dataGridViewBitacora.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewBitacora_CellContentClick);
            // 
            // btnFiltrar
            // 
            this.btnFiltrar.Location = new System.Drawing.Point(22, 64);
            this.btnFiltrar.Name = "btnFiltrar";
            this.btnFiltrar.Size = new System.Drawing.Size(225, 22);
            this.btnFiltrar.TabIndex = 7;
            this.btnFiltrar.Text = "Filtrar";
            this.btnFiltrar.UseVisualStyleBackColor = true;
            this.btnFiltrar.Click += new System.EventHandler(this.btnFiltrar_Click);
            this.btnFiltrar.Tag = "Fbitacora_Filtrar";
            // 
            // comboBoxTipo
            // 
            this.comboBoxTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxTipo.FormattingEnabled = true;
            this.comboBoxTipo.Location = new System.Drawing.Point(335, 65);
            this.comboBoxTipo.Name = "comboBoxTipo";
            this.comboBoxTipo.Size = new System.Drawing.Size(175, 21);
            this.comboBoxTipo.TabIndex = 3;
            
            // 
            // radioButtonFecha
            // 
            this.radioButtonFecha.AutoSize = true;
            this.radioButtonFecha.Location = new System.Drawing.Point(589, 28);
            this.radioButtonFecha.Name = "radioButtonFecha";
            this.radioButtonFecha.Size = new System.Drawing.Size(101, 17);
            this.radioButtonFecha.TabIndex = 4;
            this.radioButtonFecha.TabStop = true;
            this.radioButtonFecha.Text = "Filtrar por Fecha";
            this.radioButtonFecha.UseVisualStyleBackColor = true;
            this.radioButtonFecha.Tag = "Fbitacora_FiltrarFecha";
            // 
            // radioButtonTipo
            // 
            this.radioButtonTipo.AutoSize = true;
            this.radioButtonTipo.Location = new System.Drawing.Point(589, 49);
            this.radioButtonTipo.Name = "radioButtonTipo";
            this.radioButtonTipo.Size = new System.Drawing.Size(92, 17);
            this.radioButtonTipo.TabIndex = 5;
            this.radioButtonTipo.TabStop = true;
            this.radioButtonTipo.Text = "Filtrar por Tipo";
            this.radioButtonTipo.UseVisualStyleBackColor = true;
            this.radioButtonTipo.Tag = "Fbitacora_FiltrarTipo";
            // 
            // radioButtonFYT
            // 
            this.radioButtonFYT.AutoSize = true;
            this.radioButtonFYT.Location = new System.Drawing.Point(589, 72);
            this.radioButtonFYT.Name = "radioButtonFYT";
            this.radioButtonFYT.Size = new System.Drawing.Size(133, 17);
            this.radioButtonFYT.TabIndex = 6;
            this.radioButtonFYT.TabStop = true;
            this.radioButtonFYT.Text = "Filtrar por Fecha y Tipo";
            this.radioButtonFYT.UseVisualStyleBackColor = true;
            this.radioButtonFYT.Tag = "Fbitacora_FiltrarFechaTipo";
            // 
            // Bitacora
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(891, 450);
            this.Controls.Add(this.radioButtonFYT);
            this.Controls.Add(this.radioButtonTipo);
            this.Controls.Add(this.radioButtonFecha);
            this.Controls.Add(this.comboBoxTipo);
            this.Controls.Add(this.btnFiltrar);
            this.Controls.Add(this.dataGridViewBitacora);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dateTimePickerHasta);
            this.Controls.Add(this.dateTimePickerDesde);
            this.MaximizeBox = false;
            this.Name = "Bitacora";
            this.ShowIcon = false;
            this.Text = "Bitacora";
            this.Load += new System.EventHandler(this.Bitacora_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBitacora)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dateTimePickerDesde;
        private System.Windows.Forms.DateTimePicker dateTimePickerHasta;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dataGridViewBitacora;
        private System.Windows.Forms.Button btnFiltrar;
        private System.Windows.Forms.ComboBox comboBoxTipo;
        private System.Windows.Forms.RadioButton radioButtonFecha;
        private System.Windows.Forms.RadioButton radioButtonTipo;
        private System.Windows.Forms.RadioButton radioButtonFYT;
    }
}