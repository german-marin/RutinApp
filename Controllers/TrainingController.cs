using Newtonsoft.Json;
using RutinApp.Models;
using System.Net.Http.Headers;
using System.Text;

namespace RutinApp.Controllers
{
    public class TrainingController
    {
        private HttpClient client;

        public TrainingController()
        {
            client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", TokenManager.Token);
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
                //HttpResponseMessage response = await client.PostAsync("https://localhost:7137/api/Training/InsertTraining", content);
                HttpResponseMessage response = await client.PostAsync($"{ApiConfiguration.ApiBaseUrl}/api/Training/InsertTraining", content);
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
        public async Task<List<Training>> GetAllTrainings()
        {
            try
            {
                //HttpResponseMessage response = await client.GetAsync("https://localhost:7137/api/Training/GetAllTrainings");
                HttpResponseMessage response = await client.GetAsync($"{ApiConfiguration.ApiBaseUrl}/api/Training/GetAllTrainings");
                response.EnsureSuccessStatusCode();

                string responseJson = await response.Content.ReadAsStringAsync();

                List<Training> trainingList = JsonConvert.DeserializeObject<List<Training>>(responseJson);

                return trainingList;
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo obtener la petición. \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

        }
        public async Task<bool> DeleteTraining(int id)
        {
            try
            {
                //HttpResponseMessage response = await client.DeleteAsync($"https://localhost:7137/api/Training/DeleteTraining?id={id}");
                HttpResponseMessage response = await client.DeleteAsync($"{ApiConfiguration.ApiBaseUrl}/api/Training/DeleteTraining?id={id}");
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
        public async Task<bool> DeleteTrainingAndTrainingLines(int id)
        {
            try
            {
                //HttpResponseMessage response = await client.DeleteAsync($"https://localhost:7137/api/Training/DeleteTrainingAndTrainingLines?id={id}");
                HttpResponseMessage response = await client.DeleteAsync($"{ApiConfiguration.ApiBaseUrl}/api/Training/DeleteTrainingAndTrainingLines?id={id}");
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
        public async Task<Training> GetTraining(int id)
        {
            try
            {
                //HttpResponseMessage response = await client.GetAsync("https://localhost:7137/api/Training/" + id);
                HttpResponseMessage response = await client.GetAsync($"{ApiConfiguration.ApiBaseUrl}/api/Training/{id}");
                response.EnsureSuccessStatusCode();

                string responseJson = await response.Content.ReadAsStringAsync();

                Training training = JsonConvert.DeserializeObject<Training>(responseJson);

                return training;

            }
            catch (Exception ex)
            {
                //mirar como controlar esta excepción correctamente
                MessageBox.Show("No se pudo obtener la petición. \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

        }
    }
}
