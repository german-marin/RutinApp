using Newtonsoft.Json;
using RutinApp.Models;
using System.Text;

namespace RutinApp.Controllers
{
    public class TrainingController
    {
        private HttpClient client;

        public TrainingController()
        {
            client = new HttpClient();
        }

        public async Task<int> InsertTraining(Training training)
        {
            try
            {
                // Serializa el objeto Training a formato JSON
                string json = JsonConvert.SerializeObject(training);

                // Configura el contenido de la solicitud
                HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");

                // Realiza la solicitud POST
                HttpResponseMessage response = await client.PostAsync("https://localhost:7137/api/Training", content);
                response.EnsureSuccessStatusCode();

                // Lee la respuesta para obtener el último ID insertado
                string responseJson = await response.Content.ReadAsStringAsync();
                int lastInsertID = JsonConvert.DeserializeObject<int>(responseJson);

                // devolvemos ID
                return lastInsertID;

            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo realizar la inserción. \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }

        }        

    }
}
