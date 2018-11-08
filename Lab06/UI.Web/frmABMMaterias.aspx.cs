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
    public partial class frmABMMaterias : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.Page.User.Identity.IsAuthenticated)
            {
                FormsAuthentication.RedirectToLoginPage();
            }
            else if (!((Usuario)Session["usuario"]).ModulosPorUsuario.Find(m => m.Modulo.Descripcion == "Administracion").PermiteConsulta)
            {
                FormsAuthentication.RedirectToLoginPage("No está autorizado para acceder a este módulo");
            }

            if (!IsPostBack)
            {
                LimpiarControles();
                InhabilitarControles();
                LlenarPlanes();
                LoadGrid();
            }

        }

        public FormModes FormMode
        {
            get => (FormModes)this.ViewState["FormMode"];
            set { this.ViewState["FormMode"] = value; }
        }

        public Materia Entity { get; set; }

        MateriaLogic _materiaLogic;
        PlanLogic _planLogic;

        private MateriaLogic MateriaLogic
        {
            get
            {
                if (_materiaLogic == null)
                {
                    _materiaLogic = new MateriaLogic();
                }
                return _materiaLogic;
            }
        }

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

        public void LoadGrid()
        {
            List<Plan> todosLosPlanes = this.PlanLogic.GetAll();
            List<Materia> todasLasMaterias = this.MateriaLogic.GetAll();

            //foreach (Materia materia in todasLasMaterias)
            //{
            //    materia.DescripcionPlan = todosLosPlanes.Find(m => m.ID == materia.IDPlan).Descripcion;
            //}

            if (todasLasMaterias.Count != 0)
            {
                this.grvMaterias.DataSource = todasLasMaterias;
                this.grvMaterias.DataBind();
            }
            else
            {
                //throw new Exception("No dispone de cursos cargados.");
            }

        }

        public void HabilitarControles()
        {
            txtDescripcion.Enabled = true;
            txtHoraSemanales.Enabled = true;
            txtHorasTotales.Enabled = true;
            ddlPlanes.Enabled = true;
        }

        public void InhabilitarControles()
        {
            txtDescripcion.Enabled = false;
            txtHoraSemanales.Enabled = false;
            txtHorasTotales.Enabled = false;
            ddlPlanes.Enabled = false;
        }

        public void InhabilitadBotones()
        {
            btnAgregar.Enabled = false;
            btnGuardar.Enabled = false;
            btnEliminar.Enabled = false;
            btnCancelar.Enabled = false;
        }

        public void LimpiarControles()
        {
            txtDescripcion.Text = "";
            txtHoraSemanales.Text = "";
            txtHorasTotales.Text = "";
            lblValidaDescripcion.Visible = false;
            lblValidaHorasSem.Visible = false;
            lblValidaHorasTotales.Visible = false;
            lblValidaPlan.Visible = false;
            ddlPlanes.SelectedValue = "";
        }

        public void ControlAObjetos(Materia materia)
        {
            materia.Descripcion = txtDescripcion.Text;
            materia.HSSemanales = int.Parse(txtHoraSemanales.Text);
            materia.HSTotales = int.Parse(txtHorasTotales.Text);
            materia.IDPlan = RecuperarIdPlan();
        }

        public void ObjetoAControl(Materia materia)
        {
            txtDescripcion.Text = Convert.ToString(materia.Descripcion);
            txtHoraSemanales.Text = Convert.ToString(materia.HSSemanales);
            txtHorasTotales.Text = Convert.ToString(materia.HSTotales);
            ddlPlanes.SelectedValue = ddlPlanes.Items[materia.IDPlan].Text;
        }

        public int RecuperarIdPlan()
        {
            List<Plan> planes = new List<Plan>();
            int idPlan = 0;
            try
            {
                string materia = ddlPlanes.SelectedValue;
                if (string.IsNullOrEmpty(materia))
                {
                    lblValidaPlan.Text = "Debe seleccionar un plan!";
                    lblValidaPlan.Visible = true;
                    throw new Exception("Para poder seguir la operacion, deberá seleccionar un plan");
                }
                else
                {
                    planes = this.PlanLogic.GetAll();
                    idPlan = planes.Find(c => c.Descripcion == materia).ID;
                    return idPlan;
                }

            }
            catch (Exception ex)
            {
                lblValidaPlan.Visible = true;
                throw new Exception(ex.Message);
            }
        }

        protected void grvMaterias_SelectedIndexChanged(object sender, EventArgs e)
        {
            Materia materia = new Materia();
            var id = int.Parse(grvMaterias.SelectedRow.Cells[1].Text);
            materia.ID = id;
            materia = this.MateriaLogic.GetOne(id);
            ObjetoAControl(materia);
            HabilitarControles();
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            HabilitarControles();
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            Materia materia = new Materia();
            var valor = (grvMaterias.SelectedRow == null) ? true : false;
            int id = (valor == true) ? 0 : Convert.ToInt32(grvMaterias.SelectedRow.Cells[1].Text);

            if (id == 0)
            {

                materia.State = BusinessEntity.States.New;
                ControlAObjetos(materia);
                this.MateriaLogic.Save(materia);
                LimpiarControles();
                LoadGrid();
            }
            else
            {
                materia.ID = id;
                materia.State = BusinessEntity.States.Modified;
                ControlAObjetos(materia);
                this.MateriaLogic.Save(materia);
                LimpiarControles();
                LoadGrid();
            }
            LimpiarControles();
            InhabilitarControles();
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            Materia materia = new Materia();
            materia.State = BusinessEntity.States.Deleted;
            materia.ID = int.Parse(grvMaterias.SelectedRow.Cells[1].Text);
            ControlAObjetos(materia);
            this.MateriaLogic.Delete(materia.ID);
            LimpiarControles();
            InhabilitarControles();
            LoadGrid();
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarControles();
            InhabilitarControles();
        }

        public void LlenarPlanes()
        {
            List<Plan> todasLosPlanes = this.PlanLogic.GetAll();
            ddlPlanes.Items.Add("");
            ddlPlanes.SelectedValue = "";
            try
            {
                if (todasLosPlanes.Count != 0)
                {
                    foreach (Plan item in todasLosPlanes)
                    {
                        ddlPlanes.Items.Insert(item.ID, item.Descripcion);
                    }
                }
                else
                {
                    LimpiarControles();
                    InhabilitarControles();
                    InhabilitadBotones();
                    lblValidaPlan.Text = string.Format("No hay Planes disponibles. Para poder agregar una nueva materia debera agregar un plan.");
                    lblValidaPlan.Visible = true;
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
    }
}