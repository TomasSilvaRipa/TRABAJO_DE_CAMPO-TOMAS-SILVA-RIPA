namespace GUI
{
    partial class MenuDueños
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
            this.btnAgregarPropiedad = new System.Windows.Forms.Button();
            this.btnVerCatalogo = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAgregarPropiedad
            // 
            this.btnAgregarPropiedad.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnAgregarPropiedad.Location = new System.Drawing.Point(45, 52);
            this.btnAgregarPropiedad.Name = "btnAgregarPropiedad";
            this.btnAgregarPropiedad.Size = new System.Drawing.Size(149, 50);
            this.btnAgregarPropiedad.TabIndex = 0;
            this.btnAgregarPropiedad.Text = "Agregar Propiedad";
            this.btnAgregarPropiedad.UseVisualStyleBackColor = true;
            this.btnAgregarPropiedad.Click += new System.EventHandler(this.btnAgregarPropiedad_Click);
            // 
            // btnVerCatalogo
            // 
            this.btnVerCatalogo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnVerCatalogo.Location = new System.Drawing.Point(45, 206);
            this.btnVerCatalogo.Name = "btnVerCatalogo";
            this.btnVerCatalogo.Size = new System.Drawing.Size(149, 50);
            this.btnVerCatalogo.TabIndex = 1;
            this.btnVerCatalogo.Text = "Ver Catalogo";
            this.btnVerCatalogo.UseVisualStyleBackColor = true;
            this.btnVerCatalogo.Click += new System.EventHandler(this.btnVerCatalogo_Click);
            // 
            // button3
            // 
            this.button3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button3.Location = new System.Drawing.Point(290, 207);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(137, 47);
            this.button3.TabIndex = 2;
            this.button3.Text = "Ver Solicitudes de Closer";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button4.Location = new System.Drawing.Point(290, 53);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(137, 47);
            this.button4.TabIndex = 3;
            this.button4.Text = "Ver Reuniones ";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 39);
            this.label1.TabIndex = 4;
            this.label1.Text = "MENU";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.btnAgregarPropiedad, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.button3, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.button4, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnVerCatalogo, 0, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 95);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(479, 308);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel1, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 1);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 22.82878F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 77.17122F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(485, 406);
            this.tableLayoutPanel2.TabIndex = 6;
            // 
            // MenuDueños
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(483, 404);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Name = "MenuDueños";
            this.ShowIcon = false;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MenuDueños_FormClosed);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAgregarPropiedad;
        private System.Windows.Forms.Button btnVerCatalogo;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
    }
}