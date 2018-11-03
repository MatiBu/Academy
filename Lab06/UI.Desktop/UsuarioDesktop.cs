using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Business.Entities;
using Business.Logic;

namespace UI.Desktop
{
    public partial class UsuarioDesktop : ApplicationForm
    {
        public UsuarioDesktop()
        {
            InitializeComponent();
            this.moduleGrid.AutoGenerateColumns = false;
        }
        public UsuarioDesktop(ModoForm modo) : this()
        {
            Modo = modo;
            var modulo = new ModuloLogic();
            this.moduleGrid.DataSource = modulo.GetAll();
        }
        public UsuarioDesktop(int ID, ModoForm modo) : this()
        {
            Modo = modo;
            var usuario = new UsuarioLogic();
            var modulo = new ModuloLogic();
            UsuarioActual = usuario.GetOne(ID);
            List<ModuleByUser> newLista = new List<ModuleByUser>();
            var dataDeModulos = modulo.GetAll();
            var dataDeModulosPorUser = usuario.GetModulesByUser(ID);
            foreach (var module in dataDeModulos)
            {
                var index = dataDeModulosPorUser.FindIndex(m => m.IdModulo == module.ID);
                if (index >= 0)
                {
                    var newRow = new ModuleByUser
                    {
                        Descripcion = module.Descripcion,
                        PermiteAlta = dataDeModulosPorUser[index].PermiteAlta,
                        PermiteBaja = dataDeModulosPorUser[index].PermiteBaja,
                        PermiteModificacion = dataDeModulosPorUser[index].PermiteModificacion
                    };
                    newLista.Add(newRow);
                }
                else
                {
                    var newRow = new ModuleByUser { Descripcion = module.Descripcion };
                    newLista.Add(newRow);
                }
            }
            this.moduleGrid.DataSource = newLista;
            MapearDeDatos();
        }

        public Usuario UsuarioActual;
        public virtual void MapearDeDatos()
        {
            txtID.Text = UsuarioActual.ID.ToString();
            chkHabilitado.Checked = UsuarioActual.Habilitado;
            txtNombre.Text = UsuarioActual.Nombre;
            txtApellido.Text = UsuarioActual.Apellido;
            txtEmail.Text = UsuarioActual.EMail;
            txtUsuario.Text = UsuarioActual.NombreUsuario;
            txtClave.Text = UsuarioActual.Clave;
            txtConfirmarClave.Text = UsuarioActual.Clave;

            if (Modo == ModoForm.Alta | Modo == ModoForm.Consulta)
            {
                btnAceptar.Text = "Guardar";
            }
            else if (Modo == ModoForm.Baja)
            {
                btnAceptar.Text = "Eliminar";
            }
            else if (Modo == ModoForm.Modificacion)
            {
                btnAceptar.Text = "Aceptar";
            }

        }
        public virtual void MapearADatos()
        {
            if (Modo == ModoForm.Alta | Modo == ModoForm.Modificacion)
            {
                if (Modo == ModoForm.Alta)
                {
                    UsuarioActual = new Usuario();
                    UsuarioActual.State = BusinessEntity.States.New;
                }
                else
                {
                    UsuarioActual.ID = Int32.Parse(txtID.Text);
                    UsuarioActual.State = BusinessEntity.States.Modified;
                }
                UsuarioActual.Habilitado = chkHabilitado.Checked;
                UsuarioActual.Nombre = txtNombre.Text;
                UsuarioActual.Apellido = txtApellido.Text;
                UsuarioActual.EMail = txtEmail.Text;
                UsuarioActual.NombreUsuario = txtUsuario.Text;
                UsuarioActual.Clave = txtClave.Text;
                UsuarioActual.Clave = txtConfirmarClave.Text;
            }
            else if (Modo == ModoForm.Baja)
            {
                UsuarioActual.ID = Int32.Parse(txtID.Text);
                UsuarioActual.State = BusinessEntity.States.Deleted;
            }
        }
        public virtual void GuardarCambios()
        {
            MapearADatos();
            var usuario = new UsuarioLogic();
            usuario.Save(UsuarioActual);
        }
        public virtual bool Validar()
        {
            if (String.IsNullOrWhiteSpace(txtNombre.Text) | String.IsNullOrWhiteSpace(txtApellido.Text) | String.IsNullOrWhiteSpace(txtEmail.Text) |
            String.IsNullOrWhiteSpace(txtUsuario.Text) | String.IsNullOrWhiteSpace(txtClave.Text) |
            String.IsNullOrWhiteSpace(txtConfirmarClave.Text))
            {
                Notificar("Hay errores en su formulario", "Debe completar todos los campos", new MessageBoxButtons(), new MessageBoxIcon());
                return false;
            }
            else if (txtClave.Text.Length < 8)
            {
                Notificar("Hay errores en su formulario", "Sus contraseñas debe tener al menos 8 caracteres", new MessageBoxButtons(), new MessageBoxIcon());
                return false;
            }
            else if (txtConfirmarClave.Text != txtClave.Text)
            {
                Notificar("Hay errores en su formulario", "Sus contraseñas no coinciden", new MessageBoxButtons(), new MessageBoxIcon());
                return false;
            }
            return true;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (Validar())
            {
                GuardarCambios();
                Close();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void tlUsuario_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }
    }

    public class ModuleByUser
    {
        private string _Descripcion;
        private Boolean _PermiteAlta;
        private Boolean _PermiteBaja;
        private Boolean _PermiteModificacion;

        public string Descripcion { get => _Descripcion; set => _Descripcion = value; }
        public Boolean PermiteAlta { get => _PermiteAlta; set => _PermiteAlta = value; }
        public Boolean PermiteBaja { get => _PermiteBaja; set => _PermiteBaja = value; }
        public Boolean PermiteModificacion { get => _PermiteModificacion; set => _PermiteModificacion = value; }

    }
}
