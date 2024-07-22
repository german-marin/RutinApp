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
            // Validar la licencia antes de iniciar la aplicaci�n principal
            while (!LicenseManager.ValidateLicense())
            {
                // El bucle continuar� hasta que se introduzca y valide una licencia
                // Si la licencia no es v�lida o est� expirada, se mostrar� de nuevo el formulario de activaci�n
            }


            Application.Run(new Form1());
        }
    }
}
