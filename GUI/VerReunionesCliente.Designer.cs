namespace GUI
{
    partial class VerReunionesCliente
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VerReunionesCliente));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dataGridViewReuniones = new System.Windows.Forms.DataGridView();
            this.buttonCancelarReunion = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewReuniones)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.dataGridViewReuniones, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.buttonCancelarReunion, 0, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 1);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90.47619F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.523809F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(776, 437);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // dataGridViewReuniones
            // 
            this.dataGridViewReuniones.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewReuniones.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.dataGridViewReuniones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewReuniones.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridViewReuniones.Location = new System.Drawing.Point(3, 3);
            this.dataGridViewReuniones.Name = "dataGridViewReuniones";
            this.dataGridViewReuniones.RowHeadersWidth = 51;
            this.dataGridViewReuniones.RowTemplate.Height = 24;
            this.dataGridViewReuniones.Size = new System.Drawing.Size(770, 389);
            this.dataGridViewReuniones.TabIndex = 0;
            // 
            // buttonCancelarReunion
            // 
            this.buttonCancelarReunion.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.buttonCancelarReunion.Location = new System.Drawing.Point(3, 404);
            this.buttonCancelarReunion.Name = "buttonCancelarReunion";
            this.buttonCancelarReunion.Size = new System.Drawing.Size(134, 23);
            this.buttonCancelarReunion.TabIndex = 1;
            this.buttonCancelarReunion.Tag = "btnCancelarReunion";
            this.buttonCancelarReunion.Text = "Cancelar Reunion";
            this.buttonCancelarReunion.UseVisualStyleBackColor = true;
            this.buttonCancelarReunion.Click += new System.EventHandler(this.buttonCancelarReunion_Click);
            // 
            // VerReunionesCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(818, 497);
            this.Name = "VerReunionesCliente";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.Text = "Ver Reuniones Cliente";
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewReuniones)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataGridView dataGridViewReuniones;
        private System.Windows.Forms.Button buttonCancelarReunion;
    }
}