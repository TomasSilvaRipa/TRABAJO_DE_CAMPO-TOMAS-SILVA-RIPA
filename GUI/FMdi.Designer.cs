namespace GUI
{
    partial class FMdi
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
            this.components = new System.ComponentModel.Container();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.permisosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.txtUsuario = new System.Windows.Forms.Label();
            this.btnLogout = new System.Windows.Forms.Button();
            this.labelGU = new System.Windows.Forms.Label();
            this.labelBitacora = new System.Windows.Forms.Label();
            this.labelGestionDePermisos = new System.Windows.Forms.Label();
            this.labelTraducciones = new System.Windows.Forms.Label();
            this.cbxIdiomas = new System.Windows.Forms.ComboBox();
            this.labelGestorDeCambios = new System.Windows.Forms.Label();
            this.labelGestionDeBaseDeDatos = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            this.contextMenuStrip1.Tag = "contextmenuStrip2";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 20.75F);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.permisosToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1172, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Tag = "menuStrip1";
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // permisosToolStripMenuItem
            // 
            this.permisosToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 10.6F);
            this.permisosToolStripMenuItem.Name = "permisosToolStripMenuItem";
            this.permisosToolStripMenuItem.Size = new System.Drawing.Size(14, 20);
            this.permisosToolStripMenuItem.Tag = "VistaMenuInicio";
            this.permisosToolStripMenuItem.Click += new System.EventHandler(this.permisosToolStripMenuItem_Click);
            // 
            // txtUsuario
            // 
            this.txtUsuario.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUsuario.AutoSize = true;
            this.txtUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsuario.Location = new System.Drawing.Point(891, 1);
            this.txtUsuario.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(109, 25);
            this.txtUsuario.TabIndex = 2;
            this.txtUsuario.Tag = "txtUsuario";
            this.txtUsuario.Text = "txtUsuario\r\n";
            // 
            // btnLogout
            // 
            this.btnLogout.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLogout.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold);
            this.btnLogout.Location = new System.Drawing.Point(1043, 0);
            this.btnLogout.Margin = new System.Windows.Forms.Padding(4);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(129, 31);
            this.btnLogout.TabIndex = 1;
            this.btnLogout.Tag = "btnLogOut";
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // labelGU
            // 
            this.labelGU.AutoSize = true;
            this.labelGU.BackColor = System.Drawing.Color.WhiteSmoke;
            this.labelGU.Location = new System.Drawing.Point(-3, 8);
            this.labelGU.Name = "labelGU";
            this.labelGU.Size = new System.Drawing.Size(131, 16);
            this.labelGU.TabIndex = 4;
            this.labelGU.Tag = "GestionDeUsuarios";
            this.labelGU.Text = "Gestión De Usuarios";
            this.labelGU.Click += new System.EventHandler(this.labelGU_Click);
            // 
            // labelBitacora
            // 
            this.labelBitacora.AutoSize = true;
            this.labelBitacora.Location = new System.Drawing.Point(145, 8);
            this.labelBitacora.Name = "labelBitacora";
            this.labelBitacora.Size = new System.Drawing.Size(57, 16);
            this.labelBitacora.TabIndex = 5;
            this.labelBitacora.Tag = "GestionDeBitacora";
            this.labelBitacora.Text = "Bitacora";
            this.labelBitacora.Click += new System.EventHandler(this.labelBitacora_Click);
            // 
            // labelGestionDePermisos
            // 
            this.labelGestionDePermisos.AutoSize = true;
            this.labelGestionDePermisos.Location = new System.Drawing.Point(225, 8);
            this.labelGestionDePermisos.Name = "labelGestionDePermisos";
            this.labelGestionDePermisos.Size = new System.Drawing.Size(64, 16);
            this.labelGestionDePermisos.TabIndex = 6;
            this.labelGestionDePermisos.Tag = "GestionDePermisos";
            this.labelGestionDePermisos.Text = "Permisos";
            this.labelGestionDePermisos.Click += new System.EventHandler(this.label1_Click);
            // 
            // labelTraducciones
            // 
            this.labelTraducciones.AutoSize = true;
            this.labelTraducciones.Location = new System.Drawing.Point(310, 8);
            this.labelTraducciones.Name = "labelTraducciones";
            this.labelTraducciones.Size = new System.Drawing.Size(90, 16);
            this.labelTraducciones.TabIndex = 8;
            this.labelTraducciones.Tag = "Traducciones";
            this.labelTraducciones.Text = "Traducciones";
            this.labelTraducciones.Click += new System.EventHandler(this.labelTraducciones_Click);
            // 
            // cbxIdiomas
            // 
            this.cbxIdiomas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxIdiomas.FormattingEnabled = true;
            this.cbxIdiomas.Location = new System.Drawing.Point(747, 0);
            this.cbxIdiomas.Name = "cbxIdiomas";
            this.cbxIdiomas.Size = new System.Drawing.Size(104, 24);
            this.cbxIdiomas.TabIndex = 9;
            this.cbxIdiomas.SelectedIndexChanged += new System.EventHandler(this.cbxIdiomas_SelectedIndexChanged);
            // 
            // labelGestorDeCambios
            // 
            this.labelGestorDeCambios.AutoSize = true;
            this.labelGestorDeCambios.Location = new System.Drawing.Point(416, 8);
            this.labelGestorDeCambios.Name = "labelGestorDeCambios";
            this.labelGestorDeCambios.Size = new System.Drawing.Size(125, 16);
            this.labelGestorDeCambios.TabIndex = 8;
            this.labelGestorDeCambios.Tag = "GestorDeCambios";
            this.labelGestorDeCambios.Text = "Gestor De Cambios";
            this.labelGestorDeCambios.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // labelGestionDeBaseDeDatos
            // 
            this.labelGestionDeBaseDeDatos.AutoSize = true;
            this.labelGestionDeBaseDeDatos.Location = new System.Drawing.Point(547, 8);
            this.labelGestionDeBaseDeDatos.Name = "labelGestionDeBaseDeDatos";
            this.labelGestionDeBaseDeDatos.Size = new System.Drawing.Size(165, 16);
            this.labelGestionDeBaseDeDatos.TabIndex = 11;
            this.labelGestionDeBaseDeDatos.Text = "Gestion de Base de Datos";
            this.labelGestionDeBaseDeDatos.Click += new System.EventHandler(this.labelGestionDeBaseDeDatos_Click);
            // 
            // FMdi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1172, 554);
            this.Controls.Add(this.labelGestionDeBaseDeDatos);
            this.Controls.Add(this.cbxIdiomas);
            this.Controls.Add(this.labelTraducciones);
            this.Controls.Add(this.labelGestorDeCambios);
            this.Controls.Add(this.labelGestionDePermisos);
            this.Controls.Add(this.labelBitacora);
            this.Controls.Add(this.labelGU);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.txtUsuario);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FMdi";
            this.ShowIcon = false;
            this.Tag = "FormFMdi";
            this.Text = "Menu";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FMdi_FormClosed);
            this.Load += new System.EventHandler(this.FMdi_Load);
            this.VisibleChanged += new System.EventHandler(this.FMdi_VisibleChanged);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.Label txtUsuario;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.ToolStripMenuItem permisosToolStripMenuItem;
        private System.Windows.Forms.Label labelGU;
        private System.Windows.Forms.Label labelBitacora;
        private System.Windows.Forms.Label labelGestionDePermisos;
        private System.Windows.Forms.Label labelTraducciones;
        private System.Windows.Forms.ComboBox cbxIdiomas;
        private System.Windows.Forms.Label labelGestorDeCambios;
        private System.Windows.Forms.Label labelGestionDeBaseDeDatos;
    }
}