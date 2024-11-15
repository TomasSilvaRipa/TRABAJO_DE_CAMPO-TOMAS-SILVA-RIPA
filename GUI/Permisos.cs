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
using BE;
using Servicios;
namespace GUI
{
    public partial class Permisos : FIdiomaActualizable, IObservador
    {
        BLLPermisos bllPermisos;
        BLLUsuario bllUsuarios;
        Permiso permiso;
        TreeNode nodo;
        TreeNodeCollection arbol;
        GrupoDePermisos grupo;
        List<Permiso> listaDePermisos;
        Usuario usuario;
        DataTable tablaIdioma;
        BLLIdiomas bllIdiomas;
        public Permisos()
        {
            InitializeComponent();
            bllPermisos = new BLLPermisos();
            bllUsuarios = new BLLUsuario();
            listaDePermisos = new List<Permiso>();
            CargarPermisos();
            CargarUsuarios();
            CargarGruposDePermisos();
            Sesion.ObtenerSesion().AgregarObservador(this);
            actualizarIdioma();
            Notificar(this);
        }
        public delegate void IniciarMdi();
        public IniciarMdi iniciarMdi;


        public void CargarPermisos()
        {
            comboBoxPermisos.DataSource = null;
            comboBoxPermisos.DataSource = bllPermisos.LeerPermisos();
        }

        public void CargarUsuarios()
        {
            dataGridViewUsuarios.DataSource = null;
            dataGridViewUsuarios.DataSource = bllUsuarios.LeerUsuarios();
            dataGridViewUsuarios.Columns["Clave"].Visible = false;
            dataGridViewUsuarios.Columns["DV"].Visible = false;
            dataGridViewUsuarios.Columns["Foto"].Visible = false;
            dataGridViewUsuarios.Columns["ID"].Visible = false;
            dataGridViewUsuarios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        public void CargarGruposDePermisos()
        {
            comboBoxGruposDePermisos.DataSource = null;
            comboBoxGruposDePermisos.DataSource = bllPermisos.LeerGruposDePermisos();
        }

        public void CargarPermisosDeUsuario(string nombre)
        {
            dataGridViewPermisosDeUsuarios.DataSource = null;
            dataGridViewPermisosDeUsuarios.DataSource = bllPermisos.LeerPermisosXUsuario(nombre);
            dataGridViewPermisosDeUsuarios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        

        public TreeNode CargarPermisosTreeNode(List<Permiso> l, TreeNode nP)
        {
            foreach(Permiso p in l)
            {
                if (nP == null)
                {
                    nP = new TreeNode();
                    nP.Tag = p;
                    nP.Text = p.Nombre;
                }
                else
                {
                    TreeNode node = new TreeNode();
                    node.Text = p.Nombre;
                    node.Tag = p;
                    if (p.permisos.Count > 0)
                    {
                        nP.Nodes.Add(CargarPermisosTreeNode(p.permisos, node));
                    }
                    else
                    {
                        nP.Nodes.Add(node);
                    }
                }
            }
            return nP;
        }

        public bool ComprobarExistencia(Permiso permiso, TreeNodeCollection tr)
        {
            if (tr != null)
            {
                arbol = tr;
                foreach (TreeNode n in arbol)
                {
                    if (permiso.Nombre == n.Text)
                    {
                        return true;
                    }
                    if (n.Nodes.Count > 0)
                    {
                        if(ComprobarExistencia(permiso, n.Nodes))
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        public List<Permiso> ArmarGrupo(TreeNodeCollection a,GrupoDePermisos g)
        {
            foreach (TreeNode n in a)
            {
                Permiso permiso;
                if (n.Nodes.Count > 0)
                {
                    GrupoDePermisos nuevoGP = new GrupoDePermisos(n.Text);
                    nuevoGP.permisos = ArmarGrupo(n.Nodes,nuevoGP);
                    g.AgregarPermiso(nuevoGP);
                }
                else
                {
                    permiso = (Permiso)n.Tag;
                    g.AgregarPermiso(permiso);
                }
            }
            return g.permisos;
        }

        // C-> D A-> C D-> A

        public bool EvitarBucles(int idAgregar,int idPadre)
        {
            listaDePermisos = bllPermisos.TraerGrupoDePermisos(idAgregar);
            if(idAgregar == idPadre)
            {
                return false;
            }
            foreach(Permiso p in listaDePermisos)
            {
                if(p.permisos.Count > 0)
                {
                    return EvitarBucles(p.ID, idPadre);
                }
                if(p.ID == idPadre)
                {
                    return false;
                }
               
            }
            return true;
        }
        private void btnAgregarPermiso_Click(object sender, EventArgs e)
        {
            try
            {
                permiso = (PermisoSimple)comboBoxPermisos.SelectedItem;
                grupo = (GrupoDePermisos)comboBoxGruposDePermisos.SelectedItem;
                if (EvitarBucles(permiso.ID,grupo.ID))
                {
                    if (ComprobarExistencia(permiso, treeViewPermisos.Nodes) == false)
                    {
                        if (treeViewPermisos.SelectedNode != null)
                        {
                            nodo = (TreeNode)treeViewPermisos.SelectedNode;
                            Permiso g = new GrupoDePermisos();
                            g = (Permiso)nodo.Tag;
                            if (bllPermisos.IdentificarSiEsPadre(g.ID))
                            {
                                g = (GrupoDePermisos)nodo.Tag;
                                bllPermisos.CrearRelacionesDePermisos(g.ID, permiso.ID);
                                treeViewPermisos.Nodes.Clear();
                                listaDePermisos = bllPermisos.CargarPermisosTreeNode(grupo.ID);
                                treeViewPermisos.Nodes.Add(CargarPermisosTreeNode(listaDePermisos, null));
                                treeViewPermisos.ExpandAll();
                                MessageBox.Show("Permiso Añadido a " + grupo.Nombre);
                            }
                            else
                            {
                                throw new Exception("No se pueden agregar permisos a un permiso simple");
                            }
                        }
                        else
                        {
                            throw new Exception("Seleccione un Grupo de Permisos para agregar el permiso");
                        }
                    }
                    else
                    {
                        throw new Exception("El permiso que se quiere agregar ya esta dentro de la lista");
                    }
                }
                else
                {
                    throw new Exception("El grupo de permisos " + permiso.Nombre + " que se quiere agregar al " + grupo.Nombre + " ya tiene dentro suyo al grupo " + grupo.Nombre+ ". No se puede agregar al grupo de permisos un grupo del que es padre");
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        
        private void btnAsignarGrupo_Click(object sender, EventArgs e)
        {
            try
            {
                if(dataGridViewUsuarios.SelectedRows.Count == 1)
                {
                    if (comboBoxGruposDePermisos.SelectedIndex != -1)
                    {
                        grupo = (GrupoDePermisos)comboBoxGruposDePermisos.SelectedItem;
                        usuario = (Usuario)dataGridViewUsuarios.CurrentRow.DataBoundItem;
                        GrupoDePermisos g = new GrupoDePermisos();
                        g.permisos = bllPermisos.LeerPermisosXUsuario(usuario.NombreDeUsuario);
                        foreach(Permiso p in g.permisos)
                        {
                            if (ComprobarExistencia(p, treeViewPermisos.Nodes))
                            {
                                throw new Exception("El usuario ya tiene asignado este grupo de permisos");
                            }
                        }
                        bllPermisos.AgregarGrupoDePermisosAUsuario(grupo.ID,usuario.NombreDeUsuario);
                        CargarPermisosDeUsuario(usuario.NombreDeUsuario);
                        MessageBox.Show("Grupo " + grupo.Nombre + " agregado al usuario " + usuario.NombreDeUsuario);
                    }
                    else
                    {
                        MessageBox.Show("Seleccione un grupo de permisos");
                    }
                }
                else
                {
                    MessageBox.Show("Seleccione un Usuario al que agregar el grupo de permisos");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCrearGrupo_Click(object sender, EventArgs e)
        {
            try
            {
                if (ManejoErrores.ValidarNombre(txtNombreGrupoPermisos.Text))
                {
                    grupo = new GrupoDePermisos(txtNombreGrupoPermisos.Text);
                }
                else
                {
                    throw new Exception("Ingrese un nombre para el grupo");
                }
                bllPermisos.AgregarGrupo(grupo);
                MessageBox.Show("GrupoCreado");
                CargarGruposDePermisos();
                CargarPermisos();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            } 
        }

        private void comboBoxGruposDePermisos_SelectedIndexChanged(object sender, EventArgs e)
        {
            treeViewPermisos.Nodes.Clear();
            if(comboBoxGruposDePermisos.SelectedIndex != -1)
            {
                GrupoDePermisos gp = (GrupoDePermisos)comboBoxGruposDePermisos.SelectedItem;
                listaDePermisos = bllPermisos.CargarPermisosTreeNode(gp.ID);
                if(CargarPermisosTreeNode(listaDePermisos,null) != null)
                {
                    treeViewPermisos.Nodes.Add(CargarPermisosTreeNode(listaDePermisos, null));
                }
                treeViewPermisos.ExpandAll();
            }
        }

        private void btnBorrarPermiso_Click(object sender, EventArgs e)
        {
            try
            {
                if (treeViewPermisos.SelectedNode != null)
                {
                    permiso = (Permiso)treeViewPermisos.SelectedNode.Tag;
                    if(treeViewPermisos.SelectedNode.Parent != null)
                    {
                        grupo = (GrupoDePermisos)treeViewPermisos.SelectedNode.Parent.Tag;
                        bllPermisos.BorrarPermisoDeGrupo(grupo.ID,permiso.ID);
                    }
                    treeViewPermisos.Nodes.Clear();
                    listaDePermisos = bllPermisos.CargarPermisosTreeNode(grupo.ID);
                    treeViewPermisos.Nodes.Add(CargarPermisosTreeNode(listaDePermisos, null));
                    treeViewPermisos.ExpandAll();
                }
                else
                {
                    MessageBox.Show("Seleccione un permiso a borrar");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnReiniciarPermisos_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridViewUsuarios.SelectedRows.Count == 1)
                {
                    if (dataGridViewPermisosDeUsuarios.SelectedRows.Count == 1)
                    {
                        usuario = (Usuario)dataGridViewUsuarios.CurrentRow.DataBoundItem;
                        permiso = (Permiso)dataGridViewPermisosDeUsuarios.CurrentRow.DataBoundItem;
                        bllPermisos.QuitarPermisosDeUsuario(usuario.NombreDeUsuario.Trim(), permiso.ID);
                        CargarPermisosDeUsuario(usuario.NombreDeUsuario);
                        MessageBox.Show("Grupo de permisos " + permiso.Nombre + " del usuario " + usuario.NombreDeUsuario.Trim() + " quitado");
                    }
                }
                else
                {
                    MessageBox.Show("Seleccione un usuario para reinciar sus permisos");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void Notificar(object Sender)
        {
            actualizarIdioma();
        }

        private void dataGridViewUsuarios_SelectionChanged(object sender, EventArgs e)
        {
            if(dataGridViewUsuarios.SelectedRows.Count == 1)
            {
                usuario = (Usuario)dataGridViewUsuarios.CurrentRow.DataBoundItem;
                CargarPermisosDeUsuario(usuario.NombreDeUsuario);
            }
            
        }

        private void Permisos_Load(object sender, EventArgs e)
        {

        }
    }
}
