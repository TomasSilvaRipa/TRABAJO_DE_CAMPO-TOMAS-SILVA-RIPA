using BE;
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

namespace GUI
{
    public partial class VerReunionesCliente : Form
    {
        public VerReunionesCliente()
        {
            InitializeComponent();
            bllReunion = new BLLReunion();
            bllCliente = new BLLCliente();
            usuario = Sesion.ObtenerSesion().ObtenerUsuario();
            clienteActivos = bllCliente.LeerCliente(usuario.ID,1); 
            CargarReuniones();
        }
        BLLReunion bllReunion;
        BLLCliente bllCliente;
        Cliente clienteActivos;
        Usuario usuario;
        public void CargarReuniones()
        {
            dataGridViewReuniones.DataSource = null;
            dataGridViewReuniones.DataSource = bllReunion.LeerReunionPorCliente(clienteActivos);
        }

        private void buttonCancelarReunion_Click(object sender, EventArgs e)
        {
            try
            {
                if(dataGridViewReuniones.SelectedRows.Count == 1)
                {
                    Reunion reunion = (Reunion)dataGridViewReuniones.CurrentRow.DataBoundItem;
                    if (bllReunion.CancelarReunion(reunion))
                    {
                        MessageBox.Show("Reunion del " + reunion.Fecha + " Cancelada");
                    }
                }
                else
                {
                    MessageBox.Show("Seleccione una reunion a cancelar");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
