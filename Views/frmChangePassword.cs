using RutinApp.Controllers;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RutinApp.Views
{
    public partial class frmChangePassword : Form
    {
        private string currentUsername;

        public frmChangePassword()
        {
            InitializeComponent();            
        }

        private async void btnChangePassword_Click(object sender, EventArgs e)
        {
            string currentPassword = txtCurrentPassword.Text;
            string newPassword = txtNewPassword.Text;
            string confirmPassword = txtConfirmPassword.Text;

            UserController userController = new UserController();

            bool success = await userController.ChangePassword(GlobalVariables.UserName, currentPassword, newPassword, confirmPassword);
            if (success)
            {
                this.Close();
            }
        }
    }
}
