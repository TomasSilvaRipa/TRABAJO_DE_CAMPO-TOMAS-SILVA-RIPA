using BE;
using BLL;
using Servicios;
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
    public partial class VerReunionesCliente : FIdiomaActualizable,IObservador
    {
        
        public VerReunionesCliente()
        {
            InitializeComponent();
            bllReunion = new BLLReunion();
            bllCliente = new BLLCliente();
            usuario = Sesion.ObtenerSesion().ObtenerUsuario();
            clienteActivos = bllCliente.LeerCliente(usuario.ID,1); 
            CargarReuniones();
            Sesion.ObtenerSesion().AgregarObservador(this);
            actualizarTablaIdiomas();
            Notificar(this);
        }
        BLLReunion bllReunion;
        BLLCliente bllCliente;
        Cliente clienteActivos;
        Usuario usuario;
        DataTable tablaIdioma;

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

        public void CargarReuniones()
        {
            dataGridViewReuniones.DataSource = null;
            List<Reunion> reuniones = bllReunion.LeerReunionPorCliente(clienteActivos);
            if (reuniones != null && reuniones.Count > 0)
            {
                dataGridViewReuniones.DataSource = reuniones;
                dataGridViewReuniones.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridViewReuniones.Columns["ID_Cliente"].Visible = false;
                dataGridViewReuniones.Columns["ID_Closer"].Visible = false;
                dataGridViewReuniones.Columns["ID"].Visible = false;
                dataGridViewReuniones.Columns["ID_Vivienda"].Visible = false;
            }
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
