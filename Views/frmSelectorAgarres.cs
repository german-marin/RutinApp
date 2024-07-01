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
    public partial class frmSelectorAgarres : Form
    {
        public PictureBox pbSelected { get; set; }
        private int nextNumber;
        public frmSelectorAgarres()
        {
            InitializeComponent();
        }

        private void frmSelectorAgarres_Load(object sender, EventArgs e)
        {
            cargarAgarres();
        }
        private void cargarAgarres()
        {
            flpImagenes.Controls.Clear();
            // Obtener la ruta completa del directorio de recursos
            string resourcePath = Path.Combine(Application.StartupPath, "Resources/Grips");

            // Verificar si el directorio existe
            if (!Directory.Exists(resourcePath))
            {
                MessageBox.Show("El directorio de imágenes no existe.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Obtener todas las imágenes del directorio de recursos
            string[] imageFiles = Directory.GetFiles(resourcePath, "*.jpg");  // Ajusta el patrón "*.jpg" según tus extensiones de imagen

            // Cargar las miniaturas en el FlowLayoutPanel
            foreach (var imagePath in imageFiles)
            {
                string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(imagePath);

                //// Ignorar la imagen "AA"
                //if (fileNameWithoutExtension == "AA")
                //{
                //    continue;
                //}

                // Actualizar nextNumber si el nombre de archivo es un número
                if (int.TryParse(fileNameWithoutExtension, out int number))
                {
                    nextNumber = Math.Max(nextNumber, number + 1);
                }

                PictureBox pb = new PictureBox
                {
                    ImageLocation = imagePath,
                    Width = 100,
                    Height = 100,
                    SizeMode = PictureBoxSizeMode.Zoom,
                    Cursor = Cursors.Hand,
                    Margin = new Padding(5)
                };
                pb.Click += new EventHandler(Thumbnail_Click);
                pb.DoubleClick += new EventHandler(Thumbnail_DoubleClick);
                // Añadir un borde a la PictureBox para indicar selección
                pb.Paint += (s, args) =>
                {
                    if (pbSelected == pb)
                    {
                        ControlPaint.DrawBorder(args.Graphics, pb.DisplayRectangle,
                            Color.Blue, 2, ButtonBorderStyle.Solid,
                            Color.Blue, 2, ButtonBorderStyle.Solid,
                            Color.Blue, 2, ButtonBorderStyle.Solid,
                            Color.Blue, 2, ButtonBorderStyle.Solid);
                    }
                };
                flpImagenes.Controls.Add(pb);
            }
        }
        private void Thumbnail_Click(object sender, EventArgs e)
        {
            if (sender is PictureBox pb)
            {
                // Eliminar el borde de la PictureBox previamente seleccionada
                if (pbSelected != null && pbSelected != pb)
                {
                    pbSelected.Invalidate(); // Forzar el repintado para eliminar el borde de la selección anterior
                }

                // Marcar la PictureBox como seleccionada
                pbSelected = pb;

                // Forzar el repintado para mostrar el borde de selección
                pb.Invalidate();
            }
        }
        private void Thumbnail_DoubleClick(object sender, EventArgs e)
        {
            if (sender is PictureBox pb)
            {
                if (Path.GetFileNameWithoutExtension(pb.ImageLocation) != "AA")
                {
                    pbSelected = pb;
                    this.Close();
                }
                else 
                {
                    añadirAgarre();
                }
            }
        }
        private void añadirAgarre()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Archivos de imagen (*.jpg)|*.jpg";
            openFileDialog.Title = "Seleccionar imagen .jpg";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string selectedImagePath = openFileDialog.FileName;


                // Obtener el nombre del archivo seleccionado
                //string fileName = Path.GetFileName(selectedImagePath);

                // Definir el nuevo path en el directorio Resources/exercisePictures
                string destinationPath = Path.Combine(Application.StartupPath, "Resources/Grips", nextNumber.ToString() + ".jpg");


                try
                {
                    // Copiar la imagen al directorio Resources/exercisePictures
                    File.Copy(selectedImagePath, destinationPath, true);

                    MessageBox.Show("Imagen añadida con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cargarAgarres();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al añadir la imagen: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
