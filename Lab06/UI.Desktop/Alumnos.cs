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
    public partial class Alumnos : Form
    {
        public Alumnos()
        {
            InitializeComponent();
            this.dgvAlumnos.AutoGenerateColumns = false;

        }

        public void Listar()
        {
            AlumnoLogic ul = new AlumnoLogic();
            this.dgvAlumnos.DataSource = ul.GetAll();
        }

        private void Alumnos_Load(object sender, EventArgs e)
        {
            Listar();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            Listar();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            var nuevoAlumno = new AlumnoDesktop(ApplicationForm.ModoForm.Alta);
            nuevoAlumno.ShowDialog();
            Listar();
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            if (this.dgvAlumnos.SelectedRows != null && this.dgvAlumnos.SelectedRows.Count > 0)
            {
                int ID = ((Business.Entities.Alumno)this.dgvAlumnos.SelectedRows[0].DataBoundItem).ID;
                var nuevoAlumno = new AlumnoDesktop(ID, ApplicationForm.ModoForm.Modificacion);
                nuevoAlumno.ShowDialog();
                Listar();
            }
        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            if (this.dgvAlumnos.SelectedRows != null && this.dgvAlumnos.SelectedRows.Count > 0)
            {
                int ID = ((Business.Entities.Alumno)this.dgvAlumnos.SelectedRows[0].DataBoundItem).ID;
                var nuevoAlumno = new AlumnoDesktop(ID, ApplicationForm.ModoForm.Baja);
                nuevoAlumno.ShowDialog();
                Listar();
            }
        }
    }
}
