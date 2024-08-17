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
            this.label3 = new System.Windows.Forms.Label();
            this.btnBorrarPermiso = new System.Windows.Forms.Button();
            this.btnQuitarPermisos = new System.Windows.Forms.Button();
            this.dataGridViewPermisosDeUsuarios = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewUsuarios)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPermisosDeUsuarios)).BeginInit();
            this.SuspendLayout();
            // 
            // treeViewPermisos
            // 
            this.treeViewPermisos.Location = new System.Drawing.Point(12, 12);
            this.treeViewPermisos.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.treeViewPermisos.Name = "treeViewPermisos";
            this.treeViewPermisos.Size = new System.Drawing.Size(457, 269);
            this.treeViewPermisos.TabIndex = 0;
            // 
            // comboBoxPermisos
            // 
            this.comboBoxPermisos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPermisos.FormattingEnabled = true;
            this.comboBoxPermisos.Location = new System.Drawing.Point(495, 175);
            this.comboBoxPermisos.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBoxPermisos.Name = "comboBoxPermisos";
            this.comboBoxPermisos.Size = new System.Drawing.Size(231, 24);
            this.comboBoxPermisos.TabIndex = 1;
            // 
            // txtNombreGrupoPermisos
            // 
            this.txtNombreGrupoPermisos.Location = new System.Drawing.Point(491, 30);
            this.txtNombreGrupoPermisos.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtNombreGrupoPermisos.Name = "txtNombreGrupoPermisos";
            this.txtNombreGrupoPermisos.Size = new System.Drawing.Size(233, 22);
            this.txtNombreGrupoPermisos.TabIndex = 2;
            // 
            // btnCrearGrupo
            // 
            this.btnCrearGrupo.Location = new System.Drawing.Point(491, 58);
            this.btnCrearGrupo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCrearGrupo.Name = "btnCrearGrupo";
            this.btnCrearGrupo.Size = new System.Drawing.Size(235, 39);
            this.btnCrearGrupo.TabIndex = 3;
            this.btnCrearGrupo.Tag = "Fpermisos_CrearGrupo";
            this.btnCrearGrupo.Text = "Crear Nuevo Grupo De Permisos";
            this.btnCrearGrupo.UseVisualStyleBackColor = true;
            this.btnCrearGrupo.Click += new System.EventHandler(this.btnCrearGrupo_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(487, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 16);
            this.label1.TabIndex = 4;
            this.label1.Tag = "Fpermisos_NombreGrupo";
            this.label1.Text = "Nombre del Grupo";
            // 
            // btnAgregarPermiso
            // 
            this.btnAgregarPermiso.Location = new System.Drawing.Point(495, 215);
            this.btnAgregarPermiso.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAgregarPermiso.Name = "btnAgregarPermiso";
            this.btnAgregarPermiso.Size = new System.Drawing.Size(229, 30);
            this.btnAgregarPermiso.TabIndex = 5;
            this.btnAgregarPermiso.Tag = "Fpermisos_AgregarPermiso";
            this.btnAgregarPermiso.Text = "Agregar Permiso";
            this.btnAgregarPermiso.UseVisualStyleBackColor = true;
            this.btnAgregarPermiso.Click += new System.EventHandler(this.btnAgregarPermiso_Click);
            // 
            // dataGridViewUsuarios
            // 
            this.dataGridViewUsuarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewUsuarios.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridViewUsuarios.Location = new System.Drawing.Point(12, 304);
            this.dataGridViewUsuarios.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridViewUsuarios.Name = "dataGridViewUsuarios";
            this.dataGridViewUsuarios.RowHeadersWidth = 51;
            this.dataGridViewUsuarios.RowTemplate.Height = 24;
            this.dataGridViewUsuarios.Size = new System.Drawing.Size(457, 225);
            this.dataGridViewUsuarios.TabIndex = 6;
            this.dataGridViewUsuarios.SelectionChanged += new System.EventHandler(this.dataGridViewUsuarios_SelectionChanged);
            // 
            // comboBoxGruposDePermisos
            // 
            this.comboBoxGruposDePermisos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxGruposDePermisos.FormattingEnabled = true;
            this.comboBoxGruposDePermisos.Location = new System.Drawing.Point(493, 121);
            this.comboBoxGruposDePermisos.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBoxGruposDePermisos.Name = "comboBoxGruposDePermisos";
            this.comboBoxGruposDePermisos.Size = new System.Drawing.Size(231, 24);
            this.comboBoxGruposDePermisos.TabIndex = 7;
            this.comboBoxGruposDePermisos.SelectedIndexChanged += new System.EventHandler(this.comboBoxGruposDePermisos_SelectedIndexChanged);
            // 
            // btnAsignarGrupo
            // 
            this.btnAsignarGrupo.Location = new System.Drawing.Point(733, 30);
            this.btnAsignarGrupo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAsignarGrupo.Name = "btnAsignarGrupo";
            this.btnAsignarGrupo.Size = new System.Drawing.Size(172, 65);
            this.btnAsignarGrupo.TabIndex = 8;
            this.btnAsignarGrupo.Tag = "Fpermisos_AsignarGrupo";
            this.btnAsignarGrupo.Text = "Asignar Grupo de Permisos al Usuario";
            this.btnAsignarGrupo.UseVisualStyleBackColor = true;
            this.btnAsignarGrupo.Click += new System.EventHandler(this.btnAsignarGrupo_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(495, 156);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 16);
            this.label2.TabIndex = 9;
            this.label2.Tag = "Fpermisos_Permisos";
            this.label2.Text = "Permisos";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(495, 102);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 16);
            this.label3.TabIndex = 10;
            this.label3.Tag = "Fpermisos_Permisos";
            // 
            // btnBorrarPermiso
            // 
            this.btnBorrarPermiso.Location = new System.Drawing.Point(493, 251);
            this.btnBorrarPermiso.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnBorrarPermiso.Name = "btnBorrarPermiso";
            this.btnBorrarPermiso.Size = new System.Drawing.Size(229, 30);
            this.btnBorrarPermiso.TabIndex = 11;
            this.btnBorrarPermiso.Tag = "Fpermisos_BorrarPermiso";
            this.btnBorrarPermiso.Text = "Borrar Permiso";
            this.btnBorrarPermiso.UseVisualStyleBackColor = true;
            this.btnBorrarPermiso.Click += new System.EventHandler(this.btnBorrarPermiso_Click);
            // 
            // btnQuitarPermisos
            // 
            this.btnQuitarPermisos.Location = new System.Drawing.Point(733, 107);
            this.btnQuitarPermisos.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnQuitarPermisos.Name = "btnQuitarPermisos";
            this.btnQuitarPermisos.Size = new System.Drawing.Size(172, 65);
            this.btnQuitarPermisos.TabIndex = 12;
            this.btnQuitarPermisos.Tag = "Fpermisos_QuitarPermisos";
            this.btnQuitarPermisos.Text = "Quitar Permisos";
            this.btnQuitarPermisos.UseVisualStyleBackColor = true;
            this.btnQuitarPermisos.Click += new System.EventHandler(this.btnReiniciarPermisos_Click);
            // 
            // dataGridViewPermisosDeUsuarios
            // 
            this.dataGridViewPermisosDeUsuarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewPermisosDeUsuarios.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridViewPermisosDeUsuarios.Location = new System.Drawing.Point(475, 305);
            this.dataGridViewPermisosDeUsuarios.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridViewPermisosDeUsuarios.Name = "dataGridViewPermisosDeUsuarios";
            this.dataGridViewPermisosDeUsuarios.RowHeadersWidth = 51;
            this.dataGridViewPermisosDeUsuarios.RowTemplate.Height = 24;
            this.dataGridViewPermisosDeUsuarios.Size = new System.Drawing.Size(457, 225);
            this.dataGridViewPermisosDeUsuarios.TabIndex = 13;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(495, 102);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(130, 16);
            this.label4.TabIndex = 14;
            this.label4.Tag = "Fpermisos_GruposPermisos";
            this.label4.Text = "Grupos de Permisos";
            // 
            // Permisos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(940, 542);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dataGridViewPermisosDeUsuarios);
            this.Controls.Add(this.btnQuitarPermisos);
            this.Controls.Add(this.btnBorrarPermiso);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnAsignarGrupo);
            this.Controls.Add(this.comboBoxGruposDePermisos);
            this.Controls.Add(this.dataGridViewUsuarios);
            this.Controls.Add(this.btnAgregarPermiso);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCrearGrupo);
            this.Controls.Add(this.txtNombreGrupoPermisos);
            this.Controls.Add(this.comboBoxPermisos);
            this.Controls.Add(this.treeViewPermisos);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Permisos";
            this.Text = "Permisos";
            this.Load += new System.EventHandler(this.Permisos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewUsuarios)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPermisosDeUsuarios)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

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
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnBorrarPermiso;
        private System.Windows.Forms.Button btnQuitarPermisos;
        private System.Windows.Forms.DataGridView dataGridViewPermisosDeUsuarios;
        private System.Windows.Forms.Label label4;
    }
}