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
    public partial class frmABMEspecialidades : System.Web.UI.Page
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
                LoadGrid();
            }
        }

        public FormModes FormMode
        {
            get => (FormModes)this.ViewState["FormMode"];
            set { this.ViewState["FormMode"] = value; }
        }

        public Especialidad Entity { get; set; }
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

        EspecialidadLogic _especialidadLogic;

        public void LoadGrid()
        {
            List<Especialidad> todosLosCursos = EspecialidadLogic.GetAll();
           
            if (todosLosCursos.Count != 0)
            {
                this.grvEspecialid.DataSource = todosLosCursos;
                this.grvEspecialid.DataBind();
            }
            else
            {
                //throw new Exception("No dispone de cursos cargados.");
            }

        }

        public void InhabilitarControles()
        {
            txtDescripcion.Enabled = false;
            //grvEspecialid.SelectedRow.Cells[1].Text = "";
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
        }

        public void LimpiarControles()
        {
            txtDescripcion.Text = "";            
        }

        public void ControlAObjetos(Especialidad esp)
        {
            esp.Descripcion = txtDescripcion.Text;
        }

        public void ObjetoAControl(Especialidad esp)
        {
            txtDescripcion.Text = Convert.ToString(esp.Descripcion);            
        }

        protected void grvEspecialid_SelectedIndexChanged(object sender, EventArgs e)
        {
            Especialidad curso = new Especialidad();
            var id = int.Parse(grvEspecialid.SelectedRow.Cells[1].Text);
            curso.ID = id;
            curso = this.EspecialidadLogic.GetOne(id);
            ObjetoAControl(curso);
            HabilitarControles();
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            HabilitarControles();
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            Especialidad esp = new Especialidad();
            esp.State = BusinessEntity.States.Deleted;
            esp.ID = int.Parse(grvEspecialid.SelectedRow.Cells[1].Text);
            ControlAObjetos(esp);
            this.EspecialidadLogic.Delete(esp.ID);
            LimpiarControles();
            InhabilitarControles();
            LoadGrid();
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarControles();
            InhabilitarControles();
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            Especialidad esp = new Especialidad();
            var valor = (grvEspecialid.SelectedRow == null) ? true : false;
            //Este id hay que verificarlo cuando ya esta cargado anteriormente
            int id = (valor == true) ? 0 : Convert.ToInt32(grvEspecialid.SelectedRow.Cells[1].Text);

            if (id == 0)
            {

                esp.State = BusinessEntity.States.New;
                ControlAObjetos(esp);
                this.EspecialidadLogic.Save(esp);
                LimpiarControles();
                LoadGrid();
            }
            else
            {
                esp.ID = id;
                esp.State = BusinessEntity.States.Modified;
                ControlAObjetos(esp);
                this.EspecialidadLogic.Save(esp);
                LimpiarControles();
                LoadGrid();
            }
            LimpiarControles();
            InhabilitarControles();
        }
    }
}