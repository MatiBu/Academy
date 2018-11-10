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
    public partial class frmRegistroNotas : System.Web.UI.Page
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

        protected AlumnoLogic _alumnoLogic;
        private AlumnoLogic AlumnoLogic
        {
            get
            {
                if (_alumnoLogic == null)
                {
                    _alumnoLogic = new AlumnoLogic();
                }
                return _alumnoLogic;
            }
        }
        protected AlumnoInscripcionesLogic _alumnoInscripcionesLogic;
        private AlumnoInscripcionesLogic AlumnoInscripcionesLogic
        {
            get
            {
                if (_alumnoInscripcionesLogic == null)
                {
                    _alumnoInscripcionesLogic = new AlumnoInscripcionesLogic();
                }
                return _alumnoInscripcionesLogic;
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            grvAlumnos.DataSource = AlumnoLogic.GetByApellido(txtBuscar.Text);
            grvAlumnos.DataBind();
        }

        protected void grvAlumnos_SelectedIndexChanged(object sender, EventArgs e)
        {
            var id = int.Parse(grvAlumnos.SelectedRow.Cells[1].Text);
            grvAlumnosInsc.DataSource = AlumnoInscripcionesLogic.GetOneByAlumno(id);
            grvAlumnosInsc.DataBind();
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {

        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            grvAlumnosInsc.DataSource = "";
        }

    }
}