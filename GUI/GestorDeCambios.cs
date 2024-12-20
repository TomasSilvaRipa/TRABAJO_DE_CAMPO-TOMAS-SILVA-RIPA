﻿using BE;
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
    public partial class GestorDeCambios : FIdiomaActualizable, IObservador 
    {
        BLLUsuario bllUsuarios;
        public GestorDeCambios()
        {
            InitializeComponent();
            bllUsuarios = new BLLUsuario();
            CargarUsuarios();
            CargarHistoricoDeUsuario();
            Sesion.ObtenerSesion().AgregarObservador(this);
            actualizarTablaIdiomas();
            Notificar(this);
        }
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

        public void CargarUsuarios()
        {
            comboBoxUsuarios.DataSource = null;
            comboBoxUsuarios.DataSource = bllUsuarios.LeerUsuarios();
        }



        public void CargarHistoricoDeUsuario()
        {
            Usuario usuario = (Usuario)comboBoxUsuarios.SelectedItem;
            dataGridViewHistoricoUsuario.DataSource = null;
            dataGridViewHistoricoUsuario.DataSource = bllUsuarios.LeerHistoricoDeUsuario(usuario.NombreDeUsuario);
            dataGridViewHistoricoUsuario.ReadOnly = true;
            dataGridViewHistoricoUsuario.Columns["DigitoVerificador"].Visible = false;
            dataGridViewHistoricoUsuario.Columns["Clave"].Visible = false;
            dataGridViewHistoricoUsuario.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void GestorDeCambios_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridViewHistoricoUsuario.SelectedRows.Count == 1)
                {
                    GestorDeUsuario gc = (GestorDeUsuario)dataGridViewHistoricoUsuario.CurrentRow.DataBoundItem;
                    Usuario usuario = new Usuario();
                    usuario.NombreDeUsuario = gc.Nombre;
                    usuario.Clave = gc.Clave;
                    usuario.Sector = gc.Sector;
                    usuario.Mail = gc.Mail;
                    usuario.DV = bllUsuarios.CalcularDigitoVerificadorHorizontal(usuario);                  
                    if (bllUsuarios.ActualizarUsuario(usuario,1))
                    {
                        CargarHistoricoDeUsuario();
                        MessageBox.Show("Instancia del usuario " + usuario.NombreDeUsuario + " recuperado");
                    }
                    else
                    {
                        throw new Exception("Error al intentar recuperar el usuario");
                    }
                }
                else
                {
                    throw new Exception("Elija una instancia a recuperar");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void comboBoxUsuarios_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarHistoricoDeUsuario();
        }
    }
}
