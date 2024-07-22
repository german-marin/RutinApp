using RutinApp;
using RutinApp.Views;
using System;
using System.IO;
using System.Management;
using System.Security.Cryptography;
using System.Text;

namespace RutinApp.Licensing
{
    internal static class LicenseManager
    {
        public static string EncryptionKey = "myEncryptionKey12345678901234567"; // Clave de encriptación

        public static bool ValidateLicense()
        {
            if (!File.Exists(GetLicenseFilePath()))
            {
                ShowActivationForm();
                return false;
            }

            // Leer licencia encriptada desde el archivo
            string encryptedLicense = File.ReadAllText(GetLicenseFilePath());

            // Desencriptar la licencia
            string decryptedLicense = DecryptString(encryptedLicense, EncryptionKey);

            string[] licenseParts = decryptedLicense.Split(';');

            if (licenseParts.Length != 2)
            {
                MessageBox.Show("Datos de licencia incorrectos. Por favor, introduzca la clave de instalación.", "Activación de Licencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ShowActivationForm();
                return false;
            }

            string installationKey = licenseParts[0];
            string currentInstallationKey = GetHardDriveSerialNumber();

            if (installationKey != currentInstallationKey)
            {
                MessageBox.Show("La licencia no corresponde a esta instalación. Por favor, contacte con el proveedor.", "Activación de Licencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ShowActivationForm();
                return false;
            }

            DateTime expirationDate;

            if (!DateTime.TryParse(licenseParts[1], out expirationDate))
            {
                MessageBox.Show("Fecha de expiración de licencia inválida. Por favor, introduzca la clave de instalación.", "Activación de Licencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ShowActivationForm();
                return false;
            }

            if (expirationDate.Date < DateTime.Now.Date)
            {
                MessageBox.Show("La licencia ha expirado. Por favor, contacte con el proveedor para renovarla.", "Activación de Licencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ShowActivationForm();
                return false;
            }
            // Comprobar si quedan menos de 7 días para la expiración
            TimeSpan remainingTime = expirationDate.Date - DateTime.Now.Date;
            if (remainingTime.Days <= 7)
            {
                MessageBox.Show($"La licencia expira en {remainingTime.Days} días. Por favor, contacte con el proveedor para renovarla.", "Advertencia de Licencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            // Validación exitosa
            return true;
        }

        private static void ShowActivationForm()
        {
            // Mostrar formulario para activar la licencia
            using (frmLicencia activationForm = new frmLicencia())
            {
                if (activationForm.ShowDialog() == DialogResult.OK)
                {
                    // Guardar la licencia generada por el usuario
                    SaveLicense(activationForm.InstallationKey, activationForm.ExpirationDate);
                }
                else
                {
                    Application.Exit();
                }
            }
        }

        public static void SaveLicense(string installationKey, DateTime expirationDate)
        {
            string licenseData = $"{installationKey};{expirationDate.ToString("yyyy-MM-dd")}";

            // Encriptar los datos de la licencia
            string encryptedLicense = EncryptString(licenseData, EncryptionKey);

            // Guardar en archivo
            File.WriteAllText(GetLicenseFilePath(), encryptedLicense);
        }

        private static string GetLicenseFilePath()
        {
            return Path.Combine(Application.StartupPath, "license.txt");
        }

        public static string EncryptString(string plainText, string key)
        {
            byte[] iv = new byte[16]; // Vector de inicialización (debería ser aleatorio y no está en este ejemplo)
            byte[] array;

            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(key);
                aes.IV = iv;

                ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

                using (MemoryStream memoryStream = new MemoryStream())
                {
                    using (CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter streamWriter = new StreamWriter((Stream)cryptoStream))
                        {
                            streamWriter.Write(plainText);
                        }

                        array = memoryStream.ToArray();
                    }
                }
            }

            return Convert.ToBase64String(array);
        }

        public static string DecryptString(string cipherText, string key)
        {
            byte[] iv = new byte[16]; // Vector de inicialización (debería ser aleatorio y no está en este ejemplo)
            byte[] buffer = Convert.FromBase64String(cipherText);

            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(key);
                aes.IV = iv;

                ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

                using (MemoryStream memoryStream = new MemoryStream(buffer))
                {
                    using (CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader streamReader = new StreamReader((Stream)cryptoStream))
                        {
                            return streamReader.ReadToEnd();
                        }
                    }
                }
            }
        }
        public static string GetHardDriveSerialNumber()
        {
            string serialNumber = "";
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_DiskDrive");
            foreach (ManagementObject wmi_HD in searcher.Get())
            {
                serialNumber = wmi_HD["SerialNumber"].ToString();
                break;
            }
            return serialNumber;
        }
    }
}