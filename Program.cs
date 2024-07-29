using RutinApp.Views;
using System;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace RutinApp
{
    internal static class Program
    {
        private static frmLoading splashScreen;

        [STAThread]
        static void Main()
        {
            // Show splash screen
            ShowSplashScreen();

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
                    // Close the splash screen
                    CloseSplashScreen();
                    MessageBox.Show("Se ha alcanzado el número máximo de intentos de validación de la licencia.", "Error de Licencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Application.Exit();
                    return;
                }
            }

            // Close the splash screen
            CloseSplashScreen();

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

        private static void ShowSplashScreen()
        {
            // Run splash screen in a separate thread
            Thread splashThread = new Thread(new ThreadStart(() =>
            {
                splashScreen = new frmLoading();
                splashScreen.login = false;
                splashScreen.TopMost = false; // Ensure the splash screen is not always on top
                splashScreen.ShowDialog();
            }));
            splashThread.SetApartmentState(ApartmentState.STA);
            splashThread.Start();
        }

        public static void CloseSplashScreen()
        {
            if (splashScreen != null)
            {
                splashScreen.Invoke(new Action(() => splashScreen.Close()));
                splashScreen = null;
            }
        }
    }
}
