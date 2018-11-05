using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Business.Entities;
using Business.Logic;

namespace UI.Desktop
{
    public partial class AlumnoDesktop : ApplicationForm
    {
        public AlumnoDesktop()
        {
            InitializeComponent();
            cargaPlanes();
            cargaEspecialidades();
        }
        public AlumnoDesktop(ModoForm modo) : this()
        {
            Modo = modo;
        }
        public AlumnoDesktop(int ID, ModoForm modo) : this()
        {
            Modo = modo;

            var alumno = new AlumnoLogic();
            AlumnoActual = alumno.GetOne(ID);
            MapearDeDatos();
        }

        public Alumno AlumnoActual;
        public List<Especialidad> LstEspecialidades;
        public List<Plan> LstPlanes;
        public virtual void MapearDeDatos()
        {
            txtID.Text = AlumnoActual.ID.ToString();
            txtLegajo.Text = AlumnoActual.Legajo.ToString();
            txtNombre.Text = AlumnoActual.Nombre;
            txtApellido.Text = AlumnoActual.Apellido;
            txtEmail.Text = AlumnoActual.EMail;
            txtTelefono.Text = AlumnoActual.Telefono;
            txtDireccion.Text = AlumnoActual.Direccion;
            txtFechaNacimiento.Text = AlumnoActual.FechaNacimiento.ToShortDateString();
            comboEspecialidad.SelectedValue = AlumnoActual.IDEspecialidad;
            comboPlan.SelectedValue = AlumnoActual.IDPlan;

            if (Modo == ModoForm.Alta | Modo == ModoForm.Consulta)
            {
                btnAceptar.Text = "Guardar";
            }
            else if (Modo == ModoForm.Baja)
            {
                btnAceptar.Text = "Eliminar";
            }
            else if (Modo == ModoForm.Modificacion)
            {
                btnAceptar.Text = "Aceptar";
            }

        }
        private void cargaPlanes()
        {
            var plan = new PlanLogic();
            LstPlanes = plan.GetAll();
            comboPlan.DataSource = LstPlanes;
            comboPlan.DisplayMember = "Descripcion";
            comboPlan.ValueMember = "ID";
        }

        private void cargaEspecialidades()
        {
            var especialidad = new EspecialidadLogic();
            LstEspecialidades = especialidad.GetAll();
            comboEspecialidad.DataSource = LstEspecialidades;
            comboEspecialidad.DisplayMember = "Descripcion";
            comboEspecialidad.ValueMember = "ID";
        }

        public virtual void MapearADatos()
        {
            if (Modo == ModoForm.Alta | Modo == ModoForm.Modificacion)
            {
                if (Modo == ModoForm.Alta)
                {
                    AlumnoActual = new Alumno();
                    AlumnoActual.State = BusinessEntity.States.New;
                }
                else
                {
                    AlumnoActual.ID = Int32.Parse(txtID.Text);
                    AlumnoActual.State = BusinessEntity.States.Modified;
                }
                AlumnoActual.Legajo = Int32.Parse(txtLegajo.Text);
                AlumnoActual.Nombre = txtNombre.Text;
                AlumnoActual.Apellido = txtApellido.Text;
                AlumnoActual.EMail = txtEmail.Text;
                AlumnoActual.Direccion = txtDireccion.Text;
                AlumnoActual.Telefono = txtTelefono.Text;
                AlumnoActual.FechaNacimiento = txtFechaNacimiento.Value;
                AlumnoActual.IDPlan = Int32.Parse(comboPlan.SelectedValue.ToString());
            }
            else if (Modo == ModoForm.Baja)
            {
                AlumnoActual.ID = Int32.Parse(txtID.Text);
                AlumnoActual.State = BusinessEntity.States.Deleted;
            }
        }
        public virtual void GuardarCambios()
        {
            MapearADatos();
            var alumno = new AlumnoLogic();
            alumno.Save(AlumnoActual);
        }
        public virtual bool Validar()
        {
            if (String.IsNullOrWhiteSpace(txtNombre.Text) | String.IsNullOrWhiteSpace(txtApellido.Text) | String.IsNullOrWhiteSpace(txtEmail.Text) |
            String.IsNullOrWhiteSpace(txtDireccion.Text) | String.IsNullOrWhiteSpace(txtTelefono.Text))
            {
                Notificar("Hay errores en su formulario", "Debe completar todos los campos", new MessageBoxButtons(), new MessageBoxIcon());
                return false;
            }
            else if (txtTelefono.Text.Length < 8)
            {
                Notificar("Hay errores en su formulario", "Su telefono debe tener al menos 8 caracteres", new MessageBoxButtons(), new MessageBoxIcon());
                return false;
            }
            return true;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (Validar())
            {
                GuardarCambios();
                Close();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void tlAlumno_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void comboEspecialidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (LstPlanes != null && LstPlanes.Count > 0 && LstEspecialidades != null && LstEspecialidades.Count > 0)
            {
                var valor = 0;
                Int32.TryParse(comboEspecialidad.SelectedValue.ToString(), out valor);
                var planesFiltrados = LstPlanes.Where(p => p.IDEspecialidad == valor).ToList();
                if (planesFiltrados != null && planesFiltrados.Count > 0)
                {
                    comboPlan.DataSource = planesFiltrados;
                }
            }
        }
    }
}
