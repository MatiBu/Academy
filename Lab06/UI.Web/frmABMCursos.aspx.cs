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
                LimpiarControles();
                InhabilitarControles();
                LoadGrid();
                //LlenarListas();
            }
        }

        public FormModes FormMode
        {
            get => (FormModes)this.ViewState["FormMode"];
            set { this.ViewState["FormMode"] = value; }
        }

        public Curso Entity { get; set; }

        CursoLogic _cursoLogic;
        ComisionLogic _comisionLogic;
        MateriaLogic _materiaLogic;
        //private object _especialidadLogic;

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
        
            foreach (Curso curso in todosLosCursos)
            {
                curso.DescripcionComision = todasLasComisiones.Find(c => c.ID == curso.IDComision).Descripcion;
                curso.DescripcionMateria = todasLasMaterias.Find(m => m.ID == curso.IDMateria).Descripcion;
            }

            LLenarComisiones(todasLasComisiones);
            //LLenarEspecialidades();
            LlenarMaterias(todasLasMaterias);
            if(todosLosCursos.Count != 0)
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
            //txtMateria.Enabled = false;
            //txtComision.Enabled = false;
            //ddlComision.SelectedValue = "";
            ddlComision.Enabled = false;
            //ddlMateria.SelectedValue = "";
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
            //txtMateria.Enabled = true;
            //txtComision.Enabled = true;
            ddlComision.Enabled = true;
            //ddlMateria.SelectedValue = "";
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
            ddlMateria.SelectedValue = ddlMateria.Items[curso.IDMateria].Text; ;
            ddlComision.SelectedValue = ddlComision.Items[curso.IDComision].Text;
        }        

        //public string DevuelveDescripcionComision(int idComision)
        //{
            
        //    foreach (var item in ddlComision.ItemType)
        //    {
        //        //if (item.ID == idComision)
        //        //{
        //        //    return item.Descripcion;
        //        //}
        //    }
        //    return "";
        //}

        //public string DevuelveDescripcionMateria(int idCurso)
        //{
        //    return ddlMateria.Items[idCurso].Text;
        //    //ddlMateria.Items.ToString();
        //    //for (int i = 0; i < ddlMateria.Items.Count; i++)
        //    //{
        //    //    var item = ddlMateria.Items[1].Text;

        //    //}
            
        //    //return "";
        //}

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
            ValidarControles();
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

        public void LlenarMaterias(List<Materia> cursos)
        {
            ddlMateria.Items.Add("");
            ddlMateria.SelectedValue = "";
            try
            {               
                if (cursos.Count != 0)
                {
                    foreach (Materia item in cursos)
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

        public void LLenarComisiones(List<Comision> comisiones)
        {
            ddlComision.Items.Add("");
            ddlComision.SelectedValue = "";
            try
            {                
                if (comisiones.Count != 0)
                {
                    foreach (Comision item in comisiones)
                    {
                        ddlComision.Items.Insert(item.ID ,item.Descripcion);
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
                //lblValidarComision.Text = string.Format("Hubo un problema al recuperar las comisiones," +
                //    "por favor comunicarse con el administrador, disculpe las molestias. Para mas detalles " + ex.Message);
                //lblValidarComision.Visible = true;
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
                    lblValidarComision.Text =  string.Format("Para poder seguir la operacion, deberá seleccionar una comisión");
                    lblValidarComision.Visible = true;                    
                }
                else
                {
                    comisiones = this.ComisionLogic.GetAll();
                    IdCom = comisiones.Find(c => c.Descripcion == comision).ID;
                    //com.AnioEspecialidad = comisiones.Find(c => c.Descripcion == comision).AnioEspecialidad;
                    //com.IDPlan = comisiones.Find(c => c.Descripcion == comision).IDPlan;
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
                    //mat.HSSemanales = materias.Find(c => c.Descripcion == materia).HSSemanales;
                    //mat.HSTotales = materias.Find(c => c.Descripcion == materia).HSTotales;
                    return idMat;
                }
                
            }
            catch (Exception ex)
            {                
                throw new Exception(ex.Message);                
            }            
        }

        public void ValidarControles()
        {
            
        }

                //public void LlenarListas()
                //{
                //    try
                //    {
                //        LlenarMaterias();
                //        LLenarComisiones();
                //        LLenarPlanes();
                //        LLenarEspecialidades();
                //    }
                //    catch (Exception)
                //    {

        //        throw new Exception("Ocurrio un error al recuperar los datos de la pagina. Por favor comunicarse con el administrador.");
        //    }

        //}

        //public void LLenarPlanes()
        //{
        //    PlanLogic data = new PlanLogic();
        //    try
        //    {
        //        List<Plan> comisiones = data.GetAll();
        //        if (comisiones.Count != 0)
        //        {
        //            foreach (Plan item in comisiones)
        //            {
        //                ddlComision.Items.Add(item.Descripcion);
        //            }
        //        }
        //        else
        //        {
        //            lblErrorPlan.Text = "";
        //            lblErrorPlan.Visible = true;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        //lblValidarComision.Text = string.Format("Hubo un problema al recuperar las comisiones," +
        //        //    "por favor comunicarse con el administrador, disculpe las molestias. Para mas detalles " + ex.Message);
        //        //lblValidarComision.Visible = true;
        //        throw new Exception(ex.Message);
        //    }
        //}

        //public void LLenarEspecialidades()
        //{
        //EspecialidadLogic data = new EspecialidadLogic();
        //try
        //{
        //    List<Especialidad> comisiones = data.GetAll();
        //    if (comisiones.Count != 0)
        //    {
        //        foreach (Especialidad item in comisiones)
        //        {
        //            ddlEspecialidad.Items.Add(item.Descripcion);
        //        }
        //    }
        //    else
        //    {
        //        lblErrorEsp.Text = "";
        //        lblErrorEsp.Visible = true;
        //    }
        //}
        //catch (Exception ex)
        //{
        //    //lblValidarComision.Text = string.Format("Hubo un problema al recuperar las Especialidades," +
        //    //    "por favor comunicarse con el administrador, disculpe las molestias. Para mas detalles " + ex.Message);
        //    //lblValidarComision.Visible = true;
        //    throw new Exception(ex.Message);
        //}
        //}        

        //public string RecuperarEspecialidades()
        //{
        //    string especilidad = ddlEspecialidad.SelectedValue;
        //    if (string.IsNullOrEmpty(especilidad))
        //    {
        //        lblValidarMateria.Text = "Debe seleccionar una Especialidad!";
        //        lblValidarMateria.Visible = true;
        //        throw new Exception("Para poder seguir la operacion, deberá seleccionar una Especialidad");
        //    }
        //    return especilidad;
        //}

        //public string RecuperarPlanes()
        //{
        //    string plan = ddlPlan.SelectedValue;
        //    if (string.IsNullOrEmpty(plan))
        //    {
        //        lblValidarMateria.Text = "Debe seleccionar una Plan!";
        //        lblValidarMateria.Visible = true;
        //        throw new Exception("Para poder seguir la operacion, deberá seleccionar una Plan");
        //    }
        //    return plan;
        //}
    }
}