using System;
using System.IO;
using System.Windows.Forms;
using RutinApp.Licensing;

namespace RutinApp
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            // Set the DataDirectory to the startup path
            AppDomain.CurrentDomain.SetData("DataDirectory", Path.Combine(Application.StartupPath, "BBDD"));
            ApplicationConfiguration.Initialize();
            // Validar la licencia antes de iniciar la aplicación principal
            while (!LicenseManager.ValidateLicense())
            {
                // El bucle continuará hasta que se introduzca y valide una licencia
                // Si la licencia no es válida o está expirada, se mostrará de nuevo el formulario de activación
            }


            Application.Run(new Form1());
        }
    }
}
