﻿namespace GUI
{
    partial class RegistrarPropiedades
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RegistrarPropiedades));
            this.tbDireccion = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxVivienda = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.numericUpDownAmbientes = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownPisos = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownBaños = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownHabitaciones = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownAntiguedad = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownST = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownSC = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.comboBoxPatio = new System.Windows.Forms.ComboBox();
            this.comboBoxPileta = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.labelPileta = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.comboBoxCochera = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.numericUpDownValorDeCouta = new System.Windows.Forms.NumericUpDown();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.buttonSubirImagenes = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.openFileDialog2 = new System.Windows.Forms.OpenFileDialog();
            this.btnPublicaPropiedad = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnLimpiarImagenes = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.FormRPlableEtiquetas = new System.Windows.Forms.Label();
            this.flowLayoutPanelEtiquetas = new System.Windows.Forms.FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAmbientes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPisos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownBaños)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownHabitaciones)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAntiguedad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownST)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownValorDeCouta)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbDireccion
            // 
            this.tbDireccion.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tbDireccion.Location = new System.Drawing.Point(208, 50);
            this.tbDireccion.Name = "tbDireccion";
            this.tbDireccion.Size = new System.Drawing.Size(150, 22);
            this.tbDireccion.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label1.Location = new System.Drawing.Point(62, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 20);
            this.label1.TabIndex = 3;
            this.label1.Tag = "FormRPlableDireccion";
            this.label1.Text = "Dirección";
            // 
            // comboBoxVivienda
            // 
            this.comboBoxVivienda.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.comboBoxVivienda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxVivienda.FormattingEnabled = true;
            this.comboBoxVivienda.Location = new System.Drawing.Point(208, 8);
            this.comboBoxVivienda.Name = "comboBoxVivienda";
            this.comboBoxVivienda.Size = new System.Drawing.Size(150, 24);
            this.comboBoxVivienda.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label2.Location = new System.Drawing.Point(66, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 20);
            this.label2.TabIndex = 5;
            this.label2.Tag = "FormRPlableVivienda";
            this.label2.Text = "Vivienda";
            // 
            // numericUpDownAmbientes
            // 
            this.numericUpDownAmbientes.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.numericUpDownAmbientes.Location = new System.Drawing.Point(208, 91);
            this.numericUpDownAmbientes.Maximum = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.numericUpDownAmbientes.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownAmbientes.Name = "numericUpDownAmbientes";
            this.numericUpDownAmbientes.Size = new System.Drawing.Size(150, 22);
            this.numericUpDownAmbientes.TabIndex = 2;
            this.numericUpDownAmbientes.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numericUpDownPisos
            // 
            this.numericUpDownPisos.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.numericUpDownPisos.Location = new System.Drawing.Point(208, 173);
            this.numericUpDownPisos.Maximum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.numericUpDownPisos.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownPisos.Name = "numericUpDownPisos";
            this.numericUpDownPisos.Size = new System.Drawing.Size(150, 22);
            this.numericUpDownPisos.TabIndex = 4;
            this.numericUpDownPisos.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numericUpDownBaños
            // 
            this.numericUpDownBaños.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.numericUpDownBaños.Location = new System.Drawing.Point(208, 255);
            this.numericUpDownBaños.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numericUpDownBaños.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownBaños.Name = "numericUpDownBaños";
            this.numericUpDownBaños.Size = new System.Drawing.Size(150, 22);
            this.numericUpDownBaños.TabIndex = 6;
            this.numericUpDownBaños.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numericUpDownHabitaciones
            // 
            this.numericUpDownHabitaciones.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.numericUpDownHabitaciones.Location = new System.Drawing.Point(208, 214);
            this.numericUpDownHabitaciones.Maximum = new decimal(new int[] {
            6,
            0,
            0,
            0});
            this.numericUpDownHabitaciones.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownHabitaciones.Name = "numericUpDownHabitaciones";
            this.numericUpDownHabitaciones.Size = new System.Drawing.Size(150, 22);
            this.numericUpDownHabitaciones.TabIndex = 5;
            this.numericUpDownHabitaciones.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numericUpDownAntiguedad
            // 
            this.numericUpDownAntiguedad.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.numericUpDownAntiguedad.Location = new System.Drawing.Point(413, 255);
            this.numericUpDownAntiguedad.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.numericUpDownAntiguedad.Name = "numericUpDownAntiguedad";
            this.numericUpDownAntiguedad.Size = new System.Drawing.Size(154, 22);
            this.numericUpDownAntiguedad.TabIndex = 8;
            // 
            // numericUpDownST
            // 
            this.numericUpDownST.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.numericUpDownST.Location = new System.Drawing.Point(208, 132);
            this.numericUpDownST.Maximum = new decimal(new int[] {
            900,
            0,
            0,
            0});
            this.numericUpDownST.Minimum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.numericUpDownST.Name = "numericUpDownST";
            this.numericUpDownST.Size = new System.Drawing.Size(150, 22);
            this.numericUpDownST.TabIndex = 3;
            this.numericUpDownST.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            // 
            // numericUpDownSC
            // 
            this.numericUpDownSC.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.numericUpDownSC.Location = new System.Drawing.Point(413, 173);
            this.numericUpDownSC.Maximum = new decimal(new int[] {
            900,
            0,
            0,
            0});
            this.numericUpDownSC.Minimum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.numericUpDownSC.Name = "numericUpDownSC";
            this.numericUpDownSC.Size = new System.Drawing.Size(154, 22);
            this.numericUpDownSC.TabIndex = 7;
            this.numericUpDownSC.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label3.Location = new System.Drawing.Point(58, 92);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 20);
            this.label3.TabIndex = 13;
            this.label3.Tag = "FormRPlableAmbientes";
            this.label3.Text = "Ambientes";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label4.Location = new System.Drawing.Point(77, 174);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 20);
            this.label4.TabIndex = 14;
            this.label4.Tag = "FormRPlablePisos";
            this.label4.Text = "Pisos";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label5.Location = new System.Drawing.Point(74, 256);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 20);
            this.label5.TabIndex = 15;
            this.label5.Tag = "FormRPlableBaños";
            this.label5.Text = "Baños";
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label6.Location = new System.Drawing.Point(49, 215);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(107, 20);
            this.label6.TabIndex = 16;
            this.label6.Tag = "FormRPlableHabitaciones";
            this.label6.Text = "Habitaciones";
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label7.Location = new System.Drawing.Point(413, 215);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(92, 20);
            this.label7.TabIndex = 17;
            this.label7.Tag = "FormRPlableAntiguedad";
            this.label7.Text = "Antiguedad";
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label8.Location = new System.Drawing.Point(23, 133);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(159, 20);
            this.label8.TabIndex = 18;
            this.label8.Tag = "FormRPlableST";
            this.label8.Text = "SuperfieTotal en m2";
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label9.Location = new System.Drawing.Point(413, 133);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(198, 20);
            this.label9.TabIndex = 19;
            this.label9.Tag = "FormRPlableSC";
            this.label9.Text = "SuperficieCubierta en m2";
            // 
            // comboBoxPatio
            // 
            this.comboBoxPatio.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.comboBoxPatio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPatio.FormattingEnabled = true;
            this.comboBoxPatio.Location = new System.Drawing.Point(208, 336);
            this.comboBoxPatio.Name = "comboBoxPatio";
            this.comboBoxPatio.Size = new System.Drawing.Size(154, 24);
            this.comboBoxPatio.TabIndex = 10;
            this.comboBoxPatio.SelectedIndexChanged += new System.EventHandler(this.comboBoxPatio_SelectedIndexChanged);
            // 
            // comboBoxPileta
            // 
            this.comboBoxPileta.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.comboBoxPileta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPileta.FormattingEnabled = true;
            this.comboBoxPileta.Location = new System.Drawing.Point(413, 336);
            this.comboBoxPileta.Name = "comboBoxPileta";
            this.comboBoxPileta.Size = new System.Drawing.Size(154, 24);
            this.comboBoxPileta.TabIndex = 11;
            // 
            // label10
            // 
            this.label10.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label10.Location = new System.Drawing.Point(208, 297);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(47, 20);
            this.label10.TabIndex = 22;
            this.label10.Tag = "FormRPlablePatio";
            this.label10.Text = "Patio";
            // 
            // labelPileta
            // 
            this.labelPileta.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelPileta.AutoSize = true;
            this.labelPileta.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.labelPileta.Location = new System.Drawing.Point(413, 297);
            this.labelPileta.Name = "labelPileta";
            this.labelPileta.Size = new System.Drawing.Size(51, 20);
            this.labelPileta.TabIndex = 23;
            this.labelPileta.Tag = "FormRPlablePileta";
            this.labelPileta.Text = "Pileta";
            // 
            // label12
            // 
            this.label12.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label12.Location = new System.Drawing.Point(66, 297);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(72, 20);
            this.label12.TabIndex = 25;
            this.label12.Tag = "FormRPlableCochera";
            this.label12.Text = "Cochera";
            // 
            // comboBoxCochera
            // 
            this.comboBoxCochera.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.comboBoxCochera.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCochera.FormattingEnabled = true;
            this.comboBoxCochera.Location = new System.Drawing.Point(25, 336);
            this.comboBoxCochera.Name = "comboBoxCochera";
            this.comboBoxCochera.Size = new System.Drawing.Size(154, 24);
            this.comboBoxCochera.TabIndex = 9;
            // 
            // label13
            // 
            this.label13.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label13.Location = new System.Drawing.Point(8, 379);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(188, 20);
            this.label13.TabIndex = 27;
            this.label13.Tag = "FormRPlableValorCuotaMensual";
            this.label13.Text = "Valor de Couta Mensual";
            // 
            // numericUpDownValorDeCouta
            // 
            this.numericUpDownValorDeCouta.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.numericUpDownValorDeCouta.Location = new System.Drawing.Point(32, 424);
            this.numericUpDownValorDeCouta.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.numericUpDownValorDeCouta.Minimum = new decimal(new int[] {
            75000,
            0,
            0,
            0});
            this.numericUpDownValorDeCouta.Name = "numericUpDownValorDeCouta";
            this.numericUpDownValorDeCouta.Size = new System.Drawing.Size(141, 22);
            this.numericUpDownValorDeCouta.TabIndex = 14;
            this.numericUpDownValorDeCouta.Value = new decimal(new int[] {
            75000,
            0,
            0,
            0});
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // buttonSubirImagenes
            // 
            this.buttonSubirImagenes.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.buttonSubirImagenes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.buttonSubirImagenes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSubirImagenes.ForeColor = System.Drawing.Color.Red;
            this.buttonSubirImagenes.Location = new System.Drawing.Point(413, 3);
            this.buttonSubirImagenes.Name = "buttonSubirImagenes";
            this.buttonSubirImagenes.Size = new System.Drawing.Size(151, 35);
            this.buttonSubirImagenes.TabIndex = 12;
            this.buttonSubirImagenes.Tag = "FormRPBotonImagenes";
            this.buttonSubirImagenes.Text = "Subir Imagenes";
            this.buttonSubirImagenes.UseVisualStyleBackColor = false;
            this.buttonSubirImagenes.Click += new System.EventHandler(this.button1_Click);
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // openFileDialog2
            // 
            this.openFileDialog2.FileName = "openFileDialog2";
            // 
            // btnPublicaPropiedad
            // 
            this.btnPublicaPropiedad.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnPublicaPropiedad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPublicaPropiedad.ForeColor = System.Drawing.Color.Red;
            this.btnPublicaPropiedad.Location = new System.Drawing.Point(208, 413);
            this.btnPublicaPropiedad.Name = "btnPublicaPropiedad";
            this.btnPublicaPropiedad.Size = new System.Drawing.Size(155, 40);
            this.btnPublicaPropiedad.TabIndex = 15;
            this.btnPublicaPropiedad.Tag = "FormRPBotonAltaPropiedad";
            this.btnPublicaPropiedad.Text = "Publicar Propiedad";
            this.btnPublicaPropiedad.UseVisualStyleBackColor = false;
            this.btnPublicaPropiedad.Click += new System.EventHandler(this.button2_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Controls.Add(this.comboBoxVivienda, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tbDireccion, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.numericUpDownAmbientes, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.label8, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.numericUpDownST, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.numericUpDownPisos, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.label6, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.numericUpDownHabitaciones, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.numericUpDownBaños, 1, 6);
            this.tableLayoutPanel1.Controls.Add(this.label13, 0, 9);
            this.tableLayoutPanel1.Controls.Add(this.numericUpDownValorDeCouta, 0, 10);
            this.tableLayoutPanel1.Controls.Add(this.label12, 0, 7);
            this.tableLayoutPanel1.Controls.Add(this.comboBoxCochera, 0, 8);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.buttonSubirImagenes, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnLimpiarImagenes, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.label9, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.numericUpDownSC, 2, 4);
            this.tableLayoutPanel1.Controls.Add(this.numericUpDownAntiguedad, 2, 6);
            this.tableLayoutPanel1.Controls.Add(this.label7, 2, 5);
            this.tableLayoutPanel1.Controls.Add(this.label10, 1, 7);
            this.tableLayoutPanel1.Controls.Add(this.comboBoxPatio, 1, 8);
            this.tableLayoutPanel1.Controls.Add(this.labelPileta, 2, 7);
            this.tableLayoutPanel1.Controls.Add(this.comboBoxPileta, 2, 8);
            this.tableLayoutPanel1.Controls.Add(this.btnModificar, 2, 10);
            this.tableLayoutPanel1.Controls.Add(this.btnPublicaPropiedad, 1, 10);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 11;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.09091F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.09091F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.09091F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.09091F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.09091F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.09091F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.09091F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.09091F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.09091F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.09091F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.09091F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(615, 460);
            this.tableLayoutPanel1.TabIndex = 30;
            // 
            // btnLimpiarImagenes
            // 
            this.btnLimpiarImagenes.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnLimpiarImagenes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnLimpiarImagenes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimpiarImagenes.ForeColor = System.Drawing.Color.Red;
            this.btnLimpiarImagenes.Location = new System.Drawing.Point(413, 44);
            this.btnLimpiarImagenes.Name = "btnLimpiarImagenes";
            this.btnLimpiarImagenes.Size = new System.Drawing.Size(151, 35);
            this.btnLimpiarImagenes.TabIndex = 13;
            this.btnLimpiarImagenes.Tag = "FormRPBotonLimpiar";
            this.btnLimpiarImagenes.Text = "Limpiar Imagenes";
            this.btnLimpiarImagenes.UseVisualStyleBackColor = false;
            this.btnLimpiarImagenes.Click += new System.EventHandler(this.btnLimpiarImagenes_Click);
            // 
            // btnModificar
            // 
            this.btnModificar.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnModificar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnModificar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnModificar.ForeColor = System.Drawing.Color.Red;
            this.btnModificar.Location = new System.Drawing.Point(413, 415);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(160, 40);
            this.btnModificar.TabIndex = 16;
            this.btnModificar.Tag = "FormRPBotonModificarPropiedad";
            this.btnModificar.Text = "Modificar Publicacion";
            this.btnModificar.UseVisualStyleBackColor = false;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.BackColor = System.Drawing.Color.Black;
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 61.90987F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 38.09013F));
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel3, 1, 0);
            this.tableLayoutPanel2.ForeColor = System.Drawing.Color.White;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 1);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1004, 466);
            this.tableLayoutPanel2.TabIndex = 31;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.FormRPlableEtiquetas, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.flowLayoutPanelEtiquetas, 0, 1);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(624, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.565217F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 95.43478F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(377, 460);
            this.tableLayoutPanel3.TabIndex = 31;
            // 
            // FormRPlableEtiquetas
            // 
            this.FormRPlableEtiquetas.AutoSize = true;
            this.FormRPlableEtiquetas.Location = new System.Drawing.Point(3, 0);
            this.FormRPlableEtiquetas.Name = "FormRPlableEtiquetas";
            this.FormRPlableEtiquetas.Size = new System.Drawing.Size(66, 16);
            this.FormRPlableEtiquetas.TabIndex = 0;
            this.FormRPlableEtiquetas.Tag = "FRPLabelEtiquetas";
            this.FormRPlableEtiquetas.Text = "Eitiquetas";
            // 
            // flowLayoutPanelEtiquetas
            // 
            this.flowLayoutPanelEtiquetas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanelEtiquetas.Location = new System.Drawing.Point(3, 24);
            this.flowLayoutPanelEtiquetas.Name = "flowLayoutPanelEtiquetas";
            this.flowLayoutPanelEtiquetas.Size = new System.Drawing.Size(371, 433);
            this.flowLayoutPanelEtiquetas.TabIndex = 1;
            // 
            // RegistrarPropiedades
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1009, 469);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(1027, 516);
            this.Name = "RegistrarPropiedades";
            this.Text = "Registrar Propiedades";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAmbientes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPisos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownBaños)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownHabitaciones)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAntiguedad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownST)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownValorDeCouta)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox tbDireccion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxVivienda;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numericUpDownAmbientes;
        private System.Windows.Forms.NumericUpDown numericUpDownPisos;
        private System.Windows.Forms.NumericUpDown numericUpDownBaños;
        private System.Windows.Forms.NumericUpDown numericUpDownHabitaciones;
        private System.Windows.Forms.NumericUpDown numericUpDownAntiguedad;
        private System.Windows.Forms.NumericUpDown numericUpDownST;
        private System.Windows.Forms.NumericUpDown numericUpDownSC;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.ComboBox comboBoxPatio;
        private System.Windows.Forms.ComboBox comboBoxPileta;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label labelPileta;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox comboBoxCochera;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.NumericUpDown numericUpDownValorDeCouta;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button buttonSubirImagenes;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.OpenFileDialog openFileDialog2;
        private System.Windows.Forms.Button btnPublicaPropiedad;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btnLimpiarImagenes;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label FormRPlableEtiquetas;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelEtiquetas;
    }
}