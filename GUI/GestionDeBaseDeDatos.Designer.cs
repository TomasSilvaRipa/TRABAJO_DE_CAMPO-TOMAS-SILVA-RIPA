namespace GUI
{
    partial class GestionDeBaseDeDatos
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
            this.btnBackUp = new System.Windows.Forms.Button();
            this.btnRestore = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnBackUp
            // 
            this.btnBackUp.Location = new System.Drawing.Point(21, 26);
            this.btnBackUp.Name = "btnBackUp";
            this.btnBackUp.Size = new System.Drawing.Size(84, 49);
            this.btnBackUp.TabIndex = 0;
            this.btnBackUp.Text = "Hacer BackUp ";
            this.btnBackUp.UseVisualStyleBackColor = true;
            this.btnBackUp.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnRestore
            // 
            this.btnRestore.Location = new System.Drawing.Point(138, 31);
            this.btnRestore.Name = "btnRestore";
            this.btnRestore.Size = new System.Drawing.Size(84, 44);
            this.btnRestore.TabIndex = 1;
            this.btnRestore.Text = "Hacer Restore";
            this.btnRestore.UseVisualStyleBackColor = true;
            this.btnRestore.Click += new System.EventHandler(this.btnRestore_Click);
            // 
            // GestionDeBaseDeDatos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(304, 114);
            this.Controls.Add(this.btnRestore);
            this.Controls.Add(this.btnBackUp);
            this.Name = "GestionDeBaseDeDatos";
            this.ShowIcon = false;
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnBackUp;
        private System.Windows.Forms.Button btnRestore;
    }
}