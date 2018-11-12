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
            else if (((Usuario)Session["usuario"]) != null && ((Usuario)Session["usuario"]).ModulosPorUsuario != null && !((Usuario)Session["usuario"]).ModulosPorUsuario.Find(m => m.Modulo.Descripcion == "Administracion").PermiteConsulta)
            {
                FormsAuthentication.RedirectToLoginPage("No está autorizado para acceder a este módulo");
            }


            if (!IsPostBack)
            {
                LimpiarControles();
                InhabilitarControles();
                LLenarComisiones();
                LlenarMaterias();
                LoadGrid();
            }
        }

        //public FormModes FormMode
        //{
        //    get => (FormModes)this.ViewState["FormMode"];
        //    set { this.ViewState["FormMode"] = value; }
        //}

        //public Curso Entity { get; set; }

        CursoLogic _cursoLogic;
        ComisionLogic _comisionLogic;
        MateriaLogic _materiaLogic;
        //private object _especialidadLogic;

        //private int SelectID
        //{
        //    get
        //    {
        //        if (this.ViewState["SelectedID"] != null)
        //        {
        //            return (int)this.ViewState["SeletedID"];
        //        }
        //        else
        //        {
        //            return 0;
        //        }
        //    }
        //    set
        //    {
        //        this.ViewState["SelectID"] = value;
        //    }
        //}

        //private bool IsEntitySelected
        //{
        //    get
        //    {
        //        return (this.SelectID != 0);
        //    }
        //}

        private CursoLogic CursoLogic
        {
            get
            {
                if (_cursoLogic == null)
                {
                    _cursoLogic = new CursoLogic();
                }
                return _cursoLogic;
            }
        }

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

        public void LoadGrid()
        {
            List<Curso> todosLosCursos = this.CursoLogic.GetAll();
            List<Comision> todasLasComisiones = this.ComisionLogic.GetAll();
            List<Materia> todasLasMaterias = this.MateriaLogic.GetAll();

            //foreach (Curso curso in todosLosCursos)
            //{
            //    curso.DescripcionComision = todasLasComisiones.Find(c => c.ID == curso.IDComision).Descripcion;
            //    curso.DescripcionMateria = todasLasMaterias.Find(m => m.ID == curso.IDMateria).Descripcion;
            //}

            if (todosLosCursos.Count != 0)
            {
                this.grvCursos.DataSource = todosLosCursos;
                this.grvCursos.DataBind();
            }
            else
            {
                //throw new Exception("No dispone de cursos cargados.");
            }

        }

        public void InhabilitarControles()
        {
            txtCupo.Enabled = false;
            txtAnioCalendario.Enabled = false;
            ddlComision.Enabled = false;
            ddlMateria.Enabled = false;
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
            txtCupo.Enabled = true;
            txtAnioCalendario.Enabled = true;
            ddlComision.Enabled = true;
            ddlMateria.Enabled = true;
        }

        public void LimpiarControles()
        {
            txtCupo.Text = "";
            txtAnioCalendario.Text = "";
            lblValidaCupo.Visible = false;
            lblValidarMateria.Visible = false;
            lblValidarComision.Visible = false;
            ddlComision.DataSource = "";
            ddlMateria.DataSource = "";
            grvCursos.DataSource = "";
        }

        public void ControlAObjetos(Curso curso)
        {
            curso.Cupo = int.Parse(txtCupo.Text);
            curso.AnioCalendario = int.Parse(txtAnioCalendario.Text);
            curso.IDComision = RecuperarIdComision();
            curso.IDMateria = RecuperarIdMateria();
        }

        public void ObjetoAControl(Curso curso)
        {
            txtAnioCalendario.Text = Convert.ToString(curso.AnioCalendario);
            txtCupo.Text = Convert.ToString(curso.Cupo);
            ddlMateria.SelectedValue = ddlMateria.Items[curso.IDMateria].Text;
            ddlComision.SelectedValue = ddlComision.Items[curso.IDComision].Text;
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            HabilitarControles();
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            Curso curso = new Curso();
            var valor = (grvCursos.SelectedRow == null) ? true : false;
            int id = (valor == true) ? 0 : Convert.ToInt32(grvCursos.SelectedRow.Cells[1].Text);

            if (id == 0)
            {

                curso.State = BusinessEntity.States.New;
                ControlAObjetos(curso);
                this.CursoLogic.Save(curso);
                LimpiarControles();
                LoadGrid();
            }
            else
            {
                curso.ID = id;
                curso.State = BusinessEntity.States.Modified;
                ControlAObjetos(curso);
                this.CursoLogic.Save(curso);
                LimpiarControles();
                LoadGrid();
            }
            LimpiarControles();
            InhabilitarControles();
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            Curso curso = new Curso();
            curso.State = BusinessEntity.States.Deleted;
            curso.ID = int.Parse(grvCursos.SelectedRow.Cells[1].Text);
            ControlAObjetos(curso);
            this.CursoLogic.Delete(curso.ID);
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
            curso = this.CursoLogic.GetOne(id);
            ObjetoAControl(curso);
            HabilitarControles();
        }

        public void LlenarMaterias()
        {
            List<Materia> todasLasMaterias = this.MateriaLogic.GetAll();
            ddlMateria.Items.Add("");
            ddlMateria.SelectedValue = "";
            try
            {
                if (todasLasMaterias.Count != 0)
                {
                    foreach (Materia item in todasLasMaterias)
                    {
                        ddlMateria.Items.Insert(item.ID, item.Descripcion);
                    }
                }
                else
                {
                    LimpiarControles();
                    InhabilitarControles();
                    InhabilitadBotones();
                    lblValidarMateria.Text = string.Format("No hay materias disponibles. Para poder agregar un nuevo curso debera agregar una materia.");
                    lblValidarMateria.Visible = true;
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

        public void LLenarComisiones()
        {
            List<Comision> comisiones = this.ComisionLogic.GetAll();
            //Para que por default aparezca vacio
            ddlComision.Items.Add("");
            ddlComision.SelectedValue = "";
            try
            {
                if (comisiones.Count != 0)
                {
                    foreach (Comision item in comisiones)
                    {
                        ddlComision.Items.Insert(item.ID, item.Descripcion);
                    }
                }
                else
                {
                    LimpiarControles();
                    InhabilitarControles();
                    InhabilitadBotones();
                    lblValidarComision.Text = string.Format("No hay comisiones disponibles. Para poder agregar un nuevo curso debera agregar una comision.");
                    lblValidarComision.Visible = true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public int RecuperarIdComision()
        {
            List<Comision> comisiones = new List<Comision>();
            int IdCom;
            try
            {
                string comision = ddlComision.SelectedValue;
                if (string.IsNullOrEmpty(comision))
                {
                    lblValidarComision.Text = "Debe seleccionar una comision!";
                    lblValidarComision.Text = string.Format("Para poder seguir la operacion, deberá seleccionar una comisión");
                    lblValidarComision.Visible = true;
                }
                else
                {
                    comisiones = this.ComisionLogic.GetAll();
                    IdCom = comisiones.Find(c => c.Descripcion == comision).ID;
                    return IdCom;
                }

            }
            catch (Exception)
            {
                throw new Exception();
            }
            return 0;
        }

        public int RecuperarIdMateria()
        {
            List<Materia> materias = new List<Materia>();
            int idMat = 0;
            try
            {
                string materia = ddlMateria.SelectedValue;
                if (string.IsNullOrEmpty(materia))
                {
                    lblValidarMateria.Text = "Debe seleccionar una materia!";
                    lblValidarMateria.Visible = true;
                    throw new Exception("Para poder seguir la operacion, deberá seleccionar una materia");
                }
                else
                {
                    materias = this.MateriaLogic.GetAll();
                    idMat = materias.Find(c => c.Descripcion == materia).ID;
                    return idMat;
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}