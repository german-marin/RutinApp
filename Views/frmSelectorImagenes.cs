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
    public partial class frmSelectorImagenes : Form
    {
        public PictureBox pbSelected { get; set; }
        public frmSelectorImagenes()
        {
            InitializeComponent();
        }

        private void frmSelectorImagenes_Load(object sender, EventArgs e)
        {
            // Obtener la ruta completa del directorio de recursos
            string resourcePath = Path.Combine(Application.StartupPath, "Resources/exercisePictures");

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
                pbSelected = pb;
                this.Close();
            }
        }
    }
}
