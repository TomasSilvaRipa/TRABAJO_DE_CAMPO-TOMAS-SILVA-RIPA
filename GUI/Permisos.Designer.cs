namespace GUI
{
    partial class Permisos
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
            this.treeViewPermisos = new System.Windows.Forms.TreeView();
            this.comboBoxPermisos = new System.Windows.Forms.ComboBox();
            this.txtNombreGrupoPermisos = new System.Windows.Forms.TextBox();
            this.btnCrearGrupo = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAgregarPermiso = new System.Windows.Forms.Button();
            this.dataGridViewUsuarios = new System.Windows.Forms.DataGridView();
            this.comboBoxGruposDePermisos = new System.Windows.Forms.ComboBox();
            this.btnAsignarGrupo = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btnBorrarPermiso = new System.Windows.Forms.Button();
            this.btnQuitarPermisos = new System.Windows.Forms.Button();
            this.dataGridViewPermisosDeUsuarios = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewUsuarios)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPermisosDeUsuarios)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // treeViewPermisos
            // 
            this.treeViewPermisos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.treeViewPermisos.Location = new System.Drawing.Point(3, 2);
            this.treeViewPermisos.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.treeViewPermisos.Name = "treeViewPermisos";
            this.treeViewPermisos.Size = new System.Drawing.Size(504, 311);
            this.treeViewPermisos.TabIndex = 0;
            // 
            // comboBoxPermisos
            // 
            this.comboBoxPermisos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPermisos.FormattingEnabled = true;
            this.comboBoxPermisos.Location = new System.Drawing.Point(3, 188);
            this.comboBoxPermisos.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBoxPermisos.Name = "comboBoxPermisos";
            this.comboBoxPermisos.Size = new System.Drawing.Size(240, 24);
            this.comboBoxPermisos.TabIndex = 1;
            // 
            // txtNombreGrupoPermisos
            // 
            this.txtNombreGrupoPermisos.Location = new System.Drawing.Point(3, 30);
            this.txtNombreGrupoPermisos.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtNombreGrupoPermisos.Name = "txtNombreGrupoPermisos";
            this.txtNombreGrupoPermisos.Size = new System.Drawing.Size(240, 22);
            this.txtNombreGrupoPermisos.TabIndex = 2;
            // 
            // btnCrearGrupo
            // 
            this.btnCrearGrupo.Location = new System.Drawing.Point(3, 64);
            this.btnCrearGrupo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCrearGrupo.Name = "btnCrearGrupo";
            this.btnCrearGrupo.Size = new System.Drawing.Size(240, 28);
            this.btnCrearGrupo.TabIndex = 3;
            this.btnCrearGrupo.Tag = "Fpermisos_CrearGrupo";
            this.btnCrearGrupo.Text = "Crear Nuevo Grupo De Permisos";
            this.btnCrearGrupo.UseVisualStyleBackColor = true;
            this.btnCrearGrupo.Click += new System.EventHandler(this.btnCrearGrupo_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 16);
            this.label1.TabIndex = 4;
            this.label1.Tag = "Fpermisos_NombreGrupo";
            this.label1.Text = "Nombre del Grupo";
            // 
            // btnAgregarPermiso
            // 
            this.btnAgregarPermiso.Location = new System.Drawing.Point(3, 2);
            this.btnAgregarPermiso.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAgregarPermiso.Name = "btnAgregarPermiso";
            this.btnAgregarPermiso.Size = new System.Drawing.Size(240, 29);
            this.btnAgregarPermiso.TabIndex = 5;
            this.btnAgregarPermiso.Tag = "Fpermisos_AgregarPermiso";
            this.btnAgregarPermiso.Text = "Agregar Permiso";
            this.btnAgregarPermiso.UseVisualStyleBackColor = true;
            this.btnAgregarPermiso.Click += new System.EventHandler(this.btnAgregarPermiso_Click);
            // 
            // dataGridViewUsuarios
            // 
            this.dataGridViewUsuarios.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewUsuarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewUsuarios.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridViewUsuarios.Location = new System.Drawing.Point(3, 317);
            this.dataGridViewUsuarios.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridViewUsuarios.Name = "dataGridViewUsuarios";
            this.dataGridViewUsuarios.RowHeadersWidth = 51;
            this.dataGridViewUsuarios.RowTemplate.Height = 24;
            this.dataGridViewUsuarios.Size = new System.Drawing.Size(504, 223);
            this.dataGridViewUsuarios.TabIndex = 6;
            this.dataGridViewUsuarios.SelectionChanged += new System.EventHandler(this.dataGridViewUsuarios_SelectionChanged);
            // 
            // comboBoxGruposDePermisos
            // 
            this.comboBoxGruposDePermisos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxGruposDePermisos.FormattingEnabled = true;
            this.comboBoxGruposDePermisos.Location = new System.Drawing.Point(3, 130);
            this.comboBoxGruposDePermisos.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBoxGruposDePermisos.Name = "comboBoxGruposDePermisos";
            this.comboBoxGruposDePermisos.Size = new System.Drawing.Size(240, 24);
            this.comboBoxGruposDePermisos.TabIndex = 7;
            this.comboBoxGruposDePermisos.SelectedIndexChanged += new System.EventHandler(this.comboBoxGruposDePermisos_SelectedIndexChanged);
            // 
            // btnAsignarGrupo
            // 
            this.btnAsignarGrupo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAsignarGrupo.Location = new System.Drawing.Point(255, 176);
            this.btnAsignarGrupo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAsignarGrupo.Name = "btnAsignarGrupo";
            this.btnAsignarGrupo.Size = new System.Drawing.Size(247, 55);
            this.btnAsignarGrupo.TabIndex = 8;
            this.btnAsignarGrupo.Tag = "Fpermisos_AsignarGrupo";
            this.btnAsignarGrupo.Text = "Asignar Grupo de Permisos al Usuario";
            this.btnAsignarGrupo.UseVisualStyleBackColor = true;
            this.btnAsignarGrupo.Click += new System.EventHandler(this.btnAsignarGrupo_Click);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 170);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 16);
            this.label2.TabIndex = 9;
            this.label2.Tag = "Fpermisos_Permisos";
            this.label2.Text = "Permisos";
            // 
            // btnBorrarPermiso
            // 
            this.btnBorrarPermiso.Location = new System.Drawing.Point(3, 36);
            this.btnBorrarPermiso.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnBorrarPermiso.Name = "btnBorrarPermiso";
            this.btnBorrarPermiso.Size = new System.Drawing.Size(240, 29);
            this.btnBorrarPermiso.TabIndex = 11;
            this.btnBorrarPermiso.Tag = "Fpermisos_BorrarPermiso";
            this.btnBorrarPermiso.Text = "Borrar Permiso";
            this.btnBorrarPermiso.UseVisualStyleBackColor = true;
            this.btnBorrarPermiso.Click += new System.EventHandler(this.btnBorrarPermiso_Click);
            // 
            // btnQuitarPermisos
            // 
            this.btnQuitarPermisos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnQuitarPermisos.Location = new System.Drawing.Point(255, 235);
            this.btnQuitarPermisos.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnQuitarPermisos.Name = "btnQuitarPermisos";
            this.btnQuitarPermisos.Padding = new System.Windows.Forms.Padding(0, 2, 0, 2);
            this.btnQuitarPermisos.Size = new System.Drawing.Size(247, 54);
            this.btnQuitarPermisos.TabIndex = 12;
            this.btnQuitarPermisos.Tag = "Fpermisos_QuitarPermisos";
            this.btnQuitarPermisos.Text = "Quitar Permisos";
            this.btnQuitarPermisos.UseVisualStyleBackColor = true;
            this.btnQuitarPermisos.Click += new System.EventHandler(this.btnReiniciarPermisos_Click);
            // 
            // dataGridViewPermisosDeUsuarios
            // 
            this.dataGridViewPermisosDeUsuarios.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewPermisosDeUsuarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewPermisosDeUsuarios.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridViewPermisosDeUsuarios.Location = new System.Drawing.Point(513, 317);
            this.dataGridViewPermisosDeUsuarios.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridViewPermisosDeUsuarios.Name = "dataGridViewPermisosDeUsuarios";
            this.dataGridViewPermisosDeUsuarios.RowHeadersWidth = 51;
            this.dataGridViewPermisosDeUsuarios.RowTemplate.Height = 24;
            this.dataGridViewPermisosDeUsuarios.Size = new System.Drawing.Size(505, 223);
            this.dataGridViewPermisosDeUsuarios.TabIndex = 13;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 112);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(130, 16);
            this.label4.TabIndex = 14;
            this.label4.Tag = "Fpermisos_GruposPermisos";
            this.label4.Text = "Grupos de Permisos";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.dataGridViewUsuarios, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.treeViewPermisos, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.dataGridViewPermisosDeUsuarios, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(2, 2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 58.12619F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 41.87381F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1021, 542);
            this.tableLayoutPanel1.TabIndex = 15;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel3, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel4, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.btnAsignarGrupo, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnQuitarPermisos, 1, 1);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(513, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 75.50336F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 24.49664F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(505, 309);
            this.tableLayoutPanel2.TabIndex = 14;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.label4, 0, 3);
            this.tableLayoutPanel3.Controls.Add(this.txtNombreGrupoPermisos, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.label2, 0, 5);
            this.tableLayoutPanel3.Controls.Add(this.comboBoxPermisos, 0, 6);
            this.tableLayoutPanel3.Controls.Add(this.btnCrearGrupo, 0, 2);
            this.tableLayoutPanel3.Controls.Add(this.comboBoxGruposDePermisos, 0, 4);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 7;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.32877F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15.06849F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17.3516F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.87215F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17.80822F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.127209F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.20112F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(246, 227);
            this.tableLayoutPanel3.TabIndex = 13;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel4.ColumnCount = 1;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Controls.Add(this.btnBorrarPermiso, 0, 1);
            this.tableLayoutPanel4.Controls.Add(this.btnAgregarPermiso, 0, 0);
            this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 236);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 2;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 49.25373F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.74627F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(246, 70);
            this.tableLayoutPanel4.TabIndex = 16;
            // 
            // Permisos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1025, 549);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Permisos";
            this.ShowIcon = false;
            this.Text = "Permisos";
            this.Load += new System.EventHandler(this.Permisos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewUsuarios)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPermisosDeUsuarios)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView treeViewPermisos;
        private System.Windows.Forms.ComboBox comboBoxPermisos;
        private System.Windows.Forms.TextBox txtNombreGrupoPermisos;
        private System.Windows.Forms.Button btnCrearGrupo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAgregarPermiso;
        private System.Windows.Forms.DataGridView dataGridViewUsuarios;
        private System.Windows.Forms.ComboBox comboBoxGruposDePermisos;
        private System.Windows.Forms.Button btnAsignarGrupo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnBorrarPermiso;
        private System.Windows.Forms.Button btnQuitarPermisos;
        private System.Windows.Forms.DataGridView dataGridViewPermisosDeUsuarios;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
    }
}