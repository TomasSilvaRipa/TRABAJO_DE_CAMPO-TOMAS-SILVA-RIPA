using BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace GUI
{
    public partial class GestionDeBaseDeDatos : Form
    {
        public GestionDeBaseDeDatos()
        {
            InitializeComponent();
            bllBackUp = new BLLBackUp();
        }
        BLLBackUp bllBackUp;

        
        
        private void btnRestore_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Multiselect = false;
                openFileDialog.Filter = "Archivos de BackUp (*.bak)|*.bak";
                openFileDialog.Title = "Seleccione un backup";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    foreach (string file in openFileDialog.FileNames)
                    {
                        bllBackUp.Restore(2, file);
                    }
                    MessageBox.Show("Restore Exitoso");
                    Application.Restart();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string backupPath = Path.Combine(@"C:\Users\Public", "Backups-RentHub");

                // Crear la carpeta si no existe
                if (!Directory.Exists(backupPath))
                {
                    Directory.CreateDirectory(backupPath);
                }

                // Generar el archivo de backup
                string backupFile = System.IO.Path.Combine(backupPath, $"TPGrupal_Backup_{DateTime.Now:yyyy-MM-dd_HH-mm-ss}.bak");
                if (bllBackUp.BackUp(1, backupPath))
                {
                    MessageBox.Show("BackUp realizado");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
