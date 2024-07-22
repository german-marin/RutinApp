using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RutinApp.Licensing;

namespace RutinApp.Views
{
    public partial class frmLicencia : Form
    {
        public string InstallationKey { get; private set; }
        public DateTime ExpirationDate { get; private set; }
        public frmLicencia()
        {
            InitializeComponent();
            txtInstallationKey.Text = GetUniqueInstallationKey();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            // Aquí deberías implementar la lógica para desencriptar y validar la licencia introducida
            string enteredLicense = txtLicenseKey.Text.Trim();
            string decryptedLicense = LicenseManager.DecryptString(enteredLicense, LicenseManager.EncryptionKey);

            if (!IsValidLicense(decryptedLicense))
            {
                MessageBox.Show("La clave de licencia no es válida.", "Error de Activación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string[] licenseParts = decryptedLicense.Split(';');

            if (licenseParts.Length != 2 || licenseParts[0] != GetUniqueInstallationKey())
            {
                MessageBox.Show("La clave de licencia no es válida.", "Error de Activación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            InstallationKey = licenseParts[0];
            ExpirationDate = DateTime.Parse(licenseParts[1]);

            DialogResult = DialogResult.OK;
            Close();
        }
        private string GetUniqueInstallationKey()
        {
            return LicenseManager.GetHardDriveSerialNumber();
        }


        private bool IsValidLicense(string decryptedLicense)
        {
            // Implementa la lógica de validación de licencia aquí
            // Este es un ejemplo simple
            return !string.IsNullOrEmpty(decryptedLicense);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
    }

    }
