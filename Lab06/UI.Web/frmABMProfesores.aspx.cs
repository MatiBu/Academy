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
    public partial class frmABMProfesores : System.Web.UI.Page
    {
        private DocenteCursoLogic _logic;
        
        private DocenteCursoLogic Logic
        {
            get
            {
                if (_logic == null)
                {
                    _logic = new DocenteCursoLogic();
                }
                return _logic;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                InhabilitarControles();
                LoadGrid();
            }
        }

        public void LoadGrid()
        {
            this.grvDocentes.DataSource = this.Logic.GetAll();
            this.grvDocentes.DataBind();
        }

        public void ObjetosAControl(Docente usuario)
        {
            txtNombre.Text = usuario.Nombre;
            txtApellido.Text = usuario.Apellido;
            txtEmail.Text = usuario.EMail;
            txtNombreUsuario.Text = usuario.NombreUsuario;
            cbHabilitado.Checked = usuario.Habilitado;
            txtClave.Text = usuario.Clave;
            txtRepetirClave.Text = usuario.Clave;
        }

        public void ControlAObjetos(Docente usuario)
        {
            usuario.Nombre = txtNombre.Text;
            usuario.Apellido = txtApellido.Text;
            usuario.EMail = txtEmail.Text;
            usuario.NombreUsuario = txtNombreUsuario.Text;
            usuario.Habilitado = cbHabilitado.Checked;
            usuario.Clave = txtClave.Text;
        }

        public void InhabilitarControles()
        {
            txtNombre.Enabled = false;
            txtApellido.Enabled = false;
            txtEmail.Enabled = false;
            txtNombreUsuario.Enabled = false;
            cbHabilitado.Enabled = false;
            txtClave.Enabled = false;
            txtRepetirClave.Enabled = false;
        }

        public void HabilitarControles()
        {
            txtNombre.Enabled = true;
            txtApellido.Enabled = true;
            txtEmail.Enabled = true;
            txtNombreUsuario.Enabled = true;
            cbHabilitado.Enabled = true;
            txtClave.Enabled = true;
            txtRepetirClave.Enabled = true;
        }

        public void LimpiarControles()
        {
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtEmail.Text = "";
            txtNombreUsuario.Text = "";
            cbHabilitado.Text = "";
            txtClave.Text = "";
            txtRepetirClave.Text = "";
            cbHabilitado.Checked = false;
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            foreach (GridViewRow row in grvDocentes.Rows)
            {
                for (int i = 1; i <= 11; i++)
                {
                    TextBox txt = row.FindControl(string.Format("TextBox{0}", i)) as TextBox;
                    if ((txt != null) && (txt.Text == txtBuscar.Text))
                    {
                        row.BackColor = System.Drawing.Color.Red;
                        grvDocentes.DataBind();
                    }
                }

            }
        }
    }
}