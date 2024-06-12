using RutinApp.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RutinApp.Models;
using Newtonsoft.Json;

namespace RutinApp.Views
{
    public partial class frmLogin : Form
    {
        private readonly UserController _userController;
        public frmLogin()
        {
            _userController = new UserController();
            InitializeComponent();
            txtUser.Focus();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            // Cerrar la aplicación
            Application.Exit();
            //this.Close();
        }

        private async void btnAccept_Click(object sender, EventArgs e)
        {
            // Crear un objeto User con las credenciales proporcionadas por el usuario
            var user = new User(txtUser.Text, txtPass.Text);

            // Realizar la autenticación del usuario utilizando el UserController
            var authResult = await _userController.Authenticate(user);

            // Verificar si la autenticación fue exitosa
            if (authResult.IsSuccess)
            {
                // Almacenar el token en TokenManager
                TokenManager.Token = ExtractJwtToken(authResult.Token);

                // Cerrar el formulario de login
                this.Close();
            }
            else
            {
                // Mostrar un mensaje de error si la autenticación falla
                MessageBox.Show(authResult.ErrorMessage, "Error de inicio de sesión", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Función para extraer el token JWT de la cadena recibida
        private string ExtractJwtToken(string token)
        {
            try
            {
                // Intentar deserializar la cadena como un objeto JSON para extraer el token JWT
                dynamic tokenObject = JsonConvert.DeserializeObject(token);
                return tokenObject.token;
            }
            catch (Exception ex)
            {
                // Manejar cualquier error de deserialización
                MessageBox.Show($"Error al extraer el token JWT: {ex.Message}", "Error de inicio de sesión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

    }
}
