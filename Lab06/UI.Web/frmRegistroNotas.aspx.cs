using Business.Entities;
using Business.Logic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UI.Web
{
    public partial class frmRegistroNotas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.Page.User.Identity.IsAuthenticated)
            {
                FormsAuthentication.RedirectToLoginPage();
            }
            else if (((Usuario)Session["usuario"]) != null && ((Usuario)Session["usuario"]).ModulosPorUsuario != null && !((Usuario)Session["usuario"]).ModulosPorUsuario.Find(m => m.Modulo.Descripcion == "Docente").PermiteConsulta)
            {
                FormsAuthentication.RedirectToLoginPage("No está autorizado para acceder a este módulo");
            }
            todasLasMaterias = MateriaLogic.GetAll();
            todasLasEspecialidades = EspecialidadLogic.GetAll();
            if (!IsPostBack)
            {
                LlenarMaterias();
                LlenarEspecialidad();
            }

        }
        public List<Materia> todasLasMaterias;
        public List<Especialidad> todasLasEspecialidades;
        protected AlumnoInscripcionesLogic _alumnoInscripcionesLogic;
        private AlumnoInscripcionesLogic AlumnoInscripcionesLogic
        {
            get
            {
                if (_alumnoInscripcionesLogic == null)
                {
                    _alumnoInscripcionesLogic = new AlumnoInscripcionesLogic();
                }
                return _alumnoInscripcionesLogic;
            }
        }
        protected MateriaLogic _materiaLogic;
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
        protected EspecialidadLogic _especialidadLogic;
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
            BindData();
            Session["GrvAlumnosInsc"] = grvAlumnosInsc;
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            AlumnoInscripcionesLogic.SaveAll((List<AlumnoInscripciones>)((GridView)Session["GrvAlumnosInsc"]).DataSource);
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            grvAlumnosInsc.DataSource = "";
        }

        public void LlenarMaterias()
        {
            DropDownList2.Items.Add("");
            DropDownList2.SelectedValue = "";
            try
            {
                if (todasLasMaterias.Count != 0)
                {
                    foreach (Materia item in todasLasMaterias)
                    {
                        DropDownList2.Items.Add(item.Descripcion);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void LlenarEspecialidad()
        {
            DropDownList1.Items.Add("");
            DropDownList1.SelectedValue = "";
            try
            {
                if (todasLasEspecialidades.Count != 0)
                {
                    foreach (Especialidad item in todasLasEspecialidades)
                    {
                        DropDownList1.Items.Add(item.Descripcion);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        protected void TaskGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grvAlumnosInsc.PageIndex = e.NewPageIndex;
            BindData();
        }

        protected void grvAlumnosInsc_RowEditing(object sender, GridViewEditEventArgs e)
        {
            //Set the edit index.
            grvAlumnosInsc.EditIndex = e.NewEditIndex;

            grvAlumnosInsc.DataSource = ((GridView)Session["GrvAlumnosInsc"]).DataSource;
            grvAlumnosInsc.DataBind();
        }

        protected void grvAlumnosInsc_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

            //Update the values.
            GridViewRow row = grvAlumnosInsc.Rows[e.RowIndex];

            List<AlumnoInscripciones> lista = (List<AlumnoInscripciones>)((GridView)Session["GrvAlumnosInsc"]).DataSource;

            lista[row.DataItemIndex].Condicion = ((TextBox)(row.Cells[3].Controls[0])).Text;
            lista[row.DataItemIndex].Nota = Int32.Parse(((TextBox)(row.Cells[4].Controls[0])).Text);

            //Reset the edit index.
            grvAlumnosInsc.EditIndex = -1;

            //Bind data to the GridView control.
            grvAlumnosInsc.DataSource = lista;
            Session["GrvAlumnosInsc"] = grvAlumnosInsc;
            grvAlumnosInsc.DataBind();
        }

        protected void grvAlumnosInsc_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            //Reset the edit index.
            grvAlumnosInsc.EditIndex = -1;
            //Bind data to the GridView control.
            BindData();
            grvAlumnosInsc.EditIndex = -1;
        }

        private void BindData()
        {
            int selectedEspecialidad = this.todasLasEspecialidades.Find(a => a.Descripcion == DropDownList1.SelectedValue).ID;
            int selectedMateria = this.todasLasMaterias.Find(a => a.Descripcion == DropDownList2.SelectedValue).ID;
            grvAlumnosInsc.DataSource = AlumnoInscripcionesLogic.BuscarAlumnos(selectedEspecialidad, selectedMateria, TextBox1.Text);
            grvAlumnosInsc.DataBind();
        }
    }
}