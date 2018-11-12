using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business.Logic;
using Business.Entities;
using System.Web.Security;

namespace UI.Web
{
    public partial class frmABMAlumnos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.Page.User.Identity.IsAuthenticated)
            {
                FormsAuthentication.RedirectToLoginPage();
            }
            else if (((Usuario)Session["usuario"]) != null && ((Usuario)Session["usuario"]).ModulosPorUsuario != null && !((Usuario)Session["usuario"]).ModulosPorUsuario.Find(m => m.Modulo.Descripcion == "Administracion").PermiteConsulta)
            {
                FormsAuthentication.RedirectToLoginPage("No está autorizado para acceder a este módulo");
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {

        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {

        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {

        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {

        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {

        }

        protected void grvAlumnos_SelectedIndexChanged(object sender, EventArgs e)
        {
            //AlumnoLogic recuperarAlumno = new AlumnoLogic();
            Alumno Alumno = new Alumno();
            var id = int.Parse(grvAlumnos.SelectedRow.Cells[1].Text);
            //Alumno = recuperarAlumno.GetOne(id);
            ObjetosAControl(Alumno);
        }

        public void ObjetosAControl(Alumno Alumno)
        {
            txtNombre.Text = Alumno.Nombre;
            txtApellido.Text = Alumno.Apellido;
            txtEmail.Text = Alumno.EMail;
            cbHabilitado.Checked = Alumno.Habilitado;
            txtClave.Text = Alumno.Clave;
            txtRepetirClave.Text = Alumno.Clave;
        }

        public void ControlAObjetos(Alumno Alumno)
        {
            Alumno.Nombre = txtNombre.Text;
            Alumno.Apellido = txtApellido.Text;
            Alumno.EMail = txtEmail.Text;
            Alumno.Habilitado = cbHabilitado.Checked;
            Alumno.Clave = txtClave.Text;
        }

        public void HabilitarControles()
        {
            txtNombre.Enabled = true;
            txtApellido.Enabled = true;
            txtEmail.Enabled = true;
            cbHabilitado.Enabled = true;
            txtClave.Enabled = true;
            txtRepetirClave.Enabled = true;
        }

        public void LimpiarControles()
        {
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtEmail.Text = "";
            cbHabilitado.Text = "";
            txtClave.Text = "";
            txtRepetirClave.Text = "";
            cbHabilitado.Checked = false;
        }
    }
}