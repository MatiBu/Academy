using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business.Logic;
using Business.Entities;
using System.Web.Security;

namespace UI.Web
{

    public partial class Usuarios : System.Web.UI.Page
    {

        public FormModes FormMode
        {
            get => (FormModes)this.ViewState["FormMode"];
            set { this.ViewState["FormMode"] = value; }
        }

        public Usuario Entity { get; set; }

        UsuarioLogic _logic;

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

        private UsuarioLogic Logic
        {
            get
            {
                if (_logic == null)
                {
                    _logic = new UsuarioLogic();
                }
                return _logic;
            }
        }

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
                InhabilitarControles();
                LoadGrid();
            }
        }

        private void LoadForm(int id)
        {
            this.Entity = this.Logic.GetOne(id);
            this.txtNombreUsuario.Text = this.Entity.Nombre;
            this.txtApellido.Text = this.Entity.Apellido;
            this.txtEmail.Text = this.Entity.EMail;
            this.cbHabilitado.Checked = this.Entity.Habilitado;
            this.txtNombreUsuario.Text = this.Entity.NombreUsuario;
        }

        public void LoadGrid()
        {
            this.grvUsuarios.DataSource = this.Logic.GetAll();
            this.grvUsuarios.DataBind();
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            foreach (GridViewRow row in grvUsuarios.Rows)
            {
                for (int i = 1; i <= 11; i++)
                {
                    TextBox txt = row.FindControl(string.Format("TextBox{0}", i)) as TextBox;
                    if ((txt != null) && (txt.Text == txtBuscar.Text))
                    {
                        row.BackColor = System.Drawing.Color.Red;
                        grvUsuarios.DataBind();
                    }
                }

            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            HabilitarControles();
            if (txtApellido.Enabled == true)
            {
                Usuario usuario = new Usuario();
                //usuario.State = BusinessEntity.States.Modified;
                UsuarioLogic guardarUsuario = new UsuarioLogic();
                ControlAObjetos(usuario);
                this.Logic.Insert(usuario);
                LimpiarControles();
                LoadGrid();
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            Usuario usuario = new Usuario();
            //usuario.State = BusinessEntity.States.Modified;

            ControlAObjetos(usuario);
            this.Logic.Save(usuario);
            LimpiarControles();
            LoadGrid();
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            Usuario usuario = new Usuario();
            usuario.ID = int.Parse(grvUsuarios.SelectedRow.Cells[1].Text);
            usuario.State = BusinessEntity.States.Deleted;
            this.Logic.Delete(usuario.ID);
            LimpiarControles();
            LoadGrid();
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarControles();
        }

        protected void grvUsuarios_SelectedIndexChanged(object sender, EventArgs e)
        {
            Usuario usuario = new Usuario();
            var id = int.Parse(grvUsuarios.SelectedRow.Cells[1].Text);
            usuario = this.Logic.GetOne(id);
            ObjetosAControl(usuario);
            HabilitarControles();
        }

        public void ObjetosAControl(Usuario usuario)
        {
            txtNombre.Text = usuario.Nombre;
            txtApellido.Text = usuario.Apellido;
            txtEmail.Text = usuario.EMail;
            txtNombreUsuario.Text = usuario.NombreUsuario;
            cbHabilitado.Checked = usuario.Habilitado;
            txtClave.Text = usuario.Clave;
            txtRepetirClave.Text = usuario.Clave;
        }

        public void ControlAObjetos(Usuario usuario)
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


    }
}