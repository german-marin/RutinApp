using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RutinApp.Views
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            // Cerrar la aplicación
            Application.Exit();
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            // Poner la logica de loggeo
            this.Close();
        }

    }
}
