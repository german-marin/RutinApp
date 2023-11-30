using RutinApp.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RutinApp.Models
{
    public class TrainingLine
    {
        public int ID { get; set; }
        public int IdExercise { get; set; }
        public int IdTraining { get; set; }
        public string Series { get; set; }
        public string Repetition { get; set; }
        public string Weight { get; set; }
        public string Recovery { get; set; }
        public string Others { get; set; }
        public string Notes { get; set; }

        public TrainingLine(int iD, int idExercise, int idTraining, string series, string repetition, string weight, string recovery, string others, string notes)
        {
            ID = iD;
            IdExercise = idExercise;
            IdTraining = idTraining;
            Series = series;
            Repetition = repetition;
            Weight = weight;
            Recovery = recovery;
            Others = others;
            Notes = notes;
        }
        public async Task<bool> InsertTrainingLine()
        {
            try
            {
                TrainingLineController trainingLineController = new TrainingLineController();
                // Llama al método
                bool insertionResult = await trainingLineController.InsertTrainingLine(this);

                if (insertionResult)
                {
                    // todo ok                   
                    return true;
                }
                else
                {
                    // La inserción falló
                    MessageBox.Show("Error al insertar TrainingLine.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            catch (HttpRequestException ex)
            {
                // Manejo de excepciones específicas de la solicitud HTTP
                MessageBox.Show($"Error en la solicitud HTTP: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error inesperado: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

    }
}
