using Business.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business.Logic;

namespace UI.Web
{
    public partial class frmABMPlanes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!this.Page.User.Identity.IsAuthenticated)
            //{
            //    FormsAuthentication.RedirectToLoginPage();
            //}
            //else if (!((Usuario)Session["usuario"]).ModulosPorUsuario.Find(m => m.Modulo.Descripcion == "Administracion").PermiteConsulta)
            //{
            //    FormsAuthentication.RedirectToLoginPage("No está autorizado para acceder a este módulo");
            //}

            if (!IsPostBack)
            {
                LimpiarControles();
                InhabilitarControles();
                LLenarEspecialidades();
                LoadGrid();
            }

        }

        public FormModes FormMode
        {
            get => (FormModes)this.ViewState["FormMode"];
            set { this.ViewState["FormMode"] = value; }
        }

        public Plan Entity { get; set; }

        PlanLogic _planLogic;
        EspecialidadLogic _especialidadLogic;
       
        public PlanLogic PlanLogic
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

        public EspecialidadLogic EspecialidadLogic
        {
            get
            {
                if (_especialidadLogic == null)
                {
                    _especialidadLogic = new EspecialidadLogic();
                }
                return _especialidadLogic;
            }
        }

        public void LoadGrid()
        {
            List<Especialidad> todosLasEspecialidades = this.EspecialidadLogic.GetAll();
            List<Plan> todasLosPlanes = PlanLogic.GetAll();

            //foreach (Curso curso in todosLasEspecialidades)
            //{                
            //    curso.DescripcionMateria = todasLasMaterias.Find(m => m.ID == curso.IDMateria).Descripcion;
            //}

            if (todasLosPlanes.Count != 0)
            {
                this.grvPlanes.DataSource = todasLosPlanes;
                this.grvPlanes.DataBind();
            }
            else
            {
                //throw new Exception("No dispone de cursos cargados.");
            }
        }

        public void InhabilitarControles()
        {
            txtDescripcion.Enabled = false;
            ddlEspecialidad.Enabled = false;            
        }

        public void InhabilitadBotones()
        {
            btnAgregar.Enabled = false;
            btnGuardar.Enabled = false;
            btnEliminar.Enabled = false;
            btnCancelar.Enabled = false;
        }

        public void HabilitarControles()
        {
            txtDescripcion.Enabled = true;
            ddlEspecialidad.Enabled = true;
        }

        public void LimpiarControles()
        {
            txtDescripcion.Text = "";
            ddlEspecialidad.SelectedValue = "";
        }

        public void LLenarEspecialidades()
        {
            List<Especialidad> todasLasMaterias = this.EspecialidadLogic.GetAll();
            ddlEspecialidad.Items.Add("");
            ddlEspecialidad.SelectedValue = "";
            try
            {
                if (todasLasMaterias.Count != 0)
                {
                    foreach (Especialidad item in todasLasMaterias)
                    {
                        ddlEspecialidad.Items.Insert(item.ID, item.Descripcion);
                    }
                }
                else
                {
                    LimpiarControles();
                    InhabilitarControles();
                    InhabilitadBotones();
                    lblValidaEspecialidad.Text = string.Format("No hay Especialidades disponibles. Para poder agregar un nuevo plan debera agregar una especialidad.");
                    lblValidaEspecialidad.Visible = true;
                }
            }
            catch (Exception ex)
            {
                //lblValidarComision.Text = string.Format("Hubo un problema al recuperar las comisiones," +
                //    "por favor comunicarse con el administrador, disculpe las molestias. Para mas detalles " + ex.Message);
                //lblValidarComision.Visible = true;
                throw new Exception(ex.Message);
            }
        }

        protected void grvPlanes_SelectedIndexChanged(object sender, EventArgs e)
        {
            Plan plan = new Plan();
            var id = int.Parse(grvPlanes.SelectedRow.Cells[1].Text);
            plan.ID = id;
            plan = this.PlanLogic.GetOne(plan.ID);
            ObjetoAControl(plan);
            HabilitarControles();
        }

        public void ControlAObjetos(Plan plan)
        {
            plan.Especialidad = new Especialidad();
            plan.Descripcion = txtDescripcion.Text;            
            plan.Especialidad.Descripcion = ddlEspecialidad.SelectedValue;
            plan.Especialidad.ID = RecuperarIdEspecialidad();
        }

        public void ObjetoAControl(Plan plan)
        {
            txtDescripcion.Text = plan.Descripcion;
            ddlEspecialidad.SelectedValue = ddlEspecialidad.Items[plan.IDEspecialidad].Text;
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            HabilitarControles();
        }

        public int RecuperarIdEspecialidad()
        {
            List<Especialidad> especialidad = new List<Especialidad>();
            int IdEsp;
            try
            {
                string comision = ddlEspecialidad.SelectedValue;
                if (string.IsNullOrEmpty(comision))
                {
                    lblValidaEspecialidad.Text = "Debe seleccionar una Especialidad!";
                    lblValidaEspecialidad.Text = string.Format("Para poder seguir la operacion, deberá seleccionar una Especialidad");
                    lblValidaEspecialidad.Visible = true;
                }
                else
                {
                    especialidad = this.EspecialidadLogic.GetAll();
                    IdEsp = especialidad.Find(c => c.Descripcion == comision).ID;
                    return IdEsp;
                }

            }
            catch (Exception)
            {
                throw new Exception();
            }
            return 0;
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            Plan plan = new Plan();
            var valor = (grvPlanes.SelectedRow == null) ? true : false;
            int id = (valor == true) ? 0 : Convert.ToInt32(grvPlanes.SelectedRow.Cells[1].Text);

            if (id == 0)
            {

                plan.State = BusinessEntity.States.New;
                ControlAObjetos(plan);
                this.PlanLogic.Save(plan);
                LimpiarControles();
                LoadGrid();
            }
            else
            {
                FormsAuthentication.RedirectToLoginPage();
            }
            else if (((Usuario)Session["usuario"]) != null && ((Usuario)Session["usuario"]).ModulosPorUsuario != null && !((Usuario)Session["usuario"]).ModulosPorUsuario.Find(m => m.Modulo.Descripcion == "Administracion").PermiteConsulta)
            {
                FormsAuthentication.RedirectToLoginPage("No está autorizado para acceder a este módulo");
            }
                plan.ID = id;
                plan.State = BusinessEntity.States.Modified;
                ControlAObjetos(plan);
                this.PlanLogic.Save(plan);
                LimpiarControles();
                LoadGrid();
            }
            LimpiarControles();
            InhabilitarControles();
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            Plan plan = new Plan();
            plan.State = BusinessEntity.States.Deleted;
            plan.ID = int.Parse(grvPlanes.SelectedRow.Cells[1].Text);
            ControlAObjetos(plan);
            this.PlanLogic.Delete(plan.ID);
            LimpiarControles();
            InhabilitarControles();
            LoadGrid();
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarControles();
            InhabilitarControles();
        }
    }
}