namespace GUI
{
    partial class GestionDePropiedades
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GestionDePropiedades));
            this.flowLayoutPanelPadre = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // flowLayoutPanelPadre
            // 
            this.flowLayoutPanelPadre.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanelPadre.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.flowLayoutPanelPadre.ForeColor = System.Drawing.Color.White;
            this.flowLayoutPanelPadre.Location = new System.Drawing.Point(1, -1);
            this.flowLayoutPanelPadre.Name = "flowLayoutPanelPadre";
            this.flowLayoutPanelPadre.Size = new System.Drawing.Size(799, 452);
            this.flowLayoutPanelPadre.TabIndex = 1;
            this.flowLayoutPanelPadre.Paint += new System.Windows.Forms.PaintEventHandler(this.flowLayoutPanelPadre_Paint);
            // 
            // GestionDePropiedades
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.flowLayoutPanelPadre);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(818, 497);
            this.Name = "GestionDePropiedades";
            this.Text = "Catalogo de Propiedades";
            this.Load += new System.EventHandler(this.CatalogoDePropiedades_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelPadre;
    }
}