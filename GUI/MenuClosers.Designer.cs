namespace GUI
{
    partial class MenuClosers
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
            this.label1 = new System.Windows.Forms.Label();
            this.btnAbrirCatalogo = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.label1.Location = new System.Drawing.Point(12, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 39);
            this.label1.TabIndex = 0;
            this.label1.Text = "Menu";
            // 
            // btnAbrirCatalogo
            // 
            this.btnAbrirCatalogo.Location = new System.Drawing.Point(12, 104);
            this.btnAbrirCatalogo.Name = "btnAbrirCatalogo";
            this.btnAbrirCatalogo.Size = new System.Drawing.Size(179, 46);
            this.btnAbrirCatalogo.TabIndex = 1;
            this.btnAbrirCatalogo.Text = "Ver Catalogo";
            this.btnAbrirCatalogo.UseVisualStyleBackColor = true;
            this.btnAbrirCatalogo.Click += new System.EventHandler(this.btnAbrirCatalogo_Click);
            // 
            // MenuClosers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnAbrirCatalogo);
            this.Controls.Add(this.label1);
            this.Name = "MenuClosers";
            this.Text = "MenuClosers";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MenuClosers_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAbrirCatalogo;
    }
}