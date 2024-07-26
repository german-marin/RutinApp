using System;
using System.IO;
using System.Windows.Forms;

namespace RutinApp
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
            Application.ThreadException += Application_ThreadException;

            // Set the DataDirectory to the startup path
            AppDomain.CurrentDomain.SetData("DataDirectory", Path.Combine(Application.StartupPath, "BBDD"));
            ApplicationConfiguration.Initialize();

            const int maxAttempts = 5;
            int attemptCount = 0;

            // Validar la licencia antes de iniciar la aplicación principal
            while (attemptCount < maxAttempts && !Licensing.LicenseManager.ValidateLicense())
            {
                attemptCount++;
                if (attemptCount < maxAttempts)
                {
                    // Esperar un poco antes de volver a intentar
                    Thread.Sleep(2000);
                }
                else
                {
                    MessageBox.Show("Se ha alcanzado el número máximo de intentos de validación de la licencia.", "Error de Licencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Application.Exit();
                    return;
                }
            } 

            Application.Run(new Form1());
        }

        private static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            Logger.LogException(e.Exception);
            MessageBox.Show("An unhandled exception occurred.");
        }

        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Logger.LogException((Exception)e.ExceptionObject);
            MessageBox.Show("An unhandled domain exception occurred.");
        }
    }
}
