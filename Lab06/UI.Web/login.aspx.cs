using Business.Entities;
using Business.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UI.Web
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.User.Identity.IsAuthenticated)
            {
                userName.Text = Page.User.Identity.Name;
            }
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

        protected void loguearse(object sender, EventArgs e)
        {
            LoginError.Text = "";
            Usuario loginUser = new Usuario();
            loginUser.NombreUsuario = txtNombreUsuario.Text;
            loginUser.Clave = txtClave.Text;
            usuarioLogueado = Logic.Login(loginUser);
            if (usuarioLogueado != null && !String.IsNullOrEmpty(usuarioLogueado.NombreUsuario))
            {
                FormsAuthentication.RedirectFromLoginPage(usuarioLogueado.NombreUsuario, chkRecordar.Checked);
            }
            else
            {
                LoginError.Text = "El usuario o la contraseña especificada es inválida";
            };
        }

        protected void desloguearse(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
            FormsAuthentication.RedirectToLoginPage();
        }
    }
}