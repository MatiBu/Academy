using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI.Desktop.User_Controls
{
    public partial class ucABM : UserControl
    {        
        public ucABM()
        {
            InitializeComponent();
        }

        private void ucABM_Load(object sender, EventArgs e)
        {
            
            cmdModificar.Enabled = true;
            cmdGuardar.Enabled = true;
            cmdEliminar.Enabled = true;
            cmdCancelar.Enabled = true;
            cmdSalir.Enabled = true;
        }

        #region Controles

        private void cmdAgregar_Click(object sender, EventArgs e)
        {

        }

        private void cmdModificar_Click(object sender, EventArgs e)
        {

        }

        private void cmdGuardar_Click(object sender, EventArgs e)
        {

        }

        private void cmdEliminar_Click(object sender, EventArgs e)
        {

        }

        private void cmdCancelar_Click(object sender, EventArgs e)
        {

        }

        private void cmdSalir_Click(object sender, EventArgs e)
        {
            
        }

        private void cmdBuscar_Click(object sender, EventArgs e)
        {

        }

        private void cmdLimpiar_Click(object sender, EventArgs e)
        {

        }

        #endregion

        
    }
}
