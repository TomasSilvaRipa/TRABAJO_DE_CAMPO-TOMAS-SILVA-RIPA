namespace GUI
{
    partial class GestionSolicitudesDeReunion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GestionSolicitudesDeReunion));
            this.tableLayoutPanelPadre = new System.Windows.Forms.TableLayoutPanel();
            this.dataGridViewSolicitudes = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanelSolicitante = new System.Windows.Forms.FlowLayoutPanel();
            this.dataGridViewOpiniones = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanelPadre.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSolicitudes)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOpiniones)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanelPadre
            // 
            this.tableLayoutPanelPadre.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanelPadre.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.tableLayoutPanelPadre.ColumnCount = 2;
            this.tableLayoutPanelPadre.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelPadre.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelPadre.Controls.Add(this.dataGridViewSolicitudes, 0, 0);
            this.tableLayoutPanelPadre.Controls.Add(this.tableLayoutPanel1, 1, 0);
            this.tableLayoutPanelPadre.Location = new System.Drawing.Point(9, 0);
            this.tableLayoutPanelPadre.Name = "tableLayoutPanelPadre";
            this.tableLayoutPanelPadre.RowCount = 1;
            this.tableLayoutPanelPadre.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelPadre.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelPadre.Size = new System.Drawing.Size(1233, 561);
            this.tableLayoutPanelPadre.TabIndex = 0;
            // 
            // dataGridViewSolicitudes
            // 
            this.dataGridViewSolicitudes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewSolicitudes.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.dataGridViewSolicitudes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewSolicitudes.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridViewSolicitudes.Location = new System.Drawing.Point(3, 3);
            this.dataGridViewSolicitudes.Name = "dataGridViewSolicitudes";
            this.dataGridViewSolicitudes.RowHeadersWidth = 51;
            this.dataGridViewSolicitudes.RowTemplate.Height = 24;
            this.dataGridViewSolicitudes.Size = new System.Drawing.Size(610, 555);
            this.dataGridViewSolicitudes.TabIndex = 0;
            this.dataGridViewSolicitudes.SelectionChanged += new System.EventHandler(this.dataGridViewSolicitudes_SelectionChanged);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanelSolicitante, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.dataGridViewOpiniones, 0, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(619, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 67.79661F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 32.20339F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(611, 555);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // flowLayoutPanelSolicitante
            // 
            this.flowLayoutPanelSolicitante.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanelSolicitante.AutoSize = true;
            this.flowLayoutPanelSolicitante.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanelSolicitante.Name = "flowLayoutPanelSolicitante";
            this.flowLayoutPanelSolicitante.Size = new System.Drawing.Size(605, 370);
            this.flowLayoutPanelSolicitante.TabIndex = 1;
            // 
            // dataGridViewOpiniones
            // 
            this.dataGridViewOpiniones.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewOpiniones.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.dataGridViewOpiniones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewOpiniones.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridViewOpiniones.Location = new System.Drawing.Point(3, 379);
            this.dataGridViewOpiniones.Name = "dataGridViewOpiniones";
            this.dataGridViewOpiniones.RowHeadersWidth = 51;
            this.dataGridViewOpiniones.RowTemplate.Height = 24;
            this.dataGridViewOpiniones.Size = new System.Drawing.Size(605, 173);
            this.dataGridViewOpiniones.TabIndex = 2;
            // 
            // GestionSolicitudesDeReunion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1241, 562);
            this.Controls.Add(this.tableLayoutPanelPadre);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(1259, 609);
            this.Name = "GestionSolicitudesDeReunion";
            this.Text = "Gestion Solicitudes de Reunion";
            this.ResizeEnd += new System.EventHandler(this.GestionSolicitudesDeReunion_ResizeEnd);
            this.Resize += new System.EventHandler(this.GestionSolicitudesDeReunion_Resize);
            this.tableLayoutPanelPadre.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSolicitudes)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOpiniones)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelPadre;
        private System.Windows.Forms.DataGridView dataGridViewSolicitudes;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelSolicitante;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataGridView dataGridViewOpiniones;
    }
}