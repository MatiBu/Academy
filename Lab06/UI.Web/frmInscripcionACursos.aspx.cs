using Business.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UI.Web
{
    public partial class frmInscripcionACursos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.Page.User.Identity.IsAuthenticated)
            {
                FormsAuthentication.RedirectToLoginPage();
            }
            else if (((Usuario)Session["usuario"]) != null && ((Usuario)Session["usuario"]).ModulosPorUsuario != null && !((Usuario)Session["usuario"]).ModulosPorUsuario.Find(m => m.Modulo.Descripcion == "Docente").PermiteConsulta)
            {
                FormsAuthentication.RedirectToLoginPage("No está autorizado para acceder a este módulo");
            }
        }
    }
}