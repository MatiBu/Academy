using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
            if(!IsPostBack)
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
            txtDescripcion.Enabled = false;
            txtCupo.Enabled = false;
            txtAnio.Enabled = false;
        }

        public void LimpiarCampos()
        {
            txtDescripcion.Text = "";
            txtCupo.Text = "";
            txtAnio.Text = "";
        }



        public void ControlesAObjeto(Curso curso)
        {

        }

        public void ObjetosAControl(Curso curso)
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

        protected void grvCursos_SelectedIndexChanged(object sender, EventArgs e)
        {
            Curso curso = new Curso();
            var id = int.Parse(grvCursos.SelectedRow.Cells[1].Text);
            curso = this.Logic.GetOne(id);
            ObjetosAControl(curso);
        }
    }
}