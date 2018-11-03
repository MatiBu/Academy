using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business.Logic;
using Business.Entities;

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
                if(this.ViewState["SelectedID"] != null)
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
            if(!IsPostBack)
            {
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
            this.gridView.DataSource = this.Logic.GetAll();
            this.gridView.DataBind();
        }      

        protected void gridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.SelectID = (int)this.gridView.SelectedValue;
        }
    }
}