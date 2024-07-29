using RutinApp.Views;
using System;
using System.IO;
using System.Management;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace RutinApp.Licensing
{
    internal static class LicenseManager
    {
        public static string EncryptionKey = "myEncryptionKey12345678901234567"; // Clave de encriptación

        public static bool ValidateLicense()
        {
            try
            {
                if (!File.Exists(GetLicenseFilePath()))
                {
                    Program.CloseSplashScreen();  // Close splash screen before showing the activation form
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
                    Logger.Log("License data format is incorrect.");
                    Program.CloseSplashScreen();  // Close splash screen before showing the message
                    ShowTopMostMessageBox("Datos de licencia incorrectos. Por favor, introduzca la clave de instalación.", "Activación de Licencia", MessageBoxIcon.Information);
                    ShowActivationForm();
                    return false;
                }

                string installationKey = licenseParts[0];
                string currentInstallationKey = GetUniqueIdentifier();

                if (installationKey != currentInstallationKey)
                {
                    Logger.Log($"License mismatch. Expected: {installationKey}, Found: {currentInstallationKey}");
                    Program.CloseSplashScreen();  // Close splash screen before showing the message
                    ShowTopMostMessageBox("La licencia no corresponde a esta instalación. Por favor, contacte con el proveedor.", "Activación de Licencia", MessageBoxIcon.Information);
                    ShowActivationForm();
                    return false;
                }

                DateTime expirationDate;

                if (!DateTime.TryParse(licenseParts[1], out expirationDate))
                {
                    Logger.Log("Invalid license expiration date format.");
                    Program.CloseSplashScreen();  // Close splash screen before showing the message
                    ShowTopMostMessageBox("Fecha de expiración de licencia inválida. Por favor, introduzca la clave de instalación.", "Activación de Licencia", MessageBoxIcon.Information);
                    ShowActivationForm();
                    return false;
                }

                if (expirationDate.Date < DateTime.Now.Date)
                {
                    Logger.Log($"License expired. Expiration date: {expirationDate}");
                    Program.CloseSplashScreen();  // Close splash screen before showing the message
                    ShowTopMostMessageBox("La licencia ha expirado. Por favor, contacte con el proveedor para renovarla.", "Activación de Licencia", MessageBoxIcon.Information);
                    ShowActivationForm();
                    return false;
                }

                // Comprobar si quedan menos de 7 días para la expiración
                TimeSpan remainingTime = expirationDate.Date - DateTime.Now.Date;
                if (remainingTime.Days <= 7)
                {
                    Program.CloseSplashScreen();  // Close splash screen before showing the message
                    ShowTopMostMessageBox($"La licencia expira en {remainingTime.Days} días. Por favor, contacte con el proveedor para renovarla.", "Advertencia de Licencia", MessageBoxIcon.Warning);
                }

                // Validación exitosa
                return true;
            }
            catch (Exception ex)
            {
                Logger.LogException(ex);
                Program.CloseSplashScreen();  // Close splash screen before showing the message
                return false;
            }
        }

        private static void ShowActivationForm()
        {
            // Mostrar formulario para activar la licencia
            using (frmLicencia activationForm = new frmLicencia())
            {
                activationForm.TopMost = true; // Asegurar que el formulario esté en la parte superior
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

            try
            {
                string licenseFilePath = GetLicenseFilePath();

                // Asegurarse de que el directorio exista
                string licenseDirectory = Path.GetDirectoryName(licenseFilePath);
                if (!Directory.Exists(licenseDirectory))
                {
                    Directory.CreateDirectory(licenseDirectory);
                }

                File.WriteAllText(licenseFilePath, encryptedLicense);
            }
            catch (Exception ex)
            {
                // Manejo de excepciones si la escritura del archivo falla
                Logger.LogException(ex);
                ShowTopMostMessageBox($"Failed to save license file: {ex.Message}", "Error", MessageBoxIcon.Error);
            }
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
            try
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
            catch (Exception ex)
            {
                Logger.LogException(ex);
                ShowTopMostMessageBox("Error de licencia: " + ex.Message, "Activación de Licencia", MessageBoxIcon.Error);

                return null;
            }
        }

        public static string GetUniqueIdentifier()
        {
            string identifier = GetHardDriveSerialNumber();
            Logger.Log("disco:" + identifier);
            identifier = GetCpuId();
            Logger.Log("cpu:" + identifier);
            identifier = GetBiosUUID();
            Logger.Log("bios:" + identifier);
            identifier = GetMacAddress();
            Logger.Log("mac:" + identifier);

            identifier = GetHardDriveSerialNumber();

            if (string.IsNullOrEmpty(identifier))
            {
                Logger.Log("No hard drive serial number found. Attempting to get CPU ID.");
                identifier = GetCpuId();
            }
            if (string.IsNullOrEmpty(identifier))
            {
                Logger.Log("No CPU ID found. Attempting to get BIOS UUID.");
                identifier = GetBiosUUID();
            }

            if (string.IsNullOrEmpty(identifier))
            {
                Logger.Log("No BIOS UUID found. Attempting to get Network Adapter MAC.");
                identifier = GetMacAddress();
            }

            if (string.IsNullOrEmpty(identifier))
            {
                Logger.Log("No MAC address found. Unable to obtain a persistent unique identifier.");

            }

            return identifier;
        }

        private static string GetHardDriveSerialNumber()
        {
            try
            {
                string serialNumber = "";
                ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_DiskDrive");
                foreach (ManagementObject wmi_HD in searcher.Get())
                {
                    serialNumber = wmi_HD["SerialNumber"]?.ToString().Trim();
                    if (!string.IsNullOrEmpty(serialNumber))
                    {
                        return serialNumber;
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LogException(ex);
            }
            return null;
        }

        private static string GetBiosUUID()
        {
            try
            {
                ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_BIOS");
                foreach (ManagementObject wmi_BIOS in searcher.Get())
                {
                    string uuid = wmi_BIOS["SerialNumber"]?.ToString().Trim();
                    if (!string.IsNullOrEmpty(uuid))
                    {
                        return uuid;
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LogException(ex);
            }
            return null;
        }

        private static string GetMacAddress()
        {
            try
            {
                ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_NetworkAdapterConfiguration WHERE IPEnabled = TRUE");
                foreach (ManagementObject wmi_Network in searcher.Get())
                {
                    string macAddress = wmi_Network["MACAddress"]?.ToString().Trim();
                    if (!string.IsNullOrEmpty(macAddress))
                    {
                        return macAddress;
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LogException(ex);
            }
            return null;
        }

        private static string GetCpuId()
        {
            try
            {
                ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_Processor");
                foreach (ManagementObject wmi_CPU in searcher.Get())
                {
                    string cpuId = wmi_CPU["ProcessorId"]?.ToString().Trim();
                    if (!string.IsNullOrEmpty(cpuId))
                    {
                        return cpuId;
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LogException(ex);
            }
            return null;
        }

        private static void ShowTopMostMessageBox(string text, string caption, MessageBoxIcon icon)
        {
            Form topMostForm = new Form();
            topMostForm.TopMost = true;
            topMostForm.StartPosition = FormStartPosition.CenterScreen;
            topMostForm.Size = new System.Drawing.Size(1, 1); // Formulario muy pequeño solo para mostrar el mensaje
            topMostForm.MaximizeBox = false;
            topMostForm.MinimizeBox = false;
            topMostForm.HelpButton = false;
            topMostForm.ControlBox = false;
            topMostForm.ShowInTaskbar = false;
            topMostForm.Show();
            MessageBox.Show(topMostForm, text, caption, MessageBoxButtons.OK, icon);
            topMostForm.Close();
        }
    }
}
