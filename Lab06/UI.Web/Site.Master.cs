using Business.Entities;
using Business.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UI.Web
{
    public partial class Site : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        public Usuario usuarioLogueado { get; set; }
        UsuarioLogic _logic;

        private UsuarioLogic Logic
        {
            get
            {
                if (_logic == null)
                {
                    _logic = new UsuarioLogic();
                }
                return _logic;
            }
        }

        protected void login(object sender, EventArgs e)
        {
            Usuario loginUser = new Usuario();
            loginUser.NombreUsuario = txtNombreUsuario.Text;
            loginUser.Clave = txtClave.Text;
            usuarioLogueado = Logic.Login(loginUser);
            if (usuarioLogueado != null && !String.IsNullOrEmpty(usuarioLogueado.NombreUsuario))
            {
                Console.WriteLine("Usuario:" + usuarioLogueado.Nombre);
            }
            else
            {
                Console.WriteLine("El usuario o la contraseña especificada es inválida");
            };
        }
    }
}