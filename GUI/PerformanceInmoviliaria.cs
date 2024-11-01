using BE;
using BLL;
using GUI.Properties;
using iTextSharp.text;
using iText.Layout;
using iTextSharp.text.pdf;
using iText.Kernel.Pdf;
using iText.Layout.Element;
using iText.Layout.Properties;
using iText.IO.Image;
using System.Windows.Forms;
using System.Drawing;
using System.IO;
using Servicios;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Windows.Forms.DataVisualization.Charting;


namespace GUI
{
    public partial class PerformanceInmoviliaria : FIdiomaActualizable, IObservador
    {
        public PerformanceInmoviliaria()
        {
            InitializeComponent();
            bllCloser = new BLLCloser();
            bllOpinon = new BLLOpinon();
            bllCuenta = new BLLCuenta();
            bllTrato = new BLLTrato();
            bllIdiomas = new BLLIdiomas();
            CargarClosers();
            LeerSaldo();
            LeerTratosPorMes();
            MostrarCloserDelMes(ObtenerCloserDelMes());
            Sesion.ObtenerSesion().AgregarObservador(this);
            actualizarTablaIdiomas();
        }
        BLLCloser bllCloser;
        BLLOpinon bllOpinon;
        BLLCuenta bllCuenta;
        BLLTrato bllTrato;
        DataTable tablaIdioma;
        BLLIdiomas bllIdiomas;
        int contradorDeTratos = 0;


        private void actualizarTablaIdiomas()
        {
            Sesion.ObtenerSesion().ActualizarIdiomas();
            tablaIdioma = Sesion.ObtenerSesion().tablaIdioma;

        }

        public void Notificar(object Sender)
        {

            if (Sender is FTraducciones)
            {
                actualizarTablaIdiomas();
            }
            else
            {
                actualizarIdioma();
            }

        }

        public class FormData
        {
            public string Title { get; set; }
            public List<LabelData> Labels { get; set; } = new List<LabelData>();
            public string VendedorDelMes { get; set; } 
            public string Saldo { get; set; }
            public List<Closer> Closers { get; set; } = new List<Closer>();
            public List<string> Catalogo { get; set; }
            public List<string> ChartData { get; set; }

        }

        public class LabelData
        {
            public string Text { get; set; }
        }

        public class DataGridViewData
        {
            public List<List<string>> Rows { get; set; } = new List<List<string>>();
        }

        public class ImageData
        {
            public byte[] ImageBytes { get; set; }
        }

        public class ChartData
        {
            public byte[] ChartImageBytes { get; set; }
        }

        public void CargarClosers()
        {
            dataGridViewClosers.DataSource = null;
            dataGridViewClosers.DataSource = bllCloser.LeerClosers();
            dataGridViewClosers.Columns["NombreDeUsuario"].Visible = false;
            dataGridViewClosers.Columns["Sector"].Visible = false;
            dataGridViewClosers.Columns["Foto"].Visible = false;
            dataGridViewClosers.Columns["ID"].Visible = false;
            dataGridViewClosers.Columns["DV"].Visible = false;
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
                        pictureBox.Image = System.Drawing.Image.FromStream(ms);
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
                    if (propiedad.Name != "ID_Usuario" && propiedad.Name != "Foto" && propiedad.Name != "NombreDeUsuario" && propiedad.Name != "DV" && propiedad.Name != "Clave" && propiedad.Name != "Sector" && propiedad.Name != "ID")
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

        private void btnPdf_Click(object sender, EventArgs e)
        {
            try
            {
                GeneratePdf();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        

        public void GeneratePdf()
        {
            string fecha = DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss");
            string filePath = @"pdf_"+ fecha + ".pdf";

            // Crear el escritor PDF
            iText.Kernel.Pdf.PdfWriter writer = new iText.Kernel.Pdf.PdfWriter(filePath);

            // Crear el documento PDF
            iText.Kernel.Pdf.PdfDocument pdf = new iText.Kernel.Pdf.PdfDocument(writer);
            iText.Layout.Document document = new iText.Layout.Document(pdf);

            // Título del documento
            iText.Layout.Element.Paragraph title = new iText.Layout.Element.Paragraph("Reporte de Performance")
                .SetFontSize(18)
                .SetBold()
                .SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER);
            document.Add(title);

            // Línea separadora
            document.Add(new iText.Layout.Element.Paragraph("────────────────────────────────────────────────────────────────"));

            // Crear y agregar una lista
            iText.Layout.Element.List list = new iText.Layout.Element.List()
                .SetSymbolIndent(12)
                .SetListSymbol("\u2022");

            // Método para procesar controles
            void ProcessControl(Control control)
            {
                if (control is Label label)
                {
                    // Evitar agregar títulos no deseados como "Opiniones" o "Vendedor del Mes" repetido
                    if (label.Text != "Vendedor del Mes" && label.Text != "Opiniones" && label.Text != "Saldo" && label.Text != "Tratos Cerrados por Mes" && !label.Text.Contains("$"))
                    {
                        list.Add(new iText.Layout.Element.ListItem(label.Text));
                    }
                }
                else if (control is DataGridView dataGridView)
                {
                    if (dataGridView.Name == "dataGridViewClosers")
                    {
                        for (int i = 0; i < dataGridView.Rows.Count; i++)
                        {
                            var rowData = string.Join(", ", dataGridView.Rows[i].Cells.Cast<DataGridViewCell>()
                                .Where(c => c.Value != null && !string.IsNullOrEmpty(c.Value.ToString()) && !(c.Value is byte[]) && !(c.Value is int)) // Excluir valores numéricos no deseados
                                .Select(c => c.Value.ToString()));

                            list.Add(new iText.Layout.Element.ListItem(rowData));
                        }
                    }
                }
                else if (control is PictureBox pictureBox)
                {
                    if (pictureBox.Image != null)
                    {
                        using (MemoryStream ms = new MemoryStream())
                        {
                            pictureBox.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                            iText.Layout.Element.Image pdfImage = new iText.Layout.Element.Image(iText.IO.Image.ImageDataFactory.Create(ms.ToArray()));
                            document.Add(pdfImage.SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER));
                        }
                    }
                }
                else if (control is Chart chart)
                {
                    // Guardar el tamaño y estado original del form
                    var originalFormSize = this.Size;
                    var originalFormWindowState = this.WindowState;

                    // Maximizar el formulario temporalmente
                    this.WindowState = FormWindowState.Maximized;
                    this.Refresh(); // Asegurarse de que el formulario se refresque en su nuevo estado

                    // Crear un Bitmap con el tamaño del chart maximizado
                    using (Bitmap bitmap = new Bitmap(chart.Width, chart.Height))
                    {
                        // Dibujar el chart en el Bitmap
                        chart.DrawToBitmap(bitmap, new System.Drawing.Rectangle(0, 0, chart.Width, chart.Height));

                        // Guardar la imagen del chart en un MemoryStream para agregarla al PDF
                        using (MemoryStream ms = new MemoryStream())
                        {
                            bitmap.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                            iText.Layout.Element.Image pdfChartImage = new iText.Layout.Element.Image(iText.IO.Image.ImageDataFactory.Create(ms.ToArray()));

                            // Agregar la imagen del chart al PDF
                            document.Add(pdfChartImage.SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER));
                        }
                    }

                    // Restaurar el estado y tamaño original del formulario
                    this.WindowState = originalFormWindowState;
                    this.Size = originalFormSize;
                }
                else if (control is TableLayoutPanel tableLayout)
                {
                    if (tableLayout.Name == "tableLayoutPanelOpiniones") return;

                    foreach (Control item in tableLayout.Controls)
                    {
                        ProcessControl(item);
                    }
                }
            }

            // Agregar datos del Closer del Mes
            void AgregarCloserDelMes(Closer closer)
            {
                document.Add(new iText.Layout.Element.Paragraph("Vendedor del Mes").SetFontSize(16).SetBold());

                // Crear una tabla con 2 columnas para la imagen y los detalles
                iText.Layout.Element.Table table = new iText.Layout.Element.Table(2); // 2 columnas

                // Columna de la imagen
                if (closer.Foto != null)
                {
                    using (MemoryStream ms = new MemoryStream(closer.Foto))
                    {
                        iText.Layout.Element.Image pdfImage = new iText.Layout.Element.Image(iText.IO.Image.ImageDataFactory.Create(ms.ToArray()));
                        table.AddCell(new iText.Layout.Element.Cell().Add(pdfImage.SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER)));
                    }
                }

                // Columna de los detalles
                iText.Layout.Element.Cell detallesCell = new iText.Layout.Element.Cell();
                foreach (PropertyInfo propiedad in closer.GetType().GetProperties())
                {
                    if (propiedad.Name != "Foto" && propiedad.Name != "NombreDeUsuario" && propiedad.Name != "DV" && propiedad.Name != "Clave" && propiedad.Name != "Sector" && propiedad.Name != "ID")
                    {
                        string propiedadTexto = $"{propiedad.Name}: {propiedad.GetValue(closer)?.ToString()}";
                        detallesCell.Add(new iText.Layout.Element.Paragraph(propiedadTexto));
                    }
                }

                // Agregar los detalles a la segunda columna
                table.AddCell(detallesCell);

                // Añadir la tabla al documento
                document.Add(table);
            }

            // Procesar todos los controles en el formulario
            foreach (var control in this.Controls)
            {
                ProcessControl(control as Control);
            }

            // Mostrar Closer del Mes (ejemplo de cómo llamar a la función con un objeto closer)
            Closer closerDelMes = ObtenerCloserDelMes(); // Función que obtendría el Closer del Mes
            AgregarCloserDelMes(closerDelMes);

            // Agregar el saldo de la cuenta
            document.Add(new iText.Layout.Element.Paragraph("Saldo: $0,0000").SetFontSize(16).SetBold().SetFontColor(iText.Kernel.Colors.ColorConstants.GREEN));

            // Agregar la lista generada de datos
            document.Add(list);

            // Cerrar el documento
            document.Close();

            MessageBox.Show("PDF generado exitosamente en " + filePath);
        }

        private void PerformanceInmoviliaria_SizeChanged(object sender, EventArgs e)
        {
            if(this.Size == MinimumSize)
            {
                MostrarCloserDelMes(ObtenerCloserDelMes());
            }
        }

        private void btnSerializar_Click(object sender, EventArgs e)
        {
            try
            {
                ExportFormToJson();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public FormData ExtractFormData()
        {
            List<Closer> closers = new List<Closer>();
            var formData = new FormData
            {
                Title = "Reporte de Performance",
                VendedorDelMes = "Pablo Perez",
                Saldo = "$"+  (0.0M).ToString(), // Cambia este valor si tienes un campo para el saldo
                Closers = closers, 
                Catalogo = new List<string>(),
                ChartData = new List<string>()
            };

            // Extraer datos del DataGridView de los closers
            foreach (DataGridViewRow row in dataGridViewClosers.Rows)
            {
                if (row.IsNewRow) continue; // Ignorar la última fila en blanco
                var closer = new Closer
                {
                    Nombre = row.Cells["Nombre"].Value?.ToString(),
                    Apellido = row.Cells["Apellido"].Value?.ToString(),
                    Clasificacion = row.Cells["Clasificacion"].Value?.ToString(),
                    TratosCerrados = Convert.ToInt32(row.Cells["TratosCerrados"].Value ?? 0),
                    Comision = Convert.ToString(row.Cells["Comision"].Value ?? 0.0),
                    Mail = row.Cells["Mail"].Value?.ToString(),
                    

                };
                formData.Closers.Add(closer);
            }

            // Extraer datos de las etiquetas del catálogo
            foreach (var control in tableLayoutPanelCloserDelMes.Controls)
            {
                if (control is Label label)
                {
                    formData.Catalogo.Add(label.Text);
                }
            }

            // Extraer datos del Chart
            foreach (var series in chartTratosXMes.Series)
            {
                foreach (var point in series.Points)
                {
                    formData.ChartData.Add($"Mes: {point.XValue}, Ventas: {point.YValues[0]}");
                }
            }

            return formData;
        }


        public void SaveFormDataToJson(FormData formData, string filePath)
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault // Ignorar propiedades con valores por defecto
            };

            string jsonString = JsonSerializer.Serialize(formData, options);
            File.WriteAllText(filePath, jsonString);
        }

        public void ExportFormToJson()
        {
            FormData formData = ExtractFormData();
            string fecha = DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss");
            string filePath = @"DataForm" + fecha +".json"; // Cambia esta ruta a la ubicación deseada
            SaveFormDataToJson(formData, filePath);
            MessageBox.Show("Formulario exportado a JSON correctamente en " + filePath);
        }

    }
}
