using Newtonsoft.Json;
using RutinApp.Models;
using System.Text;

namespace RutinApp.Controllers
{
    public class TrainingLineController
    {

        private HttpClient client;

        public TrainingLineController()
        {
            client = new HttpClient();
        }

        public async Task<List<TrainingLine>> GetTrainingLinesOfTraining(int id)
        {
            try
            {

                HttpResponseMessage response = await client.GetAsync($"https://localhost:7137/api/TrainingLine/GetTrainingLinesOfTraining?id={id}");
                response.EnsureSuccessStatusCode();

                string responseJson = await response.Content.ReadAsStringAsync();

                List<TrainingLine> trainingLine = JsonConvert.DeserializeObject<List<TrainingLine>>(responseJson);

                return trainingLine;

            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo obtener la petición. \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

        }
        public async Task<bool> InsertTrainingLine(TrainingLine trainingLine)
        {
            try
            {
                // Serializa el objeto TrainingLine a formato JSON
                string json = JsonConvert.SerializeObject(trainingLine);

                // Configura el contenido de la solicitud
                HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");

                // Realiza la solicitud POST
                HttpResponseMessage response = await client.PostAsync("https://localhost:7137/api/TrainingLine/InsertTrainingLine", content);
                response.EnsureSuccessStatusCode();

                string responseJson = await response.Content.ReadAsStringAsync();
                bool result = JsonConvert.DeserializeObject<bool>(responseJson);

                // devolvemos ID
                return result;

            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo realizar la inserción. \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

        }
        public async Task<bool> DeleteTrainingLine(int id)
        {
            try
            {
                HttpResponseMessage response = await client.DeleteAsync($"https://localhost:7137/api/TrainingLine?id={id}");
                response.EnsureSuccessStatusCode();

                string responseJson = await response.Content.ReadAsStringAsync();
                bool result = JsonConvert.DeserializeObject<bool>(responseJson);

                return result;
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo realizar la eliminación. \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

    }
}
