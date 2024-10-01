namespace GUI
{
    partial class Menu
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
            this.tableLayoutPanelCatalogoYFiltro = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanelPadre.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanelPadre
            // 
            this.tableLayoutPanelPadre.ColumnCount = 1;
            this.tableLayoutPanelPadre.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelPadre.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelPadre.Controls.Add(this.tableLayoutPanelCatalogoYFiltro, 0, 1);
            this.tableLayoutPanelPadre.Controls.Add(this.panel1, 0, 2);
            this.tableLayoutPanelPadre.Location = new System.Drawing.Point(-8, 0);
            this.tableLayoutPanelPadre.Name = "tableLayoutPanelPadre";
            this.tableLayoutPanelPadre.RowCount = 3;
            this.tableLayoutPanelPadre.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13.43964F));
            this.tableLayoutPanelPadre.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 86.56036F));
            this.tableLayoutPanelPadre.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 47F));
            this.tableLayoutPanelPadre.Size = new System.Drawing.Size(1087, 520);
            this.tableLayoutPanelPadre.TabIndex = 0;
            // 
            // tableLayoutPanelCatalogoYFiltro
            // 
            this.tableLayoutPanelCatalogoYFiltro.ColumnCount = 2;
            this.tableLayoutPanelCatalogoYFiltro.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70.02776F));
            this.tableLayoutPanelCatalogoYFiltro.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 29.97225F));
            this.tableLayoutPanelCatalogoYFiltro.Location = new System.Drawing.Point(3, 66);
            this.tableLayoutPanelCatalogoYFiltro.Name = "tableLayoutPanelCatalogoYFiltro";
            this.tableLayoutPanelCatalogoYFiltro.RowCount = 1;
            this.tableLayoutPanelCatalogoYFiltro.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelCatalogoYFiltro.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelCatalogoYFiltro.Size = new System.Drawing.Size(1081, 403);
            this.tableLayoutPanelCatalogoYFiltro.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.MediumBlue;
            this.panel1.Controls.Add(this.tableLayoutPanel1);
            this.panel1.Location = new System.Drawing.Point(3, 475);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1081, 42);
            this.panel1.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 21.95122F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 21.95122F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.19512F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 21.95122F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 21.95122F));
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1078, 45);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1074, 515);
            this.Controls.Add(this.tableLayoutPanelPadre);
            this.Name = "Menu";
            this.ShowIcon = false;
            this.Text = "Menu";
            this.tableLayoutPanelPadre.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelPadre;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelCatalogoYFiltro;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}