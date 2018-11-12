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
    public partial class frmABMComisiones : System.Web.UI.Page
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

            if (!IsPostBack)
            {
                LimpiarControles();
                HabilitarControles(false, false);
                LLenarEspecialidades();
                LlenarPlanes();
            }
        }

        protected ComisionLogic _comisionLogic;
        private ComisionLogic ComisionLogic
        {
            get
            {
                if (_comisionLogic == null)
                {
                    _comisionLogic = new ComisionLogic();
                }
                return _comisionLogic;
            }
        }

        PlanLogic _planLogic;
        EspecialidadLogic _especialidadLogic;

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


        private EspecialidadLogic EspecialidadLogic
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

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            grvComisiones.DataSource = ComisionLogic.GetByDescription(txtBuscar.Text);
            grvComisiones.DataBind();
            HabilitarBotones(true, false);
        }

        public void HabilitarBotones(bool value1, bool value2)
        {
            btnAgregar.Enabled = value1;
            btnGuardar.Enabled = value2;
            btnCancelar.Enabled = value2;
        }

        public void HabilitarControles(bool value1, bool value2)
        {
            txtDescripcion.Enabled = value1;
            txtAnioEspecialidad.Enabled = value1;
            ddlEspecialidad.Enabled = value2;
            ddlPlan.Enabled = value2;
        }

        public void LimpiarControles()
        {
            txtDescripcion.Text = "";
            txtAnioEspecialidad.Text = "";
            lblValidarPlan.Visible = false;
            lblValidarEspecialidad.Visible = false;
            ddlEspecialidad.DataSource = "";
            ddlPlan.DataSource = "";
            grvComisiones.DataSource = "";
        }

        public void ControlAObjetos(Comision comision)
        {
            comision.Descripcion = txtDescripcion.Text;
            comision.AnioEspecialidad = int.Parse(txtAnioEspecialidad.Text);
            comision.IDPlan = ddlPlan.SelectedIndex;
        }

        public void ObjetoAControl(Comision comision)
        {
            txtAnioEspecialidad.Text = Convert.ToString(comision.AnioEspecialidad);
            txtDescripcion.Text = Convert.ToString(comision.Descripcion);
            ddlPlan.SelectedIndex = comision.Plan.ID;
            ddlEspecialidad.SelectedIndex = comision.Plan.IDEspecialidad;
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            HabilitarControles(false, true);
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            Comision comision = new Comision();
            int id = (grvComisiones.SelectedRow == null) ? 0 : Convert.ToInt32(grvComisiones.SelectedRow.Cells[1].Text);
            comision.State = BusinessEntity.States.New;
            if (id != 0)
            {
                comision.ID = id;
                comision.State = BusinessEntity.States.Modified;
            }
            ControlAObjetos(comision);
            this.ComisionLogic.Save(comision);
            LimpiarControles();
            HabilitarControles(false, false);
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarControles();
            HabilitarControles(false, false);
        }

        protected void grvComisiones_SelectedIndexChanged(object sender, EventArgs e)
        {
            Comision comision = new Comision();
            var id = int.Parse(grvComisiones.SelectedRow.Cells[1].Text);
            comision.ID = id;
            comision = this.ComisionLogic.GetOne(id);
            ObjetoAControl(comision);
            HabilitarControles(true, false);
            HabilitarBotones(false, true);
        }

        public void LlenarPlanes()
        {
            List<Plan> todasLasPlanes = this.PlanLogic.GetAll();
            ddlPlan.Items.Add("");
            ddlPlan.SelectedValue = "";
            try
            {
                if (todasLasPlanes.Count != 0)
                {
                    foreach (Plan item in todasLasPlanes)
                    {
                        ddlPlan.Items.Insert(item.ID, item.Descripcion);
                    }
                }
                else
                {
                    LimpiarControles();
                    HabilitarControles(false, false);
                    HabilitarBotones(false, false);
                    lblValidarPlan.Text = string.Format("No hay planes disponibles. Para poder agregar un nuevo curso debera agregar un plan.");
                    lblValidarPlan.Visible = true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public void LLenarEspecialidades()
        {
            List<Especialidad> especialidades = EspecialidadLogic.GetAll();
            ddlEspecialidad.Items.Add("");
            ddlEspecialidad.SelectedValue = "";
            try
            {
                if (especialidades.Count != 0)
                {
                    foreach (Especialidad item in especialidades)
                    {
                        ddlEspecialidad.Items.Insert(item.ID, item.Descripcion);
                    }
                }
                else
                {
                    LimpiarControles();
                    HabilitarControles(false, false);
                    HabilitarBotones(false, false);
                    lblValidarEspecialidad.Text = string.Format("No hay especialidades disponibles. Para poder agregar un nuevo curso debera agregar una especialidad.");
                    lblValidarEspecialidad.Visible = true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
    }
}