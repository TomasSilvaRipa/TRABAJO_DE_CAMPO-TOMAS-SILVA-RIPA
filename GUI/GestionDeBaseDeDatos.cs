using BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
                string path = @"C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\Backup\";
                bllBackUp.BackUp(1, path);
            } 
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
