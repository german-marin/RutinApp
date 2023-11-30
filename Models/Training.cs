using RutinApp.Controllers;

namespace RutinApp.Models
{
    public class Training
    {
        public int ID { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int IdClient { get; set; }
        public string Notes { get; set; }

        public Training(int id, string description, DateTime startDate, DateTime endDate, int idClient, string notes)
        {
            ID = id;
            Description = description;
            StartDate = startDate;
            EndDate = endDate;
            IdClient = idClient;
            Notes = notes;
        }
        public async Task<int> InsertTraining()
        {
            try
            {
                // Crea una instancia de TrainingController
                TrainingController trainingController = new TrainingController();

                // Llama al método InsertTraining que devuelve el último ID insertado
                int lastInsertID = await trainingController.InsertTraining(this);

                if (lastInsertID != 0)
                {
                    // Si la inserción fue exitosa, actualiza el ID local
                    ID = lastInsertID;
                    return lastInsertID;
                }
                else
                {
                    // La inserción falló
                    MessageBox.Show("Error al insertar Training.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return -1;
                }

            }
            catch (HttpRequestException ex)
            {
                // Manejo de excepciones específicas de la solicitud HTTP
                MessageBox.Show($"Error en la solicitud HTTP: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
            catch (Exception ex)
            {             
                MessageBox.Show($"Error inesperado: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
        }        
    }
}
