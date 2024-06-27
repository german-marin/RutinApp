using Newtonsoft.Json;
using RutinApp.Models;
using System.Net.Http.Headers;
using System.Text;

namespace RutinApp.Controllers
{
    public class ExerciseController
    {
        private HttpClient client;

        public ExerciseController()
        {
            client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", TokenManager.Token);
        }

        public async Task<List<Exercise>> GetCategoryExercises(int id)
        {
            try
            {

                HttpResponseMessage response = await client.GetAsync($"{ApiConfiguration.ApiBaseUrl}/api/Exercise/GetCategoryExercises?id={id}");
                response.EnsureSuccessStatusCode();

                string responseJson = await response.Content.ReadAsStringAsync();

                List<Exercise> exerciseList = JsonConvert.DeserializeObject<List<Exercise>>(responseJson);

                return exerciseList;

            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo obtener la petición. \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

        }
        public async Task<Exercise> GetExercise(int id)
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync($"{ApiConfiguration.ApiBaseUrl}/api/Exercise/{id}");
                response.EnsureSuccessStatusCode();

                string responseJson = await response.Content.ReadAsStringAsync();

                Exercise exercise = JsonConvert.DeserializeObject<Exercise>(responseJson);

                return exercise;

            }
            catch (Exception ex)
            {
                //mirar como controlar esta excepción correctamente
                MessageBox.Show("No se pudo obtener la petición. \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

        }

        public async Task<bool> UpdateExercise(Exercise exercise)
        {
            try
            {
                string json = JsonConvert.SerializeObject(exercise);
                HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PutAsync($"{ApiConfiguration.ApiBaseUrl}/api/Exercise/{exercise.ID}", content);

                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                {
                    // Manejar el caso de código de estado de respuesta no exitoso
                    MessageBox.Show($"Error en la solicitud: {response.StatusCode}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show("No se pudo realizar la modificación: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            catch (Exception ex)
            {
                // Manejar otros errores
                MessageBox.Show("Error inesperado: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        public async Task<bool> InsertExercise(Exercise exercise)
        {
            try
            {
                // Serializa el objeto exercise a formato JSON
                string json = JsonConvert.SerializeObject(exercise);

                // Configura el contenido de la solicitud
                HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");

                // Realiza la solicitud POST               
                HttpResponseMessage response = await client.PostAsync($"{ApiConfiguration.ApiBaseUrl}/api/Exercise", content);
                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                {
                    // Manejar el caso de código de estado de respuesta no exitoso
                    MessageBox.Show($"Error en la solicitud: {response.StatusCode}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show("No se pudo realizar la inserción: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            catch (Exception ex)
            {
                // Manejar otros errores
                MessageBox.Show("Error inesperado: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        public async Task<bool> DeleteExercise(int id)
        {
            try
            {
                HttpResponseMessage response = await client.DeleteAsync($"{ApiConfiguration.ApiBaseUrl}/api/Exercise/DeleteExercise?id={id}");
                response.EnsureSuccessStatusCode();

                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                {
                    // Manejar el caso de código de estado de respuesta no exitoso
                    MessageBox.Show($"Error en la solicitud: {response.StatusCode}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show("No se pudo realizar la eliminación: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            catch (Exception ex)
            {
                // Manejar otros errores
                MessageBox.Show("Error inesperado: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }
}
