using Business.Entities;
using Business.Logic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI.Desktop
{
    public partial class Login : ApplicationForm
    {
        public Login()
        {
            InitializeComponent();
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void aceptar_Click(object sender, EventArgs e)
        {
            MapearADatos();
            var usuario = new UsuarioLogic();
            var usuarioRegistrado = usuario.Login(UsuarioActual);
            if (usuarioRegistrado != null && !String.IsNullOrEmpty(usuarioRegistrado.NombreUsuario))
            {
                Form adminUsuarios = new Menu(usuarioRegistrado.Nombre);
                this.Hide();
                adminUsuarios.Closed += (s, args) => this.Close();
                adminUsuarios.Show();
            }
            else
            {
                Notificar("El usuario o la contraseña especificada es inválida", new MessageBoxButtons(), new MessageBoxIcon());
            };
        }

        public Usuario UsuarioActual;

        public virtual void MapearADatos()
        {
            UsuarioActual = new Usuario();
            UsuarioActual.NombreUsuario = txtUsuario.Text;
            UsuarioActual.Clave = txtContraseña.Text;
        }

        public virtual bool Validar()
        {
            if (String.IsNullOrWhiteSpace(txtUsuario.Text) | String.IsNullOrWhiteSpace(txtContraseña.Text))
            {
                Notificar("Hay errores en su formulario", "Debe completar todos los campos", new MessageBoxButtons(), new MessageBoxIcon());
                return false;
            }
            return true;
        }
    }
}
