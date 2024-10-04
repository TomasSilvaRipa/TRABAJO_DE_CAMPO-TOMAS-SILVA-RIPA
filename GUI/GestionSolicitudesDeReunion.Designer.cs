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
            this.tableLayoutPanelSolicitante = new System.Windows.Forms.TableLayoutPanel();
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
            this.tableLayoutPanelPadre.Controls.Add(this.tableLayoutPanelSolicitante, 1, 0);
            this.tableLayoutPanelPadre.Location = new System.Drawing.Point(9, 0);
            this.tableLayoutPanelPadre.Name = "tableLayoutPanelPadre";
            this.tableLayoutPanelPadre.RowCount = 1;
            this.tableLayoutPanelPadre.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelPadre.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelPadre.Size = new System.Drawing.Size(789, 443);
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
            this.dataGridViewSolicitudes.Size = new System.Drawing.Size(388, 437);
            this.dataGridViewSolicitudes.TabIndex = 0;
            this.dataGridViewSolicitudes.SelectionChanged += new System.EventHandler(this.dataGridViewSolicitudes_SelectionChanged);
            // 
            // tableLayoutPanelSolicitante
            // 
            this.tableLayoutPanelSolicitante.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanelSolicitante.ColumnCount = 1;
            this.tableLayoutPanelSolicitante.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelSolicitante.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelSolicitante.Location = new System.Drawing.Point(397, 3);
            this.tableLayoutPanelSolicitante.Name = "tableLayoutPanelSolicitante";
            this.tableLayoutPanelSolicitante.RowCount = 1;
            this.tableLayoutPanelSolicitante.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelSolicitante.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelSolicitante.Size = new System.Drawing.Size(389, 437);
            this.tableLayoutPanelSolicitante.TabIndex = 1;
            // 
            // GestionSolicitudesDeReunion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 455);
            this.Controls.Add(this.tableLayoutPanelPadre);
            this.Name = "GestionSolicitudesDeReunion";
            this.Text = "GestionSolicitudesDeReunion";
            this.tableLayoutPanelPadre.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSolicitudes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelPadre;
        private System.Windows.Forms.DataGridView dataGridViewSolicitudes;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelSolicitante;
    }
}