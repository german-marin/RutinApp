using System;
using System.IO;
using System.Windows.Forms;

namespace RutinApp
{
    public static class Logger
    {
        private static readonly string logFilePath = Path.Combine(Application.StartupPath, "error.log");
         
        static Logger()
        {
            // Asegurarse de que el directorio exista
            string logDirectory = Path.GetDirectoryName(logFilePath);
            if (!Directory.Exists(logDirectory))
            {
                Directory.CreateDirectory(logDirectory);
            }
        }

        public static void LogException(Exception ex)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(logFilePath, true))
                {
                    writer.WriteLine("--------------------------------------------------");
                    writer.WriteLine($"Date: {DateTime.Now}");
                    writer.WriteLine($"Message: {ex.Message}");
                    writer.WriteLine($"StackTrace: {ex.StackTrace}");
                    writer.WriteLine("--------------------------------------------------");
                }
            }
            catch (Exception logEx)
            {
                MessageBox.Show($"Failed to write to log file: {logEx.Message}");
            }
        }

        public static void Log(string message)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(logFilePath, true))
                {
                    writer.WriteLine("--------------------------------------------------");
                    writer.WriteLine($"Date: {DateTime.Now}");
                    writer.WriteLine($"Message: {message}");
                    writer.WriteLine("--------------------------------------------------");
                }
            }
            catch (Exception logEx)
            {
                MessageBox.Show($"Failed to write to log file: {logEx.Message}");
            }
        }
    }
}
