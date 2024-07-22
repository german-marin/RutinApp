using RutinApp.Controllers;
using RutinApp.Models;
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
    public partial class frmParametros : Form
    {
        private string selectedImageName;
        public frmParametros()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmParametros_Load(object sender, EventArgs e)
        {
            if (GlobalVariables.Notes != "")
            {
                txtNotasGenerales.Text = GlobalVariables.Notes.ToString();
            }
            if (GlobalVariables.Days != 0)
            {
                txtDays.Text = GlobalVariables.Days.ToString();
            }
            if (GlobalVariables.Logo != "")
            {
                try
                {
                    pbLogo.Image = Image.FromFile(Path.Combine(Application.StartupPath, "Resources", GlobalVariables.Logo.Trim().ToString() + ".jpg"));
                    selectedImageName = GlobalVariables.Logo.Trim().ToString();
                }
                catch (FileNotFoundException)
                {
                    // Set the default image here
                    pbLogo.Image = Image.FromFile(Path.Combine(Application.StartupPath, "Resources", "rutinApp.jpg"));
                }
            }
        }

        private void btnCambiar_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Archivos de imagen (*.jpg)|*.jpg";
            openFileDialog.Title = "Seleccionar imagen .jpg";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string selectedImagePath = openFileDialog.FileName;


                // Obtener el nombre del archivo seleccionado
                string fileName = Path.GetFileName(selectedImagePath);

                // Definir el nuevo path en el directorio Resources
                string destinationPath = Path.Combine(Application.StartupPath, "Resources", fileName);

                // Si el archivo ya existe, generar un nuevo nombre
                int fileCount = 1;
                while (File.Exists(destinationPath))
                {
                    string newFileName = Path.GetFileNameWithoutExtension(fileName) + "_" + fileCount + Path.GetExtension(fileName);
                    destinationPath = Path.Combine(Application.StartupPath, "Resources", newFileName);
                    fileCount++;
                }

                try
                {
                    // Copiar la imagen al directorio Resources
                    File.Copy(selectedImagePath, destinationPath, true);

                    MessageBox.Show("Imagen añadida con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    pbLogo.ImageLocation = destinationPath;
                    selectedImageName = Path.GetFileNameWithoutExtension(destinationPath);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al añadir la imagen: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            selectedImageName = "";
            pbLogo.Image = Image.FromFile(Path.Combine(Application.StartupPath, "Resources", "rutinApp.jpg"));
        }

        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            // Verificar la inserción
            DialogResult result = MessageBox.Show("¿Estás seguro de que deseas actualizar estos parámetros?", "Confirmar actualización", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                SaveData();
                this.Close();
            }
        }
        private async void SaveData()
        {
            var userController = new UserController();
            var user = new User
            {
                Id = GlobalVariables.Id,
                Logo = selectedImageName,
                Notes = txtNotasGenerales.Text,
                Days = int.Parse(txtDays.Text.ToString())
            };

            bool updateSuccessful = await userController.UpdateUserSettings(user);

            if (updateSuccessful)
            {
                GlobalVariables.Logo = selectedImageName;
                GlobalVariables.Notes = txtNotasGenerales.Text;
                GlobalVariables.Days = int.Parse(txtDays.Text.ToString());

                MessageBox.Show("Configuraciones del usuario actualizadas correctamente.");
            }
            else
            {
                MessageBox.Show("Error al actualizar las configuraciones del usuario.");
            }

        }

        private void txtDays_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verificar si el carácter es un dígito o una tecla de control
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                // Si no es un dígito ni una tecla de control, cancelar la entrada
                e.Handled = true;
            }
        }
    }
}
