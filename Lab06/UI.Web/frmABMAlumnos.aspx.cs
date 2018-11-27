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
            todosLosPlanes = PlanLogic.GetAll();
            if (!IsPostBack)
            {
                LlenarPlan();
            }
        }

        public List<Plan> todosLosPlanes;

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

        protected PlanLogic _planLogic;
        private PlanLogic PlanLogic
        {
            get
            {
                if (_planLogic == null)
                {
                    _planLogic = new PlanLogic();
                }
                return _planLogic;
            }
        }

        public void LlenarPlan()
        {
            ddlPlan.Items.Add("");
            ddlPlan.SelectedValue = "";
            try
            {
                if (todosLosPlanes.Count != 0)
                {
                    foreach (Plan item in todosLosPlanes)
                    {
                        ddlPlan.Items.Add(item.Descripcion);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            grvAlumnos.DataSource = AlumnoLogic.GetByApellido(txtBuscar.Text);
            grvAlumnos.DataBind();
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            HabilitarControles();
            if (txtLegajo.Enabled == true)
            {
                Alumno alumno = new Alumno();
                ControlAObjetos(alumno);
                alumno.State = BusinessEntity.States.New;
                AlumnoLogic.Save(alumno);
                LimpiarControles();
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            Alumno alumno = new Alumno();
            ControlAObjetos(alumno);
            alumno.State = BusinessEntity.States.Modified;
            AlumnoLogic.Save(alumno);
            LimpiarControles();
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            Alumno alumno = new Alumno();
            alumno.ID = int.Parse(grvAlumnos.SelectedRow.Cells[1].Text);
            alumno.State = BusinessEntity.States.Deleted;
            AlumnoLogic.Save(alumno);
            LimpiarControles();

        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarControles();
        }

        protected void grvAlumnos_SelectedIndexChanged(object sender, EventArgs e)
        {
            //AlumnoLogic recuperarAlumno = new AlumnoLogic();
            Alumno alum = new Alumno();
            alum.ID = int.Parse(grvAlumnos.SelectedRow.Cells[1].Text);
            alum.Legajo = int.Parse(grvAlumnos.SelectedRow.Cells[2].Text);
            alum.Nombre = grvAlumnos.SelectedRow.Cells[3].Text;
            alum.Apellido = grvAlumnos.SelectedRow.Cells[4].Text;
            alum.Plan = new Plan();
            alum.Plan.Descripcion = grvAlumnos.SelectedRow.Cells[5].Text;

            ObjetosAControl(alum);
        }

        public void ObjetosAControl(Alumno Alumno)
        {
            txtNombre.Text = Alumno.Nombre;
            txtApellido.Text = Alumno.Apellido;
            txtLegajo.Text = Alumno.Legajo.ToString();
            ddlPlan.SelectedValue = Alumno.Plan.Descripcion;
        }

        public void ControlAObjetos(Alumno Alumno)
        {
            Alumno.Nombre = txtNombre.Text;
            Alumno.Apellido = txtApellido.Text;
            Alumno.Legajo = Int32.Parse(txtLegajo.Text);
            Alumno.IDPlan = this.todosLosPlanes.Find(a => a.Descripcion == ddlPlan.SelectedValue).ID;
        }

        public void HabilitarControles()
        {
            txtNombre.Enabled = true;
            txtApellido.Enabled = true;
        }

        public void LimpiarControles()
        {
            txtNombre.Text = "";
            txtApellido.Text = "";
            ddlPlan.DataSource = "";
        }
    }
}