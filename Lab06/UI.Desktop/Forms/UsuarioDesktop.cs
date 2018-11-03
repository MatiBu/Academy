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
        }
        public UsuarioDesktop(ModoForm modo) : this()
        {
            Modo = modo;
        }
        public UsuarioDesktop(int ID, ModoForm modo) : this()
        {
            Modo = modo;
            var usuario = new UsuarioLogic();
            UsuarioActual = usuario.GetOne(ID);
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
    }
}
