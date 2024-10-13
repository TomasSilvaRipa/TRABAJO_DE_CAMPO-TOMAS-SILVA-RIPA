using BE;
using BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class VerReuniones : Form
    {
        public VerReuniones()
        {
            InitializeComponent();
            bllReunion = new BLLReunion();
            bllCliente = new BLLCliente();
            bllTrato = new BLLTrato();
            bllOpinion = new BLLOpinon();
            CargarReuniones();
        }
        BLLReunion bllReunion;
        BLLCliente bllCliente;
        BLLTrato bllTrato;
        BLLOpinon bllOpinion;

        private void VerReuniones_Load(object sender, EventArgs e)
        {

        }

        public void CargarReuniones()
        {
            dataGridViewReuniones.DataSource = null;
            dataGridViewReuniones.DataSource = bllReunion.LeerReuniones();
        }

        private void dataGridViewReuniones_SelectionChanged(object sender, EventArgs e)
        {
            if(dataGridViewReuniones.SelectedRows.Count == 1)
            {
                MostrarCliente();
            }
        }

        public void MostrarCliente()
        {
            try
            {
                Reunion reunion = (Reunion)dataGridViewReuniones.CurrentRow.DataBoundItem;
                Cliente cliente = bllCliente.LeerCliente(reunion.ID_Cliente, 2);
                tableLayoutPanelPersonaDeReunion.Controls.Clear();
                tableLayoutPanelPersonaDeReunion.RowCount = 1;
                tableLayoutPanelPersonaDeReunion.ColumnCount = 2;

                tableLayoutPanelPersonaDeReunion.ColumnStyles.Clear();
                tableLayoutPanelPersonaDeReunion.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
                tableLayoutPanelPersonaDeReunion.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));

                Panel panelImagen = new Panel();
                panelImagen.Dock = DockStyle.Fill;

                PictureBox pictureBox = new PictureBox();
                pictureBox.SizeMode = PictureBoxSizeMode.Zoom;  
                pictureBox.Dock = DockStyle.Fill;

                if (cliente.Foto != null)
                {
                    using (MemoryStream ms = new MemoryStream(cliente.Foto))
                    {
                        pictureBox.Image = Image.FromStream(ms);
                    }
                }

                panelImagen.Controls.Add(pictureBox);

                Panel panelDescripcion = new Panel();
                panelDescripcion.Dock = DockStyle.Fill;
                panelDescripcion.AutoScroll = true;

                int labelPosY = 20;
                int labelAncho = 100;
                foreach (PropertyInfo propiedad in cliente.GetType().GetProperties())
                {
                    if (propiedad.Name != "Foto" && propiedad.Name != "NombreDeUsuario" && propiedad.Name != "DV" && propiedad.Name != "Clave" && propiedad.Name != "Sector" && propiedad.Name != "ID")
                    {
                        Label labelNombre = new Label();
                        labelNombre.Text = propiedad.Name;
                        labelNombre.Location = new Point(10, labelPosY);

                        Label labelValor = new Label();
                        labelValor.Text = propiedad.GetValue(cliente)?.ToString();
                        labelValor.Location = new Point(150, labelPosY);

                        panelDescripcion.Controls.Add(labelNombre);
                        panelDescripcion.Controls.Add(labelValor);

                        labelPosY += 30;
                    }
                }
                labelPosY += 20;

                Label labelFechaInicio = new Label();
                labelFechaInicio.Text = "Fecha de Inicio:";
                labelFechaInicio.Location = new Point(10, labelPosY);

                DateTimePicker dtpFechaInicio = new DateTimePicker();
                dtpFechaInicio.Format = DateTimePickerFormat.Short;
                dtpFechaInicio.Location = new Point(labelAncho + 20, labelPosY);
                dtpFechaInicio.Width = 80;

                panelDescripcion.Controls.Add(labelFechaInicio);
                panelDescripcion.Controls.Add(dtpFechaInicio);

                labelPosY += 30;

                Label labelFechaFin = new Label();
                labelFechaFin.Text = "Fecha de Finalización:";
                labelFechaFin.Location = new Point(10, labelPosY);
                labelFechaFin.Height = 40;
                DateTimePicker dtpFechaFin = new DateTimePicker();
                dtpFechaFin.Format = DateTimePickerFormat.Short;
                dtpFechaFin.Width = 80;
                dtpFechaFin.Location = new Point(labelAncho + 20, labelPosY);

                panelDescripcion.Controls.Add(labelFechaFin);
                panelDescripcion.Controls.Add(dtpFechaFin);

                labelPosY += 40;

                Button btnCerrarTrato = new Button();
                btnCerrarTrato.Text = "CerrarTrato";
                btnCerrarTrato.Width = 120;
                btnCerrarTrato.Location = new Point(10, labelPosY);
                btnCerrarTrato.Click += (s, e) =>
                {
                    DateTime fechaInicio = dtpFechaInicio.Value;
                    DateTime fechaFin = dtpFechaFin.Value;

                    CerrarTrato(fechaInicio, fechaFin);
                };

                labelPosY += 30;
                panelDescripcion.Controls.Add(btnCerrarTrato);

                tableLayoutPanelPersonaDeReunion.Controls.Add(panelImagen, 0, 0);
                tableLayoutPanelPersonaDeReunion.Controls.Add(panelDescripcion, 1, 0);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                this.Close();
            }
        }


        public void CerrarTrato(DateTime fechaInicio, DateTime fechaFin)
        {
            try
            {
                if( fechaInicio < fechaFin && fechaInicio >= DateTime.Now)
                {
                    Reunion reunion = (Reunion)dataGridViewReuniones.CurrentRow.DataBoundItem;
                    Trato trato = new Trato(reunion.ID_Closer, reunion.ID_Cliente, reunion.ID_Vivienda, fechaInicio, fechaFin);
                    if(richTextBoxCloser.Text != "" && richTextBoxCliente.Text != "")
                    {
                        Opinion opinionCloser = new Opinion(trato.ID_Closer, richTextBoxCloser.Text, (int)numericUpDownCloser.Value);
                        Opinion opinionCliente = new Opinion(trato.ID_Cliente, richTextBoxCliente.Text, (int)numericUpDownCliente.Value);
                        if (bllTrato.AltaTrato(trato) && bllOpinion.AltaOpinion(opinionCloser) && bllOpinion.AltaOpinion(opinionCliente))
                        {
                            CargarReuniones();
                            MessageBox.Show("Trato Cerrado Exitosamente");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Campo reseña incompleto");
                    }
                    
                }
                else
                {
                    MessageBox.Show("Eliga fechas coherentes para el trato");
                }
                
            }
            catch(Exception ex)
            {

            }
        }
    }
}
