﻿namespace GUI
{
    partial class CatalogoPropiedadesDueño
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
            this.flowLayoutPanelPadre = new System.Windows.Forms.FlowLayoutPanel();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // flowLayoutPanelPadre
            // 
            this.flowLayoutPanelPadre.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanelPadre.Location = new System.Drawing.Point(1, 1);
            this.flowLayoutPanelPadre.Name = "flowLayoutPanelPadre";
            this.flowLayoutPanelPadre.Size = new System.Drawing.Size(799, 452);
            this.flowLayoutPanelPadre.TabIndex = 0;
            this.flowLayoutPanelPadre.Paint += new System.Windows.Forms.PaintEventHandler(this.flowLayoutPanelPadre_Paint);
            // 
            // CatalogoPropiedadesDueño
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.flowLayoutPanelPadre);
            this.Name = "CatalogoPropiedadesDueño";
            this.Text = "CatalogoPropiedadesDueño";
            this.Load += new System.EventHandler(this.CatalogoPropiedadesDueño_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelPadre;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}