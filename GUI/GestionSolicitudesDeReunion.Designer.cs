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
            this.tableLayoutPanelPadre = new System.Windows.Forms.TableLayoutPanel();
            this.dataGridViewSolicitudes = new System.Windows.Forms.DataGridView();
            this.flowLayoutPanelSolicitante = new System.Windows.Forms.FlowLayoutPanel();
            this.tableLayoutPanelPadre.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSolicitudes)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanelPadre
            // 
            this.tableLayoutPanelPadre.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanelPadre.ColumnCount = 2;
            this.tableLayoutPanelPadre.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelPadre.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelPadre.Controls.Add(this.dataGridViewSolicitudes, 0, 0);
            this.tableLayoutPanelPadre.Controls.Add(this.flowLayoutPanelSolicitante, 1, 0);
            this.tableLayoutPanelPadre.Location = new System.Drawing.Point(9, 0);
            this.tableLayoutPanelPadre.Name = "tableLayoutPanelPadre";
            this.tableLayoutPanelPadre.RowCount = 1;
            this.tableLayoutPanelPadre.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelPadre.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelPadre.Size = new System.Drawing.Size(1233, 458);
            this.tableLayoutPanelPadre.TabIndex = 0;
            // 
            // dataGridViewSolicitudes
            // 
            this.dataGridViewSolicitudes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewSolicitudes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewSolicitudes.Location = new System.Drawing.Point(3, 3);
            this.dataGridViewSolicitudes.Name = "dataGridViewSolicitudes";
            this.dataGridViewSolicitudes.RowHeadersWidth = 51;
            this.dataGridViewSolicitudes.RowTemplate.Height = 24;
            this.dataGridViewSolicitudes.Size = new System.Drawing.Size(610, 452);
            this.dataGridViewSolicitudes.TabIndex = 0;
            this.dataGridViewSolicitudes.SelectionChanged += new System.EventHandler(this.dataGridViewSolicitudes_SelectionChanged);
            // 
            // flowLayoutPanelSolicitante
            // 
            this.flowLayoutPanelSolicitante.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanelSolicitante.AutoSize = true;
            this.flowLayoutPanelSolicitante.Location = new System.Drawing.Point(619, 3);
            this.flowLayoutPanelSolicitante.Name = "flowLayoutPanelSolicitante";
            this.flowLayoutPanelSolicitante.Size = new System.Drawing.Size(611, 452);
            this.flowLayoutPanelSolicitante.TabIndex = 1;
            // 
            // GestionSolicitudesDeReunion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1241, 455);
            this.Controls.Add(this.tableLayoutPanelPadre);
            this.Name = "GestionSolicitudesDeReunion";
            this.Text = "GestionSolicitudesDeReunion";
            this.tableLayoutPanelPadre.ResumeLayout(false);
            this.tableLayoutPanelPadre.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSolicitudes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelPadre;
        private System.Windows.Forms.DataGridView dataGridViewSolicitudes;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelSolicitante;
    }
}