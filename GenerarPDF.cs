using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using iText.IO.Font.Constants;
using iText.Kernel.Font;
using iText.IO.Image;
using iText.Layout.Borders;
using iText.Kernel.Events;
using iText.Kernel.Pdf.Canvas;
using RutinApp.Models;
using iText.Kernel.Pdf.Canvas.Draw;
using System.Drawing.Imaging;
using iTextPath = System.IO.Path;  
using Image = System.Drawing.Image;
using System.Diagnostics;

namespace RutinApp
{
    public partial class GenerarPDF
    {
        public static void CrearPDF(List<ExerciseToPrint> exercisesToPrint, string pdfPath)
        {
           string logoPath;

            if (GlobalVariables.Logo != "")
            {
                 logoPath = Path.Combine(Application.StartupPath, "Resources\\" + GlobalVariables.Logo + ".jpg");
            }
            else 
            {
                 logoPath = Path.Combine(Application.StartupPath, "Resources\\rutinApp.jpg");
            }

            // Configurar fuente
            PdfFont font = PdfFontFactory.CreateFont(StandardFonts.HELVETICA);
            PdfFont boldFont = PdfFontFactory.CreateFont(StandardFonts.HELVETICA_BOLD);


            // Crear el escritor de PDF
            using (PdfWriter writer = new PdfWriter(pdfPath))
            {
                // Crear el documento PDF
                using (PdfDocument pdf = new PdfDocument(writer))
                {
                    // Agregar evento para el pie de página
                    pdf.AddEventHandler(PdfDocumentEvent.END_PAGE, new FooterHandler(font));

                    Document document = new Document(pdf);

                    // Establecer márgenes: superior, inferior, izquierdo, derecho (10 mm cada uno)
                    document.SetMargins(10, 10, 10, 10);

                    // Crear una tabla para la cabecera
                    Table headerTable = new Table(UnitValue.CreatePercentArray(new float[] { 1, 3 })).UseAllAvailableWidth();
                    headerTable.SetBorder(Border.NO_BORDER);

                    // Añadir el logo con tamaño ajustado
                    iText.Layout.Element.Image logo = new iText.Layout.Element.Image(ImageDataFactory.Create(logoPath))
                        .SetWidth(50)  // Ajusta el ancho del logo
                        .SetHeight(50); // Ajusta la altura del logo                                        
                    headerTable.AddCell(new Cell().Add(logo).SetBorder(Border.NO_BORDER).SetVerticalAlignment(iText.Layout.Properties.VerticalAlignment.MIDDLE));

                    // Crear una tabla para la información del cliente
                    Table infoTable = new Table(UnitValue.CreatePercentArray(new float[] { 1, 1 })).UseAllAvailableWidth();
                    infoTable.SetBorder(Border.NO_BORDER);

                    // Añadir información del cliente
                    infoTable.AddCell(new Cell().Add(new Paragraph("Programa de entrenamiento").SetFont(boldFont).SetFontSize(12).SetUnderline()).SetBorder(Border.NO_BORDER));
                    infoTable.AddCell(new Cell().Add(new Paragraph()).SetBorder(Border.NO_BORDER));
                    infoTable.AddCell(new Cell().Add(new Paragraph("Nombre: " + exercisesToPrint[0].CustomerName).SetFont(font).SetFontSize(10).SetFixedLeading(6)).SetBorder(Border.NO_BORDER));
                    infoTable.AddCell(new Cell().Add(new Paragraph("Inicio programa: " + exercisesToPrint[0].StartDate).SetFont(font).SetFontSize(8).SetFixedLeading(6)).SetBorder(Border.NO_BORDER));
                    infoTable.AddCell(new Cell().Add(new Paragraph("Días entrenamiento: " + exercisesToPrint[0].Days).SetFont(font).SetFontSize(8).SetFixedLeading(6)).SetBorder(Border.NO_BORDER));
                    infoTable.AddCell(new Cell().Add(new Paragraph("Final programa: " + exercisesToPrint[0].EndDate).SetFont(font).SetFontSize(8).SetFixedLeading(6)).SetBorder(Border.NO_BORDER));
                    infoTable.AddCell(new Cell().Add(new Paragraph("Nº Socio: " + exercisesToPrint[0].CustomerID.ToString()).SetFont(font).SetFontSize(8).SetFixedLeading(6)).SetBorder(Border.NO_BORDER));

                    // Añadir la tabla de información del cliente a la tabla de cabecera
                    headerTable.AddCell(new Cell().Add(infoTable).SetBorder(Border.NO_BORDER).SetVerticalAlignment(VerticalAlignment.MIDDLE));

                    // Añadir la tabla de cabecera al documento
                    document.Add(headerTable);

                    // Añadir ejercicios                    

                    for (int i = 0; i < exercisesToPrint.Count; i += 3)
                    {
                        // Crear una tabla para agrupar tres ejercicios por fila
                        Table exerciseRowTable = new Table(UnitValue.CreatePercentArray(new float[] { 1, 1, 1 })).UseAllAvailableWidth();

                        for (int j = i; j < i + 3 && j < exercisesToPrint.Count; j++)
                        {
                            ExerciseToPrint exercise = exercisesToPrint[j];

                            // Crear tabla para cada ejercicio
                            Table exerciseTable = new Table(UnitValue.CreatePercentArray(new float[] { 1 })).UseAllAvailableWidth();
                            exerciseTable.SetBorder(Border.NO_BORDER);

                            // Añadir cabecera del ejercicio sin bordes
                            Cell headerCell = new Cell().Add(new Paragraph(exercisesToPrint[j].Title)
                                .SetFont(boldFont)
                                .SetFontSize(8)
                                .SetPadding(2));
                            headerCell.SetBorder(Border.NO_BORDER);
                            exerciseTable.AddCell(headerCell);


                            // Crear una tabla interna para detalles e imagen
                            Table detailsImageTable = new Table(UnitValue.CreatePercentArray(new float[] { 1, 1 })).UseAllAvailableWidth();
                            detailsImageTable.SetBorder(Border.NO_BORDER);

                            // Añadir detalles del ejercicio en formato vertical
                            Table detailsTable = new Table(UnitValue.CreatePercentArray(new float[] { 1 })).UseAllAvailableWidth();
                            detailsTable.SetBorder(Border.NO_BORDER);

                            detailsTable.AddCell(new Cell().Add(new Paragraph("Series:").SetFont(font).SetFontSize(8).SetFixedLeading(6).SetUnderline()).SetBorder(Border.NO_BORDER));
                            detailsTable.AddCell(new Cell().Add(new Paragraph(exercise.Sets.ToString()).SetFont(font).SetFontSize(8).SetFixedLeading(6)).SetBorder(Border.NO_BORDER));

                            detailsTable.AddCell(new Cell().Add(new Paragraph("Repeticiones:").SetFont(font).SetFontSize(8).SetFixedLeading(6).SetUnderline()).SetBorder(Border.NO_BORDER));
                            detailsTable.AddCell(new Cell().Add(new Paragraph(exercise.Repetitions.ToString()).SetFont(font).SetFontSize(8).SetFixedLeading(6)).SetBorder(Border.NO_BORDER));

                            detailsTable.AddCell(new Cell().Add(new Paragraph("Pesos:").SetFont(font).SetFontSize(8).SetFixedLeading(6).SetUnderline()).SetBorder(Border.NO_BORDER));
                            detailsTable.AddCell(new Cell().Add(new Paragraph(exercise.Weight.ToString()).SetFont(font).SetFontSize(8).SetFixedLeading(6)).SetBorder(Border.NO_BORDER));

                            detailsTable.AddCell(new Cell().Add(new Paragraph("Recuperación:").SetFont(font).SetFontSize(8).SetFixedLeading(6).SetUnderline()).SetBorder(Border.NO_BORDER));
                            detailsTable.AddCell(new Cell().Add(new Paragraph(exercise.Recovery.ToString()).SetFont(font).SetFontSize(8).SetFixedLeading(7)).SetBorder(Border.NO_BORDER));

                            detailsTable.AddCell(new Cell().Add(new Paragraph("Otros:").SetFont(font).SetFontSize(8).SetFixedLeading(6).SetUnderline()).SetBorder(Border.NO_BORDER));
                            detailsTable.AddCell(new Cell().Add(new Paragraph(exercise.Others.ToString()).SetFont(font).SetFontSize(8).SetFixedLeading(7)).SetBorder(Border.NO_BORDER));

                            detailsTable.AddCell(new Cell().Add(new Paragraph("Notas:").SetFont(font).SetFontSize(8).SetFixedLeading(6).SetUnderline()).SetBorder(Border.NO_BORDER));
                            detailsTable.AddCell(new Cell().Add(new Paragraph(exercise.Notes.ToString()).SetFont(font).SetFontSize(8).SetFixedLeading(7)).SetBorder(Border.NO_BORDER));

                            detailsImageTable.AddCell(new Cell().Add(detailsTable).SetBorder(Border.NO_BORDER));

                            // Añadir celda de la imagen                       
                            string imgPath = Path.Combine(Application.StartupPath, "Resources/exercisePictures", exercise.Image.ToString() + ".jpg");
                            
                            if (exercise.Grip != "" && exercise.Grip is not null)
                            {
                                string overlayImgPath = Path.Combine(Application.StartupPath, "Resources/Grips", exercise.Grip.ToString() + ".jpg");
                                // Combinar las imágenes y añadir la imagen combinada
                                imgPath = CombineImages(imgPath, overlayImgPath);
                            }
                            iText.Layout.Element.Image img = new iText.Layout.Element.Image(ImageDataFactory.Create(imgPath)).SetAutoScale(true);
                            Cell imageCell = new Cell().Add(img);
                            imageCell.SetBorder(Border.NO_BORDER);
                            detailsImageTable.AddCell(imageCell);

                            // Añadir la tabla interna a la tabla del ejercicio
                            Cell combinedCell = new Cell().Add(detailsImageTable);
                            combinedCell.SetBorder(Border.NO_BORDER);
                            exerciseTable.AddCell(combinedCell);

                            // Añadir la tabla del ejercicio a la celda del exerciseRowTable
                            Cell exerciseCell = new Cell().Add(exerciseTable).SetBorder(Border.NO_BORDER);
                            exerciseRowTable.AddCell(exerciseCell);
                        }

                        // Añadir celdas vacías si es necesario para completar la fila
                        int emptyCells = 3 - ((exercisesToPrint.Count - i) % 3);
                        for (int j = 0; j < emptyCells && emptyCells < 3; j++)
                        {
                            exerciseRowTable.AddCell(new Cell().Add(new Paragraph("")).SetBorder(Border.NO_BORDER));
                        }

                        // Añadir la tabla de la fila de ejercicios al documento
                        exerciseRowTable.SetKeepTogether(true);
                        document.Add(exerciseRowTable);
                    }

                    // Añadir una línea de separación
                    LineSeparator separator = new LineSeparator(new SolidLine());
                    document.Add(separator);

                    // Añadir notas al final del documento
                    document.Add(new Paragraph("\nNotas:")
                        .SetFont(boldFont)
                        .SetFontSize(12)
                        .SetTextAlignment(TextAlignment.CENTER));
                    document.Add(new Paragraph(exercisesToPrint[0].GeneralNotes)
                        .SetFont(font)
                        .SetFontSize(10)
                        .SetTextAlignment(TextAlignment.LEFT));

                    document.Close();

                }
            }
            //MessageBox.Show("PDF creado exitosamente en " + pdfPath);
            // Abrir el archivo PDF automáticamente después de guardarlo
            try
            {
                Process.Start(new ProcessStartInfo(pdfPath) { UseShellExecute = true });
            }
            catch (Exception ex)
            {
                Console.WriteLine("No se pudo abrir el archivo PDF automáticamente: " + ex.Message);
            }
        }
        // Método para combinar dos imágenes
        private static string CombineImages(string imgPath1, string imgPath2)
        {
            using (Image img1 = Image.FromFile(imgPath1))
            using (Image img2 = Image.FromFile(imgPath2))
            {
                //int width = Math.Max(img1.Width, img2.Width);
                //int height = Math.Max(img1.Height, img2.Height);

                //using (Bitmap combinedImage = new Bitmap(width, height))
                int width = (int)Math.Round(img1.Width * 0.25);
                
                using (Bitmap combinedImage = new Bitmap(img1.Width, img1.Height))
                using (Graphics g = Graphics.FromImage(combinedImage))
                {
                    g.Clear(System.Drawing.Color.White);
                    g.DrawImage(img1, new System.Drawing.Rectangle(0, 0, img1.Width, img1.Height));
                    //g.DrawImage(img2, new System.Drawing.Rectangle(0, 0, img2.Width, img2.Height));
                    //g.DrawImage(img2, new System.Drawing.Rectangle(0, 0, 35, 35));
                    g.DrawImage(img2, new System.Drawing.Rectangle(0, 0, width, width));
                    string combinedImgPath = iTextPath.Combine(iTextPath.GetTempPath(), "combinedImg.jpg");
                    combinedImage.Save(combinedImgPath, ImageFormat.Jpeg);
                    return combinedImgPath;
                }
            }
        }
        // Evento para manejar el pie de página
        public class FooterHandler : IEventHandler
        {
            private readonly PdfFont font;
            public FooterHandler(PdfFont font)
            {
                this.font = font;
            }
            public void HandleEvent(Event currentEvent)
            {
                PdfDocumentEvent docEvent = (PdfDocumentEvent)currentEvent;
                PdfDocument pdf = docEvent.GetDocument();
                PdfPage page = docEvent.GetPage();
                int pageNumber = pdf.GetPageNumber(page);

                PdfCanvas canvas = new PdfCanvas(page.NewContentStreamAfter(), page.GetResources(), pdf);
                iText.Kernel.Geom.Rectangle pageSize = page.GetPageSize();
                canvas.BeginText()
                    .SetFontAndSize(font, 9)
                    .MoveText(pageSize.GetWidth() / 2 - 30, pageSize.GetBottom() + 10)
                    .ShowText($"Página {pageNumber}")
                    .EndText()
                    .Release();
            }
        }
    }
}
