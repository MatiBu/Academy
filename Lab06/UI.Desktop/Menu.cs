using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI.Desktop
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        public Menu(String nombre)
        {
            InitializeComponent();
            lblBienvenido.Text = "Bienvenido " + nombre;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void linkLabel1_Click(object sender, EventArgs e)
        {
            var adminUsuarios = new Usuarios();
            adminUsuarios.ShowDialog();
        }

        private void linkLabel2_Click(object sender, EventArgs e)
        {
            var adminAlumnos = new Alumnos();
            adminAlumnos.ShowDialog();
        }
    }
}
