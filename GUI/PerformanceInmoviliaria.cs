using BE;
using BLL;
using GUI.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class PerformanceInmoviliaria : Form
    {
        public PerformanceInmoviliaria()
        {
            InitializeComponent();
            bllCloser = new BLLCloser();
            bllOpinon = new BLLOpinon();
            bllCuenta = new BLLCuenta();
            bllTrato = new BLLTrato();
            CargarClosers();
            LeerSaldo();
            LeerTratosPorMes();
            MostrarCloserDelMes(ObtenerCloserDelMes());
        }
        BLLCloser bllCloser;
        BLLOpinon bllOpinon;
        BLLCuenta bllCuenta;
        BLLTrato bllTrato;
        int contradorDeTratos = 0;


        public void CargarClosers()
        {
            dataGridViewClosers.DataSource = null;
            dataGridViewClosers.DataSource = bllCloser.LeerClosers();
            dataGridViewClosers.Columns["NombreDeUsuario"].Visible = false;
            dataGridViewClosers.Columns["Sector"].Visible = false;
            dataGridViewClosers.Columns["Foto"].Visible = false;
            dataGridViewClosers.Columns["ID"].Visible = false;
            dataGridViewClosers.Columns["DV"].Visible = false;
            dataGridViewClosers.Columns["Mail"].Visible = false;
            dataGridViewClosers.Columns["Clave"].Visible = false;
        }

        public void LeerSaldo()
        {
            try
            {
                labelSaldo.Text = "$" + bllCuenta.LeerSaldoDeCuenta().ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        
        public void CargarOpinionesXCloser(Closer closer)
        {
            
            dataGridViewOpiniones.DataSource = null;
            dataGridViewOpiniones.DataSource = bllOpinon.LeerOpiniones(closer,3);
        }

        private void dataGridViewClosers_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if(dataGridViewClosers.SelectedRows.Count == 1)
                {
                    Closer closer = (Closer)dataGridViewClosers.CurrentRow.DataBoundItem;
                    CargarOpinionesXCloser(closer);
                }
            }
            catch(Exception ex)
            {

            }
        }

        public void LeerTratosPorMes()
        {
            List<Trato> listaTratos = bllTrato.LeerTratos();

            Dictionary<int, int> tratosPorMes = new Dictionary<int, int>();

            for (int mes = 1; mes <= 12; mes++)
            {
                tratosPorMes[mes] = 0;
            }

            foreach (var trato in listaTratos)
            {
                int mes = trato.FechaDeInicio.Month;
                tratosPorMes[mes]++;
            }

            foreach (var mes in tratosPorMes.Keys)
            {
                chartTratosXMes.Series["Tratos Cerrados"].Points.AddXY(mes, tratosPorMes[mes]);
            }

        }

        public Closer ObtenerCloserDelMes()
        {
            List<Trato> tratos = bllTrato.LeerTratos(); 
            Dictionary<Closer, int> tratosPorCloser = new Dictionary<Closer, int>();

            foreach (DataGridViewRow row in dataGridViewClosers.Rows)
            {
                Closer closer = (Closer)row.DataBoundItem; 
                int contadorDeTratos = 0; 

                foreach (Trato t in tratos)
                {
                    if (t.ID_Closer == closer.ID && t.FechaDeInicio.Month == DateTime.Now.Month && t.FechaDeInicio.Year == DateTime.Now.Year)
                    {
                        contadorDeTratos++;
                    }
                }
                tratosPorCloser[closer] = contadorDeTratos;
            }

            Closer closerDelMes = tratosPorCloser.OrderByDescending(kv => kv.Value).FirstOrDefault().Key;

            return closerDelMes;
        }

        public void MostrarCloserDelMes(Closer closer)
        {
            try
            {
                tableLayoutPanelCloserDelMes.Controls.Clear();
                tableLayoutPanelCloserDelMes.RowCount = 1;
                tableLayoutPanelCloserDelMes.ColumnCount = 2;

                tableLayoutPanelCloserDelMes.ColumnStyles.Clear();
                tableLayoutPanelCloserDelMes.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
                tableLayoutPanelCloserDelMes.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));

                Panel panelImagen = new Panel();
                panelImagen.Dock = DockStyle.Fill;

                PictureBox pictureBox = new PictureBox();
                pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
                pictureBox.Dock = DockStyle.Fill;

                if (closer.Foto != null)
                {
                    using (MemoryStream ms = new MemoryStream(closer.Foto))
                    {
                        pictureBox.Image = Image.FromStream(ms);
                    }
                }
                else
                {
                    pictureBox.Image = Resources.UsuarioGenerico;
                }

                panelImagen.Controls.Add(pictureBox);

                Panel panelDescripcion = new Panel();
                panelDescripcion.Dock = DockStyle.Fill;
                panelDescripcion.AutoScroll = true;

                int labelPosY = 20;
                int labelAncho = 100;
                foreach (PropertyInfo propiedad in closer.GetType().GetProperties())
                {
                    if (propiedad.Name != "Foto" && propiedad.Name != "NombreDeUsuario" && propiedad.Name != "DV" && propiedad.Name != "Clave" && propiedad.Name != "Sector" && propiedad.Name != "ID")
                    {
                        Label labelNombre = new Label();
                        labelNombre.Text = propiedad.Name;
                        labelNombre.Location = new Point(10, labelPosY);

                        Label labelValor = new Label();
                        labelValor.Text = propiedad.GetValue(closer)?.ToString();
                        labelValor.Location = new Point(150, labelPosY);

                        panelDescripcion.Controls.Add(labelNombre);
                        panelDescripcion.Controls.Add(labelValor);

                        labelPosY += 30;
                    }
                }
                labelPosY += 20;

                tableLayoutPanelCloserDelMes.Controls.Add(panelImagen, 0, 0);
                tableLayoutPanelCloserDelMes.Controls.Add(panelDescripcion, 1, 0);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                this.Close();
            }
        }
    }
}
