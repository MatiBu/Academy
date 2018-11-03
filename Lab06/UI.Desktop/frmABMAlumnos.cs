using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UI.Desktop.User_Controls;

namespace UI.Desktop
{
    public partial class frmABMAlumnos : Form 
    {
        ucABM uc = new ucABM();
        
        public frmABMAlumnos()
        {            
            InitializeComponent();
            int valor  = ucABM1.Controls.Count;
        }       

    }
}
