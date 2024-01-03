using Newtonsoft.Json;
using RutinApp.Models;

namespace RutinApp.Controllers
{
    public class ExerciseController
    {
        private HttpClient client;

        public ExerciseController()
        {
            client = new HttpClient();
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
                //mirar como controlar esta excepción correctamente
                MessageBox.Show("No se pudo obtener la petición. \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

        }
        public async Task<Exercise> GetExercise(int id)
        {
            try
            {

                //HttpResponseMessage response = await client.GetAsync("https://localhost:7137/api/Exercise/" + id);
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
    }
}
