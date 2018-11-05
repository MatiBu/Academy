using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business.Entities;
using Business.Logic;

namespace UI.Web
{
    public partial class frmABMCursos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.Page.User.Identity.IsAuthenticated)
            {
                FormsAuthentication.RedirectToLoginPage();
            }
            if (!IsPostBack)
            {
                InhabilitarControles();
                LoadGrid();
            }
        }

        public FormModes FormMode
        {
            get => (FormModes)this.ViewState["FormMode"];
            set { this.ViewState["FormMode"] = value; }
        }

        public Curso Entity { get; set; }

        CursoLogic _logic;

        private int SelectID
        {
            get
            {
                if (this.ViewState["SelectedID"] != null)
                {
                    return (int)this.ViewState["SeletedID"];
                }
                else
                {
                    return 0;
                }
            }
            set
            {
                this.ViewState["SelectID"] = value;
            }
        }

        private bool IsEntitySelected
        {
            get
            {
                return (this.SelectID != 0);
            }
        }

        private CursoLogic Logic
        {
            get
            {
                if (_logic == null)
                {
                    _logic = new CursoLogic();
                }
                return _logic;
            }
        }

        public void LoadGrid()
        {
            this.grvCursos.DataSource = this.Logic.GetAll();
            this.grvCursos.DataBind();
        }

        public void InhabilitarControles()
        {            
            txtCupo.Enabled = false;
            txtAnioCalendario.Enabled = false;
            txtMateria.Enabled = false;
            txtComision.Enabled = false;
        }

        public void HabilitarControles()
        {
            txtCupo.Enabled = true;
            txtAnioCalendario.Enabled = true;
            txtMateria.Enabled = true;
            txtComision.Enabled = true;
        }       

        public void LimpiarControles()
        {            
            txtCupo.Text = "";
            txtAnioCalendario.Text = "";
            txtComision.Text = "";
            txtMateria.Text = "";
        }

        public void ControlAObjetos(Curso curso)
        {
            curso.Cupo = int.Parse(txtCupo.Text);
            curso.AnioCalendario = int.Parse(txtAnioCalendario.Text);
            curso.IDMateria = int.Parse(txtMateria.Text);
            curso.IDComision = int.Parse(txtComision.Text);
        }

        public void ObjetoAControl(Curso curso)
        {
            txtAnioCalendario.Text = Convert.ToString(curso.AnioCalendario);
            txtCupo.Text = Convert.ToString(curso.Cupo);
            txtMateria.Text = Convert.ToString(curso.IDMateria);
            txtComision.Text = Convert.ToString(curso.IDComision);
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            HabilitarControles();
            //var id = int.Parse(grvCursos.SelectedRow.Cells[1].Text);
            //if (id == 0)
            //{
            //    Curso curso = new Curso();
            //    //curso.State = BusinessEntity.States.Modified;
            //    //cursoLogic guardarcurso = new cursoLogic();
            //    ControlAObjetos(curso);
            //    this.Logic.Insert(curso);
            //    LimpiarControles();
            //    LoadGrid();
            //}
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {

            var valor = (grvCursos.SelectedRow == null)? true: false;        
            
            int id = (valor == true)? 0 : Convert.ToInt32(grvCursos.SelectedRow.Cells[1].Text);
                
            if (id == 0)
            {
                Curso curso = new Curso();
                curso.State = BusinessEntity.States.New;                
                ControlAObjetos(curso);
                this.Logic.Save(curso);
                LimpiarControles();
                LoadGrid();
            }
            else
            {
                Curso curso = new Curso();
                curso.ID = id;
                curso.State = BusinessEntity.States.Modified;                
                ControlAObjetos(curso);
                this.Logic.Save(curso);
                LimpiarControles();
                LoadGrid();
            }
            InhabilitarControles();
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            Curso curso = new Curso();
            curso.State = BusinessEntity.States.Deleted;
            curso.ID = int.Parse(grvCursos.SelectedRow.Cells[1].Text);
            ControlAObjetos(curso);
            this.Logic.Delete(curso.ID);
            LimpiarControles();
            InhabilitarControles();
            LoadGrid();
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarControles();
            InhabilitarControles();
        }

        protected void grvCursos_SelectedIndexChanged(object sender, EventArgs e)
        {
            Curso curso = new Curso();
            var id = int.Parse(grvCursos.SelectedRow.Cells[1].Text);
            curso.ID = id;
            curso = this.Logic.GetOne(id);
            ObjetoAControl(curso);
            HabilitarControles();
        }
    }
}